using Cake.Http;

namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Pull Requests API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsPullRequestAliases
{
    /// <summary>
    /// Get a pull request by number.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">Pull request number</param>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#get-a-single-pull-request">http://developer.github.com/v3/pulls/#get-a-single-pull-request</seealso>
    /// </remarks>
    public static Task<PullRequest> GitHubPullRequest(this IGitHubEndpointContext context, int number)
            => context.GitHubClient().PullRequest.Get(context.Owner, context.RepoName, number);


    /// <summary>
    /// Get all open pull requests for the repository.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <returns><see cref="IReadOnlyList{PullRequest}"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#get-a-single-pull-request">http://developer.github.com/v3/pulls/#get-a-single-pull-request</seealso>
    /// </remarks>
    public static Task<IReadOnlyList<PullRequest>> GitHubPullRequestAll(this IGitHubEndpointContext context)
            => context.GitHubClient().PullRequest.GetAllForRepository(context.Owner, context.RepoName);

    /// <summary>
    /// Create a pull request for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="title">The title of the pull request.</param>
    /// <param name="head">The branch (or git ref where your changes are implemented. In other words, the source branch/ref</param>
    /// <param name="baseRef">The base (or git ref) reference you want your changes pulled into. In other words, the target branch/ref</param>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#create-a-pull-request">http://developer.github.com/v3/pulls/#create-a-pull-request</seealso>
    /// </remarks>
    public static Task<PullRequest> GitHubPullRequestCreate(this IGitHubEndpointContext context, string title, string head, string baseRef)
            => context.GitHubClient().PullRequest.Create(context.Owner, context.RepoName, new NewPullRequest(title: title, head: head, baseRef: baseRef));

    /// <summary>
    /// Create a pull request for the specified repository from an existing Issue Id
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="issueId">The number of an existing issue to convert into a pull request.</param>
    /// <param name="head">The branch (or git ref where your changes are implemented. In other words, the source branch/ref</param>
    /// <param name="baseRef">The base (or git ref) reference you want your changes pulled into. In other words, the target branch/ref</param>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#create-a-pull-request">http://developer.github.com/v3/pulls/#create-a-pull-request</seealso>
    /// </remarks>
    public static Task<PullRequest> GitHubPullRequestCreateFromIssue(this IGitHubEndpointContext context, int issueId, string head, string baseRef)
            => context.GitHubClient().PullRequest.Create(context.Owner, context.RepoName, new NewPullRequest(issueId: issueId, head: head, baseRef: baseRef));

    /// <summary>
    /// Updates an pull request for the specified repository from an existing Issue Id
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The number of the pull request to update.</param>
    /// <param name="title">Title of the pull request (required)</param>
    /// <param name="comment">The body for the pull request. Supports GitHub Flavored Markdown.</param>
    /// <param name="isOpen">Whether the pull request is open or closed. The default is open</param>
    /// <param name="branch">The branch (or git ref where your changes are implemented. In other words, the source branch/ref</param>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#update-a-pull-request">http://developer.github.com/v3/pulls/#update-a-pull-request</seealso>
    /// </remarks>
    public static Task<PullRequest> GitHubPullRequestUpdate(this IGitHubEndpointContext context, int number, string title, string? comment = null, bool isOpen = true, string? branch = null)
            => context.GitHubClient().PullRequest.Update(context.Owner, context.RepoName, number, new PullRequestUpdate { Title = title, Base = branch, State = isOpen ? ItemState.Open : ItemState.Closed, Body = comment });

    /// <summary>
    /// Merge a pull request.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="title">The Title for the automatic commit message (optional)</param>
    /// <param name="message">The message that will be used for the merge commit (optional)</param>
    /// <returns><see cref="PullRequestMerge"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#merge-a-pull-request-merge-buttontrade">http://developer.github.com/v3/pulls/#merge-a-pull-request-merge-buttontrade"></seealso>
    /// </remarks>
    public static Task<PullRequestMerge> GitHubPullRequestMerge(this IGitHubEndpointContext context, int number, string? title = null, string? message = null)
        => context.GitHubClient().PullRequest.Merge(context.Owner, context.RepoName, number, new MergePullRequest { MergeMethod = PullRequestMergeMethod.Squash, CommitTitle = title, CommitMessage = message });

    /// <summary>
    /// Enable the default auto-merge on a pull request
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="mergeMethod">The merge method to use.</param>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    /// GraphQL API: <seealso href="https://docs.github.com/en/graphql/reference/mutations#enablepullrequestautomerge">https://docs.github.com/en/graphql/reference/mutations#enablepullrequestautomerge</seealso>
    /// </remarks>
    public static async Task<PullRequest> GitHubPullRequestAutoMerge(this IGitHubEndpointContext context, int number, PullRequestMergeMethod mergeMethod = PullRequestMergeMethod.Squash)
    {
        var pr = await GitHubPullRequest(context, number) ?? throw new ArgumentException($"Pull request {number} not found");

        await context.HttpPostAsync(GraphQL.ApiUrl, settings =>
        {
            settings.UseBearerAuthorization(context.GitHubToken)
                    .SetRequestBody($"mutation PullRequestAutoMerge {{ enablePullRequestAutoMerge(input: {{pullRequestId: \"{pr.NodeId}\", mergeMethod: {mergeMethod.ToString().ToUpperInvariant()}}}) {{ clientMutationId }}}}")
                    .SetContentType("application/json");
        });

        return pr;
    }

    //=> context.GitHubClient().PullRequest.Merge(context.Owner, context.RepoName, number, new MergePullRequest { MergeMethod = PullRequestMergeMethod.Squash, CommitTitle = title, CommitMessage = message });

    /// <summary>
    /// Get the pull request merge status.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <returns><see cref="Boolean"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/pulls/#get-if-a-pull-request-has-been-merged">http://developer.github.com/v3/pulls/#get-if-a-pull-request-has-been-merged</seealso>
    /// </remarks>
    public static Task<bool> GitHubPullRequestMergeStatus(this IGitHubEndpointContext context, int number) => context.GitHubClient().PullRequest.Merged(context.Owner, context.RepoName, number);

    /// <summary>
    /// Locks an issue for the specified repository. Issue owners and users with push access can lock an issue or pull request's conversation.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The Pull request number.</param>
    /// <param name="lockReason">The reason for locking the issue</param>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/issues/#lock-an-issue">https://developer.github.com/v3/issues/#lock-an-issue</seealso>
    /// </remarks>
    public static Task GitHubPullRequestLock(this IGitHubEndpointContext context, int number, LockReason? lockReason = null)
        => context.GitHubClient().PullRequest.LockUnlock.Lock(context.Owner, context.RepoName, number, lockReason);

    /// <summary>
    /// Unlocks an issue for the specified repository. Issue owners and users with push access can unlock an issue or pull request's conversation.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The Pull request number.</param>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/issues/#unlock-an-issue">https://developer.github.com/v3/issues/#unlock-an-issue</seealso>
    /// </remarks>
    public static Task GitHubPullRequestUnlock(this IGitHubEndpointContext context, int number)
        => context.GitHubClient().PullRequest.LockUnlock.Unlock(context.Owner, context.RepoName, number);


    /// <summary>
    /// Gets a single pull request review by ID.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="reviewId">The pull request review number</param>
    /// <returns><see cref="PullRequestReview"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/reviews/#get-a-single-review/">https://developer.github.com/v3/pulls/reviews/#get-a-single-review</seealso>
    /// </remarks>
    public static Task<PullRequestReview> GitHubPullRequestReview(this IGitHubEndpointContext context, int number, long reviewId)
        => context.GitHubClient().PullRequest.Review.Get(context.Owner, context.RepoName, number, reviewId);

    /// <summary>
    ///  Gets reviews for a specified pull request.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <returns><see cref="IReadOnlyList{PullRequestReview}"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/reviews/#list-reviews-on-a-pull-request">https://developer.github.com/v3/pulls/reviews/#list-reviews-on-a-pull-request</seealso>
    /// </remarks>
    public static Task<IReadOnlyList<PullRequestReview>> GitHubPullRequestReviewAll(this IGitHubEndpointContext context, int number)
        => context.GitHubClient().PullRequest.Review.GetAll(context.Owner, context.RepoName, number);

    /// <summary>
    /// Lists comments for a single review
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="reviewId">The pull request review number</param>
    /// <returns><see cref="IReadOnlyList{PullRequestReviewComment}"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/reviews/#get-comments-for-a-single-review">https://developer.github.com/v3/pulls/reviews/#get-comments-for-a-single-review</seealso>
    /// </remarks>
    public static Task<IReadOnlyList<PullRequestReviewComment>> GitHubPullRequestReviewCommentsAll(this IGitHubEndpointContext context, int number, long reviewId)
        => context.GitHubClient().PullRequest.Review.GetAllComments(context.Owner, context.RepoName, number, reviewId);

    /// <summary>
    /// Creates a pull request review.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="message">he body of the review message</param>
    /// <returns><see cref="PullRequestReview"/></returns>
    /// <remarks>
    ///  API: <seealso href=""></seealso>
    /// </remarks>
    public static Task<PullRequestReview> GitHubPullRequestReviewCreate(this IGitHubEndpointContext context, int number, string? message = null)
        => context.GitHubClient().PullRequest.Review.Create(context.Owner, context.RepoName, number, new PullRequestReviewCreate { Body = message });

    /// <summary>
    /// Deletes a pull request review.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="reviewId">The pull request review number</param>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/reviews/#delete-a-pending-review">https://developer.github.com/v3/pulls/reviews/#delete-a-pending-review</seealso>
    /// </remarks>
    public static Task GitHubPullRequestReviewDelete(this IGitHubEndpointContext context, int number, long reviewId)
        => context.GitHubClient().PullRequest.Review.Delete(context.Owner, context.RepoName, number, reviewId);

    /// <summary>
    /// Submits a pull request review.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="reviewId">The pull request review number</param>
    /// <param name="review">The review event - Approve, Request Changes, Comment</param>
    /// <param name="message">he body of the review message</param>
    /// <returns><see cref="PullRequestReview"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/reviews/#submit-a-pull-request-review">https://developer.github.com/v3/pulls/reviews/#submit-a-pull-request-review</seealso>
    /// </remarks>
    public static Task<PullRequestReview> GitHubPullRequestReviewSubmit(this IGitHubEndpointContext context, int number, long reviewId, PullRequestReviewEvent review, string? message = null)
        => context.GitHubClient().PullRequest.Review.Submit(context.Owner, context.RepoName, number, reviewId, new PullRequestReviewSubmit { Body = message, Event = review });

    /// <summary>
    /// Dismisses a pull request review.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">The pull request number.</param>
    /// <param name="reviewId">The pull request review number</param>
    /// <param name="message">The message indicating why the review was dismissed</param>
    /// <returns><see cref="PullRequestReview"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/reviews/#dismiss-a-pull-request-review">https://developer.github.com/v3/pulls/reviews/#dismiss-a-pull-request-review</seealso>
    /// </remarks>
    public static Task<PullRequestReview> GitHubPullRequestReviewDismiss(this IGitHubEndpointContext context, int number, long reviewId, string? message = null)
        => context.GitHubClient().PullRequest.Review.Dismiss(context.Owner, context.RepoName, number, reviewId, new PullRequestReviewDismiss { Message = message });

    /// <summary>
    /// Gets review requests for a specified pull request.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">Pull request number</param>
    /// <returns><see cref="PullRequestReviewComment"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/review_requests/#list-review-requests">https://developer.github.com/v3/pulls/review_requests/#list-review-requests</seealso>
    /// </remarks>
    public static Task<RequestedReviews> GitHubPullRequestReviewRequest(this IGitHubEndpointContext context, int number)
            => context.GitHubClient().PullRequest.ReviewRequest.Get(context.Owner, context.RepoName, number);

    /// <summary>
    /// Creates review requests on a pull request for specified users.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">Pull request number</param>
    /// <param name="reviewers">Pull request number</param>
    /// <param name="teamReviewers">List of teams will be requested for review</param>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/review_requests/#create-a-review-request">https://developer.github.com/v3/pulls/review_requests/#create-a-review-request</seealso>
    /// </remarks>
    public static Task<PullRequest> GitHubPullRequestReviewRequestCreate(this IGitHubEndpointContext context, int number, IReadOnlyList<string>? reviewers = null, IReadOnlyList<string>? teamReviewers = null)
    {
        if ((reviewers == null || reviewers.Count < 1) && (teamReviewers == null || teamReviewers.Count < 1))
            throw new ArgumentException("At least one reviewer or team reviewer is required");

        return context.GitHubClient().PullRequest.ReviewRequest.Create(context.Owner, context.RepoName, number, new PullRequestReviewRequest(reviewers, teamReviewers));
    }

    /// <summary>
    /// Creates review requests on a pull request for specified users.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="number">Pull request number</param>
    /// <param name="reviewers">List of logins of users that will be not longer requested for review</param>
    /// <param name="teamReviewers">List of teams that will be not longer requested for review</param>>
    /// <returns><see cref="PullRequest"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/pulls/review_requests/#delete-a-review-request">https://developer.github.com/v3/pulls/review_requests/#delete-a-review-request</seealso>
    /// </remarks>
    public static Task GitHubPullRequestReviewRequestDelete(this IGitHubEndpointContext context, int number, IReadOnlyList<string>? reviewers = null, IReadOnlyList<string>? teamReviewers = null)
    {
        if ((reviewers == null || reviewers.Count < 1) && (teamReviewers == null || teamReviewers.Count < 1))
            throw new ArgumentException("At least one reviewer or team reviewer is required");

        return context.GitHubClient().PullRequest.ReviewRequest.Delete(context.Owner, context.RepoName, number, new PullRequestReviewRequest(reviewers, teamReviewers));
    }
}

