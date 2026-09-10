# APIView Feedback Resolution Details

## Feedback Categories

- **Critical**: Breaking changes, security issues - must resolve
- **Suggestions**: Naming improvements, documentation - should resolve
- **Informational**: Style notes - optional

## Resolution Approaches

**If TypeSpec change needed:**

1. Run `azsdk_typespec_delegate_apiview_feedback` to create a GH issue with all actionable comments in the specs repo and assign to Copilot.

**If code-only fix needed:**

1. Apply the fix directly in the SDK repository
2. Regenerate SDK if needed

## Post-Resolution Steps

1. Run `azsdk_run_typespec_validation` to verify TypeSpec changes
2. Run `azsdk_package_generate_code` to regenerate SDK
3. Build and test the updated SDK
4. Update the SDK PR with changes
5. Re-check APIView for any new comments
6. Inform user to request re-review if needed

## Post-Delegation Follow-Up

When `azsdk_typespec_delegate_apiview_feedback` is used to delegate changes, follow these steps to close the loop with the user:

1. **Share the issue link** — Immediately share the created GitHub issue URL with the user so they can track progress.
2. **Explain the pipeline chain** — Let the user know the expected flow: GitHub issue → spec PR (created by Copilot) → SDK generation pipeline → SDK PRs → updated APIView revision.
3. **Monitor pipeline status** — Offer to check pipeline progress using `azure-sdk-mcp:azsdk_get_pipeline_status`.
4. **Track SDK PRs** — Once the spec PR is created, use `azure-sdk-mcp:azsdk_get_sdk_pull_request_link` to find the resulting SDK pull requests.
5. **Present the full link chain** — When available, share the complete chain with the user: issue → spec PR → SDK PRs → APIView revision link.
