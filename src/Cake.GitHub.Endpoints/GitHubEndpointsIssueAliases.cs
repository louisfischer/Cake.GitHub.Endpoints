namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repositories API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsIssueAliases
{
    /// <summary>
    /// Locks an issue for the specified repository. Issue owners and users with push access can lock an issue or pull request's conversation.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The issue number.</param>
    /// <param name="lockReason">The reason for locking the issue</param>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/issues/#lock-an-issue">https://developer.github.com/v3/issues/#lock-an-issue</seealso>
    /// </remarks>
    public static Task GitHubIssueLock(this IGitHubEndpointContext context, int number, LockReason? lockReason = null)
        => context.GitHubClient().Issue.LockUnlock.Lock(context.Owner, context.RepoName, number, lockReason);

    /// <summary>
    /// Unlocks an issue for the specified repository. Issue owners and users with push access can unlock an issue or pull request's conversation.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The Pull request number.</param>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/issues/#unlock-an-issue">https://developer.github.com/v3/issues/#unlock-an-issue</seealso>
    /// </remarks>
    public static Task GitHubIssueUnlock(this IGitHubEndpointContext context, int number)
        => context.GitHubClient().Issue.LockUnlock.Unlock(context.Owner, context.RepoName, number);
}
