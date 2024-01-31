# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: NotificationHubs
namespace: Azure.ResourceManager.NotificationHubs
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/notificationhubs/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#   show-serialized-names: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}: NotificationHubNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NotificationHubs/namespaces/{namespaceName}/notificationHubs/{notificationHubName}/AuthorizationRules/{authorizationRuleName}: NotificationHubAuthorizationRule

rename-mapping:
  NamespaceResource.properties.serviceBusEndpoint: -|uri
  NamespaceCreateOrUpdateParameters.properties.serviceBusEndpoint: -|uri
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
  NamespaceCreateOrUpdateParameters.properties.enabled: IsEnabled
  NamespaceCreateOrUpdateParameters.properties.critical: IsCritical
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
  PolicykeyResource: NotificationHubPolicyKey
  ResourceListKeys: NotificationHubResourceKeys
  Sku: NotificationHubSku
  SkuName: NotificationHubSkuName
  SharedAccessAuthorizationRuleCreateOrUpdateParameters: SharedAccessAuthorizationRuleCreateOrUpdateContent
  ApnsCredential.properties.thumbprint: ThumbprintString
  MpnsCredential.properties.thumbprint: ThumbprintString

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
```
