namespace Cake.GitHub.Endpoints;

/// <summary>
///
/// </summary>
public static class GitHubEndpointsRepositoryEnvironmentAliases
{
    /// <summary>
    /// Gets all the environments for the specified repository. Any user with pull access
    /// to a repository can view deployments.
    /// </summary>
    /// <remarks>
    /// https://docs.github.com/en/rest/deployments/environments#list-environments
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    public static Task<DeploymentEnvironmentsResponse> GitHubRepositoryEnvironmentGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Environment.GetAll(context.Owner, context.RepoName, Options.DefaultApiOptions);
}
