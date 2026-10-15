# ARM resource shape comparison: Azure.ResourceManager.ComputeBulkActions

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 1 |
| resolveArmResources resources | 2 |
| Matching normalized resource IDs | 1 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 1 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 1 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/subscriptions/{}/providers/Microsoft.ComputeBulkActions/locations/{}/operations/{}` | resourceId=`/subscriptions/{subscriptionId}/providers/Microsoft.ComputeBulkActions/locations/{location}/operations/{id}`<br>resourceType=`Microsoft.ComputeBulkActions/locations/operations`<br>parent=_none_<br>scope=`kind=Subscription`; `id=/subscriptions/{subscriptionId}`; `type=Microsoft.Resources/subscriptions`<br>Read=`Microsoft.ComputeBulkActions.BulkActions.getOperationStatus /subscriptions/{subscriptionId}/providers/Microsoft.ComputeBulkActions/locations/{location}/operations/{id} [Subscription, /subscriptions/{subscriptionId}/providers/Microsoft.ComputeBulkActions/locations/{location}/operations/{id}, Microsoft.Resources/subscriptions]`<br>Create=_none_ |

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ComputeBulkActions/locations/{}/launchBulkInstancesOperations/{}` | scope | `kind=ResourceGroup`<br>`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`<br>`type=Microsoft.Resources/resourceGroups` | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`<br>`type=Microsoft.Resources/resourceGroups` |
