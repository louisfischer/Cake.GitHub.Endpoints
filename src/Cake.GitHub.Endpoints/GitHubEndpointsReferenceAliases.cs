namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for Create Branches and Tags GitHub APi.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsReferenceAliases
{
    /// <summary>
    ///  Gets a reference for a given repository by reference name (branch, tag, etc)
    /// </summary>
    /// <param name="context">Github Context</param>
    /// <param name="reference">The reference name</param>
    /// <returns><see cref="Reference"/></returns>
    /// <remarks>
    /// The reference parameter supports either the fully-qualified ref
    /// (prefixed with  "refs/", e.g. "refs/heads/main" or
    /// "refs/tags/release-1") or the shortened form (omitting "refs/", e.g.
    /// "heads/main" or "tags/release-1"). <br/>
    /// <see href="http://developer.github.com/v3/git/refs/#get-a-reference">API Reference</see>
    /// </remarks>
    public static Task<Reference> GitHubReference(this IGitHubEndpointContext context, string reference)
    {
        if(context == null) throw new ArgumentNullException(nameof(context));
        if(string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException(nameof(reference));

        return context.GitHubClient().Git.Reference.Get(context.Owner, context.RepoName, reference);
    }

    /// <summary>
    /// Creates a reference for a given repository
    /// </summary>
    /// <param name="context">Github Context</param>
    /// <param name="reference"> name of the fully qualified reference (ie: refs/heads/main). If it doesn’t start with ‘refs’ and have at least two slashes, it will be rejected.</param>
    /// <param name="sha">The SHA1 value to set this reference t</param>
    /// <returns><see cref="Reference"/></returns>
    /// <remarks>
    /// The reference parameter supports either the fully-qualified ref
    /// (prefixed with  "refs/", e.g. "refs/heads/main" or
    /// "refs/tags/release-1") or the shortened form (omitting "refs/", e.g.
    /// "heads/main" or "tags/release-1") <br /><br />
    /// API: <see href="https://developer.github.com/v3/git/refs/#create-a-reference">https://developer.github.com/v3/git/refs/#create-a-reference</see>
    ///</remarks>
    public static Task<Reference> GitHubReferenceCreate(this IGitHubEndpointContext context, string reference, string sha)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException(nameof(reference));
        if (string.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));

        return context.GitHubClient().Git.Reference.Create(context.Owner, context.RepoName, new NewReference(reference, sha));
    }

    /// <summary>
    /// Updates a reference for a given repository by reference name
    /// </summary>
    /// <param name="context">Github Context</param>
    /// <param name="reference">The reference name</param>
    /// <param name="sha">The SHA1 value to set this reference t</param>
    /// <param name="force"> Indicates whether to force the update or to make sure the update is a fast-forward update. Leaving this out or setting it to false will make sure you’re not overwriting work.</param>
    /// <returns><see cref="Reference"/></returns>
    /// <remarks>
    /// The reference parameter supports either the fully-qualified ref
    /// (prefixed with  "refs/", e.g. "refs/heads/main" or
    /// "refs/tags/release-1") or the shortened form (omitting "refs/", e.g.
    /// "heads/main" or "tags/release-1") <br /><br />
    /// API: <see href="http://developer.github.com/v3/git/refs/#update-a-reference">http://developer.github.com/v3/git/refs/#update-a-reference</see>
    /// </remarks>
    public static Task<Reference> GitHubReferenceUpdate(this IGitHubEndpointContext context, string reference, string sha, bool force = false)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException(nameof(reference));
        if (string.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));

        return context.GitHubClient().Git.Reference.Update(context.Owner, context.RepoName, reference, new ReferenceUpdate(sha, force));
    }

    /// <summary>
    /// Deletes a reference for a given repository by reference name
    /// </summary>
    /// <param name="context">Github Context</param>
    /// <param name="reference">The reference name</param>
    /// <remarks>
    /// The reference parameter supports either the fully-qualified ref
    /// (prefixed with  "refs/", e.g. "refs/heads/main" or
    /// "refs/tags/release-1") or the shortened form (omitting "refs/", e.g.
    /// "heads/main" or "tags/release-1") <br /><br />
    /// API: <see href="http://developer.github.com/v3/git/refs/#delete-a-reference">http://developer.github.com/v3/git/refs/#delete-a-reference</see>
    /// </remarks>
    public static Task GitHubReferenceDelete(this IGitHubEndpointContext context, string reference)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException(nameof(reference));

        return context.GitHubClient().Git.Reference.Delete(context.Owner, context.RepoName, reference);
    }
}
