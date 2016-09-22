// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition
{

    using Microsoft.Azure.Management.V2.Batch;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithGroup,
        IWithCreate
    {
    }
    /// <summary>
    /// A batch account definition with sufficient inputs to create a new
    /// batch account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IBatchAccount>,
        IDefinitionWithTags<IWithCreate>
    {
        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        IWithCreate WithStorageAccount (IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        IWithCreate WithNewStorageAccount (ICreatable<IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        IWithCreate WithNewStorageAccount (string storageAccountName);

    }
    /// <summary>
    /// The first stage of the batch account definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// A batch account definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<IWithCreate>
    {
    }
}