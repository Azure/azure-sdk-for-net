# ARM provider schema comparison: Azure.ResourceManager.Advisor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

The Advisor resource detection result is mostly equivalent between the legacy detector and `resolveArmResources` when compared by `resourceIdPattern`.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same eight resource ID patterns in both schemas. No missing patterns on either side. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same `resourceModelId` and `resourceType` for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | `resolveArmResources` correctly attaches one additional subscription-scoped list operation. All other list/action operations match. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same eight `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 8 | All Advisor resource ID patterns are present in both snapshots. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

Hierarchy is represented by the resource-level `scope` object in these schema snapshots. All eight matching resource ID patterns have the same hierarchy in both schemas.

| Resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy | Result |
| --- | --- | --- | --- |
| `/providers/Microsoft.Advisor/metadata/{name}` | Tenant, `scopeIdPattern: ""`, `scopeResourceType: Microsoft.Resources/tenants` | Tenant, `scopeIdPattern: ""`, `scopeResourceType: Microsoft.Resources/tenants` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/advisorScore/{name}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/assessments/{assessmentName}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}` | Extension, `scopeIdPattern: /subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}`, `scopeResourceType: Microsoft.Advisor/resiliencyReviews` | Extension, `scopeIdPattern: /subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}`, `scopeResourceType: Microsoft.Advisor/resiliencyReviews` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}/providers/Microsoft.Advisor/triageResources/{recommendationResourceId}` | Extension, `scopeIdPattern: /subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}`, `scopeResourceType: Microsoft.Advisor/triageRecommendations` | Extension, `scopeIdPattern: /subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}`, `scopeResourceType: Microsoft.Advisor/triageRecommendations` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}` | Extension, `scopeIdPattern: /{resourceUri}` | Extension, `scopeIdPattern: /{resourceUri}` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{name}` | Extension, `scopeIdPattern: /{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}`, `scopeResourceType: Microsoft.Advisor/recommendations` | Extension, `scopeIdPattern: /{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}`, `scopeResourceType: Microsoft.Advisor/recommendations` | Same |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

All matching resource ID patterns use the same `resourceModelId` and `resourceType` in both schemas.

| Resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Resource type | Result |
| --- | --- | --- | --- | --- |
| `/providers/Microsoft.Advisor/metadata/{name}` | `Microsoft.Advisor.MetadataEntity` | `Microsoft.Advisor.MetadataEntity` | `Microsoft.Advisor/metadata` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/advisorScore/{name}` | `Microsoft.Advisor.AdvisorScoreEntity` | `Microsoft.Advisor.AdvisorScoreEntity` | `Microsoft.Advisor/advisorScore` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/assessments/{assessmentName}` | `Microsoft.Advisor.AssessmentResult` | `Microsoft.Advisor.AssessmentResult` | `Microsoft.Advisor/assessments` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}` | `Microsoft.Advisor.ResiliencyReview` | `Microsoft.Advisor.ResiliencyReview` | `Microsoft.Advisor/resiliencyReviews` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}` | `Microsoft.Advisor.TriageRecommendation` | `Microsoft.Advisor.TriageRecommendation` | `Microsoft.Advisor/triageRecommendations` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}/providers/Microsoft.Advisor/triageResources/{recommendationResourceId}` | `Microsoft.Advisor.TriageResource` | `Microsoft.Advisor.TriageResource` | `Microsoft.Advisor/triageResources` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}` | `Microsoft.Advisor.ResourceRecommendationBase` | `Microsoft.Advisor.ResourceRecommendationBase` | `Microsoft.Advisor/recommendations` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{name}` | `Microsoft.Advisor.SuppressionContract` | `Microsoft.Advisor.SuppressionContract` | `Microsoft.Advisor/recommendations/suppressions` | Same |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

CRUD means `Create`, `Read`, `Update`, and `Delete`. The CRUD operation set is the same for every matching resource ID pattern.

| Resource ID pattern | CRUD operations | Result |
| --- | --- | --- |
| `/providers/Microsoft.Advisor/metadata/{name}` | `Read: Microsoft.Advisor.MetadataEntities.get` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/advisorScore/{name}` | `Read: Microsoft.Advisor.AdvisorScoreEntities.get` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/assessments/{assessmentName}` | `Create: Microsoft.Advisor.AssessmentResults.put`; `Read: Microsoft.Advisor.AssessmentResults.get`; `Delete: Microsoft.Advisor.AssessmentResults.delete` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}` | `Read: Microsoft.Advisor.ResiliencyReviews.get` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}` | `Read: Microsoft.Advisor.TriageRecommendations.get` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}/providers/Microsoft.Advisor/triageResources/{recommendationResourceId}` | `Read: Microsoft.Advisor.TriageResources.get` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}` | `Read: Microsoft.Advisor.ResourceRecommendationBases.get`; `Update: Microsoft.Advisor.ResourceRecommendationBases.patch` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{name}` | `Create: Microsoft.Advisor.SuppressionContracts.create`; `Read: Microsoft.Advisor.SuppressionContracts.get`; `Delete: Microsoft.Advisor.SuppressionContracts.delete` | Same |

### 4.2 List and action operations

**Differences:** one valid improvement from `resolveArmResources`. For `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}`, `resolveArmResources` adds `Microsoft.Advisor.ResourceRecommendationBases.list` with request path `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/recommendations`; all other list/action operation sets are identical.

List/action operations match except for one extra list operation in `resolveArmResources`.

| Resource ID pattern | Legacy list/action operations | `resolveArmResources` list/action operations | Result |
| --- | --- | --- | --- |
| `/providers/Microsoft.Advisor/metadata/{name}` | `List: Microsoft.Advisor.MetadataEntities.list` | `List: Microsoft.Advisor.MetadataEntities.list` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/advisorScore/{name}` | `List: Microsoft.Advisor.AdvisorScoreEntities.list` | `List: Microsoft.Advisor.AdvisorScoreEntities.list` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/assessments/{assessmentName}` | `List: Microsoft.Advisor.AssessmentResults.list` | `List: Microsoft.Advisor.AssessmentResults.list` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}` | `List: Microsoft.Advisor.ResiliencyReviews.list` | `List: Microsoft.Advisor.ResiliencyReviews.list` | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}` | `List: Microsoft.Advisor.TriageRecommendations.list`; `Action: Microsoft.Advisor.TriageRecommendations.approveTriageRecommendation`; `Action: Microsoft.Advisor.TriageRecommendations.rejectTriageRecommendation`; `Action: Microsoft.Advisor.TriageRecommendations.resetTriageRecommendation` | Same as legacy | Same |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}/providers/Microsoft.Advisor/triageResources/{recommendationResourceId}` | `List: Microsoft.Advisor.TriageResources.list` | `List: Microsoft.Advisor.TriageResources.list` | Same |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}` | `List: Microsoft.Advisor.ResourceRecommendationBases.listByTenant` | `List: Microsoft.Advisor.ResourceRecommendationBases.listByTenant`; `List: Microsoft.Advisor.ResourceRecommendationBases.list` | Different: `resolveArmResources` adds the subscription-scoped list operation at `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/recommendations`. |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{name}` | None | None | Same |

#### Operation difference details: `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}`

`resolveArmResources` attaches one additional list operation to this resource:

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Advisor.ResourceRecommendationBases.list` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/recommendations` | Missing. | Present. |

The legacy schema only attaches `Microsoft.Advisor.ResourceRecommendationBases.listByTenant` to this resource, with request path `/{resourceUri}/providers/Microsoft.Advisor/recommendations`. The added `resolveArmResources` operation is subscription-scoped and appears to be a valid additional list operation for the same resource.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output:

| Difference | Legacy | `resolveArmResources` | Notes |
| --- | --- | --- | --- |
| `resourceName` values | SDK-style names for seven resources, such as `AdvisorRecommendation`, `AdvisorTriageRecommendation`, and `AdvisorTriage`. | Raw or pluralized names for the same resources, such as `ResourceRecommendationBase`, `TriageRecommendations`, and `TriageResources`. | Outside the requested axes because `resourceModelId` and `resourceType` still match. Legacy names look closer to the current SDK naming style. |
| Provider operations non-resource method | Missing. | Adds `Azure.ResourceManager.Legacy.Operations.list` for `/providers/Microsoft.Advisor/operations` at tenant scope. | Outside the resource-level comparison because it is a non-resource method. |

## Initial assessment

For Advisor, `resolveArmResources` matches the legacy detector on resource ID pattern coverage, hierarchy, resource model selection, and CRUD operations. The only requested-axis difference is a valid extra subscription-scoped recommendation list operation attached by `resolveArmResources`. The main non-axis concern is SDK-facing resource name normalization.
