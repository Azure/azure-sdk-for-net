# ARM provider schema comparison: Azure.ResourceManager.AppContainers

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 legacy-only and 0 resolve-only normalized resource ID patterns; 3 CRUD operation differences; 4 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 38 matching normalized patterns; 3 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 3 differences. |
| List/action operations for matching patterns | 4 differences. |

## 1. Resource ID pattern coverage

**Differences:** 3 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 38 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 3 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/detectorProperties/revisionsApi/revisions/{revisionName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/detectorProperties/rootApi/`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/detectorProperties/rootApi/` |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 3 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/daprComponents/{componentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.ConnectedEnvironmentsDaprComponents.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/daprComponents/{componentName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/httpRouteConfigs/{httpRouteName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.HttpRouteConfigs.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/httpRouteConfigs/{httpRouteName}` | Present. | Missing. |
| `Microsoft.App.HttpRouteConfigs.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/httpRouteConfigs/{httpRouteName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/managedCertificates/{managedCertificateName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.ManagedCertificates.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/managedCertificates/{managedCertificateName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 4 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.ConnectedEnvironmentsDaprComponents.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/daprComponents/{componentName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.ContainerAppsDiagnostics.getRevision` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/detectorProperties/revisionsApi/revisions/{revisionName}` | Missing. | Present. |
| `Microsoft.App.ContainerAppsDiagnostics.getRoot` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/detectorProperties/rootApi/` | Missing. | Present. |
| `Microsoft.App.ContainerAppsDiagnostics.listRevisions` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/detectorProperties/revisionsApi/revisions/` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/labelHistory/{labelName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.ContainerAppsLabelHistory.listLabelHistory` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/labelHistory` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.App.HttpRouteConfigs.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/httpRouteConfigs/{httpRouteName}` | Missing. | Present. |
| `Microsoft.App.HttpRouteConfigs.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/httpRouteConfigs/{httpRouteName}` | Missing. | Present. |
| `Microsoft.App.ManagedCertificates.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/managedCertificates/{managedCertificateName}` | Missing. | Present. |
| `Microsoft.App.ManagedEnvironmentsDiagnostics.getRoot` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{environmentName}/detectorProperties/rootApi/` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 29 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/builders/{}` | `Builder` | `BuilderResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/builders/{}/builds/{}` | `Build` | `BuildResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/connectedenvironments/{}` | `ContainerAppConnectedEnvironment` | `ConnectedEnvironment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/connectedenvironments/{}/daprcomponents/{}` | `ContainerAppConnectedEnvironmentDaprComponent` | `ConnectedEnvironmentsDaprComponents` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/connectedenvironments/{}/storages/{}` | `ContainerAppConnectedEnvironmentStorage` | `ConnectedEnvironmentStorage` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/authconfigs/{}` | `ContainerAppAuthConfig` | `AuthConfig` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/builds/{}` | `ContainerAppsBuild` | `ContainerAppsBuilds` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/functions/{}` | `ContainerAppsFunction` | `ContainerAppsFunctions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/labelhistory/{}` | `LabelHistory` | `ContainerAppsLabelHistory` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/patches/{}` | `ContainerAppsPatch` | `ContainerAppsPatches` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/providers/microsoft.app/logicapps/{}/workflows/{}` | `LogicAppWorkflowEnvelope` | `WorkflowEnvelope` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/resiliencypolicies/{}` | `AppResiliency` | `ContainerAppsResiliencyPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/revisions/{}` | `ContainerAppRevision` | `Revision` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/revisions/{}/functions/{}` | `ContainerAppsRevisionFunction` | `RevisionsFunctions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/revisions/{}/replicas/{}` | `ContainerAppReplica` | `Replica` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/containerapps/{}/sourcecontrols/{}` | `ContainerAppSourceControl` | `SourceControl` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/jobs/{}` | `ContainerAppJob` | `Job` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/jobs/{}/executions/{}` | `ContainerAppJobExecution` | `JobExecution` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}` | `ContainerAppManagedEnvironment` | `ManagedEnvironment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/daprcomponents/{}` | `ContainerAppManagedEnvironmentDaprComponent` | `ManagedEnvironmentsDaprComponents` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/daprcomponents/{}/resiliencypolicies/{}` | `DaprComponentResiliencyPolicy` | `DaprComponentsResiliencyPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/daprsubscriptions/{}` | `DaprSubscription` | `ManagedEnvironmentsDaprSubscriptions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/dotnetcomponents/{}` | `DotNetComponent` | `ManagedEnvironmentsDotNetComponents` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/httprouteconfigs/{}` | `ContainerAppHttpRouteConfig` | `ManagedEnvironmentsHttpRouteConfigs` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/javacomponents/{}` | `JavaComponent` | `ManagedEnvironmentsJavaComponents` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/maintenanceconfigurations/{}` | `ContainerAppMaintenanceConfiguration` | `ManagedEnvironmentsMaintenanceConfigurations` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/managedcertificates/{}` | `ContainerAppManagedCertificate` | `ManagedCertificate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/privateendpointconnections/{}` | `ContainerAppPrivateEndpointConnection` | `ManagedEnvironmentsPrivateEndpointConnections` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.app/managedenvironments/{}/storages/{}` | `ContainerAppManagedEnvironmentStorage` | `ManagedEnvironmentStorage` |

