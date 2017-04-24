# Prepare for Azure Management Libraries for .NET 1.0.0 #

Steps to migrate code that uses Azure Management Libraries for .NET from beta 5 to 1.0.0 …

> If this note missed any breaking changes, please open a pull request.

## App service plan adds new required parameter: operating system

To create an `AppServicePlan` in beta5:

```C#
appServiceManager.AppServicePlans.Define(AppServicePlanName)
    .WithRegion(Region.USWest)
    .WithNewResourceGroup(rgName)
    .WwithPricingTier(PricingTier.PremiumP1)
    .Create();
```

To create an `AppServicePlan` in 1.0.0:

```C#
appServiceManager.AppServicePlans.Define(AppServicePlanName)
    .WithRegion(Region.USWest)
    .WithNewResourceGroup(rgName)
    .WithPricingTier(PricingTier.PremiumP1)
    .WithOperatingSystem(OperatingSystem.Windows)
    .Create();
```

## Parameters for `WebApp` creation are re-ordered

In beta 5, we create a `WebApp` with a new plan as following:

```C#
azure.WebApps.Define(app1Name)
    .WithNewResourceGroup(rg1Name)
    .WithNewAppServicePlan(planName)
    .WithRegion(Region.USWest)
    .WithPricingTier(AppServicePricingTier.StandardS1)
    .Create();
```

or with an existing plan as following:

```C#
azure.WebApps.Define(app2Name)
    .WithExistingResourceGroup(rg1Name)
    .WithExistingAppServicePlan(plan)
    .Create();
```

In 1.0, there are a few breaking changes:

- region is the first required parameter for a new app service plan
- the app service plan is the first required parameter for an existing app service plan
- the app service plan parameter doesn't require a name (if its name is important, define an app service plan separately in its own `Define()` flow)
- `WithNewAppServicePlan()` is separated into `WithNewWindowsPlan()` and `WithNewLinuxPlan()` depending on the operating system of the plan. Same applies for `WithExistingAppServicePlan()`.

To create one with a new app service plan

```C#
var app1 = azure.WebApps
    .Define(app1Name)
    .WithRegion(Region.USWest)
    .WithNewResourceGroup(rg1Name)
    .WithNewWindowsPlan(PricingTier.StandardS1)
    .Create();
```

To create one with an existing app service plan

```C#
azure.WebApps
    .Define(app2Name)
    .WithExistingWindowsPlan(plan)
    .WithExistingResourceGroup(rg1Name)
    .Create();
```

## Change Method or Interface Names ##

<table>
  <tr>
    <th>From</th>
    <th>To</th>
    <th>Ref</th>
  </tr>
  <tr>
      <td><code>VirtualMachine.Exntesions</code></td>
      <td><code>VirtualMachine.ListExtensions()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/2997">#2997</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskCaching()</code></td>
    <td><code>VirtualMachine.WithOSDiskCaching()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskSizeInGB()</code></td>
    <td><code>VirtualMachine.WithOSDiskSizeInGB()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithSpecializedOsUnmanagedDisk()</code></td>
    <td><code>VirtualMachine.WithSpecializedOSUnmanagedDisk()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskName()</code></td>
    <td><code>VirtualMachine.WithOSDiskName()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskEncryptionSettings()</code></td>
    <td><code>VirtualMachine.WithOSDiskEncryptionSettings()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskStorageAccountType()</code></td>
    <td><code>VirtualMachine.WithOSDiskStorageAccountType()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskVhdLocation()</code></td>
    <td><code>VirtualMachine.WithOSDiskVhdLocation()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithoutVmAgent()</code></td>
    <td><code>VirtualMachine.WithoutVMAgent()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithWinRm()</code></td>
    <td><code>VirtualMachine.WithWinRM()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithWinRm()</code></td>
    <td><code>VirtualMachineScaleSet.WithWinRM()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithoutVmAgent()</code></td>
    <td><code>VirtualMachineScaleSet.WithoutVMAgent()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithVmAgent()</code></td>
    <td><code>VirtualMachineScaleSet.WithVMAgent()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithOsDiskStorageAccountType()</code></td>
    <td><code>VirtualMachineScaleSet.WithOSDiskStorageAccountType()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithOsDiskCaching()</code></td>
    <td><code>VirtualMachineScaleSet.WithOSDiskCaching()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithOsDiskName()</code></td>
    <td><code>VirtualMachineScaleSet.WithOSDiskName()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3073">#3073</a></td>
  </tr>
  <tr>
    <td>All <code>*ByGroup*</code> in names</td>
    <td>All <code>*ByResourceGroup*</code> in names</td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3016">#3016</a></td>
  </tr>
  <tr>
    <td>Interface <code>Wrapper&lt;T&gt;</code></td>
    <td>Interface <code>HasInner&lt;T&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/2827">#2827</a></td>
  </tr>
  <tr>
    <td>Any types or methods <code>*Vm*</code> in names</td>
    <td>Any types or methods <code>*VM*</code> in names</td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/2982">#2982</a></td>
  </tr>
</table>



## Change Receiving Variable Type ##

<table>
  <tr>
    <th>From</th>
    <th>To</th>
    <th>For Method</th>
    <th>Ref</th>
  </tr>
  <tr>
    <td><code>IList&lt;DataDiskImage&gt;</code></td>
    <td><code>IReadOnlyDictionary&lt;int, DataDiskImage&gt;</code></td>
    <td><code>VirtualMachineImage.DataDiskImages</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/2771">#2771</a></td>
  </tr>
  <tr>
    <td><code>IList&lt;String&gt;></code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><code>AvailabilitySet.VirtualMachineIds</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3038">3038</a></td>
  </tr>
  <tr>
    <td><code>IList&lt;String&gt;></code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><code>NetworkSecurityGroup.NetworkInterfaceIds</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/2827">2827</a></td>
  </tr>

</table>


## Drop Method Usage or Use Alternate ##

<table>
  <tr>
    <th>Drop Method</th>
    <th>Use Alternate</th>
    <th>Ref</th>
  </tr>
  <tr>
    <td><code>StorageAccount.WithoutCustomDomain()</code></td>
    <td></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3062">3062</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithDataDiskUpdated()</code></td>
    <td>Disks can not longer be updated as part of virtual machine update. They should be updated directly via Disks API.</td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3049">3049</a></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithDataDiskUpdated()</code></td>
    <td>Disks can not longer be updated as part of virtual machine scale set update. They should be updated directly via Disks API.</td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3049">3049</a></td>
  </tr>
</table>

