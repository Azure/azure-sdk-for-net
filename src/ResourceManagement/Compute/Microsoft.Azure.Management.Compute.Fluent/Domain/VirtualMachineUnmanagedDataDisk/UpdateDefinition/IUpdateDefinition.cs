// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage that allows configure the disk based on existing vhd.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithVhdAttachedDiskSettings<ParentT>  :
        IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies the size in GB the disk needs to be resized.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<ParentT> WithSizeInGB(int sizeInGB);

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<ParentT> WithLun(int lun);

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<ParentT> WithCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The stage of the data disk definition allowing to choose the source.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithDiskSource<ParentT> 
    {
        /// <summary>
        /// Specifies the existing source vhd of the disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding VHD file.</param>
        /// <param name="vhdName">The name of the VHD file to attach.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<ParentT> WithExistingVhd(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Specifies that disk needs to be created with a new vhd of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> WithNewVhd(int sizeInGB);
    }

    /// <summary>
    /// The first stage of a  data disk definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithDiskSource<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the data disk definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The stage that allows configure the disk based on new vhd.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithNewVhdDiskSettings<ParentT>  :
        IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> StoreAt(string storageAccountName, string containerName, string vhdName);

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> WithLun(int lun);

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<ParentT> WithCaching(CachingTypes cachingType);
    }
}