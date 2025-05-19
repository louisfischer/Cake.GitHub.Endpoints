namespace Cake.GitHub.Endpoints;

/// <summary>
/// Extension methods for <see cref="IGitHubEndpointContext"/>.
/// </summary>
public static class GitHubEndpointExtensions
{
    /// <summary>
    ///A Client for the GitHub API v3. You can read more about the API here: http://developer.github.com.
    /// </summary>
    /// <returns><see cref="IGitHubClient"/></returns>
    public static IGitHubClient GitHubClient(this IGitHubEndpointContext context) => new GitHubClient(new ProductHeaderValue(Constants.HttpHeaders.Values.UserAgent)) { Credentials = new Credentials(context.GitHubToken) };

    /// <summary>
    ///A Client for the GitHub API v3. You can read more about the API here: http://developer.github.com.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="jwt">Json Web Token</param>
    /// <returns><see cref="IGitHubClient"/></returns>
    public static IGitHubClient GitHubClient(this ICakeContext context, string jwt) => new GitHubClient(new ProductHeaderValue(Constants.HttpHeaders.Values.UserAgent)) { Credentials = new Credentials(jwt, AuthenticationType.Bearer) };
}
