# Azure.Communication.JobRouter

When a new version of the swagger needs to be updated:
1. Go to sdk\communication\Azure.Communication.JobRouter\src, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.JobRouter.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

> see [https://aka.ms/autorest](https://aka.ms/autorest)

## Configuration

```yaml
tag: package-jobrouter-2021-10-20-preview2
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5cd329c4ab95ed45749f78026cae892b73015a82/specification/communication/data-plane/JobRouter/readme.md

generation1-convenience-client: true
```

### Rename AcceptJobOfferResponse to AcceptJobOfferResult
```yaml
directive:
  - from: swagger-document
    where: '$.definitions.AcceptJobOfferResponse'
    transform: >
      $["x-ms-client-name"] = "AcceptJobOfferResult";
```
