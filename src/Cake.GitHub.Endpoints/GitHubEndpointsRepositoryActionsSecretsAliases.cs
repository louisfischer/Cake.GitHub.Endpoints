namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repository Actions Repository Secrets API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryActionsSecretsAliases
{
    /// <summary>
    /// List the secrets for a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/actions/secrets/#list-repository-secrets">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="RepositorySecretsCollection"/> instance for the list of repository secrets.</returns>
    public static Task<RepositorySecretsCollection> GitHubRepositoryActionsSecretsGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Actions.Secrets.GetAll(context.Owner, context.RepoName);

    /// <summary>
    /// Get a secret from a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/actions/secrets/#get-a-repository-secret">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the secret</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="RepositorySecret"/> instance for the repository secret.</returns>
    public static Task<RepositorySecret> GitHubRepositoryActionsSecretsGet(this IGitHubEndpointContext context, string name) =>
        context.GitHubClient().Repository.Actions.Secrets.Get(context.Owner, context.RepoName, name);

    /// <summary>
    /// Create or update a secret in a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/actions/secrets/#create-or-update-a-repository-secret">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the variable to create or update</param>
    /// <param name="keyId">The id of the encryption key used to encrypt the secret.</param>
    /// <remarks>Get key and id from <see cref="RepositorySecretsClient.GetPublicKey(string, string)"/> and use the <a href="https://developer.github.com/v3/actions/secrets/#create-or-update-a-repository-secret">API documentation</a> for more information on how to encrypt the secret</remarks>
    /// <param name="encryptedValue">The encrypted value and id of the encryption key</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <returns>A <see cref="RepositorySecret"/> instance for the repository secret that was created or updated.</returns>
    public static Task<RepositorySecret> GitHubRepositoryActionsSecretsCreate(this IGitHubEndpointContext context, string name, string keyId, string encryptedValue) =>
        context.GitHubClient().Repository.Actions.Secrets.CreateOrUpdate(context.Owner, context.RepoName, name, new UpsertRepositorySecret { EncryptedValue = encryptedValue, KeyId = keyId });

    /// <summary>
    /// Delete a secret in a repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/actions/secrets/#delete-a-repository-secret">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="name">The name of the secret</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task GitHubRepositoryActionsSecretsDelete(this IGitHubEndpointContext context, string name) =>
        context.GitHubClient().Repository.Actions.Secrets.Delete(context.Owner, context.RepoName, name);
}
