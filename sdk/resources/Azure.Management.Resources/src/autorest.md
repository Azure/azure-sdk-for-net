# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/resources/resource-manager/readme.md
batch:
  - package-features: true
  - package-locks: true
  - package-policy: true
  - package-resources: true
  - package-subscriptions: true
  - package-links: true
  - package-deploymentscripts: true
modelerfour:
  lenient-model-deduplication: true
```