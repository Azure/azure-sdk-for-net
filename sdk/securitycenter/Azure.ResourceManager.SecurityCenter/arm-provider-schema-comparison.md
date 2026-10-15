# ARM provider schema comparison: Azure.ResourceManager.SecurityCenter

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 legacy-only and 2 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 64 matching normalized patterns; 3 legacy-only; 2 resolve-only |
| Raw resource ID patterns | 3 legacy-only raw; 2 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 12 matching normalized patterns differ |
| Non-resource methods | 4 legacy-only; 7 resolve-only |


### Legacy-only normalized resource ID patterns

- `/{}/providers/Microsoft.Security/advancedThreatProtectionSettings/current`
- `/subscriptions/{}/providers/Microsoft.Security/locations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.Security/serverVulnerabilityAssessments/default`


### resolveArmResources-only normalized resource ID patterns

- `/{}/providers/Microsoft.Security/advancedThreatProtectionSettings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.Security/serverVulnerabilityAssessments/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/providers/Microsoft.Security/sensitivitySettings/current`
  - resolveArmResources-only: `SensitivitySettingsAPI.GetSensitivitySettingsResponses.list (List) /providers/Microsoft.Security/sensitivitySettings [Tenant: , Microsoft.Resources/tenants]`
- `/subscriptions/{}/providers/Microsoft.Security/locations/{}/alerts/{}`
  - legacy-only: `AlertsAPI.Alerts.listSubscriptionLevelByRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/alerts [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`; `AlertsAPI.AlertsOperationGroup.simulate (CollectionAction) /subscriptions/{}/providers/Microsoft.Security/locations/{}/alerts/default/simulate [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `AlertsAPI.Alerts.listSubscriptionLevelByRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/alerts [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/providers/Microsoft.Security/locations/{}/tasks/{}`
  - legacy-only: `TasksAPI.SecurityTasks.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/tasks [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `TasksAPI.SecurityTasks.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/tasks [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/providers/Microsoft.Security/mdeOnboardings/default`
  - resolveArmResources-only: `MdeOnboardingAPI.MdeOnboardings.list (List) /subscriptions/{}/providers/Microsoft.Security/mdeOnboardings [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiManagement/service/{}/providers/Microsoft.Security/apiCollections/{}`
  - resolveArmResources-only: `ApiCollectionsAPI.ApiCollections.listBySubscription (List) /subscriptions/{}/providers/Microsoft.Security/apiCollections [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/iotSecuritySolutions/{}`
  - legacy-only: `IoTSecurityAPI.IoTSecuritySolutionAnalyticsModels.list (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/iotSecuritySolutions/{}/analyticsModels [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/iotSecuritySolutions/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/iotSecuritySolutions/{}/analyticsModels/default`
  - resolveArmResources-only: `IoTSecurityAPI.IoTSecuritySolutionAnalyticsModels.list (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/iotSecuritySolutions/{}/analyticsModels [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/iotSecuritySolutions/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/locations/{}/allowedConnections/{}`
  - legacy-only: `SecuritySolutionsAPI.AllowedConnectionsResources.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/allowedConnections [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `SecuritySolutionsAPI.AllowedConnectionsResources.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/allowedConnections [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/locations/{}/discoveredSecuritySolutions/{}`
  - legacy-only: `SecuritySolutionsAPI.DiscoveredSecuritySolutions.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/discoveredSecuritySolutions [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `SecuritySolutionsAPI.DiscoveredSecuritySolutions.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/discoveredSecuritySolutions [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/locations/{}/jitNetworkAccessPolicies/{}`
  - legacy-only: `SecuritySolutionsAPI.JitNetworkAccessPolicies.listByRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/jitNetworkAccessPolicies [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `SecuritySolutionsAPI.JitNetworkAccessPolicies.listByRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/jitNetworkAccessPolicies [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/locations/{}/topologies/{}`
  - legacy-only: `SecuritySolutionsAPI.TopologyResources.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/topologies [Subscription: /subscriptions/{}/providers/Microsoft.Security/locations/{}, Microsoft.Resources/subscriptions]`
  - resolveArmResources-only: `SecuritySolutionsAPI.TopologyResources.listByHomeRegion (List) /subscriptions/{}/providers/Microsoft.Security/locations/{}/topologies [Subscription: /subscriptions/{}, Microsoft.Resources/subscriptions]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/privateLinks/{}`
  - legacy-only: `PrivateLinksAPI.PrivateLinkResources.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/privateLinks/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/privateLinks/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

- `ApiCollectionsAPI.ApiCollections.listBySubscription (/subscriptions/{}/providers/Microsoft.Security/apiCollections) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `MdeOnboardingAPI.MdeOnboardings.list (/subscriptions/{}/providers/Microsoft.Security/mdeOnboardings) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `SecuritySolutionsAPI.ServerVulnerabilityAssessments.listByExtendedResource (/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/providers/Microsoft.Security/serverVulnerabilityAssessments) Extension [/subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}: ]`
- `SensitivitySettingsAPI.GetSensitivitySettingsResponses.list (/providers/Microsoft.Security/sensitivitySettings) Tenant`


### resolveArmResources-only non-resource methods

- `AlertsAPI.AlertsOperationGroup.simulate (/subscriptions/{}/providers/Microsoft.Security/locations/{}/alerts/default/simulate) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `LocationsAPI.AscLocations.get (/subscriptions/{}/providers/Microsoft.Security/locations/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `LocationsAPI.AscLocations.list (/subscriptions/{}/providers/Microsoft.Security/locations) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `OperationsAPI.OperationResultsOperationGroup.get (/subscriptions/{}/providers/Microsoft.Security/locations/{}/operationResults/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `PrivateLinksAPI.PrivateLinkResources.head (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Security/privateLinks/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `SecuritySolutionsAPI.ExternalSecuritySolutions.listByHomeRegion (/subscriptions/{}/providers/Microsoft.Security/locations/{}/ExternalSecuritySolutions) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `SecuritySolutionsAPI.SecuritySolutionsReferenceDataOperationGroup.listByHomeRegion (/subscriptions/{}/providers/Microsoft.Security/locations/{}/securitySolutionsReferenceData) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
