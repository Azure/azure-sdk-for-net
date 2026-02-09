# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2025-12-03)

### Features Added
- Introduces standalone inference package for runtime Q&A.
- Supports knowledge base and text queries using preview service version `2025-05-15-preview`.
- Adds query tuning and ranking configuration:
    - Adds `AnswersOptions.QueryPreferences` property.
    - Adds models: `QueryPreferences`, `MatchingPolicy`, `PrebuiltQueryMatchingPolicy`.
    - Adds unions/enums: `Scorer` (Classic, Transformer, Semantic), `MatchingPolicyKind` (Prebuilt), MatchingPolicyFieldsType (Questions, Answer).
