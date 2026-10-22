# ARM provider schema comparison: Azure.ResourceManager.GuestConfiguration

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 4 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 4 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 24 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}`


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

- `Microsoft.GuestConfiguration.GuestConfigurationAssignments.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignments.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignments.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignments.guestConfigurationAssignmentReportsGet (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignments.guestConfigurationAssignmentReportsList (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignments.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachines/{}: Microsoft.Compute/virtualMachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}: Microsoft.Compute/virtualMachineScaleSets]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}: Microsoft.Compute/virtualMachineScaleSets]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}: Microsoft.Compute/virtualMachineScaleSets]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.guestConfigurationAssignmentReportsVMSSGet (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}: Microsoft.Compute/virtualMachineScaleSets]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.guestConfigurationAssignmentReportsVMSSList (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}: Microsoft.Compute/virtualMachineScaleSets]`
- `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}: Microsoft.Compute/virtualMachineScaleSets]`
- `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}: Microsoft.ConnectedVMwarevSphere/virtualmachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}: Microsoft.ConnectedVMwarevSphere/virtualmachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}: Microsoft.ConnectedVMwarevSphere/virtualmachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.guestConfigurationConnectedVMwarevSphereAssignmentsReportsGet (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}: Microsoft.ConnectedVMwarevSphere/virtualmachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.guestConfigurationConnectedVMwarevSphereAssignmentsReportsList (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}: Microsoft.ConnectedVMwarevSphere/virtualmachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{}: Microsoft.ConnectedVMwarevSphere/virtualmachines]`
- `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}: Microsoft.HybridCompute/machines]`
- `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}: Microsoft.HybridCompute/machines]`
- `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}: Microsoft.HybridCompute/machines]`
- `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.guestConfigurationHCRPAssignmentReportsGet (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}: Microsoft.HybridCompute/machines]`
- `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.guestConfigurationHCRPAssignmentReportsList (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{}/reports) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}: Microsoft.HybridCompute/machines]`
- `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HybridCompute/machines/{}: Microsoft.HybridCompute/machines]`
