# ARM provider schema comparison: Azure.ResourceManager.SecurityInsights

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
| CRUD operations | 5 matching normalized patterns differ |
| List/action operations | 1 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 4 resolve-only |


### Legacy-only normalized resource ID patterns

None.


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/alertRules/{}/actions/{}`
  - legacy-only: `Microsoft.SecurityInsights.ActionResponses.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/alertRules/{}/actions/{} [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/alertRules/{}/actions/{}, Microsoft.OperationalInsights/workspaces]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/automationRules/{}`
  - legacy-only: `Microsoft.SecurityInsights.AutomationRules.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/automationRules/{} [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/automationRules/{}, Microsoft.OperationalInsights/workspaces]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/entityQueries/{}`
  - legacy-only: `Microsoft.SecurityInsights.EntityQueries.createOrUpdate (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/entityQueries/{} [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/entityQueries/{}, Microsoft.OperationalInsights/workspaces]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/onboardingStates/{}`
  - legacy-only: `Microsoft.SecurityInsights.SentinelOnboardingStates.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/onboardingStates/{} [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/onboardingStates/{}, Microsoft.OperationalInsights/workspaces]`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{}`
  - legacy-only: `Microsoft.SecurityInsights.ThreatIntelligenceInformationOperations.create (Create) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{} [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{}, Microsoft.OperationalInsights/workspaces]`


### List/action operation differences

- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/alertRules/{}`
  - resolveArmResources-only: `Microsoft.SecurityInsights.ActionResponses.createOrUpdate (Action) /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/alertRules/{}/actions/{} [Extension: /subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/alertRules/{}, Microsoft.OperationalInsights/workspaces]`


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.SecurityInsights.AutomationRules.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/automationRules/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}: Microsoft.OperationalInsights/workspaces]`
- `Microsoft.SecurityInsights.EntityQueries.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/entityQueries/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}: Microsoft.OperationalInsights/workspaces]`
- `Microsoft.SecurityInsights.SentinelOnboardingStates.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/onboardingStates/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}: Microsoft.OperationalInsights/workspaces]`
- `Microsoft.SecurityInsights.ThreatIntelligenceInformationOperations.create (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{}) Extension [/subscriptions/{}/resourceGroups/{}/providers/Microsoft.OperationalInsights/workspaces/{}: Microsoft.OperationalInsights/workspaces]`
