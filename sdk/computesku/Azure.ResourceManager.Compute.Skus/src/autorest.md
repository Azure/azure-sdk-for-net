# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: ComputeSku
namespace: Azure.ResourceManager.Compute
title: ComputeManagementClient
# require: https://github.com/Azure/azure-rest-api-specs/blob/6fb604853ab1c56f2adbe6e4922c31e772425cba/specification/compute/resource-manager/readme.md
tag: split-package-2025-04-01-skus
output-folder: $(this-folder)/Generated
clear-output-folder: true
# sample-gen:
#   output-folder: $(this-folder)/../tests/Generated
#   clear-output-folder: true
#   skipped-operations:
#     - CommunityGalleries_Get
#     - SharedGalleries_Get
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

override-operation-name:
  ResourceSkus_List: GetComputeResourceSkus

rename-mapping:
  ResourceSkuCapabilities: ComputeResourceSkuCapabilities
```

## Tag: split-package-2025-04-01-skus

Creating this tag to exclude some preview operations that do not exist in our previous stable version of monitor releases.

These settings apply only when `--tag=split-package-2025-04-01-skus` is specified on the command line.

This is identical to the real compute's tag, but we only kept the skus.json input file for test.

```yaml $(tag) == 'split-package-2025-04-01-skus'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/6fb604853ab1c56f2adbe6e4922c31e772425cba/specification/compute/resource-manager/Microsoft.Compute/Skus/stable/2021-07-01/skus.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/6fb604853ab1c56f2adbe6e4922c31e772425cba/specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2025-04-01/ComputeRP.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/6fb604853ab1c56f2adbe6e4922c31e772425cba/specification/compute/resource-manager/Microsoft.Compute/DiskRP/stable/2025-01-02/DiskRP.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/6fb604853ab1c56f2adbe6e4922c31e772425cba/specification/compute/resource-manager/Microsoft.Compute/GalleryRP/stable/2024-03-03/GalleryRP.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/6fb604853ab1c56f2adbe6e4922c31e772425cba/specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2024-11-04/cloudService.json
```
