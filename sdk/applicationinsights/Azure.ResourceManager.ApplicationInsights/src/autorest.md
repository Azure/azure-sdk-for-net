# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ApplicationInsights
namespace: Azure.ResourceManager.ApplicationInsights
require: https://github.com/Azure/azure-rest-api-specs/blob/d4f3374fc56a25acc5442a7efe5aee11413fdfe2/specification/applicationinsights/resource-manager/readme.md
tag: package-2024-04-25-only
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - LiveToken_Get
  - WorkItemConfigurations_Create
  - WorkItemConfigurations_UpdateItem
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

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
  API: Api
  SSL: Ssl

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.insights/components/{resourceName}/linkedStorageAccounts/{storageType}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/workbooks/{resourceName}/revisions/{revisionId}: ApplicationInsightsWorkbookRevision
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/workbooks/{resourceName}: ApplicationInsightsWorkbook

rename-mapping:
  WebTest.properties.Frequency: FrequencyInSeconds
  WebTest.properties.Timeout: TimeoutInSeconds
  ApplicationInsightsComponent.properties.WorkspaceResourceId: -|arm-id
  ApplicationInsightsComponent.properties.DisableIpMasking: IsDisableIpMasking
  ApplicationInsightsComponent.properties.ImmediatePurgeDataOn30Days: IsImmediatePurgeDataOn30Days
  ApplicationInsightsComponent.properties.DisableLocalAuth: IsDisableLocalAuth
  ApplicationInsightsComponent.properties.ForceCustomerStorageForProfiler: IsForceCustomerStorageForProfiler
  MyWorkbook.properties.tags: Tags
  Workbook.properties.tags: Tags
  Workbook.properties.sourceId: -|arm-id
  WebTest.properties.Enabled: IsEnabled
  Workbook.properties.timeModified: ModifiedOn|date-time
  WorkbookTemplate.properties.localized: LocalizedGalleries
  ApplicationInsightsComponentDataVolumeCap.StopSendNotificationWhenHitThreshold: IsStopSendNotificationWhenHitThreshold
  ApplicationInsightsComponentDataVolumeCap.StopSendNotificationWhenHitCap: IsStopSendNotificationWhenHitCap
  ApplicationInsightsComponentProactiveDetectionConfiguration.Enabled: IsEnabled
  ApplicationInsightsComponentProactiveDetectionConfiguration.LastUpdatedTime: LastUpdatedOn|date-time
  WorkItemCreateConfiguration.ValidateOnly: IsValidateOnly
  WebTest.properties.RetryEnabled: IsRetryEnabled
  WebTestPropertiesValidationRules.SSLCheck: CheckSsl
  ItemScopePath.myanalyticsItems: MyAnalyticsItems
  MyWorkbookResource: MyWorkbookResourceContent
  PrivateLinkScopedResource: PrivateLinkScopedResourceReference
  PrivateLinkScopedResource.ResourceId: -|arm-id
  TagsResource: WebTestComponentTag
  Annotation.EventTime: EventOccurredOn
  ItemScope: ComponentItemScope
  ItemType: ComponentItemType
  ApplicationInsightsComponentAPIKey.createdDate: CreatedOn|date-time
  ApplicationInsightsComponentExportConfiguration.DestinationAccountId: -|arm-id
  ApplicationInsightsComponentExportConfiguration.LastUserUpdate: LastUserUpdatedOn|date-time
  ApplicationInsightsComponentExportConfiguration.NotificationQueueEnabled: IsNotificationQueueEnabled
  ApplicationInsightsComponentExportConfiguration.LastSuccessTime: LastSucceededOn|date-time
  ApplicationInsightsComponentExportConfiguration.LastGapTime: LastGappedOn|date-time
  ApplicationInsightsComponentExportRequest: ApplicationInsightsComponentExportContent
  ApplicationInsightsComponentExportRequest.NotificationQueueEnabled: IsNotificationQueueEnabled
  ApplicationInsightsComponentExportRequest.DestinationAccountId: -|arm-id
  FavoriteType: ComponentFavoriteType
  ApplicationInsightsComponentFavorite.TimeModified: ModifiedOn|date-time
  ApplicationInsightsComponentFeature.ResouceId: ResourceId|arm-id
  ApplicationInsightsComponentFeatureCapabilities.SupportExportData: IsExportDataSupported
  ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions.SupportsEmailNotifications: IsEmailNotificationsSupported
  ApplicationInsightsComponentQuotaStatus.ExpirationTime: ExpireOn|date-time
  CategoryType: WorkbookCategoryType
  CategoryType.TSG: Tsg
  ComponentPurgeBody: ComponentPurgeContent
  ComponentPurgeBodyFilters: ComponentPurgeFilters
  ComponentPurgeResponse: ComponentPurgeResult
  ComponentPurgeStatusResponse: ComponentPurgeStatusResult
  FlowType: ComponentFlowType
  HeaderField: WebTestRequestHeaderField
  IngestionMode: ComponentIngestionMode
  ItemScopePath: AnalyticsItemScopePath
  ItemTypeParameter: AnalyticsItemTypeContent
  LiveTokenResponse: LiveTokenResult
  PurgeState: ComponentPurgeState
  RequestSource: ComponentRequestSource
  WebTestKind.multistep: MultiStep
  WebTestPropertiesConfiguration: WebTestConfiguration
  WebTestPropertiesRequest: WebTestRequest
  WebTestPropertiesValidationRules: WebTestValidationRules
  WebTestPropertiesValidationRulesContentValidation: WebTestContentValidation
  WorkbookTemplateGallery.type: WorkbookType
  ApplicationInsightsComponentAnalyticsItem.TimeCreated: CreatedOn|date-time
  ApplicationInsightsComponentAnalyticsItem.TimeModified: ModifiedOn|date-time

prepend-rp-prefix:
  - Annotation
  - WebTest
  - Workbook
  - WorkbookTemplate
  - APIKeyRequest
  - ApplicationType
  - PublicNetworkAccessType

override-operation-name:
  ComponentQuotaStatus_Get: GetComponentQuotaStatus
  AnalyticsItems_Put: AddOrUpdateAnalyticsItem
  APIKeys_Create: CreateApiKey
  APIKeys_Delete: DeleteApiKey
  APIKeys_Get: GetApiKey
  APIKeys_List: GetApiKeys

directive:
  - from: webTestLocations_API.json
    where: $.definitions
    transform: >
      $["ApplicationInsightsWebTestLocationsListResult"] = {
        "description": "Describes the list of web test locations available to an Application Insights Component.",
        "type": "array",
        "items": {
          "$ref": "#/definitions/ApplicationInsightsComponentWebTestLocation"
        },
        "x-ms-identifiers": [
          "DisplayName"
        ]
      }
    reason: workaround incorrect definition in swagger
  - where-operation: webTestLocations_List
    debug: true
    transform: >
      delete $["x-ms-pageable"]
  - from: workbookTemplates_API.json
    where: $.definitions
    transform: >
      $["WorkbookTemplatesListResult"] = {
        "description": "WorkbookTemplate list result.",
        "type": "array",
        "items": {
          "$ref": "#/definitions/WorkbookTemplate"
        }
      }
    reason: workaround incorrect definition in swagger
  - where-operation: WorkbookTemplates_ListByResourceGroup
    transform: >
      delete $["x-ms-pageable"]
```
