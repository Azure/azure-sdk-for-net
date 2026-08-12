# ARM resource shape comparison: Azure.ResourceManager.Sql

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 127 |
| resolveArmResources resources | 126 |
| Matching normalized resource IDs | 125 |
| Legacy-only normalized resource IDs | 2 |
| resolveArmResources-only normalized resource IDs | 1 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 5 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 2 |

## Legacy-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/servers/{}/firewallRules/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}`<br>resourceType=`Microsoft.Sql/servers/firewallRules`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=`Microsoft.Sql.FirewallRules.get /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}, Microsoft.Resources/resourceGroups]`<br>Create=`Microsoft.Sql.FirewallRules.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}, Microsoft.Resources/resourceGroups]` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/servers/{}/ipv6FirewallRules/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}`<br>resourceType=`Microsoft.Sql/servers/ipv6FirewallRules`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=`Microsoft.Sql.IPv6FirewallRules.get /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}, Microsoft.Resources/resourceGroups]`<br>Create=`Microsoft.Sql.IPv6FirewallRules.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}, Microsoft.Resources/resourceGroups]` |

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/servers/{}/databases/{}/extensions/{}` | resourceId=`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extensions/{extensionName}`<br>resourceType=`Microsoft.Sql/servers/databases/extensions`<br>parent=`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}`<br>scope=`kind=ResourceGroup`; `id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`; `type=Microsoft.Resources/resourceGroups`<br>Read=_none_<br>Create=`Microsoft.Sql.ImportExportExtensionsOperationResults.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extensions/{extensionName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extensions/{extensionName}, Microsoft.Resources/resourceGroups]` |

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/providers/Microsoft.Sql/locations/{}/deletedServers/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=ResourceGroup`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/Microsoft.Sql/locations/{}/timeZones/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=ResourceGroup`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/Microsoft.Sql/locations/{}/usages/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=ResourceGroup`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/locations/{}/longTermRetentionManagedInstances/{}/longTermRetentionDatabases/{}/longTermRetentionManagedInstanceBackups/{}` | scope | `kind=ResourceGroup`<br>`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`<br>`type=Microsoft.Resources/resourceGroups` | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`<br>`type=Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/locations/{}/longTermRetentionServers/{}/longTermRetentionDatabases/{}/longTermRetentionBackups/{}` | scope | `kind=ResourceGroup`<br>`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`<br>`type=Microsoft.Resources/resourceGroups` | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`<br>`type=Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/managedInstances/{}/databases/{}/schemas/{}/tables/{}/columns/{}/sensitivityLabels/{}` | create | _none_ | `Microsoft.Sql.SensitivityLabels.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}, Microsoft.Resources/resourceGroups]` |
| `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Sql/servers/{}/databases/{}/schemas/{}/tables/{}/columns/{}/sensitivityLabels/{}` | create | _none_ | `Microsoft.Sql.SensitivityLabelOperationGroup.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}, Microsoft.Resources/resourceGroups]` |
