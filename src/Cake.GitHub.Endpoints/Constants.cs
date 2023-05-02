namespace Cake.GitHub.Endpoints;

internal static class Constants
{
    public static class HttpHeaders
    {
        public static class Values
        {
            public const string UserAgent = "Cake GitHub Endpoints Client";
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
