# ARM provider schema comparison: Azure.ResourceManager.ApiManagement

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 resource model differences; 5 CRUD operation differences; 17 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 102 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 3 differences. |
| CRUD operations for matching patterns | 5 differences. |
| List/action operations for matching patterns | 17 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 102 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

### Raw resource ID variable-name differences

Raw resource ID pattern mismatches reduced after normalizing path variable names. This means at least some raw differences are only parameter-name differences such as `{name}` vs `{labName}`.

| Raw legacy-only | Raw `resolveArmResources`-only | Normalized legacy-only | Normalized `resolveArmResources`-only |
| ---: | ---: | ---: | ---: |
| 1 | 1 | 0 | 0 |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 3 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalsettings/delegation` | `Microsoft.ApiManagement.PortalDelegationSettings` | `Microsoft.ApiManagement.PortalDelegationSettings` | `Microsoft.ApiManagement/service/portalsettings` | `Microsoft.ApiManagement/service` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalsettings/signin` | `Microsoft.ApiManagement.PortalSigninSettings` | `Microsoft.ApiManagement.PortalSigninSettings` | `Microsoft.ApiManagement/service/portalsettings` | `Microsoft.ApiManagement/service` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalsettings/signup` | `Microsoft.ApiManagement.PortalSignupSettings` | `Microsoft.ApiManagement.PortalSignupSettings` | `Microsoft.ApiManagement/service/portalsettings` | `Microsoft.ApiManagement/service` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 5 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.PrivateEndpointConnections.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/privateEndpointConnections/{privateEndpointConnectionName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tagDescriptions/{tagDescriptionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.TagDescriptionContracts.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tagDescriptions/{tagDescriptionId}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/notifications/{notificationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceNotification.workspaceNotificationRecipientEmailCreateOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/notifications/{notificationName}/recipientEmails/{email}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceNotification.workspaceNotificationRecipientUserCreateOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/notifications/{notificationName}/recipientUsers/{userId}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/privateEndpointConnections/{privateEndpointConnectionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.PrivateEndpointConnections.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/privateEndpointConnections/{privateEndpointConnectionName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/templates/{templateName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.EmailTemplateContracts.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/templates/{templateName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 17 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.AccessInformationContracts.deploy` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/deploy` | Missing. | Present. |
| `Microsoft.ApiManagement.AccessInformationContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{accessName}` | Missing. | Present. |
| `Microsoft.ApiManagement.AccessInformationContracts.getSyncState` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/syncState` | Missing. | Present. |
| `Microsoft.ApiManagement.AccessInformationContracts.save` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/save` | Missing. | Present. |
| `Microsoft.ApiManagement.AccessInformationContracts.validate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/validate` | Missing. | Present. |
| `Microsoft.ApiManagement.ApiContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ApiVersionSetContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apiVersionSets/{versionSetId}` | Missing. | Present. |
| `Microsoft.ApiManagement.AuthorizationServerContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/authorizationServers/{authsid}` | Missing. | Present. |
| `Microsoft.ApiManagement.BackendContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/backends/{backendId}` | Missing. | Present. |
| `Microsoft.ApiManagement.CacheContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/caches/{cacheId}` | Missing. | Present. |
| `Microsoft.ApiManagement.CertificateContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/certificates/{certificateId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ClientApplicationContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/clientApplications/{clientApplicationId}` | Missing. | Present. |
| `Microsoft.ApiManagement.DelegationSettings.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalsettings/delegation` | Missing. | Present. |
| `Microsoft.ApiManagement.Diagnostic.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/diagnostics/{diagnosticId}` | Missing. | Present. |
| `Microsoft.ApiManagement.DocumentationContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/documentations/{documentationId}` | Missing. | Present. |
| `Microsoft.ApiManagement.EmailTemplateContracts.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/templates/{templateName}` | Missing. | Present. |
| `Microsoft.ApiManagement.EmailTemplateContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/templates/{templateName}` | Missing. | Present. |
| `Microsoft.ApiManagement.GatewayContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}` | Missing. | Present. |
| `Microsoft.ApiManagement.GlobalSchemaContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/schemas/{schemaId}` | Missing. | Present. |
| `Microsoft.ApiManagement.GroupContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}` | Missing. | Present. |
| `Microsoft.ApiManagement.IdentityProviderContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/identityProviders/{identityProviderName}` | Missing. | Present. |
| `Microsoft.ApiManagement.LoggerContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/loggers/{loggerId}` | Missing. | Present. |
| `Microsoft.ApiManagement.NamedValueContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/namedValues/{namedValueId}` | Missing. | Present. |
| `Microsoft.ApiManagement.OpenidConnectProviderContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/openidConnectProviders/{opid}` | Missing. | Present. |
| `Microsoft.ApiManagement.Policy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/policies/{policyId}` | Missing. | Present. |
| `Microsoft.ApiManagement.PolicyFragmentContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/policyFragments/{id}` | Missing. | Present. |
| `Microsoft.ApiManagement.PolicyRestrictionContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/policyRestrictions/{policyRestrictionId}` | Missing. | Present. |
| `Microsoft.ApiManagement.PortalConfigContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalconfigs/{portalConfigId}` | Missing. | Present. |
| `Microsoft.ApiManagement.PortalRevisionContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalRevisions/{portalRevisionId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ProductContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}` | Missing. | Present. |
| `Microsoft.ApiManagement.SignInSettings.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalsettings/signin` | Missing. | Present. |
| `Microsoft.ApiManagement.SignUpSettings.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalsettings/signup` | Missing. | Present. |
| `Microsoft.ApiManagement.SubscriptionContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/subscriptions/{sid}` | Missing. | Present. |
| `Microsoft.ApiManagement.TagContractOperationGroup.getEntityState` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tags/{tagId}` | Missing. | Present. |
| `Microsoft.ApiManagement.UserContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.ApiContracts.listByApis` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/products` | Different. | Different. |
| `Microsoft.ApiManagement.ApiPolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/policies/{policyId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ApiReleaseContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/releases/{releaseId}` | Missing. | Present. |
| `Microsoft.ApiManagement.DiagnosticContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/diagnostics/{diagnosticId}` | Missing. | Present. |
| `Microsoft.ApiManagement.IssueContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}` | Missing. | Present. |
| `Microsoft.ApiManagement.OperationContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ResolverContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/resolvers/{resolverId}` | Missing. | Present. |
| `Microsoft.ApiManagement.SchemaContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/schemas/{schemaId}` | Missing. | Present. |
| `Microsoft.ApiManagement.Tag.getEntityStateByApi` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tags/{tagId}` | Missing. | Present. |
| `Microsoft.ApiManagement.TagDescriptionContracts.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tagDescriptions/{tagDescriptionId}` | Missing. | Present. |
| `Microsoft.ApiManagement.TagDescriptionContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tagDescriptions/{tagDescriptionId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ToolContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/tools/{toolId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WikiContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/wikis/default` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.IssueAttachmentContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}/attachments/{attachmentId}` | Missing. | Present. |
| `Microsoft.ApiManagement.IssueCommentContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}/comments/{commentId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.PolicyContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}/policies/{policyId}` | Missing. | Present. |
| `Microsoft.ApiManagement.TagContracts.getEntityStateByOperation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}/tags/{tagId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/resolvers/{resolverId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.GraphQLApiResolverPolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/resolvers/{resolverId}/policies/{policyId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/contentTypes/{contentTypeId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.ContentItemContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/contentTypes/{contentTypeId}/contentItems/{contentItemId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.GatewayCertificateAuthorityContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/certificateAuthorities/{certificateId}` | Missing. | Present. |
| `Microsoft.ApiManagement.GatewayContracts.gatewayApiListByService` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis` | Different. | Different. |
| `Microsoft.ApiManagement.GatewayHostnameConfigurationContracts.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/hostnameConfigurations/{hcId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.GroupContracts.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/groups/{groupId}/users` | Different. | Different. |
| `Microsoft.ApiManagement.WorkspaceGroup.checkEntityExists` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}/users/{userId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceGroup.workspaceGroupUserDelete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}/users/{userId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.ProductContracts.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/subscriptions` | Different. | Different. |
| `Microsoft.ApiManagement.ProductContracts.listByProduct` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/apis` | Different. | Different. |
| `Microsoft.ApiManagement.ProductContracts.productGroupListByProduct` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/groups` | Different. | Different. |
| `Microsoft.ApiManagement.ProductPolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/policies/{policyId}` | Missing. | Present. |
| `Microsoft.ApiManagement.ProductWiki.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/wikis/default` | Missing. | Present. |
| `Microsoft.ApiManagement.TagContractOperation.getEntityStateByProduct` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/products/{productId}/tags/{tagId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{accessName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.AccessInformationContracts.deploy` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/deploy` | Present. | Missing. |
| `Microsoft.ApiManagement.AccessInformationContracts.getSyncState` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/syncState` | Present. | Missing. |
| `Microsoft.ApiManagement.AccessInformationContracts.save` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/save` | Present. | Missing. |
| `Microsoft.ApiManagement.AccessInformationContracts.validate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tenant/{configurationName}/validate` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.UserContracts.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/users/{userId}/groups` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceApi.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceApiVersionSet.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apiVersionSets/{versionSetId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceBackend.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/backends/{backendId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceCertificate.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/certificates/{certificateId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceDiagnostic.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/diagnostics/{diagnosticId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceGlobalSchema.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/schemas/{schemaId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceGroup.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceLogger.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/loggers/{loggerId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceNamedValue.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/namedValues/{namedValueId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspacePolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/policies/{policyId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspacePolicyFragment.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/policyFragments/{id}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceProduct.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/products/{productId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceSubscription.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/subscriptions/{sid}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceTag.getEntityState` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/tags/{tagId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceApiDiagnostic.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/diagnostics/{diagnosticId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceApiOperation.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/operations/{operationId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceApiPolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/policies/{policyId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceApiRelease.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/releases/{releaseId}` | Missing. | Present. |
| `Microsoft.ApiManagement.WorkspaceApiSchema.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/schemas/{schemaId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/operations/{operationId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceApiOperationPolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/apis/{apiId}/operations/{operationId}/policies/{policyId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceGroup.checkEntityExists` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}/users/{userId}` | Present. | Missing. |
| `Microsoft.ApiManagement.WorkspaceGroup.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}/users` | Different. | Different. |
| `Microsoft.ApiManagement.WorkspaceGroup.workspaceGroupUserDelete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/groups/{groupId}/users/{userId}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/notifications/{notificationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceNotification.workspaceNotificationRecipientEmailCreateOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/notifications/{notificationName}/recipientEmails/{email}` | Present. | Missing. |
| `Microsoft.ApiManagement.WorkspaceNotification.workspaceNotificationRecipientUserCreateOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/notifications/{notificationName}/recipientUsers/{userId}` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/products/{productId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiManagement.WorkspaceProductPolicy.getEntityTag` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/products/{productId}/policies/{policyId}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 37 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.apimanagement/locations/{}/deletedservices/{}` | `ApiManagementDeletedService` | `DeletedServiceContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/gateways/{}` | `ApiGateway` | `ApiManagementGatewayResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/gateways/{}/configconnections/{}` | `ApiGatewayConfigConnection` | `ApiManagementGatewayConfigConnectionResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/gateways/{}/hostnamebindings/{}` | `GatewayHostnameBinding` | `GatewayHostnameBindingResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}` | `ApiManagementService` | `ApiManagementServiceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}` | `Api` | `ServiceApis` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/diagnostics/{}` | `ApiDiagnostic` | `ApisDiagnostics` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/issues/{}` | `ApiIssue` | `ApisIssues` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/issues/{}/attachments/{}` | `ApiIssueAttachment` | `IssueAttachmentContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/issues/{}/comments/{}` | `ApiIssueComment` | `IssueCommentContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/operations/{}` | `ApiOperation` | `ApisOperations` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/operations/{}/policies/{}` | `ApiOperationPolicy` | `OperationsPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/policies/{}` | `ApiPolicy` | `ApisPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/releases/{}` | `ApiRelease` | `ApisReleases` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/schemas/{}` | `ApiSchema` | `ApisSchemas` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apis/{}/tagdescriptions/{}` | `ApiTagDescription` | `TagDescriptionContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/apiversionsets/{}` | `ApiVersionSet` | `ServiceApiVersionSets` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/authorizationservers/{}` | `ApiManagementAuthorizationServer` | `AuthorizationServerContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/caches/{}` | `ApiManagementCache` | `CacheContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/contenttypes/{}` | `ApiManagementContentType` | `ContentTypeContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/contenttypes/{}/contentitems/{}` | `ApiManagementContentItem` | `ContentItemContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/gateways/{}` | `ApiManagementGateway` | `GatewayContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/gateways/{}/certificateauthorities/{}` | `ApiManagementGatewayCertificateAuthority` | `GatewayCertificateAuthorityContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/gateways/{}/hostnameconfigurations/{}` | `ApiManagementGatewayHostnameConfiguration` | `GatewayHostnameConfigurationContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/identityproviders/{}` | `ApiManagementIdentityProvider` | `IdentityProviderContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/openidconnectproviders/{}` | `ApiManagementOpenIdConnectProvider` | `OpenidConnectProviderContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalrevisions/{}` | `ApiManagementPortalRevision` | `PortalRevisionContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalsettings/delegation` | `ApiManagementPortalDelegationSetting` | `PortalDelegationSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalsettings/signin` | `ApiManagementPortalSignInSetting` | `PortalSigninSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/portalsettings/signup` | `ApiManagementPortalSignUpSetting` | `PortalSignupSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/privateendpointconnections/{}` | `ApiManagementPrivateEndpointConnection` | `ApiManagementServiceResourcePrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/privatelinkresources/{}` | `ApiManagementPrivateLinkResource` | `ApiManagementServiceResourcePrivateLinkResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/settings/{}` | `ApiManagementTenantSetting` | `TenantSettingsContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/templates/{}` | `ApiManagementEmailTemplate` | `EmailTemplateContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/tenant/{}` | `TenantAccessInfo` | `AccessInformationContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/users/{}` | `ApiManagementUser` | `UserContract` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apimanagement/service/{}/workspacelinks/{}` | `ApiManagementWorkspaceLinks` | `ApiManagementWorkspaceLinksResource` |

