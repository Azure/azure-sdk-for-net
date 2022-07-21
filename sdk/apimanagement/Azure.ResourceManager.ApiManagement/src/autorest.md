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

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/diagnostics/{diagnosticId}: ApiDiagnostic
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}: ApiIssue
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/policies/{policyId}: ApiPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tags/{tagId}: ApiTag

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ApiVersionSetId': 'arm-id'
  'SourceApiId': 'arm-id'
  'PrivateIPAddresses': 'ip-address'
  'PublicIPAddresses': 'ip-address'

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

override-operation-name:
  NetworkStatus_ListByLocation: GetNetworkStatusByLocation
  TenantAccessGit_RegeneratePrimaryKey: RegeneratePrimaryKeyForGit
  TenantAccessGit_RegenerateSecondaryKey: RegenerateSecondaryKeyForGit
  ApiProduct_ListByApis: GetApiProducts
  ApiManagementServiceSkus_ListAvailableServiceSkus: GetAvailableApiManagementServiceSkus
  NetworkStatus_ListByService: GetNetworkStatuses
  OutboundNetworkDependenciesEndpoints_ListByService: GetOutboundNetworkDependenciesEndpoints
  PolicyDescription_ListByService: GetPolicyDescriptions
  PortalSettings_ListByService: GetPortalSettings
  QuotaByCounterKeys_ListByService: GetQuotaByCounterKeys
  Region_ListByService: GetRegions
  TenantConfiguration_GetSyncState: GetTenantConfigurationSyncState
  TagResource_ListByService: GetTagResources

prepend-rp-prefix:
- ResourceSkuCapacity
- ResourceSkuCapacityScaleType

rename-mapping:
  OpenidConnectProviderContract: ApiManagementOpenIdConnectProvider
  OpenidConnectProviderUpdateContract: OpenIdConnectProviderUpdateContract
  VirtualNetworkConfiguration.vnetid: VnetId
  AccessInformationContract: TenantAccess
  AccessInformationContract.properties.enabled: IsEnabled
  AccessInformationContract.properties.id: AccessInfoType
  AccessIdName: AccessName
  ApiContract: Api
  ApiCollection: ApiListResult
  NetworkStatusContractByLocation: NetworkStatusContractWithLocation
  ApiManagementServiceResource: ApiManagementService
  ApiReleaseContract: ApiRelease
  OperationContract: ApiOperation
  SchemaContract: ApiSchema
  TagDescriptionContract: ApiTagDescription
  ApiManagementServiceBackupRestoreParameters: ApiManagementServiceBackupRestoreContent
  OperationResultContract: GitOperationResultContractData
  ConfigurationIdName: ConfigurationName
  DeployConfigurationParameters: DeployConfigurationContent
  ApiVersionSetContract: ApiVersionSet
  AuthorizationServerContract:  ApiManagementAuthorizationServer
  BackendContract: ApiManagementBackend
  CacheContract: ApiManagementCache
  CertificateContract: ApiManagementCertificate
  ContentTypeContract: ApiManagementContentType
  EmailTemplateContract: ApiManagementEmailTemplate
  GatewayContract: ApiManagementGateway
  GlobalSchemaContract: ApiManagementGlobalSchema
  GroupContract: ApiManagementGroup
  IdentityProviderContract: ApiManagementIdentityProvider
  LoggerContract: ApiManagementLogger
  NamedValueContract: ApiManagementNamedValue
  NotificationContract: ApiManagementNotification
  PolicyDescriptionContract: PolicyDescriptionContractData
  PortalDelegationSettings: ApiManagementPortalDelegationSettings

directive:
  - remove-operation: 'ApiManagementOperations_List'
  - from: definitions.json
    where: $.definitions
    transform: >
      $.AuthorizationServerContractBaseProperties.properties.bearerTokenSendingMethods.items['x-ms-enum']['name'] = 'BearerTokenSendingMethodMode';
      $.BearerTokenSendingMethodsContract['x-ms-enum']['name'] = 'BearerTokenSendingMethodContract';
      $.ApiEntityBaseContract.properties.subscriptionRequired['x-ms-client-name'] = 'IsSubscriptionRequired';
  - from: apimdeployment.json
    where: $.definitions
    transform: >
      $.Operation['x-ms-client-name'] = 'RestApiOperation';
  - from: apimanagement.json
    where: $.parameters
    transform: >
      $.OpenIdConnectIdParameter['x-ms-client-name'] = 'OpenId';

```
