# Release History

## 1.0.0-beta.4 (2026-09-24)

### Bugs Fixed

- Restored resource name requirements lost during the TypeSpec migration for
  `FrontDoorOriginGroup`, `FrontDoorOrigin`, and `FrontDoorRoute`. These
  resources now use Azure's documented 1-50 character constraints instead of
  the inherited 1-24 lowercase defaults. The authoritative 50-character limit
  also replaces beta.2's historical 90-character value, so automatically
  generated names may change or be truncated sooner when upgrading.

## 1.0.0-beta.3 (2026-06-25)

### Other Changes

- Migrated to the new TypeSpec-based provisioning generator
  (`@azure-typespec/http-client-csharp-provisioning`).

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
