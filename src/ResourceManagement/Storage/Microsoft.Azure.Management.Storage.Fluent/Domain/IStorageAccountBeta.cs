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
    /// Members of the IStorageAccount that are in Beta.
    /// </summary>
    public interface IStorageAccountBeta : IBeta
    {
        /// <summary>
        /// Fetch the up-to-date access keys from Azure for this storage account asynchronously.
        /// </summary>
        /// <return>Observable to the access keys for this storage account.</return>
        Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> GetKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates the access keys for this storage account asynchronously.
        /// </summary>
        /// <param name="keyName">If the key name.</param>
        /// <return>Observable to the access keys for this storage account.</return>
        Task<System.Collections.Generic.IReadOnlyList<Models.StorageAccountKey>> RegenerateKeyAsync(string keyName, CancellationToken cancellationToken = default(CancellationToken));
    }
}