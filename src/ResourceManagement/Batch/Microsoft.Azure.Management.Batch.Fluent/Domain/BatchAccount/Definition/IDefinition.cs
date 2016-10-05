// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Batch.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    /// <summary>
    /// A batch account definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreateAndApplication>
    {
    }
    /// <summary>
    /// The first stage of the batch account definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithGroup>
    {
    }
    /// <summary>
    /// A batch account definition with sufficient inputs to create a new
    /// batch account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        IDefinitionWithTags<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate>
    {
    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IBlank,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithGroup,
        IWithCreate,
        IWithApplicationAndStorage,
        IWithCreateAndApplication,
        IWithApplication,
        IWithStorage
    {
    }
    /// <summary>
    /// A batch account definition allowing defining application and storage account.
    /// </summary>
    public interface IWithApplicationAndStorage  :
        IWithStorage,
        IWithApplication
    {
    }
    /// <summary>
    /// A batch account definition allowing creation of application and batch account.
    /// </summary>
    public interface IWithCreateAndApplication  :
        IWithCreate,
        IWithApplicationAndStorage
    {
    }
    /// <summary>
    /// A batch account definition to allow creation of application.
    /// </summary>
    public interface IWithApplication 
    {
        /// <summary>
        /// First stage to create new application in Batch account.
        /// </summary>
        /// <param name="applicationId">applicationId id of the application to create</param>
        /// <returns>next stage to create the Batch account.</returns>
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IBlank<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithApplicationAndStorage> DefineNewApplication(string applicationId);

    }
    /// <summary>
    /// A batch account definition to allow attaching storage accounts.
    /// </summary>
    public interface IWithStorage 
    {
        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate WithNewStorageAccount(string storageAccountName);

    }
}