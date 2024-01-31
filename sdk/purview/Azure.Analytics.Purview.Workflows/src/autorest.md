# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/afa158ef56a05f6603924f4a493817cec332b113/specification/purview/data-plane/Azure.Analytics.Purview.Workflow/preview/2023-10-01-preview/purviewWorkflow.json
security: AADToken
security-scopes: https://purview.azure.net/.default

```








