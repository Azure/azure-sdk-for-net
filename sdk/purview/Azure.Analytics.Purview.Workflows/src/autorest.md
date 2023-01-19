# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: 
- C:/Users/jiwang6/repo/azure-rest-api-specs-pr/specification/purview/data-plane/Azure.Analytics.Purview.Workflow/preview/2022-05-01-preview/purviewWorkflow.json
namespace: Azure.Analytics.Purview.Workflows
security: AADToken
security-scopes: https://purview.azure.net/.default
 
```
