# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

- Started migration to the new TypeSpec-based provisioning generator
  (`@azure-typespec/http-client-csharp-provisioning`). Scaffolding only in this
  PR — regeneration is currently blocked on
  [microsoft/typespec#10485](https://github.com/microsoft/typespec/issues/10485).

## 1.0.0-beta.1 (2026-03-13)

### Features Added

- Initial beta release of Azure.Provisioning.Cdn with support for declarative CDN resource provisioning.
- Added support for CDN Profile, Endpoint, Origin, OriginGroup, CustomDomain, and WebApplicationFirewallPolicy resources.
- Added support for Front Door Endpoint, Origin, OriginGroup, CustomDomain, Route, Rule, RuleSet, Secret, and SecurityPolicy resources.
