# Troubleshooting Azure.Projects

Use this file to find solutions to common issues related to Azure.Projects developmnet.
You can search this file for issues you are experiencing,
or better feed it to your Copilot and ask it to help you with the issue. 

## Provisioning Issues

### Error: "The subscription has reached its limit of 'configurationStores' resources with the 'free' SKU."

By default, project configuration settings are stored in a free SKU of Azure App Configuration service.
If you need to provision more than one application in the same subscription,
you need to change the SKU to one of the higher tiers.
Note that this might incur additional costs.
See the [Azure App Configuration pricing page](https://azure.microsoft.com/pricing/details/app-configuration/) for more details.

```C# Snippet:StoreAppConfigurationSku
AppConfigConnectionStore connections = new(AppConfigurationFeature.SkuName.Developer);
ProjectInfrastructure infrastructure = new(connections);
```