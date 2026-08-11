# ARM provider schema comparison: Azure.ResourceManager.Hci.Vm

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 2 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 17 matching normalized patterns; 0 legacy-only; 2 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 2 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 2 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/natGateways/{}/inboundRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/snapshots/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/networkInterfaces/{}`
  - resolveArmResources-only: `Microsoft.AzureStackHCI.NetworkInterfaces.updateOld (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/networkInterfaces/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/networkInterfaces/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{}`
  - resolveArmResources-only: `Microsoft.AzureStackHCI.VirtualHardDisks.updateOld (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/{}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default`
  - resolveArmResources-only: `Microsoft.AzureStackHCI.VirtualMachineInstances.powerOff (Action) /{}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default/powerOff [Extension: /{}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
