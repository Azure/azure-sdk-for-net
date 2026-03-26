# Troubleshooting Owners and Labels

## My PR to change CODEOWNERS is blocked

Edits to protected sections of the CODEOWNERS file are prohibited. If you want to make changes to a protected section, use MCP tooling described in the [operations reference](operations-reference.md) to make the necessary changes to the data model. If you are unsure which tool to use, start with `azsdk_engsys_codeowner_view` to query the current state and identify which entries need to be modified, then use the appropriate add/remove operations.

## I cannot associate my service label with a package

1. Use `azsdk_check_service_label` to confirm that the label exists.
2. If the label does not exist, ask the user if they want to create the label using `azsdk_create_service_label`. That operation will open a PR to Azure/azure-sdk-tools and that PR must be merged before the label can be associated with packages.
