# ARM provider schema comparison: Azure.ResourceManager.Compute

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 35 matching normalized patterns; 2 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 2 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 1 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/extensions/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/extensions/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}`
  - resolveArmResources-only: `Compute.VirtualMachineScaleSetExtensions.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetExtensions.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetExtensions.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetExtensions.list (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/extensions [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetExtensions.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}`
  - resolveArmResources-only: `Compute.VirtualMachineScaleSetVMExtensions.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetVMExtensions.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetVMExtensions.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetVMExtensions.list (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/extensions [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}, Microsoft.Resources/resourceGroups]`; `Compute.VirtualMachineScaleSetVMExtensions.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Compute.Operations.list (/providers/Microsoft.Compute/operations) Tenant`
