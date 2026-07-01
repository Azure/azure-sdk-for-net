# Schema Validation Notes

The generated BotService provisioning resources were compared with the Azure Bicep reference for `2023-09-15-preview`.

## Known mismatch

### `Microsoft.BotService/botServices/networkSecurityPerimeterConfigurations`

Bicep reference: <https://learn.microsoft.com/en-us/azure/templates/microsoft.botservice/2023-09-15-preview/botservices/networksecurityperimeterconfigurations?pivots=deployment-language-bicep>

The Bicep reference exposes only `name` and `parent` for this resource type. The generated `BotServiceNetworkSecurityPerimeterConfiguration` type exposes a writable `Properties` property, and `NetworkSecurityPerimeterConfigurationProperties` exposes writable `ProvisioningState` and `ProvisioningIssues` properties.

This resource is intentionally excluded from package examples until the spec or provisioning emitter behavior is reconciled with the Bicep schema.
