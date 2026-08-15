# ARM provider schema comparison: Azure.ResourceManager.ApplicationInsights

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 4 matching normalized patterns; 2 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 2 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 52 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/webtests/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

None.


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `AnalyticsItems.AnalyticsItemsOperationGroup.delete (/subscriptions/{}/resourceGroups/{}/providers/microsoft.insights/components/{}/{}/item) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `AnalyticsItems.AnalyticsItemsOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/microsoft.insights/components/{}/{}/item) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `AnalyticsItems.AnalyticsItemsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/microsoft.insights/components/{}/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `AnalyticsItems.AnalyticsItemsOperationGroup.put (/subscriptions/{}/resourceGroups/{}/providers/microsoft.insights/components/{}/{}/item) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.AnnotationsOperationGroup.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/Annotations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.AnnotationsOperationGroup.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/Annotations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.AnnotationsOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/Annotations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.AnnotationsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/Annotations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.APIKeysOperationGroup.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/ApiKeys) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.APIKeysOperationGroup.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/APIKeys/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.APIKeysOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/APIKeys/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.APIKeysOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/ApiKeys) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ComponentAvailableFeaturesOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/getavailablebillingfeatures) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ComponentCurrentBillingFeaturesOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/currentbillingfeatures) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ComponentCurrentBillingFeaturesOperationGroup.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/currentbillingfeatures) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ComponentFeatureCapabilitiesOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/featurecapabilities) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ComponentQuotaStatusOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/quotastatus) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ExportConfigurationsOperationGroup.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/exportconfiguration) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ExportConfigurationsOperationGroup.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/exportconfiguration/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ExportConfigurationsOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/exportconfiguration/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ExportConfigurationsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/exportconfiguration) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ExportConfigurationsOperationGroup.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/exportconfiguration/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ProactiveDetectionConfigurationsOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/ProactiveDetectionConfigs/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ProactiveDetectionConfigurationsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/ProactiveDetectionConfigs) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.ProactiveDetectionConfigurationsOperationGroup.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/ProactiveDetectionConfigs/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.WorkItemConfigurationsOperationGroup.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/WorkItemConfigs) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.WorkItemConfigurationsOperationGroup.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/WorkItemConfigs/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.WorkItemConfigurationsOperationGroup.getDefault (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/DefaultWorkItemConfig) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.WorkItemConfigurationsOperationGroup.getItem (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/WorkItemConfigs/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.WorkItemConfigurationsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/WorkItemConfigs) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `ComponentAPIs.WorkItemConfigurationsOperationGroup.updateItem (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/WorkItemConfigs/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ApplicationInsightsComponents.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ApplicationInsightsComponents.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ApplicationInsightsComponents.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ApplicationInsightsComponents.list (/subscriptions/{}/providers/Microsoft.Insights/components) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Components.ApplicationInsightsComponents.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ApplicationInsightsComponents.purge (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/purge) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ApplicationInsightsComponents.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Components.ComponentPurgeStatusOperationGroup.getPurgeStatus (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/operations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Favorites.FavoritesOperationGroup.add (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/favorites/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Favorites.FavoritesOperationGroup.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/favorites/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Favorites.FavoritesOperationGroup.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/favorites/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Favorites.FavoritesOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/favorites) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Favorites.FavoritesOperationGroup.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/favorites/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestLocation.webTestLocationsOperationGroup.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/syntheticmonitorlocations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestsApi.WebTests.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/webtests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestsApi.WebTests.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/webtests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestsApi.WebTests.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/webtests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestsApi.WebTests.list (/subscriptions/{}/providers/Microsoft.Insights/webtests) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `WebTestsApi.WebTests.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/webtests) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestsApi.WebTests.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/webtests/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `WebTestsApi.WebTestsOperationGroup.listByComponent (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Insights/components/{}/webtests) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
