# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Dns
namespace: Azure.ResourceManager.Dns
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/e0996d4f6dbca40ebf2fa4abf9a1cba45ada94d8/specification/dns/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

```