// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Definition
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The first stage of a  data disk definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        IWithDataDisk<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a data disk definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithStoreAt<ParentT>
    {
    }

    /// <summary>
    /// The first stage of new data disk configuration.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IAttachNewDataDisk<ParentT> 
    {
        /// <summary>
        /// Specifies the initial disk size in GB for new blank data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing optional additional settings for the attachable data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Definition.IWithStoreAt<ParentT> WithSizeInGB(int sizeInGB);
    }

    /// <summary>
    /// The final stage of the data disk definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the data disk definition
    /// can be attached to the parent virtual machine definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Definition.IWithAttach<ParentT> WithLun(int lun);

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Definition.IWithAttach<ParentT> WithCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The stage allowing to choose configuring new or existing data disk.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithDataDisk<ParentT>  :
        IAttachNewDataDisk<ParentT>,
        IAttachExistingDataDisk<ParentT>
    {
    }

    /// <summary>
    /// The first stage of attaching an existing disk as data disk and configuring it.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IAttachExistingDataDisk<ParentT> 
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing optional additional settings for the attachable data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Definition.IWithAttach<ParentT> From(string storageAccountName, string containerName, string vhdName);
    }

    /// <summary>
    /// The stage of the new data disk configuration allowing to specify location to store the VHD.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithStoreAt<ParentT>  :
        IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The stage representing optional additional configurations for the data disk.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Definition.IWithAttach<ParentT> StoreAt(string storageAccountName, string containerName, string vhdName);
    }
}