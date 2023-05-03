namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working withGitHub's Git Database API. Gives you access to read and write raw Git objects and to list and update your references.
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
    /// <returns><see cref="Blob"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/blobs/#get-a-blob">http://developer.github.com/v3/git/blobs/#get-a-blob</seealso>
    /// </remarks>
    public static Task<Commit> GitHubGitBlob(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Git.Commit.Get(context.Owner, context.RepoName, reference);

    /// <summary>
    /// Creates a new Blob
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="content">The content of the blob.</param>
    /// <param name="encoding">The encoding of the blob.</param>
    /// <returns><see cref="BlobReference"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/blobs/#create-a-blob">http://developer.github.com/v3/git/blobs/#create-a-blob</seealso>
    /// </remarks>
    public static Task<BlobReference> GitHubGitTagCreate(this IGitHubEndpointContext context, string content, EncodingType encoding) =>
        context.GitHubClient().Git.Blob.Create(context.Owner, context.RepoName, new NewBlob
        {
             Content = content,
             Encoding = encoding
        });
}
