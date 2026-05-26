---
name: azsdk-common-apiview-feedback-resolution
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
description: "Analyze and resolve APIView review feedback on Azure SDK PRs. **UTILITY SKILL**. USE FOR: APIView comments, API review feedback, SDK API surface changes. DO NOT USE FOR: general code review, non-APIView feedback. INVOKES: azure-sdk-mcp:azsdk_apiview_get_comments, azure-sdk-mcp:azsdk_customized_code_update."
compatibility:
  requires: "azure-sdk-mcp server, SDK pull request with APIView review link"
---

# APIView Feedback Resolution

**Prerequisites:** azure-sdk-mcp server required; no CLI fallback. Without MCP, this skill cannot retrieve APIView comments or apply TypeSpec changes. Connect the `azure-sdk-mcp` server before use.

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_apiview_get_comments` | Get APIView comments |
| `azure-sdk-mcp:azsdk_customized_code_update` | Apply TypeSpec & code customization changes locally |
| `azure-sdk-mcp:azsdk_typespec_delegate_apiview_feedback` | Delegate to CCA pipeline |
| `azure-sdk-mcp:azsdk_run_typespec_validation` | Validate TypeSpec |
| `azure-sdk-mcp:azsdk_package_generate_code` | Regenerate SDK |

## Steps

1. **Retrieve** — Get APIView URL from SDK PR, run `azsdk_apiview_get_comments`.
2. **Categorize** — Group as Critical/Suggestions/Informational per [feedback steps](references/feedback-resolution-steps.md).
3. **Resolve** — Use `azsdk_customized_code_update` for TypeSpec changes; delegate via `azsdk_typespec_delegate_apiview_feedback` for complex cases.
4. **Validate** — Run validation, regenerate SDK, build and test.
5. **Confirm** — Verify all items addressed. If delegated, follow [post-delegation follow-up](references/feedback-resolution-steps.md#post-delegation-follow-up). Request re-review.

## Examples

- "Resolve the APIView comments on my SDK pull request"
- "What feedback did the API reviewer leave?"

## Troubleshooting

- **No comments**: Verify PR has APIView link and MCP server is connected.
- **Validation fails**: Re-run after fixing TypeSpec errors.
- **MCP unavailable**: Requires `azure-sdk-mcp` server; no CLI fallback. Connect the server and retry.
