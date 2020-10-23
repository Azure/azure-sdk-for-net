# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/Azure/azure-rest-api-specs/blob/6dbb686b279234e608aba00309e6b8564c291c97
```

``` yaml
public-clients: true
modelerfour:
  lenient-model-deduplication: true
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/artifacts.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/DataFlow.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/Dataset.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/LinkedService.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/Notebook.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/Pipeline.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/SparkJobDefinition.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/SqlScript.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/entityTypes/Trigger.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/bigDataPools.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/integrationRuntimes.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/sqlPools.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-06-01-preview/workspace.json
```
