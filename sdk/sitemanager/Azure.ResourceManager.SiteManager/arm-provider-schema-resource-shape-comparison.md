# ARM resource shape comparison: Azure.ResourceManager.SiteManager

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 3 |
| resolveArmResources resources | 3 |
| Matching normalized resource IDs | 3 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 1 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.Edge/sites/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{servicegroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{servicegroupName}`<br>`type=Microsoft.Management/serviceGroups` |
