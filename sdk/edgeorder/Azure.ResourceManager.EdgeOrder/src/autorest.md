# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: EdgeOrder
namespace: Azure.ResourceManager.EdgeOrder
require: https://github.com/Azure/azure-rest-api-specs/blob/58891380ba22c3565ca884dee3831445f638b545/specification/edgeorder/resource-manager/readme.md
tag: package-2021-12
output-folder: Generated/
clear-output-folder: true
mgmt-debug:
  suppress-list-exception: true
modelerfour:
  lenient-model-deduplication: true
directive:
  - from: swagger-document
    where: $.definitions.Origin
    transform: >
      $['x-ms-enum'] = {
          "name": "OperationOrigin",
          "modelAsString": true
      }
  - rename-model:
      from: Configuration
      to: ProductConfiguration
  - rename-model:
      from: Configurations
      to: ProductConfigurations
  - rename-model:
      from: Description
      to: ProductDescription
  - rename-model:
      from: Dimensions
      to: ProductDimensions
  - rename-model:
      from: Link
      to: ProductLink
  - rename-model:
      from: Operation
      to: EdgeOrderOperation
  - rename-model:
      from: Preferences
      to: OrderItemPreferences
  - rename-model:
      from: Product
      to: EdgeOrderProduct
  - rename-model:
      from: Specification
      to: ProductSpecification

```