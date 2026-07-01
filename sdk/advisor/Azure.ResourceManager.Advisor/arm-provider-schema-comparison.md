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
| List/action operations for matching patterns | One extra list operation is attached by `resolveArmResources`. All other list/action operations match. |

## 1. Resource ID pattern coverage

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 8 | All Advisor resource ID patterns are present in both snapshots. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

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

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output:

- `resolveArmResources` emits different `resourceName` values for seven resources. The legacy names look closer to the current SDK naming style, especially where the `resolveArmResources` names are pluralized (`TriageRecommendations`, `TriageResources`) or raw model names (`ResourceRecommendationBase`).
- `resolveArmResources` includes one additional non-resource method, `Azure.ResourceManager.Legacy.Operations.list`, for `/providers/Microsoft.Advisor/operations` at tenant scope. The legacy schema does not include this method.

## Initial assessment

For Advisor, `resolveArmResources` matches the legacy detector on resource ID pattern coverage, hierarchy, resource model selection, and CRUD operations. The only requested-axis gap is the extra subscription-scoped recommendation list operation attached by `resolveArmResources`. The main non-axis concern is SDK-facing resource name normalization.
