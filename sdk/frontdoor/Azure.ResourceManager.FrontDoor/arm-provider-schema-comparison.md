# ARM provider schema comparison: Azure.ResourceManager.FrontDoor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

6 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 6 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 6 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 35 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/frontendEndpoints/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/rulesEngines/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}`


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

- `Microsoft.Network.Experiments.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Experiments.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Experiments.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Experiments.getLatencyScorecards (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}/latencyScorecard) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Experiments.getTimeseries (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}/timeseries) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Experiments.listByProfile (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Experiments.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/Experiments/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontDoors.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontDoors.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontDoors.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontDoors.list (/subscriptions/{}/providers/Microsoft.Network/frontDoors) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.FrontDoors.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontDoors.purgeContent (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/purge) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontDoors.validateCustomDomain (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/validateCustomDomain) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontendEndpoints.disableHttps (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/frontendEndpoints/{}/disableHttps) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontendEndpoints.enableHttps (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/frontendEndpoints/{}/enableHttps) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontendEndpoints.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/frontendEndpoints/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.FrontendEndpoints.listByFrontDoor (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/frontendEndpoints) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.list (/subscriptions/{}/providers/Microsoft.Network/NetworkExperimentProfiles) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.Profiles.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.preconfiguredEndpointsList (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}/preconfiguredEndpoints) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Profiles.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/NetworkExperimentProfiles/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.RulesEngines.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/rulesEngines/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.RulesEngines.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/rulesEngines/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.RulesEngines.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/rulesEngines/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.RulesEngines.listByFrontDoor (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/frontDoors/{}/rulesEngines) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.WebApplicationFirewallPolicies.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.WebApplicationFirewallPolicies.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.WebApplicationFirewallPolicies.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.WebApplicationFirewallPolicies.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.WebApplicationFirewallPolicies.listBySubscription (/subscriptions/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.WebApplicationFirewallPolicies.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
