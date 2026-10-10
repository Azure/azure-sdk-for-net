# ARM provider schema comparison: Azure.ResourceManager.Elastic

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 4 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 4 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 2 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}`
  - legacy-only: `Microsoft.Elastic.ElasticMonitorResources.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Elastic.ElasticMonitorResources.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{}`
  - legacy-only: `Microsoft.Elastic.MonitoredSubscriptions.createorUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Elastic.MonitoredSubscriptions.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/openAIIntegrations/{}`
  - legacy-only: `Microsoft.Elastic.OpenAIIntegrationRPModels.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/openAIIntegrations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/openAIIntegrations/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/tagRules/{}`
  - legacy-only: `Microsoft.Elastic.TagRules.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/tagRules/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/tagRules/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}`
  - resolveArmResources-only: `Microsoft.Elastic.MonitoredSubscriptions.createorUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Elastic.MonitoredSubscriptions.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/monitoredSubscriptions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Elastic.OpenAIIntegrationRPModels.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/openAIIntegrations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Elastic.TagRules.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}/tagRules/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.Elastic.ElasticMonitorResources.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Elastic.ElasticMonitorResources.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Elastic/monitors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
