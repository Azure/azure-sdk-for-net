// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Update;
    using Microsoft.Azure.Management.Batch.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
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
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithExistingStorageAccount(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithNewStorageAccount(string storageAccountName);

        /// <summary>
        /// Specifies that storage account should be removed from the batch account.
        /// </summary>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithoutStorageAccount();

    }
    /// <summary>
    /// A batch account definition to allow creation of application.
    /// </summary>
    public interface IWithApplication 
    {
        /// <summary>
        /// Specifies definition of an application to be created in a batch account.
        /// </summary>
        /// <param name="applicationId">applicationId the reference name for application</param>
        /// <returns>the stage representing configuration for the extension</returns>
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IBlank<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate> DefineNewApplication(string applicationId);

        /// <summary>
        /// Begins the description of an update of an existing application of this batch account.
        /// </summary>
        /// <param name="applicationId">applicationId the reference name for the application to be updated</param>
        /// <returns>the stage representing updatable application.</returns>
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IUpdate UpdateApplication(string applicationId);

        /// <summary>
        /// Deletes specified application from the batch account.
        /// </summary>
        /// <param name="applicationId">applicationId the reference name for the application to be removed</param>
        /// <returns>the stage representing updatable batch account definition.</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithoutApplication(string applicationId);

    }
    /// <summary>
    /// The template for a storage account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        IUpdateWithTags<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate>,
        IWithStorageAccount,
        IWithApplication
    {
    }
}