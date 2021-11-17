# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d302c82f32daec0feb68cd7d68d45ba898b67ee7/specification/appconfiguration/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
no-property-type-replacement: RegenerateKeyParameters
# operation-group-to-resource-type:
#  PrivateLinkResources: Microsoft.AppConfiguration/configurationStores/privateLinkResources
# operation-group-to-resource:
#   PrivateLinkResources: PrivateLinkResource
directive:
  - from: swagger-document
    where: $.definitions.EncryptionProperties
    transform: >
      $.properties.keyVaultProperties["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ConfigurationStoreProperties
    transform: >
      $.properties.privateEndpointConnections["x-nullable"] = true;
````