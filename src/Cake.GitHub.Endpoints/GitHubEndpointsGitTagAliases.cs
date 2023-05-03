namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repositories API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsGitTagAliases
{
    /// <summary>
    /// Gets a tag for a given repository by sha reference
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="reference">Tha sha reference of the tag.</param>
    /// <returns><see cref="GitTag"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/tags/#get-a-tag">http://developer.github.com/v3/git/tags/#get-a-tag</seealso>
    /// </remarks>
    public static Task<GitTag> GitHubGitTag(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Git.Tag.Get(context.Owner, context.RepoName, reference);

    /// <summary>
    /// Creates a tag for a given repository
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="tag">The tag</param>
    /// <param name="message">Tag Message</param>
    /// <param name="reference">The SHA of the git object this is tagging</param>
    /// <param name="name">The full name of the author or committer.</param>
    /// <param name="email">The email of the author or committer.</param>
    /// <param name="taggedType">The type of the object we’re tagging. Defaults to Commit.</param>
    /// <returns><see cref="GitTag"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/tags/#create-a-tag-object">http://developer.github.com/v3/git/tags/#create-a-tag-object</seealso>
    ///  <br />
    ///  Note that creating a tag object does not create the reference that makes a tag in Git. If you want to create
    ///  an annotated tag in Git, you have to do this call to create the tag object, and then create the
    ///  refs/tags/[tag] reference. If you want to create a lightweight tag, you only have to create the tag reference
    ///  - this call would be unnecessary.
    /// </remarks>
    public static Task<GitTag> GitHubGitTagCreate(this IGitHubEndpointContext context, string tag, string message, string reference, string name, string email, TaggedType taggedType = TaggedType.Commit) =>
        context.GitHubClient().Git.Tag.Create(context.Owner, context.RepoName, new NewTag
        {
             Tag = tag,
             Message = message,
             Object = reference,
             Type = taggedType,
             Tagger = new Committer(name, email, DateTimeOffset.UtcNow)
        });
}
