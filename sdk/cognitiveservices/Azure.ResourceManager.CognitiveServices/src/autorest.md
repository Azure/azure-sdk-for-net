# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: CognitiveServices
namespace: Azure.ResourceManager.CognitiveServices
require: https://github.com/Azure/azure-rest-api-specs/blob/33f813731c763f05425666a9950fb0698df5f79a/specification/cognitiveservices/resource-manager/readme.md
#tag: package-2025-06-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

list-exception:
  - /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/locations/{location}/resourceGroups/{resourceGroupName}/deletedAccounts/{accountName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/locations/{location}/resourceGroups/{resourceGroupName}/deletedAccounts/{accountName}: CognitiveServicesDeletedAccount
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}: CognitiveServicesAccount
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/commitmentPlans/{commitmentPlanName}: CommitmentPlan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/commitmentPlans/{commitmentPlanName}: CognitiveServicesCommitmentPlan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/capabilityHosts/{capabilityHostName}: CognitiveServicesCapabilityHost
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}: CognitiveServicesProjectCapabilityHost
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/connections/{connectionName}: CognitiveServicesConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/connections/{connectionName}: CognitiveServicesProjectConnection

rename-mapping:
  CheckSkuAvailabilityParameter.type: ResourceType
  CheckDomainAvailabilityParameter.type: ResourceType
  AccountProperties.dynamicThrottlingEnabled: EnableDynamicThrottling
  SkuAvailability.skuAvailable: IsSkuAvailable
  ApiProperties.statisticsEnabled: EnableStatistics
  ThrottlingRule.dynamicThrottlingEnabled: IsDynamicThrottlingEnabled
  ApiKeys: ServiceAccountApiKeys
  ApiProperties: ServiceAccountApiProperties
  CallRateLimit: ServiceAccountCallRateLimit
  CheckDomainAvailabilityParameter: CognitiveServicesDomainAvailabilityContent
  CheckSkuAvailabilityParameter: CognitiveServicesSkuAvailabilityContent
  DomainAvailability: CognitiveServicesDomainAvailabilityList
  Deployment: CognitiveServicesAccountDeployment
  DeploymentListResult: CognitiveServicesAccountDeploymentListResult
  DeploymentModel: CognitiveServicesAccountDeploymentModel
  DeploymentProperties: CognitiveServicesAccountDeploymentProperties
  DeploymentProvisioningState: CognitiveServicesAccountDeploymentProvisioningState
  DeploymentScaleSettings: CognitiveServicesAccountDeploymentScaleSettings
  DeploymentScaleType: CognitiveServicesAccountDeploymentScaleType
  Encryption: ServiceAccountEncryptionProperties
  HostingModel: ServiceAccountHostingModel
  KeyName: ServiceAccountKeyName
  KeySource: ServiceAccountEncryptionKeySource
  MetricName: ServiceAccountUsageMetricName
  ModelDeprecationInfo: ServiceAccountModelDeprecationInfo
  ProvisioningState: ServiceAccountProvisioningState
  PublicNetworkAccess: ServiceAccountPublicNetworkAccess
  QuotaLimit: ServiceAccountQuotaLimit
  QuotaUsageStatus: ServiceAccountQuotaUsageStatus
  RegenerateKeyParameters: RegenerateServiceAccountKeyParameters
  RequestMatchPattern: ServiceAccountThrottlingMatchPattern
  ResourceSku: AvailableCognitiveServicesSku
  ResourceSkuListResult: AvailableCognitiveServicesSkuResult
  ResourceSkuRestrictionInfo: CognitiveServicesSkuRestrictionInfo
  ResourceSkuRestrictions: CognitiveServicesSkuRestrictions
  ResourceSkuRestrictionsReasonCode: CognitiveServicesSkuRestrictionReasonCode
  ResourceSkuRestrictionsType: CognitiveServicesSkuRestrictionsType
  SkuAvailability: CognitiveServicesSkuAvailabilityList
  SkuAvailabilityListResult: CognitiveServicesSkuAvailabilityListResult
  ThrottlingRule: ServiceAccountThrottlingRule
  UnitType: ServiceAccountUsageUnitType
  Usage: ServiceAccountUsage
  UsageListResult: ServiceAccountUsageListResult
  UserOwnedStorage: ServiceAccountUserOwnedStorage
  RegionSetting: CognitiveServicesRegionSetting
  RoutingMethods: CognitiveServicesRoutingMethod
  PatchResourceTags: CognitiveServicesPatchResourceTags
  MultiRegionSettings: CognitiveServicesMultiRegionSettings
  CommitmentPlanProperties.commitmentPlanGuid: -|uuid
  CommitmentPlanAssociation.commitmentPlanId: -|arm-id
  KeyVaultProperties: CognitiveServicesKeyVaultProperties
  ModelListResult: CognitiveServicesModelListResult
  Model: CognitiveServicesModel
  ModelSku: CognitiveServicesModelSku
  CapacityConfig: CognitiveServicesCapacityConfig
  CalculateModelCapacityParameter: CalculateModelCapacityContent
  RaiBlocklistItemBulkRequest: RaiBlocklistItemBulkContent
  SkuResource: CognitiveServicesResourceSku
  DeploymentProperties.dynamicThrottlingEnabled: IsDynamicThrottlingEnabled
  RaiMonitorConfig.adxStorageResourceId: -|arm-id
  UserOwnedAmlWorkspace.resourceId: -|arm-id
  NetworkSecurityPerimeter.perimeterGuid: -|uuid
  ByPassSelection: TrustedServicesByPassSelection
  ContentLevel: RaiPolicyContentLevel
  ProvisioningIssue: NetworkSecurityPerimeterProvisioningIssue
  ProvisioningIssueProperties: NetworkSecurityPerimeterProvisioningIssueProperties
  CapabilityHost: CognitiveServicesCapabilityHost
  CapabilityHostProperties: CognitiveServicesCapabilityHostProperties
  ConnectionPropertiesV2BasicResource: CognitiveServicesConnection
  ConnectionUpdateContent: CognitiveServicesConnectionPatch
  ConnectionPropertiesV2: CognitiveServicesConnectionProperties
  Project: CognitiveServicesProject
  ProjectProperties: CognitiveServicesProjectProperties
  AADAuthTypeConnectionProperties: AadAuthTypeConnectionProperties
  ConnectionAccessKey: CognitiveServicesConnectionAccessKey
  ConnectionCategory: CognitiveServicesConnectionCategory
  ConnectionGroup: CognitiveServicesConnectionGroup
  ConnectionManagedIdentity: CognitiveServicesConnectionManagedIdentity
  ConnectionOAuth2: CognitiveServicesConnectionOAuth2
  ConnectionServicePrincipal: CognitiveServicesConnectionServicePrincipal
  ConnectionUsernamePassword: CognitiveServicesConnectionUsernamePassword
  NetworkInjections: AIFoundryNetworkInjection
  PATAuthTypeConnectionProperties: PatAuthTypeConnectionProperties
  ScenarioType: AIFoundryNetworkInjectionScenarioType

prepend-rp-prefix:
  - Account
  - AccountListResult
  - AccountModel
  - AccountModelListResult
  - AccountProperties
  - AccountSku
  - AccountSkuListResult
  - EncryptionScope
  - EncryptionScopeProperties
  - IpRule
  - NetworkRuleAction
  - NetworkRuleSet
  - NetworkSecurityPerimeter
  - ResourceBase
  - SkuCapability
  - SkuChangeInfo
  - VirtualNetworkRule

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'aadClientId': 'uuid'
  'aadTenantId': 'uuid'
  'identityClientId': 'uuid'

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
  Db: DB
  SqlMi: SqlMI

directive:
  - from: cognitiveservices.json
    where: $.paths
    transform: >
      delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}"]["put"]
  - from: cognitiveservices.json
    where: $.definitions
    transform: >
      $.CheckDomainAvailabilityParameter.properties.type['x-ms-format'] = 'resource-type';
      $.CheckSkuAvailabilityParameter.properties.type['x-ms-format'] =  'resource-type';
      $.PrivateEndpointConnection.properties.properties['x-ms-client-flatten'] = true;
      $.ModelSku.properties.rateLimits['readOnly'] = true;
      delete $.AccountProperties.properties.internalId;
  # TODO, these configs will be replaced by the new rename-mapping
  - from: cognitiveservices.json
    where: $.definitions
    transform: >
      $.ModelDeprecationInfo.properties.fineTune['format'] = 'date-time';
      $.ModelDeprecationInfo.properties.fineTune['x-ms-client-name'] = 'FineTuneOn';
      $.ModelDeprecationInfo.properties.inference['format'] = 'date-time';
      $.ModelDeprecationInfo.properties.inference['x-ms-client-name'] = 'InferenceOn';
      $.AccountProperties.properties.dateCreated['format'] = 'date-time';
      $.AccountProperties.properties.dateCreated['x-ms-client-name'] = 'CreatedOn';
      $.AccountProperties.properties.deletionDate['format'] = 'date-time';
      $.AccountProperties.properties.deletionDate['x-ms-client-name'] = 'DeletedOn';
      $.CommitmentPeriod.properties.startDate['format'] = 'date-time';
      $.CommitmentPeriod.properties.startDate['x-ms-client-name'] = 'StartOn';
      $.CommitmentPeriod.properties.endDate['format'] = 'date-time';
      $.CommitmentPeriod.properties.endDate['x-ms-client-name'] = 'EndOn';
      $.UserOwnedStorage.properties.resourceId['x-ms-format'] = 'arm-id';
      $.AccountSku.properties.resourceType['x-ms-format'] = 'resource-type';
      $.SkuChangeInfo.properties.lastChangeDate['format'] = 'date-time';
      $.SkuChangeInfo.properties.lastChangeDate['x-ms-client-name'] = 'lastChangedOn';
      $.VirtualNetworkRule.properties.id['x-ms-format'] = 'arm-id';
      $.ApiProperties.properties.qnaAzureSearchEndpointId['x-ms-format'] = 'arm-id';
```
