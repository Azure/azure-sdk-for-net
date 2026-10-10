# ARM provider schema comparison: Azure.ResourceManager.ApiCenter

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 10 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 9 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}`
  - resolveArmResources-only: `Microsoft.ApiCenter.MetadataSchemas.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/metadataSchemas/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ApiCenter.Workspaces.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/metadataSchemas/{}`
  - legacy-only: `Microsoft.ApiCenter.MetadataSchemas.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/metadataSchemas/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/metadataSchemas/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}`
  - legacy-only: `Microsoft.ApiCenter.Workspaces.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.ApiCenter.Apis.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ApiCenter.ApiSources.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apiSources/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ApiCenter.Environments.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/environments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}`
  - legacy-only: `Microsoft.ApiCenter.Apis.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.ApiCenter.ApiVersions.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.ApiCenter.Deployments.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/deployments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/deployments/{}`
  - legacy-only: `Microsoft.ApiCenter.Deployments.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/deployments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/deployments/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}`
  - legacy-only: `Microsoft.ApiCenter.ApiVersions.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.ApiCenter.ApiDefinitions.head (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}/definitions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}/definitions/{}`
  - legacy-only: `Microsoft.ApiCenter.ApiDefinitions.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}/definitions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apis/{}/versions/{}/definitions/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apiSources/{}`
  - legacy-only: `Microsoft.ApiCenter.ApiSources.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apiSources/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/apiSources/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/environments/{}`
  - legacy-only: `Microsoft.ApiCenter.Environments.head (CheckExistence) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/environments/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.ApiCenter/services/{}/workspaces/{}/environments/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
