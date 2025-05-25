namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for creating Bearer token for authentication as a GitHub App.
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsAuthenticationAliases
{
    /// <summary>
    /// Generates an installation Token for a GitHub App that can be used to make API calls as an App
    /// </summary>
    /// <param name="context">The GithubContext</param>
    /// <param name="clientId">The client ID of the GitHub App</param>
    /// <param name="installationId">Installation Id associated with the app.</param>
    /// <param name="privateKeyBase64">Private Key generated in github org in Base64 format.  The private key is the SINGLE most valuable secret for a GitHub App. We recommend storing the key in a key vault, such as Azure Key Vault or HashiCorp</param>
    /// <returns><see cref="AccessToken"/></returns>
    /// <remarks><seealso href="https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/managing-private-keys-for-github-apps">Managing private keys for GitHub Apps</seealso></remarks>
    public static async Task<AccessToken> GitHubAppInstallationToken(this ICakeContext context, int clientId, long installationId, string privateKeyBase64)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (string.IsNullOrWhiteSpace(privateKeyBase64)) throw new ArgumentNullException(nameof(privateKeyBase64));

        GitHubEndpointsAddinInformation.LogVersionInformation(context.Log);

        using var rsa = RSA.Create();

        rsa.ImportFromPem(Encoding.UTF8.GetString(Convert.FromBase64String(privateKeyBase64)));

        var header = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { alg = "RS256", typ = "JWT" }))).Base64Sanitize();
        var payload = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { iat = DateTimeOffset.UtcNow.AddSeconds(-60).ToUnixTimeSeconds(), exp = DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds(), iss = clientId }))).Base64Sanitize();
        var signature = Convert.ToBase64String(rsa.SignData(Encoding.UTF8.GetBytes($"{header}.{payload}"), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)).Base64Sanitize();

        var jwt = $"{header}.{payload}.{signature}";

        // Pass the JWT as a Bearer token to Octokit.net
        return await context.GitHubClient(jwt).GitHubApps.CreateInstallationToken(installationId);
    }
}
