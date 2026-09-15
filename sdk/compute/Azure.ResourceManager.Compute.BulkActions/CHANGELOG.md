# Release History

## 1.2.0-beta.3 (2026-09-15)

### Features Added

- Added `LocationBasedBulkCreateResource`, `LocationBasedBulkCreateData`, and `LocationBasedBulkCreateCollection`, along with the `GetLocationBasedBulkCreate`, `GetLocationBasedBulkCreates`, and `GetLocationBasedBulkCreateResource` accessors.
- Added `BulkCreateProperties` and `BulkCreateVmSizeProfile` models.
- Added `GetBulkCreateAsyncOperationStatus` for polling the status of a bulk create operation.

### Breaking Changes

- The launch bulk instances operation has been consolidated into bulk create. `LocationBasedLaunchBulkInstancesOperationResource`, `LocationBasedLaunchBulkInstancesOperationData`, `LocationBasedLaunchBulkInstancesOperationCollection`, and `LaunchBulkInstancesOperationProperties` were removed. Use the corresponding `LocationBasedBulkCreate*` types instead.
- Removed the `GetLocationBasedLaunchBulkInstancesOperation`, `GetLocationBasedLaunchBulkInstancesOperations`, and `GetLocationBasedLaunchBulkInstancesOperationResource` extension methods. Use the `GetLocationBasedBulkCreate*` equivalents instead.
- Removed the `BulkCreateOperation` and `BulkCreateOperationAsync` methods. Bulk create is now modeled as a resource, so create the operation through `LocationBasedBulkCreateCollection` instead.
- Removed the `GetOperationStatus` and `GetVirtualMachines` methods. Use `GetBulkCreateAsyncOperationStatus` instead.
- Renamed `VmSizeProfile` to `BulkCreateVmSizeProfile`.
- Removed `OptimizationPreference`.
- Removed attribute-based VM selection. `VMAttributes`, `VMAttributeSupport`, `VMAttributeMinMaxDouble`, `VMAttributeMinMaxInteger`, `VMCategory`, `AcceleratorManufacturer`, `AcceleratorType`, `ArchitectureType`, `CpuManufacturer`, `LocalStorageDiskType`, `HyperVGeneration`, and `OSType` were removed. Specify VM sizes through `BulkCreateVmSizeProfile` instead.
- Removed the bulk operation error acknowledgement surface: `AcknowledgeBulkOperationErrorsRequestContent`, `AcknowledgeBulkOperationErrorsResponseResult`, `ApiError`, `ApiErrorBase`, and `BulkInstancesInnerError`.
- Removed the VDI provisioning surface: `BulkActionsExecuteVdiCreateRequestContent`, `ExecuteCreateContent`, `ResourceProvisionPayload`, `ResourceProvisionVdiPayload`, and `FlexProperties`.
- Removed `VirtualMachine`, `VMOperationStatus`, `CreateResourceOperationResult`, and `ScheduledActionsExecutionParametersContent`.

### Other Changes

- Updated the client to target API version `2026-09-06-preview`.

## 1.2.0-beta.2 (2026-08-06)

### Features Added

- Added capacity and placement recommendations for bulk start operations.
- Added partial fulfillment controls, including minimum capacity.
- Added pageable per-VM operation status for `BulkCreateCustom`.
- Added resolved VM details to `BulkCreateCustom` results.

### Breaking Changes

- Renamed `RecurringScheduledActions*` models to `ScheduledActions*`.
- Renamed `ResourceProvisioningState` to `OccurrenceResourceProvisioningState`.

### Bugs Fixed

- Renamed the non-resource model to `BulkCreateCustomResolvedItem`.
- Corrected boolean and timestamp property names to follow .NET conventions.

### Other Changes

- Updated the client to target API version `2026-08-06-preview`.

## 1.2.0-beta.1 (2026-08-03)

### Features Added

- The `ExecuteStartContent`, `ExecuteDeallocateContent`, `ExecuteHibernateContent`, and `ExecuteDeleteContent` models now expose a settable `Resources` property and a constructor overload that accepts only `executionParameters`, in addition to the existing `(executionParameters, resources)` constructor.

## 1.1.0 (2026-07-07)

### Breaking Changes

- The bulk operation methods now require an explicit `AzureLocation` parameter instead of inferring the location from the `ResourceGroupResource`. A resource group's location can differ from the location of the resources it contains, so the location must be supplied by the caller. The following overloads that inferred the location were removed:
    - `BulkStartOperation` / `BulkStartOperationAsync`
    - `BulkDeallocateOperation` / `BulkDeallocateOperationAsync`
    - `BulkHibernateOperation` / `BulkHibernateOperationAsync`
    - `BulkDeleteOperation` / `BulkDeleteOperationAsync`
    - `BulkGetOperationsStatus` / `BulkGetOperationsStatusAsync`
    - `BulkCancelOperations` / `BulkCancelOperationsAsync`

## 1.0.0 (2026-06-23)

### Features Added

- Initial GA release of the Azure.ResourceManager.Compute.BulkActions client library, targeting the `Microsoft.Compute` `2026-06-06` stable API version.
- New endpoints were added for the following bulk operations on virtual machines:
    - `BulkStartOperation` / `BulkStartOperationAsync`
    - `BulkDeallocateOperation` / `BulkDeallocateOperationAsync`
    - `BulkHibernateOperation` / `BulkHibernateOperationAsync`
    - `BulkDeleteOperation` / `BulkDeleteOperationAsync`
    - `BulkGetOperationsStatus` / `BulkGetOperationsStatusAsync`
    - `BulkCancelOperations` / `BulkCancelOperationsAsync`

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
