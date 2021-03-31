# Microsoft.Azure.Synapse.Artifacts

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-artifacts-2019-06-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/ba2d430b967bc6299fbedb8dc16ff039e08e1388/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Artifacts
public-clients: true
credential-types: TokenCredential
credential-scopes: https://dev.azuresynapse.net/.default
modelerfour:
  lenient-model-deduplication: true
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
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
          path.endsWith("CopyBehaviorType") ||
          path.endsWith("CopyTranslator") ||
          path.endsWith("DataFlowDebugPreviewDataRequest") ||
          path.endsWith("DataFlowDebugQueryResponse") ||
          path.endsWith("DataFlowDebugResultResponse") ||
          path.endsWith("DataFlowDebugStatisticsRequest") ||
          path.endsWith("DatasetDataElement") ||
          path.endsWith("DatasetSchemaDataElement") ||
          path.endsWith("DatasetStorageFormat") ||
          path.endsWith("EvaluateDataFlowExpressionRequest") ||
          path.endsWith("ExposureControlRequest") ||
          path.endsWith("ExposureControlResponse") ||
          path.endsWith("GetSsisObjectMetadataRequest") ||
          path.endsWith("JsonFormat") ||
          path.endsWith("JsonFormatFilePattern") ||
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