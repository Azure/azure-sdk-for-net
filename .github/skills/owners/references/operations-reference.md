# Operations Reference

## Data Model

The CODEOWNERS tools manage a data model in Azure DevOps that is rendered into the repository CODEOWNERS file. You do not edit CODEOWNERS directly — use the MCP tools or CLI to update the data model.

| Type | Purpose | Used During |
|------|---------|-------------|
| **Service Label** | Identifies the Azure service (e.g., `Storage`, `Key Vault`). Links packages and paths to a service for issue routing. | Issue triage |
| **Service Owner** | GitHub user(s) representing the service partner team. Mentioned when "Service Attention" label is added. | Issue triage |
| **PR Label** | Label(s) automatically applied to PRs based on changed file paths. | PR review |
| **Azure SDK Owner** | SDK team member(s) with triage responsibility for a service label. | Issue triage |

A **package** has a **PR Label** (applied to PRs touching its files) and **source owners** (PR reviewers). A **Service Label** groups packages under a service and has **Service Owners** contacted for escalations. A package's PR Label should be the Service Label for the package's service.

### Resolve the Repo

Tools that add owners or labels use a `repo` argument. If the current context is not an Azure SDK repository, ask the user for the target repository. Valid values for `repo` are:

- `Azure/azure-sdk-for-net`
- `Azure/azure-sdk-for-java`
- `Azure/azure-sdk-for-js`
- `Azure/azure-sdk-for-python`
- `Azure/azure-sdk-for-go`
- `Azure/azure-sdk-for-cpp`
- `Azure/azure-sdk-for-rust`

## View

Query CODEOWNERS associations. Provide at least one parameter.

| Parameter | Description | Example |
|-----------|-------------|---------|
| `github_user` | GitHub alias | `myuser` |
| `label` | Label name(s) | `Storage` |
| `package` | Package name | `azure-storage-blob` |
| `path` | Repository path | `sdk/storage/` |
| `repo` | Repository (owner/repo) | `Azure/azure-sdk-for-python` |

**MCP:** `azsdk_engsys_codeowner_view`
**CLI:** `azsdk config codeowners view --github-user myuser --repo Azure/azure-sdk-for-python`

## Add Operations

### Add Package Owner

**MCP:** `azsdk_engsys_codeowner_add_package_owner` (`github_user`, `package`, `repo`)
**CLI:** `azsdk config codeowners add-package-owner --github-user user1 --package azure-core --repo Azure/azure-sdk-for-python`

### Add Package Label

**MCP:** `azsdk_engsys_codeowner_add_package_label` (`label`, `package`, `repo`)
**CLI:** `azsdk config codeowners add-package-label --label Storage --package azure-storage-blob --repo Azure/azure-sdk-for-python`

### Add Label Owner

**MCP:** `azsdk_engsys_codeowner_add_label_owner` (`github_user`, `label`, `path` optional, `owner_type`: AzSdkOwner|PrLabel|ServiceOwner, `repo`)
**CLI:** `azsdk config codeowners add-label-owner --github-user user1 --label Storage --owner-type ServiceOwner --repo Azure/azure-sdk-for-python`

## Remove Operations

Same parameters as add counterparts.

### Remove Package Owner

**MCP:** `azsdk_engsys_codeowner_remove_package_owner` (`github_user`, `package`, `repo`)
**CLI:** `azsdk config codeowners remove-package-owner --github-user user1 --package azure-core --repo Azure/azure-sdk-for-python`

### Remove Package Label

**MCP:** `azsdk_engsys_codeowner_remove_package_label` (`label`, `package`, `repo`)
**CLI:** `azsdk config codeowners remove-package-label --label Storage --package azure-storage-blob --repo Azure/azure-sdk-for-python`

### Remove Label Owner

**MCP:** `azsdk_engsys_codeowner_remove_label_owner` (`github_user`, `label`, `owner_type`: AzSdkOwner|PrLabel|ServiceOwner, `repo`)
**CLI:** `azsdk config codeowners remove-label-owner --github-user user1 --label Storage --owner-type ServiceOwner --repo Azure/azure-sdk-for-python`

## Check Package

Verify that a package has sufficient owners, PR labels, and service owners. Useful for diagnosing why a PR or release is blocked.

| Parameter | Description | Example |
|-----------|-------------|---------|
| `directoryPath` | Path to the package directory (required) | `sdk/storage/azure-storage-blob` |
| `repo` | Repository (owner/repo) | `Azure/azure-sdk-for-python` |
| `codeownersCachePath` | Path to a local cache file (optional) | |

**MCP:** `azsdk_engsys_codeowner_check_package`

## Update Cache

Run the CODEOWNERS cache update pipeline to propagate ownership changes. Use this after making add/remove changes to ensure PRs, releases, and other pipelines pick up the new ownership data. Takes no parameters.

**MCP:** `azsdk_engsys_codeowner_update_cache`

## CLI Fallback

When MCP is unavailable, all operations can be performed via the `azsdk` CLI. The base command is:

```shell
azsdk config codeowners <operation> [options]
```

Common flags across all commands:

- `--repo <owner/repo>` — Target repository (e.g. `Azure/azure-sdk-for-python`)
- `--github-user <user>` — GitHub username (leave off `@` prefix)
- `--label <label>` — Label name (leave off `%` prefix)
- `--package <name>` — Package name
- `--owner-type <type>` — One of `AzSdkOwner`, `PrLabel`, `ServiceOwner`
