# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/3a1ca5a2130250382e65e4585d8e88bfab6d93e4/specification/purview/data-plane/Azure.Analytics.Purview.Workflow/preview/2022-05-01-preview/purviewWorkflow.json
security: AADToken
security-scopes: https://purview.azure.net/.default

```
