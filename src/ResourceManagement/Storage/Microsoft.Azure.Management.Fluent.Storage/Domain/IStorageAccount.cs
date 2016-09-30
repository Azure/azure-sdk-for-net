// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Storage
{

    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;
    using System;
    using Microsoft.Azure.Management.Fluent.Storage.StorageAccount.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    /// <summary>
    /// An immutable client-side representation of an Azure storage account.
    /// </summary>
    public interface IStorageAccount  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Fluent.Storage.IStorageAccount>,
        IUpdatable<Microsoft.Azure.Management.Fluent.Storage.StorageAccount.Update.IUpdate>,
        IWrapper<Microsoft.Azure.Management.Storage.Models.StorageAccountInner>
    {
        /// <returns>the status indicating whether the primary and secondary location of</returns>
        /// <returns>the storage account is available or unavailable. Possible values include:</returns>
        /// <returns>'Available', 'Unavailable'</returns>
        Microsoft.Azure.Management.Fluent.Storage.AccountStatuses AccountStatuses { get; }

        /// <returns>the sku of this storage account. Possible names include:</returns>
        /// <returns>'Standard_LRS', 'Standard_ZRS', 'Standard_GRS', 'Standard_RAGRS',</returns>
        /// <returns>'Premium_LRS'. Possible tiers include: 'Standard', 'Premium'.</returns>
        Microsoft.Azure.Management.Storage.Models.Sku Sku { get; }

        /// <returns>the kind of the storage account. Possible values are 'Storage',</returns>
        /// <returns>'BlobStorage'.</returns>
        Microsoft.Azure.Management.Storage.Models.Kind Kind { get; }

        /// <returns>the creation date and time of the storage account in UTC</returns>
        System.DateTime CreationTime { get; }

        /// <returns>the user assigned custom domain assigned to this storage account</returns>
        Microsoft.Azure.Management.Storage.Models.CustomDomain CustomDomain { get; }

        /// <returns>the timestamp of the most recent instance of a failover to the</returns>
        /// <returns>secondary location. Only the most recent timestamp is retained. This</returns>
        /// <returns>element is not returned if there has never been a failover instance.</returns>
        /// <returns>Only available if the accountType is StandardGRS or StandardRAGRS</returns>
        System.DateTime LastGeoFailoverTime { get; }

        /// <returns>the status of the storage account at the time the operation was</returns>
        /// <returns>called. Possible values include: 'Creating', 'ResolvingDNS',</returns>
        /// <returns>'Succeeded'</returns>
        Microsoft.Azure.Management.Storage.Models.ProvisioningState ProvisioningState { get; }

        /// <returns>the URLs that are used to perform a retrieval of a public blob,</returns>
        /// <returns>queue or table object. Note that StandardZRS and PremiumLRS accounts</returns>
        /// <returns>only return the blob endpoint</returns>
        Microsoft.Azure.Management.Fluent.Storage.PublicEndpoints EndPoints { get; }

        /// <returns>the encryption settings on the account. If unspecified the account</returns>
        /// <returns>is unencrypted.</returns>
        Microsoft.Azure.Management.Storage.Models.Encryption Encryption { get; }

        /// <returns>access tier used for billing. Access tier cannot be changed more</returns>
        /// <returns>than once every 7 days (168 hours). Access tier cannot be set for</returns>
        /// <returns>StandardLRS, StandardGRS, StandardRAGRS, or PremiumLRS account types.</returns>
        /// <returns>Possible values include: 'Hot', 'Cool'.</returns>
        Microsoft.Azure.Management.Storage.Models.AccessTier AccessTier { get; }

        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account.
        /// </summary>
        /// <returns>the access keys for this storage account</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Storage.Models.StorageAccountKey> GetKeys();

        /// <summary>
        /// Regenerates the access keys for this storage account.
        /// </summary>
        /// <param name="keyName">keyName if the key name</param>
        /// <returns>the generated access keys for this storage account</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Storage.Models.StorageAccountKey> RegenerateKey(string keyName);

    }
}