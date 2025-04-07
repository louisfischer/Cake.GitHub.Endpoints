namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub's Repository Custom Property Values API.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryCustomPropertyAliases
{
    /// <summary>
    /// Get all custom property values for a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/rest/repos/custom-properties#get-all-custom-property-values-for-a-repository">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="CustomPropertyValue"/> instance for the list of repository secrets.</returns>
    public static Task<IReadOnlyList<CustomPropertyValue>> GitHubRepositoryCustomPropertyGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.CustomProperty.GetAll(context.Owner, context.RepoName);

    /// <summary>
    /// Create or update a secret in a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/rest/repos/custom-properties#create-or-update-custom-property-values-for-a-repository">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="propertyValues">The custom property values to create or update</param>
    /// <remarks></remarks>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task GitHubRepositoryCustomPropertySave(this IGitHubEndpointContext context, IDictionary<string, IReadOnlyList<string>> propertyValues) =>
        context.GitHubClient().Repository.CustomProperty.CreateOrUpdate(context.Owner, context.RepoName, new UpsertRepositoryCustomPropertyValues
        {
            Properties = propertyValues.Select(c => new CustomPropertyValueUpdate(c.Key, c.Value)).ToList()
        });
}
