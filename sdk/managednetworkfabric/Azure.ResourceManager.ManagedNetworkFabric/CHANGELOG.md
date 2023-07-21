# Release History

## 1.0.0 (2023-07-28)
This release is the first stable release of the Managed Network Fabric library.


### Features Added

This version supports the following new resources:

    1. InternetGateyways
    2. InternetGatewayRules
    3. NetworkTap
    4. NetworkTapRules
    5. NetworkPacketBroker
    6. NeighborGroup

### Breaking Changes

    1. Supported new parameters and removed deprecated parameters in all existing resources.
    2. Supported new post actions in the existing resources.
    3. Removed some post actions that are not needed.

## 1.0.0-beta.1 (2023-06-28)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
