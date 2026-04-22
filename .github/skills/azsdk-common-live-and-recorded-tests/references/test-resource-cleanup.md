# Test Resource Cleanup

## Script Location

`eng/common/TestResources/Remove-TestResources.ps1`

## Common Parameters

| Parameter | Required | Description |
|-----------|----------|-------------|
| `ServiceDirectory` | Yes* | Service directory name (e.g., `keyvault`). Required if `ResourceGroupName` not provided. |
| `-ResourceGroupName` | No | Explicit resource group name to delete |
| `-Force` | No | Skip confirmation prompt |

*Either `ServiceDirectory` or `-ResourceGroupName` must be provided. If the test resources were deployed to the TME tenant, you must use the resource group name, which should include the `SSS3PT_` prefix as output by the test resource creation script.

## Usage Examples

### Basic cleanup

```powershell
eng/common/TestResources/Remove-TestResources.ps1 keyvault -Force
```

### Cleanup by resource group name

```powershell
eng/common/TestResources/Remove-TestResources.ps1 `
    -ResourceGroupName 'rg-mytest' `
    -Force
```

## Notes

- The script also purges purgeable resources (e.g., Key Vault soft-deleted vaults).
- Any `.env` files created by `New-TestResources.ps1` are also removed.
- Always ask the user before cleaning up — they may want to reuse resources for additional test runs.
