# Test Recording Fixes for BillingBenefits Migration

## Context

Migration from Swagger/AutoRest (`api-version=2022-11-01`) to TypeSpec-based generation (`api-version=2025-12-01-preview`).

Package: `Azure.ResourceManager.BillingBenefits` (version `1.0.0-beta.5`)

## Original Test Failures

**41 total tests, 2 failures** — both for `TestValidateSavingsPlanOrderAliasPurchase` (sync + async).

Error: `TestRecordingMismatchException` — the test proxy could not match the SDK request against the old recording.

### Root Cause

The `/providers/Microsoft.BillingBenefits/validate` (POST) operation changed between API versions:

| Aspect | Old (`2022-11-01`) | New (`2025-12-01-preview`) |
|--------|-------------------|---------------------------|
| SDK method | `ValidatePurchase` / `ValidatePurchaseAsync` | `Validate` / `ValidateAsync` |
| Request model | `SavingsPlanPurchaseValidateContent` (flat list of `BillingBenefitsSavingsPlanOrderAliasData`) | `BenefitValidateRequest` (polymorphic list of `BenefitValidateModel`) |
| Return type | `Pageable<SavingsPlanValidateResult>` | `Response<BenefitValidateResponse>` |
| Discriminator | None | `benefitType` on abstract `BenefitValidateModel` |

The test code was updated in the PR to use the new models (`SavingsPlanValidateModel` extends `BenefitValidateModel`), but the recordings in `azure-sdk-assets` still reflected the old API.

Two mismatches blocked playback:

1. **API version in URL**: Recording had `api-version=2022-11-01`, SDK sends `api-version=2025-12-01-preview`.
2. **Request body shape**: The new SDK serializes `"benefitType": "SavingsPlan"` (discriminator for `SavingsPlanValidateModel`). The old recording had no such field.

When playback failed, the test framework attempted to re-record against the live service, which also failed (`InvalidResourceType: The resource type 'validate' could not be found in the namespace 'Microsoft.Billing'`).

## Fixes Applied

### Fix 1: API Version Replacement (38 files)

String replacement across all 38 recording files in `.assets/`:

```
2022-11-01 → 2025-12-01-preview
```

This is the standard recording fix pattern for API version changes during migration (see `knowledge/common_recording_fix_patterns.md` pattern #1).

### Fix 2: Add `benefitType` Discriminator (2 files)

Added `"benefitType": "SavingsPlan"` to the validate request body in 2 recording files:

- `TestValidateSavingsPlanOrderAliasPurchase().json`
- `TestValidateSavingsPlanOrderAliasPurchase()Async.json`

Before:
```json
{
  "benefits": [{
    "sku": { "name": "Compute_Savings_Plan" },
    "properties": { ... }
  }]
}
```

After:
```json
{
  "benefits": [{
    "benefitType": "SavingsPlan",
    "sku": { "name": "Compute_Savings_Plan" },
    "properties": { ... }
  }]
}
```

## Why These Fixes Are Legitimate

1. **Beta package**: The SDK is `1.0.0-beta.5` (recorded with `1.0.0-alpha.20221117.1`). Breaking changes are expected in beta — ApiCompat does not enforce backward compatibility for pre-GA packages.

2. **Spec-driven API change**: The validate operation changed in the TypeSpec spec (`routes.tsp`). The old `SavingsPlanPurchaseValidateRequest` model still exists in `models.tsp` but is no longer referenced by any route — replaced by the polymorphic `BenefitValidateRequest`. This is a spec-level API evolution, not a migration artifact.

3. **Serialization is correct**: `SavingsPlanValidateModel` extends abstract `BenefitValidateModel`. The base class serializer unconditionally writes `"benefitType"` (the discriminator). The factory method `ArmBillingBenefitsModelFactory.SavingsPlanValidateModel()` hardcodes `BenefitType.SavingsPlan`. The recording fix matches what the SDK actually serializes on the wire.

4. **Response body unchanged**: The validate response `{"benefits": [{"valid": true}]}` is identical between API versions — no response-side fix was needed.

## Results

After fixes: **41 total, 0 failed, 41 succeeded, 0 skipped**.
