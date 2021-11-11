# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.ProviderShortName
require: https://github.com/Azure/azure-rest-api-specs/blob/4faf292aa0f76fd1cfc2a4085c69391d79ada56e/specification/ProviderNameMappingPrefixProviderNameMappingSuffix/resource-manager/readme.md
use: D:/Autorest-Branch/autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/
tagPrefix SwaggerVersionTag
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
mgmt-debug:
  suppress-list-exception: true
modelerfour:
  lenient-model-deduplication: true

```