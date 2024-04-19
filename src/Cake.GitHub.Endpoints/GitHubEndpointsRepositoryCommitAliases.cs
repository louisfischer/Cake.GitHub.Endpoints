namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repository Commits API
/// </summary>
/// <remarks>
/// See the <a href="http://developer.github.com/v3/repos/commits/">Repository Commits API documentation</a> for more information.
/// </remarks>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryCommitAliases
{
    /// <summary>
    /// Gets all <see cref="Branch"/>s for the specified repository commit
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#list-releases-for-a-repository">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="sha1">Used to find all branches where the given commit SHA is the HEAD, or latest commit for the branch</param>
    public static Task<IReadOnlyList<Branch>> GitHubRepositoryCommitBranchesWhereHead(this IGitHubEndpointContext context, string sha1) =>
        context.GitHubClient().Repository.Commit.BranchesWhereHead(context.Owner, context.RepoName, sha1, Options.DefaultApiOptions);

    /// <summary>
    /// Compare two references in a repository
    /// </summary>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="base">The reference to use as the base commit</param>
    /// <param name="head">The reference to use as the head commit</param>
    public static Task<CompareResult> GitHubRepositoryCommitCompare(this IGitHubEndpointContext context, string @base, string head) =>
        context.GitHubClient().Repository.Commit.Compare(context.Owner, context.RepoName, @base, head, Options.DefaultApiOptions);

    /// <summary>
    /// Gets a single commit for a given repository
    /// </summary>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="reference">The reference for the commit (SHA)</param>
    public static Task<GitHubCommit> GitHubRepositoryCommitGet(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Repository.Commit.Get(context.Owner, context.RepoName, reference);

    /// <summary>
    /// Gets all commits for a given repository
    /// </summary>
    /// <param name="context">The GitHubEndpointContext context</param>
    public static Task<IReadOnlyList<GitHubCommit>> GitHubRepositoryCommitGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Commit.GetAll(context.Owner, context.RepoName);

    /// <summary>
    /// Get the SHA-1 of a commit reference
    /// </summary>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="reference">The repository reference</param>
    public static Task<string> GitHubRepositoryCommitSha1(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Repository.Commit.GetSha1(context.Owner, context.RepoName, reference);

    /// <summary>
    /// List pull requests associated with a commit
    /// </summary>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="sha1">Used to find all pull requests containing the provided commit SHA, which can be from any point in the commit history</param>
    public static Task<IReadOnlyList<CommitPullRequest>> GitHubRepositoryCommitPullRequests(this IGitHubEndpointContext context, string sha1) =>
        context.GitHubClient().Repository.Commit.PullRequests(context.Owner, context.RepoName, sha1, Options.DefaultApiOptions);
}
