# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/Azure/azure-rest-api-specs/tree/8a09ea0b84aa36cb0e56bab4f4c8efd83a6fdcf6
```

``` yaml
public-clients: true
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-11-01-preview/monitoring.json
```
