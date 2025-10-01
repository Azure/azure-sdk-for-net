# Release History

## 1.1.0-beta.1 (2025-09-09)

### Features Added

Upgrade to api-version 2025-07-01-preview:
- Connector Templates: Create reusable templates to streamline connector configuration and deployment across Azure IoT Operations clusters.
- ADR Namespaces: Enable logical isolation and security boundaries for managing assets and devices at scale.
- Devices: Support for devices with inbound endpoints, including cross-connector capabilities.
- ONVIF Connector: Integrate ONVIF-compliant cameras and devices for video and surveillance scenarios.
- Media Connector: Ingest and process media streams from diverse sources with enhanced flexibility.
- REST Connector: Connect to any RESTful endpoint, enabling seamless integration with external systems and APIs.
- Enrich: Enhance incoming data with contextual metadata from REST endpoints to support advanced analytics.
- Discovery of Devices and Assets: Automatically detect and onboard devices and assets, reducing manual configuration.
- Regional Expansion: Azure IoT Operations is now deployable to Arc-connected clusters in the Germany West Central region. This support is available in the latest preview and backported to GA version 1.1.59
- Advanced Dataflow Operations: Dataflow graphs allow for definitions of custom workflows and transformations. Custom operations can now be performed using WASMmodules provided by customers .
 

### Other Changes

ExtendedLocation is now optional in the following resources: 
- IotOperationsBroker
- IotOperationsBrokerListener
- IotOperationsBrokerAuthentication
- IotOperationsBrokerAuthorization
- IotOperationsDataflowEndpoint
- IotOperationsDataflowProfile
- IotOperationsDataflow

## 1.0.0 (2024-11-01)

This release is the first stable release of the IotOperations Management client library.

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
