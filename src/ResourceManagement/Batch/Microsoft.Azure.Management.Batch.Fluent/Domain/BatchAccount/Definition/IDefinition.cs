// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.Azure.Management.Batch.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of a Batch account definition allowing the adding of a Batch application or creating the Batch account.
    /// </summary>
    public interface IWithCreateAndApplication  :
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithApplicationAndStorage
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing to associate storage accounts with the Batch account.
    /// </summary>
    public interface IWithStorage 
    {
        /// <summary>
        /// Specifies a new storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">A storage account to be created along with and used in the Batch account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies the name of a new storage account to be created and associated with this Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate WithNewStorageAccount(string storageAccountName);

        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate WithExistingStorageAccount(IStorageAccount storageAccount);
    }

    /// <summary>
    /// A Batch account definition with sufficient inputs to create a new
    /// Batch account in the cloud, but exposing additional optional inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing adding an application and a storage account.
    /// </summary>
    public interface IWithApplicationAndStorage  :
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithStorage,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithApplication
    {
    }

    /// <summary>
    /// The first stage of a Batch account definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the creation of a Batch application.
    /// </summary>
    public interface IWithApplication 
    {
        /// <summary>
        /// The stage of a Batch account definition allowing to add a Batch application.
        /// </summary>
        /// <param name="applicationId">The id of the application to create.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IBlank<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithApplicationAndStorage> DefineNewApplication(string applicationId);
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreateAndApplication>
    {
    }

    /// <summary>
    /// The entirety of a Batch account definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IBlank,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithGroup,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreate,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithApplicationAndStorage,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithCreateAndApplication,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithApplication,
        Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition.IWithStorage
    {
    }
}