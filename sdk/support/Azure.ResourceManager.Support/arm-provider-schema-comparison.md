# ARM provider schema comparison: Azure.ResourceManager.Support

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 hierarchy differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 12 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 3 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 12 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 3 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.support/fileworkspaces/{}/files/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Tenant, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/microsoft.support/supporttickets/{}/chattranscripts/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Tenant, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/microsoft.support/supporttickets/{}/communications/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Tenant, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 11 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.support/fileworkspaces/{}` | `TenantFileWorkspace` | `FileWorkspaces` |
| `/providers/microsoft.support/fileworkspaces/{}/files/{}` | `SupportTicketNoSubFile` | `FileWorkspacesFiles` |
| `/providers/microsoft.support/services/{}` | `SupportAzureService` | `Service` |
| `/providers/microsoft.support/supporttickets/{}` | `TenantSupportTicket` | `SupportTickets` |
| `/providers/microsoft.support/supporttickets/{}/chattranscripts/{}` | `SupportTicketNoSubChatTranscript` | `SupportTicketsChatTranscripts` |
| `/providers/microsoft.support/supporttickets/{}/communications/{}` | `SupportTicketNoSubCommunication` | `SupportTicketsCommunications` |
| `/subscriptions/{}/providers/microsoft.support/fileworkspaces/{}` | `SubscriptionFileWorkspace` | `FileWorkspaces` |
| `/subscriptions/{}/providers/microsoft.support/fileworkspaces/{}/files/{}` | `SupportTicketFile` | `FileWorkspacesFiles` |
| `/subscriptions/{}/providers/microsoft.support/supporttickets/{}` | `SubscriptionSupportTicket` | `SupportTickets` |
| `/subscriptions/{}/providers/microsoft.support/supporttickets/{}/chattranscripts/{}` | `SupportTicketChatTranscript` | `SupportTicketsChatTranscripts` |
| `/subscriptions/{}/providers/microsoft.support/supporttickets/{}/communications/{}` | `SupportTicketCommunication` | `SupportTicketsCommunications` |

