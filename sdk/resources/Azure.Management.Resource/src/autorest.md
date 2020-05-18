# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/Microsoft.Resources/stable/2019-10-01/resources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/Microsoft.Resources/stable/2019-11-01/subscriptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policyAssignments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policyDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policySetDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/Microsoft.Resources/preview/2019-10-01-preview/deploymentScripts.json
modelerfour:
    lenient-model-deduplication: true
directive:
  - from: subscriptions.json
    where: $.paths
    transform: delete $["/providers/Microsoft.Resources/operations"]
```
