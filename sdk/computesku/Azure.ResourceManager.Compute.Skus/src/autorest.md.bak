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
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VirtualMachineScaleSet
  VmScaleSet: VirtualMachineScaleSet
  VmScaleSets: VirtualMachineScaleSets
  VMScaleSets: VirtualMachineScaleSets
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  SSD: Ssd
  SAS: Sas
  VCPUs: VCpus
  LRS: Lrs
  ZRS: Zrs
  RestorePointCollection: RestorePointGroup # the word `collection` is reserved by the SDK, therefore we need to rename all the occurrences of this in all resources and models
  EncryptionSettingsCollection: EncryptionSettingsGroup # the word `collection` is reserved by the SDK, therefore we need to rename all the occurrences of this in all resources and models
  VHD: Vhd
  VHDX: Vhdx

override-operation-name:
  ResourceSkus_List: GetComputeResourceSkus

rename-mapping:
  ResourceSku: ComputeResourceSku
  ResourceSkuCapacity: ComputeResourceSkuCapacity
  ResourceSkuCapacityScaleType: ComputeResourceSkuCapacityScaleType
  ResourceSkuLocationInfo: ComputeResourceSkuLocationInfo
  ResourceSkuRestrictionInfo: ComputeResourceSkuRestrictionInfo
  ResourceSkuRestrictions: ComputeResourceSkuRestrictions
  ResourceSkuRestrictionsReasonCode: ComputeResourceSkuRestrictionsReasonCode
  ResourceSkuRestrictionsType: ComputeResourceSkuRestrictionsType
  ResourceSkuZoneDetails: ComputeResourceSkuZoneDetails
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
