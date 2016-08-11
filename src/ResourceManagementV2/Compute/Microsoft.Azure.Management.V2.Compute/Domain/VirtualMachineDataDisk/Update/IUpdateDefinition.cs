/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Compute.Models;
    /// <summary>
    /// The first stage of a  data disk definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithDataDisk<ParentT>
    {
    }
    /// <summary>
    /// The stage allowing to choose configuring new or existing data disk.
    /// 
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithDataDisk<ParentT>  :
        IAttachNewDataDisk<ParentT>,
        IAttachExistingDataDisk<ParentT>
    {
    }
    /// <summary>
    /// The final stage of the data disk definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the data disk definition
    /// can be attached to the parent virtual machine definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>
    {
        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">lun the logical unit number</param>
        /// <returns>the next stage of data disk definition</returns>
        IWithAttach<ParentT> WithLun (int? lun);

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">cachingType the disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'</param>
        /// <returns>the next stage of data disk definition</returns>
        IWithAttach<ParentT> WithCaching (CachingTypes cachingType);

    }
    /// <summary>
    /// The entirety of a data disk definition as part of a virtual machine update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithStoreAt<ParentT>
    {
    }
    /// <summary>
    /// The first stage of attaching an existing disk as data disk and configuring it.
    /// 
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IAttachExistingDataDisk<ParentT> 
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container holding the VHD file</param>
        /// <param name="vhdName">vhdName the name for the VHD file</param>
        /// <returns>the stage representing optional additional settings for the attachable data disk</returns>
        IWithAttach<ParentT> From (string storageAccountName, string containerName, string vhdName);

    }
    /// <summary>
    /// The first stage of new data disk configuration.
    /// 
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IAttachNewDataDisk<ParentT> 
    {
        /// <summary>
        /// Specifies the initial disk size in GB for new blank data disk.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the stage representing optional additional settings for the attachable data disk</returns>
        IWithStoreAt<ParentT> WithSizeInGB (int? sizeInGB);

    }
    /// <summary>
    /// The stage of the new data disk configuration allowing to specify location to store the VHD.
    /// 
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithStoreAt<ParentT>  :
        IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container to hold the new VHD file</param>
        /// <param name="vhdName">vhdName the name for the new VHD file</param>
        /// <returns>the stage representing optional additional configurations for the data disk</returns>
        IWithAttach<ParentT> StoreAt (string storageAccountName, string containerName, string vhdName);

    }
}