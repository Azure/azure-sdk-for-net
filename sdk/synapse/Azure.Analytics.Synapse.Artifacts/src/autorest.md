# Microsoft.Azure.Synapse.Artifacts

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-artifacts-composite-v7
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/5ae522bc106bf8609c6cb379e584aa3e0e2639f3/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Artifacts
generation1-convenience-client: true
public-clients: true
security: AADToken
security-scopes: https://dev.azuresynapse.net/.default
modelerfour:
  lenient-model-deduplication: true
  seal-single-value-enum-by-default: true
model-factory-for-hlc:
- ManagedIntegrationRuntime

suppress-abstract-base-class:
- Dataset
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.Notebook
  transform: >
    $.properties.folder["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SparkJobDefinition
  transform: >
    $.properties.folder["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SqlScript
  transform: >
    $.properties.folder["x-nullable"] = true;
```

### Expose serialization and deserialization methods and internal models

``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    for (var path in $)
    {
      if (path.endsWith("AvroFormat") ||
          path.endsWith("CreateDataFlowDebugSessionRequest") ||
          path.endsWith("CopyBehaviorType") ||
          path.endsWith("CopyTranslator") ||
          path.endsWith("DataFlowDebugPreviewDataRequest") ||
          path.endsWith("DataFlowDebugQueryResponse") ||
          path.endsWith("DataFlowDebugResultResponse") ||
          path.endsWith("DataFlowDebugStatisticsRequest") ||
          path.endsWith("DataFlowDebugPackage") ||
          path.endsWith("DatasetDataElement") ||
          path.endsWith("DatasetSchemaDataElement") ||
          path.endsWith("DatasetStorageFormat") ||
          path.endsWith("EditTablesRequest") ||
          path.endsWith("EvaluateDataFlowExpressionRequest") ||
          path.endsWith("ExposureControlRequest") ||
          path.endsWith("ExposureControlResponse") ||
          path.endsWith("GetSsisObjectMetadataRequest") ||
          path.endsWith("JsonFormat") ||
          path.endsWith("JsonFormatFilePattern") ||
          path.endsWith("LinkTableRequest") ||
          path.endsWith("OrcFormat") ||
          path.endsWith("ParquetFormat") ||
          path.endsWith("RerunTriggerListResponse") ||
          path.endsWith("RerunTumblingWindowTriggerActionParameter") ||
          path.endsWith("SsisObjectMetadataStatusResponse") ||
          path.endsWith("StartDataFlowDebugSessionRequest") ||
          path.endsWith("StartDataFlowDebugSessionResponse") ||
          path.endsWith("TabularTranslator") ||
          path.endsWith("TextFormat") ||
          path.endsWith("TriggerDependencyProvisioningStatus") ||
          path.endsWith("TypeConversionSettings") ||
          path.endsWith("WorkspaceIdentity") ||
          path.endsWith("WorkspaceUpdateParameters"))
      {
        $[path]["x-csharp-usage"] = "model,input,output,converter";
        $[path]["x-csharp-formats"] = "json";
      }
      else
      {
        $[path]["x-csharp-usage"] = "converter";
      }
    }
```

### Fix spelling issues

``` yaml
directive:
  from: swagger-document
  where: $.definitions.Notebook.properties
  transform: >
    $.nbformat['x-ms-client-name'] = 'NotebookFormat';
    $.nbformat_minor['x-ms-client-name'] = 'NotebookFormatMinor';
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.TriggerRun.properties
  transform: >
    $.status["x-ms-enum"].values = [{value: "Succeeded", name: "Succeeded" },{value: "Failed", name: "Failed" },{value: "Inprogress", name: "InProgress" }];
```

### Suppress Abstract Base Class

``` yaml
suppress-abstract-base-class:
- CustomSetupBase
- DataFlow
- DependencyReference
- LinkedIntegrationRuntimeType
- SecretBase
- WebLinkedServiceTypeProperties
```
