# ARM provider schema comparison: Azure.ResourceManager.ResilienceManagement

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 5 resolve-only normalized resource ID patterns; 4 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 14 matching normalized patterns; 0 legacy-only; 5 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 4 differences. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 5 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 14 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 5 | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/chaosJobs/{chaosJobName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/chaosJobs/{chaosJobName}/chaosJobChildJobs/{chaosJobChildJobName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/chaosJobs/{chaosJobName}/chaosJobResources/{chaosJobResourceName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/drillRunChildJobs/{drillRunChildJobName}`<br>`/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/recoveryChildJobs/{recoveryChildJobName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 4 list/action operation differences.

#### List and action operations differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.Drills.addOrUpdateResourcesOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/addOrUpdateResourcesOld` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.Drills.refreshReadinessState` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/refreshReadinessState` | Missing. | Present. |

#### List and action operations differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.DrillRuns.testFailOver` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/testFailOver` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.DrillRuns.testFailOverCleanup` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/drills/{drillName}/drillRuns/{drillRunName}/testFailOverCleanup` | Missing. | Present. |

#### List and action operations differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.RecoveryPlanActions.reprotectOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/reprotectOld` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.RecoveryPlanActions.validateForReprotectOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/validateForReprotectOld` | Missing. | Present. |

#### List and action operations differences: `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureResilienceManagement.RecoveryJobs.cancelOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/cancelOld` | Missing. | Present. |
| `Microsoft.AzureResilienceManagement.RecoveryJobs.resumeOld` | `Action` | `/providers/Microsoft.Management/serviceGroups/{serviceGroupName}/providers/Microsoft.AzureResilienceManagement/recoveryPlans/{recoveryPlanName}/recoveryJobs/{recoveryJobName}/resumeOld` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 7 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.management/servicegroups/{}/providers/microsoft.azureresiliencemanagement/drills/{}` | `ResilienceManagementDrill` | `Drill` |
| `/providers/microsoft.management/servicegroups/{}/providers/microsoft.azureresiliencemanagement/drills/{}/drillresources/{}` | `DrillTarget` | `DrillResource` |
| `/providers/microsoft.management/servicegroups/{}/providers/microsoft.azureresiliencemanagement/drills/{}/drillruns/{}/drillrunresources/{}` | `DrillRunTarget` | `DrillRunResource` |
| `/providers/microsoft.management/servicegroups/{}/providers/microsoft.azureresiliencemanagement/goalassignments/{}/goalresources/{}` | `GoalMembers` | `GoalResource` |
| `/providers/microsoft.management/servicegroups/{}/providers/microsoft.azureresiliencemanagement/recoveryplans/{}/recoveryjobs/{}/recoveryjobresources/{}` | `RecoveryJobTarget` | `RecoveryJobResource` |
| `/providers/microsoft.management/servicegroups/{}/providers/microsoft.azureresiliencemanagement/recoveryplans/{}/recoveryresources/{}` | `RecoveryMembers` | `RecoveryResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azureresiliencemanagement/usageplans/{}/enrollments/{}` | `UsagePlanEnrollment` | `Enrollment` |

