# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: DigitalTwins
namespace: Azure.ResourceManager.DigitalTwins
require: https://github.com/Azure/azure-rest-api-specs/blob/fc0c0316bf5187af413a256c484c1e2a259e18b8/specification/digitaltwins/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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

rename-rules:
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
