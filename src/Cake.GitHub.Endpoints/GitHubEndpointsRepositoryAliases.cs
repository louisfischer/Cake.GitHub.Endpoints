namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repositories API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointswRepositoryAliases
{
    /// <summary>
    /// Gets the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <returns><see cref="Repository"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/#get-a-repository">http://developer.github.com/v3/repos/#get-a-repository</seealso>
    /// </remarks>
    public static Task<Repository> GitHubRepository(this IGitHubEndpointContext context) => context.GitHubClient().Repository.Get(context.Owner, context.RepoName);

    /// <summary>
    /// Creates a new repository in the specified organization or current user if <paramref name="organization">organization</paramref> .
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="newRepository">A <see cref="NewRepository"/> instance describing the new repository to create</param>
    /// <param name="organization">Login of the organization in which to create the repository</param>
    /// <returns><see cref="Repository"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/#create-an-organization-repository">http://developer.github.com/v3/repos/#create-an-organization-repository</seealso>
    /// </remarks>
    public static Task<Repository> GitHubRepositoryCreate(this IGitHubEndpointContext context, NewRepository newRepository, string? organization = null) =>
        !string.IsNullOrWhiteSpace(organization) ? context.GitHubClient().Repository.Create(organization, newRepository) : context.GitHubClient().Repository.Create(newRepository);

    /// <summary>
    /// Updates the specified repository with the values given in <paramref name="update"/>
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="update">New values to update the repository with</param>
    /// <returns><see cref="Repository"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/#update-a-repository">http://developer.github.com/v3/repos/#update-a-repository</seealso>
    /// </remarks>
    public static Task<Repository> GitHubRepositoryUpdate(this IGitHubEndpointContext context, RepositoryUpdate update) => context.GitHubClient().Repository.Edit(context.Owner, context.Owner, update);

    /// <summary>
    /// Deletes the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/#delete-a-repository">API documentation</a> for more information.
    /// Deleting a repository requires admin access. If OAuth is used, the `delete_repo` scope is required.
    /// </remarks>
    public static Task GitHubRepositoryDelete(this IGitHubEndpointContext context) => context.GitHubClient().Repository.Delete(context.Owner, context.Owner);

    /// <summary>
    /// Gets all tags for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <returns><see cref="IReadOnlyList{RepositoryTag}"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/#list-tags">http://developer.github.com/v3/repos/#list-tags</seealso>
    /// </remarks>
    public static Task<IReadOnlyList<RepositoryTag>> GitHubRepositoryTags(this IGitHubEndpointContext context) => context.GitHubClient().Repository.GetAllTags(context.Owner, context.RepoName);

    /// <summary>
    /// Gets all teams for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <returns><see cref="IReadOnlyList{Team}"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/#list-teams">http://developer.github.com/v3/repos/#list-teams</seealso>
    /// </remarks>
    public static Task<IReadOnlyList<Team>> GitHubRepositoryTeams(this IGitHubEndpointContext context) => context.GitHubClient().Repository.GetAllTeams(context.Owner, context.RepoName);

    /// <summary>
    /// Checks if vulnerability alerts are enabled for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <returns><see cref="bool"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://docs.github.com/rest/reference/repos#check-if-vulnerability-alerts-are-enabled-for-a-repository">https://docs.github.com/rest/reference/repos#check-if-vulnerability-alerts-are-enabled-for-a-repository</seealso>
    /// </remarks>
    public static Task<bool> GitHubRepositoryVulnerabilityAlertsEnabled(this IGitHubEndpointContext context) => context.GitHubClient().Repository.AreVulnerabilityAlertsEnabled(context.Owner, context.RepoName);
}
