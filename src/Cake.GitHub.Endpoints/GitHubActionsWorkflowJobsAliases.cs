namespace Cake.GitHub.Endpoints;

/// <summary>
///  Contains functionality for working with the GitHubActions Workflow Jobs API.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubActionsWorkflowJobsAliases
{
    /// <summary>
    /// Re-runs a specific workflow job in a repository.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#re-run-a-job-from-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="jobId">The Id of the workflow job.</param>
    public static Task GitHubActionsWorkflowJobsRerun(this IGitHubEndpointContext context, long jobId) =>
        context.GitHubClient().Actions.Workflows.Jobs.Rerun(context.Owner, context.RepoName, jobId);

    /// <summary>
    /// Gets a specific job in a workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-jobs/#get-a-job-for-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="jobId">The unique identifier of the job.</param>
    public static Task<WorkflowJob> GitHubActionsWorkflowJobsGet(this IGitHubEndpointContext context, long jobId) =>
        context.GitHubClient().Actions.Workflows.Jobs.Get(context.Owner, context.RepoName, jobId);

    /// <summary>
    /// Gets the plain text log file for a workflow job.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-jobs/#download-job-logs-for-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="jobId">The Id of the workflow job.</param>
    public static Task<string> GitHubActionsWorkflowJobsGetLogs(this IGitHubEndpointContext context, long jobId) =>
        context.GitHubClient().Actions.Workflows.Jobs.GetLogs(context.Owner, context.RepoName, jobId);

    /// <summary>
    /// Lists jobs for a specific workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-jobs-for-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task<WorkflowJobsResponse> GitHubActionsWorkflowJobsList(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Jobs.List(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Lists jobs for a specific workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-jobs-for-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    /// <param name="workflowRunJobsRequest">Details to filter the request, such as by when completed.</param>
    public static Task<WorkflowJobsResponse> GitHubActionsWorkflowJobsList(this IGitHubEndpointContext context, long runId, WorkflowRunJobsRequest workflowRunJobsRequest) =>
        context.GitHubClient().Actions.Workflows.Jobs.List(context.Owner, context.RepoName, runId, workflowRunJobsRequest);

    /// <summary>
    /// Lists jobs for a specific workflow run attempt.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-jobs-for-a-workflow-run-attempt
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    /// <param name="attemptNumber">The attempt number of the workflow run.</param>
    public static Task<WorkflowJobsResponse> GitHubActionsWorkflowJobsList(this IGitHubEndpointContext context, long runId, int attemptNumber) =>
        context.GitHubClient().Actions.Workflows.Jobs.List(context.Owner, context.RepoName, runId, attemptNumber);
}