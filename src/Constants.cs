namespace Cake.GitHub.Endpoints;

internal static class Constants
{
    public static class HttpHeaders
    {
        public static class Values
        {
            public const string UserAgent = "Cake GitHub Endpoints Client";

            public static class ContentTypes
            {
                public const string ApplicationJson = "application/json";
                public const string GitHubJson = "application/vnd.github+json";
                public const string GitHubRaw = "application/vnd.github.raw";
                public const string GitHubHtml = "application/vnd.github.html";
                public const string GitHubObject = "application/vnd.github.object";
            }
        }
    }

    public static class Repos
    {
        public static class Contents
        {
            public static class Defaults
            {
                public const string Message = "File uploaded: {0}";
                public const string Branch = "main";
            }
        }
    }
}
