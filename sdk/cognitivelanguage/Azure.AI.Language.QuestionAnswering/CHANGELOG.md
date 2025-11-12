# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added
- Initial preview release of the dedicated runtime (inference) package `Azure.AI.Language.QuestionAnswering.Inference`.
- Provides querying APIs (`QuestionAnsweringClient`, `GetAnswers` / `GetAnswersAsync`, follow‑up context, answer filtering) previously available in the monolithic `Azure.AI.Language.QuestionAnswering` package.
- Targets service API version `2025-05-15-preview`.

### Breaking Changes
- Package split: runtime (inference) types moved out of the authoring package into this dedicated inference package.
- No behavioral changes to existing querying APIs; namespaces for inference remain `Azure.AI.Language.QuestionAnswering`.
- Consumers that wish to slim dependencies for query‑only scenarios can depend on this package instead of the authoring package.

### Bugs Fixed
- N/A (first release after package split).

### Other Changes
- Internal repository restructuring and build configuration to support type forwarding from the authoring package.
- Documentation updated to distinguish authoring (`Azure.AI.Language.QuestionAnswering`) vs inference (`Azure.AI.Language.QuestionAnswering.Inference`).
- Forward compatibility note: future previews may remove or reduce forwarded inference surface from the authoring package—track its changelog for updates.
