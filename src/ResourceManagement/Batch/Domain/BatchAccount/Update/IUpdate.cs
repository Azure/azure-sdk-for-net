// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Batch.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Update;
    using Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition;

    /// <summary>
    /// The stage of a Batch account update allowing to specify a storage account.
    /// </summary>
    public interface IWithStorageAccount 
    {
        /// <summary>
        /// Removes the associated storage account.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithoutStorageAccount();

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">The definition of the storage account.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithNewStorageAccount(string storageAccountName);

        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithExistingStorageAccount(IStorageAccount storageAccount);
    }

    /// <summary>
    /// The template for a Batch account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate>,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IWithStorageAccount,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IWithApplication
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the creation of a Batch application.
    /// </summary>
    public interface IWithApplication 
    {
        /// <summary>
        /// Starts a definition of an application to be created in the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application.</param>
        /// <return>The first stage of a Batch application definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IBlank<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate> DefineNewApplication(string applicationId);

        /// <summary>
        /// Removes the specified application from the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application to be removed.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate WithoutApplication(string applicationId);

        /// <summary>
        /// Begins the description of an update of an existing Batch application in this Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name of the application to be updated.</param>
        /// <return>The first stage of a Batch application update.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IUpdate UpdateApplication(string applicationId);
    }
}