# ARM provider schema comparison: Azure.ResourceManager.TrafficManager

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

7 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 7 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 7 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 15 resolve-only |


### Legacy-only normalized resource ID patterns

- `/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default`
- `/subscriptions/{}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/AzureEndpoints/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/ExternalEndpoints/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/heatMaps/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/NestedEndpoints/{}`


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

- `Microsoft.Network.Endpoints.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/{}/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Endpoints.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/{}/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Endpoints.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/{}/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Endpoints.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/{}/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.HeatMapModels.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}/heatMaps/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.listBySubscription (/subscriptions/{}/providers/Microsoft.Network/trafficmanagerprofiles) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.Profiles.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/trafficmanagerprofiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.TrafficManagerGeographicHierarchies.getDefault (/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default) Tenant`
- `Microsoft.Network.UserMetricsModels.createOrUpdate (/subscriptions/{}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.UserMetricsModels.delete (/subscriptions/{}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.UserMetricsModels.get (/subscriptions/{}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
