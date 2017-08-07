// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System;

    internal partial class StorageAccountImpl 
    {
        /// <summary>
        /// Gets the status indicating whether the primary and secondary location of
        /// the storage account is available or unavailable. Possible values include:
        /// 'Available', 'Unavailable'.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.AccountStatuses Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.AccountStatuses
        {
            get
            {
                return this.AccountStatuses() as Microsoft.Azure.Management.Storage.Fluent.AccountStatuses;
            }
        }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account.
        /// </summary>
        /// <return>The access keys for this storage account.</return>
        System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.GetKeys()
        {
            return this.GetKeys() as System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>;
        }

        /// <summary>
        /// Gets the user assigned custom domain assigned to this storage account.
        /// </summary>
        Models.CustomDomain Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.CustomDomain
        {
            get
            {
                return this.CustomDomain() as Models.CustomDomain;
            }
        }

        /// <summary>
        /// Gets the source of the key used for encryption.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountEncryptionKeySource Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.EncryptionKeySource
        {
            get
            {
                return this.EncryptionKeySource() as Microsoft.Azure.Management.Storage.Fluent.StorageAccountEncryptionKeySource;
            }
        }

        /// <summary>
        /// Gets the kind of the storage account. Possible values are 'Storage',
        /// 'BlobStorage'.
        /// </summary>
        Models.Kind Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.Kind
        {
            get
            {
                return this.Kind();
            }
        }

        /// <summary>
        /// Regenerates the access keys for this storage account.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>The generated access keys for this storage account.</return>
        System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.RegenerateKey(string keyName)
        {
            return this.RegenerateKey(keyName) as System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>;
        }

        /// <summary>
        /// Gets the status of the storage account at the time the operation was
        /// called. Possible values include: 'Creating', 'ResolvingDNS',
        /// 'Succeeded'.
        /// </summary>
        Models.ProvisioningState Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the creation date and time of the storage account in UTC.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.CreationTime
        {
            get
            {
                return this.CreationTime();
            }
        }

        /// <summary>
        /// Gets the sku of this storage account. Possible names include:
        /// 'Standard_LRS', 'Standard_ZRS', 'Standard_GRS', 'Standard_RAGRS',
        /// 'Premium_LRS'. Possible tiers include: 'Standard', 'Premium'.
        /// </summary>
        Models.Sku Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.Sku
        {
            get
            {
                return this.Sku() as Models.Sku;
            }
        }

        /// <summary>
        /// Gets the encryption settings on the account.
        /// TODO: This getter should be deprecated and removed (the new fully fluent encryption replaces this).
        /// </summary>
        Models.Encryption Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.Encryption
        {
            get
            {
                return this.Encryption() as Models.Encryption;
            }
        }

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob,
        /// queue or table object. Note that StandardZRS and PremiumLRS accounts
        /// only return the blob endpoint.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.PublicEndpoints Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.EndPoints
        {
            get
            {
                return this.EndPoints() as Microsoft.Azure.Management.Storage.Fluent.PublicEndpoints;
            }
        }

        /// <summary>
        /// Gets the encryption statuses indexed by storage service type.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.Storage.Fluent.StorageService,Microsoft.Azure.Management.Storage.Fluent.IStorageAccountEncryptionStatus> Microsoft.Azure.Management.Storage.Fluent.IStorageAccountBeta.EncryptionStatuses
        {
            get
            {
                return this.EncryptionStatuses() as System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.Storage.Fluent.StorageService,Microsoft.Azure.Management.Storage.Fluent.IStorageAccountEncryptionStatus>;
            }
        }

        /// <summary>
        /// Gets access tier used for billing. Access tier cannot be changed more
        /// than once every 7 days (168 hours). Access tier cannot be set for
        /// StandardLRS, StandardGRS, StandardRAGRS, or PremiumLRS account types.
        /// Possible values include: 'Hot', 'Cool'.
        /// </summary>
        Models.AccessTier Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.AccessTier
        {
            get
            {
                return this.AccessTier();
            }
        }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the
        /// secondary location. Only the most recent timestamp is retained. This
        /// element is not returned if there has never been a failover instance.
        /// Only available if the accountType is StandardGRS or StandardRAGRS.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.LastGeoFailoverTime
        {
            get
            {
                return this.LastGeoFailoverTime();
            }
        }

        /// <summary>
        /// Regenerates the access keys for this storage account asynchronously.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>A representation of the deferred computation of this call, returning the regenerated access key.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.RegenerateKeyAsync(string keyName, CancellationToken cancellationToken)
        {
            return await this.RegenerateKeyAsync(keyName, cancellationToken) as System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>;
        }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call, returning the access keys.</return>
        async Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> Microsoft.Azure.Management.Storage.Fluent.IStorageAccount.GetKeysAsync(CancellationToken cancellationToken)
        {
            return await this.GetKeysAsync(cancellationToken) as System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>;
        }

        /// <summary>
        /// Specifies the encryption setting on the account.
        /// The default setting is unencrypted.
        /// TODO: This overload should be deprecated and removed (the new fully fluent encryption withers replaces this).
        /// </summary>
        /// <param name="encryption">The encryption setting.</param>
        /// <return>The nest stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithEncryption(Encryption encryption)
        {
            return this.WithEncryption(encryption) as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Enables encryption for all storage services in the account that supports encryption.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithEncryption()
        {
            return this.WithEncryption() as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Disables encryption for all storage services in the account that supports encryption.
        /// </summary>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithEncryptionBeta.WithoutEncryption()
        {
            return this.WithoutEncryption() as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the encryption settings on the account. The default
        /// setting is unencrypted.
        /// TODO: This overload should be deprecated and removed (the new fully fluent encryption withers replaces this).
        /// </summary>
        /// <param name="encryption">The encryption setting.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithEncryption(Encryption encryption)
        {
            return this.WithEncryption(encryption) as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables encryption for all storage services in the account that supports encryption.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithEncryptionBeta.WithEncryption()
        {
            return this.WithEncryption() as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the storage account kind to be "BlobStorage". The access
        /// tier is defaulted to be "Hot".
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreateAndAccessTier StorageAccount.Definition.IWithBlobStorageAccountKind.WithBlobStorageAccountKind()
        {
            return this.WithBlobStorageAccountKind() as StorageAccount.Definition.IWithCreateAndAccessTier;
        }

        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithAccessTier.WithAccessTier(AccessTier accessTier)
        {
            return this.WithAccessTier(accessTier) as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the storage account kind to be "Storage", the kind for
        /// general purposes.
        /// </summary>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithGeneralPurposeAccountKind.WithGeneralPurposeAccountKind()
        {
            return this.WithGeneralPurposeAccountKind() as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        StorageAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<StorageAccount.Update.IUpdate>.Update()
        {
            return this.Update() as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the sku of the storage account. This used to be called
        /// account types.
        /// </summary>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithSku.WithSku(SkuName skuName)
        {
            return this.WithSku(skuName) as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the sku of the storage account. This used to be called
        /// account types.
        /// </summary>
        /// <param name="skuName">The sku.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithSku.WithSku(SkuName skuName)
        {
            return this.WithSku(skuName) as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            return this.WithCustomDomain(customDomain) as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name)
        {
            return this.WithCustomDomain(name) as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account update.</return>
        StorageAccount.Update.IUpdate StorageAccount.Update.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            return this.WithCustomDomain(name, useSubDomain) as StorageAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="customDomain">The user domain assigned to the storage account.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(CustomDomain customDomain)
        {
            return this.WithCustomDomain(customDomain) as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(string name)
        {
            return this.WithCustomDomain(name) as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the user domain assigned to the storage account.
        /// </summary>
        /// <param name="name">The custom domain name, which is the CNAME source.</param>
        /// <param name="useSubDomain">Whether indirect CName validation is enabled.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCustomDomain.WithCustomDomain(string name, bool useSubDomain)
        {
            return this.WithCustomDomain(name, useSubDomain) as StorageAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Storage.Fluent.IStorageAccount;
        }

        /// <summary>
        /// Specifies the access tier used for billing.
        /// Access tier cannot be changed more than once every 7 days (168 hours).
        /// Access tier cannot be set for StandardLRS, StandardGRS, StandardRAGRS,
        /// or PremiumLRS account types.
        /// </summary>
        /// <param name="accessTier">The access tier value.</param>
        /// <return>The next stage of storage account definition.</return>
        StorageAccount.Definition.IWithCreate StorageAccount.Definition.IWithCreateAndAccessTier.WithAccessTier(AccessTier accessTier)
        {
            return this.WithAccessTier(accessTier) as StorageAccount.Definition.IWithCreate;
        }
    }
}