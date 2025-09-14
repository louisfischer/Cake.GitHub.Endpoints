# Cake.GitHub.Endpoints
This plugin is a set of convience Cake aliases for [GitHub API Endpoints](https://docs.github.com/en/rest). Uses the [OckoKit C# client](https://github.com/octokit/octokit.net) to make http calls.

## Using Cake Projects

### Cake Script
- **GitHub App Installation Token (recommended for automation)**: Create a GitHub App, generate a JWT signed with the App private key, exchange the JWT for an installation access token and set it on `IGitHubEndpointContext.GitHubToken`. Installation tokens are short-lived and should be refreshed as needed by automation scripts.
<!-- Examples for generating installation tokens are available under the
 	 `GitHubAppInstallationToken` entry in the Aliases Catalog below. -->

Aliases catalog

# Aliases Catalog

This document lists the Cake aliases provided by this addin. Each entry includes the alias method name, a one-line purpose (from the XML <summary>), parameters, return type, REST URL (when present in remarks), and an example showing how to call the alias from a Cake script using an `IGitHubEndpointContext`.

Note: All examples assume a context instance with `Owner`, `RepoName`, and `GitHubToken` set from an environment variable.

---

## Authentication

- `GitHubAppInstallationToken` (ICakeContext)
	- Purpose: Generates an installation Token for a GitHub App for API calls.
	- Parameters: `clientId` (int), `installationId` (long), `privateKeyBase64` (string)
	- Return type: `Task<AccessToken>`
	- Remarks: See GitHub Apps docs for private keys. Source: `src/Cake.GitHub.Endpoints/GitHubEndpointsAuthenticationAliases.cs`
	- Example:
		```csharp
		// One-liner: get the installation token
		var token = (await CakeContext.GitHubAppInstallationToken(appId, installationId, privateKeyBase64)).Token;
		```

	Example — prepare Base64 private key (convert your PEM to Base64):

	```csharp
	// Convert your GitHub App private key PEM file into a Base64 string outside of Cake
	// and provide it to your build as an environment variable.
	var privateKeyBase64 = EnvironmentVariable("GITHUB_APP_PRIVATEKEY_BASE64");
	```

	Example — Cake Frosting task (C#):

	```csharp
	public sealed class GenerateTokenTask : FrostingTask<ICakeContext>
	{
		public override async Task Run(ICakeContext context)
		{
			int appId = 12345;
			long installationId = 67890L;

			// privateKeyBase64 is the Base64-encoded PEM contents
			var access = await context.GitHubAppInstallationToken(appId, installationId, privateKeyBase64);

			// Use token for subsequent calls (example: set on IGitHubEndpointContext)
			var ghContext = new GitHubEndpointContext
			{
				Owner = "my-org",
				RepoName = "my-repo",
				GitHubToken = access.Token
			};

			// Example call using the token
			var runs = await ghContext.GitHubActionsWorkflowRunsList();
		}
	}
	```

	Example — set a process-scoped environment variable from Cake (optional):

	```csharp
	var access = await context.GitHubAppInstallationToken(appId, installationId, privateKeyBase64);
	Environment.SetEnvironmentVariable("GITHUB_INSTALL_TOKEN", access.Token);
	// Note: this sets the variable for the current process only.
	```

## Repository

- `GitHubRepository`
	- Purpose: Gets the specified repository.
	- Parameters: `this IGitHubEndpointContext context`
	- Return type: `Task<Repository>`
	- API: http://developer.github.com/v3/repos/#get-a-repository
	- Source: `GitHubEndpointsRepositoryAliases.cs`
	- Example (expanded):
		```csharp
		// Get repository metadata
		var repo = await context.GitHubRepository();
		context.Information("Repository: {0} ({1})", repo.FullName, repo.DefaultBranch);
		```

- `GitHubRepositoryCreate`
	- Purpose: Creates a new repository in an organization or for current user.
	- Parameters: `NewRepository newRepository`, `string? organization = null`
	- Return type: `Task<Repository>`
	- API: http://developer.github.com/v3/repos/#create-an-organization-repository
	- Example (expanded):
		```csharp
		// Create a new repository (user or organization)
		var newRepo = new NewRepository("my-repo")
		{
			Private = false,
			Description = "My repository created from Cake",
			AutoInit = true
		};

		var created = await context.GitHubRepositoryCreate(newRepo, organization: "my-org");
		context.Information("Created repo: {0}", created.FullName);
		```

- `GitHubRepositoryDelete`
	- Purpose: Deletes the specified repository.
	- Parameters: `this IGitHubEndpointContext context`
	- Return type: `Task`
	- API: http://developer.github.com/v3/repos/#delete-a-repository
	- Example (expanded):
		```csharp
		// Delete the configured repository (use with care)
		await context.GitHubRepositoryDelete();
		context.Information("Repository deleted");
		```

- `GitHubRepositoryTags`
	- Purpose: Gets all tags for the specified repository.
	- Return type: `Task<IReadOnlyList<RepositoryTag>>`
	- Example (expanded):
		```csharp
		var tags = await context.GitHubRepositoryTags();
		foreach (var t in tags) context.Information("{0} -> {1}", t.Name, t.Commit.Sha);
		```

- `GitHubRepositoryTeams`
	- Purpose: Gets all teams for the specified repository.
	- Return type: `Task<IReadOnlyList<Team>>`
	- Example (expanded):
		```csharp
		var teams = await context.GitHubRepositoryTeams();
		foreach (var team in teams) context.Information("{0}", team.Name);
		```

- `GitHubRepositoryVulnerabilityAlertsEnabled`
	- Purpose: Checks if vulnerability alerts are enabled.
	- Return type: `Task<bool>`
	- Example:
		```csharp
		var alertsEnabled = await context.GitHubRepositoryVulnerabilityAlertsEnabled();
		context.Information("Vulnerability alerts enabled: {0}", alertsEnabled);
		```

## Repository Content

- `GitHubRepositoryContent`
	- Purpose: Returns raw content of a file as bytes.
	- Parameters: `string path`, `string? reference = null`
	- Return type: `Task<byte[]>`
	- API: https://developer.github.com/v3/repos/contents/#get-contents
	- Example (expanded):
		```csharp
		var bytes = await context.GitHubRepositoryContent("path/to/file.txt");
		await using var ms = new MemoryStream(bytes);
		// Use ms or write to disk
		```

- `GitHubRepositoryContentAsString`
	- Purpose: Returns raw content as string.
	- Return type: `Task<string>`

- `GitHubRepositoryContentCreate`
	- Purpose: Creates a new file commit.
	- Parameters: `string path, string content, string? message = null, string? branch = null, bool convertToBase64 = true`
	- Return type: `Task<RepositoryContentChangeSet>`

- `GitHubRepositoryContentUpdate`
	- Purpose: Updates file contents.
	- Parameters: `string path, string content, string sha, ...`

- `GitHubRepositoryContentDelete`
	- Purpose: Deletes a file.
	- Parameters: `string path, string sha, ...`

- `GitHubRepositoryContentArchive`
	- Purpose: Gets archive (tarball/zipball) bytes.
	- Parameters: `ArchiveFormat format`

- `GitHubRepositoryContentReadMe`
	- Purpose: Gets preferred README as `Readme`.

- `GitHubRepositoryContentReadMeAsHtml`
	- Purpose: Gets README as HTML string.



If you want a machine-readable catalog or a dedicated `docs/ALIASES.md` I can create that as a follow-up. The per-alias examples above contain expanded, copy-paste-ready snippets for common operations.

