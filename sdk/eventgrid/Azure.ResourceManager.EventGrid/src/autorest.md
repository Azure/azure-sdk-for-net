# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: EventGrid
namespace: Azure.ResourceManager.EventGrid
require: https://github.com/Azure/azure-rest-api-specs/blob/df70965d3a207eb2a628c96aa6ed935edc6b7911/specification/eventgrid/resource-manager/readme.md
tag: package-2022-06
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}|Microsoft.EventGrid/topics/privateEndpointConnections: EventGridTopicPrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}|Microsoft.EventGrid/domains/privateEndpointConnections: EventGridDomainPrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}|Microsoft.EventGrid/partnerNamespaces/privateEndpointConnections: EventGridPartnerNamespacePrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateLinkResources/{privateLinkResourceName}|Microsoft.EventGrid/topics/privateLinkResources: EventGridTopicPrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateLinkResources/{privateLinkResourceName}|Microsoft.EventGrid/domains/privateLinkResources: EventGridDomainPrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateLinkResources/{privateLinkResourceName}|Microsoft.EventGrid/partnerNamespaces/privateLinkResources: PartnerNamespacePrivateLinkResource

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
  - from: EventGrid.json
    where: $.paths..parameters[?(@.name=='scope')]
    transform: >
      $['x-ms-skip-url-encoding'] = true;
  # PrivateEndpointConnection defines enum type but PrivateLinkResources not, should fix it in swagger 
  - from: EventGrid.json
    where: $.paths..parameters[?(@.name=='parentType')]
    transform: >
      $['enum'] = [
              'topics',
              'domains',
              'partnerNamespaces'
            ];
      $['x-ms-enum'] = {
              'name': 'ParentType',
              'modelAsString': true
            };
  
```