# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ApiManagement
namespace: Azure.ResourceManager.ApiManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/b9b91929c304f8fb44002267b6c98d9fb9dde014/specification/apimanagement/resource-manager/readme.md
tag: package-2021-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
skip-serialization-format-xml: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.ApiManagement/locations/{location}/deletedservices/{serviceName}

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
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Etag: ETag

override-operation-name:
  NetworkStatus_ListByLocation: GetNetworkStatusByLocation


directive:
  - remove-operation: 'ApiManagementOperations_List'
  - from: definitions.json
    where: $.definitions
    transform: >
      $.AuthorizationServerContractBaseProperties.properties.bearerTokenSendingMethods.items['x-ms-enum']['name'] = 'BearerTokenSendingMethodMode';
      $.BearerTokenSendingMethodsContract['x-ms-enum']['name'] = 'BearerTokenSendingMethodContract';
      $.OpenidConnectProviderContract['x-ms-client-name'] = 'OpenIdConnectProviderContract';
      $.OpenidConnectProviderUpdateContract['x-ms-client-name'] = 'OpenIdConnectProviderUpdateContract';
  - from: apimdeployment.json
    where: $.definitions
    transform: >
      $.Operation['x-ms-client-name'] = 'RestApiOperation';
      $.VirtualNetworkConfiguration.properties.vnetid['x-ms-client-name'] = 'VnetId';
  - from: apimanagement.json
    where: $.parameters
    transform: >
      $.OpenIdConnectIdParameter['x-ms-client-name'] = 'OpenId';

```