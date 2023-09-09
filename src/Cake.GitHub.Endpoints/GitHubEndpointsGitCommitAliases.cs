namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub's Git Database API. Gives you access to read and write raw Git objects and to list and update your references.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsGitCommitAliases
{
    /// <summary>
    ///  Gets a commit for a given repository by sha reference
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="reference">Tha sha reference of the commit</param>
    /// <returns><see cref="Commit"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/commits/#get-a-commit">http://developer.github.com/v3/git/commits/#get-a-commit</seealso>
    /// </remarks>
    public static Task<Commit> GitHubGitCommit(this IGitHubEndpointContext context, string reference) => context.GitHubClient().Git.Commit.Get(context.Owner, context.RepoName, reference);

    /// <summary>
    /// Create a commit for a given repository
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="commit">The commit to create</param>
    /// <returns><see cref="BlobReference"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/commits/#create-a-commit">http://developer.github.com/v3/git/commits/#create-a-commit</seealso>
    /// </remarks>
    public static Task<Commit> GitHubGitCommitCreate(this IGitHubEndpointContext context, NewCommit commit) => context.GitHubClient().Git.Commit.Create(context.Owner, context.RepoName, commit);
}
