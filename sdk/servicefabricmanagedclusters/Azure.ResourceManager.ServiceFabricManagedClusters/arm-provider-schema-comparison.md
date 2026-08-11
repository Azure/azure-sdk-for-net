# ARM provider schema comparison: Azure.ResourceManager.ServiceFabricManagedClusters

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
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 2 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}`
  - resolveArmResources-only: `Microsoft.ServiceFabric.ManagedApplyMaintenanceWindow.post (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/applyMaintenanceWindow [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.ManagedClusters.getFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/getFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.ManagedClusters.listFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/listFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.ManagedClusters.startFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/startFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.ManagedClusters.stopFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/stopFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}`
  - resolveArmResources-only: `Microsoft.ServiceFabric.NodeTypes.getFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}/getFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.NodeTypes.listFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}/listFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.NodeTypes.startFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}/startFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ServiceFabric.NodeTypes.stopFaultSimulation (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}/stopFaultSimulation [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ServiceFabric/managedClusters/{}/nodeTypes/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.ServiceFabric.OperationResults.get (/subscriptions/{}/providers/Microsoft.ServiceFabric/locations/{}/managedClusterOperationResults/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.ServiceFabric.OperationStatus.get (/subscriptions/{}/providers/Microsoft.ServiceFabric/locations/{}/managedClusterOperations/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
