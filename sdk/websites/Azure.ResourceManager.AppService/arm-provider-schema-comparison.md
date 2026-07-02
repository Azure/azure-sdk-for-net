# ARM provider schema comparison: Azure.ResourceManager.AppService

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 legacy-only and 1 resolve-only normalized resource ID patterns; 81 hierarchy differences; 39 resource model differences; 1 CRUD operation difference; 42 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 132 matching normalized patterns; 4 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | 81 differences. |
| Resource model for matching patterns | 39 differences. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 42 differences. |

## 1. Resource ID pattern coverage

**Differences:** 4 legacy-only normalized pattern(s), 1 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 132 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 4 | `/providers/Microsoft.Web/publishingUsers/web`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm` |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 81 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/backups/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/certificates/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/configreferences/appsettings/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/configreferences/connectionstrings/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/web/snapshots/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/continuouswebjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/deployments/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/deploymentstatus/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/detectors/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/diagnostics/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/diagnostics/{}/analyses/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/diagnostics/{}/detectors/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/domainownershipidentifiers/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/functions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostnamebindings/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}/repetitions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}/repetitions/{}/requesthistories/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}/scoperepetitions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/triggers/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/triggers/{}/histories/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/versions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hybridconnection/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/instances/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/instances/{}/extensions/msdeploy` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/instances/{}/processes/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/networkfeatures/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/premieraddons/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/privateendpointconnections/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/processes/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/publiccertificates/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/recommendations/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/resourcehealthmetadata/default` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/sitecontainers/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/siteextensions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/backups/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/basicpublishingcredentialspolicies/ftp` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/certificates/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/authsettingsv2` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/configreferences/appsettings/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/configreferences/connectionstrings/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/logs` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/web` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/web/snapshots/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/continuouswebjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/deployments/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/deploymentstatus/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/domainownershipidentifiers/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/extensions/msdeploy` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/functions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/hostnamebindings/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/hybridconnection/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/instances/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/instances/{}/extensions/msdeploy` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/instances/{}/processes/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/migratemysql/status` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/networkconfig/virtualnetwork` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/networkfeatures/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/premieraddons/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/privateaccess/virtualnetworks` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/privateendpointconnections/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/processes/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/publiccertificates/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/resourcehealthmetadata/default` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/sitecontainers/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/siteextensions/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/sourcecontrols/web` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/triggeredwebjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/triggeredwebjobs/{}/history/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/virtualnetworkconnections/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/virtualnetworkconnections/{}/gateways/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/webjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/workflows/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/triggeredwebjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/triggeredwebjobs/{}/history/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/virtualnetworkconnections/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/virtualnetworkconnections/{}/gateways/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/webjobs/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/workflows/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 39 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/hostingenvironments/{}/capacities/virtualip` | `Microsoft.Web.AddressResponse` | `Microsoft.Web.AddressResponse` | `Microsoft.Web/hostingEnvironments/capacities` | `Microsoft.Web/hostingEnvironments` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/hostingenvironments/{}/configurations/customdnssuffix` | `Microsoft.Web.CustomDnsSuffixConfiguration` | `Microsoft.Web.CustomDnsSuffixConfiguration` | `Microsoft.Web/hostingEnvironments/configurations` | `Microsoft.Web/hostingEnvironments` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/hostingenvironments/{}/configurations/networking` | `Microsoft.Web.AseV3NetworkingConfiguration` | `Microsoft.Web.AseV3NetworkingConfiguration` | `Microsoft.Web/hostingEnvironments/configurations` | `Microsoft.Web/hostingEnvironments` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/serverfarms/{}/hybridconnectionplanlimits/limit` | `Microsoft.Web.HybridConnectionLimits` | `Microsoft.Web.HybridConnectionLimits` | `Microsoft.Web/serverfarms/hybridConnectionPlanLimits` | `Microsoft.Web/serverfarms` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/basicpublishingcredentialspolicies/ftp` | `Microsoft.Web.CsmPublishingCredentialsPoliciesEntity` | `Microsoft.Web.CsmPublishingCredentialsPoliciesEntity` | `Microsoft.Web/sites/basicPublishingCredentialsPolicies` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/authsettingsv2` | `Microsoft.Web.SiteAuthSettingsV2` | `Microsoft.Web.SiteAuthSettingsV2` | `Microsoft.Web/sites/config` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/configreferences/appsettings/{}` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web/sites/config/appsettings` | `Microsoft.Web/sites/appsettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/configreferences/connectionstrings/{}` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web/sites/config/connectionstrings` | `Microsoft.Web/sites/connectionstrings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/logs` | `Microsoft.Web.SiteLogsConfig` | `Microsoft.Web.SiteLogsConfig` | `Microsoft.Web/sites/config` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/slotconfignames` | `Microsoft.Web.SlotConfigNamesResource` | `Microsoft.Web.SlotConfigNamesResource` | `Microsoft.Web/sites/config` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/web` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web/sites/config` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/config/web/snapshots/{}` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web/sites/config/snapshots` | `Microsoft.Web/sites/snapshots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/extensions/msdeploy` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web/sites/extensions` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}` | `Microsoft.Web.WorkflowRun` | `Microsoft.Web.WorkflowRun` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/runs` | `Microsoft.Web/sites/workflows/runs` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}` | `Microsoft.Web.WorkflowRunAction` | `Microsoft.Web.WorkflowRunAction` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/runs/actions` | `Microsoft.Web/sites/workflows/runs/actions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}/repetitions/{}` | `Microsoft.Web.WorkflowRunActionRepetitionDefinition` | `Microsoft.Web.WorkflowRunActionRepetitionDefinition` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/runs/actions/repetitions` | `Microsoft.Web/sites/workflows/runs/actions/repetitions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}/repetitions/{}/requesthistories/{}` | `Microsoft.Web.RequestHistory` | `Microsoft.Web.RequestHistory` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/runs/actions/repetitions/requestHistories` | `Microsoft.Web/sites/workflows/runs/actions/repetitions/requestHistories` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/runs/{}/actions/{}/scoperepetitions/{}` | `Microsoft.Web.WorkflowRunActionRepetitionDefinition` | `Microsoft.Web.WorkflowRunActionRepetitionDefinition` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/runs/actions/scopeRepetitions` | `Microsoft.Web/sites/workflows/runs/actions/scopeRepetitions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/triggers/{}` | `Microsoft.Web.WorkflowTrigger` | `Microsoft.Web.WorkflowTrigger` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/triggers` | `Microsoft.Web/sites/workflows/triggers` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/triggers/{}/histories/{}` | `Microsoft.Web.WorkflowTriggerHistory` | `Microsoft.Web.WorkflowTriggerHistory` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/triggers/histories` | `Microsoft.Web/sites/workflows/triggers/histories` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{}/versions/{}` | `Microsoft.Web.WorkflowVersion` | `Microsoft.Web.WorkflowVersion` | `Microsoft.Web/sites/hostruntime/webhooks/api/workflows/versions` | `Microsoft.Web/sites/workflows/versions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/instances/{}/extensions/msdeploy` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web/sites/instances/extensions` | `Microsoft.Web/sites/instances` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/migratemysql/status` | `Microsoft.Web.MigrateMySqlStatus` | `Microsoft.Web.MigrateMySqlStatus` | `Microsoft.Web/sites/migratemysql` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/networkconfig/virtualnetwork` | `Microsoft.Web.SwiftVirtualNetwork` | `Microsoft.Web.SwiftVirtualNetwork` | `Microsoft.Web/sites/networkConfig` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/privateaccess/virtualnetworks` | `Microsoft.Web.PrivateAccess` | `Microsoft.Web.PrivateAccess` | `Microsoft.Web/sites/privateAccess` | `Microsoft.Web/sites` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/basicpublishingcredentialspolicies/ftp` | `Microsoft.Web.CsmPublishingCredentialsPoliciesEntity` | `Microsoft.Web.CsmPublishingCredentialsPoliciesEntity` | `Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/authsettingsv2` | `Microsoft.Web.SiteAuthSettingsV2` | `Microsoft.Web.SiteAuthSettingsV2` | `Microsoft.Web/sites/slots/config` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/configreferences/appsettings/{}` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web/sites/slots/config/appsettings` | `Microsoft.Web/sites/slots/appsettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/configreferences/connectionstrings/{}` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web.ApiKVReference` | `Microsoft.Web/sites/slots/config/connectionstrings` | `Microsoft.Web/sites/slots/connectionstrings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/logs` | `Microsoft.Web.SiteLogsConfig` | `Microsoft.Web.SiteLogsConfig` | `Microsoft.Web/sites/slots/config` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/web` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web/sites/slots/config` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/config/web/snapshots/{}` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web.SiteConfigResource` | `Microsoft.Web/sites/slots/config/snapshots` | `Microsoft.Web/sites/slots/snapshots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/extensions/msdeploy` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web/sites/slots/extensions` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/instances/{}/extensions/msdeploy` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web.MSDeployStatus` | `Microsoft.Web/sites/slots/instances/extensions` | `Microsoft.Web/sites/slots/instances` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/migratemysql/status` | `Microsoft.Web.MigrateMySqlStatus` | `Microsoft.Web.MigrateMySqlStatus` | `Microsoft.Web/sites/slots/migratemysql` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/networkconfig/virtualnetwork` | `Microsoft.Web.SwiftVirtualNetwork` | `Microsoft.Web.SwiftVirtualNetwork` | `Microsoft.Web/sites/slots/networkConfig` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/privateaccess/virtualnetworks` | `Microsoft.Web.PrivateAccess` | `Microsoft.Web.PrivateAccess` | `Microsoft.Web/sites/slots/privateAccess` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/slots/{}/sourcecontrols/web` | `Microsoft.Web.SiteSourceControl` | `Microsoft.Web.SiteSourceControl` | `Microsoft.Web/sites/slots/sourcecontrols` | `Microsoft.Web/sites/slots` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/sites/{}/sourcecontrols/web` | `Microsoft.Web.SiteSourceControl` | `Microsoft.Web.SiteSourceControl` | `Microsoft.Web/sites/sourcecontrols` | `Microsoft.Web/sites` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.FunctionEnvelopeOperationGroup.createOrUpdateFunctionSecretSlot` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}` | Missing. | Present. |
| `Microsoft.Web.FunctionEnvelopeOperationGroup.deleteFunctionSecretSlot` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 42 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.AppServiceEnvironmentResources.getDiagnosticsItem` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/diagnostics/{diagnosticsName}` | Present. | Missing. |
| `Microsoft.Web.AppServiceEnvironmentResources.listAppServicePlans` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/serverfarms` | Different. | Different. |
| `Microsoft.Web.AppServiceEnvironmentResources.listWebApps` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/sites` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/configurations/customdnssuffix`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.AppServiceEnvironmentResources.getDiagnosticsItem` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/diagnostics/{diagnosticsName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/multiRolePools/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.AppServiceEnvironments.listWorkerPoolInstanceMetricDefinitions` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/workerPools/{workerPoolName}/instances/{instance}/metricdefinitions` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/workerPools/{workerPoolName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.AppServiceEnvironments.listWorkerPoolInstanceMetricDefinitions` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/workerPools/{workerPoolName}/instances/{instance}/metricdefinitions` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.AppServicePlans.listHybridConnections` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionRelays` | Different. | Different. |
| `Microsoft.Web.AppServicePlans.listWebApps` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/sites` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.VnetRoutes.createOrUpdateVnetRoute` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}` | Present. | Missing. |
| `Microsoft.Web.VnetRoutes.deleteVnetRoute` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}` | Present. | Missing. |
| `Microsoft.Web.VnetRoutes.getRouteForVnet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}` | Present. | Missing. |
| `Microsoft.Web.VnetRoutes.listRoutesForVnet` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes` | Present. | Missing. |
| `Microsoft.Web.VnetRoutes.updateVnetRoute` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/routes/{routeName}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.BackupItems.listBackups` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.CsmPublishingCredentialsPoliciesEntities.listBasicPublishingCredentialsPolicies` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/certificates/{certificateName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.SiteCertificates.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/certificates` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/appsettings/{appSettingKey}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.AppSettingKeyVaultReference.getAppSettingsKeyVaultReferences` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/appsettings` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings/{connectionStringKey}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.SiteConnectionStringKeyVaultReference.getSiteConnectionStringKeyVaultReferences` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.SiteConfigResourceOperationGroup.listConfigurations` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.Sites.listSnapshots` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/snapshots` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.ContinuousWebJobs.listContinuousWebJobs` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments/{id}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.Deployments.listDeployments` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployments` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus/{deploymentStatusId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.CsmDeploymentStatuses.listProductionSiteDeploymentStatuses` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/detectors/{detectorName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.Diagnostics.listSiteDetectorResponses` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/detectors` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.DiagnosticCategories.listSiteDiagnosticCategories` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers/{domainOwnershipIdentifierName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.Identifiers.listDomainOwnershipIdentifiers` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/domainOwnershipIdentifiers` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/{functionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.FunctionEnvelopes.listFunctions` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.HostNameBindings.listHostNameBindings` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/runs/{runName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.WorkflowRuns.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/runs` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/triggers/{triggerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.WorkflowTriggers.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/triggers` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/versions/{versionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.WorkflowVersions.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/versions` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.Sites.listRelayServiceConnections` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.WebSiteInstanceStatuses.listInstanceIdentifiers` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.Sites.listPremierAddOns` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections/{privateEndpointConnectionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.RemotePrivateEndpointConnectionARMResourceOperationGroup.getPrivateEndpointConnectionList` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateEndpointConnections` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes/{processId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.ProcessInfoOperationGroup.listProcesses` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/processes` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates/{publicCertificateName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.PublicCertificates.listPublicCertificates` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publicCertificates` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/recommendations/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.SiteRecommendations.listRecommendedRulesForWebApp` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/recommendations` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resourceHealthMetadata/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.ResourceHealthMetadataOperationGroup.listBySite` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resourceHealthMetadata` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sitecontainers/{containerName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.SiteContainers.listSiteContainers` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sitecontainers` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.SiteExtensionInfos.listSiteExtensions` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.CsmPublishingCredentialsPoliciesEntityScmAllowedSlot.getScmAllowedSlot` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm` | Missing. | Present. |
| `Microsoft.Web.CsmPublishingCredentialsPoliciesEntityScmAllowedSlot.updateScmAllowedSlot` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm` | Missing. | Present. |
| `Microsoft.Web.SiteRecommendations.disableAllForWebApp` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/recommendations/disable` | Missing. | Present. |
| `Microsoft.Web.SiteRecommendations.resetAllFiltersForWebApp` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/recommendations/reset` | Missing. | Present. |
| `Microsoft.Web.SiteWorkflows.regenerateAccessKey` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/regenerateAccessKey` | Missing. | Present. |
| `Microsoft.Web.SiteWorkflows.validate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/validate` | Missing. | Present. |
| `Microsoft.Web.Sites.getNetworkSecurityPerimeterConfiguration` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkSecurityPerimeterConfigurations/{networkSecurityPerimeterReference}` | Missing. | Present. |
| `Microsoft.Web.Sites.getNetworkTraceOperationV2` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTraces/current/operationresults/{operationId}` | Missing. | Present. |
| `Microsoft.Web.Sites.getNetworkTraces` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/{operationId}` | Missing. | Present. |
| `Microsoft.Web.Sites.getNetworkTracesV2` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTraces/{operationId}` | Missing. | Present. |
| `Microsoft.Web.Sites.list` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Web/sites` | Missing. | Present. |
| `Microsoft.Web.Sites.listHostKeys` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listkeys` | Missing. | Present. |
| `Microsoft.Web.Sites.listPublishingCredentials` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/publishingcredentials/list` | Missing. | Present. |
| `Microsoft.Web.Sites.listSyncStatus` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listsyncstatus` | Missing. | Present. |
| `Microsoft.Web.Sites.migrateMySql` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql` | Missing. | Present. |
| `Microsoft.Web.Sites.migrateStorage` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migrate` | Missing. | Present. |
| `Microsoft.Web.Sites.start` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/start` | Missing. | Present. |
| `Microsoft.Web.Sites.syncFunctions` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/sync` | Missing. | Present. |
| `Microsoft.Web.WebApps.listByResourceGroup` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites` | Missing. | Present. |
| `Microsoft.Web.WebApps.listSiteBackupsSlot` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/listbackups` | Different. | Different. |
| `Microsoft.Web.WebApps.listSlots` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.FunctionEnvelopeOperationGroup.createOrUpdateFunctionSecretSlot` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}` | Present. | Missing. |
| `Microsoft.Web.FunctionEnvelopeOperationGroup.deleteFunctionSecretSlot` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/functions/{functionName}/keys/{keyName}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.TriggeredWebJobOperationGroup.listTriggeredWebJobs` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.VnetConnectionOperationGroup.listVnetConnections` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.WebJobOperationGroup.listWebJobs` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/workflows/{workflowName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.WorkflowEnvelopeOperationGroup.listWorkflows` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/workflows` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.StaticSiteARMResources.getDatabaseConnectionsWithDetails` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/showDatabaseConnections` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds/{environmentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Web.StaticSiteBuildARMResources.getBuildDatabaseConnectionsWithDetails` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds/{environmentName}/showDatabaseConnections` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 8 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 66 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.web/sourcecontrols/{}` | `AppServiceSourceControl` | `SourceControl` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/hostingenvironments/{}` | `AppServiceEnvironment` | `AppServiceEnvironmentResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/hostingenvironments/{}/capacities/virtualip` | `AppServiceEnvironmentAddress` | `AddressResponse` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/serverfarms/{}/hybridconnectionplanlimits/limit` | `HybridConnectionLimit` | `HybridConnectionLimits` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/staticsites/{}` | `StaticSite` | `StaticSiteARMResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/staticsites/{}/basicauth/{}` | `StaticSiteBasicAuthProperty` | `StaticSiteBasicAuthPropertiesARMResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/staticsites/{}/builds/{}` | `StaticSiteBuild` | `StaticSiteBuildARMResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.web/staticsites/{}/customdomains/{}` | `StaticSiteCustomDomainOverview` | `StaticSiteCustomDomainOverviewARMResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Web.CsmPublishingCredentialsPoliciesEntityOperationGroup.getScmAllowed` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm` | Missing. | Present. |
| `Microsoft.Web.CsmPublishingCredentialsPoliciesEntityOperationGroup.updateScmAllowed` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm` | Missing. | Present. |
| `Microsoft.Web.SiteRecommendations.listHistoryForWebApp` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/recommendationHistory` | Missing. | Present. |
| `Microsoft.Web.Sites.analyzeCustomHostname` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/analyzeCustomHostname` | Missing. | Present. |
| `Microsoft.Web.Sites.applySlotConfigToProduction` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/applySlotConfig` | Missing. | Present. |
| `Microsoft.Web.Sites.backup` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backup` | Missing. | Present. |
| `Microsoft.Web.Sites.createOneDeployOperation` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/onedeploy` | Missing. | Present. |
| `Microsoft.Web.Sites.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}` | Missing. | Present. |
| `Microsoft.Web.Sites.createOrUpdateHostSecret` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/{keyType}/{keyName}` | Missing. | Present. |
| `Microsoft.Web.Sites.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}` | Missing. | Present. |
| `Microsoft.Web.Sites.deleteBackupConfiguration` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup` | Missing. | Present. |
| `Microsoft.Web.Sites.deleteHostSecret` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/{keyType}/{keyName}` | Missing. | Present. |
| `Microsoft.Web.Sites.deployWorkflowArtifacts` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deployWorkflowArtifacts` | Missing. | Present. |
| `Microsoft.Web.Sites.discoverBackup` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/discoverbackup` | Missing. | Present. |
| `Microsoft.Web.Sites.generateNewSitePublishingPassword` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/newpassword` | Missing. | Present. |
| `Microsoft.Web.Sites.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}` | Missing. | Present. |
| `Microsoft.Web.Sites.getAuthSettings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettings/list` | Missing. | Present. |
| `Microsoft.Web.Sites.getBackupConfiguration` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup/list` | Missing. | Present. |
| `Microsoft.Web.Sites.getContainerLogsZip` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/containerlogs/zip/download` | Missing. | Present. |
| `Microsoft.Web.Sites.getFunctionsAdminToken` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/functions/admin/token` | Missing. | Present. |
| `Microsoft.Web.Sites.getNetworkTraceOperation` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/operationresults/{operationId}` | Missing. | Present. |
| `Microsoft.Web.Sites.getOneDeployStatus` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/extensions/onedeploy` | Missing. | Present. |
| `Microsoft.Web.Sites.getPrivateLinkResources` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateLinkResources` | Missing. | Present. |
| `Microsoft.Web.Sites.getSitePhpErrorLogFlag` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/phplogging` | Missing. | Present. |
| `Microsoft.Web.Sites.getWebSiteContainerLogs` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/containerlogs` | Missing. | Present. |
| `Microsoft.Web.Sites.isCloneable` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/iscloneable` | Missing. | Present. |
| `Microsoft.Web.Sites.listApplicationSettings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/appsettings/list` | Missing. | Present. |
| `Microsoft.Web.Sites.listAzureStorageAccounts` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/azurestorageaccounts/list` | Missing. | Present. |
| `Microsoft.Web.Sites.listConnectionStrings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/connectionstrings/list` | Missing. | Present. |
| `Microsoft.Web.Sites.listHybridConnections` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays` | Missing. | Present. |
| `Microsoft.Web.Sites.listMetadata` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/metadata/list` | Missing. | Present. |
| `Microsoft.Web.Sites.listNetworkSecurityPerimeterConfigurations` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkSecurityPerimeterConfigurations` | Missing. | Present. |
| `Microsoft.Web.Sites.listPerfMonCounters` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/perfcounters` | Missing. | Present. |
| `Microsoft.Web.Sites.listPublishingProfileXmlWithSecrets` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/publishxml` | Missing. | Present. |
| `Microsoft.Web.Sites.listSiteBackups` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listbackups` | Missing. | Present. |
| `Microsoft.Web.Sites.listSitePushSettings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/pushsettings/list` | Missing. | Present. |
| `Microsoft.Web.Sites.listSlotDifferencesFromProduction` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slotsdiffs` | Missing. | Present. |
| `Microsoft.Web.Sites.listSnapshotsFromDRSecondary` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/snapshotsdr` | Missing. | Present. |
| `Microsoft.Web.Sites.listSyncFunctionTriggers` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listsyncfunctiontriggerstatus` | Missing. | Present. |
| `Microsoft.Web.Sites.listUsages` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/usages` | Missing. | Present. |
| `Microsoft.Web.Sites.listWorkflowsConnections` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/listWorkflowsConnections` | Missing. | Present. |
| `Microsoft.Web.Sites.resetProductionSlotConfig` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resetSlotConfig` | Missing. | Present. |
| `Microsoft.Web.Sites.restart` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restart` | Missing. | Present. |
| `Microsoft.Web.Sites.restoreFromBackupBlob` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreFromBackupBlob` | Missing. | Present. |
| `Microsoft.Web.Sites.restoreFromDeletedApp` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreFromDeletedApp` | Missing. | Present. |
| `Microsoft.Web.Sites.restoreSnapshot` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/restoreSnapshot` | Missing. | Present. |
| `Microsoft.Web.Sites.startNetworkTrace` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/startNetworkTrace` | Missing. | Present. |
| `Microsoft.Web.Sites.startWebSiteNetworkTrace` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/start` | Missing. | Present. |
| `Microsoft.Web.Sites.startWebSiteNetworkTraceOperation` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/startOperation` | Missing. | Present. |
| `Microsoft.Web.Sites.stop` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/stop` | Missing. | Present. |
| `Microsoft.Web.Sites.stopNetworkTrace` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/stopNetworkTrace` | Missing. | Present. |
| `Microsoft.Web.Sites.stopWebSiteNetworkTrace` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkTrace/stop` | Missing. | Present. |
| `Microsoft.Web.Sites.swapSlotWithProduction` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slotsswap` | Missing. | Present. |
| `Microsoft.Web.Sites.syncFunctionTriggers` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/syncfunctiontriggers` | Missing. | Present. |
| `Microsoft.Web.Sites.syncRepository` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sync` | Missing. | Present. |
| `Microsoft.Web.Sites.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}` | Missing. | Present. |
| `Microsoft.Web.Sites.updateApplicationSettings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/appsettings` | Missing. | Present. |
| `Microsoft.Web.Sites.updateAuthSettings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettings` | Missing. | Present. |
| `Microsoft.Web.Sites.updateAzureStorageAccounts` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/azurestorageaccounts` | Missing. | Present. |
| `Microsoft.Web.Sites.updateBackupConfiguration` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/backup` | Missing. | Present. |
| `Microsoft.Web.Sites.updateConnectionStrings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/connectionstrings` | Missing. | Present. |
| `Microsoft.Web.Sites.updateMachineKey` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/updatemachinekey` | Missing. | Present. |
| `Microsoft.Web.Sites.updateMetadata` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/metadata` | Missing. | Present. |
| `Microsoft.Web.Sites.updateSitePushSettings` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/pushsettings` | Missing. | Present. |
| `Microsoft.Web.Users.getPublishingUser` | `/providers/Microsoft.Web/publishingUsers/web` | Missing. | Present. |
| `Microsoft.Web.Users.updatePublishingUser` | `/providers/Microsoft.Web/publishingUsers/web` | Missing. | Present. |

