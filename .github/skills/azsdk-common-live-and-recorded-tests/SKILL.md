---
name: azsdk-common-live-and-recorded-tests
license: MIT
metadata:
  version: "0.1.0"
  distribution: shared
description: "Deploy test resources and run Azure SDK tests in live, record, or playback mode. WHEN: \"run live tests\", \"run recorded tests\", \"deploy test resources\", \"record tests\", \"run tests in record mode\", \"clean up test resources\", \"run tests against live resources\". DO NOT USE FOR: writing new tests, authoring Bicep templates, playback-only test runs without resource deployment. INVOKES: azure-sdk-mcp:azsdk_package_run_tests."
compatibility:
  requires: "azure-sdk-mcp server, Azure PowerShell (Az module), local azure-sdk-for-{language} clone"
---

# Live and Recorded Tests

## MCP Tools

| Tool | Purpose |
|------|---------|
| `azure-sdk-mcp:azsdk_package_run_tests` | Run tests in playback, record, or live mode |

> **IMPORTANT:** ALWAYS use the `azure-sdk-mcp:azsdk_package_run_tests` MCP tool to run tests. NEVER run test commands directly in the terminal (e.g., `pytest`, `dotnet test`, `mvn test`, `npm test`, `go test`). The MCP tool handles test mode configuration, environment setup, and automatic asset pushing in record mode.

## Prerequisites

- azure-sdk-mcp server must be running
- Azure PowerShell module (`Az`) installed
- For live/record modes: an Azure subscription with permissions to create resources
  - Use the Azure SDK Test Resources - TME (id: 4d042dc6-fe17-4698-a23f-ec6a8d1e98f4) subscription if not already authenticated and no other subscription is specified.

## Steps

1. **Identify service directory** — Determine the service directory for the package under test (e.g., `keyvault`, `storage`). This is required by the test resource deployment script.
2. **Check for existing deployment** — Look for a `.env` file at either the service directory level  (next to `test-resources.bicep`, e.g. `sdk/storage/.env`) or at the package level (e.g. `sdk/storage/storage-blob/.env`). If one exists, inform the user that a previous deployment appears to be available and ask whether to **reuse the existing deployment** or **redeploy test resources**. If reusing, skip to step 7.
3. **Verify Azure context** — Run `Get-AzContext` to check for an active Azure PowerShell session. If no context exists, guide the user through `Connect-AzAccount -TenantId [TME tenant ID]`. Confirm the correct subscription is selected.
4. **Confirm deployment** — Even if no existing `.env` file is found, confirm with the user before proceeding to deploy test resources. Deployment creates Azure resources that may incur costs.
5. **Deploy test resources** — Run `eng/common/TestResources/New-TestResources.ps1` with the service directory, tenant ID, subscription ID, and any user-provided parameters. Use the TME tenant ID and subscription ID if one has not already been provided. See [deployment parameters](references/test-resource-deployment.md) for details. The script outputs environment variables needed for live/record test runs.
6. **Save environment** — Capture the environment variables output by the deployment script. If the script writes a `.env` file, note its path. Otherwise, collect the environment variables from the script output. In azure-sdk-for-net, if the script outputs a file like `test-resources.bicep.env` instead of a `.env` file, move on to step 7 and call the MCP tool WITHOUT passing an env filepath. The test framework will automatically find and handle this special file type.
7. **Run tests** — Call the `azure-sdk-mcp:azsdk_package_run_tests` MCP tool (do NOT run test commands directly in the terminal). Provide the appropriate test mode (`record`, `live`, or `playback`) and the path to the `.env` file containing test environment variables. When tests run in record mode and all tests pass, the tool automatically pushes recorded test assets to the assets repo.
8. **Clean up** — Ask the user whether to clean up test resources. If yes, run `eng/common/TestResources/Remove-TestResources.ps1`. If no, inform the user that resources remain deployed for subsequent test runs. See [cleanup details](references/test-resource-cleanup.md).

## Examples

- "Deploy test resources and run live tests for this package"
- "Run the tests in record mode using the live test deployment specified in .env"
- "Clean up my test resources for keyvault"
- "Run tests in record mode against my existing deployment"
- "Set up live test resources for storage and run all tests"

## Troubleshooting

- **No Azure context:** Run `Connect-AzAccount` and select the target subscription with `Set-AzContext -SubscriptionId <id>`.
- **Deployment fails with auth error:** Verify that the signed-in account has Contributor or Owner role on the target subscription. Check `Get-AzContext` output.
- **Deployment fails with resource conflict:** A previous deployment may still exist. Try running `Remove-TestResources.ps1` first, or use a different `BaseName`.
- **Tests fail in record mode:** Check that all environment variables from the deployment are being passed correctly. Verify the `.env` file path is correct.
- **Assets push fails after recording:** Ensure the assets repo is configured and accessible. Check git authentication.
