/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Storage.StorageAccount.Update
{

    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Resource.Core.Resource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Management.Storage.Models;

    /// <summary>
    /// A storage account update stage allowing to change the parameters.
    /// </summary>
    public interface IWithSku 
    {
        /// <summary>
        /// Specifies the sku of the storage account. This used to be called
        /// account types.             *
        /// </summary>
        /// <param name="skuName">skuName the sku</param>
        /// <returns>the next stage of storage account update</returns>
        IUpdate WithSku (SkuName skuName);

    }
    /// <summary>
    /// The template for a storage account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IStorageAccount>,
        IWithSku,
        IWithCustomDomain,
        IWithEncryption,
        IWithAccessTier,
        IUpdateWithTags<IUpdate>
    {
    }
    /// <summary>
    /// A storage account update allowing encryption to be specified.
    /// </summary>
    public interface IWithEncryption 
    {
        /// <summary>
        /// Specifies the encryption setting on the account.
        /// <p>
        /// The default setting is unencrypted.
        /// </summary>
        /// <param name="encryption">encryption the encryption setting</param>
        /// <returns>the nest stage of storage account update</returns>
        IUpdate WithEncryption (Encryption encryption);

    }
    /// <summary>
    /// A blob storage account update stage allowing access tier to be specified.
    /// </summary>
    public interface IWithAccessTier 
    {
        /// <summary>
        /// Specifies the access tier used for billing.
        /// <p>
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">accessTier the access tier value</param>
        /// <returns>the next stage of storage account update</returns>
        IUpdate WithAccessTier (AccessTier accessTier);

    }
    /// <summary>
    /// A storage account update stage allowing to change the parameters.
    /// </summary>
    public interface IWithCustomDomain 
    {
        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">customDomain the user domain assigned to the storage account</param>
        /// <returns>the next stage of storage account update</returns>
        IUpdate WithCustomDomain (CustomDomain customDomain);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">name the custom domain name, which is the CNAME source</param>
        /// <returns>the next stage of storage account update</returns>
        IUpdate WithCustomDomain (string name);

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">name the custom domain name, which is the CNAME source</param>
        /// <param name="useSubDomain">useSubDomain whether indirect CName validation is enabled</param>
        /// <returns>the next stage of storage account update</returns>
        IUpdate WithCustomDomain (string name, bool useSubDomain);

        /// <summary>
        /// Clears the existing user domain assigned to the storage account.
        /// </summary>
        /// <returns>the next stage of storage account update</returns>
        IUpdate WithoutCustomDomain ();

    }
}