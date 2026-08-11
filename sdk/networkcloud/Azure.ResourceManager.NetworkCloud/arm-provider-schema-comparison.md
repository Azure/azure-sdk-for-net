# ARM provider schema comparison: Azure.ResourceManager.NetworkCloud

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 21 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 3 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{}`
  - resolveArmResources-only: `Microsoft.NetworkCloud.BareMetalMachines.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.NetworkCloud.BareMetalMachines.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/racks/{}`
  - resolveArmResources-only: `Microsoft.NetworkCloud.Racks.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/racks/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/racks/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.NetworkCloud.Racks.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/racks/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/racks/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/storageAppliances/{}`
  - resolveArmResources-only: `Microsoft.NetworkCloud.StorageAppliances.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/storageAppliances/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/storageAppliances/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.NetworkCloud.StorageAppliances.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/storageAppliances/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/storageAppliances/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{}`
  - resolveArmResources-only: `Microsoft.NetworkCloud.BareMetalMachines.reimageOld (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{}/reimageOld [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.NetworkCloud/bareMetalMachines/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
