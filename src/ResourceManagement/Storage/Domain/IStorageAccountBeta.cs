// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Update;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure storage account.
    /// </summary>
    public interface IStorageAccountBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the encryption statuses indexed by storage service type.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<Microsoft.Azure.Management.Storage.Fluent.StorageService,Microsoft.Azure.Management.Storage.Fluent.IStorageAccountEncryptionStatus> EncryptionStatuses { get; }

        /// <summary>
        /// Gets the source of the key used for encryption.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.StorageAccountEncryptionKeySource EncryptionKeySource { get; }
    }
}