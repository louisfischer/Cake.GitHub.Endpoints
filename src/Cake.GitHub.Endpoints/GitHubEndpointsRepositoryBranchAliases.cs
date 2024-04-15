namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repository Branches API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryBranchAliases
{
    /// <summary>
    /// Gets all the branches for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/branches/#list-branches">API documentation</a> for more details
    /// </remarks>
    public static Task<IReadOnlyList<Branch>> GitHubRepositoryBranch(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Branch.GetAll(context.Owner, context.RepoName);

    /// <summary>
    /// Gets the specified branch.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/branches/#get-branch">API documentation</a> for more details
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="branch">The name of the branch</param>
    public static Task<Branch> GitHubRepositoryBranchGet(this IGitHubEndpointContext context, string branch) =>
        context.GitHubClient().Repository.Branch.Get(context.Owner, context.RepoName, branch);

    /// <summary>
    /// Get the branch protection settings for the specified branch
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/branches/#get-branch-protection">API documentation</a> for more details
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="branch">The name of the branch</param>
    public static Task<BranchProtectionSettings> GitHubRepositoryBranchProtectionGet(this IGitHubEndpointContext context, string branch) =>
        context.GitHubClient().Repository.Branch.GetBranchProtection(context.Owner, context.RepoName, branch);

    /// <summary>
    /// Renames a branch in a repository
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/branches/branches?apiVersion=2022-11-28#rename-a-branch">API documentation</a> for more details
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="branch">The name of the branch to rename</param>
    /// <param name="newName">The new name of the branch</param>
    public static Task<Branch> GitHubRepositoryBranchRename(this IGitHubEndpointContext context, string branch, string newName) =>
        context.GitHubClient().Repository.Branch.RenameBranch(context.Owner, context.RepoName, branch, newName);

    /// <summary>
    /// Get the required status checks for the specified branch
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/branches/#get-required-status-checks-of-protected-branch">API documentation</a> for more details
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="branch">The name of the branch</param>
    public static Task<BranchProtectionRequiredStatusChecks> GitHubRepositoryBranchRequiredStatusChecks(this IGitHubEndpointContext context, string branch) =>
        context.GitHubClient().Repository.Branch.GetRequiredStatusChecks(context.Owner, context.RepoName, branch);

    /// <summary>
    /// Get restrictions for the specified branch (applies only to Organization owned repositories)
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/branches/#get-restrictions-of-protected-branch">API documentation</a> for more details
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="branch">The name of the branch</param>
    public static Task<BranchProtectionPushRestrictions> GitHubRepositoryBranchProtectedRestrictions(this IGitHubEndpointContext context, string branch) =>
        context.GitHubClient().Repository.Branch.GetProtectedBranchRestrictions(context.Owner, context.RepoName, branch);
}
