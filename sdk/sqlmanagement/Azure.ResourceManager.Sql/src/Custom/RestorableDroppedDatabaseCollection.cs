// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="RestorableDroppedDatabaseResource" /> and their operations.
    /// Each <see cref="RestorableDroppedDatabaseResource" /> in the collection will belong to the same instance of <see cref="SqlServerResource" />.
    /// To get a <see cref="RestorableDroppedDatabaseCollection" /> instance call the GetRestorableDroppedDatabases method from an instance of <see cref="SqlServerResource" />.
    /// </summary>
    public partial class RestorableDroppedDatabaseCollection : ArmCollection, IEnumerable<RestorableDroppedDatabaseResource>, IAsyncEnumerable<RestorableDroppedDatabaseResource>
    {
        /// <summary>
        /// Gets a restorable dropped database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RestorableDroppedDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="restorableDroppedDatabaseId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="restorableDroppedDatabaseId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="restorableDroppedDatabaseId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<RestorableDroppedDatabaseResource>> GetAsync(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
        {
            return await GetAsync(restorableDroppedDatabaseId, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a restorable dropped database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RestorableDroppedDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="restorableDroppedDatabaseId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="restorableDroppedDatabaseId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="restorableDroppedDatabaseId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RestorableDroppedDatabaseResource> Get(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
        {
            return Get(restorableDroppedDatabaseId, null, null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RestorableDroppedDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="restorableDroppedDatabaseId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="restorableDroppedDatabaseId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="restorableDroppedDatabaseId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
        {
            return await ExistsAsync(restorableDroppedDatabaseId, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RestorableDroppedDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="restorableDroppedDatabaseId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="restorableDroppedDatabaseId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="restorableDroppedDatabaseId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
        {
            return Exists(restorableDroppedDatabaseId, null, null, cancellationToken);
        }
    }
}
