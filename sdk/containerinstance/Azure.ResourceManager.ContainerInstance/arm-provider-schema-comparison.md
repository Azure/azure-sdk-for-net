# ARM provider schema comparison: Azure.ResourceManager.ContainerInstance

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 3 matching normalized patterns; 1 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 1 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 13 resolve-only |


### Legacy-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}`


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

- `Microsoft.ContainerInstance.ContainerGroups.attach (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/containers/{}/attach) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.executeCommand (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/containers/{}/exec) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.getOutboundNetworkDependenciesEndpoints (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/outboundNetworkDependenciesEndpoints) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.listLogs (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/containers/{}/logs) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.restart (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/restart) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.start (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/start) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.stop (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}/stop) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroups.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.ContainerInstance.ContainerGroupsOperationGroup.list (/subscriptions/{}/providers/Microsoft.ContainerInstance/containerGroups) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.ContainerInstance.ContainerGroupsOperationGroup.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ContainerInstance/containerGroups) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
