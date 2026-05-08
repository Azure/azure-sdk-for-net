# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial beta release of Azure.Provisioning.CostManagement with support for declarative Cost Management resource provisioning.
- Added support for Cost Management Export, View, and Scheduled Action resources.

### Other Changes

- Scaffolded for the new TypeSpec-based provisioning generator
  (`@azure-typespec/http-client-csharp-provisioning`). Regeneration via the new
  generator is currently blocked on
  [microsoft/typespec#10485](https://github.com/microsoft/typespec/issues/10485);
  the source files in this initial release were produced by the legacy
  reflection-based provisioning generator.
