# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Resources/stable/2019-10-01/resources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Resources/stable/2019-11-01/subscriptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policyAssignments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policyDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policySetDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Resources/preview/2019-10-01-preview/deploymentScripts.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Features/stable/2015-12-01/features.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Authorization/stable/2016-09-01/locks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f9d1625a69e739f362dd16e32f8f9e8fa01abd37/specification/resources/resource-manager/Microsoft.Solutions/stable/2018-06-01/managedapplications.json
modelerfour:
    lenient-model-deduplication: true
directive:
  - from: subscriptions.json
    where: $.paths
    transform: delete $["/providers/Microsoft.Resources/operations"]
  - from: links.json
    where: $.paths
    transform: delete $["/providers/Microsoft.Resources/operations"]
```
