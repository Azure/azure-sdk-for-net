# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/Azure/azure-rest-api-specs/blob/fdf4bbfd7a73b28960d3a62490440345d6f2e8e3
```

``` yaml
public-clients: true
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-11-01-preview/sparkJob.json
```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SparkBatchJob
  transform: >
    $.properties.appId["x-nullable"] = true;
    $.properties.appInfo["x-nullable"] = true;
    $.properties.log["x-nullable"] = true;
````
