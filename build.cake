#addin "nuget:?package=Cake.MinVer&version=3.0.0"
#addin "nuget:?package=Cake.Args&version=3.0.0"

var target       = ArgumentOrDefault<string>("Target") ?? "Pack";
var buildVersion = MinVer(s => s.WithTagPrefix("v").WithDefaultPreReleasePhase("preview"));

Task("Clean")
    .Does(() =>
{
    CleanDirectories("./artifact/**");
    CleanDirectories("./**/^{bin,obj}");
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetRestore("./Cake.MinVer.sln", new DotNetRestoreSettings
    {
        LockedMode = true,
    });
});

Task("Build")
    .IsDependentOn("restore")
    .DoesForEach(new[] { "Debug", "Release" }, (configuration) =>
{
    DotNetBuild("./Cake.MinVer.sln", new DotNetBuildSettings
    {
        Configuration = configuration,
        NoRestore = true,
        NoIncremental = false,
        MSBuildSettings = new DotNetMSBuildSettings
        {
            Version = buildVersion.Version,
            AssemblyVersion = buildVersion.AssemblyVersion,
            FileVersion = buildVersion.FileVersion,
            ContinuousIntegrationBuild = BuildSystem.IsLocalBuild,
        },
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    var settings = new DotNetTestSettings
    {
        Configuration = "Release",
        NoRestore = true,
        NoBuild = true,
    };

    var projectFiles = GetFiles("./test/**/*.csproj");
    foreach (var file in projectFiles)
    {
        DotNetTest(file.FullPath, settings);
    }
});

Task("Pack")
    .IsDependentOn("test")
    .Does(() =>
{
    var releaseNotes = $"https://github.com/cake-contrib/Cake.MinVer/releases/tag/v{buildVersion.Version}";

    DotNetPack("./src/Cake.MinVer/Cake.MinVer.csproj", new DotNetPackSettings
    {
        Configuration = "Release",
        NoRestore = true,
        NoBuild = true,
        OutputDirectory = "./artifact/nuget",
        MSBuildSettings = new DotNetMSBuildSettings
        {
            Version = buildVersion.Version,
            PackageReleaseNotes = releaseNotes,
        },
    });
});

Task("Push")
    .IsDependentOn("Pack")
    .Does(context =>
{
    var url =  context.EnvironmentVariable("NUGET_URL");
    if (string.IsNullOrWhiteSpace(url))
    {
        context.Information("No NuGet URL specified. Skipping publishing of NuGet packages");
        return;
    }

    var apiKey =  context.EnvironmentVariable("NUGET_API_KEY");
    if (string.IsNullOrWhiteSpace(apiKey))
    {
        context.Information("No NuGet API key specified. Skipping publishing of NuGet packages");
        return;
    }

    var nugetPushSettings = new DotNetNuGetPushSettings
    {
        Source = url,
        ApiKey = apiKey,
    };

    foreach (var nugetPackageFile in GetFiles("./artifact/nuget/*.nupkg"))
        DotNetNuGetPush(nugetPackageFile.FullPath, nugetPushSettings);
});

RunTarget(target);
