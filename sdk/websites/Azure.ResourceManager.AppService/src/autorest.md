# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.AppService

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: AppService
namespace: Azure.ResourceManager.AppService
require: https://github.com/Azure/azure-rest-api-specs/blob/ec2b6d1985ce89c8646276e0806a738338e98bd2/specification/web/resource-manager/readme.md
tag: package-2021-02
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
output-folder: ./Generated
directive:
# pageable lro
  - remove-operation: AppServiceEnvironments_ChangeVnet
  - remove-operation: AppServiceEnvironments_Resume
  - remove-operation: AppServiceEnvironments_Suspend
# get array
  - remove-operation: AppServicePlans_GetRouteForVnet
  - from: swagger-document
    where: $.definitions.AppServicePlan.properties.hostingEnviromentProfile
    transform: $["x-nullable"] = true
```
