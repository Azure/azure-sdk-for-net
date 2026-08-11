# ARM provider schema comparison: Azure.ResourceManager.DeviceRegistry

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 2 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 13 matching normalized patterns; 0 legacy-only; 2 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 2 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 1 matching normalized patterns differ |
| CRUD operations | 3 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 1 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/discoveredAssetEndpointProfiles/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/discoveredAssets/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}`
  - legacy: `Microsoft.DeviceRegistry.Policy`
  - resolveArmResources: `Microsoft.DeviceRegistry.Policy`, `Microsoft.DeviceRegistry.PolicyV1`


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}`
  - resolveArmResources-only: `Microsoft.DeviceRegistry.PoliciesV1.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DeviceRegistry.PoliciesV1.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DeviceRegistry.PoliciesV1.get (Read) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DeviceRegistry.PoliciesV1.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/schemaRegistries/{}/schemas/{}`
  - resolveArmResources-only: `Microsoft.DeviceRegistry.Schemas.deleteSync (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/schemaRegistries/{}/schemas/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/schemaRegistries/{}/schemas/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/schemaRegistries/{}/schemas/{}/schemaVersions/{}`
  - resolveArmResources-only: `Microsoft.DeviceRegistry.SchemaVersions.deleteSync (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/schemaRegistries/{}/schemas/{}/schemaVersions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/schemaRegistries/{}/schemas/{}/schemaVersions/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/assets/{}`
  - resolveArmResources-only: `Microsoft.DeviceRegistry.NamespaceAssets.executeAction (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/assets/{}/executeAction [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/assets/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies/{}`
  - resolveArmResources-only: `Microsoft.DeviceRegistry.PoliciesV1.listByResourceGroup (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default/policies [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DeviceRegistry/namespaces/{}/credentials/default, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.DeviceRegistry.OperationStatus.get (/subscriptions/{}/providers/Microsoft.DeviceRegistry/locations/{}/operationStatuses/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
