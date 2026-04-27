---
name: owners
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: "Query and modify CODEOWNERS ownership, service labels, and package associations in Azure SDK repositories. **UTILITY SKILL**. FOR SINGLE OPERATIONS: view, add, or remove owners and labels. WHEN: \"code owners\", \"view codeowners\", \"add package owner\", \"remove package owner\", \"add label\", \"remove label\", \"codeowners blocked PR\", \"who owns this package\", \"create service label\", \"update codeowners cache\", \"unblock release\". INVOKES: azsdk_engsys_codeowner_view, azsdk_engsys_codeowner_add_package_owner, azsdk_engsys_codeowner_add_label_owner, azsdk_check_service_label, azsdk_create_service_label, azsdk_engsys_codeowner_update_cache, azsdk_engsys_codeowner_check_package."
compatibility:
  requires: "azure-sdk-mcp server"
---

# Owners

**Requires:** azure-sdk-mcp server

## Tools

| Tool | Purpose |
|------|---------|
| `azsdk_engsys_codeowner_view` | Query by user, label, package, path |
| `azsdk_engsys_codeowner_add_*` | Add owners/labels ([details](references/operations-reference.md)) |
| `azsdk_engsys_codeowner_remove_*` | Remove owners/labels |
| `azsdk_check_service_label` | Check if service label exists |
| `azsdk_create_service_label` | Create service label |
| `azsdk_engsys_codeowner_check_package` | Check if a package has sufficient owners, labels, and service owners |
| `azsdk_engsys_codeowner_update_cache` | Run the CODEOWNERS cache update pipeline to propagate changes |

**CLI fallback:** `azsdk config codeowners` CLI when MCP is unavailable.

## Repository Resolution

Infer `repo` from workspace in `Azure/azure-sdk-for-*` repos. Otherwise, ask.

## Workflow

1. **Query** — `azsdk_engsys_codeowner_view` to inspect current state.
2. **Modify** — Add/remove [owners or labels](references/owners-and-labels.md).
3. **Verify** — Re-query to confirm.
4. **Update cache** — After all ownership changes are complete, ask the user if they want to run `azsdk_engsys_codeowner_update_cache` to propagate changes immediately. This is especially important when changes are needed to unblock PRs or releases.

New labels: `azsdk_check_service_label` → `azsdk_create_service_label` → PR merged → `azsdk_engsys_codeowner_add_package_label`. See [data model](references/operations-reference.md).

### Checking Package Readiness

Use `azsdk_engsys_codeowner_check_package` with a package `directoryPath` to verify a package has sufficient owners, PR labels, and service owners. This is useful to diagnose why a PR or release is blocked due to missing ownership.

## Examples

- "Add @user to azure-core in azure-sdk-for-python"
- "Who owns azure-storage-blob?"

## Troubleshooting

See [troubleshooting](references/troubleshooting.md) for common issues.