# Release History

## 2.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.0.0-beta.2 (2022-03-08)

### Features Added
- Provide customers with much lower latency and more transactions per second than the current service limits.
- Provide subsampling for customers so that only subsampled data are processed.
- Provide a model import API to allow customers to warm start the Personalizer service.

### Breaking Changes
- In `PersonalizerAdministrationClient`, `GetPersonalizerModel` and `GetPersonalizerModelAsync` are replaced with `ExportPersonalizerModel` and `ExportPersonalizerModelAsync`.
- In `PersonalizerClientOptions`, `ServiceVersion` is changed from V1_1_preview_1 to V1_1_preview_3.

## 2.0.0-beta.1 (2021-10-05)

### Features Added
- Initial Release of Azure AI [Personalizer cognitive service](https://learn.microsoft.com/azure/cognitive-services/personalizer/) version 2.0.0-beta.1 SDK.
- This is a new release of the Azure AI Personalizer SDK that follows the Azure SDK guidelines, so the structure is a little different from the old SDK.
- [Multi-Slot personalization](https://learn.microsoft.com/azure/cognitive-services/personalizer/how-to-multi-slot?pivots=programming-language-csharp)
- [Personalizer Automatic Optimization](https://learn.microsoft.com/azure/cognitive-services/personalizer/concept-auto-optimization)
- Support Azure Active Directory Authentication.
- New overloads for `Rank`, `Reward` and the `PersonalizerClient` constructor.

### Breaking Changes
- `PersonalizerClient` contains (single and multi-slot) Rank / Reward / Activate functionality.
- All other functionality (ServiceConfiguration, Evaluations, Policy, Model, Log) was moved to `PersonalizerAdministrationClient`.
- All methods are exposed in their top level client. For example `PersonalizerClient.Events.Reward` is now `PersonalizerClient.Reward`.
- Changed method names and signatures to follow Azure SDK guidelines.
