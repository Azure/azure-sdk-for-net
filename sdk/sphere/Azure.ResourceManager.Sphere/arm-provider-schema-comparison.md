# ARM provider schema comparison: Azure.ResourceManager.Sphere

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 7 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}`
  - legacy-only: `Microsoft.AzureSphere.Catalogs.listDeployments (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/listDeployments [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.AzureSphere.Catalogs.listDeviceGroups (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/listDeviceGroups [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.AzureSphere.Catalogs.listDevices (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/listDevices [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.AzureSphere.Catalogs.listDeployments (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/listDeployments [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.AzureSphere.Catalogs.listDeviceGroups (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/listDeviceGroups [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.AzureSphere.Catalogs.listDevices (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/listDevices [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/products/{}`
  - legacy-only: `Microsoft.AzureSphere.Products.generateDefaultDeviceGroups (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/products/{}/generateDefaultDeviceGroups [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/products/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.AzureSphere.Products.generateDefaultDeviceGroups (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/products/{}/generateDefaultDeviceGroups [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.AzureSphere/catalogs/{}/products/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
