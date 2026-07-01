# ARM provider schema comparison: Azure.ResourceManager.Advisor

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

Both schema snapshots identify the same eight ARM resources. There are no resources present only in the legacy result and no resources present only in the `resolveArmResources` result.

The main gaps are:

- `resolveArmResources` produces different `resourceName` values for seven of the eight resources.
- `resolveArmResources` attaches one additional list operation to `Microsoft.Advisor.ResourceRecommendationBase`.
- `resolveArmResources` classifies the provider operations endpoint as a non-resource method, while the legacy result does not include it.

## Resource coverage

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 8 | All Advisor resources are present in both snapshots. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## Resource name differences

| Resource model | Legacy `resourceName` | `resolveArmResources` `resourceName` | Notes |
| --- | --- | --- | --- |
| `Microsoft.Advisor.AdvisorScoreEntity` | `AdvisorScoreEntity` | `AdvisorScoreEntity` | Same. |
| `Microsoft.Advisor.AssessmentResult` | `AdvisorAssessment` | `AssessmentResult` | Legacy keeps the current SDK-style Advisor prefix and shorter name. |
| `Microsoft.Advisor.MetadataEntity` | `AdvisorMetadataEntity` | `MetadataEntity` | Legacy keeps the current SDK-style Advisor prefix. |
| `Microsoft.Advisor.ResiliencyReview` | `AdvisorResiliencyReview` | `ResiliencyReview` | Legacy keeps the current SDK-style Advisor prefix. |
| `Microsoft.Advisor.ResourceRecommendationBase` | `AdvisorRecommendation` | `ResourceRecommendationBase` | Legacy maps the wire/model name to the SDK resource name. |
| `Microsoft.Advisor.SuppressionContract` | `AdvisorSuppressionContract` | `SuppressionContract` | Legacy keeps the current SDK-style Advisor prefix. |
| `Microsoft.Advisor.TriageRecommendation` | `AdvisorTriageRecommendation` | `TriageRecommendations` | Legacy uses a singular SDK resource name; `resolveArmResources` keeps a pluralized name. |
| `Microsoft.Advisor.TriageResource` | `AdvisorTriage` | `TriageResources` | Legacy uses a singular SDK resource name; `resolveArmResources` keeps a pluralized name. |

The legacy names look more consistent with the existing management-plane SDK naming pattern for this library. The `resolveArmResources` names look closer to raw model or collection segment names and may need SDK naming normalization.

## Resource method differences

| Resource model | Method | Legacy | `resolveArmResources` | Notes |
| --- | --- | --- | --- | --- |
| `Microsoft.Advisor.ResourceRecommendationBase` | `Microsoft.Advisor.ResourceRecommendationBases.list` | Not attached to the resource. | Attached as a `List` method scoped to `/subscriptions/{subscriptionId}`. | `resolveArmResources` discovers the subscription-scoped recommendation list operation. The legacy resource only has `get`, `patch`, and `listByTenant` for this resource. |

All other resource methods match between the two schema snapshots.

## Non-resource method differences

| Method | Legacy | `resolveArmResources` | Notes |
| --- | --- | --- | --- |
| `Azure.ResourceManager.Legacy.Operations.list` | Missing. | Present for `/providers/Microsoft.Advisor/operations` at tenant scope. | This is the provider operations endpoint. It is likely safe as a non-resource method, but it is not part of the legacy result. |

All other non-resource methods match between the two schema snapshots.

## Initial assessment

For Advisor, the resource detection coverage is equivalent, but the legacy result appears better aligned with current SDK resource naming. The likely gaps to investigate in `resolveArmResources` are SDK resource name normalization and plural-to-singular handling. The extra recommendation list operation and provider operations method should be reviewed separately to decide whether they are legitimate improvements over the legacy detector.
