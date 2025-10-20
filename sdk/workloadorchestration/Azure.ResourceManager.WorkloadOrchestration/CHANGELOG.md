# Release History

## 1.1.0 (2025-10-14)

### Features Added
- Upgraded package version to 1.1.0
- Added support for `x-ms-skip-api-version-override` configuration to fix Long Running Operations (LRO) API version handling
- LRO operations now correctly use appropriate API versions for polling endpoints instead of reusing the initial request API version

### Bugs Fixed
- Fixed LRO operations failing when polling `locations/operationStatuses` endpoint with incorrect API version
- Resolved CreateOrUpdate operations timeout issues in EASTUS2EUAP region

## 1.0.0 (2025-09-01)



### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.


> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dot-net).
