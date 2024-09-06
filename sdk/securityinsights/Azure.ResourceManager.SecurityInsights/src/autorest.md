# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SecurityInsights
namespace: Azure.ResourceManager.SecurityInsights
require: https://github.com/Azure/azure-rest-api-specs/blob/2d973fccf9f28681a481e9760fa12b2334216e21/specification/securityinsights/resource-manager/readme.md
tag: package-preview-2024-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

mgmt-debug: 
  show-serialized-names: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}: SecurityInsightsThreatIntelligenceIndicator
  # Added these relation resource due to new added type in 2024-01-01-preview version
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}/relations/{relationName}: SecurityInsightsBookmarkRelation
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/entities/{entityId}/relations/{relationName}: SecurityInsightsEntityRelation
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/hunts/{huntId}/relations/{huntRelationId}: SecurityInsightsHuntRelation
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/relations/{relationName}: SecurityInsightsIncidentRelation

partial-resources:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}: OperationalInsightsWorkspace

rename-mapping:
  Bookmark.properties.updated: UpdatedOn
  EnrichmentDomainWhois.expires: ExpireOn
  EnrichmentDomainWhois.updated: UpdatedOn
  HuntingBookmark: SecurityInsightsHuntingBookmark
  HuntingBookmark.properties.updated: UpdatedOn
  HuntingBookmark.properties.created: CreatedOn
  Watchlist.properties.updated: UpdatedOn
  WatchlistItem.properties.updated: UpdatedOn
  AlertRule: SecurityInsightsAlertRule
  ThreatIntelligenceInformation: SecurityInsightsThreatIntelligenceIndicatorBase
  ThreatIntelligenceIndicatorModel: SecurityInsightsThreatIntelligenceIndicatorData
  ThreatIntelligenceIndicatorModel.properties.lastUpdatedTimeUtc: LastUpdatedOn|date-time
  ThreatIntelligenceIndicatorModel.properties.created: CreatedOn|date-time
  ThreatIntelligenceIndicatorModel.properties.externalLastUpdatedTimeUtc: ExternalLastUpdatedOn|date-time
  ThreatIntelligenceIndicatorModel.properties.validFrom: -|date-time
  ThreatIntelligenceIndicatorModel.properties.validUntil: -|date-time
  ThreatIntelligenceIndicatorModel.properties.defanged: IsDefanged
  ThreatIntelligenceIndicatorModel.properties.revoked: IsRevoked
  ActionResponse: SecurityInsightsAlertRuleAction
  AlertRuleTemplate: SecurityInsightsAlertRuleTemplate
  AutomationRule: SecurityInsightsAutomationRule
  AutomationRule.properties.lastModifiedTimeUtc: LastModifiedOn
  AutomationRule.properties.createdTimeUtc: CreatedOn
  ClientInfo: SecurityInsightsClientInfo
  UserInfo: SecurityInsightsUserInfo
  Bookmark: SecurityInsightsBookmark
  Bookmark.properties.created: CreatedOn
  IncidentInfo: SecurityInsightsBookmarkIncidentInfo
  IncidentInfo.incidentId: -|uuid
  DataConnector: SecurityInsightsDataConnector
  Incident: SecurityInsightsIncident
  Incident.properties.additionalData: AdditionalInfo
  Incident.properties.createdTimeUtc: CreatedOn
  Incident.properties.firstActivityTimeUtc: FirstActivityOn
  Incident.properties.lastActivityTimeUtc: LastActivityOn
  Incident.properties.lastModifiedTimeUtc: LastModifiedOn
  Incident.properties.relatedAnalyticRuleIds: -|arm-id
  IncidentAdditionalData: SecurityInsightsIncidentAdditionalInfo
  IncidentClassification: SecurityInsightsIncidentClassification
  IncidentClassificationReason: SecurityInsightsIncidentClassificationReason
  IncidentLabel: SecurityInsightsIncidentLabel
  IncidentLabelType: SecurityInsightsIncidentLabelType
  IncidentOwnerInfo: SecurityInsightsIncidentOwnerInfo
  IncidentSeverity: SecurityInsightsIncidentSeverity
  IncidentStatus: SecurityInsightsIncidentStatus
  IncidentComment: SecurityInsightsIncidentComment
  IncidentComment.properties.createdTimeUtc: CreatedOn
  IncidentComment.properties.lastModifiedTimeUtc: LastModifiedOn
  SecurityAlert: SecurityInsightsAlert
  SecurityAlert.properties.endTimeUtc: EndOn
  SecurityAlert.properties.startTimeUtc: StartOn
  SecurityAlert.properties.timeGenerated: AlertGeneratedOn
  IncidentEntitiesResponse: SecurityInsightsIncidentEntitiesResult
  Relation: SecurityInsightsIncidentRelation
  Relation.properties.relatedResourceId: -|arm-id
  Relation.properties.relatedResourceType: -|resource-type
  SentinelOnboardingState: SecurityInsightsSentinelOnboardingState
  SentinelOnboardingState.properties.customerManagedKey: IsCustomerManagedKeySet
  Watchlist: SecurityInsightsWatchlist
  Watchlist.properties.created: CreatedOn
  Watchlist.properties.watchlistId: -|uuid
  WatchlistItem: SecurityInsightsWatchlistItem
  WatchlistItem.properties.created: CreatedOn
  AADDataConnector: SecurityInsightsAadDataConnector
  AatpDataConnector: SecurityInsightsAatpDataConnector
  DataTypeState: SecurityInsightsDataTypeConnectionState
  AccountEntity: SecurityInsightsAccountEntity
  AlertDetail: SecurityInsightsAlertDetail
  AlertDetailsOverride: SecurityInsightsAlertDetailsOverride
  AlertSeverity: SecurityInsightsAlertSeverity
  AlertStatus: SecurityInsightsAlertStatus
  AnomalySecurityMLAnalyticsSettings.properties.enabled: IsEnabled
  AnomalySecurityMLAnalyticsSettings.properties.lastModifiedUtc: LastModifiedOn
  SettingsStatus: AnomalySecurityMLAnalyticsSettingsStatus
  AttackTactic: SecurityInsightsAttackTactic
  ASCDataConnector: SecurityInsightsAscDataConnector
  AutomationRuleAction: SecurityInsightsAutomationRuleAction
  AutomationRuleCondition: SecurityInsightsAutomationRuleCondition
  IncidentPropertiesAction: SecurityInsightsIncidentActionConfiguration
  AutomationRulePropertyConditionSupportedProperty.AccountUPNSuffix: AccountUpnSuffix
  AutomationRulePropertyConditionSupportedProperty.MailboxUPN: MailboxUpn
  AutomationRulePropertyConditionSupportedProperty.Url: Uri
  PlaybookActionProperties: AutomationRuleRunPlaybookActionProperties
  PlaybookActionProperties.logicAppResourceId: -|arm-id
  AutomationRuleTriggeringLogic: SecurityInsightsAutomationRuleTriggeringLogic
  AutomationRuleTriggeringLogic.expirationTimeUtc: ExpireOn
  AwsCloudTrailDataConnector: SecurityInsightsAwsCloudTrailDataConnector
  AzureResourceEntity: SecurityInsightsAzureResourceEntity
  CloudApplicationEntity: SecurityInsightsCloudApplicationEntity
  ConfidenceLevel: SecurityInsightsAlertConfidenceLevel
  ConfidenceScoreStatus: SecurityInsightsAlertConfidenceScoreStatus
  DnsEntity: SecurityInsightsDnsEntity
  Entity: SecurityInsightsEntity
  EntityKindEnum: SecurityInsightsEntityKind
  EntityKindEnum.Url: Uri
  EntityMapping: SecurityInsightsAlertRuleEntityMapping
  EntityMappingType: SecurityInsightsAlertRuleEntityMappingType
  EntityMappingType.URL: Uri
  FieldMapping: SecurityInsightsFieldMapping
  FileEntity: SecurityInsightsFileEntity
  FileHashAlgorithm: SecurityInsightsFileHashAlgorithm
  FileHashAlgorithm.SHA1: Sha1
  FileHashAlgorithm.SHA256: Sha256
  FileHashAlgorithm.SHA256AC: Sha256AC
  FileHashEntity: SecurityInsightsFileHashEntity
  FusionAlertRule: SecurityInsightsFusionAlertRule
  FusionAlertRule.properties.enabled: IsEnabled
  FusionAlertRule.properties.lastModifiedUtc: LastModifiedOn
  FusionAlertRuleTemplate: SecurityInsightsFusionAlertRuleTemplate
  FusionAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  FusionAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  TemplateStatus: SecurityInsightsAlertRuleTemplateStatus
  GeoLocation: SecurityInsightsIPEntityGeoLocation
  GroupingConfiguration: SecurityInsightsGroupingConfiguration
  GroupingConfiguration.enabled: IsEnabled
  GroupingConfiguration.reopenClosedIncident: IsClosedIncidentReopened
  MatchingMethod: SecurityInsightsGroupingMatchingMethod
  HostEntity: SecurityInsightsHostEntity
  HostEntity.properties.azureID: -|arm-id
  OSFamily: SecurityInsightsHostOSFamily
  OSFamily.IOS: Ios
  IncidentConfiguration: SecurityInsightsIncidentConfiguration
  IncidentConfiguration.createIncident: IsIncidentCreated
  IncidentEntitiesResultsMetadata: SecurityInsightsIncidentEntitiesMetadata
  OwnerType:  SecurityInsightsIncidentOwnerType
  IoTDeviceEntity: SecurityInsightsIotDeviceEntity
  ThreatIntelligence: SecurityInsightsThreatIntelligence
  IpEntity: SecurityInsightsIPEntity
  IpEntity.properties.address: -|ip-address
  KillChainIntent: SecurityInsightsKillChainIntent
  MailboxEntity: SecurityInsightsMailboxEntity
  MailClusterEntity: SecurityInsightsMailClusterEntity
  MailMessageEntity: SecurityInsightsMailMessageEntity
  MailMessageEntity.properties.urls: Uris
  MailMessageEntity.properties.senderIP: -|ip-address
  DeliveryAction: SecurityInsightsMailMessageDeliveryAction
  DeliveryLocation: SecurityInsightsMailMessageDeliveryLocation
  MalwareEntity: SecurityInsightsMalwareEntity
  AlertsDataTypeOfDataConnector: SecurityInsightsAlertsDataTypeOfDataConnector
  MicrosoftSecurityIncidentCreationAlertRule.properties.enabled: IsEnabled
  MicrosoftSecurityIncidentCreationAlertRule.properties.lastModifiedUtc: LastModifiedOn
  MicrosoftSecurityIncidentCreationAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  MicrosoftSecurityIncidentCreationAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  OfficeDataConnector: SecurityInsightsOfficeDataConnector
  OfficeDataConnectorDataTypes: SecurityInsightsOfficeDataConnectorDataTypes
  ProcessEntity: SecurityInsightsProcessEntity
  ProcessEntity.properties.creationTimeUtc: CreatedOn
  ElevationToken: SecurityInsightsProcessElevationToken
  PropertyArrayChangedConditionProperties: SecurityInsightsPropertyArrayChangedConditionProperties
  PropertyChangedConditionProperties: SecurityInsightsPropertyChangedConditionProperties
  PropertyConditionProperties: SecurityInsightsPropertyConditionProperties
  RegistryHive: SecurityInsightsRegistryHive
  RegistryKeyEntity: SecurityInsightsRegistryKeyEntity
  RegistryValueEntity: SecurityInsightsRegistryValueEntity
  RegistryValueKind: SecurityInsightsRegistryValueKind
  ScheduledAlertRule: SecurityInsightsScheduledAlertRule
  ScheduledAlertRule.properties.enabled: IsEnabled
  ScheduledAlertRule.properties.lastModifiedUtc: LastModifiedOn
  ScheduledAlertRule.properties.suppressionEnabled: IsSuppressionEnabled
  TriggerOperator: SecurityInsightsAlertRuleTriggerOperator
  SecurityAlertPropertiesConfidenceReasonsItem: SecurityInsightsAlertConfidenceReason
  SecurityGroupEntity: SecurityInsightsGroupEntity
  SubmissionMailEntity: SecurityInsightsSubmissionMailEntity
  SubmissionMailEntity.properties.senderIp: -|ip-address
  SubmissionMailEntity.properties.submissionDate: SubmitOn
  SubmissionMailEntity.properties.timestamp: MessageReceivedOn
  ThreatIntelligenceFilteringCriteria.minValidUntil: -|date-time
  ThreatIntelligenceFilteringCriteria.maxValidUntil: -|date-time
  ThreatIntelligenceFilteringCriteria.includeDisabled: IsIncludeDisabled
  ThreatIntelligenceGranularMarkingModel: ThreatIntelligenceGranularMarkingEntity
  ThreatIntelligenceMetric.lastUpdatedTimeUtc: LastUpdatedOn
  TIDataConnector: SecurityInsightsTIDataConnector
  TIDataConnector.properties.tipLookbackPeriod: TipLookbackOn
  UrlEntity: SecurityInsightsUriEntity
  BookmarkExpandResponse: BookmarkExpandResult
  EntityExpandResponse: EntityExpandResult
  PullRequest: PullRequestInfo
  ReevaluateResponse: ReevaluateResult
  CustomizableConnectorDefinition: CustomizableConnectorDefinitionData
  TiTaxiiDataConnectorDataTypesTaxiiClient: TiTaxiiDataConnectorDataTypes
  Hunt: SecurityInsightsHunt
  HuntList: SecurityInsightsHuntList
  HuntComment: SecurityInsightsHuntComment
  HuntRelation: SecurityInsightsHuntRelation
  HuntRelation.properties.relatedResourceId: -|arm-id
  HuntOwner: SecurityInsightsHuntOwner
  Job: WorkspaceManagerAssignmentJob
  BillingStatistic: SecurityInsightsBillingStatistic
  DataConnectorDefinition: SecurityInsightsDataConnectorDefinition
  EntityQuery: SecurityInsightsEntityQuery
  EntityQueryTemplate: SecurityInsightsEntityQueryTemplate
  Recommendation: SecurityInsightsRecommendation
  ActivityCustomEntityQuery.properties.enabled: IsEnabled
  ActivityEntityQuery.properties.enabled: IsEnabled
  Settings: SecurityInsightsSettings
  SettingList: SecurityInsightsSettingList
  Anomalies: SecurityInsightsSettingAnomaliesKind
  AnomalyTimelineItem.azureResourceId: -|arm-id
  AnomalyTimelineItem.timeGenerated: GeneratedOn
  Availability: ConnectorAvailability
  AvailabilityStatus: ConnectorAvailabilityStatus
  BookmarkTimelineItem.azureResourceId: -|arm-id
  CcpResponseConfig.convertChildPropertiesToArray: IsConvertChildPropertiesToArray
  Connective: ClauseConnective
  Customs: CustomsPermission
  CustomsPermission: CustomsPermissionProperties
  Deployment: SourceControlDeployment
  DeploymentFetchStatus: SourceControlDeploymentFetchStatus
  DeploymentInfo: SourceControlDeploymentInfo
  DeploymentResult: SourceControlDeploymentResult
  DeploymentState: SourceControlDeploymentState
  EntityGetInsightsParameters.addDefaultExtendedTimeRange: IsDefaultExtendedTimeRangeAdded
  EntityManualTriggerRequestBody: EntityManualTriggerRequestContent
  EntityManualTriggerRequestBody.incidentArmId: -|arm-id
  EntityManualTriggerRequestBody.logicAppsResourceId: -|arm-id
  Error: PublicationFailedError
  Flag: MetadataFlag
  FusionSourceSettings.enabled: IsEnabled
  FusionSourceSubTypeSetting.enabled: IsEnabled
  FusionSubTypeSeverityFiltersItem.enabled: IsEnabled
  Identity: TiObjectKindIdentity
  Indicator: TiObjectKindIndicator
  AttackPattern: TiObjectKindAttackPattern
  Relationship: TiObjectKindRelationship
  ThreatActor: TiObjectKindThreatActor
  MLBehaviorAnalyticsAlertRule.properties.enabled: IsEnabled
  Mode: WorkspaceManagerConfigurationMode
  Operator: ConditionClauseOperator
  Permissions: ConnectorPermissions
  # Not working, check if we still need this.
  # ProductTemplateModelCollectionGetAllOptions.count: ReturnOnlyObjectCount
  # PackageModelCollectionGetAllOptions 
  # TemplateModelCollectionGetAllOptions 
  # Confirm if this a guid or not
  # OracleAuthModel.tenantId
  Repo: SourceControlRepo
  Repository: SourceControlRepository
  RequiredPermissions.action: IsCustomAction
  RequiredPermissions.delete: IsDeleteAction
  RequiredPermissions.read: IsReadAction
  RequiredPermissions.write: IsWriteAction
  SourceControl.properties.id: SourceControlId | uuid
  AssignmentItem.resourceId: -|arm-id
  EnrichmentDomainBody: EnrichmentDomainContent
  DataConnectorConnectBody: DataConnectorConnectContent
  InsightQueryItemPropertiesTableQueryColumnsDefinitionsItem.supportDeepLink: IsDeepLinkSupported
  JobItem.resourceId: -|arm-id
  NrtAlertRule.properties.enabled: IsEnabled
  NrtAlertRule.properties.suppressionEnabled: IsSuppressionEnabled
  ResourceProviderRequiredPermissions.action: IsCustomAction
  ResourceProviderRequiredPermissions.delete: IsDeleteAction
  ResourceProviderRequiredPermissions.read: IsReadAction
  ResourceProviderRequiredPermissions.write: IsWriteAction
  SecurityAlertTimelineItem.azureResourceId: -|arm-id
  ServicePrincipal: SourceControlServicePrincipal
  State: RecommendationState
  ThreatIntelligenceAlertRule.properties.enabled: IsEnabled
  Ueba: UebaSettings
  Version: SourceControlVersion
  Warning: ResponseWarning
  Webhook: SourceControlWebhook
  Webhook.rotateWebhookSecret: IsWebhookSecretRotated
  FileImport: SecurityInsightsFileImport
  FileImport.properties.createdTimeUTC: CreatedOn
  FileImport.properties.filesValidUntilTimeUTC: FilesValidUntil
  FileImport.properties.importValidUntilTimeUTC: ImportValidUntil
  IncidentTask: SecurityInsightsIncidentTask
  IncidentTask.properties.createdTimeUtc: CreatedOn
  IncidentTask.properties.lastModifiedTimeUtc: LastModifiedOn
  MetadataModel: SecurityInsightsMetadataModel
  OfficeConsent: SecurityInsightsOfficeConsent
  Recommendation.properties.creationTimeUtc: CreatedOn
  Recommendation.properties.lastEvaluatedTimeUtc: LastEvaluatedOn
  Recommendation.properties.lastModifiedTimeUtc: LastModifiedOn
  TriggeredAnalyticsRuleRun.properties.executionTimeUtc: ExecuteOn
  ActivityCustomEntityQuery.properties.createdTimeUtc: CreatedOn
  ActivityCustomEntityQuery.properties.lastModifiedTimeUtc: LastModifiedOn
  ActivityEntityQuery.properties.createdTimeUtc: CreatedOn
  ActivityEntityQuery.properties.lastModifiedTimeUtc: LastModifiedOn
  ActivityTimelineItem.bucketStartTimeUTC: BucketStartOn
  ActivityTimelineItem.bucketEndTimeUTC: BucketEndOn
  ActivityTimelineItem.firstActivityTimeUTC: FirstActivityOn
  ActivityTimelineItem.lastActivityTimeUTC: LastActivityOn
  AnalyticsRuleRunTrigger.properties.executionTimeUtc: ExecuteOn
  AnomalyTimelineItem.endTimeUtc: EndOn
  AnomalyTimelineItem.startTimeUtc: StartOn
  BookmarkTimelineItem.endTimeUtc: EndOn
  BookmarkTimelineItem.startTimeUtc: StartOn
  CustomizableConnectorDefinition.properties.lastModifiedUtc: LastModifiedOn
  CustomizableConnectorDefinition.properties.createdTimeUtc: CreatedOn
  MLBehaviorAnalyticsAlertRule.properties.lastModifiedUtc: LastModifiedOn
  MLBehaviorAnalyticsAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  MLBehaviorAnalyticsAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  NrtAlertRule.properties.lastModifiedUtc: LastModifiedOn
  NrtAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  NrtAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  ReevaluateResponse.lastEvaluatedTimeUtc: LastEvaluatedOn
  SecurityAlertTimelineItem.endTimeUtc: EndOn
  SecurityAlertTimelineItem.startTimeUtc: StartOn
  SecurityAlertTimelineItem.timeGenerated: GeneratedOn
  ThreatIntelligenceAlertRule.properties.lastModifiedUtc: LastModifiedOn
  ThreatIntelligenceAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  ThreatIntelligenceAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  TIObject.properties.firstIngestedTimeUtc: FirstIngestedOn
  TIObject.properties.lastIngestedTimeUtc: LastIngestedOn
  TIObject.properties.lastUpdatedDateTimeUtc: LastUpdatedOn
  # Added property renaming due to api compat check with property breaking chang to dictionary type in 2024-01-01-preview version
  WatchlistItem.properties.itemsKeyValue: ItemsKeyValueDictionary
  WatchlistItem.properties.entityMapping: EntityMappingDictionary
  # Added property renaming due to api compat check with property breaking chang to string type in 2024-01-01-preview version
  Watchlist.properties.source: SourceString

override-operation-name:
  DomainWhois_Get: GetDomainWhoisInformation
  Incidents_ListEntities: GetEntitiesResult
  ThreatIntelligenceIndicatorMetrics_List: GetAllThreatIntelligenceIndicatorMetrics
  ThreatIntelligenceIndicator_QueryIndicators: QueryThreatIntelligenceIndicators

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
  Orderby: OrderBy|orderBy
  AAD: Aad
  IoT: Iot
#  Nt: NT

suppress-abstract-base-class:
- SecurityInsightsAlertRuleData
- SecurityInsightsAlertRuleTemplateData
- SecurityInsightsDataConnectorData
- SecurityInsightsThreatIntelligenceIndicatorBaseData
- SecurityMLAnalyticsSettingData
- SecurityInsightsEntityData

directive:
  - rename-operation:
      from: ThreatIntelligenceIndicator_Get
      to: ThreatIntelligenceIndicators_Get
  - rename-operation:
      from: ThreatIntelligenceIndicator_Create
      to: ThreatIntelligenceIndicators_Update
  - rename-operation:
      from: ThreatIntelligenceIndicator_Delete
      to: ThreatIntelligenceIndicators_Delete
  - rename-operation:
      from: ThreatIntelligenceIndicator_AppendTags
      to: ThreatIntelligenceIndicators_AppendTags
  - remove-operation: ThreatIntelligenceIndicator_ReplaceTags
  - remove-operation: ThreatIntelligenceIndicator_CreateIndicator
  - rename-operation:
      from: Bookmark_Expand
      to: Bookmarks_Expand
  - from: dataConnectors.json
    where: $.definitions
    transform: >
      $.DataConnectorWithAlertsProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.MTPDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.AwsCloudTrailDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.MSTIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.AwsS3DataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.Dynamics365DataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.Office365ProjectDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.OfficePowerBIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.TIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.TiTaxiiDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.CodelessUiConnectorConfigProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.MicrosoftPurviewInformationProtectionDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
  - from: AlertRules.json
    where: $.definitions
    transform: >
      $.ActionPropertiesBase.properties.logicAppResourceId['x-ms-format'] = 'arm-id';
  # Reslove `Duplicate Schema` issue for 2024-01-01-preview version
  - from: EnrichmentWithWorkspace.json
    where: $.definitions
    transform: >
      $.EnrichmentIpGeodata['x-ms-client-name'] = 'WorkspaceEnrichmentIpGeodata';
  - from: ThreatIntelligenceQuery.json
    where: $.definitions
    transform: >
      $.Query['x-ms-client-name'] = 'ThreatIntelligenceQuery';
      $.UserInfo['x-ms-client-name'] = 'ThreatIntelligenceUserInfo';   
  - from: ThreatIntelligenceCount.json
    where: $.definitions
    transform: >
      $.Query['x-ms-client-name'] = 'ThreatIntelligenceCountQuery';
  # Add this because the parameter order is mismatch in 2024-01-01-preview version
  - from: ThreatIntelligence.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators"].get
    transform: >
      $["parameters"] = [
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ResourceGroupNameParameter"
          },
          {
            "$ref": "../../../common/2.0/types.json#/parameters/WorkspaceName"
          },
          {
            "$ref": "../../../common/2.0/types.json#/parameters/ODataFilter"
          },
          {
            "$ref": "../../../common/2.0/types.json#/parameters/ODataTop"
          },
          {
            "$ref": "../../../common/2.0/types.json#/parameters/ODataSkipToken"
          },
          {
            "$ref": "../../../common/2.0/types.json#/parameters/ODataOrderBy"
          }
        ];
  # Add this because lack of x-ms-enum value
  - from: EntityQueries.json
    where: $.parameters
    transform: >
      $.EntityQueryKind["x-ms-enum"] = {
        "modelAsString": true,
        "name": "EntityQueryKind",
        "values": [
          {
            "value": "Expansion"
          },
          {
            "value": "Activity"
          }
        ]};
  # Add this due to the naming requirement and actually there are two status in this service
  - from: Hunts.json
    where: $.definitions.HuntProperties.properties.status
    transform: >
      $['x-ms-enum'].name = 'HuntStatus';
  - from: WorkspaceManagerAssignments.json
    where: $.definitions.jobItem.properties.status
    transform: >
      $['x-ms-enum'].name = 'PublicationStatus';
```
