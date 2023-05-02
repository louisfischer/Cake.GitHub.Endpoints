using Cake.GitHub.Endpoints;

internal static class GitHubEndpointsAddinInformation
{
#pragma warning disable CS8601 // Possible null reference assignment.
    private static readonly string InformationalVersion = typeof(GitHubEndpointsAddinInformation).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    private static readonly string AssemblyVersion = typeof(GitHubEndpointsAddinInformation).GetTypeInfo().Assembly.GetName().Version.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
    private static readonly string AssemblyName = typeof(GitHubEndpointsAddinInformation).GetTypeInfo().Assembly.GetName().Name;
#pragma warning restore CS8601 // Possible null reference assignment.

    /// <summary>
    /// verbosely log addin version information
    /// </summary>
    /// <param name="log"></param>
    public static void LogVersionInformation(ICakeLog log) => log.Verbose(entry => entry("Using addin: {0} v{1} ({2})", AssemblyName, AssemblyVersion, InformationalVersion));
}
