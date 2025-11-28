# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: EdgeActions
namespace: Azure.ResourceManager.EdgeActions
title: EdgeActionsManagementClient
require: https://github.com/Azure/azure-rest-api-specs/blob/f2a98b8cbb07e49b5f07a4ccba068e866f6cd920/specification/cdn/resource-manager/Microsoft.Cdn/EdgeActions/readme.md
tag: package-2025-09-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

#mgmt-debug:
#  show-serialized-names: true

directive:
  # Suppress Operations endpoint warning - operations defined in main CDN swagger
  - suppress: R4009
    from: openapi.json
    reason: Operations endpoint defined in main CDN package

rename-mapping:
  EdgeAction.properties.attachments: Attachments
  EdgeActionProperties.attachments: Attachments

override-client-name: EdgeActionsManagementClient
```
