namespace Cake.GitHub.Endpoints;

/// <summary>
/// 
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubActionsWorkflowsAliases
{
    /// <summary>
    /// Manually triggers a GitHub Actions workflow run in a repository by slug.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#create-a-workflow-dispatch-event
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    /// <param name="createDispatch">The parameters to use to trigger the workflow run.</param>
    public static Task GitHubActionsWorkflowsCreateDispatch(this IGitHubEndpointContext context, string workflowFileName, CreateWorkflowDispatch createDispatch) =>
        context.GitHubClient().Actions.Workflows.CreateDispatch(context.Owner, context.Owner, workflowFileName, createDispatch);

    /// <summary>
    /// Disables a specific workflow in a repository by Id.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#disable-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    public static Task Disable(this IGitHubEndpointContext context, string workflowFileName) =>
        context.GitHubClient().Actions.Workflows.Disable(context.Owner, context.Owner, workflowFileName);

    /// <summary>
    /// Disables a specific workflow in a repository by Id.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#disable-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowId">The Id of the workflow.</param>
    public static Task Disable(this IGitHubEndpointContext context, long workflowId) =>
        context.GitHubClient().Actions.Workflows.Disable(context.Owner, context.Owner, workflowId);

    /// <summary>
    /// Enables a specific workflow in a repository by Id.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#enable-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    public static Task Enable(this IGitHubEndpointContext context, string workflowFileName) =>
        context.GitHubClient().Actions.Workflows.Enable(context.Owner, context.Owner, workflowFileName);

    /// <summary>
    /// Enables a specific workflow in a repository by Id.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#enable-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowId">The Id of the workflow.</param>
    public static Task Enable(this IGitHubEndpointContext context, long workflowId) =>
        context.GitHubClient().Actions.Workflows.Enable(context.Owner, context.Owner, workflowId);

    /// <summary>
    /// Gets a specific workflow in a repository by Id. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#get-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    public static Task<Workflow> Get(this IGitHubEndpointContext context, string workflowFileName) =>
        context.GitHubClient().Actions.Workflows.Get(context.Owner, context.Owner, workflowFileName);

    /// <summary>
    /// Gets a specific workflow in a repository by Id. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#get-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowId">The Id of the workflow.</param>
    public static Task<Workflow> Get(this IGitHubEndpointContext context, long workflowId) =>
        context.GitHubClient().Actions.Workflows.Get(context.Owner, context.Owner, workflowId);

    /// <summary>
    /// Gets useage of a specific workflow in a repository by Id. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#get-workflow-usage
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    public static Task<WorkflowUsage> GetUsage(this IGitHubEndpointContext context, string workflowFileName) =>
        context.GitHubClient().Actions.Workflows.GetUsage(context.Owner, context.Owner, workflowFileName);

    /// <summary>
    /// Gets useage of a specific workflow in a repository by Id. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#get-workflow-usage
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowId">The Id of the workflow.</param>
    public static Task<WorkflowUsage> GetUsage(this IGitHubEndpointContext context, long workflowId) =>
        context.GitHubClient().Actions.Workflows.GetUsage(context.Owner, context.Owner, workflowId);

    /// <summary>
    /// Lists the workflows in a repository. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflows/#list-repository-workflows
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    public static Task<WorkflowsResponse> List(this IGitHubEndpointContext context) =>
        context.GitHubClient().Actions.Workflows.List(context.Owner, context.Owner);
}