# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: CostManagement
namespace: Azure.ResourceManager.CostManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/f61e11971b66e35d893c182e01cef00243e37e01/specification/cost-management/resource-manager/Microsoft.CostManagement/CostManagement/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - BenefitRecommendations_List
  - Forecast_Usage
  - Dimensions_List
  - Query_Usage
  - ScheduledActions_CheckNameAvailabilityByScope
skip-csproj: true
modelerfour:
  flatten-payloads: false
#   lenient-model-deduplication: true
use-model-reader-writer: true

# mgmt-debug:
#   show-serialized-names: true

list-exception:
- /providers/Microsoft.CostManagement/views/{viewName}
- /{scope}/providers/Microsoft.CostManagement/costDetailsOperationResults/{operationId}
- /{scope}/providers/Microsoft.CostManagement/operationResults/{operationId}
- /{scope}/providers/Microsoft.CostManagement/operationStatus/{operationId}
- /providers/Microsoft.CostManagement/scheduledActions/{name}
- /providers/Microsoft.CostManagement/mgmtviews/{viewName}

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
  ETag: ETag|eTag

request-path-to-resource-name:
  /providers/Microsoft.CostManagement/views/{viewName}: TenantsCostManagementViews
  /{scope}/providers/Microsoft.CostManagement/views/{viewName}: CostManagementViews
  /{scope}/providers/Microsoft.CostManagement/exports/{exportName}: CostManagementExport

override-operation-name:
  ScheduledActions_CheckNameAvailabilityByScope: CheckCostManagementNameAvailabilityByScopeScheduledAction
  ScheduledActions_CheckNameAvailability: CheckCostManagementNameAvailabilityByScheduledAction
  PriceSheet_DownloadByInvoice: DownloadPriceSheet
  GenerateBenefitUtilizationSummariesReport_GenerateBySavingsPlanOrderId: GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope
  GenerateBenefitUtilizationSummariesReport_GenerateByReservationId: GenerateBenefitUtilizationSummariesReportReservationScope
  GenerateBenefitUtilizationSummariesReport_GenerateByReservationOrderId: GenerateBenefitUtilizationSummariesReportReservationOrderScope
  GenerateBenefitUtilizationSummariesReport_GenerateByBillingProfile: GenerateBenefitUtilizationSummariesReportBillingProfileScope
  GenerateBenefitUtilizationSummariesReport_GenerateByBillingAccount: GenerateBenefitUtilizationSummariesReportBillingAccountScope
  GenerateBenefitUtilizationSummariesReport_GenerateBySavingsPlanId: GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope
  PriceSheet_DownloadByBillingProfile: DownloadPriceSheetByBillingProfile

prepend-rp-prefix:
  - Alert
  - View
  - Export
  - AlertCategory
  - AlertOperator
  - AlertSource
  - AlertsResult
  - AlertStatus
  - AlertType
  - Dimension
  - DimensionsListResult

rename-mapping:
  FormatType: ExportFormatType
  StatusType: ExportScheduleStatusType
  RecurrenceType: ExportScheduleRecurrenceType
  ReportType: ViewReportType
  PivotType: ViewPivotType
  MetricType: ViewMetricType
  KpiType: ViewKpiType
  KpiProperties: ViewKpiProperties
  ChartType: ViewChartType
  PivotProperties: ViewPivotProperties
  ExecutionType: ExportRunExecutionType
  ExecutionStatus: ExportRunExecutionStatus
  ErrorDetails: ExportRunErrorDetails
  BenefitKind: BillingAccountBenefitKind
  DaysOfWeek: ScheduledActionDaysOfWeek
  WeeksOfMonth: ScheduledActionWeeksOfMonth
  FileFormat: ScheduledActionFileFormat
  Term: BenefitRecommendationPeriodTerm
  Scope: BenefitRecommendationScope
  Grain: BenefitRecommendationUsageGrain
  OperatorType: ComparisonOperatorType
  DismissAlertPayload.properties.closeTime: CloseOn|datetime
  DismissAlertPayload.properties.statusModificationTime: StatusModifiedOn|datetime
  Alert.properties.modificationTime: ModifiedOn|datetime
  Alert.properties.creationTime: CreatedOn|datetime
  Alert.properties.statusModificationTime: StatusModifiedOn|datetime
  View.properties.scope: -|arm-id
  ScheduledAction.properties.scope: -|arm-id
  ScheduledAction.properties.viewId: -|arm-id
  ExportDeliveryDestination.resourceId: -|arm-id
  KpiProperties.id: -|arm-id
  Dimension.properties.filterEnabled: IsFilterEnabled
  Dimension.properties.groupingEnabled: IsGroupingEnabled
  KpiProperties.enabled: IsEnabled
  CheckNameAvailabilityRequest: CostManagementNameAvailabilityContent
  CheckNameAvailabilityResponse: CostManagementNameAvailabilityResult
  CheckNameAvailabilityReason: CostManagementUnavailabilityReason
  BenefitUtilizationSummariesRequest: BenefitUtilizationSummariesContent
  GrainParameter: GrainContent
  AlertPropertiesDefinition.type: AlertType

suppress-abstract-base-class:
- BenefitUtilizationSummary

directive:
  # [Error][Linked: https://github.com/Azure/autorest.csharp/issues/3288] Found more than 1 candidate for XX
  - remove-operation: Views_List
  - remove-operation: ScheduledActions_List
  # [Build Error][LRO issue] Return 'Response' instead of 'Response<Foo>'
  - remove-operation: GenerateCostDetailsReport_CreateOperation
  - remove-operation: GenerateCostDetailsReport_GetOperationResults
  - remove-operation: GenerateDetailedCostReport_CreateOperation
  - remove-operation: GenerateDetailedCostReportOperationResults_Get
  - remove-operation: GenerateDetailedCostReportOperationStatus_Get
  - remove-operation: Operations_List
#   - remove-operation: CostAllocationRules_CheckNameAvailability

  # Could not set ResourceTypeSegment for request path /{scope}
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/scheduledActions'].get
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/scheduledActions/{name}'].get
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/scheduledActions/{name}'].put
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/scheduledActions/{name}'].delete
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/scheduledActions/{name}/execute'].post
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/checkNameAvailability'].post
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/views'].get
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/views/{viewName}'].get
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/views/{viewName}'].put
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/views/{viewName}'].delete
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/settings'].get
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/settings/{type}'].get
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/settings/{type}'].put
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  - from: openapi.json
    where: $.paths['/{scope}/providers/Microsoft.CostManagement/settings/{type}'].delete
    transform: >
        $['parameters'][1]['x-ms-skip-url-encoding'] = true;
  # Dup schema
  - from: openapi.json
    where: $.definitions.ErrorResponse
    transform: $['x-ms-client-name'] = 'OperationErrorResponse';
  - from: openapi.json
    where: $.definitions
    transform: delete $.SettingType;
```
