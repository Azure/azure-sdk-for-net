# Release History

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-09-27)

### Features Added

New endpoints were added for the following to be available in public preview
- VirtualMachinesSubmitStart
- VirtualMachinesSubmitDeallocate
- VirtualMachinesSubmitHibernate
- VirtualMachinesExecuteStart
- VirtualMachinesExecuteDeallocate
- VirtualMachinesExecuteHibernate
- VirtualMachinesGetOperationStatus
- VirtualMachinesCancelOperations
- VirtualMachinesGetOperationErrors

The endpoint was also changed from `2024-06-01-preview` to the most recent `2024-08-15-preview` version that includes the `VirtualMachinesGetOperationErrors` endpoint

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
