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
openapi-type: data-plane
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/805e16a53f0a725471e0caa6007b48986c7722d9/specification/communication/data-plane/JobRouter/preview/2021-10-20-preview2/communicationservicejobrouter.json

generation1-convenience-client: true

title:
  Azure Communication Services

csharp:
  azure-arm: true
  license-header: MICROSOFT_MIT_NO_VERSION
  payload-flattening-threshold: 1
  clear-output-folder: true
  client-side-validation: false
  namespace: Azure.Communication.JobRouter
```

### Set reference to WorkerSelectorAttachment in ClassificationPolicy
```yaml
directive:
  - from: swagger-document
    where: "$.definitions.ClassificationPolicy.properties.workerSelectors.items"
    transform: >
      $["$ref"] = "#/definitions/WorkerSelectorAttachment";
```

### Set reference to QueueSelectorAttachment in ClassificationPolicy
```yaml
directive:
  - from: swagger-document
    where: "$.definitions.ClassificationPolicy.properties.queueSelectors.items"
    transform: >
      $["$ref"] = "#/definitions/QueueSelectorAttachment";
```

### Set reference to WorkerSelectorAttachment in PagedClassificationPolicy
```yaml
directive:
  - from: swagger-document
    where: "$.definitions.PagedClassificationPolicy.properties.workerSelectors.items"
    transform: >
      $["$ref"] = "#/definitions/WorkerSelectorAttachment";
```

### Set reference to QueueSelectorAttachment in PagedClassificationPolicy
```yaml
directive:
  - from: swagger-document
    where: "$.definitions.PagedClassificationPolicy.properties.queueSelectors.items"
    transform: >
      $["$ref"] = "#/definitions/QueueSelectorAttachment";
```

### Set reference to ExceptionAction in ExceptionRule
```yaml
directive:
  - from: swagger-document
    where: "$.definitions.ExceptionRule.properties.actions"
    transform: >
      $.type = "object";
      $.additionalProperties["$ref"] = "#/definitions/ExceptionAction";
```

### Rename CommunicationError to JobRouterError
```yaml
directive:
  from: swagger-document
  where: '$.definitions.CommunicationError'
  transform: >
    $["x-ms-client-name"] = "JobRouterError";
```

### Rename AcceptJobOfferResponse to AcceptJobOfferResult
```yaml
directive:
  from: swagger-document
  where: '$.definitions.AcceptJobOfferResponse'
  transform: >
    $["x-ms-client-name"] = "AcceptJobOfferResult";
```
