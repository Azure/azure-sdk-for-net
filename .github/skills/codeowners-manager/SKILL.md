---
name: codeowners-manager
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: "Manage Azure SDK CODEOWNERS owners, labels, protected sections, and cache. **UTILITY SKILL**. WHEN: \"code owners\", \"tell me about codeowners\", \"who owns\", \"owners for path\", \"codeowners for /sdk/\", \"protected CODEOWNERS section\", \"Client Libraries section\", \"package owner\", \"package label\", \"label owner\", \"service label\", \"codeowners blocked PR\". DO NOT USE FOR: unprotected CODEOWNERS edits, non-Azure SDK repositories. INVOKES: azsdk_engsys_codeowner_*, azsdk_check_service_label, azsdk_create_service_label."
compatibility:
  requires: "azure-sdk-mcp server preferred; azsdk CLI fallback"
---

# CODEOWNERS Manager

## Prerequisites

Use `azure-sdk-mcp`; fall back to `azsdk` if unavailable.
Never edit CODEOWNERS directly; use MCP or `azsdk`.

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azsdk_engsys_codeowner_view` | Query associations. |
| `azsdk_engsys_codeowner_add_*`, `azsdk_engsys_codeowner_remove_*` | Update owners and labels. |
| `azsdk_check_service_label`, `azsdk_create_service_label`, `azsdk_engsys_codeowner_check_package`, `azsdk_engsys_codeowner_update_cache` | Create labels, validate readiness, propagate changes. |

## Use

Applies to both **read** (lookup/query) and **write** (add/remove) operations. Use this skill whenever the user asks who owns a path, what labels apply, or anything about CODEOWNERS entries — not only when making changes.

Protected sections like Client Libraries route here. Infer `repo` from `Azure/azure-sdk-for-*`; otherwise, ask.

1. Start with `azsdk_engsys_codeowner_view` to inspect state.
2. Use `azsdk_engsys_codeowner_add_*` or `azsdk_engsys_codeowner_remove_*` for owners and labels. See [owners and labels](references/owners-and-labels.md).
3. For path cleanup or blocked section edits, use the remove ops in [operations](references/operations-reference.md).
4. For a new label, check it, create it if needed, then associate it after the PR merges.
5. After all CODEOWNERS changes are complete, offer to run `azsdk_engsys_codeowner_update_cache` to propagate changes. **Note:** Cache updates take approximately 2-3 minutes to complete, so encourage batching all changes before triggering an update.
6. Use `azsdk_engsys_codeowner_check_package` for blocked PRs or releases to validate owner/label readiness.

See [troubleshooting](references/troubleshooting.md) for blocked PRs, missing labels, and release-readiness issues.

## Cache Updates

After making CODEOWNERS changes (adding/removing owners or labels), the cache must be updated to propagate changes across dependent systems. However, cache updates take about **20 minutes** to complete.

**Best practice:** Batch all related changes together, then offer to run the cache update once at the end. Example prompt:

> "All changes are complete. Ready to update the CODEOWNERS cache to propagate these changes? (This takes about 2–3 minutes.) Should I proceed?"

Only offer `azsdk_engsys_codeowner_update_cache` when:
- All requested CODEOWNERS changes have been applied
- The user is ready to wait for the update to complete
- Or the user explicitly asks to update the cache
