/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Batch.BatchAccount.Update
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Batch;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
    /// <summary>
    /// The stage of the batch account update definition allowing to specify storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        IUpdate WithStorageAccount (IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        IUpdate WithNewStorageAccount (ICreatable<IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        IUpdate WithNewStorageAccount (string storageAccountName);

        /// <summary>
        /// Specifies that storage account should be removed from the batch account.
        /// </summary>
        /// <returns>the stage representing updatable batch account definition</returns>
        IUpdate WithoutStorageAccount ();

    }
    /// <summary>
    /// The template for a storage account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IBatchAccount>,
        IUpdateWithTags<IUpdate>,
        IWithStorageAccount
    {
    }
}