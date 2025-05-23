# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DigitalTwins
namespace: Azure.ResourceManager.DigitalTwins
require: https://github.com/Azure/azure-rest-api-specs/blob/71e8a754d34d1af32bf81f23445f286422ca4c40/specification/digitaltwins/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

rename-mapping:
  AzureDataExplorerConnectionProperties.adxResourceId: -|arm-id
  AzureDataExplorerConnectionProperties.eventHubNamespaceResourceId: -|arm-id
  CheckNameResult.nameAvailable: IsNameAvailable
  CheckNameRequest.type: ResourceType
  AuthenticationType: DigitalTwinsAuthenticationType
  ProvisioningState: DigitalTwinsProvisioningState
  PublicNetworkAccess: DigitalTwinsPublicNetworkAccess
  GroupIdInformation: DigitalTwinsPrivateLinkResource
  GroupIdInformationProperties: DigitalTwinsPrivateLinkResourceProperties
  ConnectionProperties: DigitalTwinsPrivateEndpointConnectionProperties
  AzureDataExplorerConnectionProperties: DataExplorerConnectionProperties
  CheckNameResult: DigitalTwinsNameResult
  CheckNameRequest: DigitalTwinsNameContent
  Reason: DigitalTwinsNameUnavailableReason
  ConnectionState: DigitalTwinsPrivateLinkServiceConnectionState
  PrivateLinkServiceConnectionStatus: DigitalTwinsPrivateLinkServiceConnectionStatus
  ConnectionPropertiesProvisioningState: DigitalTwinsPrivateLinkResourceProvisioningState
  EndpointProvisioningState: DigitalTwinsEndpointProvisioningState
  EventGrid: DigitalTwinsEventGridProperties
  EventHub: DigitalTwinsEventHubProperties
  ServiceBus: DigitalTwinsServiceBusProperties
  ResourceType: DigitalTwinsResourceType
  ManagedIdentityReference: DigitalTwinsManagedIdentityReference
  IdentityType: DigitalTwinsManagedIdentityType

override-operation-name:
  PrivateLinkResources_Get: GetPrivateLinkResourceGroupIdInformation
  DigitalTwins_CheckNameAvailability: CheckDigitalTwinsNameAvailability

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
  - from: digitaltwins.json
    where: $.definitions
    transform: >
      $.CheckNameRequest.properties.type['x-ms-enum']['name'] = 'ResourceType';
      $.ConnectionProperties.properties.privateLinkServiceConnectionState = {
            'description': 'The connection state.',
            '$ref': '#/definitions/ConnectionState'
          };
```
