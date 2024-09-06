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
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

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
  AADDataConnector: SecurityInsightsAadDataConnector
  AatpDataConnector: SecurityInsightsAatpDataConnector
  AccountEntity: SecurityInsightsAccountEntity
  ActionResponse: SecurityInsightsAlertRuleAction
  ActivityCustomEntityQuery.properties.createdTimeUtc: CreatedOn
  ActivityCustomEntityQuery.properties.enabled: IsEnabled
  ActivityCustomEntityQuery.properties.lastModifiedTimeUtc: LastModifiedOn
  ActivityEntityQuery.properties.createdTimeUtc: CreatedOn
  ActivityEntityQuery.properties.enabled: IsEnabled
  ActivityEntityQuery.properties.lastModifiedTimeUtc: LastModifiedOn
  ActivityEntityQueryTemplatePropertiesQueryDefinitions: ActivityEntityQueryDefinition
  ActivityTimelineItem.bucketEndTimeUTC: BucketEndOn
  ActivityTimelineItem.bucketStartTimeUTC: BucketStartOn
  ActivityTimelineItem.firstActivityTimeUTC: FirstActivityOn
  ActivityTimelineItem.lastActivityTimeUTC: LastActivityOn
  AlertDetail: SecurityInsightsAlertDetail
  AlertDetailsOverride: SecurityInsightsAlertDetailsOverride
  AlertProperty: SecurityInsightsAlertProperty
  AlertPropertyMapping: SecurityInsightsAlertPropertyMapping
  AlertRule: SecurityInsightsAlertRule
  AlertRuleTemplate: SecurityInsightsAlertRuleTemplate
  AlertsDataTypeOfDataConnector: SecurityInsightsAlertsDataTypeOfDataConnector
  AlertSeverity: SecurityInsightsAlertSeverity
  AlertStatus: SecurityInsightsAlertStatus
  AnalyticsRuleRunTrigger.properties.executionTimeUtc: ExecuteOn
  Anomalies: SecurityInsightsSettingAnomaliesKind
  AnomalySecurityMLAnalyticsSettings.properties.enabled: IsEnabled
  AnomalySecurityMLAnalyticsSettings.properties.lastModifiedUtc: LastModifiedOn
  AnomalyTimelineItem.azureResourceId: -|arm-id
  AnomalyTimelineItem.endTimeUtc: EndOn
  AnomalyTimelineItem.startTimeUtc: StartOn
  AnomalyTimelineItem.timeGenerated: GeneratedOn
  ApiKeyAuthModel:  SecurityInsightsApiKeyAuthModel
  ASCCheckRequirements: AscCheckRequirements
  ASCDataConnector: SecurityInsightsAscDataConnector
  AssignmentItem.resourceId: -|arm-id
  AttackPattern: TiObjectKindAttackPattern
  AttackTactic: SecurityInsightsAttackTactic
  AutomationRule.properties.createdTimeUtc: CreatedOn
  AutomationRule.properties.lastModifiedTimeUtc: LastModifiedOn
  AutomationRule: SecurityInsightsAutomationRule
  AutomationRuleAction: SecurityInsightsAutomationRuleAction
  AutomationRuleCondition: SecurityInsightsAutomationRuleCondition
  AutomationRulePropertyConditionSupportedProperty.AccountUPNSuffix: AccountUpnSuffix
  AutomationRulePropertyConditionSupportedProperty.MailboxUPN: MailboxUpn
  AutomationRulePropertyConditionSupportedProperty.Url: Uri
  AutomationRuleTriggeringLogic.expirationTimeUtc: ExpireOn
  AutomationRuleTriggeringLogic: SecurityInsightsAutomationRuleTriggeringLogic
  Availability: ConnectorAvailability
  AvailabilityStatus: ConnectorAvailabilityStatus
  AwsCloudTrailDataConnector: SecurityInsightsAwsCloudTrailDataConnector
  AzureResourceEntity: SecurityInsightsAzureResourceEntity
  BillingStatistic: SecurityInsightsBillingStatistic
  Bookmark.properties.created: CreatedOn
  Bookmark.properties.updated: UpdatedOn
  Bookmark: SecurityInsightsBookmark
  BookmarkExpandResponse: BookmarkExpandResult
  BookmarkTimelineItem.azureResourceId: -|arm-id
  BookmarkTimelineItem.endTimeUtc: EndOn
  BookmarkTimelineItem.startTimeUtc: StartOn
  CcpResponseConfig.convertChildPropertiesToArray: IsConvertChildPropertiesToArray
  ClientInfo: SecurityInsightsClientInfo
  CloudApplicationEntity: SecurityInsightsCloudApplicationEntity
  ConfidenceLevel: SecurityInsightsAlertConfidenceLevel
  ConfidenceScoreStatus: SecurityInsightsAlertConfidenceScoreStatus
  Connective: ClauseConnective
  CustomizableConnectorDefinition.properties.createdTimeUtc: CreatedOn
  CustomizableConnectorDefinition.properties.lastModifiedUtc: LastModifiedOn
  CustomizableConnectorDefinition: CustomizableConnectorDefinitionData
  Customs: CustomsPermission
  CustomsPermission: CustomsPermissionProperties
  DataConnector: SecurityInsightsDataConnector
  DataConnectorConnectBody: DataConnectorConnectContent
  DataConnectorDefinition: SecurityInsightsDataConnectorDefinition
  DataTypeState: SecurityInsightsDataTypeConnectionState
  DeliveryAction: SecurityInsightsMailMessageDeliveryAction
  DeliveryLocation: SecurityInsightsMailMessageDeliveryLocation
  Deployment: SourceControlDeployment
  DeploymentFetchStatus: SourceControlDeploymentFetchStatus
  DeploymentInfo: SourceControlDeploymentInfo
  DeploymentResult: SourceControlDeploymentResult
  DeploymentState: SourceControlDeploymentState
  DnsEntity: SecurityInsightsDnsEntity
  ElevationToken: SecurityInsightsProcessElevationToken
  EnrichmentDomainBody: EnrichmentDomainContent
  EnrichmentDomainWhois.expires: ExpireOn
  EnrichmentDomainWhois.updated: UpdatedOn
  Entity: SecurityInsightsEntity
  EntityExpandResponse: EntityExpandResult
  EntityGetInsightsParameters.addDefaultExtendedTimeRange: IsDefaultExtendedTimeRangeAdded
  EntityKindEnum.Url: Uri
  EntityKindEnum: SecurityInsightsEntityKind
  EntityManualTriggerRequestBody.incidentArmId: -|arm-id
  EntityManualTriggerRequestBody.logicAppsResourceId: -|arm-id
  EntityManualTriggerRequestBody: EntityManualTriggerRequestContent
  EntityMapping: SecurityInsightsAlertRuleEntityMapping
  EntityMappingType.URL: Uri
  EntityMappingType: SecurityInsightsAlertRuleEntityMappingType
  EntityQuery: SecurityInsightsEntityQuery
  EntityQueryTemplate: SecurityInsightsEntityQueryTemplate
  Error: PublicationFailedError
  FieldMapping: SecurityInsightsFieldMapping
  FileEntity: SecurityInsightsFileEntity
  FileHashAlgorithm.SHA1: Sha1
  FileHashAlgorithm.SHA256: Sha256
  FileHashAlgorithm.SHA256AC: Sha256AC
  FileHashAlgorithm: SecurityInsightsFileHashAlgorithm
  FileHashEntity: SecurityInsightsFileHashEntity
  FileImport.properties.createdTimeUTC: CreatedOn
  FileImport.properties.filesValidUntilTimeUTC: FilesValidUntil
  FileImport.properties.importValidUntilTimeUTC: ImportValidUntil
  FileImport: SecurityInsightsFileImport
  Flag: MetadataFlag
  FusionAlertRule.properties.enabled: IsEnabled
  FusionAlertRule.properties.lastModifiedUtc: LastModifiedOn
  FusionAlertRule: SecurityInsightsFusionAlertRule
  FusionAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  FusionAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  FusionAlertRuleTemplate: SecurityInsightsFusionAlertRuleTemplate
  FusionSourceSettings.enabled: IsEnabled
  FusionSourceSubTypeSetting.enabled: IsEnabled
  FusionSubTypeSeverityFiltersItem.enabled: IsEnabled
  GeoLocation: SecurityInsightsIPEntityGeoLocation
  GroupingConfiguration.enabled: IsEnabled
  GroupingConfiguration.reopenClosedIncident: IsClosedIncidentReopened
  GroupingConfiguration: SecurityInsightsGroupingConfiguration
  HostEntity.properties.azureID: -|arm-id
  HostEntity: SecurityInsightsHostEntity
  Hunt: SecurityInsightsHunt
  HuntComment: SecurityInsightsHuntComment
  HuntingBookmark.properties.created: CreatedOn
  HuntingBookmark.properties.updated: UpdatedOn
  HuntingBookmark: SecurityInsightsHuntingBookmark
  HuntList: SecurityInsightsHuntList
  HuntOwner: SecurityInsightsHuntOwner
  HuntRelation.properties.relatedResourceId: -|arm-id
  HuntRelation: SecurityInsightsHuntRelation
  Identity: TiObjectKindIdentity
  Incident.properties.additionalData: AdditionalInfo
  Incident.properties.createdTimeUtc: CreatedOn
  Incident.properties.firstActivityTimeUtc: FirstActivityOn
  Incident.properties.lastActivityTimeUtc: LastActivityOn
  Incident.properties.lastModifiedTimeUtc: LastModifiedOn
  Incident.properties.relatedAnalyticRuleIds: -|arm-id
  Incident: SecurityInsightsIncident
  IncidentAdditionalData: SecurityInsightsIncidentAdditionalInfo
  IncidentClassification: SecurityInsightsIncidentClassification
  IncidentClassificationReason: SecurityInsightsIncidentClassificationReason
  IncidentComment.properties.createdTimeUtc: CreatedOn
  IncidentComment.properties.lastModifiedTimeUtc: LastModifiedOn
  IncidentComment: SecurityInsightsIncidentComment
  IncidentConfiguration.createIncident: IsIncidentCreated
  IncidentConfiguration: SecurityInsightsIncidentConfiguration
  IncidentEntitiesResponse: SecurityInsightsIncidentEntitiesResult
  IncidentEntitiesResultsMetadata: SecurityInsightsIncidentEntitiesMetadata
  IncidentInfo.incidentId: -|uuid
  IncidentInfo: SecurityInsightsBookmarkIncidentInfo
  IncidentLabel: SecurityInsightsIncidentLabel
  IncidentLabelType: SecurityInsightsIncidentLabelType
  IncidentOwnerInfo: SecurityInsightsIncidentOwnerInfo
  IncidentPropertiesAction: SecurityInsightsIncidentActionConfiguration
  IncidentSeverity: SecurityInsightsIncidentSeverity
  IncidentStatus: SecurityInsightsIncidentStatus
  IncidentTask.properties.createdTimeUtc: CreatedOn
  IncidentTask.properties.lastModifiedTimeUtc: LastModifiedOn
  IncidentTask: SecurityInsightsIncidentTask
  Indicator: TiObjectKindIndicator
  InsightQueryItemPropertiesTableQueryColumnsDefinitionsItem.supportDeepLink: IsDeepLinkSupported
  IoTDeviceEntity: SecurityInsightsIotDeviceEntity
  IpEntity.properties.address: -|ip-address
  IpEntity: SecurityInsightsIPEntity
  Job: WorkspaceManagerAssignmentJob
  JobItem.resourceId: -|arm-id
  KillChainIntent: SecurityInsightsKillChainIntent
  MailboxEntity: SecurityInsightsMailboxEntity
  MailClusterEntity: SecurityInsightsMailClusterEntity
  MailMessageEntity.properties.senderIP: -|ip-address
  MailMessageEntity.properties.urls: Uris
  MailMessageEntity: SecurityInsightsMailMessageEntity
  MalwareEntity: SecurityInsightsMalwareEntity
  MatchingMethod: SecurityInsightsGroupingMatchingMethod
  MetadataModel: SecurityInsightsMetadata
  MicrosoftSecurityIncidentCreationAlertRule.properties.enabled: IsEnabled
  MicrosoftSecurityIncidentCreationAlertRule.properties.lastModifiedUtc: LastModifiedOn
  MicrosoftSecurityIncidentCreationAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  MicrosoftSecurityIncidentCreationAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  MLBehaviorAnalyticsAlertRule.properties.enabled: IsEnabled
  MLBehaviorAnalyticsAlertRule.properties.lastModifiedUtc: LastModifiedOn
  MLBehaviorAnalyticsAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  MLBehaviorAnalyticsAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  Mode: WorkspaceManagerConfigurationMode
  NrtAlertRule.properties.enabled: IsEnabled
  NrtAlertRule.properties.lastModifiedUtc: LastModifiedOn
  NrtAlertRule.properties.suppressionEnabled: IsSuppressionEnabled
  NrtAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  NrtAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  OfficeConsent: SecurityInsightsOfficeConsent
  OfficeDataConnector: SecurityInsightsOfficeDataConnector
  OfficeDataConnectorDataTypes: SecurityInsightsOfficeDataConnectorDataTypes
  Operator: ConditionClauseOperator
  OSFamily.IOS: Ios
  OSFamily: SecurityInsightsHostOSFamily
  OwnerType:  SecurityInsightsIncidentOwnerType
  PackageModel: SecurityInsightsPackage
  Permissions: ConnectorPermissions
  PlaybookActionProperties.logicAppResourceId: -|arm-id
  PlaybookActionProperties: AutomationRuleRunPlaybookActionProperties
  ProcessEntity.properties.creationTimeUtc: CreatedOn
  ProcessEntity: SecurityInsightsProcessEntity
  ProductPackageModel: SecurityInsightsProductPackage
  ProductTemplateModel: SecurityInsightsProductTemplate
  PropertyArrayChangedConditionProperties: SecurityInsightsPropertyArrayChangedConditionProperties
  PropertyChangedConditionProperties: SecurityInsightsPropertyChangedConditionProperties
  PropertyConditionProperties: SecurityInsightsPropertyConditionProperties
  PullRequest: PullRequestInfo
  Recommendation.properties.creationTimeUtc: CreatedOn
  Recommendation.properties.lastEvaluatedTimeUtc: LastEvaluatedOn
  Recommendation.properties.lastModifiedTimeUtc: LastModifiedOn
  Recommendation: SecurityInsightsRecommendation
  ReevaluateResponse.lastEvaluatedTimeUtc: LastEvaluatedOn
  ReevaluateResponse: ReevaluateResult
  RegistryHive: SecurityInsightsRegistryHive
  RegistryKeyEntity: SecurityInsightsRegistryKeyEntity
  RegistryValueEntity: SecurityInsightsRegistryValueEntity
  RegistryValueKind: SecurityInsightsRegistryValueKind
  Relation.properties.relatedResourceId: -|arm-id
  Relation.properties.relatedResourceType: -|resource-type
  Relation: SecurityInsightsIncidentRelation
  Relationship: TiObjectKindRelationship
  Repo: SourceControlRepo
  Repository: SourceControlRepository
  RequiredPermissions.action: IsCustomAction
  RequiredPermissions.delete: IsDeleteAction
  RequiredPermissions.read: IsReadAction
  RequiredPermissions.write: IsWriteAction
  ResourceProviderRequiredPermissions.action: IsCustomAction
  ResourceProviderRequiredPermissions.delete: IsDeleteAction
  ResourceProviderRequiredPermissions.read: IsReadAction
  ResourceProviderRequiredPermissions.write: IsWriteAction
  ScheduledAlertRule.properties.enabled: IsEnabled
  ScheduledAlertRule.properties.lastModifiedUtc: LastModifiedOn
  ScheduledAlertRule.properties.suppressionEnabled: IsSuppressionEnabled
  ScheduledAlertRule: SecurityInsightsScheduledAlertRule
  SecurityAlert.properties.endTimeUtc: EndOn
  SecurityAlert.properties.startTimeUtc: StartOn
  SecurityAlert.properties.timeGenerated: AlertGeneratedOn
  SecurityAlert: SecurityInsightsAlert
  SecurityAlertPropertiesConfidenceReasonsItem: SecurityInsightsAlertConfidenceReason
  SecurityAlertTimelineItem.azureResourceId: -|arm-id
  SecurityAlertTimelineItem.endTimeUtc: EndOn
  SecurityAlertTimelineItem.startTimeUtc: StartOn
  SecurityAlertTimelineItem.timeGenerated: GeneratedOn
  SecurityGroupEntity: SecurityInsightsGroupEntity
  SentinelOnboardingState.properties.customerManagedKey: IsCustomerManagedKeySet
  SentinelOnboardingState: SecurityInsightsSentinelOnboardingState
  ServicePrincipal: SourceControlServicePrincipal
  SettingList: SecurityInsightsSettingList
  Settings: SecurityInsightsSettings
  SettingsStatus: AnomalySecurityMLAnalyticsSettingsStatus
  SourceControl: SecurityInsightsSourceControl
  SourceControl.properties.id: SourceControlId | uuid
  State: RecommendationState
  SubmissionMailEntity.properties.senderIp: -|ip-address
  SubmissionMailEntity.properties.submissionDate: SubmitOn
  SubmissionMailEntity.properties.timestamp: MessageReceivedOn
  SubmissionMailEntity: SecurityInsightsSubmissionMailEntity
  TemplateModel: SecurityInsightsTemplate
  TemplateStatus: SecurityInsightsAlertRuleTemplateStatus
  ThreatActor: TiObjectKindThreatActor
  ThreatIntelligence: SecurityInsightsThreatIntelligence
  ThreatIntelligenceAlertRule.properties.enabled: IsEnabled
  ThreatIntelligenceAlertRule.properties.lastModifiedUtc: LastModifiedOn
  ThreatIntelligenceAlertRuleTemplate.properties.createdDateUTC: CreatedOn
  ThreatIntelligenceAlertRuleTemplate.properties.lastUpdatedDateUTC: LastUpdatedOn
  ThreatIntelligenceFilteringCriteria.includeDisabled: IsIncludeDisabled
  ThreatIntelligenceFilteringCriteria.maxValidUntil: -|date-time
  ThreatIntelligenceFilteringCriteria.minValidUntil: -|date-time
  ThreatIntelligenceGranularMarkingModel: ThreatIntelligenceGranularMarkingEntity
  ThreatIntelligenceIndicatorModel.properties.created: CreatedOn|date-time
  ThreatIntelligenceIndicatorModel.properties.defanged: IsDefanged
  ThreatIntelligenceIndicatorModel.properties.externalLastUpdatedTimeUtc: ExternalLastUpdatedOn|date-time
  ThreatIntelligenceIndicatorModel.properties.lastUpdatedTimeUtc: LastUpdatedOn|date-time
  ThreatIntelligenceIndicatorModel.properties.revoked: IsRevoked
  ThreatIntelligenceIndicatorModel.properties.validFrom: -|date-time
  ThreatIntelligenceIndicatorModel.properties.validUntil: -|date-time
  ThreatIntelligenceIndicatorModel: SecurityInsightsThreatIntelligenceIndicatorData
  ThreatIntelligenceInformation: SecurityInsightsThreatIntelligenceIndicatorBase
  ThreatIntelligenceMetric.lastUpdatedTimeUtc: LastUpdatedOn
  TIDataConnector.properties.tipLookbackPeriod: TipLookbackOn
  TIDataConnector: SecurityInsightsTIDataConnector
  TIObject.properties.firstIngestedTimeUtc: FirstIngestedOn
  TIObject.properties.lastIngestedTimeUtc: LastIngestedOn
  TIObject.properties.lastUpdatedDateTimeUtc: LastUpdatedOn
  TiTaxiiDataConnectorDataTypesTaxiiClient: TiTaxiiDataConnectorDataTypes
  TriggeredAnalyticsRuleRun.properties.executionTimeUtc: ExecuteOn
  TriggerOperator: SecurityInsightsAlertRuleTriggerOperator
  Ueba: UebaSettings
  UrlEntity: SecurityInsightsUriEntity
  UserInfo: SecurityInsightsUserInfo
  Version: SourceControlVersion
  Warning: ResponseWarning
  Watchlist.properties.created: CreatedOn
  Watchlist.properties.source: SourceString   # Added property renaming due to api compat check with property breaking chang to string type in 2024-01-01-preview version
  Watchlist.properties.updated: UpdatedOn
  Watchlist.properties.watchlistId: -|uuid
  Watchlist: SecurityInsightsWatchlist
  WatchlistItem.properties.created: CreatedOn
  WatchlistItem.properties.entityMapping: EntityMappingDictionary # Added property renaming due to api compat check with property breaking chang to dictionary type in 2024-01-01-preview version
  WatchlistItem.properties.itemsKeyValue: ItemsKeyValueDictionary # Added property renaming due to api compat check with property breaking chang to dictionary type in 2024-01-01-preview version
  WatchlistItem.properties.updated: UpdatedOn
  WatchlistItem: SecurityInsightsWatchlistItem
  Webhook.rotateWebhookSecret: IsWebhookSecretRotated
  Webhook: SourceControlWebhook

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
