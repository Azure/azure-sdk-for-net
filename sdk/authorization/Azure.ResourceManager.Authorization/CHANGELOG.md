# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

- Change ResourceType from `Microsoft.Authorization/roleManagementPolicyAssignment` to `Microsoft.Authorization/roleManagementPolicyAssignments`

### Other Changes

## 1.1.0 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-25)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-05)

This release is the first stable release of the Authorization Management client library.

### Breaking Changes

- Corrected the type of property `LinkedRoleEligibilityScheduleId` of RoleAssignmentScheduleData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `LinkedRoleEligibilityScheduleId` of RoleAssignmentScheduleInstanceData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `LinkedRoleEligibilityScheduleInstanceId` of RoleAssignmentScheduleInstanceData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `LinkedRoleEligibilityScheduleId` of RoleAssignmentScheduleRequestData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `TargetRoleAssignmentScheduleId` of RoleAssignmentScheduleRequestData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `TargetRoleAssignmentScheduleInstanceId` of RoleAssignmentScheduleRequestData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `TargetRoleEligibilityScheduleId` of RoleEligibilityScheduleRequestData from `Guid` to `ResourceIdentifier`.
- Corrected the type of property `TargetRoleEligibilityScheduleInstanceId` of RoleEligibilityScheduleRequestData from `Guid` to `ResourceIdentifier`.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `Authorization` / `RoleManagement` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) that provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Authorization` to `Azure.ResourceManager.Authorization`

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
