namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub's Git Trees API.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsGitTreeAliases
{
    /// <summary>
    /// Gets a Tree Response for a given SHA.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="reference">The sha reference of the tag.</param>
    /// <returns><see cref="TreeResponse"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/trees/#get-a-tree">http://developer.github.com/v3/git/trees/#get-a-tree</seealso>
    /// </remarks>
    public static Task<TreeResponse> GitHubGitTree(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Git.Tree.Get(context.Owner, context.RepoName, reference);

    /// <summary>
    /// Gets a Tree Response for a given SHA.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="reference">The sha reference of the tag.</param>
    /// <returns><see cref="TreeResponse"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/git/trees/#get-a-tree-recursively">https://developer.github.com/v3/git/trees/#get-a-tree-recursively</seealso>
    /// </remarks>
    public static Task<TreeResponse> GitHubGitTreeRecursive(this IGitHubEndpointContext context, string reference) =>
        context.GitHubClient().Git.Tree.GetRecursive(context.Owner, context.RepoName, reference);

    /// <summary>
    ///  Creates a new Tree in the specified repo
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="sha">The SHA1 of the tree you want to update with new data.</param>
    /// <param name="tree">The list of Tree Items for this new Tree item.</param>
    /// <returns><see cref="TreeResponse"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/git/trees/#create-a-tree">http://developer.github.com/v3/git/trees/#create-a-tree</seealso>
    ///  <br />
    ///  The tree creation API will take nested entries as well. If both a tree and a nested path modifying that tree
    ///  are specified, it will overwrite the contents of that tree with the new path contents and write a new tree out.
    /// </remarks>
    public static Task<TreeResponse> GitHubGitTreeCreate(this IGitHubEndpointContext context, string sha, IList<NewTreeItem> tree)
    {
        var items = new NewTree { BaseTree = sha };
        if (tree != null && tree.Count > 0)
            foreach (var item in tree)
                items.Tree.Add(item);

        return context.GitHubClient().Git.Tree.Create(context.Owner, context.RepoName, items);
    }
}
