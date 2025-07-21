# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SecurityCenter
namespace: Azure.ResourceManager.SecurityCenter
require: https://github.com/Azure/azure-rest-api-specs/blob/6c4497e6b0aaad8127f2dd50fa8a29aaf68f24e6/specification/security/resource-manager/readme.md
tag: package-dotnet-sdk
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - InformationProtectionPolicies_CreateOrUpdate
  - SqlVulnerabilityAssessmentBaselineRules_Add
  - InformationProtectionPolicies_List
  - SubAssessments_ListAll
  - Assessments_List
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

#mgmt-debug:
#  show-serialized-names: true

keep-orphaned-models:
  - ExternalSecuritySolutionKind

rename-mapping:
  OnPremiseResourceDetails.vmuuid: VmUuid|uuid
  RecommendationType.IoT_ACRAuthentication: IotAcrAuthentication
  RecommendationType.IoT_IPFilter_DenyAll: IotIPFilterDenyAll
  RecommendationType.IoT_IPFilter_PermissiveRule: IotIPFilterPermissiveRule
  DefenderForServersAwsOfferingVaAutoProvisioning: DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioning
  DefenderForServersAwsOfferingVaAutoProvisioningConfiguration: DefenderForServersAwsOfferingVulnerabilityAssessmentAutoProvisioningConfiguration
  DefenderForServersAwsOfferingDefenderForServers: AwsDefenderForServersInfo
  DefenderForServersGcpOfferingDefenderForServers: GcpDefenderForServersInfo
  DefenderForDatabasesGcpOfferingDefenderForDatabasesArcAutoProvisioning: GcpDefenderForDatabasesArcAutoProvisioning
  AdaptiveNetworkHardening.properties.rulesCalculationTime: RulesCalculatedOn
  Alert: SecurityAlert
  Application: SecurityApplication
  Automation: SecurityAutomation
  Compliance: SecurityCompliance
  Scan: SqlVulnerabilityAssessmentScan
  ScanResult: SqlVulnerabilityAssessmentScanResult
  ScanResultProperties: SqlVulnerabilityAssessmentScanResultProperties
  RuleStatus: SqlVulnerabilityAssessmentScanResultRuleStatus
  Remediation: SqlVulnerabilityAssessmentRemediation
  Remediation.automated: IsAutomated
  Baseline: SqlVulnerabilityAssessmentBaseline
  ScanTriggerType: SqlVulnerabilityAssessmentScanTriggerType
  ScanProperties: SqlVulnerabilityAssessmentScanProperties
  ScanState: SqlVulnerabilityAssessmentScanState
  ScanningMode: DefenderForServersScanningMode
  Setting: SecuritySetting
  Software: SoftwareInventory
  Software.properties.firstSeenAt: -|date-time
  TopologyResource: SecurityTopologyResource
  Alert.properties.endTimeUtc: EndOn
  Alert.properties.startTimeUtc: StartOn
  Alert.properties.timeGeneratedUtc: GeneratedOn
  Alert.properties.processingEndTimeUtc: ProcessingEndOn
  AlertsSuppressionRule: SecurityAlertsSuppressionRule
  AlertsSuppressionRule.properties.expirationDateUtc: ExpireOn
  AlertsSuppressionRule.properties.lastModifiedUtc: LastModifiedOn
  Compliance.properties.assessmentTimestampUtcDate: AssessedOn
  SeverityEnum: CustomAssessmentSeverity
  Severity: SecurityAssessmentSeverity
  IoTSecurityAggregatedAlert.properties.aggregatedDateUtc: AggregatedOn
  IoTSecuritySolutionModel: IotSecuritySolution
  MdeOnboardingData: MdeOnboarding
  Pricing.properties.deprecated: IsDeprecated
  Pricing.properties.enablementTime: EnabledOn
  SecuritySubAssessment.properties.id: VulnerabilityId
  SecuritySubAssessment.properties.timeGenerated: GeneratedOn
  SecurityTask.properties.creationTimeUtc: CreatedOn
  SecurityTask.properties.lastStateChangeTimeUtc: LastStateChangedOn
  RuleState: SecurityAlertsSuppressionRuleState
  TopologySingleResource.resourceId: -|arm-id
  TopologySingleResourceChild.resourceId: -|arm-id
  TopologySingleResourceParent.resourceId: -|arm-id
  VmRecommendation.resourceId: -|arm-id
  VaRule: VulnerabilityAssessmentRule
  RuleType: VulnerabilityAssessmentRuleType
  Rule: RecommendedSecurityRule
  ValueType: SecurityValueType
  TransportProtocol: SecurityTransportProtocol
  Direction: SecurityTrafficDirection
  Threats: SecurityThreat
  Techniques: SecurityAssessmentTechnique
  Tactics: SecurityAssessmentTactic
  Categories: SecurityAssessmentResourceCategory
  UserImpact: SecurityAssessmentUserImpact
  SecurityAssessmentMetadataPartnerData: SecurityAssessmentMetadataPartner
  SecurityAssessmentMetadataPropertiesResponsePublishDates: SecurityAssessmentPublishDates
  SecurityAssessmentPartnerData: SecurityAssessmentPartner
  SupportedCloudEnum: CustomAssessmentAutomationSupportedCloud
  StatusReason: JitNetworkAccessPortStatusReason
  Status: JitNetworkAccessPortStatus
  State: RegulatoryComplianceState
  SqlServerVulnerabilityProperties.type: SqlServerVulnerabilityType
  SourceSystem: AdaptiveApplicationControlGroupSourceSystem
  SettingName: SecuritySettingName
  ServicePrincipalProperties.applicationId: -|uuid
  ServerVulnerabilityProperties.patchable: IsPatchable
  ServerVulnerabilityProperties.type: ServerVulnerabilityType
  SecurityTaskParameters: SecurityTaskProperties
  SecurityFamily.Va: VulnerabilityAssessment
  SecurityAssessmentMetadataProperties.preview: IsPreview
  ScopeElement: SuppressionAlertsScopeElement
  AdditionalData: SecuritySubAssessmentAdditionalInfo
  GovernanceAssignmentAdditionalData: GovernanceAssignmentAdditionalInfo
  SecuritySubAssessmentAdditionalData: SecuritySubAssessmentAdditionalInfo
  AlertPropertiesSupportingEvidence: SecurityAlertSupportingEvidence
  AlertPropertiesSupportingEvidence.type: SecurityAlertSupportingEvidenceType
  AlertSyncSettings: SecurityAlertSyncSettings
  AlertSyncSettings.properties.enabled: IsEnabled
  AssessmentStatusResponse.firstEvaluationDate: FirstEvaluatedOn
  AssessmentStatusResponse: SecurityAssessmentStatusResult
  AutoProvision: AutoProvisionState
  AwAssumeRoleAuthenticationDetailsProperties: AwsAssumeRoleAuthenticationDetailsProperties
  ContainerRegistryVulnerabilityProperties.patchable: IsPatchable
  CVE: SecurityCve
  Cvss: SecurityCvss
  DataExportSettings.properties.enabled: IsEnabled
  DefenderFoDatabasesAwsOfferingArcAutoProvisioning: DefenderForDatabasesAwsOfferingArcAutoProvisioning
  DefenderFoDatabasesAwsOfferingArcAutoProvisioning.enabled: IsEnabled
  DefenderFoDatabasesAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata.expiryDate: ExpireOn
  DefenderFoDatabasesAwsOfferingRds: DefenderForDatabasesAwsOfferingRds
  DefenderFoDatabasesAwsOfferingRds.enabled: IsEnabled
  DefenderForContainersAwsOffering.enableContainerVulnerabilityAssessment: IsContainerVulnerabilityAssessmentEnabled
  DefenderForContainersAwsOffering.autoProvisioning: IsAutoProvisioningEnabled
  DefenderForContainersGcpOffering.auditLogsAutoProvisioningFlag: IsAuditLogsAutoProvisioningEnabled
  DefenderForContainersGcpOffering.defenderAgentAutoProvisioningFlag: IsDefenderAgentAutoProvisioningEnabled
  DefenderForContainersGcpOffering.policyAgentAutoProvisioningFlag: IsPolicyAgentAutoProvisioningEnabled
  DefenderForDatabasesGcpOfferingArcAutoProvisioning.enabled: IsEnabled
  DefenderForServersAwsOfferingArcAutoProvisioning.enabled: IsEnabled
  DefenderForServersAwsOfferingArcAutoProvisioningServicePrincipalSecretMetadata.expiryDate: ExpireOn|date-time
  DefenderForServersAwsOfferingMdeAutoProvisioning.enabled: IsEnabled
  DefenderForServersAwsOfferingVaAutoProvisioning.enabled: IsEnabled
  DefenderForServersAwsOfferingVmScanners.enabled: IsEnabled
  DefenderForServersGcpOfferingArcAutoProvisioning.enabled: IsEnabled
  DefenderForServersGcpOfferingMdeAutoProvisioning.enabled: IsEnabled
  DefenderForServersGcpOfferingVaAutoProvisioning.enabled: IsEnabled
  DefenderForServersGcpOfferingVaAutoProvisioning: DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioning
  DefenderForServersGcpOfferingVaAutoProvisioningConfiguration: DefenderForServersGcpOfferingVulnerabilityAssessmentAutoProvisioningConfiguration
  DefenderForServersGcpOffering.vaAutoProvisioning: VulnerabilityAssessmentAutoProvisioning
  EnvironmentData: SecurityConnectorEnvironment
  AwsEnvironmentData: AwsEnvironment
  AzureDevOpsScopeEnvironmentData: AzureDevOpsScopeEnvironment
  GcpProjectEnvironmentData: GcpProjectEnvironment
  GithubScopeEnvironmentData: GithubScopeEnvironment
  EventSource: SecurityEventSource
  AutomationSource: SecurityAutomationSource
  ExpandControlsEnum: SecurityScoreODataExpand
  ExpandEnum: SecurityAssessmentODataExpand
  ExportData: IotSecuritySolutionExportOption
  FileType: PathRecommendationFileType
  GcpCredentialsDetailsProperties.type: GcpCredentialType
  GcpOrganizationalData: GcpOrganizationalInfo
  GcpOrganizationalDataMember: GcpMemberOrganizationalInfo
  GcpOrganizationalDataOrganization: GcpParentOrganizationalInfo
  AwsOrganizationalData: AwsOrganizationalInfo
  GovernanceEmailNotification.disableManagerEmailNotification: IsManagerEmailNotificationDisabled
  GovernanceEmailNotification.disableOwnerEmailNotification: IsOwnerEmailNotificationDisabled
  GovernanceRuleEmailNotification.disableManagerEmailNotification: IsManagerEmailNotificationDisabled
  GovernanceRuleEmailNotification.disableOwnerEmailNotification: IsOwnerEmailNotificationDisabled
  Intent: KillChainIntent
  JitNetworkAccessPolicyInitiatePort.endTimeUtc: EndOn
  JitNetworkAccessRequest.startTimeUtc: StartOn
  JitNetworkAccessRequest: JitNetworkAccessRequestInfo
  JitNetworkAccessRequestPort.endTimeUtc: EndOn
  Operator: AutomationTriggeringRuleOperator
  PropertyType: AutomationTriggeringRulePropertyType
  PathRecommendation.common: IsCommon
  Protocol: JitNetworkAccessPortProtocol
  ProvisioningState: SecurityFamilyProvisioningState
  SecurityAssessmentMetadataResponse.properties.preview: IsPreview
  ConnectableResource: ConnectableResourceInfo
  ConnectedResource: ConnectedResourceInfo
  TagsResource: SecurityCenterTagsResourceInfo
  SecureScoreItem: SecureScore
  SecurityAssessment: SecurityAssessmentInfo
  SecurityAssessmentResponse: SecurityAssessment
  SecurityAssessmentMetadata: SecurityAssessmentMetadataInfo
  SecurityAssessmentMetadataResponse: SecurityAssessmentMetadata
  RuleResults: SqlVulnerabilityAssessmentBaselineRule
  AscLocation: SecurityCenterLocation
  AwAssumeRoleAuthenticationDetailsProperties.awsExternalId: -|uuid
  ConnectableResource.id: -|arm-id
  IoTSecurityAggregatedAlertPropertiesTopDevicesListItem: IotSecurityAggregatedAlertTopDevice
  IoTSecuritySolutionAnalyticsModelPropertiesDevicesMetricsItem: IotSecuritySolutionAnalyticsModelDevicesMetrics
  InformationProtectionAwsOfferingInformationProtection: AwsInformationProtection
  JitNetworkAccessPolicyInitiateVirtualMachine.id: -|arm-id
  JitNetworkAccessPolicyVirtualMachine.id: -|arm-id
  JitNetworkAccessRequestVirtualMachine.id: -|arm-id
  LogAnalyticsIdentifier.agentId: -|uuid
  AllowedConnectionsResource: SecurityCenterAllowedConnection
  WorkspaceSetting: SecurityWorkspaceSetting
  WorkspaceSetting.properties.workspaceId: -|arm-id
  MinimalSeverity: SecurityAlertMinimalSeverity
  Roles: SecurityAlertReceivingRole
  BundleType: SecurityAlertSimulatorBundleType
  ControlType: SecurityControlType
  DataSource: IotSecuritySolutionDataSource
  EnforcementMode: AdaptiveApplicationControlEnforcementMode
  EnforcementSupport: SecurityCenterVmEnforcementSupportState
  PermissionProperty: SecurityCenterCloudPermission
  ProtectionMode: SecurityCenterFileProtectionMode
  QueryCheck: VulnerabilityAssessmentRuleQueryCheck
  RecommendationType: IotSecurityRecommendationType
  ResourceDetails: SecurityCenterResourceDetails
  ResourceStatus: SecurityAssessmentResourceStatus
  AutomationAction: SecurityAutomationAction
  AssessmentType: SecurityAssessmentType
  AssessmentStatus: SecurityAssessmentStatus
  AssessmentStatusCode: SecurityAssessmentStatusCode
  AlertStatus: SecurityAlertStatus
  AlertEntity: SecurityAlertEntity
  AlertResourceIdentifier: SecurityAlertResourceIdentifier
  AlertSeverity: SecurityAlertSeverity
  AlertSimulatorRequestProperties: SecurityAlertSimulatorRequestProperties
  AlertSimulatorBundlesRequestProperties: SecurityAlertSimulatorBundlesRequestProperties
  AlertSimulatorRequestBody: SecurityAlertSimulatorContent
  AutomationActionEventHub: SecurityAutomationActionEventHub
  AutomationActionLogicApp: SecurityAutomationActionLogicApp
  AutomationActionWorkspace: SecurityAutomationActionWorkspace
  AutomationRuleSet: SecurityAutomationRuleSet
  AutomationScope: SecurityAutomationScope
  AutomationTriggeringRule: SecurityAutomationTriggeringRule
  AutomationTriggeringRuleOperator: SecurityAutomationTriggeringRuleOperator
  AutomationValidationStatus: SecurityAutomationValidationStatus
  ConnectorSetting: SecurityCloudConnector
  LogAnalyticsIdentifier.workspaceId: -|uuid
  OnPremiseResourceDetails.workspaceId: -|arm-id
  OnPremiseSqlResourceDetails.workspaceId: -|arm-id
  InformationType: SecurityInformationTypeInfo
  InformationType.enabled: IsEnabled
  Rank: SensitivityLabelRank
  Extension: PlanExtension
  Code: ExtensionOperationStatusCode
  OperationStatus: ExtensionOperationStatus
  IsEnabled: IsExtensionEnabled
  GitlabScopeEnvironmentData: GitlabScopeEnvironment
  AzureDevOpsOrg: DevOpsOrg
  AzureDevOpsOrgProperties: DevOpsOrgProperties
  AzureDevOpsOrgProperties.provisioningStatusUpdateTimeUtc: ProvisioningStatusUpdatedOn
  AzureDevOpsProject: DevOpsProject
  AzureDevOpsProjectProperties: DevOpsProjectProperties
  AzureDevOpsProjectProperties.provisioningStatusUpdateTimeUtc: ProvisioningStatusUpdatedOn
  AzureDevOpsRepository: DevOpsRepository
  AzureDevOpsRepositoryProperties: DevOpsRepositoryProperties
  AzureDevOpsRepositoryProperties.provisioningStatusUpdateTimeUtc: ProvisioningStatusUpdatedOn
  OnboardingState: ResourceOnboardingState
  DefenderForStorageSetting.properties.isEnabled: IsEnabled
  DefenderForStorageSetting.properties.overrideSubscriptionLevelSettings: IsOverrideSubscriptionLevelSettingsEnabled
  DefenderForStorageSetting.properties.sensitiveDataDiscovery.isEnabled: IsSensitiveDataDiscoveryEnabled
  DefenderForStorageSetting.properties.sensitiveDataDiscovery.operationStatus: SensitiveDataDiscoveryOperationStatus
  DefenderForStorageSetting.properties.malwareScanning.operationStatus: MalwareScanningOperationStatus
  DefenderForStorageSetting.properties.malwareScanning.onUpload.isEnabled: IsMalwareScanningOnUploadEnabled
  GetSensitivitySettingsResponse: SensitivitySettings
  GetSensitivitySettingsResponseProperties: SensitivitySettingsProperties
  GitHubOwner: SecurityConnectorGitHubOwner
  GitHubOwnerProperties: SecurityConnectorGitHubOwnerProperties
  GitHubRepository: SecurityConnectorGitHubRepository
  GitHubRepositoryProperties: SecurityConnectorGitHubRepositoryProperties
  GitLabGroup: SecurityConnectorGitLabGroup
  GitLabGroupProperties: SecurityConnectorGitLabGroupProperties
  GitLabProject: SecurityConnectorGitLabProject
  GitLabProjectProperties: SecurityConnectorGitLabProjectProperties
  HealthReport: SecurityHealthReport
  Issue: SecurityHealthReportIssue
  AutoDiscovery: DevOpsAutoDiscovery
  DefenderCspmAwsOfferingDatabasesDspm.enabled: IsEnabled
  DefenderCspmAwsOfferingDataSensitivityDiscovery.enabled: IsEnabled
  DefenderCspmAwsOfferingMdcContainersAgentlessDiscoveryK8S.enabled: IsEnabled
  DefenderCspmAwsOfferingMdcContainersImageAssessment.enabled: IsEnabled
  DefenderCspmGcpOfferingDataSensitivityDiscovery.enabled: IsEnabled
  DefenderCspmGcpOfferingMdcContainersAgentlessDiscoveryK8S.enabled: IsEnabled
  DefenderCspmGcpOfferingMdcContainersImageAssessment.enabled: IsEnabled
  DefenderCspmGcpOfferingVmScanners.enabled: IsEnabled
  DefenderFoDatabasesAwsOfferingDatabasesDspm.enabled: IsEnabled
  DefenderForContainersAwsOfferingMdcContainersAgentlessDiscoveryK8S.enabled: IsEnabled
  DefenderForContainersAwsOfferingMdcContainersImageAssessment.enabled: IsEnabled
  DefenderForContainersGcpOfferingMdcContainersAgentlessDiscoveryK8S.enabled: IsEnabled
  DefenderForContainersGcpOfferingMdcContainersImageAssessment.enabled: IsEnabled
  DefenderForServersGcpOfferingVmScanners.enabled: IsEnabled
  SensitivityLabel.enabled: IsEnabled
  Label: MipSensitivityLabel
  Source: HealthReportSource
  HealthReportResourceDetails.id: -|arm-id
  StatusName: HealthReportStatusName
  Authorization: DevOpsAuthorization
  InfoType: UserDefinedInformationType

prepend-rp-prefix:
  - CloudName
  - Pricing
  - PricingTier
  - ConfigurationStatus
  - CloudOffering
  - ConnectionType
  - PublisherInfo
  - ApiCollection

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'ascLocation': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceId': 'arm-id'
  'policyDefinitionId': 'arm-id'

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
  IoT: Iot
  TLS: Tls
  VA: VulnerabilityAssessment
  TCP: Tcp
  UDP: Udp
  AWS: Aws
  GCP: Gcp
  AAD: Aad
  ATA: Ata
  CEF: Cef
  SSM: Ssm
  K8s: K8S

override-operation-name:
  Alerts_UpdateResourceGroupLevelStateToResolve: Resolve
  Alerts_UpdateResourceGroupLevelStateToDismiss: Dismiss
  Alerts_UpdateResourceGroupLevelStateToActivate: Activate
  Alerts_UpdateResourceGroupLevelStateToInProgress: UpdateSatateToInProgress
  Alerts_UpdateSubscriptionLevelStateToResolve: Resolve
  Alerts_UpdateSubscriptionLevelStateToDismiss: Dismiss
  Alerts_UpdateSubscriptionLevelStateToActivate: Activate
  Alerts_UpdateSubscriptionLevelStateToInProgress: UpdateSatateToInProgress
  GovernanceRules_RuleIdExecuteSingleSecurityConnector: ExecuteRule
  SecurityConnectorGovernanceRulesExecuteStatus_Get: GetRuleExecutionStatus
  GovernanceRules_RuleIdExecuteSingleSubscription: ExecuteRule
  SubscriptionGovernanceRulesExecuteStatus_Get: GetRuleExecutionStatus
  ExternalSecuritySolutions_List: GetExternalSecuritySolutions
  AzureDevOpsOrgs_Get: GetDevOpsOrg
  AzureDevOpsOrgs_ListAvailable: GetAvailableDevOpsOrgs

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}: SubscriptionSecurityAlert
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}: ResourceGroupSecurityAlert
  /subscriptions/{subscriptionId}/providers/Microsoft.Security/applications/{applicationId}: SubscriptionSecurityApplication
  /subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}: SubscriptionSecurityTask
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}: ResourceGroupSecurityTask

request-path-is-non-resource:
  - /{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/{scanId}/scanResults/{scanResultId}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections/{connectionType}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/topologies/{topologyResourceName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions/{discoveredSecuritySolutionName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/ExternalSecuritySolutions/{externalSecuritySolutionsName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/securitySolutions/{securitySolutionName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.Security/mdeOnboardings/default

request-path-to-parent:
  /subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/default/simulate: /subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}

operation-positions:
  Alerts_Simulate: collection

list-exception:
  - /{resourceId}/providers/Microsoft.Security/assessments/{assessmentName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/applicationWhitelistings/{groupName}
  - /{resourceId}/providers/Microsoft.Security/defenderForStorageSettings/{settingName}

suppress-abstract-base-class:
- SecuritySettingData
- ExternalSecuritySolution
- SecurityAlertSimulatorRequestProperties

directive:
  - rename-operation:
      from: SecurityConnectorApplication_Get
      to: SecurityConnectorApplications_Get
  - rename-operation:
      from: SecurityConnectorApplication_CreateOrUpdate
      to: SecurityConnectorApplications_CreateOrUpdate
  - rename-operation:
      from: SecurityConnectorApplication_Delete
      to: SecurityConnectorApplications_Delete
  - rename-operation:
      from: SecurityConnectorGovernanceRule_List
      to: SecurityConnectorGovernanceRules_List
  - from: externalSecuritySolutions.json
    where: $.definitions
    transform: >
      $.ExternalSecuritySolutionKind['x-ms-client-name'] = 'ExternalSecuritySolutionKindInfo';
      $.AadConnectivityState.properties.connectivityState['x-ms-enum']['name'] = 'AadConnectivityStateType';
  - from: jitNetworkAccessPolicies.json
    where: $.definitions
    transform: >
      $.JitNetworkAccessPortRule.properties.maxRequestAccessDuration['format'] = 'duration';
  - from: types.json
    where: $.definitions.Kind
    transform: >
      $['x-ms-client-name'] = 'ResourceKind';
  - from: securityConnectors.json
    where: $.definitions
    transform: >
      $.defenderForServersAwsOffering.properties.vaAutoProvisioning.properties.configuration.properties.type['x-ms-enum']['name'] = 'VulnerabilityAssessmentAutoProvisioningType';
      $.defenderForServersAwsOffering.properties.subPlan.properties.type['x-ms-enum']['name'] = 'AvailableSubPlanType';
      $.defenderForServersGcpOffering.properties.vaAutoProvisioning.properties.configuration.properties.type['x-ms-enum']['name'] = 'VulnerabilityAssessmentAutoProvisioningType';
      $.defenderForServersGcpOffering.properties.subPlan.properties.type['x-ms-enum']['name'] = 'AvailableSubPlanType';
      $.defenderFoDatabasesAwsOffering['x-ms-client-name'] = 'DefenderForDatabasesAwsOffering'
  - from: alerts.json
    where: $.definitions
    transform: >
      $.ResourceIdentifier['x-ms-client-name'] = 'AlertResourceIdentifier';
  - from: securityContacts.json
    where: $.definitions.SecurityContactProperties.properties.alertNotifications.properties.state
    transform: >
        $['x-ms-enum']['name'] = 'SecurityAlertNotificationState';
  - from: securityContacts.json
    where: $.definitions.SecurityContactProperties.properties.notificationsByRole.properties.state
    transform: >
        $['x-ms-enum']['name'] = 'SecurityAlertNotificationByRoleState';
  - from: sqlVulnerabilityAssessmentsBaselineRuleOperations.json
    where: $.paths..parameters[?(@.name == 'workspaceId')]
    transform: >
        $.format = 'uuid';
  - from: sqlVulnerabilityAssessmentsScanOperations.json
    where: $.paths..parameters[?(@.name == 'workspaceId')]
    transform: >
        $.format = 'uuid';
  - from: sqlVulnerabilityAssessmentsScanResultsOperations.json
    where: $.paths..parameters[?(@.name == 'workspaceId')]
    transform: >
        $.format = 'uuid';
  - remove-operation: GovernanceRules_OperationResults
  # TODO: temporary remove these operations to mitigate the exception from BuildParameterMapping in Autorest.CSharp
  - remove-operation: InformationProtectionPolicies_Get
  - remove-operation: Tasks_UpdateSubscriptionLevelTaskState
  - remove-operation: Tasks_UpdateResourceGroupLevelTaskState
  - from: externalSecuritySolutions.json
    where: $.definitions['ExternalSecuritySolutionKind']
    transform: >
        $ = {
          "type": "string",
          "description": "The kind of the external solution",
          "enum": [
            "CEF",
            "ATA",
            "AAD"
          ],
          "x-ms-enum": {
            "name": "ExternalSecuritySolutionKind",
            "modelAsString": true,
            "values": [
              {
                "value": "CEF"
              },
              {
                "value": "ATA"
              },
              {
                "value": "AAD"
              }
            ]
          }
        };
  - from: externalSecuritySolutions.json
    where: $.definitions['ExternalSecuritySolution']
    transform: >
        $.properties['kind'] = {
          "$ref": "#/definitions/ExternalSecuritySolutionKind"
        };
        $.allOf = [
          {
            "$ref": "../../../common/v1/types.json#/definitions/Resource"
          },
          {
            "$ref": "../../../common/v1/types.json#/definitions/Location"
          }
        ]
  - from: governanceRules.json
    where: $.definitions
    transform: >
        $.OperationResult.properties.status['x-ms-enum']['name'] = 'OperationResultStatus';
  # The parameter for /{scope} must be defined as x-ms-skip-url-encoding = true
  - from: governanceRules.json
    where: $.parameters
    transform: >
        $.Scope['x-ms-skip-url-encoding'] = true;
  - from: governanceAssignments.json
    where: $.parameters
    transform: >
        $.Scope['x-ms-skip-url-encoding'] = true;
  - from: defenderForStorageSettings.json
    where: $.parameters
    transform: >
        $.DefenderForStorageSettingName['x-ms-enum']['name'] = "defenderForStorageSettingName";
  - from: healthReports.json
    where: $.definitions
    transform: >
      $.resourceDetails['x-ms-client-name'] = 'HealthReportResourceDetails';
  - from: healthReports.json
    where: $.definitions
    transform: >
      $.status['x-ms-client-name'] = 'HealthReportStatus';
```
