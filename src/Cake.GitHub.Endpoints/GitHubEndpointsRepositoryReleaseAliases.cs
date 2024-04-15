namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repository Releases API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubRepositoryReleaseAliases
{
    /// <summary>
    /// Gets all <see cref="Release"/>s for the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#list-releases-for-a-repository">API documentation</a> for more information.
    /// </remarks>
    public static Task<IReadOnlyList<Release>> GitHubRepositoryReleaseGetAll(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Release.GetAll(context.Owner, context.RepoName, Options.DefaultApiOptions);

    /// <summary>
    /// Gets a single <see cref="Release"/> for the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/releases/#get-a-release-by-tag-name">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="tag">The tag of the release</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<Release> GitHubRepositoryReleaseGet(this IGitHubEndpointContext context, string tag) =>
        context.GitHubClient().Repository.Release.Get(context.Owner, context.RepoName, tag);

    /// <summary>
    /// Gets the latest <see cref="Release"/> for the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/releases/#get-the-latest-release">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<Release> GitHubRepositoryReleaseGetLatest(this IGitHubEndpointContext context) =>
        context.GitHubClient().Repository.Release.GetLatest(context.Owner, context.RepoName);

    /// <summary>
    /// Creates a new <see cref="Release"/> for the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#create-a-release">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="data">A description of the release to create</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<Release> GitHubRepositoryReleaseCreate(this IGitHubEndpointContext context, NewRelease data) =>
        context.GitHubClient().Repository.Release.Create(context.Owner, context.RepoName, data);

    /// <summary>
    /// Edits an existing <see cref="Release"/> for the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#edit-a-release">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="id">The id of the release</param>
    /// <param name="data">A description of the release to edit</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<Release> GitHubRepositoryReleaseEdit(this IGitHubEndpointContext context, int id, ReleaseUpdate data) =>
        context.GitHubClient().Repository.Release.Edit(context.Owner, context.RepoName, id, data);

    /// <summary>
    /// Deletes an existing <see cref="Release"/> for the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#delete-a-release">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="id">The id of the release to delete</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task GitHubRepositoryReleaseDelete(this IGitHubEndpointContext context, int id) =>
        context.GitHubClient().Repository.Release.Delete(context.Owner, context.RepoName, id);

    /// <summary>
    /// Gets the specified <see cref="ReleaseAsset"/> for the specified release of the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#get-a-single-release-asset">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="assetId">The id of the <see cref="ReleaseAsset"/></param>
    public static Task<ReleaseAsset> GitHubRepositoryReleaseGetAsset(this IGitHubEndpointContext context, int assetId) =>
        context.GitHubClient().Repository.Release.GetAsset(context.Owner, context.RepoName, assetId);

    /// <summary>
    /// Gets all <see cref="ReleaseAsset"/> for the specified release of the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#list-assets-for-a-release">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="assetId">The id of the <see cref="Release"/>.</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<IReadOnlyList<ReleaseAsset>> GitHubRepositoryReleaseGetAssetsAll(this IGitHubEndpointContext context, int assetId) =>
        context.GitHubClient().Repository.Release.GetAllAssets(context.Owner, context.RepoName, assetId);

    /// <summary>
    /// Edits the <see cref="ReleaseAsset"/> for the specified release of the specified repository.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#edit-a-release-asset">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="assetId">The id of the <see cref="ReleaseAsset"/></param>
    /// <param name="data">Description of the asset with its amended data</param>
    public static Task<ReleaseAsset> GitHubRepositoryReleaseEditAsset(this IGitHubEndpointContext context, int assetId, ReleaseAssetUpdate data) =>
        context.GitHubClient().Repository.Release.EditAsset(context.Owner, context.RepoName, assetId, data);

    /// <summary>
    /// Deletes the specified <see cref="ReleaseAsset"/> from the specified repository
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#delete-a-release-asset">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="assetId">The id of the <see cref="ReleaseAsset"/>.</param>
    public static Task GitHubRepositoryReleaseDeleteAsset(this IGitHubEndpointContext context, int assetId) =>
        context.GitHubClient().Repository.Release.DeleteAsset(context.Owner, context.RepoName, assetId);

    /// <summary>
    /// Uploads a <see cref="ReleaseAsset"/> for the specified release.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/releases/#upload-a-release-asset">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="tag">The tag of the release to upload the asset to</param>
    /// <param name="data">Description of the asset with its data</param>
    /// <param name="cancellationToken">An optional token to monitor for cancellation requests</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    /// <exception cref="CakeException">Thrown when a release with the tag is not found</exception>
    public static async Task<ReleaseAsset> GitHubRepositoryReleaseUploadAsset(this IGitHubEndpointContext context, string tag, ReleaseAssetUpload data, CancellationToken cancellationToken = default)
    {
        var release = await context.GitHubClient().Repository.Release.Get(context.Owner, context.RepoName, tag);
        if (release is null)
            throw new CakeException($"Release with tag '{tag}' not found.");

        return await context.GitHubClient().Repository.Release.UploadAsset(release, data, cancellationToken);
    }

    /// <summary>
    /// Generates a <see cref="GeneratedReleaseNotes"/>s for the specified repository with auto generated notes.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://docs.github.com/rest/releases/releases#generate-release-notes-content-for-a-release">API documentation</a> for more information.
    /// </remarks>
    /// <param name="context">The GitHubEndpointContext context</param>
    /// <param name="data">The request for generating release notes</param>
    /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
    public static Task<GeneratedReleaseNotes> GitHubRepositoryReleaseDeleteAsset(this IGitHubEndpointContext context, GenerateReleaseNotesRequest data) =>
        context.GitHubClient().Repository.Release.GenerateReleaseNotes(context.Owner, context.RepoName, data);
}
