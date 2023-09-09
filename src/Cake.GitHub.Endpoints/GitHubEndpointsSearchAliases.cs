namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Search API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsSearchAliases
{
    /// <summary>
    /// Search Repos
    /// </summary>
    /// <seealso href="http://developer.github.com/v3/search/#search-repositories"/>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="request">Searching Request</param>
    /// <returns>List of repos</returns>
    public static Task<SearchRepositoryResult> GitHubSearchRepos(this IGitHubEndpointContext context, SearchRepositoriesRequest request) => context.GitHubClient().Search.SearchRepo(request);

    /// <summary>
    /// Search Users
    /// </summary>
    /// <seealso href="http://developer.github.com/v3/search/#search-users"/>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="request">Searching Request</param>
    /// <returns>List of users</returns>
    public static Task<SearchUsersResult> GitHubSearchUsers(this IGitHubEndpointContext context, SearchUsersRequest request) => context.GitHubClient().Search.SearchUsers(request);

    /// <summary>
    /// Search Issues
    /// </summary>
    /// <seealso href="http://developer.github.com/v3/search/#search-issues"/>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="request">Searching Request</param>
    /// <returns>List of issues</returns>
    public static Task<SearchIssuesResult> GitHubSearchIssues(this IGitHubEndpointContext context, SearchIssuesRequest request) => context.GitHubClient().Search.SearchIssues(request);

    /// <summary>
    /// Search Code
    /// </summary>
    /// <seealso href="http://developer.github.com/v3/search/#search-issues"/>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="request">Searching Request</param>
    /// <returns>List of files</returns>
    public static Task<SearchCodeResult> GitHubSearchCode(this IGitHubEndpointContext context, SearchCodeRequest request) => context.GitHubClient().Search.SearchCode(request);

    /// <summary>
    /// Search Labels
    /// </summary>
    /// <seealso href="http://developer.github.com/v3/search/#search-issues"/>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="request">Searching Request</param>
    /// <returns>LList of labels</returns>
    public static Task<SearchLabelsResult> GitHubSearchLabels(this IGitHubEndpointContext context, SearchLabelsRequest request) => context.GitHubClient().Search.SearchLabels(request);
}
