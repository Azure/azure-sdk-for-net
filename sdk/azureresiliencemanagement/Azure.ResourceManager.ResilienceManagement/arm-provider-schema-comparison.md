# ARM provider schema comparison: Azure.ResourceManager.ResilienceManagement

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 5 resolve-only resource ID patterns; 4 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 14 matching patterns; 0 legacy-only; 5 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 4 differences. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only pattern(s), 5 resolve-only pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 14 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 5 | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/chaosJobs/{chaosJobName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/chaosJobs/{chaosJobName}/chaosJobChildJobs/{chaosJobChildJobName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/chaosJobs/{chaosJobName}/chaosJobResources/{chaosJobResourceName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/drillRunChildJobs/{drillRunChildJobName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/recoveryChildJobs/{recoveryChildJobName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** 4 list/action operation differences.

#### List/action operation differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.Drills.addOrUpdateResourcesOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/addOrUpdateResourcesOld` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.Drills.refreshReadinessState` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/refreshReadinessState` | Missing. | Present. |

#### List/action operation differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.DrillRuns.testFailOver` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/testFailOver` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.DrillRuns.testFailOverCleanup` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/testFailOverCleanup` | Missing. | Present. |

#### List/action operation differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.RecoveryPlanActions.reprotectOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/reprotectOld` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.RecoveryPlanActions.validateForReprotectOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForReprotectOld` | Missing. | Present. |

#### List/action operation differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.RecoveryJobs.cancelOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/cancelOld` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.RecoveryJobs.resumeOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/resumeOld` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 7 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}` | `ResilienceManagementDrill` | `Drill` |
| `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillResources/{drillResourceName}` | `DrillTarget` | `DrillResource` |
| `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/drillRunResources/{drillRunResourceName}` | `DrillRunTarget` | `DrillRunResource` |
| `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/goalAssignments/{goalAssignmentName}/goalResources/{goalResourceName}` | `GoalMembers` | `GoalResource` |
| `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/recoveryJobResources/{recoveryJobResourceName}` | `RecoveryJobTarget` | `RecoveryJobResource` |
| `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryResources/{recoveryResourceName}` | `RecoveryMembers` | `RecoveryResource` |
| `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureResilienceManagement/usagePlans/{usagePlanName}/enrollments/{enrollmentName}` | `UsagePlanEnrollment` | `Enrollment` |

