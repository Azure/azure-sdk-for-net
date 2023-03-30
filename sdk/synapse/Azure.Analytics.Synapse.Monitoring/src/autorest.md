# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-monitoring-2019-11-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/fc5e2fbcfc3f585d38bdb1c513ce1ad2c570cf3d/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Monitoring
generation1-convenience-client: true
security: AADToken
security-scopes: https://dev.azuresynapse.net/.default
# use: D:/GIT/pshao25.csharp/artifacts/bin/AutoRest.CSharp/Debug/net6.0
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```