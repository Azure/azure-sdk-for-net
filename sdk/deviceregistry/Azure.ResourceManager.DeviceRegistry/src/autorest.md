# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: DeviceRegistry
namespace: Azure.ResourceManager.DeviceRegistry
require: https://github.com/Azure/azure-rest-api-specs/blob/0a29f9763e50adf092908d090ae4b91037bdc3e7/specification/deviceregistry/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

 

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
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
  VMScaleSet: VmScaleSet
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

directive:
  - from: asset.json
    where: $.definitions.AssetProperties
    transform: >
      $["x-ms-client-name"] = "AdrAssetProperties";
  - from: asset.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assets/{assetName}"].put
    transform: >
      $.parameters[3] = {
                "name": "assetName",
                "description": "Asset name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: asset.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assets/{assetName}"].patch
    transform: >
      $.parameters[3] = {
                "name": "assetName",
                "description": "Asset name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: asset.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assets/{assetName}"].delete
    transform: >
      $.parameters[3] = {
                "name": "assetName",
                "description": "Asset name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: asset.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assets/{assetName}"].get
    transform: >
      $.parameters[3] = {
                "name": "assetName",
                "description": "Asset name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: assetendpointprofile.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assetEndpointProfiles/{assetEndpointProfileName}"].put
    transform: >
      $.parameters[3] = {
                "name": "assetEndpointProfileName",
                "description": "Asset Endpoint Profile name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: assetendpointprofile.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assetEndpointProfiles/{assetEndpointProfileName}"].patch
    transform: >
      $.parameters[3] = {
                "name": "assetEndpointProfileName",
                "description": "Asset Endpoint Profile name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: assetendpointprofile.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assetEndpointProfiles/{assetEndpointProfileName}"].delete
    transform: >
      $.parameters[3] = {
                "name": "assetEndpointProfileName",
                "description": "Asset Endpoint Profile name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }
  - from: assetendpointprofile.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DeviceRegistry/assetEndpointProfiles/{assetEndpointProfileName}"].get
    transform: >
      $.parameters[3] = {
                "name": "assetEndpointProfileName",
                "description": "Asset Endpoint Profile name parameter.",
                "in": "path",
                "required": true,
                "type": "string",
                "pattern": "^[a-z0-9][a-z0-9-]*[a-z0-9]$",
                "maxLength": 63,
                "minLength": 3
            }

```