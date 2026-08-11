# ARM provider schema comparison: Azure.ResourceManager.HDInsight

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 6 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 4 matching normalized patterns; 0 legacy-only; 6 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 6 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 2 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 1 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/applications/{}/azureasyncoperations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/azureasyncoperations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/configurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/extensions/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/extensions/{}/azureAsyncOperations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/scriptExecutionHistory/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}`
  - legacy-only: `Microsoft.HDInsight.Clusters.getAzureAsyncOperationStatus (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/azureasyncoperations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.Configurations.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/configurations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.Configurations.update (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/configurations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.Extensions.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.Extensions.delete (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.Extensions.get (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/extensions/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.Extensions.getAzureAsyncOperationStatus (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/extensions/{}/azureAsyncOperations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.ScriptActions.getExecutionDetail (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/scriptExecutionHistory/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.HDInsight.ScriptExecutionHistory.promote (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/scriptExecutionHistory/{}/promote [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.HDInsight.ScriptExecutionHistory.promote (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/scriptExecutionHistory/{}/promote [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/scriptExecutionHistory/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/applications/{}`
  - legacy-only: `Microsoft.HDInsight.Applications.getAzureAsyncOperationStatus (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/applications/{}/azureasyncoperations/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.HDInsight/clusters/{}/applications/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.HDInsight.LocationsOperationGroup.getAzureAsyncOperationStatus (/subscriptions/{}/providers/Microsoft.HDInsight/locations/{}/azureasyncoperations/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
