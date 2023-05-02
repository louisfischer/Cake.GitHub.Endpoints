namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Repositories Contents API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsRepositoryContentAliases
{
    /// <summary>
    /// Returns the raw content of the file at the given <paramref name="path"/> or <c>null</c> if the path is a directory.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="path">The content path</param>
    /// <param name="reference">The name of the commit/branch/tag.</param>
    /// <returns></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/repos/contents/#get-contents">https://developer.github.com/v3/repos/contents/#get-contents</seealso>
    /// </remarks>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<byte[]> GitHubRepositoryContent(this IGitHubEndpointContext context, string path, string? reference = null)
    {
        if(context == null) throw new ArgumentNullException(nameof(context));
        if(string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

        var contents = !string.IsNullOrWhiteSpace(reference) ?
                                await context.GitHubClient().Repository.Content.GetRawContentByRef(context.Owner, context.RepoName, path, reference)
                                : await context.GitHubClient().Repository.Content.GetRawContent(context.Owner, context.RepoName, path);

        return contents!;
    }

    /// <summary>
    /// Returns the raw content of the file at the given <paramref name="path"/> or <c>null</c> if the path is a directory.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="path">The content path</param>
    /// <param name="reference">The name of the commit/branch/tag.</param>
    /// <returns></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/repos/contents/#get-contents">https://developer.github.com/v3/repos/contents/#get-contents</seealso>
    /// </remarks>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<string> GitHubRepositoryContentAsString(this IGitHubEndpointContext context, string path, string? reference = null)
    {
        var contents = await GitHubRepositoryContent(context, path, reference);
        return contents.Length > 0 ? Encoding.UTF8.GetString(contents, 0, contents.Length) : string.Empty;
    }

    /// <summary>
    /// Creates a commit that CREATES a new file in a repository.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="path">The path to the file in GitHub Repository (NOT File Path)</param>
    /// <param name="content"> The contents of the file to create.</param>
    /// <param name="message">The commit message. If null, defaults to the name of the file.</param>
    /// <param name="branch">The branch name. If null, this defaults to the default branch which is usually "main".</param>
    /// <param name="convertToBase64">">True to convert content to base64</param>
    /// <returns><see cref="RepositoryContentChangeSet"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/repos/contents/#create-or-update-file-contents">https://developer.github.com/v3/repos/contents/#create-or-update-file-contents</seealso>
    /// </remarks>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<RepositoryContentChangeSet> GitHubRepositoryContentCreate(this IGitHubEndpointContext context, string path, string content, string? message = null, string? branch = null, bool convertToBase64 = true)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));

        var request = new CreateFileRequest
        (
            content: content,
            message: !string.IsNullOrWhiteSpace(message) ? message : string.Format(Repos.Contents.Defaults.Message, PathUtilities.GetFileName(path)),
            branch: !string.IsNullOrWhiteSpace(branch) ? branch : Repos.Contents.Defaults.Branch,
            convertContentToBase64: convertToBase64
        );

        return context.GitHubClient().Repository.Content.CreateFile(context.Owner, context.RepoName, path, request);
    }

    /// <summary>
    ///  Creates a commit that UPDATES the contents of a file in a repository.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="path">The path to the file in GitHub Repository (NOT File Path)</param>
    /// <param name="content"> The contents of the file to create.</param>
    /// <param name="sha">The blob SHA of the file being replaced.</param>
    /// <param name="message">The commit message. If null, defaults to the name of the file.</param>
    /// <param name="branch">The branch name. If null, this defaults to the default branch which is usually "main".</param>
    /// <param name="convertToBase64">">True to convert content to base64</param>
    /// <returns><see cref="RepositoryContentChangeSet"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/repos/contents/#create-or-update-file-contents">https://developer.github.com/v3/repos/contents/#create-or-update-file-contents</seealso>
    /// </remarks>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task<RepositoryContentChangeSet> GitHubRepositoryContentUpdate(this IGitHubEndpointContext context, string path, string content, string sha, string? message = null, string? branch = null, bool convertToBase64 = true)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
        if (string.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));

        var request = new UpdateFileRequest
        (
            content: content,
            sha: sha,
            message: !string.IsNullOrWhiteSpace(message) ? message : string.Format(Repos.Contents.Defaults.Message, PathUtilities.GetFileName(path)),
            branch: !string.IsNullOrWhiteSpace(branch) ? branch : Repos.Contents.Defaults.Branch,
            convertContentToBase64: convertToBase64
        );

        return context.GitHubClient().Repository.Content.UpdateFile(context.Owner, context.RepoName, path, request);
    }

    /// <summary>
    ///   Creates a commit that DELETES a file in a repository.
    /// </summary>
    /// <param name="context">The GitHubBuildContext</param>
    /// <param name="path">The path to the file in GitHub Repository (NOT File Path)</param>
    /// <param name="sha">The blob SHA of the file being replaced.</param>
    /// <param name="message">The commit message. If null, defaults to the name of the file.</param>
    /// <param name="branch">The branch name. If null, this defaults to the default branch which is usually "main".</param>
    /// <returns><see cref="RepositoryContentChangeSet"/></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/repos/contents/#create-or-update-file-contents">https://developer.github.com/v3/repos/contents/#create-or-update-file-contents</seealso>
    /// </remarks>
    /// <exception cref="ArgumentNullException"></exception>
    public static Task GitHubRepositoryContentDelete(this IGitHubEndpointContext context, string path, string sha, string? message = null, string? branch = null)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (string.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));

        var request = new DeleteFileRequest
        (
            sha: sha,
            message: !string.IsNullOrWhiteSpace(message) ? message : string.Format(Repos.Contents.Defaults.Message, PathUtilities.GetFileName(path)),
            branch: !string.IsNullOrWhiteSpace(branch) ? branch : Repos.Contents.Defaults.Branch
        );

        return context.GitHubClient().Repository.Content.DeleteFile(context.Owner, context.RepoName, path, request);
    }

    /// <summary>
    /// Get an archive of a given repository's contents
    /// </summary>
    /// <param name="context"></param>>
    /// <param name="format">he format of the archive. Can be either tarball or zipball</param>
    /// <returns></returns>
    /// <remarks>
    ///  API: <seealso href="https://developer.github.com/v3/repos/contents/#get-archive-link">https://developer.github.com/v3/repos/contents/#get-archive-link</seealso>
    /// </remarks>
    public static Task<byte[]> GitHubRepositoryContentArchive(this IGitHubEndpointContext context, ArchiveFormat format) => context.GitHubClient().Repository.Content.GetArchive(context.Owner, context.RepoName, format);

    /// <summary>
    /// Gets the preferred README for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <returns><see cref="Readme"/></returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/contents/#get-the-readme">http://developer.github.com/v3/repos/contents/#get-the-readme</seealso>
    /// </remarks>
    public static Task<Readme> GitHubRepositoryContentReadMe(this IGitHubEndpointContext context) => context.GitHubClient().Repository.Content.GetReadme(context.Owner, context.RepoName);

    /// <summary>
    /// Gets the preferred README for the specified repository.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <returns>Readme as html string</returns>
    /// <remarks>
    ///  API: <seealso href="http://developer.github.com/v3/repos/contents/#get-the-readme">http://developer.github.com/v3/repos/contents/#get-the-readme</seealso>
    /// </remarks>
    public static Task<string> GitHubRepositoryContentReadMeAsHtml(this IGitHubEndpointContext context) => context.GitHubClient().Repository.Content.GetReadmeHtml(context.Owner, context.RepoName);

}
