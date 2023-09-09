namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub's Git Blobs API.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsGitBlobAliases
{
    /// <summary>
    ///  Gets a single Blob by SHA.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="reference">The SHA of the blob</param>
    /// <returns><see cref="Blob"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/blobs/#get-a-blob">http://developer.github.com/v3/git/blobs/#get-a-blob</seealso>
    /// </remarks>
    public static Task<Blob> GitHubGitBlob(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Git.Blob.Get(context.Owner, context.RepoName, reference);

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
    public static Task<BlobReference> GitHubGitBlobCreate(this IGitHubEndpointContext context, string content, EncodingType encoding) =>
        context.GitHubClient().Git.Blob.Create(context.Owner, context.RepoName, new NewBlob
        {
             Content = content,
             Encoding = encoding
        });
}
