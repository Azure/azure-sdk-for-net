# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Relay
namespace: Azure.ResourceManager.Relay
require: https://github.com/Azure/azure-rest-api-specs/blob/16019d65735c2330ce2efd687d7a62d1985b1252/specification/relay/resource-manager/readme.md
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

request-path-to-resource-name:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}: RelayNamespaceAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/hybridConnections/{hybridConnectionName}/authorizationRules/{authorizationRuleName}: RelayHybridConnectionAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Relay/namespaces/{namespaceName}/wcfRelays/{relayName}/authorizationRules/{authorizationRuleName}: WcfRelayAuthorizationRule

override-operation-name:
  Namespaces_CheckNameAvailability: CheckRelayNamespaceNameAvailability

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

rename-mapping:
  AuthorizationRule: RelayAuthorizationRule
  AccessRights: RelayAccessRight
  HybridConnection.properties.requiresClientAuthorization: IsClientAuthorizationRequired
  AccessKeys: RelayAccessKeys
  RegenerateAccessKeyParameters: RelayRegenerateAccessKeyContent
  NetworkRuleSet.properties.trustedServiceAccessEnabled: IsTrustedServiceAccessEnabled
  NetworkRuleSet: RelayNetworkRuleSet
  DefaultAction: RelayNetworkRuleSetDefaultAction
  NetworkRuleIPAction: RelayNetworkRuleIPAction
  PublicNetworkAccess: RelayPublicNetworkAccess
  ConnectionState: RelayPrivateLinkServiceConnectionState
  PrivateLinkConnectionStatus: RelayPrivateLinkConnectionStatus
  EndPointProvisioningState: RelayPrivateEndpointConnectionProvisioningState
  WcfRelay.properties.requiresClientAuthorization: IsClientAuthorizationRequired
  WcfRelay.properties.requiresTransportSecurity: IsTransportSecurityRequired
  Relaytype: RelayType
  CheckNameAvailability: RelayNameAvailabilityContent
  CheckNameAvailabilityResult: RelayNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  UnavailableReason: RelayNameUnavailableReason
  KeyType: RelayAccessKeyType
  HybridConnection: RelayHybridConnection

directive:
  - from: swagger-document
    where: $.definitions
    transform: >
      $.NWRuleSetIpRules['x-ms-client-name'] = 'RelayNetworkRuleSetIPRule';
  - from: swagger-document
    where: $.definitions
    transform: >
      $.RelayNamespaceProperties.properties.publicNetworkAccess['description'] = 'This determines if traffic is allowed over public network. By default it is enabled. DO NOT USE PublicNetworkAccess on Namespace API. Please use the NetworkRuleSet API to enable or disable PublicNetworkAccess.';
```
