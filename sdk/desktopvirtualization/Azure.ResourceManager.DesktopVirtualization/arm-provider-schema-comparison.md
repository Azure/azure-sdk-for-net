# ARM provider schema comparison: Azure.ResourceManager.DesktopVirtualization

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 17 matching normalized patterns; 0 legacy-only; 0 resolve-only |
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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}`
  - legacy-only: `Microsoft.DesktopVirtualization.AppAttachPackageInfo.import (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/importAppAttachPackageInfo [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DesktopVirtualization.ScalingPlans.listByHostPool (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/scalingPlans [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DesktopVirtualization.UserSessions.listByHostPool (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/userSessions [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.DesktopVirtualization.ActiveSessionHostConfigurations.listByHostPool (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/activeSessionHostConfigurations [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DesktopVirtualization.AppAttachPackageInfo.import (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/importAppAttachPackageInfo [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DesktopVirtualization.ScalingPlans.listByHostPool (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/scalingPlans [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.DesktopVirtualization.UserSessions.listByHostPool (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/userSessions [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/activeSessionHostConfigurations/default`
  - legacy-only: `Microsoft.DesktopVirtualization.ActiveSessionHostConfigurations.listByHostPool (List) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}/activeSessionHostConfigurations [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.DesktopVirtualization/hostPools/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
