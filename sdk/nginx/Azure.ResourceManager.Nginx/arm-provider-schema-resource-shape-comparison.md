# ARM resource shape comparison: Azure.ResourceManager.Nginx

This report compares only resource-shape fields from the current snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other methods and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still reported as a separate axis for matched rows.

## Summary

| Metric | Count |
| --- | ---: |
| Legacy resources | 5 |
| resolveArmResources resources | 5 |
| Matching normalized resource IDs | 5 |
| Legacy-only normalized resource IDs | 0 |
| resolveArmResources-only normalized resource IDs | 0 |
| Exact resource ID differences on matched resources | 0 |
| ARM resource type differences | 0 |
| Parent differences | 0 |
| Scope differences | 0 |
| Read lifecycle differences | 0 |
| Create lifecycle differences | 4 |

## Legacy-only resources

None.

## resolveArmResources-only resources

None.

## Matched resource-shape differences

| Normalized resource ID | Axis | Legacy | resolveArmResources |
| --- | --- | --- | --- |
| `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}` | create | `Nginx.NginxPlus.NginxDeployments.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}, Microsoft.Resources/resourceGroups]` | _none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/certificates/{}` | create | `Nginx.NginxPlus.NginxCertificates.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/certificates/{certificateName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/certificates/{certificateName}, Microsoft.Resources/resourceGroups]` | _none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/configurations/{}` | create | `Nginx.NginxPlus.NginxConfigurationResponses.createOrUpdate /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName}, Microsoft.Resources/resourceGroups]` | _none_ |
| `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/wafPolicies/{}` | create | `Nginx.NginxPlus.NginxDeploymentWafPolicies.create /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/wafPolicies/{wafPolicyName} [ResourceGroup, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/wafPolicies/{wafPolicyName}, Microsoft.Resources/resourceGroups]` | _none_ |
