# Test Resource Deployment

## Script Location

`eng/common/TestResources/New-TestResources.ps1`

## Common Parameters

| Parameter | Required | Description |
|-----------|----------|-------------|
| `ServiceDirectory` | Yes | Service directory name under `sdk/` (e.g., `keyvault`, `storage`) |
| `-OutFile` | Yes | Required for a .env file to be output. |
| `-BaseName` | No | Base name for resource group (default: auto-generated) |
| `-Location` | No | Azure region for deployment (default: script default) |
| `-SubscriptionId` | No | Target subscription (uses current Az context if omitted) |
| `-ResourceGroupName` | No | Custom resource group name |

## Usage Examples

### Basic deployment (interactive, uses current Az context)

```powershell
Connect-AzAccount -Subscription 'SUBSCRIPTION_ID'
eng/common/TestResources/New-TestResources.ps1 keyvault -OutFile
```

### Deployment with custom parameters

```powershell
Connect-AzAccount -Subscription 'SUBSCRIPTION_ID'
eng/common/TestResources/New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'SUBSCRIPTION_ID' `
    -ResourceGroupName 'rg-mytest' `
    -Location 'eastus'
    -OutFile
```

## Output

The script outputs environment variables needed for live and record test runs. If `$SupportsTestResourcesDotenv=$true` in the language repo's `LanguageSettings.ps1`, a `.env` file is written next to the `test-resources.bicep` file.

Environment variables typically include credentials and resource endpoints needed by test frameworks.

## Additional Parameters

Some services require extra parameters (e.g., `-AdditionalParameters @{enableHsm=$true}` for Key Vault HSM tests). Check the service's `test-resources.bicep` or `test-resources.json` for required parameters.
