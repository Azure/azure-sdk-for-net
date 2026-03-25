# Troubleshooting Owners and Labels

## My PR to change CODEOWNERS is blocked

Edits to protected sections of the CODEOWNERS file are prohibited. If you want to make changes to a protected section, use MCP tooling described in the [operations reference](operations-reference.md) to make the necessary changes to the data model. If you are unsure which tool to use, start with `azsdk_engsys_codeowner_view` to query the current state and identify which entries need to be modified, then use the appropriate add/remove operations.

## I cannot associate my service label with a package

- Ensure that the service label PR has been merged in the azure-sdk-tools repo. The label must exist before it can be associated with packages and paths.
- Use `azsdk_check_service_label` to confirm that the label exists.

## The repository I want to modify is not being inferred

If the tool cannot infer the target repository from the current workspace, ask the user for the repo in the format `Azure/azure-sdk-for-net` and try the tool call with that parameter for the repo
