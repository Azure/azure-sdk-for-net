# ARM resource shape comparison: Azure.ResourceManager.HorizonDB

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 7 |
| resolveArmResources resources | 6 |
| Matching normalized resource IDs | 6 |
| Legacy-only normalized resource IDs | 1 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HorizonDb/clusters/{}/privateEndpointConnections/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HorizonDb/clusters/{clusterName}/privateEndpointConnections/{privateEndpointConnectionName}`<br>resourceType=`Microsoft.HorizonDb/clusters/privateEndpointConnections`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HorizonDb/clusters/{clusterName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=`Microsoft.HorizonDb.HorizonDbPrivateEndpointConnections.get /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HorizonDb/clusters/{clusterName}/privateEndpointConnections/{privateEndpointConnectionName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HorizonDb/clusters/{clusterName}/privateEndpointConnections/{privateEndpointConnectionName}, Microsoft.Resources/resourceGroups]`<br>Create=_none_ |

## resolveArmResources-only resources

None.

## Matched resource-shape differences

None.
