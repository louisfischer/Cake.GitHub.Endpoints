namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for creating Bearer token for authentication as an Ap
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsAuthenticationAliases
{
    /// <summary>
    /// Generates an installation Token for a GitHub App that can be used to make API calls as an App
    /// </summary>
    /// <param name="context">The GithubContext</param>
    /// <param name="appId">Unique application is for a GitHub App</param>
    /// <param name="installationId">Installation Id associated with the app.</param>
    /// <param name="privateKey">Private Key generated in github org.  The private key is the SINGLE most valuable secret for a GitHub App. We recommend storing the key in a key vault, such as Azure Key Vault or HashiCorp</param>
    /// <returns><see cref="AccessToken"/></returns>
    /// <remarks><seealso href="https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/managing-private-keys-for-github-apps">Managing private keys for GitHub Apps</seealso></remarks>
    public static async Task<AccessToken> GitHubAppInstallationToken(this ICakeContext context, int appId, long installationId, string privateKey)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(privateKey)) throw new ArgumentNullException(nameof(privateKey));

        GitHubEndpointsAddinInformation.LogVersionInformation(context.Log);

        using var rsa = RSA.Create();

        rsa.ImportFromPem(privateKey.ToCharArray());

        var jwt = JwtBuilder.Create()
                            .WithAlgorithm(new RS256Algorithm(rsa, rsa))
                            .IssuedAt(DateTimeOffset.UtcNow.AddSeconds(-60).ToUnixTimeSeconds())
                            .ExpirationTime(DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
                            .Issuer(appId.ToString())
                            .Encode();

        // Pass the JWT as a Bearer token to Octokit.net
        return await context.GitHubClient(jwt).GitHubApps.CreateInstallationToken(installationId);
    }
}
