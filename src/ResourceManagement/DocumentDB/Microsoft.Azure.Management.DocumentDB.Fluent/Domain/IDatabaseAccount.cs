// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.DocumentDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DocumentDB.Fluent.DatabaseAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure document db.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IDatabaseAccount  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.DocumentDB.Fluent.IDocumentDBManager,Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<DatabaseAccount.Update.IUpdate>
    {
        /// <summary>
        /// Gets an array that contains the writable georeplication locations enabled for the DocumentDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> WritableReplications { get; }

        /// <summary>
        /// Gets the default consistency level for the DocumentDB database account.
        /// </summary>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DefaultConsistencyLevel DefaultConsistencyLevel { get; }

        /// <return>The connection strings for the specified Azure DocumentDB database account.</return>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner ListConnectionStrings();

        /// <return>The access keys for the specified Azure DocumentDB database account.</return>
        Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner> ListKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets specifies the set of IP addresses or IP address ranges in CIDR form.
        /// </summary>
        string IPRangeFilter { get; }

        /// <return>The access keys for the specified Azure DocumentDB database account.</return>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner ListKeys();

        /// <summary>
        /// Gets the consistency policy for the DocumentDB database account.
        /// </summary>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.ConsistencyPolicy ConsistencyPolicy { get; }

        /// <summary>
        /// Gets indicates the type of database account.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets the connection endpoint for the DocumentDB database account.
        /// </summary>
        string DocumentEndpoint { get; }

        /// <summary>
        /// Gets an array that contains the readable georeplication locations enabled for the DocumentDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> ReadableReplications { get; }

        /// <summary>
        /// Gets the offer type for the DocumentDB database account.
        /// </summary>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountOfferType DatabaseAccountOfferType { get; }

        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        Task RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The connection strings for the specified Azure DocumentDB database account.</return>
        Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="keyKind">The key kind.</param>
        void RegenerateKey(string keyKind);
    }
}