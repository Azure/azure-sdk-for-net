# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/Azure/azure-rest-api-specs/blob/9dfdc98ddb44c7ef2d63449c7492347876ad3e11 
```

``` yaml
public-clients: true
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2019-11-01-preview/monitoring.json
```
