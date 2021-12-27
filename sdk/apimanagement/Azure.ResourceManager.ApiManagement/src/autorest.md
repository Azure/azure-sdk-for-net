# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: ApiManagement
namespace: Azure.ResourceManager.ApiManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/ea0f7b072ad3aaff203ea9003246b9e584b819ff/specification/apimanagement/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
no-property-type-replacement: 
  - PrivateEndpoint
list-exception:
  - /subscriptions/{subscriptionId}/providers/Microsoft.ApiManagement/locations/{location}/deletedservices/{serviceName}
directive:
  - rename-operation:
      from: ApiManagementOperations_List
      to: Operations_List
```
