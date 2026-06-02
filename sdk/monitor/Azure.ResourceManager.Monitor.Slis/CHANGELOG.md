# Release History

## 1.0.0-beta.2 (2026-06-01)

### Features Added

- Added `SliSamplingType.Average` for average sampling.
- Added `SliSamplingType.Count` for count sampling.

### Breaking Changes

- Renamed `SliSamplingType.Avg` to `SliSamplingType.Average`.
- Changed `SliSamplingType` wire values for `Max`, `Min`, and `Sum` from `max`, `min`, and `sum` to `Max`, `Min`, and `Sum`.
- Changed `SliConditionOperator` wire values from symbolic operators to named operators: `==` to `eq`, `!=` to `ne`, `>` to `gt`, `>=` to `gte`, `<` to `lt`, `<=` to `lte`, `@in` to `in`, `!in` to `notin`, `!contains` to `notcontains`, and `!startswith` to `notstartswith`.
- Changed `WindowUptimeCriteriaComparator` wire values from symbolic operators to named operators: `>` to `gt`, `>=` to `gte`, `<` to `lt`, and `<=` to `lte`.

## 1.0.0-beta.1 (2026-04-22)

### Features Added

- Initial preview release of `Azure.ResourceManager.Monitor.Slis` for managing Service Level Indicator (SLI) resources under the `Microsoft.Monitor` namespace.
- Support for SLI resource CRUD operations: create or update, get, delete, and list.
- SLI evaluation with Availability and Latency categories, supporting both window-based and request-based evaluation types with configurable signal sources, aggregation, and SLO baselines.
- Integration with Azure Monitor Workspace (AMW) accounts for metric emission, with managed identity and alert support.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
