# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: AppComplianceAutomation
namespace: Azure.ResourceManager.AppComplianceAutomation
require: https://github.com/Azure/azure-rest-api-specs/blob/f28f14c35918513bd3c3cf9f30d31ee192602525/specification/appcomplianceautomation/resource-manager/readme.md
#tag: package-2024-06
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
    - Report_CreateOrUpdate
    - Report_SyncCertRecord
    - Evidence_CreateOrUpdate
    - Snapshot_Download
    - ScopingConfiguration_CreateOrUpdate
    - Webhook_CreateOrUpdate
skip-csproj: true
modelerfour:
  flatten-payloads: false
  flatten-models: false
use-model-reader-writer: true
#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  EvidenceResource: AppComplianceReportEvidence
  EvidenceProperties: AppComplianceReportEvidenceProperties
  ReportResource: AppComplianceReport
  ScopingConfigurationResource: AppComplianceReportScopingConfiguration
  ScopingConfigurationProperties: AppComplianceReportScopingConfigurationProperties
  SnapshotResource: AppComplianceReportSnapshot
  SnapshotProperties: AppComplianceReportSnapshotProperties
  WebhookResource: AppComplianceReportWebhook
  WebhookProperties: AppComplianceReportWebhookProperties
  Category: AppComplianceCategory
  CategoryStatus: AppComplianceCategoryStatus
  CheckNameAvailabilityReason: AppComplianceReportNameUnavailabilityReason
  CheckNameAvailabilityRequest: AppComplianceReportNameAvailabilityContent
  CheckNameAvailabilityResponse: AppComplianceReportNameAvailabilityResult
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityRequest.type: -|resource-type
  ComplianceReportItem: AppComplianceReportItem
  ComplianceReportItem.resourceId: -|arm-id
  ComplianceReportItem.resourceType: -|resource-type
  ComplianceReportItem.resourceStatusChangeDate: ResourceStatusChangedOn
  ComplianceResult: AppComplianceResult
  ContentType: WebhookContentType
  Control: AppComplianceControl
  Control.controlDescriptionHyperLink: -|uri
  ControlFamily: AppComplianceControlFamily
  ControlStatus: AppComplianceControlStatus
  DeliveryStatus: WebhookDeliveryStatus
  DownloadResponse: AppComplianceDownloadResult
  DownloadResponseComplianceDetailedPdfReport: AppComplianceDetailedPdfReport
  DownloadResponseCompliancePdfReport: AppCompliancePdfReport
  DownloadType: AppComplianceDownloadType
  EvidenceFileDownloadResponse: EvidenceFileDownloadResult
  EvidenceFileDownloadResponseEvidenceFile: EvidenceFileUrlInfo
  EvidenceType: AppComplianceReportEvidenceType
  GetCollectionCountRequest: ReportCollectionGetCountContent
  GetCollectionCountResponse: ReportCollectionGetCountResult
  GetOverviewStatusRequest: AppComplianceGetOverviewStatusContent
  GetOverviewStatusResponse: AppComplianceGetOverviewStatusResult
  InputType: ScopingQuestionInputType
  ListInUseStorageAccountsRequest: ReportListInUseStorageAccountsContent
  ListInUseStorageAccountsResponse: ReportListInUseStorageAccountsResult
  NotificationEvent: WebhookNotificationEvent
  OnboardRequest: AppComplianceOnboardContent
  OnboardResponse: AppComplianceOnboardResult
  OverviewStatus: ReportOverviewStatus
  ProvisioningState: AppComplianceProvisioningState
  Recommendation: RecommendationDetails
  ReportPatchProperties: AppComplianceReportPatchProperties
  ReportProperties: AppComplianceReportProperties
  ReportStatus: AppComplianceReportStatus
  ResourceItem: ReportResourceItem
  ResourceItem.resourceId: -|arm-id
  ResourceItem.resourceType: -|resource-type
  ResourceMetadata: ReportResourceMetadata
  ResourceMetadata.resourceId: -|arm-id
  ResourceMetadata.resourceType: -|resource-type
  ResourceOrigin: ReportResourceOrigin
  ResourceOrigin.AWS: Aws
  ResourceOrigin.GCP: Gcp
  ResourceStatus: ReportResourceStatus
  Responsibility: CustomerResponsibility
  ResponsibilityEnvironment.AWS: Aws
  ResponsibilityEnvironment.GCP: Gcp
  ResponsibilityResource: ResponsibilityResourceItem
  ResponsibilityResource.resourceId: -|arm-id
  ResponsibilityResource.resourceType: -|resource-type
  ResponsibilityResource.resourceStatusChangeDate: ResourceStatusChangedOn
  Result: ReportResult
  Rule: QuestionRuleItem
  StatusItem: OverviewStatusItem
  StorageInfo: ReportStorageInfo
  SyncCertRecordResponse: SyncCertRecordResult
  TriggerEvaluationResponse: TriggerEvaluationResult
  QuickAssessment.resourceId: -|arm-id
  QuickAssessment.timestamp: CreatedOn
  SnapshotDownloadRequest: SnapshotDownloadRequestContent
  EvidenceFileDownloadRequest: EvidenceFileDownloadRequestContent

override-operation-name:
  ProviderActions_CheckNameAvailability: CheckAppComplianceReportNameAvailability
  Report_NestedResourceCheckNameAvailability: CheckAppComplianceReportNestedResourceNameAvailability

format-by-name-rules:
  'tenantId': 'uuid'
  '*TenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
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

```
