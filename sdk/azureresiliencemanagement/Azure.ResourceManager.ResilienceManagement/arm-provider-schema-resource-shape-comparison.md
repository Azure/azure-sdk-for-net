# ARM resource shape comparison: Azure.ResourceManager.ResilienceManagement

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 14 |
| resolveArmResources resources | 14 |
| Matching normalized resource IDs | 14 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 12 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillResources/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/drillRunResources/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/goalAssignments/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/goalAssignments/{}/goalResources/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/goalTemplates/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}/recoveryJobResources/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryResources/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
| `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/unifiedResilienceItems/{}` | scope | `kind=Extension`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` | `kind=ResourceGroup`<br>`id=/providers/Microsoft.Management/serviceGroups/{serviceGroupName}`<br>`type=Microsoft.Management/serviceGroups` |
