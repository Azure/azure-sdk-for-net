# Azure.Communication.JobRouter

When a new version of the swagger needs to be updated:
1. Go to sdk\communication\Azure.Communication.JobRouter\src, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. In root folder, run `eng\scripts\Export-API.ps1 -ServiceDirectory communication/Azure.Communication.JobRouter`
3. In root folder, run `eng\scripts\Update-Snippets.ps1 -ServiceDirectory communication/Azure.Communication.JobRouter`

> see [https://aka.ms/autorest](https://aka.ms/autorest)

## Configuration

```yaml
tag: package-jobrouter-2022-07-18-preview
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/29159d148372f5f61cb04b76fc87252b13c62515/specification/communication/data-plane/JobRouter/readme.md

generation1-convenience-client: true
reflect-api-versions: true
protocol-method-list:
    - JobRouterAdministration_UpsertClassificationPolicy
    - JobRouterAdministration_UpsertDistributionPolicy
    - JobRouterAdministration_UpsertExceptionPolicy
    - JobRouterAdministration_UpsertQueue
    - JobRouter_UpsertJob
    - JobRouter_UpsertWorker
```
