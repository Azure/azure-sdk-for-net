# ARM provider schema comparison: Azure.ResourceManager.Nginx

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 5 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 4 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 1 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}`
  - legacy-only: `Nginx.NginxPlus.NginxDeployments.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/certificates/{}`
  - legacy-only: `Nginx.NginxPlus.NginxCertificates.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/certificates/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/certificates/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/configurations/{}`
  - legacy-only: `Nginx.NginxPlus.NginxConfigurationResponses.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/configurations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/configurations/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/wafPolicies/{}`
  - legacy-only: `Nginx.NginxPlus.NginxDeploymentWafPolicies.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/wafPolicies/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/wafPolicies/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}`
  - resolveArmResources-only: `Nginx.NginxPlus.NginxCertificates.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/certificates/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}, Microsoft.Resources/resourceGroups]`; `Nginx.NginxPlus.NginxConfigurationResponses.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/configurations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}, Microsoft.Resources/resourceGroups]`; `Nginx.NginxPlus.NginxDeploymentWafPolicies.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}/wafPolicies/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Nginx.NginxPlus.NginxDeployments.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Nginx.NginxPlus/nginxDeployments/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
