# ARM provider schema comparison: Azure.ResourceManager.Automation

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 8 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 25 matching normalized patterns; 0 legacy-only; 8 resolve-only |
| Raw resource ID patterns | 0 legacy-only raw; 8 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 5 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 0 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/jobs/{}/streams/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/modules/{}/activities/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodecounts/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodes/{}/reports/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/softwareUpdateConfigurationMachineRuns/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/softwareUpdateConfigurationRuns/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{}/streams/{}`


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}`
  - legacy-only: `Microsoft.Automation.AutomationAccounts.getById (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/softwareUpdateConfigurationMachineRuns/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Automation.AutomationAccounts.nodeCountInformationGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodecounts/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Automation.AutomationAccounts.softwareUpdateConfigurationRunsGetById (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/softwareUpdateConfigurationRuns/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/jobs/{}`
  - legacy-only: `Microsoft.Automation.Jobs.jobStreamGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/jobs/{}/streams/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/jobs/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/modules/{}`
  - legacy-only: `Microsoft.Automation.Modules.activityGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/modules/{}/activities/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/modules/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodes/{}`
  - legacy-only: `Microsoft.Automation.DscNodes.getContent (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodes/{}/reports/{}/content [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodes/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Automation.DscNodes.nodeReportsGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodes/{}/reports/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/nodes/{}, Microsoft.Resources/resourceGroups]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}`
  - legacy-only: `Microsoft.Automation.SourceControls.create (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Automation.SourceControls.listBySyncJob (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{}/streams [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Automation.SourceControls.sourceControlSyncJobGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}, Microsoft.Resources/resourceGroups]`; `Microsoft.Automation.SourceControls.sourceControlSyncJobStreamsGet (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{}/streams/{} [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}, Microsoft.Resources/resourceGroups]`
  - resolveArmResources-only: `Microsoft.Automation.SourceControls.listBySyncJob (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{}/streams [ResourceGroup: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.Automation/automationAccounts/{}/sourceControls/{}/sourceControlSyncJobs/{}, Microsoft.Resources/resourceGroups]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

None.
