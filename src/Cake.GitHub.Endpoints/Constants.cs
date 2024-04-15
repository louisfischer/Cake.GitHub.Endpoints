namespace Cake.GitHub.Endpoints;

internal static class Constants
{
    public static class HttpHeaders
    {
        public static class Values
        {
            public const string UserAgent = "cake-gh-endpoints";
        }
    }

    public static class Options
    {
        public static readonly ApiOptions DefaultApiOptions = new ApiOptions { PageSize = 100 };
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

    public static class GraphQL
    {
        public const string ApiUrl = "https://api.github.com/graphql";

        #region Mutations
        public static class Mutations
        {
            public const string enablePullRequestAutoMerge = "mutation PullRequestAutoMerge { enablePullRequestAutoMerge(input: {pullRequestId: \"{0}\", mergeMethod: {1}}) { clientMutationId } }";
        }
        #endregion
    }
}
