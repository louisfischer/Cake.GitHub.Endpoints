namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repository Releases API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryDeploymentsAliases
{
    /// <summary>
    /// Gets all the deployments for the specified repository. Any user with pull access
    /// to a repository can view deployments.
    /// </summary>
    /// <remarks>
    /// http://developer.github.com/v3/repos/deployments/#list-deployments
    /// </remarks>
    public static Task<IReadOnlyList<Deployment>> GitHubRepositoryDeploymentGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Deployment.GetAll(context.Owner, context.RepoName, Options.DefaultApiOptions);

    /// <summary>
    /// Creates a new deployment for the specified repository.
    /// Users with push access can create a deployment for a given ref.
    /// </summary>
    /// <remarks>
    /// http://developer.github.com/v3/repos/deployments/#create-a-deployment
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="deployment">A <see cref="NewDeployment"/> instance describing the new deployment to create</param>
    public static Task<Deployment> GitHubRepositoryDeploymentCreate(this IGitHubEndpointContext context, NewDeployment deployment) =>
        context.GitHubClient().Repository.Deployment.Create(context.Owner, context.RepoName, deployment);

    /// <summary>
    /// Gets all the statuses for the given deployment. Any user with pull access to a repository can
    /// view deployments.
    /// </summary>
    /// <remarks>
    /// http://developer.github.com/v3/repos/deployments/#list-deployment-statuses
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="deploymentId">The id of the deployment.</param>
    public static Task<IReadOnlyList<DeploymentStatus>> GitHubRepositoryDeploymentGetAll(this IGitHubEndpointContext context, int deploymentId) =>
        context.GitHubClient().Repository.Deployment.Status.GetAll(context.Owner, context.RepoName, deploymentId);

    /// <summary>
    /// Creates a new status for the given deployment. Users with push access can create deployment
    /// statuses for a given deployment.
    /// </summary>
    /// <remarks>
    /// http://developer.github.com/v3/repos/deployments/#create-a-deployment-status
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="deploymentId">The id of the deployment.</param>
    /// <param name="deploymentStatus">The new deployment status to create.</param>
    public static Task<DeploymentStatus> GitHubRepositoryDeploymentCreate(this IGitHubEndpointContext context, int deploymentId, NewDeploymentStatus deploymentStatus) =>
        context.GitHubClient().Repository.Deployment.Status.Create(context.Owner, context.RepoName, deploymentId, deploymentStatus);
}
