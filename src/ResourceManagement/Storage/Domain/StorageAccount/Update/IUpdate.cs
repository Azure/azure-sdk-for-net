// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// A storage account update stage allowing to change the parameters.
    /// </summary>
    public interface IWithCustomDomain 
    {
        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithCustomDomain(CustomDomain customDomain);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithCustomDomain(string name);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithCustomDomain(string name, bool useSubDomain);
    }

    /// <summary>
    /// The template for a storage account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithSku,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithCustomDomain,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithEncryption,
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithAccessTier,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate>
    {
    }

    /// <summary>
    /// A storage account update allowing encryption to be specified.
    /// </summary>
    public interface IWithEncryption  :
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IWithEncryptionBeta
    {
    }

    /// <summary>
    /// A storage account update stage allowing to change the parameters.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku of the storage account. This used to be called
        /// account types.
        /// </summary>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithSku(SkuName skuName);
    }

    /// <summary>
    /// A blob storage account update stage allowing access tier to be specified.
    /// </summary>
    public interface IWithAccessTier 
    {
        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithAccessTier(AccessTier accessTier);
    }

    /// <summary>
    /// A storage account update allowing encryption to be specified.
    /// </summary>
    public interface IWithEncryptionBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Disables encryption for all storage services in the account that supports encryption.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithoutEncryption();

        /// <summary>
        /// Specifies the encryption setting on the account.
        /// The default setting is unencrypted.
        /// TODO: This overload should be deprecated and removed (the new fully fluent encryption withers replaces this).
        /// </summary>
        /// <param name="encryption">The encryption setting.</param>
        /// <return>The nest stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithEncryption(Encryption encryption);

        /// <summary>
        /// Enables encryption for all storage services in the account that supports encryption.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update.IUpdate WithEncryption();
    }
}