/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Storage.StorageAccount.Definition
{

    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Management.Storage.Models;

    /// <summary>
    /// A storage account definition specifying a custom domain to associate with the account.
    /// </summary>
    public interface IWithCustomDomain 
    {
        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">customDomain the user domain assigned to the storage account</param>
        /// <returns>the next stage of storage account definition</returns>
        IWithCreate WithCustomDomain (CustomDomain customDomain);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">name the custom domain name, which is the CNAME source</param>
        /// <returns>the next stage of storage account definition</returns>
        IWithCreate WithCustomDomain (string name);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">name the custom domain name, which is the CNAME source</param>
        /// <param name="useSubDomain">useSubDomain whether indirect CName validation is enabled</param>
        /// <returns>the next stage of storage account definition</returns>
        IWithCreate WithCustomDomain (string name, bool useSubDomain);

    }
    /// <summary>
    /// A storage account definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition.IWithGroup<IWithCreate>
    {
    }
    /// <summary>
    /// The first stage of the storage account definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.V2.Storage.StorageAccount.Definition.IWithGroup>
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
        /// <returns>the next stage of storage account definition</returns>
        IWithCreateAndAccessTier WithBlobStorageAccountKind ();

    }
    /// <summary>
    /// A storage account definition with sufficient inputs to create a new
    /// storage account in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IStorageAccount>,
        IWithSku,
        IWithBlobStorageAccountKind,
        IWithGeneralPurposeAccountKind,
        IWithEncryption,
        IWithCustomDomain,
        IDefinitionWithTags<IWithCreate>
    {
    }
    /// <summary>
    /// A storage account definition allowing the sku to be set.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku of the storage account. This used to be called
        /// account types.
        /// </summary>
        /// <param name="skuName">skuName the sku</param>
        /// <returns>the next stage of storage account definition</returns>
        IWithCreate WithSku (SkuName skuName);

    }
    /// <summary>
    /// A storage account definition allowing access tier to be set.
    /// </summary>
    public interface IWithCreateAndAccessTier  :
        IWithCreate
    {
        /// <summary>
        /// Specifies the access tier used for billing.
        /// <p>
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">accessTier the access tier value</param>
        /// <returns>the next stage of storage account definition</returns>
        IWithCreate WithAccessTier (AccessTier accessTier);

    }
    /// <summary>
    /// A storage account definition specifying encryption setting.
    /// </summary>
    public interface IWithEncryption 
    {
        /// <summary>
        /// Specifies the encryption settings on the account. The default
        /// setting is unencrypted.
        /// </summary>
        /// <param name="encryption">encryption the encryption setting</param>
        /// <returns>the nest stage of storage account definition</returns>
        IWithCreate WithEncryption (Encryption encryption);

    }
    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        Microsoft.Azure.Management.V2.Storage.StorageAccount.Definition.IWithGroup,
        IWithCreate,
        IWithCreateAndAccessTier
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
        /// <returns>the next stage of storage account definition</returns>
        IWithCreate WithGeneralPurposeAccountKind ();

    }
}