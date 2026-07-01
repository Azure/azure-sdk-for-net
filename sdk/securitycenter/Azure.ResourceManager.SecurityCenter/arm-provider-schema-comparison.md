# ARM provider schema comparison: Azure.ResourceManager.SecurityCenter

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 legacy-only and 2 resolve-only resource ID patterns; 8 hierarchy differences; 1 CRUD operation difference; 11 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 63 matching patterns; 4 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | 8 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 11 differences. |

## 1. Resource ID pattern coverage

**Differences:** 4 legacy-only pattern(s), 2 resolve-only pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 63 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 4 | `/providers/Microsoft.Security/sensitivitySettings/current`<br>`/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/serverVulnerabilityAssessments/default`<br>`/{resourceId}/providers/Microsoft.Security/advancedThreatProtectionSettings/current` |
| `resolveArmResources` only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/serverVulnerabilityAssessments/{serverVulnerabilityAssessment}`<br>`/{resourceId}/providers/Microsoft.Security/advancedThreatProtectionSettings/{settingName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 8 hierarchy differences.

| Resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/pricings/{pricingName}/securityOperators/{securityOperatorName}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Extension, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections/{connectionType}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions/{discoveredSecuritySolutionName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/jitNetworkAccessPolicies/{jitNetworkAccessPolicyName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/securitySolutions/{securitySolutionName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/topologies/{topologyResourceName}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operation differences: `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SqlVulnerabilityAssessmentsAPI.SqlVulnerabilityAssessmentSettingsOperationGroup.getScanOperationResult` | `Read` | `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/scanOperationResults/{operationId}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 11 list/action operation differences.

#### List/action operation differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `AlertsAPI.Alerts.listSubscriptionLevelByRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `TasksAPI.SecurityTasks.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Security/mdeOnboardings/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `MdeOnboardingAPI.MdeOnboardings.list` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/mdeOnboardings` | Missing. | Present. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/providers/Microsoft.Security/apiCollections/{apiId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `ApiCollectionsAPI.ApiCollections.listBySubscription` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/apiCollections` | Missing. | Present. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `IoTSecurityAPI.IoTSecuritySolutionAnalyticsModels.list` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels` | Present. | Missing. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `IoTSecurityAPI.IoTSecuritySolutionAnalyticsModels.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels` | Missing. | Present. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections/{connectionType}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.AllowedConnectionsResources.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions/{discoveredSecuritySolutionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.DiscoveredSecuritySolutions.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/jitNetworkAccessPolicies/{jitNetworkAccessPolicyName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.JitNetworkAccessPolicies.listByRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/jitNetworkAccessPolicies` | Different. | Different. |

#### List/action operation differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/topologies/{topologyResourceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.TopologyResources.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/topologies` | Different. | Different. |

#### List/action operation differences: `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SqlVulnerabilityAssessmentsAPI.SqlVulnerabilityAssessmentSettingsOperationGroup.getScanOperationResult` | `Action` | `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/scanOperationResults/{operationId}` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 36 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 12 non-resource method difference(s) were found.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/alertsSuppressionRules/{alertsSuppressionRuleName}` | `SecurityAlertsSuppressionRule` | `AlertsSuppressionRule` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}` | `SubscriptionSecurityAlert` | `LocationsAlerts` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}` | `SubscriptionSecurityTask` | `LocationsTasks` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/pricings/{pricingName}/securityOperators/{securityOperatorName}` | `SecurityOperator` | `PricingsSecurityOperators` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/secureScores/{secureScoreName}` | `SecureScore` | `SecureScoreItem` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/settings/{settingName}` | `SecuritySetting` | `Setting` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Security/workspaceSettings/{workspaceSettingName}` | `SecurityWorkspaceSetting` | `WorkspaceSetting` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/providers/Microsoft.Security/apiCollections/{apiId}` | `ApiCollection` | `ExternalResourceApiCollection` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/assignments/{assignmentId}` | `SecurityCenterAssignment` | `Assignment` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/automations/{automationName}` | `SecurityAutomation` | `Automation` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}` | `IotSecuritySolution` | `IoTSecuritySolutionModel` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels/default` | `IotSecuritySolutionAnalyticsModel` | `IoTSecuritySolutionAnalyticsModel` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels/default/aggregatedAlerts/{aggregatedAlertName}` | `IotSecurityAggregatedAlert` | `IoTSecurityAggregatedAlert` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels/default/aggregatedRecommendations/{aggregatedRecommendationName}` | `IotSecurityAggregatedRecommendation` | `IoTSecurityAggregatedRecommendation` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}` | `ResourceGroupSecurityAlert` | `LocationsAlerts` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections/{connectionType}` | `SecurityCenterAllowedConnection` | `AllowedConnectionsResource` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}` | `ResourceGroupSecurityTask` | `LocationsTasks` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/topologies/{topologyResourceName}` | `SecurityTopology` | `TopologyResource` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/privateLinks/{privateLinkName}/privateEndpointConnections/{privateEndpointConnectionName}` | `PrivateEndpointConnection` | `PrivateLinkResourcePrivateEndpointConnection` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/privateLinks/{privateLinkName}/privateLinkResources/{groupId}` | `PrivateLinkGroup` | `PrivateLinkGroupResource` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default` | `DevOpsConfiguration` | `SecurityConnectorsDevops` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/azureDevOpsOrgs/{orgName}` | `AzureDevOpsOrg` | `DevopsAzureDevOpsOrgs` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/azureDevOpsOrgs/{orgName}/projects/{projectName}` | `AzureDevOpsProject` | `AzureDevOpsOrgsProjects` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/azureDevOpsOrgs/{orgName}/projects/{projectName}/repos/{repoName}` | `AzureDevOpsRepository` | `ProjectsRepos` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/gitHubOwners/{ownerName}` | `GitHubOwner` | `DevopsGitHubOwners` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/gitHubOwners/{ownerName}/repos/{repoName}` | `GitHubRepository` | `GitHubOwnersRepos` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/gitLabGroups/{groupFQName}` | `GitLabGroup` | `DevopsGitLabGroups` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/devops/default/gitLabGroups/{groupFQName}/projects/{projectName}` | `GitLabProject` | `GitLabGroupsProjects` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/standards/{standardId}` | `SecurityCenterStandard` | `Standard` |
| `/{resourceId}/providers/Microsoft.Security/assessments/{assessmentName}` | `SecurityAssessment` | `SecurityAssessmentResponsesScopeParameterSecurityAssessmentResponse` |
| `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/baselineRules/{ruleId}` | `SqlVulnerabilityAssessmentBaselineRule` | `RuleResults` |
| `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/{scanId}` | `SqlVulnerabilityAssessmentScan` | `ScanV2` |
| `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/{scanId}/scanResults/{scanResultId}` | `SqlVulnerabilityAssessmentScanResult` | `ScanResult` |
| `/{resourceId}/providers/Microsoft.Security/standardAssignments/{standardAssignmentName}` | `StandardAssignment` | `ResourceIdScopeParameterStandardAssignment` |
| `/{scopeId}/providers/Microsoft.Security/pricings/{pricingName}` | `SecurityCenterPricing` | `Pricing` |
| `/{scope}/providers/Microsoft.Security/compliances/{complianceName}` | `SecurityCompliance` | `Compliance` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `AlertsAPI.AlertsOperationGroup.simulate` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/default/simulate` | Missing. | Present. |
| `ApiCollectionsAPI.ApiCollections.listBySubscription` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/apiCollections` | Present. | Missing. |
| `LocationsAPI.AscLocations.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}` | Missing. | Present. |
| `LocationsAPI.AscLocations.list` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations` | Missing. | Present. |
| `MdeOnboardingAPI.MdeOnboardings.list` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/mdeOnboardings` | Present. | Missing. |
| `OperationsAPI.OperationResultsOperationGroup.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{location}/operationResults/{operationId}` | Missing. | Present. |
| `PrivateLinksAPI.PrivateLinkResources.head` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/privateLinks/{privateLinkName}` | Missing. | Present. |
| `SecuritySolutionsAPI.ExternalSecuritySolutions.listByHomeRegion` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/ExternalSecuritySolutions` | Missing. | Present. |
| `SecuritySolutionsAPI.SecuritySolutionsReferenceDataOperationGroup.listByHomeRegion` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/securitySolutionsReferenceData` | Missing. | Present. |
| `SecuritySolutionsAPI.ServerVulnerabilityAssessments.listByExtendedResource` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/serverVulnerabilityAssessments` | Present. | Missing. |
| `SensitivitySettingsAPI.GetSensitivitySettingsResponses.createOrUpdate` | `/providers/Microsoft.Security/sensitivitySettings/current` | Missing. | Present. |
| `SensitivitySettingsAPI.GetSensitivitySettingsResponses.get` | `/providers/Microsoft.Security/sensitivitySettings/current` | Missing. | Present. |

