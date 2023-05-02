namespace Cake.GitHub.Endpoints;

/// <summary>
/// Contains functionality for working with GitHub Users API
/// </summary>
[CakeAliasCategory("GitHub")]
[CakeNamespaceImport("Cake.GitHub.Endpoints")]
public static class GitHubEndpointsUserAliases
{
    /// <summary>
    /// Returns the user specified by the login.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="login">The login name for the user</param>
    /// <returns><see cref="User"/></returns>
    public static Task<User> GitHubUser(this IGitHubEndpointContext context, string login) => context.GitHubClient().User.Get(login);

    /// <summary>
    ///  Update the specified <see cref="UserUpdate"/>.
    /// </summary>
    /// <param name="context">The GitHubEndpointContext</param>
    /// <param name="user">The login for the user</param>
    /// <returns>A <see cref="User"/></returns>
    public static Task<User> GitHubUserUpdate(this IGitHubEndpointContext context, UserUpdate user) => context.GitHubClient().User.Update(user);
}
