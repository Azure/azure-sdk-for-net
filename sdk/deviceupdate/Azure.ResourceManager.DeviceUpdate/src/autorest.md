# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.DeviceUpdate
require: https://github.com/Azure/azure-rest-api-specs/blob/c577452bb8022521a87142bcaaf2e4bde92b64c8/specification/deviceupdate/resource-manager/readme.md
#tag: package-2023-07-01
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

override-operation-name:
  CheckNameAvailability: CheckDeviceUpdateNameAvailability

rename-mapping:
  GroupInformation: DeviceUpdatePrivateLink
  Location: DeviceUpdateAccountLocationDetail
  Role: DeviceUpdateAccountLocationRole
  SKU: DeviceUpdateSku
  Encryption.userAssignedIdentity: -|arm-id
  CheckNameAvailabilityResponse: DeviceUpdateNameAvailabilityResult
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityReason: DeviceUpdateNameUnavailableReason
  CheckNameAvailabilityRequest: DeviceUpdateAvailabilityContent
  CheckNameAvailabilityRequest.type: -|resource-type
  AuthenticationType: DiagnosticStorageAuthenticationType
  ConnectionDetails: DeviceUpdatePrivateEndpointConnectionDetails
  IotHubSettings.resourceId: -|arm-id
  DiagnosticStorageProperties.resourceId: -|arm-id
  GroupConnectivityInformation.privateLinkServiceArmRegion: -|azure-location
  GroupIdProvisioningState: DeviceUpdatePrivateLinkProvisioningState
  PrivateEndpointUpdate.id: -|arm-id
  PrivateEndpointUpdate.immutableResourceId: -|arm-id
  PrivateLinkServiceProxy.id: -|arm-id
  RemotePrivateEndpoint.id: -|arm-id
  RemotePrivateEndpoint.immutableResourceId: -|arm-id

prepend-rp-prefix:
  - Account
  - Instance
  - Encryption
  - ProvisioningState
  - PublicNetworkAccess
  - IotHubSettings
  - PrivateEndpointConnectionProxy
  - PrivateEndpointUpdate
  - PrivateEndpointConnectionProxyProvisioningState
  - PrivateLinkServiceConnection
  - PrivateLinkServiceProxy
  - RemotePrivateEndpoint

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  - remove-operation: Accounts_Head  # Not supported yet
  - remove-operation: Instances_Head # Not supported yet
  # Swagger issue, should be fixed
  - from: deviceupdate.json
    where: $.definitions
    transform: >
      delete $.AccountUpdate['allOf'];
      $.AccountUpdate.properties['tags'] = {
        "type": "object",
        "description": "List of key value pairs that describe the resource. This will overwrite the existing tags.",
        "additionalProperties": {
          "type": "string"
        }
      };

```
