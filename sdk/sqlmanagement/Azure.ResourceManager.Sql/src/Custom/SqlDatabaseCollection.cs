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
        /// <summary> Gets a database. </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlDatabaseResource> Get(string databaseName, CancellationToken cancellationToken)
            => Get(databaseName, null, null, cancellationToken);

        /// <summary> Gets a database. </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SqlDatabaseResource>> GetAsync(string databaseName, CancellationToken cancellationToken)
            => await GetAsync(databaseName, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Checks if a database exists. </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string databaseName, CancellationToken cancellationToken)
            => Exists(databaseName, null, null, cancellationToken);

        /// <summary> Checks if a database exists. </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string databaseName, CancellationToken cancellationToken)
            => await ExistsAsync(databaseName, null, null, cancellationToken).ConfigureAwait(false);
    }
}
