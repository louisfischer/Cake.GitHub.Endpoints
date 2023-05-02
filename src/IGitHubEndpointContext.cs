namespace Cake.GitHub.Endpoints;

/// <summary>
/// GitHub Endpoint Context
/// </summary>
public interface IGitHubEndpointContext: ICakeContext
{
    /// <summary>
    /// Owner of the GitHub repository
    /// </summary>
    string Owner { get; }

    /// <summary>
    /// Name of the Repository
    /// </summary>
    string RepoName { get; }

    /// <summary>
    /// The GitHub Access PAT
    /// </summary>
    string GitHubToken { get; }
}
