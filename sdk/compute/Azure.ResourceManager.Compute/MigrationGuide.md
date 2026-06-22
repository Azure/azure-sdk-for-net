# Migration guide for Azure.ResourceManager.Compute 1.15.0

This guide helps customers migrate from `Azure.ResourceManager.Compute` 1.14.x or earlier stable versions to `Azure.ResourceManager.Compute` 1.15.0.

Version 1.15.0 is the first stable release of the Compute management library generated from Compute TypeSpec definitions. The package name, namespace, authentication model, and ARM resource pattern remain the same, but the generated API surface is more directly aligned with the service model. To preserve compatibility, many previously shipped members are still present but are marked `[Obsolete]` and hidden from IntelliSense with `[EditorBrowsable(EditorBrowsableState.Never)]`.

## Migration benefits

The TypeSpec-generated release provides:

- A generated API surface aligned with the latest Compute service definitions.
- New Compute features, including Virtual Machine Scale Set lifecycle hook event resources, resiliency and recovery settings, Interconnect Block APIs, and automatic SKU migration policy support.
- More consistent naming and grouping across generated models, request content, patch models, and resource collections.
- Improved long-term maintainability for future Compute API versions.

## Recommended migration approach

1. Upgrade your package reference to `Azure.ResourceManager.Compute` 1.15.0.
2. Build your solution and address compiler warnings for obsolete members.
3. Replace obsolete compatibility members with the newer generated properties listed below.
4. Run your unit and integration tests, especially code that creates or updates VM, VM scale set, capacity reservation, restore point, gallery, or networking-related Compute models.
5. Remove any dependencies on Cloud Services (classic) APIs from this package. These APIs are obsolete and no longer supported by the generated Compute client.

## General API shape changes

### Prefer generated nested model properties

Some older root-level convenience properties are now compatibility shims over properties that live on generated nested models. Prefer the generated nested model property when writing new code.

For example, code that reads VMSS VM network interface configurations through `VirtualMachineScaleSetVmData.NetworkInterfaceConfigurations` should move to the generated property path:

```C#
IList<VirtualMachineScaleSetNetworkConfiguration> configurations =
    vmssVm.Data.Properties.NetworkProfileConfiguration.NetworkInterfaceConfigurations;
```

The root-level compatibility property remains available where required by previous public API shape, but new code should prefer the generated model path.

### Prefer Compute-specific resource reference models

The TypeSpec-generated Compute surface uses Compute-specific reference models such as `ComputeWriteableSubResourceData` and `ComputeSubResourceData` instead of some older `Azure.ResourceManager.Resources.Models.WritableSubResource` and `SubResource` properties.

This affects several obsolete compatibility properties. The older properties are present only to preserve compatibility and are not wired to service serialization. Use the replacement properties instead.

| Old member | Replacement |
| --- | --- |
| `AvailabilitySetData.VirtualMachines` | `AvailabilitySetData.VirtualMachineResources` |
| `AvailabilitySetPatch.VirtualMachines` | `AvailabilitySetPatch.VirtualMachineResources` |
| `CapacityReservationGroupData.CapacityReservations` | `CapacityReservationGroupData.CapacityReservationResources` |
| `CapacityReservationGroupData.VirtualMachinesAssociated` | `CapacityReservationGroupData.AssociatedVirtualMachineResources` |
| `CapacityReservationGroupData.SharingSubscriptionIds` | `CapacityReservationGroupData.SharingSubscriptionResources` |
| `CapacityReservationGroupPatch.CapacityReservations` | `CapacityReservationGroupPatch.CapacityReservationResources` |
| `CapacityReservationGroupPatch.VirtualMachinesAssociated` | `CapacityReservationGroupPatch.AssociatedVirtualMachineResources` |
| `CapacityReservationGroupPatch.SharingSubscriptionIds` | `CapacityReservationGroupPatch.SharingSubscriptionResources` |
| `RestorePointData.ExcludeDisks` | `RestorePointData.ExcludedDisks` |
| `VirtualMachineNetworkInterfaceIPConfiguration.ApplicationGatewayBackendAddressPools` | `VirtualMachineNetworkInterfaceIPConfiguration.ApplicationGatewayBackendAddressPoolResources` |
| `VirtualMachineNetworkInterfaceIPConfiguration.ApplicationSecurityGroups` | `VirtualMachineNetworkInterfaceIPConfiguration.ApplicationSecurityGroupResources` |
| `VirtualMachineNetworkInterfaceIPConfiguration.LoadBalancerBackendAddressPools` | `VirtualMachineNetworkInterfaceIPConfiguration.LoadBalancerBackendAddressPoolResources` |
| `VirtualMachineScaleSetIPConfiguration.ApplicationGatewayBackendAddressPools` | `VirtualMachineScaleSetIPConfiguration.ApplicationGatewayBackendAddressPoolResources` |
| `VirtualMachineScaleSetIPConfiguration.ApplicationSecurityGroups` | `VirtualMachineScaleSetIPConfiguration.ApplicationSecurityGroupResources` |
| `VirtualMachineScaleSetIPConfiguration.LoadBalancerBackendAddressPools` | `VirtualMachineScaleSetIPConfiguration.LoadBalancerBackendAddressPoolResources` |
| `VirtualMachineScaleSetIPConfiguration.LoadBalancerInboundNatPools` | `VirtualMachineScaleSetIPConfiguration.LoadBalancerInboundNatPoolResources` |
| `VirtualMachineScaleSetUpdateIPConfiguration.ApplicationGatewayBackendAddressPools` | `VirtualMachineScaleSetUpdateIPConfiguration.ApplicationGatewayBackendAddressPoolResources` |
| `VirtualMachineScaleSetUpdateIPConfiguration.ApplicationSecurityGroups` | `VirtualMachineScaleSetUpdateIPConfiguration.ApplicationSecurityGroupResources` |
| `VirtualMachineScaleSetUpdateIPConfiguration.LoadBalancerBackendAddressPools` | `VirtualMachineScaleSetUpdateIPConfiguration.LoadBalancerBackendAddressPoolResources` |
| `VirtualMachineScaleSetUpdateIPConfiguration.LoadBalancerInboundNatPools` | `VirtualMachineScaleSetUpdateIPConfiguration.LoadBalancerInboundNatPoolResources` |

#### Example: capacity reservation group references

Before:

```C#
foreach (SubResource reservation in capacityReservationGroup.Data.CapacityReservations)
{
    Console.WriteLine(reservation.Id);
}
```

After:

```C#
foreach (ComputeSubResourceData reservation in capacityReservationGroup.Data.CapacityReservationResources)
{
    Console.WriteLine(reservation.Id);
}
```

#### Example: VM scale set IP configuration backend pools

Before:

```C#
ipConfiguration.ApplicationGatewayBackendAddressPools.Add(
    new WritableSubResource { Id = applicationGatewayBackendPoolId });
```

After:

```C#
ipConfiguration.ApplicationGatewayBackendAddressPoolResources.Add(
    new ComputeWriteableSubResourceData(applicationGatewayBackendPoolId));
```

## Renamed compatibility members

Some older names are retained as obsolete aliases while the generated name should be used in new code.

| Old member | Replacement |
| --- | --- |
| `CommunityGalleryInfo.PublisherUri` | `CommunityGalleryInfo.PublisherUriString` |
| `GalleryImageVersionPatch.Restore` | `GalleryImageVersionPatch.IsRestoreEnabled` |

## Cloud Services APIs

Cloud Services (classic) operations are no longer supported by the generated Compute client. CloudService-related types, extension methods, resource methods, and model factory helpers are obsolete and are preserved only for compatibility with existing source and binaries.

Affected API areas include:

- `CloudServiceResource`, `CloudServiceData`, and `CloudServiceCollection`.
- Cloud Service role, role instance, OS family, and OS version resource types.
- Cloud Service extension and network/profile model types.
- `ComputeExtensions` and `MockableCompute*` methods that return or list Cloud Service resources.
- `ArmComputeModelFactory` helpers for Cloud Service model types.

If your application still depends on Cloud Services (classic) management APIs, keep using a previous package version while planning migration away from those APIs.

## Model factory changes

`ArmComputeModelFactory` follows the generated TypeSpec model shape. If you use factory methods for tests, update arguments to match replacement properties when a compatibility property has been deprecated.

For example, prefer factory overloads and parameters using:

- `CapacityReservationResources` instead of `CapacityReservations`.
- `AssociatedVirtualMachineResources` instead of `VirtualMachinesAssociated`.
- `SharingSubscriptionResources` instead of `SharingSubscriptionIds`.
- `ApplicationGatewayBackendAddressPoolResources`, `ApplicationSecurityGroupResources`, `LoadBalancerBackendAddressPoolResources`, and `LoadBalancerInboundNatPoolResources` instead of the older common-resource list properties.

## New APIs in this release

This stable release includes features introduced during the 1.15.0 preview and additional APIs from the merged Compute service definitions, including:

- `InterconnectBlockResource`, `InterconnectBlockCollection`, `InterconnectBlockData`, and related Interconnect Block models.
- Virtual Machine Scale Set lifecycle hook event resource APIs and supporting models.
- VM Scale Set resiliency and recovery policy models.
- `ExternalHealthPolicy` support.
- Storage fault-domain alignment models and enums.
- Automatic SKU migration policy support through `ComputeSkuProfile.IsAutomaticSkuMigrationPolicyEnabled`.

## Troubleshooting

### I see obsolete warnings after upgrading

Replace the obsolete member with the suggested replacement from this guide or from the `[Obsolete]` message. Many compatibility properties are intentionally not wired to the service request/response payload and should not be used in new code.

### My code uses CloudService APIs

CloudService APIs in this package are obsolete and unsupported in the TypeSpec-generated client. Continue using a previous package version temporarily if needed, and plan migration away from Cloud Services (classic) APIs.

### My serialized payload changed

Review usages of obsolete compatibility properties. Set values on the generated replacement properties instead. Compatibility placeholders may exist to preserve compile-time compatibility, but request serialization follows the generated TypeSpec model.
