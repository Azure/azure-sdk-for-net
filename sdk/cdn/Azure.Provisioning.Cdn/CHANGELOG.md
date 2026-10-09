# Release History

## 1.0.0-beta.4 (2026-10-09)

### Bugs Fixed

- Restored the beta.2 resource name requirements lost during the TypeSpec
  migration for `FrontDoorEndpoint`, `FrontDoorOriginGroup`, `FrontDoorOrigin`,
  and `FrontDoorRoute`. Generated names again allow uppercase letters, numbers,
  and hyphens, with maximum lengths of 46 for endpoints and 90 for origin
  groups, origins, and routes instead of the beta.3 inherited 24-character
  lowercase defaults. Generated resource names may therefore differ when
  upgrading from beta.3.

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
