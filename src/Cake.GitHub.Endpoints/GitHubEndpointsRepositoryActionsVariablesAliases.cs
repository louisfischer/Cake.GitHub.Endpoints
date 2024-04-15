namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repository Actions Repository Variables API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryActionsVariablesAliases
{
    /// <summary>
    /// List the variables for a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/actions/variables?apiVersion=2022-11-28#list-repository-variables">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    public static Task<RepositoryVariablesCollection> GitHubRepositoryActionsVariablesGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Actions.Variables.GetAll(context.Owner, context.RepoName);

    /// <summary>
    /// Get a variable from a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/actions/variables?apiVersion=2022-11-28#get-a-repository-variable">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the variable</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="RepositoryVariable"/> instance for the repository secret.</returns>
    public static Task<RepositoryVariable> GitHubRepositoryActionsVariablesGet(this IGitHubEndpointContext context, string name) =>
        context.GitHubClient().Repository.Actions.Variables.Get(context.Owner, context.RepoName, name);

    /// <summary>
    /// List the organization variables for a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/actions/variables?apiVersion=2022-11-28#list-repository-organization-variables">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="RepositoryVariablesCollection"/> instance for the list of repository variables.</returns>
    public static Task<RepositoryVariablesCollection> GitHubRepositoryActionsVariablesGetAllOrganization(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Actions.Variables.GetAllOrganization(context.Owner, context.RepoName);

    /// <summary>
    /// Create a variable in a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/actions/variables?apiVersion=2022-11-28#create-a-repository-variable">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the variable to create</param>
    /// <param name="value">The value of the variable to create</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="RepositoryVariable"/> instance for the repository variable that was created.</returns>
    public static Task<RepositoryVariable> GitHubRepositoryActionsVariablesCreate(this IGitHubEndpointContext context, string name, string value) =>
        context.GitHubClient().Repository.Actions.Variables.Create(context.Owner, context.RepoName, new Variable(name, value));

    /// <summary>
    /// Update a variable in a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/actions/variables?apiVersion=2022-11-28#update-a-repository-variable">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the variable to create</param>
    /// <param name="value">The value of the variable to create</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<RepositoryVariable> GitHubRepositoryActionsVariablesUpdate(this IGitHubEndpointContext context, string name, string value) =>
        context.GitHubClient().Repository.Actions.Variables.Update(context.Owner, context.RepoName, new Variable(name, value));

    /// <summary>
    /// Delete a variable in a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/en/rest/actions/variables?apiVersion=2022-11-28#delete-a-repository-variable">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the variable</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task GitHubRepositoryActionsVariablesDelete(this IGitHubEndpointContext context, string name) =>
        context.GitHubClient().Repository.Actions.Variables.Delete(context.Owner, context.RepoName, name);
}
