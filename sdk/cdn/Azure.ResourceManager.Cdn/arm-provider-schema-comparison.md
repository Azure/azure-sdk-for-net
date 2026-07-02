# ARM provider schema comparison: Azure.ResourceManager.Cdn

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 CRUD operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 20 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 20 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Cdn.RuleSets.createV1` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/ruleSets/{ruleSetName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 18 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/afdendpoints/{}` | `FrontDoorEndpoint` | `AFDEndpoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/afdendpoints/{}/routes/{}` | `FrontDoorRoute` | `Route` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/agents/{}` | `CdnProfileAgent` | `ProfileAgent` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/customdomains/{}` | `FrontDoorCustomDomain` | `AFDDomain` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/deploymentversions/{}` | `CdnDeploymentVersion` | `DeploymentVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/endpoints/{}` | `CdnEndpoint` | `Endpoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/endpoints/{}/customdomains/{}` | `CdnCustomDomain` | `CustomDomain` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/endpoints/{}/origingroups/{}` | `CdnOriginGroup` | `OriginGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/endpoints/{}/origins/{}` | `CdnOrigin` | `Origin` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/keygroups/{}` | `CdnKeyGroup` | `KeyGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/origingroups/{}` | `FrontDoorOriginGroup` | `AFDOriginGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/origingroups/{}/origins/{}` | `FrontDoorOrigin` | `AFDOrigin` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/rulesets/{}` | `FrontDoorRuleSet` | `RuleSet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/rulesets/{}/rules/{}` | `FrontDoorRule` | `Rule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/secrets/{}` | `FrontDoorSecret` | `Secret` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/profiles/{}/securitypolicies/{}` | `FrontDoorSecurityPolicy` | `SecurityPolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/webagents/{}` | `CdnWebAgent` | `WebAgent` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cdn/webagents/{}/knowledgesources/{}` | `CdnWebAgentKnowledgeSource` | `KnowledgeSource` |

