# ARM provider schema comparison: Azure.ResourceManager.FrontDoor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

6 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 6 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 6 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 0 | None. |
| Legacy only | 6 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/frontendEndpoints/{frontendEndpointName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/rulesEngines/{rulesEngineName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{policyName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}` |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 35 non-resource method difference(s) were found.

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Network.Experiments.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}` | Missing. | Present. |
| `Microsoft.Network.Experiments.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}` | Missing. | Present. |
| `Microsoft.Network.Experiments.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}` | Missing. | Present. |
| `Microsoft.Network.Experiments.getLatencyScorecards` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/latencyScorecard` | Missing. | Present. |
| `Microsoft.Network.Experiments.getTimeseries` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/timeseries` | Missing. | Present. |
| `Microsoft.Network.Experiments.listByProfile` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments` | Missing. | Present. |
| `Microsoft.Network.Experiments.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.list` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/frontDoors` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.listByResourceGroup` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.purgeContent` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/purge` | Missing. | Present. |
| `Microsoft.Network.FrontDoors.validateCustomDomain` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/validateCustomDomain` | Missing. | Present. |
| `Microsoft.Network.FrontendEndpoints.disableHttps` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/frontendEndpoints/{frontendEndpointName}/disableHttps` | Missing. | Present. |
| `Microsoft.Network.FrontendEndpoints.enableHttps` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/frontendEndpoints/{frontendEndpointName}/enableHttps` | Missing. | Present. |
| `Microsoft.Network.FrontendEndpoints.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/frontendEndpoints/{frontendEndpointName}` | Missing. | Present. |
| `Microsoft.Network.FrontendEndpoints.listByFrontDoor` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/frontendEndpoints` | Missing. | Present. |
| `Microsoft.Network.Profiles.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.Profiles.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.Profiles.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.Profiles.list` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/NetworkExperimentProfiles` | Missing. | Present. |
| `Microsoft.Network.Profiles.listByResourceGroup` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles` | Missing. | Present. |
| `Microsoft.Network.Profiles.preconfiguredEndpointsList` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/preconfiguredEndpoints` | Missing. | Present. |
| `Microsoft.Network.Profiles.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}` | Missing. | Present. |
| `Microsoft.Network.RulesEngines.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/rulesEngines/{rulesEngineName}` | Missing. | Present. |
| `Microsoft.Network.RulesEngines.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/rulesEngines/{rulesEngineName}` | Missing. | Present. |
| `Microsoft.Network.RulesEngines.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/rulesEngines/{rulesEngineName}` | Missing. | Present. |
| `Microsoft.Network.RulesEngines.listByFrontDoor` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/rulesEngines` | Missing. | Present. |
| `Microsoft.Network.WebApplicationFirewallPolicies.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{policyName}` | Missing. | Present. |
| `Microsoft.Network.WebApplicationFirewallPolicies.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{policyName}` | Missing. | Present. |
| `Microsoft.Network.WebApplicationFirewallPolicies.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{policyName}` | Missing. | Present. |
| `Microsoft.Network.WebApplicationFirewallPolicies.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies` | Missing. | Present. |
| `Microsoft.Network.WebApplicationFirewallPolicies.listBySubscription` | `/subscriptions/{subscriptionId}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies` | Missing. | Present. |
| `Microsoft.Network.WebApplicationFirewallPolicies.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/{policyName}` | Missing. | Present. |

## Bicep reference validation

Resource type validity was checked against the public Bicep reference by opening `https://learn.microsoft.com/en-us/azure/templates/{resourceType}?pivots=deployment-language-bicep`. For resources that exist, the Bicep API versions were compared with this package's generated API versions.

| Metric | Count |
| --- | ---: |
| Checked rows | 6 |
| Found in Bicep reference | 6 |
| Found in package API version | 6 |
| Found only outside package API versions | 0 |
| Not found in Bicep reference | 0 |

**Result:** All six legacy-only resource types are real ARM resources and are present in the same package API version (`2025-11-01`). This supports that `resolveArmResources` missed real resources rather than legacy detecting false resources.

The TypeSpec uses converted legacy custom-resource bases marked with `@Azure.ResourceManager.Legacy.customAzureResource(#{ isAzureResource: true })`, e.g. `Resource`, `BasicResource`, and `BasicResourceWithSettableIDName`. `resolveArmResources` returns zero resources and leaves all resource operations as non-resource methods, matching the same root cause as Network and TrafficManager.

| Resource type | Bicep API versions | Package resource API versions |
| --- | --- | --- |
| [Microsoft.Network/frontDoors](https://learn.microsoft.com/en-us/azure/templates/microsoft.network/frontdoors?pivots=deployment-language-bicep) | `2025-11-01` | `2025-10-01`, `2025-11-01` |
| [Microsoft.Network/frontDoors/frontendEndpoints](https://learn.microsoft.com/en-us/azure/templates/microsoft.network/frontdoors/frontendendpoints?pivots=deployment-language-bicep) | `2025-11-01` | `2025-10-01`, `2025-11-01` |
| [Microsoft.Network/frontDoors/rulesEngines](https://learn.microsoft.com/en-us/azure/templates/microsoft.network/frontdoors/rulesengines?pivots=deployment-language-bicep) | `2020-05-01`, `2020-06-01`, `2025-11-01` | `2025-10-01`, `2025-11-01` |
| [Microsoft.Network/FrontDoorWebApplicationFirewallPolicies](https://learn.microsoft.com/en-us/azure/templates/microsoft.network/frontdoorwebapplicationfirewallpolicies?pivots=deployment-language-bicep) | `2020-06-01`, `2020-11-01`, `2025-11-01` | `2025-10-01`, `2025-11-01` |
| [Microsoft.Network/NetworkExperimentProfiles](https://learn.microsoft.com/en-us/azure/templates/microsoft.network/networkexperimentprofiles?pivots=deployment-language-bicep) | `2025-11-01` | `2025-10-01`, `2025-11-01` |
| [Microsoft.Network/NetworkExperimentProfiles/Experiments](https://learn.microsoft.com/en-us/azure/templates/microsoft.network/networkexperimentprofiles/experiments?pivots=deployment-language-bicep) | `2025-11-01` | `2025-10-01`, `2025-11-01` |
