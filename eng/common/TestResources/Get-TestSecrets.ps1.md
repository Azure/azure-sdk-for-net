---
external help file: -help.xml
Module Name:
online version:
schema: 2.0.0
---

# Get-TestSecrets.ps1

## SYNOPSIS
Gets configuration secrets from Key Vault.

## SYNTAX

```
Get-TestSecrets.ps1 [-VaultName] <String> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Gets configuration secrets from Key Vault and returns them as an object you can pass to \`New-TestResources.ps\` similar to what live test pipelines would do.
If the secret contains JSON-formatted data, it is parsed and returned as an object containing multiple properties.
If the secret does not contain JSON-formatted data, the passed-in name is returned as a custom property with the secret value as its value.

## EXAMPLES

### EXAMPLE 1
```
$secretValue = @{
    SubscriptionId=$env:AZURE_SUBSCRIPTION_ID
    TestApplicationId=$env:AZURE_CLIENT_ID
    TestApplicationSecret=$env:AZURE_CLIENT_SECRET
    } `
    | ConvertTo-Json -Compress `
    | ConvertTo-SecureString -AsPlainText -Force
Set-AzKeyVaultSecret `
    -VaultName myvault `
    -Name mysecret `
    -SecretValue $secretValue
Get-TestSecrets.ps1 myvault mysecret `
    | New-TestResources.ps1 -ServiceDirectory myservice
```

Gets the contents of "mysecret" from "myvault" and passed them through to New-TestResources.ps1.

## PARAMETERS

### -VaultName
The name of the Key Vault containing secrets.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the secret.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject
## NOTES

## RELATED LINKS
