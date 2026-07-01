# ARM provider schema comparison: Azure.ResourceManager.Advisor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

Only one requested-axis difference: `resolveArmResources` adds one subscription-scoped list operation, and that addition makes sense.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 8 resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | One valid `resolveArmResources` addition. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 8 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** one valid `resolveArmResources` addition.

#### List/action operation differences: `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Advisor.ResourceRecommendationBases.list` | `List` | `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/recommendations` | Missing. | Present. |

This subscription-scoped list operation is a reasonable addition for the recommendation resource.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 7 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/Microsoft.Advisor/metadata/{name}` | `AdvisorMetadataEntity` | `MetadataEntity` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/assessments/{assessmentName}` | `AdvisorAssessment` | `AssessmentResult` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}` | `AdvisorResiliencyReview` | `ResiliencyReview` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}` | `AdvisorTriageRecommendation` | `TriageRecommendations` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Advisor/resiliencyReviews/{reviewId}/providers/Microsoft.Advisor/triageRecommendations/{recommendationId}/providers/Microsoft.Advisor/triageResources/{recommendationResourceId}` | `AdvisorTriage` | `TriageResources` |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}` | `AdvisorRecommendation` | `ResourceRecommendationBase` |
| `/{resourceUri}/providers/Microsoft.Advisor/recommendations/{recommendationId}/suppressions/{name}` | `AdvisorSuppressionContract` | `SuppressionContract` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Azure.ResourceManager.Legacy.Operations.list` | `/providers/Microsoft.Advisor/operations` | Missing. | Present. |
