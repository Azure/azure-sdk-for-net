// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoDatabaseCollection
    {
        /// <summary> Lists databases using the legacy overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<KustoDatabaseResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);

        /// <summary> Lists databases using the legacy overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<KustoDatabaseResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary> Creates or updates a database using the legacy overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<KustoDatabaseResource> CreateOrUpdate(WaitUntil waitUntil, string databaseName, KustoDatabaseData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, databaseName, data, null, cancellationToken);

        /// <summary> Creates or updates a database using the legacy overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<KustoDatabaseResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string databaseName, KustoDatabaseData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, databaseName, data, null, cancellationToken);
    }
}
