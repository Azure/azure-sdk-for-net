# ARM provider schema comparison: Azure.ResourceManager.SecurityCenter

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 legacy-only and 2 resolve-only normalized resource ID patterns; 8 hierarchy differences; 1 CRUD operation difference; 11 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 63 matching normalized patterns; 4 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | 8 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 11 differences. |

## 1. Resource ID pattern coverage

**Differences:** 4 legacy-only normalized pattern(s), 2 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 63 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 4 | `/providers/Microsoft.Security/sensitivitySettings/current`<br>`/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/serverVulnerabilityAssessments/default`<br>`/{resourceId}/providers/Microsoft.Security/advancedThreatProtectionSettings/current` |
| `resolveArmResources` only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceNamespace}/{resourceType}/{resourceName}/providers/Microsoft.Security/serverVulnerabilityAssessments/{serverVulnerabilityAssessment}`<br>`/{resourceId}/providers/Microsoft.Security/advancedThreatProtectionSettings/{settingName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 8 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.security/pricings/{}/securityoperators/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Extension, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/alerts/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/allowedconnections/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/discoveredsecuritysolutions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/jitnetworkaccesspolicies/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/securitysolutions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/tasks/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/topologies/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SqlVulnerabilityAssessmentsAPI.SqlVulnerabilityAssessmentSettingsOperationGroup.getScanOperationResult` | `Read` | `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/scanOperationResults/{operationId}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 11 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts/{alertName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `AlertsAPI.Alerts.listSubscriptionLevelByRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/alerts` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks/{taskName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `TasksAPI.SecurityTasks.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/tasks` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/providers/Microsoft.Security/mdeOnboardings/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `MdeOnboardingAPI.MdeOnboardings.list` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/mdeOnboardings` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/providers/Microsoft.Security/apiCollections/{apiId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `ApiCollectionsAPI.ApiCollections.listBySubscription` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/apiCollections` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `IoTSecurityAPI.IoTSecuritySolutionAnalyticsModels.list` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `IoTSecurityAPI.IoTSecuritySolutionAnalyticsModels.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}/analyticsModels` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections/{connectionType}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.AllowedConnectionsResources.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions/{discoveredSecuritySolutionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.DiscoveredSecuritySolutions.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/jitNetworkAccessPolicies/{jitNetworkAccessPolicyName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.JitNetworkAccessPolicies.listByRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/jitNetworkAccessPolicies` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/topologies/{topologyResourceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SecuritySolutionsAPI.TopologyResources.listByHomeRegion` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/topologies` | Different. | Different. |

#### List and action operations differences: `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `SqlVulnerabilityAssessmentsAPI.SqlVulnerabilityAssessmentSettingsOperationGroup.getScanOperationResult` | `Action` | `/{resourceId}/providers/Microsoft.Security/sqlVulnerabilityAssessments/default/scans/scanOperationResults/{operationId}` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 36 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 12 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.security/alertssuppressionrules/{}` | `SecurityAlertsSuppressionRule` | `AlertsSuppressionRule` |
| `/subscriptions/{}/providers/microsoft.security/locations/{}/alerts/{}` | `SubscriptionSecurityAlert` | `LocationsAlerts` |
| `/subscriptions/{}/providers/microsoft.security/locations/{}/tasks/{}` | `SubscriptionSecurityTask` | `LocationsTasks` |
| `/subscriptions/{}/providers/microsoft.security/pricings/{}/securityoperators/{}` | `SecurityOperator` | `PricingsSecurityOperators` |
| `/subscriptions/{}/providers/microsoft.security/securescores/{}` | `SecureScore` | `SecureScoreItem` |
| `/subscriptions/{}/providers/microsoft.security/settings/{}` | `SecuritySetting` | `Setting` |
| `/subscriptions/{}/providers/microsoft.security/workspacesettings/{}` | `SecurityWorkspaceSetting` | `WorkspaceSetting` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/providers/microsoft.security/apicollections/{}` | `ApiCollection` | `ExternalResourceApiCollection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/assignments/{}` | `SecurityCenterAssignment` | `Assignment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/automations/{}` | `SecurityAutomation` | `Automation` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/iotsecuritysolutions/{}` | `IotSecuritySolution` | `IoTSecuritySolutionModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/iotsecuritysolutions/{}/analyticsmodels/default` | `IotSecuritySolutionAnalyticsModel` | `IoTSecuritySolutionAnalyticsModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/iotsecuritysolutions/{}/analyticsmodels/default/aggregatedalerts/{}` | `IotSecurityAggregatedAlert` | `IoTSecurityAggregatedAlert` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/iotsecuritysolutions/{}/analyticsmodels/default/aggregatedrecommendations/{}` | `IotSecurityAggregatedRecommendation` | `IoTSecurityAggregatedRecommendation` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/alerts/{}` | `ResourceGroupSecurityAlert` | `LocationsAlerts` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/allowedconnections/{}` | `SecurityCenterAllowedConnection` | `AllowedConnectionsResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/tasks/{}` | `ResourceGroupSecurityTask` | `LocationsTasks` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/locations/{}/topologies/{}` | `SecurityTopology` | `TopologyResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/privatelinks/{}/privateendpointconnections/{}` | `PrivateEndpointConnection` | `PrivateLinkResourcePrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/privatelinks/{}/privatelinkresources/{}` | `PrivateLinkGroup` | `PrivateLinkGroupResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default` | `DevOpsConfiguration` | `SecurityConnectorsDevops` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/azuredevopsorgs/{}` | `AzureDevOpsOrg` | `DevopsAzureDevOpsOrgs` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/azuredevopsorgs/{}/projects/{}` | `AzureDevOpsProject` | `AzureDevOpsOrgsProjects` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/azuredevopsorgs/{}/projects/{}/repos/{}` | `AzureDevOpsRepository` | `ProjectsRepos` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/githubowners/{}` | `GitHubOwner` | `DevopsGitHubOwners` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/githubowners/{}/repos/{}` | `GitHubRepository` | `GitHubOwnersRepos` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/gitlabgroups/{}` | `GitLabGroup` | `DevopsGitLabGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/securityconnectors/{}/devops/default/gitlabgroups/{}/projects/{}` | `GitLabProject` | `GitLabGroupsProjects` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.security/standards/{}` | `SecurityCenterStandard` | `Standard` |
| `/{}/providers/microsoft.security/assessments/{}` | `SecurityAssessment` | `SecurityAssessmentResponsesScopeParameterSecurityAssessmentResponse` |
| `/{}/providers/microsoft.security/compliances/{}` | `SecurityCompliance` | `Compliance` |
| `/{}/providers/microsoft.security/pricings/{}` | `SecurityCenterPricing` | `Pricing` |
| `/{}/providers/microsoft.security/sqlvulnerabilityassessments/default/baselinerules/{}` | `SqlVulnerabilityAssessmentBaselineRule` | `RuleResults` |
| `/{}/providers/microsoft.security/sqlvulnerabilityassessments/default/scans/{}` | `SqlVulnerabilityAssessmentScan` | `ScanV2` |
| `/{}/providers/microsoft.security/sqlvulnerabilityassessments/default/scans/{}/scanresults/{}` | `SqlVulnerabilityAssessmentScanResult` | `ScanResult` |
| `/{}/providers/microsoft.security/standardassignments/{}` | `StandardAssignment` | `ResourceIdScopeParameterStandardAssignment` |

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

