# Release History

## 3.6.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 3.5.0 (2025-06-20)

### Other Changes

- Updating .NET runtime dependencies to the 8.x line, the Azure extensions to 1.12.0, and the latest dependencies for the Functions host.

## 3.4.4 (2025-03-14)

### Other Changes

- Updating .NET runtime dependencies to the 6.x line, the Azure extensions to 1.8.0, and the latest dependencies for the Functions host.

## 3.4.3 (2024-11-19)

### Bugs Fixed

- Return correct `WebHook-Allowed-Origin` response header for CloudEvent schema subscriptions for gov cloud.
- Prevent DateTime values from being translated by NewtonSoft when parsing payloads. They are now treated as strings.

## 3.4.2 (2024-07-30)

### Other Changes

- To mitigate a [disclosure vulnerability](https://github.com/advisories/GHSA-m5vv-6r4h-3vj9), updating the transitive dependency for `Azure.Identity` to v1.11.4 via version bump to `Microsoft.Extensions.Azure`.

## 3.4.1 (2024-04-17)

### Other Changes

- To mitigate a [disclosure vulnerability](https://github.com/advisories/GHSA-wvxc-855f-jvrv), updating the transitive dependency for `Azure.Identity` to v1.11.1 via version bump to `Microsoft.Extensions.Azure`.

## 3.3.1 (2023-11-13)

### Other Changes

- Bump dependency on `Microsoft.Extensions.Azure` to prevent transitive dependency on deprecated version of `Azure.Identity`.

## 3.3.0 (2023-06-14)

### Acknowledgments
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions to this release:

- Andrew Williamson  _([GitHub](https://github.com/andrewjw1995))_

### Features Added

- Added the ability to use Active Directory authentication when using the `EventGrid` output binding. _(A community contribution, courtesy of [andrewjw1995](https://github.com/andrewjw1995))_

## 3.2.1 (2022-09-08)

### Bugs Fixed

- EventGrid Trigger execution failed in azure portal.

## 3.2.0 (2022-04-20)

### Features Added

- Added support for creating CloudEvent subscriptions using OPTIONS handshake.

## 3.1.0 (2022-01-11)

### Features Added

- Support end-to-end distributed tracing and correlation for `CloudEvents` schema.

## 3.0.1 (2021-12-03)

### Bugs Fixed

- Added output binding for byte array to support integration with other languages

## 3.0.0 (2021-10-21)

### Features Added

- General availability of Microsoft.Azure.WebJobs.Extensions.EventGrid 3.0.0.

## 3.0.0-beta.4 (2021-10-11)

### Key Bugs Fixed

- Avoid synchronously waiting for batch trigger execution

## 3.0.0-beta.3 (2021-06-08)

### Key Bug Fixes

- Fix issue when parsing CloudEvent schema subscription validation request.

## 3.0.0-beta.2 (2021-05-11)

### Added

- Binding to the `CloudEvent` type is now supported.

## 3.0.0-beta.1 (2021-03-23)

- The initial release of Microsoft.Azure.WebJobs.Extensions.EventGrid 3.0.0
