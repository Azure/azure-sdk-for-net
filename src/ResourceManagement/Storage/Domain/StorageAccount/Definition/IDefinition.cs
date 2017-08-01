// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// A storage account definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku of the storage account. This used to be called
        /// account types.
        /// </summary>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithSku(SkuName skuName);
    }

    /// <summary>
    /// A storage account definition allowing access tier to be set.
    /// </summary>
    public interface IWithCreateAndAccessTier  :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate
    {
        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithAccessTier(AccessTier accessTier);
    }

    /// <summary>
    /// A storage account definition specifying encryption setting.
    /// </summary>
    public interface IWithEncryption  :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithEncryptionBeta
    {
    }

    /// <summary>
    /// A storage account definition selecting the general purpose account kind.
    /// </summary>
    public interface IWithGeneralPurposeAccountKind 
    {
        /// <summary>
        /// Specifies the storage account kind to be "Storage", the kind for
        /// general purposes.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithGeneralPurposeAccountKind();
    }

    /// <summary>
    /// A storage account definition specifying a custom domain to associate with the account.
    /// </summary>
    public interface IWithCustomDomain 
    {
        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithCustomDomain(CustomDomain customDomain);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithCustomDomain(string name);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithCustomDomain(string name, bool useSubDomain);
    }

    /// <summary>
    /// The first stage of the storage account definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// A storage account definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A storage account definition with sufficient inputs to create a new
    /// storage account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithSku,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithBlobStorageAccountKind,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithGeneralPurposeAccountKind,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithEncryption,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCustomDomain,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IBlank,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithGroup,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreateAndAccessTier
    {
    }

    /// <summary>
    /// A storage account definition specifying the account kind to be blob.
    /// </summary>
    public interface IWithBlobStorageAccountKind 
    {
        /// <summary>
        /// Specifies the storage account kind to be "BlobStorage". The access
        /// tier is defaulted to be "Hot".
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreateAndAccessTier WithBlobStorageAccountKind();
    }

    /// <summary>
    /// A storage account definition specifying encryption setting.
    /// </summary>
    public interface IWithEncryptionBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the encryption settings on the account. The default
        /// setting is unencrypted.
        /// TODO: This overload should be deprecated and removed (the new fully fluent encryption withers replaces this).
        /// </summary>
        /// <param name="encryption">The encryption setting.</param>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithEncryption(Encryption encryption);

        /// <summary>
        /// Enables encryption for all storage services in the account that supports encryption.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition.IWithCreate WithEncryption();
    }
}