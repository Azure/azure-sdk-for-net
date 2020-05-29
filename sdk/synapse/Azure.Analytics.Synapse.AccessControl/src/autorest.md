# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/idear1203/azure-rest-api-specs/blob/624ed22741a5a0d076eb092e87aed474557e20fc
```

``` yaml
public-clients: true
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2020-02-01-preview/roleAssignments.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2020-02-01-preview/roles.json
```
