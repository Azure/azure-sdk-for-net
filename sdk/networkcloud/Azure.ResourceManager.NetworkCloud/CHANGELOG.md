# Release History

## 1.1.0 (Unreleased)

- This is a stable SDK version based on the 2024-07-01 API.

## 1.1.0-beta.1 (2024-11-06)

### Features Added

- This SDK version supports 2024-06-01-preview API version.
- ClusterManager resource supports system-assigned and user-assigned identities.
- Cluster resource supports system-assigned and user-assigned identities.
- Cluster resource supports version update with the pause and a new command to continue the update. ClusterDetailedStatus got a new value "UpdatePaused" to represent Cluster update status being paused.
- Cluster resource supports the new scan runtime command, and RuntimeProtectionEnforcementLevel got a new value "OnDemand".
- ClusterConnectionStatus got a new value representing "Disconnected" status of the Cluster.
- CommandOutputSettings is added to Cluster configuration for provisioning of a storage account used during BareMetalMachine command execution result download.
- ClusterSecretArchive is added to configure a key vault for Cluster's secrets storage.
- ClusterUpdateStrategy is added to support a rack pause during Cluster update.
- KubernetesClusterFeature is added that enables managing addons for the KubernetesCluster.
- AgentPoolUpgradeSettings is added that configures upgrade setting for the KubernetesCluster agent pool.
- l2ServiceLoadBalancerConfiguration is added to support an alternative load balancer for the KubernetesCluster.
- KubernetesCluster configuration is added to support additional upgrade settings drainTimeout and maxUnavailable for initial agent pools. The same configuration is added to the KubernetesCluster agentpool.
- BareMetalMachine has new properties returned for the machine cluster version, machine roles, runtime protection status, and secret rotation status.
- StorageAppliance has new properties returned for the appliance manifacturer, model, version, and secret rotation status.
- KeySetUser has a new property containing a user principal name that can be set.
- RackSkuProvisioningState got new values "Cancelled" and "Failed" to better represent its state.
- NetworkCloudOperationStatusResult now exposes additional properties to get access for BareMetalMachine command execution result, such as, exitCode, outputHead, resultRef, and resultUri.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Other Changes

- A clarification is added to the descriptions throughout that memory and disk sizes are measured in gibibytes.
- ServiceLoadBalancerBgpPeer has the following optional fields marked as deprecated: "holdTime" and "keepAliveTime". If defined, their values will be ignored.
- For consistency with the API implementation, synchronous DELETE commands were removed and Location header is added to all PATCH update commands.

## 1.0.1 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0 (2023-08-22)

This is the first stable SDK for NetworkCloud based on 2023-07-01 APIs.

### Features Added

- Upgraded API version to 2023-07-01.

### Breaking Changes

Polishing since last public beta release:
- Prepended `NetworkCloud` prefix to all single / simple model names.
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

## 1.0.0-beta.2 (2023-06-30)

### Features Added

This version adds support to KubernetesCluster resource and its child resource AgentPool.

### Breaking Changes

This version no longer supports HybridAksCluster and DefaultCniNetwork resource. Customers are redirected to use newly created KubernetesCluster resource instead.

### Other Changes

Upgrades API version to 2023-05-01-preview.

## 1.0.0-beta.1 (2023-05-26)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
