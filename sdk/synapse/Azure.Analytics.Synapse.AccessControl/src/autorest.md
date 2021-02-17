# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
repo: https://github.com/Azure/azure-rest-api-specs/blob/aa19725fe79aea2a9dc580f3c66f77f89cc34563
```

``` yaml
public-clients: true
input-file:
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2020-08-01-preview/roleAssignments.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2020-08-01-preview/roleDefinitions.json
    - $(repo)/specification/synapse/data-plane/Microsoft.Synapse/preview/2020-08-01-preview/checkAccessSynapseRbac.json
```
