# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Elastic
namespace: Azure.ResourceManager.Elastic
require: https://github.com/Azure/azure-rest-api-specs/blob/3c1ce8207350922f820d20e04547cc4785c758d3/specification/elastic/resource-manager/readme.md
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

#mgmt-debug:
#  show-serialized-names: true

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

rename-mapping:
  ElasticMonitorResource: ElasticMonitor
  MonitoringTagRules: ElasticTagRule
  MonitoringTagRulesProperties: ElasticTagRuleProperties
  ElasticVersionListProperties.version: AvailableVersion
  OpenAIIntegrationRPModel: ElasticOpenAIIntegration
  OpenAIIntegrationProperties: ElasticOpenAIIntegrationProperties
  BillingInfoResponse: ElasticBillingInfoResult
  ConnectedPartnerResourceProperties.azureResourceId: -|arm-id
  ConnectedPartnerResourcesListFormat: ConnectedPartnerResourceInfo
  DeploymentInfoResponse: ElasticDeploymentInfoResult
  ElasticOrganizationToAzureSubscriptionMappingResponse: ElasticOrganizationToAzureSubscriptionMappingResult
  ElasticOrganizationToAzureSubscriptionMappingResponseProperties: ElasticOrganizationToAzureSubscriptionMappingProperties
  ElasticProperties: ElasticCloudProperties
  ElasticTrafficFilter.includeByDefault: DoesIncludeByDefault
  ElasticTrafficFilterResponse: ElasticTrafficFilterListResult
  ElasticVersionListFormat: ElasticVersion
  ElasticVersionListProperties: ElasticVersionProperties
  ExternalUserInfo: ElasticExternalUserContent
  ExternalUserCreationResponse: ElasticExternalUserCreationResult
  ExternalUserCreationResponse.created: IsCreated
  FilteringTag: ElasticFilteringTag
  LiftrResourceCategories: ElasticLiftrResourceCategories
  LogRules: ElasticLogRules
  LogRules.sendAadLogs: ShouldAadLogsBeSent
  LogRules.sendSubscriptionLogs: ShouldSubscriptionLogsBeSent
  LogRules.sendActivityLogs: ShouldActivityLogsBeSent
  MarketplaceSaaSInfo.subscribed: IsSubscribed
  MonitoredResource: MonitoredResourceInfo
  MonitoredResource.id: -|arm-id
  MonitorProperties.generateApiKey: IsApiKeyGenerated
  OpenAIIntegrationStatusResponse: ElasticOpenAIIntegrationStatusResult
  OpenAIIntegrationStatusResponseProperties: ElasticOpenAIIntegrationStatusProperties
  OperationName: VMCollectionUpdateOperationName
  ResourceSku: ElasticSku
  SendingLogs: SendingLogsStatus
  TagAction: FilteringTagAction
  Type: ElasticFilterType
  UpgradableVersionsList: UpgradableVersionListResult
  UserApiKeyResponse: ElasticUserApiKeyResult
  UserApiKeyResponseProperties: ElasticUserApiKeyProperties
  UserInfo: ElasticUserInfo
  UserEmailId: ElasticUserEmailId
  VMCollectionUpdate: VmCollectionContent
  VMCollectionUpdate.vmResourceId: -|arm-id
  VMIngestionDetailsResponse: VmIngestionDetailsResult
  VMResources: ElasticVMResourceInfo
  VMResources.vmResourceId: -|arm-id

prepend-rp-prefix:
  - MonitoringStatus
  - MonitorProperties
  - CompanyInfo
  - PlanDetails
  - ProvisioningState

override-operation-name:
  VMHost_List: GetVmHosts
  VMIngestion_Details: GetVmIngestionDetails
  VMCollection_Update: UpdateVmCollection
  UpgradableVersions_Details: GetUpgradableVersionDetails
  listAssociatedTrafficFilters_List: GetAssociatedTrafficFilters
  createAndAssociateIPFilter_Create: CreateAndAssociateIPFilter
  createAndAssociatePLFilter_Create: CreateAndAssociatePrivateLinkFilter
  AssociateTrafficFilter_Associate: AssociateTrafficFilter
  DetachAndDeleteTrafficFilter_Delete: DetachAndDeleteTrafficFilter
  DetachTrafficFilter_Update: DetachTrafficFilter
  Organizations_GetApiKey: GetApiKey
  Organizations_GetElasticToAzureSubscriptionMapping: GetElasticToAzureSubscriptionMapping

```
