# ARM provider schema comparison: Azure.ResourceManager.SecurityInsights

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 resource model difference; 5 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 41 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | 5 differences. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 41 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/threatintelligence/main/indicators/{}` | `Microsoft.SecurityInsights.ThreatIntelligenceInformation` | `Microsoft.SecurityInsights.ThreatIntelligenceInformation` | `Microsoft.SecurityInsights/threatIntelligence/indicators` | `Microsoft.SecurityInsights/indicators` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 5 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}/actions/{actionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.SecurityInsights.ActionResponses.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}/actions/{actionId}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.SecurityInsights.AutomationRules.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/entityQueries/{entityQueryId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.SecurityInsights.EntityQueries.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/entityQueries/{entityQueryId}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/onboardingStates/{sentinelOnboardingStateName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.SecurityInsights.SentinelOnboardingStates.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/onboardingStates/{sentinelOnboardingStateName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.SecurityInsights.ThreatIntelligenceInformationOperations.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.SecurityInsights.ActionResponses.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}/actions/{actionId}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 37 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 4 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/alertrules/{}` | `SecurityInsightsAlertRule` | `ExternalResourceAlertRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/alertrules/{}/actions/{}` | `SecurityInsightsAlertRuleAction` | `ExternalResourceActionResponse` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/alertruletemplates/{}` | `SecurityInsightsAlertRuleTemplate` | `ExternalResourceAlertRuleTemplate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/automationrules/{}` | `SecurityInsightsAutomationRule` | `ExternalResourceAutomationRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/billingstatistics/{}` | `SecurityInsightsBillingStatistic` | `ExternalResourceBillingStatistic` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/bookmarks/{}` | `SecurityInsightsBookmark` | `ExternalResourceBookmark` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/contentpackages/{}` | `SecurityInsightsPackage` | `ExternalResourcePackageModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/contentproductpackages/{}` | `SecurityInsightsProductPackage` | `ExternalResourceProductPackageModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/contentproducttemplates/{}` | `SecurityInsightsProductTemplate` | `WorkspacesContentproducttemplates` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/contenttemplates/{}` | `SecurityInsightsTemplate` | `ExternalResourceTemplateModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/dataconnectordefinitions/{}` | `SecurityInsightsDataConnectorDefinition` | `ExternalResourceDataConnectorDefinition` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/dataconnectors/{}` | `SecurityInsightsDataConnector` | `ExternalResourceDataConnector` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/entities/{}` | `SecurityInsightsEntity` | `ExternalResourceEntity` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/entityqueries/{}` | `SecurityInsightsEntityQuery` | `ExternalResourceEntityQuery` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/entityquerytemplates/{}` | `SecurityInsightsEntityQueryTemplate` | `ExternalResourceEntityQueryTemplate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/fileimports/{}` | `SecurityInsightsFileImport` | `ExternalResourceFileImport` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/hunts/{}` | `SecurityInsightsHunt` | `ExternalResourceHunt` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/hunts/{}/comments/{}` | `SecurityInsightsHuntComment` | `ExternalResourceHuntComment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/hunts/{}/relations/{}` | `SecurityInsightsHuntRelation` | `ExternalResourceHuntRelation` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/incidents/{}` | `SecurityInsightsIncident` | `ExternalResourceIncident` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/incidents/{}/comments/{}` | `SecurityInsightsIncidentComment` | `ExternalResourceIncidentComment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/incidents/{}/tasks/{}` | `SecurityInsightsIncidentTask` | `ExternalResourceIncidentTask` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/metadata/{}` | `SecurityInsightsMetadata` | `ExternalResourceMetadataModel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/officeconsents/{}` | `SecurityInsightsOfficeConsent` | `ExternalResourceOfficeConsent` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/onboardingstates/{}` | `SecurityInsightsSentinelOnboardingState` | `ExternalResourceSentinelOnboardingState` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/recommendations/{}` | `SecurityInsightsRecommendation` | `ExternalResourceRecommendation` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/securitymlanalyticssettings/{}` | `SecurityMLAnalyticsSetting` | `ExternalResourceSecurityMLAnalyticsSetting` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/settings/{}` | `SecurityInsightsSetting` | `ExternalResourceSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/sourcecontrols/{}` | `SecurityInsightsSourceControl` | `ExternalResourceSourceControl` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/triggeredanalyticsruleruns/{}` | `TriggeredAnalyticsRuleRun` | `ExternalResourceTriggeredAnalyticsRuleRun` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/watchlists/{}` | `SecurityInsightsWatchlist` | `ExternalResourceWatchlist` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/watchlists/{}/watchlistitems/{}` | `SecurityInsightsWatchlistItem` | `ExternalResourceWatchlistItem` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/workspacemanagerassignments/{}` | `WorkspaceManagerAssignment` | `ExternalResourceWorkspaceManagerAssignment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/workspacemanagerassignments/{}/jobs/{}` | `WorkspaceManagerAssignmentJob` | `ExternalResourceJob` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/workspacemanagerconfigurations/{}` | `WorkspaceManagerConfiguration` | `ExternalResourceWorkspaceManagerConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/workspacemanagergroups/{}` | `WorkspaceManagerGroup` | `ExternalResourceWorkspaceManagerGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.operationalinsights/workspaces/{}/providers/microsoft.securityinsights/workspacemanagermembers/{}` | `WorkspaceManagerMember` | `ExternalResourceWorkspaceManagerMember` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.SecurityInsights.AutomationRules.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}` | Missing. | Present. |
| `Microsoft.SecurityInsights.EntityQueries.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/entityQueries/{entityQueryId}` | Missing. | Present. |
| `Microsoft.SecurityInsights.SentinelOnboardingStates.create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/onboardingStates/{sentinelOnboardingStateName}` | Missing. | Present. |
| `Microsoft.SecurityInsights.ThreatIntelligenceInformationOperations.create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}` | Missing. | Present. |

