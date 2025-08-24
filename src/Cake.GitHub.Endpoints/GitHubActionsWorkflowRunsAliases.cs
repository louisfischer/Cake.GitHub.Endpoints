namespace Cake.GitHub.Endpoints;

/// <summary>
///  Contains functionality for working with the GitHubActions Workflow Runs API.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubActionsWorkflowRunsAliases
{
    /// <summary>
    /// Lists all workflow runs for a repository.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-workflow-runs-for-a-repository
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    public static Task<WorkflowRunsResponse> GitHubActionsWorkflowRunsList(this IGitHubEndpointContext context) =>
        context.GitHubClient().Actions.Workflows.Runs.List(context.Owner, context.RepoName);

    /// <summary>
    /// Lists all workflow runs for a repository.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-workflow-runs-for-a-repository
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowRunsRequest">Details to filter the request, such as by check suite Id.</param>
    public static Task<WorkflowRunsResponse> GitHubActionsWorkflowRunsList(this IGitHubEndpointContext context, WorkflowRunsRequest workflowRunsRequest) =>
        context.GitHubClient().Actions.Workflows.Runs.List(context.Owner, context.RepoName, workflowRunsRequest);

    /// <summary>
    /// Gets a specific workflow run in a repository. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#get-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task<WorkflowRun> GitHubActionsWorkflowRunsGet(this IGitHubEndpointContext context, long runId) =>
       context.GitHubClient().Actions.Workflows.Runs.Get(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Deletes a specific workflow run. Anyone with write access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#delete-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task GitHubActionsWorkflowRunsDelete(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.Delete(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Get the review history for a workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#get-the-review-history-for-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task<IReadOnlyList<EnvironmentApprovals>> GitHubActionsWorkflowRunsGetReviewHistory(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.GetReviewHistory(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Approve or reject pending deployments that are waiting on approval by a required reviewer.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#review-pending-deployments-for-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    /// <param name="review">The review for the pending deployment.</param>
    public static Task<Deployment> GitHubActionsWorkflowRunsReviewPendingDeployments(this IGitHubEndpointContext context, long runId, PendingDeploymentReview review) =>
        context.GitHubClient().Actions.Workflows.Runs.ReviewPendingDeployments(context.Owner, context.RepoName, runId, review);

    /// <summary>
    /// Approves a workflow run for a pull request from a public fork of a first time contributor.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#approve-a-workflow-run-for-a-fork-pull-request
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task GitHubActionsWorkflowRunsApprove(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.Approve(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Gets a specific workflow run attempt. Anyone with read access to the repository can use this endpoint.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#get-a-workflow-run-attempt
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    /// <param name="attemptNumber">The attempt number of the workflow run.</param>
    public static Task<WorkflowRun> GitHubActionsWorkflowRunsGetAttempt(this IGitHubEndpointContext context, long runId, long attemptNumber) =>
        context.GitHubClient().Actions.Workflows.Runs.GetAttempt(context.Owner, context.RepoName, runId, attemptNumber);

    /// <summary>
    /// Gets a byte array containing an archive of log files for a specific workflow run attempt.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#download-workflow-run-attempt-logs
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    /// <param name="attemptNumber">The attempt number of the workflow run.</param>
    public static Task<byte[]> GitHubActionsWorkflowRunsGetAttemptLogs(this IGitHubEndpointContext context, long runId, long attemptNumber) =>
        context.GitHubClient().Actions.Workflows.Runs.GetAttemptLogs(context.Owner, context.RepoName, runId, attemptNumber);

    /// <summary>
    /// Cancels a workflow run using its Id.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#cancel-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task GitHubActionsWorkflowRunsCancel(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.Cancel(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Gets a byte array containing an archive of log files for a workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#download-workflow-run-logs
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task<byte[]> GitHubActionsWorkflowRunsGetLogs(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.GetLogs(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Deletes all logs for a workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#delete-workflow-run-logs
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task GitHubActionsWorkflowRunsDeleteLogs(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.DeleteLogs(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Re-runs your workflow run using its Id.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#re-run-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task GitHubActionsWorkflowRunsRerun(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.Rerun(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Re-run all of the failed jobs and their dependent jobs in a workflow run using the Id of the workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#re-run-failed-jobs-from-a-workflow-run
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task GitHubActionsWorkflowRunsRerunFailedJobs(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.RerunFailedJobs(context.Owner, context.RepoName, runId);

    /// <summary>
    /// Gets the number of billable minutes and total run time for a specific workflow run.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#get-workflow-run-usage
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="runId">The Id of the workflow run.</param>
    public static Task<WorkflowRunUsage> GitHubActionsWorkflowRunsGetUsage(this IGitHubEndpointContext context, long runId) =>
        context.GitHubClient().Actions.Workflows.Runs.GetUsage(context.Owner, context.RepoName, runId);

    /// <summary>
    /// List all workflow runs for a workflow.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-workflow-runs-for-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowId">The Id of the workflow.</param>
    public static Task<WorkflowRunsResponse> GitHubActionsWorkflowRunsListByWorkflow(this IGitHubEndpointContext context, long workflowId) =>
        context.GitHubClient().Actions.Workflows.Runs.ListByWorkflow(context.Owner, context.RepoName, workflowId);

    /// <summary>
    /// List all workflow runs for a workflow.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-workflow-runs-for-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    public static Task<WorkflowRunsResponse> GitHubActionsWorkflowRunsListByWorkflow(this IGitHubEndpointContext context, string workflowFileName) =>
        context.GitHubClient().Actions.Workflows.Runs.ListByWorkflow(context.Owner, context.RepoName, workflowFileName);

    /// <summary>
    /// List all workflow runs for a workflow.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-workflow-runs-for-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowId">The Id of the workflow.</param>
    /// <param name="workflowRunsRequest">Details to filter the request, such as by check suite Id.</param>
    public static Task<WorkflowRunsResponse> GitHubActionsWorkflowRunsListByWorkflow(this IGitHubEndpointContext context, long workflowId, WorkflowRunsRequest workflowRunsRequest) =>
        context.GitHubClient().Actions.Workflows.Runs.ListByWorkflow(context.Owner, context.RepoName, workflowId, workflowRunsRequest);

    /// <summary>
    /// List all workflow runs for a workflow.
    /// </summary>
    /// <remarks>
    /// https://developer.github.com/v3/actions/workflow-runs/#list-workflow-runs-for-a-workflow
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="workflowFileName">The workflow file name.</param>
    /// <param name="workflowRunsRequest">Details to filter the request, such as by check suite Id.</param>
    public static Task<WorkflowRunsResponse> GitHubActionsWorkflowRunsListByWorkflow(this IGitHubEndpointContext context, string workflowFileName, WorkflowRunsRequest workflowRunsRequest) =>
         context.GitHubClient().Actions.Workflows.Runs.ListByWorkflow(context.Owner, context.RepoName, workflowFileName, workflowRunsRequest);
}