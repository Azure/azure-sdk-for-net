# Prepare for Azure Management Libraries for .NET 1.0.0-beta5#

Steps to migrate code that uses Azure Management Libraries for .NET from beta 4 to beta 5 …

> If this note missed any breaking changes, please open a pull request.

# `Create()` defaults to Managed Disks#

In `IVirtualMachine, IVirtualMachineScaleSet` and `IVirtualMachineScaleSetVM` the OS and data disks getters and withers **default** to managed disks.

The withers and getters for storage account based (unmanaged) OS and data disks are **renamed** to include the term `unmanaged`.

## `Create()` creates unmanaged disks on explicit requests##
Starting in 1.0.0-beta5, if you like to continue to use the storage account based (unmanaged) operating system and data disks, you may use `WithUnmanagedDisks()` in the `Define() ... Create()` method chain. 

The following sample statement creates a virtual machine with an unmanaged operating system disk:
    
    azure.VirtualMachines.Define("myLinuxVM")
       .WithRegion(Region.USEast)
       .WithNewResourceGroup(rgName)
       .WithNewPrimaryNetwork("10.0.0.0/28")
       .WithPrimaryPrivateIpAddressDynamic()
       .WithNewPrimaryPublicIpAddress("mylinuxvmdns")
       .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
       .WithRootUsername("tirekicker")
       .WithSsh(sshKey)
       // Unmanaged disks - uses Storage Account
       .WithUnmanagedDisks()
       .WithSize(VirtualMachineSizeTypes.StandardD3V2)
       .Create();

For additional sample code, please see <a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-with-unmanaged-disks">Manage Virtual Machine With Unmanaged Disks</a> ready-to-run sample. 

## Converting virtual machines with storage account based disks to use managed disks
 ##
You can convert a virtual machine with unmanaged disks (Storage Account based) to managed disks with a single reboot.

    var virtualMachines = azure.VirtualMachines.List();
    foreach (var virtualMachine : virtualMachines) 
    {
        if (!virtualMachine.IsManagedDiskEnabled) 
        {
            virtualMachine.Deallocate();
            virtualMachine.ConvertToManaged();
        }
    }


# Change Property and Method Names #

<table>
  <tr>
    <th>From</th>
    <th>To</th>
  </tr>
    <tr>
    <td><code>IVirtualMachineScaleSetVM.IsOsBasedOnPlatformImage</code></td>
    <td><code>IVirtualMachineScaleSetVM.IsOSBasedOnPlatformImage</code></td>
  </tr>
  <tr>
    <td><code>IVirtualMachineScaleSetVM.GetPlatformImage()</code></td>
    <td><code>IVirtualMachineScaleSetVM.getOSPlatformImage()</code></td>
  </tr>
  <tr>
    <td><code>IVirtualMachineScaleSetVM.CustomImageVhdUri</code></td>
    <td><code>IVirtualMachineScaleSetVM.StoredImageUnmanagedVhdUri</code></td>
  </tr>
    <tr>
    <td><code>IVirtualMachine.OsDiskVhdUri</code></td>
    <td><code>IVirtualMachine.OsUnmanagedDiskVhdUri</code></td>
  </tr>
    <tr>
    <td><code>IVirtualMachine.GetPlatformImage()</code></td>
    <td><code>IVirtualMachine.GetOSPlatformImage()</code></td>
  </tr>
  <tr>
    <td><code>IVirtualMachineScaleSetVM.OsDiskVhdUri</code></td>
    <td><code>IVirtualMachineScaleSetVM.OsUnmanagedDiskVhdUri</code></td>
  </tr>
    <tr>
    <td><code>IVirtualMachine.DataDisks()</code></td>
    <td><code>IVirtualMachine.UnmanagedDataDisks()</code></td>
  </tr>
  <tr>
    <td><code>ISubscriptions.GetByName()</code></td>
    <td><code>ISubscriptions.GetById()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDisk()</code></td>
    <td><code>VirtualMachine.WithSpecializedOsUnmanagedDisk()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskCaching()</code></td>
    <td><code>VirtualMachine.WithOSDiskCaching()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithOsDiskSizeInGb()</code></td>
    <td><code>VirtualMachine.WithOSDiskSizeInGB()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.DefineNewDataDisk()</code></td>
    <td><code>VirtualMachine.DefineUnmanagedDataDisk()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithNewDataDisk()</code></td>
    <td><code>VirtualMachine.WithNewUnmanagedDataDisk()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithExistingDataDisk()</code></td>
    <td><code>VirtualMachine.WithExistingUnmanagedDataDisk()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithoutDataDisk()</code></td>
    <td><code>VirtualMachine.WithoutUnmanagedDataDisk()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.UpdateDataDisk()</code></td>
    <td><code>VirtualMachine.UpdateUnmanagedDataDisk()</code></td>
  </tr>
</table>



# Change Receiving Variable Type #

<table>
  <tr>
    <th>From</th>
    <th>To</th>
    <th>For Property/Method</th>
  </tr>
  <tr>
    <td><code> IList&lt;DataDiskImage&gt;</code></td>
    <td><code>IReadOnlyDictionary&lt;int, DataDiskImage&gt;</code></td>
    <td><code>IVirtualMachineImage.DataDiskImages</code></td>
  </tr>
</table>

# Change visibility #

<table>
  <tr>
    <th>Name</th>
    <th>Visibility</th>
    <th>Note</th>
    <th>Ref</th>
  </tr>
  <tr>
    <td><code>SetInner(T)</code></td>
    <td><code>internal</code></td>
    <td>we already documented setInner as "internal use only", making it really internal</td>
  </tr>
</table>