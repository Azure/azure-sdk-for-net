# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# tag: package-access-control-2020-08-01-preview
input-file:
#    - https://github.com/Azure/azure-rest-api-specs/blob/fc5e2fbcfc3f585d38bdb1c513ce1ad2c570cf3d/specification/synapse/data-plane/readme.md
  - $(this-folder)/swagger/checkAccessSynapseRbac.json
  - $(this-folder)/swagger/roleAssignments.json
  - $(this-folder)/swagger/roleDefinitions.json
namespace: Azure.Analytics.Synapse.AccessControl
public-clients: true
low-level-client: true
security: AADToken
security-scopes: https://dev.azuresynapse.net/.default
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```
