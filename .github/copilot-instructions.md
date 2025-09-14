<!-- Copilot / AI agent instructions for the Cake.GitHub.Endpoints repository -->
# Guidance for AI coding agents

This repo is a Cake addin that provides Cake aliases wrapping GitHub REST/GraphQL operations using Octokit (the C# GitHub client). Keep changes small, idiomatic C#, and aligned with existing Cake alias patterns.

- **Big picture**: aliases live under `src/Cake.GitHub.Endpoints/` and are implemented as static extension classes exposing `IGitHubEndpointContext` methods. Authentication uses a PAT from `IGitHubEndpointContext.GitHubToken` and `GitHubClient()` in `GitHubEndpointExtensions.cs`.
- **Key files**:
  - `src/Cake.GitHub.Endpoints/*.cs` — alias implementations (examples: `GitHubEndpointsRepositoryAliases.cs`, `GitHubEndpointsPullRequestAliases.cs`).
  - `IGitHubEndpointContext.cs` — contract for `Owner`, `RepoName`, and `GitHubToken` used across aliases.
  - `GitHubEndpointExtensions.cs` — creates `IGitHubClient` instances. Use this helper to call Octokit APIs.
  - `Constants.cs` — central default values (user-agent, GraphQL API url, default branch/message for uploads).
  - `build.cake` and `.github/workflows/build.yml` — build, pack and publish flow using Cake script and GitHub Actions.

- **Patterns & conventions**:
  - Aliases are `public static` methods on static classes and take `IGitHubEndpointContext` as the first parameter.
  - Use `context.GitHubClient()` (or the `ICakeContext` overload) to get an authenticated `IGitHubClient` before calling Octokit methods.
  - Async APIs return `Task` or `Task<T>` directly (no `async/await` wrapper unless needed for additional logic).
  - Use `Constants.Options.DefaultApiOptions` when calling list endpoints that accept `ApiOptions`.
  - Follow existing naming: methods start with `GitHub` e.g., `GitHubRepository`, `GitHubRepositoryCreate`.
  - Keep XML documentation comments for public aliases and include the REST URL as done in other files.

- **Build / test / debug workflows**:
  - Local build via Cake script (requires .NET SDK 9.x):
    ```pwsh
    dotnet tool restore
    dotnet cake --target=Default
    ```
  - You can also run the Cake script with specific targets: `Clean`, `Restore`, `Build`, `Pack`, `Push` (see `build.cake`).
  - CI: `/.github/workflows/build.yml` runs the Cake script on `ubuntu-latest` with .NET 9.

- **Dependencies & integration points**:
  - Uses Octokit (via project references in the csproj) to call GitHub REST/GraphQL APIs — prefer using Octokit methods where possible instead of hand-crafting HTTP requests.
  - GraphQL mutation templates live in `Constants.GraphQL` (e.g., `enablePullRequestAutoMerge`); prefer using these constants when invoking the GraphQL endpoint.

- **What to change and how to test small updates**:
  - When adding a new alias, add a new static method in an appropriately named file, follow the `CakeAliasCategory` and `CakeNamespaceImport` attributes as other files do.
  - Keep methods minimal and call the corresponding `IGitHubClient` API. For example, to list repository tags reuse `context.GitHubClient().Repository.GetAllTags(context.Owner, context.RepoName)` pattern.
  - Build locally with `dotnet cake` (see above). Packaging and pushing is handled by `Pack` and `Push` targets in `build.cake`.

- **Project-specific pitfalls to avoid**:
  - Do not change the public API surface (method names/signatures) unless necessary — this is a published NuGet addin.
  - Avoid adding synchronous blocking calls; the project uses `Task` return types to integrate with Cake's async support.
  - Do not hardcode secrets: authentication always flows through `IGitHubEndpointContext.GitHubToken` or GitHub Actions secrets in CI (see `.github/workflows/build.yml`).

- **Examples** (copy/paste friendly):
  - Create a client: `var client = context.GitHubClient();`
  - Get repository: `return context.GitHubClient().Repository.Get(context.Owner, context.RepoName);`

If anything in this file looks incomplete or you want me to include more examples (e.g., common ApiOptions usage or how paging is handled), tell me which areas to expand.
