# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
use: $(this-folder)/../../../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/readme.md
modelerfour:
  lenient-model-deduplication: true
show-request-path: true
directive:
    - remove-operation: FirewallRules_Replace
    - remove-operation: DatabaseExtensions_Get
    - rename-operation:
        from: ManagedDatabaseRecommendedSensitivityLabels_Update
        to: ManagedDatabaseSensitivityLabels_UpdateRecommended
    - rename-operation:
        from: RecommendedSensitivityLabels_Update
        to: SensitivityLabels_UpdateRecommended

```
