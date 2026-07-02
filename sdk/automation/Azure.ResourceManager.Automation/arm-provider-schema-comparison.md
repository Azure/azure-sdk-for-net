# ARM provider schema comparison: Azure.ResourceManager.Automation

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 9 resolve-only normalized resource ID patterns; 5 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 25 matching normalized patterns; 0 legacy-only; 9 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 5 differences. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 9 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 25 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 9 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}/streams/{jobStreamId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/modules/{moduleName}/activities/{activityName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodecounts/{countType}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/objectDataTypes/{typeName}/fields`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationMachineRuns/{softwareUpdateConfigurationMachineRunId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationRuns/{softwareUpdateConfigurationRunId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}/sourceControlSyncJobs/{sourceControlSyncJobId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}/sourceControlSyncJobs/{sourceControlSyncJobId}/streams/{streamId}` |

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

**Differences:** 5 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Automation.AutomationAccounts.getById` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationMachineRuns/{softwareUpdateConfigurationMachineRunId}` | Present. | Missing. |
| `Microsoft.Automation.AutomationAccounts.listFieldsByType` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/objectDataTypes/{typeName}/fields` | Present. | Missing. |
| `Microsoft.Automation.AutomationAccounts.nodeCountInformationGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodecounts/{countType}` | Present. | Missing. |
| `Microsoft.Automation.AutomationAccounts.softwareUpdateConfigurationRunsGetById` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationRuns/{softwareUpdateConfigurationRunId}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Automation.Jobs.jobStreamGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs/{jobName}/streams/{jobStreamId}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/modules/{moduleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Automation.Modules.activityGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/modules/{moduleName}/activities/{activityName}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Automation.DscNodes.getContent` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}/content` | Present. | Missing. |
| `Microsoft.Automation.DscNodes.nodeReportsGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes/{nodeId}/reports/{reportId}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Automation.SourceControls.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}/sourceControlSyncJobs/{sourceControlSyncJobId}` | Present. | Missing. |
| `Microsoft.Automation.SourceControls.listBySyncJob` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}/sourceControlSyncJobs/{sourceControlSyncJobId}/streams` | Present. | Missing. |
| `Microsoft.Automation.SourceControls.sourceControlSyncJobGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}/sourceControlSyncJobs/{sourceControlSyncJobId}` | Present. | Missing. |
| `Microsoft.Automation.SourceControls.sourceControlSyncJobStreamsGet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/sourceControls/{sourceControlName}/sourceControlSyncJobs/{sourceControlSyncJobId}/streams/{streamId}` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 17 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/certificates/{}` | `AutomationCertificate` | `Certificate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/connections/{}` | `AutomationConnection` | `Connection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/connectiontypes/{}` | `AutomationConnectionType` | `ConnectionType` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/credentials/{}` | `AutomationCredential` | `Credential` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/jobs/{}` | `AutomationJob` | `Job` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/jobschedules/{}` | `AutomationJobSchedule` | `JobSchedule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/modules/{}` | `AutomationAccountModule` | `AutomationAccountsModules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/privateendpointconnections/{}` | `AutomationPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/python2packages/{}` | `AutomationAccountPython2Package` | `AutomationAccountsPython2Packages` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/runbooks/{}` | `AutomationRunbook` | `Runbook` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/runtimeenvironments/{}` | `AutomationRuntimeEnvironment` | `RuntimeEnvironment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/runtimeenvironments/{}/packages/{}` | `AutomationPackage` | `Package` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/schedules/{}` | `AutomationSchedule` | `Schedule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/sourcecontrols/{}` | `AutomationSourceControl` | `SourceControl` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/variables/{}` | `AutomationVariable` | `Variable` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/watchers/{}` | `AutomationWatcher` | `Watcher` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.automation/automationaccounts/{}/webhooks/{}` | `AutomationWebhook` | `Webhook` |

