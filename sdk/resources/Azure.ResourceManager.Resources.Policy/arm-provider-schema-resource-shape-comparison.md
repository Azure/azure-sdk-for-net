# ARM resource shape comparison: Azure.ResourceManager.Resources.Policy

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 9 |
| resolveArmResources resources | 19 |
| Matching normalized resource IDs | 9 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 10 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 2 |
| Scope differences | 2 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 0 |

## Legacy-only resources

None.

## resolveArmResources-only resources

| Normalized resource ID | Resource shape |
| --- | --- |
| `/providers/Microsoft.Authorization/policyDefinitions/{}` | resourceId=`/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}`<br>resourceType=`Microsoft.Authorization/policyDefinitions`<br>parent=_none_<br>scope=`kind=Tenant`; `type=Microsoft.Resources/tenants`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Authorization/policyDefinitions/{}/versions/{}` | resourceId=`/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/versions/{policyDefinitionVersion}`<br>resourceType=`Microsoft.Authorization/policyDefinitions/versions`<br>parent=`id=/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}`<br>scope=`kind=Tenant`; `type=Microsoft.Resources/tenants`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Authorization/policySetDefinitions/{}` | resourceId=`/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}`<br>resourceType=`Microsoft.Authorization/policySetDefinitions`<br>parent=_none_<br>scope=`kind=Tenant`; `type=Microsoft.Resources/tenants`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Authorization/policySetDefinitions/{}/versions/{}` | resourceId=`/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/versions/{policyDefinitionVersion}`<br>resourceType=`Microsoft.Authorization/policySetDefinitions/versions`<br>parent=`id=/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}`<br>scope=`kind=Tenant`; `type=Microsoft.Resources/tenants`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policyDefinitions/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}`<br>resourceType=`Microsoft.Authorization/policyDefinitions`<br>parent=_none_<br>scope=`kind=ManagementGroup`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policyDefinitions/{}/versions/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/versions/{policyDefinitionVersion}`<br>resourceType=`Microsoft.Authorization/policyDefinitions/versions`<br>parent=`id=/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}`<br>scope=`kind=Tenant`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupName}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policySetDefinitions/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}`<br>resourceType=`Microsoft.Authorization/policySetDefinitions`<br>parent=_none_<br>scope=`kind=ManagementGroup`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/policySetDefinitions/{}/versions/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/versions/{policyDefinitionVersion}`<br>resourceType=`Microsoft.Authorization/policySetDefinitions/versions`<br>parent=`id=/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}`<br>scope=`kind=Tenant`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupName}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/variables/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/variables/{variableName}`<br>resourceType=`Microsoft.Authorization/variables`<br>parent=_none_<br>scope=`kind=ManagementGroup`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |
| `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Authorization/variables/{}/values/{}` | resourceId=`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/variables/{variableName}/values/{variableValueName}`<br>resourceType=`Microsoft.Authorization/variables/values`<br>parent=`id=/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/variables/{variableName}`<br>scope=`kind=Subscription`; `id=/providers/Microsoft.Management/managementGroups/{managementGroupId}`; `type=Microsoft.Management/managementGroups`<br>Read=_none_<br>Create=_none_ |

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/providers/Microsoft.Authorization/policyDefinitions/{}/versions/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}` | `id=/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}` |
| `/subscriptions/{}/providers/Microsoft.Authorization/policyDefinitions/{}/versions/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Tenant`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/Microsoft.Authorization/policySetDefinitions/{}/versions/{}` | parent | `id=/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}` | `id=/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}` |
| `/subscriptions/{}/providers/Microsoft.Authorization/policySetDefinitions/{}/versions/{}` | scope | `kind=Subscription`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` | `kind=Tenant`<br>`id=/subscriptions/{subscriptionId}`<br>`type=Microsoft.Resources/subscriptions` |
