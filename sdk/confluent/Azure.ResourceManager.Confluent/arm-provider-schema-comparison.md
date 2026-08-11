# ARM provider schema comparison: Azure.ResourceManager.Confluent

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
| CRUD operations | 5 matching normalized patterns differ |
| List/action operations | 3 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 3 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}`
  - legacy-only: `Microsoft.Confluent.OrganizationResources.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Confluent.OrganizationResources.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}`
  - legacy-only: `Microsoft.Confluent.SCEnvironmentRecords.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}`
  - legacy-only: `Microsoft.Confluent.SCClusterRecords.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/connectors/{}`
  - legacy-only: `Microsoft.Confluent.ConnectorResources.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/connectors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/connectors/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/topics/{}`
  - legacy-only: `Microsoft.Confluent.TopicRecords.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/topics/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/topics/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}`
  - resolveArmResources-only: `Microsoft.Confluent.SCEnvironmentRecords.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}`
  - resolveArmResources-only: `Microsoft.Confluent.SCClusterRecords.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}`
  - resolveArmResources-only: `Microsoft.Confluent.ConnectorResources.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/connectors/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Confluent.TopicRecords.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}/topics/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}/environments/{}/clusters/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.Confluent.Operations.list (/providers/Microsoft.Confluent/operations) Tenant`
- `Microsoft.Confluent.OrganizationResources.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Confluent.OrganizationResources.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Confluent/organizations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
