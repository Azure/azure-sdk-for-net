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
    -Location 'eastus' `
    -OutFile
```

## Output

The script outputs environment variables needed for live and record test runs. If `$SupportsTestResourcesDotenv=$true` in the language repo's `LanguageSettings.ps1`, a `.env` file is written next to the `test-resources.bicep` file.

Environment variables typically include credentials and resource endpoints needed by test frameworks.

## Additional Parameters

Some services require extra parameters (e.g., `-AdditionalParameters @{enableHsm=$true}` for Key Vault HSM tests). Check the service's `test-resources.bicep` or `test-resources.json` for required parameters.

## Troubleshooting

### Resource already exists / deployment conflict

If deployment fails because a resource or resource group already exists:

1. Check whether an existing deployment is present by running:
   ```powershell
   Get-AzResourceGroup -Name '<resource-group-name>' -ErrorAction SilentlyContinue
   ```
2. Ask the user whether they want to **remove the existing deployment** and redeploy, or **deploy with a different resource group name**.
3. If removing, run `Remove-TestResources.ps1` first (see [cleanup details](test-resource-cleanup.md)), then retry the deployment.
4. If the conflict is on a specific resource (e.g., a Key Vault in soft-deleted state), purge it manually:
   ```powershell
   Remove-AzKeyVault -VaultName '<vault-name>' -InRemovedState -Force -Location '<location>'
   ```

### Authentication or authorization failure

- Verify the signed-in account has **Contributor** or **Owner** role on the target subscription: `Get-AzContext`.
- If no context exists, run `Connect-AzAccount` and select the correct subscription with `Set-AzContext -SubscriptionId <id>`.
- For the TME subscription, ensure the account has been granted access to subscription `4d042dc6-fe17-4698-a23f-ec6a8d1e98f4`.

### Deployment times out

- Some services (e.g., Cosmos DB, HDInsight) have long provisioning times.
- Check the Azure portal for the resource group's deployment status to identify which resource is slow.

### Missing .env file after deployment

- Ensure `-OutFile` was passed to `New-TestResources.ps1`.
- Verify the language repo's `eng/scripts/LanguageSettings.ps1` sets `$SupportsTestResourcesDotenv = $true`. If it does not, environment variables must be collected from the script's console output instead.
