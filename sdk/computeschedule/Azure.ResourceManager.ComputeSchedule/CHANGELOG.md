# Release History

## 1.2.0-beta.1 (2025-09-12)

### Features Added

- Updated the Computeschedule RP api-version from `2025-05-01` to the preview version `2025-04-15-preview`.
    -New endpoints were added for the recurring scheduledactions feature which will allow customers create recurring scheduledactions to perform actions on their virtual machines. These actions include:
        - Creating and deleting of recurring starts, deallocates and hibernates on virtual machines
        - Attaching and detaching virtual machines from recurring scheduledactions
        - Cancelling and delaying scheduled/unscheduled occurrences of start/deallocate/hibernates on attached virtual machines attached to recurring scheduledactions

## 1.1.0 (2025-09-12)

### Features Added

- Updated the Computeschedule RP api-version from `2024-10-01` to the stable version `2025-05-01`.

## 1.0.0 (2025-01-24)

### Features Added

- Updated the Computeschedule RP api-version from `2024-08-15-preview` to the first stable version `2024-10-01`.

### Bugs Fixed

- Changed the errorDetails in OperationErrorDetails from dateTime to string.
- Added AzureOperationName in results returned when calling `GetOperationErrors` endpoint.

## 1.0.0-beta.1 (2024-09-27)

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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
