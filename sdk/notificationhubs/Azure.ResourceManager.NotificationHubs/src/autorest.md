# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: NotificationHubs
namespace: Azure.ResourceManager.NotificationHubs
require: https://github.com/Azure/azure-rest-api-specs/blob/87643ba491d34656ed9d08ddce7544d033c349eb/specification/notificationhubs/resource-manager/readme.md
#package-preview-2023-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}: NotificationHubNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/authorizationRules/{authorizationRuleName}: NotificationHubAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}: NotificationHubNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/AuthorizationRules/{authorizationRuleName}: NotificationHubAuthorizationRule

rename-mapping:
  NamespaceResource: NotificationHubNamespace
  NamespaceResource.properties.serviceBusEndpoint: -|uri
  NamespaceResource.properties.enabled: IsEnabled
  NamespaceResource.properties.critical: IsCritical
  NamespaceResource.properties.provisioningState: OperationProvisioningState
  NamespaceResource.properties.status: NamespaceStatus
  NamespaceResource.properties.namespaceType: HubNamespaceType
  ApnsCredential: NotificationHubApnsCredential
  ApnsCredential.properties.endpoint: -|uri
  ApnsCredential.properties.thumbprint: ThumbprintString
  BaiduCredential: NotificationHubBaiduCredential
  BaiduCredential.properties.baiduEndPoint: BaiduEndpoint|uri
  GcmCredential: NotificationHubGcmCredential
  GcmCredential.properties.gcmEndpoint: -|uri
  GcmCredential.properties.googleApiKey: gcmApiKey
  WnsCredential: NotificationHubWnsCredential
  WnsCredential.properties.windowsLiveEndpoint: -|uri
  NotificationHubResource: NotificationHub
  NotificationHubResource.properties.registrationTtl: -|duration-constant
  SharedAccessAuthorizationRuleResource: NotificationHubAuthorizationRule
  SharedAccessAuthorizationRuleResource.properties.createdTime: CreatedOn|date-time
  SharedAccessAuthorizationRuleResource.properties.modifiedTime: ModifiedOn|date-time
  SharedAccessAuthorizationRuleResource.properties.rights: AccessRights
  SharedAccessAuthorizationRuleProperties.createdTime: CreatedOn|date-time
  SharedAccessAuthorizationRuleProperties.modifiedTime: ModifiedOn|date-time
  MpnsCredential: NotificationHubMpnsCredential
  MpnsCredential.properties.thumbprint: ThumbprintString
  AdmCredential: NotificationHubAdmCredential
  AccessRights: AuthorizationRuleAccessRightExt
  CheckAvailabilityParameters: NotificationHubAvailabilityContent
  CheckAvailabilityResult: NotificationHubAvailabilityResult
  DebugSendResponse: NotificationHubTestSendResult
  DebugSendResponse.properties.results: FailureDescription
  NamespaceListResult: NotificationHubNamespaceListResult
  NamespaceType: NotificationHubNamespaceTypeExt
  PnsCredentialsResource: NotificationHubPnsCredentials
  PolicyKeyResource: NotificationHubPolicyKey
  ResourceListKeys: NotificationHubResourceKeys
  Sku: NotificationHubSku
  SkuName: NotificationHubSkuName
  IpRule: NotificationHubIPRule
  IpRule.rights: AccessRights
  NetworkAcls: NotificationHubNetworkAcls
  PublicInternetAuthorizationRule.rights: AccessRights
  SharedAccessAuthorizationRuleProperties.rights: AccessRights
  PrivateEndpointConnectionResource: NotificationHubPrivateEndpointConnection
  PrivateEndpointConnectionProperties: NotificationHubPrivateEndpointConnectionProperties
  NamespaceProperties: NotificationHubNamespaceProperties
  NamespaceProperties.enabled: IsEnabled
  NamespaceProperties.critical: IsCritical
  NamespaceStatus: NotificationHubNamespaceStatus
  PrivateLinkConnectionStatus: NotificationHubPrivateLinkConnectionStatus
  PublicNetworkAccess: NotificationHubPublicNetworkAccess
  RegistrationResult: NotificationHubPubRegistrationResult
  ReplicationRegion: AllowedReplicationRegion
  ReplicationRegion.WestUs2: WestUS2

parameter-rename-mapping:
  NotificationHubs_DebugSend:
    parameters: anyObject

override-operation-name:
  NotificationHubs_CheckNotificationHubAvailability: CheckNotificationHubAvailability
  Namespaces_CheckAvailability: CheckNotificationHubNamespaceAvailability

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
- from: notificationhubs.json
  where: $.definitions
  transform: >
    $.NotificationHubProperties.properties.name['x-ms-client-name'] = 'NotificationHubName';
    $.NamespaceProperties.properties.name['x-ms-client-name'] = 'NamespaceName';
    $.DebugSendResult.properties.success['type'] = 'integer';
    $.DebugSendResult.properties.failure['type'] = 'integer';
# Revert spec modifications to keep backward compatibility.”
- from: notificationhubs.json
  where: $.definitions
  transform: >
    $.NotificationHubProperties.properties.authorizationRules['readOnly'] = false;
    $.NamespaceProperties.properties.createdAt['readOnly'] = false;
    $.NamespaceProperties.properties.critical['readOnly'] = false;
    $.NamespaceProperties.properties.enabled['readOnly'] = false;
    $.NamespaceProperties.properties.name['readOnly'] = false;
    $.NamespaceProperties.properties.region['readOnly'] = false;
    $.NamespaceProperties.properties.serviceBusEndpoint['readOnly'] = false;
    $.NamespaceProperties.properties.updatedAt['readOnly'] = false;
    $.NamespaceProperties.properties.subscriptionId['readOnly'] = false;
```
