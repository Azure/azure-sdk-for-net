# Release History

## 2.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.0.0-beta.1 (2021-10-05)

### Features Added
- Initial Release of Azure AI [Personalizer cognitive service](https://docs.microsoft.com/azure/cognitive-services/personalizer/) version 2.0.0-beta.1 SDK.
- This is a new release of the Azure AI Personalizer SDK that follows the Azure SDK guidelines, so the structure is a little different from the old SDK.
- [Multi-Slot personalization](https://docs.microsoft.com/azure/cognitive-services/personalizer/how-to-multi-slot?pivots=programming-language-csharp)
- [Personalizer Automatic Optimization](https://docs.microsoft.com/azure/cognitive-services/personalizer/concept-auto-optimization)
- Support Azure Active Directory Authentication.
- New overloads for `Rank`, `Reward` and the `PersonalizerClient` constructor.

### Breaking Changes
- `PersonalizerClient` contains (single and multi-slot) Rank / Reward / Activate functionality.
- All other functionality (ServiceConfiguration, Evaluations, Policy, Model, Log) was moved to `PersonalizerAdministrationClient`.
- All methods are exposed in their top level client. For example `PersonalizerClient.Events.Reward` is now `PersonalizerClient.Reward`.
- Changed method names and signatures to follow Azure SDK guidelines.
