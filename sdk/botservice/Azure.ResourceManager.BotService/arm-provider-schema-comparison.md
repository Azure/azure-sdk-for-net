# ARM provider schema comparison: Azure.ResourceManager.BotService

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
| CRUD operations | 1 matching normalized patterns differ |
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

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{}`
  - legacy-only: `Microsoft.BotService.BotChannels.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.BotService.BotChannels.update (Update) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{}, Microsoft.Resources/resourceGroups]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}`
  - resolveArmResources-only: `Microsoft.BotService.BotChannels.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.BotService.BotChannels.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}/channels/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.BotService/botServices/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Azure.ResourceManager.Legacy.Operations.list (/providers/Microsoft.BotService/operations) Tenant`
- `Microsoft.BotService.OperationResultsOperationGroup.get (/subscriptions/{}/providers/Microsoft.BotService/operationresults/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
