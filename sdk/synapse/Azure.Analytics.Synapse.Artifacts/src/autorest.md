# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/Azure/azure-rest-api-specs/blob/036a9bba574b092c83a5d1b2fd9482d87e8fdc9d
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
```
