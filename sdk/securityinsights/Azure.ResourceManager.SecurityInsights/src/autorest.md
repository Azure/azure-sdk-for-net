# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SecurityInsights
namespace: Azure.ResourceManager.SecurityInsights
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/e0aca4c32155a2568fdad5cb91028206930f0053/specification/securityinsights/resource-manager/readme.md
tag: package-2022-11
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}: SecurityInsightsThreatIntelligenceIndicator

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
  source: SecurityInsightsWatchlistSource
  WatchlistItem: SecurityInsightsWatchlistItem
  WatchlistItem.properties.created: CreatedOn
  WatchlistItem.properties.WatchlistItemId: -|uuid
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
  triggersOn: SecurityInsightsAutomationRuleTriggersOn
  triggersWhen: SecurityInsightsAutomationRuleTriggersWhen
  AwsCloudTrailDataConnector: SecurityInsightsAwsCloudTrailDataConnector
  AzureResourceEntity: SecurityInsightsAzureResourceEntity
  AzureResourceEntity.resourceId: -|arm-id
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
  MCASDataConnector: SecurityInsightsMcasDataConnector
  MCASDataConnectorDataTypes: SecurityInsightsMcasDataConnectorDataTypes
  AlertsDataTypeOfDataConnector: SecurityInsightsAlertsDataTypeOfDataConnector
  MDATPDataConnector: SecurityInsightsMdatpDataConnector
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
- SecurityInsightsEntity

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
      $.MCASDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.Dynamics365DataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.Office365ProjectDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.OfficePowerBIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.OfficeDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.TIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.TiTaxiiDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.CodelessUiConnectorConfigProperties.properties.dataTypes["x-ms-client-flatten"] = true;
  - from: AlertRules.json
    where: $.definitions
    transform: >
      $.ActionPropertiesBase.properties.logicAppResourceId['x-ms-format'] = 'arm-id';
```
