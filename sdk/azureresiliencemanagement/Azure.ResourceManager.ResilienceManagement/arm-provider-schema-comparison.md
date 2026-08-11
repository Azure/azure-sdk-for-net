# ARM provider schema comparison: Azure.ResourceManager.ResilienceManagement

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 5 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 14 matching normalized patterns; 0 legacy-only; 5 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 5 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 4 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/chaosJobs/{}`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/chaosJobs/{}/chaosJobChildJobs/{}`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/chaosJobs/{}/chaosJobResources/{}`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/drillRunChildJobs/{}`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}/recoveryChildJobs/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}`
  - resolveArmResources-only: `Microsoft.AzureResilienceManagement.Drills.addOrUpdateResourcesOld (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/addOrUpdateResourcesOld [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}, Microsoft.Management/serviceGroups]`; `Microsoft.AzureResilienceManagement.Drills.refreshReadinessState (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/refreshReadinessState [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}, Microsoft.Management/serviceGroups]`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}`
  - resolveArmResources-only: `Microsoft.AzureResilienceManagement.DrillRuns.testFailOver (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/testFailOver [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}, Microsoft.Management/serviceGroups]`; `Microsoft.AzureResilienceManagement.DrillRuns.testFailOverCleanup (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}/testFailOverCleanup [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/drills/{}/drillRuns/{}, Microsoft.Management/serviceGroups]`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}`
  - resolveArmResources-only: `Microsoft.AzureResilienceManagement.RecoveryPlanActions.reprotectOld (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/reprotectOld [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}, Microsoft.Management/serviceGroups]`; `Microsoft.AzureResilienceManagement.RecoveryPlanActions.validateForReprotectOld (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/validateForReprotectOld [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}, Microsoft.Management/serviceGroups]`
- `/providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}`
  - resolveArmResources-only: `Microsoft.AzureResilienceManagement.RecoveryJobs.cancelOld (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}/cancelOld [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}, Microsoft.Management/serviceGroups]`; `Microsoft.AzureResilienceManagement.RecoveryJobs.resumeOld (Action) /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}/resumeOld [Extension: /providers/Microsoft.Management/serviceGroups/{}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{}/recoveryJobs/{}, Microsoft.Management/serviceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
