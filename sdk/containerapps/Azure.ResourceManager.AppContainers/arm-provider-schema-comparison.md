# ARM provider schema comparison: Azure.ResourceManager.AppContainers

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 41 matching normalized patterns; 0 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 3 matching normalized patterns differ |
| List/action operations | 3 matching normalized patterns differ |
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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}/daprComponents/{}`
  - legacy-only: `Microsoft.App.ConnectedEnvironmentsDaprComponents.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}/daprComponents/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}/daprComponents/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{}`
  - legacy-only: `Microsoft.App.HttpRouteConfigs.delete (Delete) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.App.HttpRouteConfigs.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/managedCertificates/{}`
  - legacy-only: `Microsoft.App.ManagedCertificates.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/managedCertificates/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/managedCertificates/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}`
  - resolveArmResources-only: `Microsoft.App.ConnectedEnvironmentsDaprComponents.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}/daprComponents/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/connectedEnvironments/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/containerApps/{}/labelHistory/{}`
  - resolveArmResources-only: `Microsoft.App.ContainerAppsLabelHistory.listLabelHistory (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/containerApps/{}/labelHistory [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/containerApps/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}`
  - resolveArmResources-only: `Microsoft.App.HttpRouteConfigs.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.App.HttpRouteConfigs.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/httpRouteConfigs/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.App.ManagedCertificates.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}/managedCertificates/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.App/managedEnvironments/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
