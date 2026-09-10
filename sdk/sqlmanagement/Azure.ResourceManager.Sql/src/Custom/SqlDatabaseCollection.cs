// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseCollection
    {
        /// <summary>
        /// Gets a list of databases.
        /// </summary>
        /// <param name="skipToken"> An opaque token that identifies a starting point in the collection. Ignored in the
        /// 2025-02-01-preview API; provided for binary back-compat with v1.4.0 callers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlDatabaseResource> GetAllAsync(string skipToken, CancellationToken cancellationToken = default)
            => GetAllAsync(top: null, skip: null, filter: null, orderby: null, cancellationToken);

        /// <summary>
        /// Gets a list of databases.
        /// </summary>
        /// <param name="skipToken"> An opaque token that identifies a starting point in the collection. Ignored in the
        /// 2025-02-01-preview API; provided for binary back-compat with v1.4.0 callers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlDatabaseResource> GetAll(string skipToken, CancellationToken cancellationToken = default)
            => GetAll(top: null, skip: null, filter: null, orderby: null, cancellationToken);
    }
}
