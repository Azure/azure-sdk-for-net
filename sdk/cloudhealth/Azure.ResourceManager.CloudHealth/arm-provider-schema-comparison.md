# ARM provider schema comparison: Azure.ResourceManager.CloudHealth

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 6 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 5 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/authenticationsettings/{}`
  - resolveArmResources-only: `Microsoft.CloudHealth.AuthenticationSettings.createOrUpdateV1 (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/authenticationsettings/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/authenticationsettings/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.CloudHealth.AuthenticationSettings.deleteV1 (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/authenticationsettings/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/authenticationsettings/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/discoveryrules/{}`
  - resolveArmResources-only: `Microsoft.CloudHealth.DiscoveryRules.createOrUpdateV1 (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/discoveryrules/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/discoveryrules/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.CloudHealth.DiscoveryRules.deleteV1 (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/discoveryrules/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/discoveryrules/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/entities/{}`
  - resolveArmResources-only: `Microsoft.CloudHealth.Entities.createOrUpdateV1 (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/entities/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/entities/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.CloudHealth.Entities.deleteV1 (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/entities/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/entities/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/relationships/{}`
  - resolveArmResources-only: `Microsoft.CloudHealth.Relationships.createOrUpdateV1 (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/relationships/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/relationships/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.CloudHealth.Relationships.deleteV1 (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/relationships/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/relationships/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/signaldefinitions/{}`
  - resolveArmResources-only: `Microsoft.CloudHealth.SignalDefinitions.createOrUpdateV1 (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/signaldefinitions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/signaldefinitions/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.CloudHealth.SignalDefinitions.deleteV1 (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/signaldefinitions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.CloudHealth/healthmodels/{}/signaldefinitions/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

None.


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
