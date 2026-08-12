# ARM resource shape comparison: Azure.ResourceManager.AppContainers

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 41 |
| resolveArmResources resources | 41 |
| Matching normalized resource IDs | 41 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 2 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 2 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}/daprComponents/{}` | create | `Microsoft.App.ConnectedEnvironmentsDaprComponents.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/daprComponents/{componentName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/daprComponents/{componentName}, Microsoft.Resources/resourceGroups]` | _none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/containerApps/{}/detectorProperties/revisionsApi/revisions/{}` | parent | `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}` | `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/detectorProperties/rootApi/` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/containerApps/{}/providers/Microsoft.App/logicApps/{}` | parent | `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}` | _none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/managedCertificates/{}` | create | `Microsoft.App.ManagedCertificates.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/managedCertificates/{managedCertificateName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/managedCertificates/{managedCertificateName}, Microsoft.Resources/resourceGroups]` | _none_ |
