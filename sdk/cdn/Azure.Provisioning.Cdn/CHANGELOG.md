# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2026-04-30)

### Bugs Fixed

- Implemented `GetResourceNameRequirements` for `CdnProfile`,
  `FrontDoorEndpoint`, `FrontDoorOriginGroup`, `FrontDoorOrigin`, and
  `FrontDoorRoute` so generated Bicep names use each resource's actual
  Azure length limit instead of the default 24-character cap
  ([#58181](https://github.com/Azure/azure-sdk-for-net/issues/58181)).

## 1.0.0-beta.1 (2026-03-13)

### Features Added

- Initial beta release of Azure.Provisioning.Cdn with support for declarative CDN resource provisioning.
- Added support for CDN Profile, Endpoint, Origin, OriginGroup, CustomDomain, and WebApplicationFirewallPolicy resources.
- Added support for Front Door Endpoint, Origin, OriginGroup, CustomDomain, Route, Rule, RuleSet, Secret, and SecurityPolicy resources.
