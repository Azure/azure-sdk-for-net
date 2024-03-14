# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: NotificationHubs
namespace: Azure.ResourceManager.NotificationHubs
require: https://github.com/Azure/azure-rest-api-specs/blob/a03dfac64acc53a8b84501a10099f95885b1b496/specification/notificationhubs/resource-manager/readme.md
#package-preview-2023-10
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

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}: NotificationHubNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/authorizationRules/{authorizationRuleName}: NotificationHubAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}: NotificationHubNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/AuthorizationRules/{authorizationRuleName}: NotificationHubAuthorizationRule

rename-mapping:
  NamespaceResource.properties.serviceBusEndpoint: -|uri
  ApnsCredential.properties.endpoint: -|uri
  BaiduCredential.properties.baiduEndPoint: BaiduEndpoint|uri
  GcmCredential.properties.gcmEndpoint: -|uri
  GcmCredential.properties.googleApiKey: gcmApiKey
  WnsCredential.properties.windowsLiveEndpoint: -|uri
  NotificationHubResource.properties.registrationTtl: -|duration-constant
  SharedAccessAuthorizationRuleResource.properties.createdTime: CreatedOn|date-time
  SharedAccessAuthorizationRuleResource.properties.modifiedTime: ModifiedOn|date-time
  SharedAccessAuthorizationRuleProperties.createdTime: CreatedOn|date-time
  SharedAccessAuthorizationRuleProperties.modifiedTime: ModifiedOn|date-time
  NamespaceResource.properties.enabled: IsEnabled
  NamespaceResource.properties.critical: IsCritical
  ApnsCredential: NotificationHubApnsCredential
  WnsCredential: NotificationHubWnsCredential
  GcmCredential: NotificationHubGcmCredential
  MpnsCredential: NotificationHubMpnsCredential
  AdmCredential: NotificationHubAdmCredential
  BaiduCredential: NotificationHubBaiduCredential
  AccessRights: AuthorizationRuleAccessRight
  NamespaceResource: NotificationHubNamespace
  NotificationHubResource: NotificationHub
  SharedAccessAuthorizationRuleResource: NotificationHubAuthorizationRule
  CheckAvailabilityParameters: NotificationHubAvailabilityContent
  CheckAvailabilityResult: NotificationHubAvailabilityResult
  DebugSendResponse: NotificationHubTestSendResult
  NamespaceListResult: NotificationHubNamespaceListResult
  NamespaceType: NotificationHubNamespaceType
  PnsCredentialsResource: NotificationHubPnsCredentials
  PolicyKeyResource: NotificationHubPolicyKey
  ResourceListKeys: NotificationHubResourceKeys
  Sku: NotificationHubSku
  SkuName: NotificationHubSkuName
  ApnsCredential.properties.thumbprint: ThumbprintString
  MpnsCredential.properties.thumbprint: ThumbprintString
  NamespaceResource.properties.provisioningState: OperationProvisioningState
  NamespaceResource.properties.status: NamespaceStatus

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
    $.NamespaceType['x-ms-enum']['modelAsString'] = false;
    $.NamespaceProperties.properties.createdAt['readOnly'] = false;
    $.NamespaceProperties.properties.critical['readOnly'] = false;
    $.NamespaceProperties.properties.enabled['readOnly'] = false;
    $.NamespaceProperties.properties.name['readOnly'] = false;
    $.NamespaceProperties.properties.region['readOnly'] = false;
    $.NamespaceProperties.properties.serviceBusEndpoint['readOnly'] = false;
    $.NamespaceProperties.properties.updatedAt['readOnly'] = false;
    $.NamespaceProperties.properties.subscriptionId['readOnly'] = false;
```
