// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.OracleDatabase
{
    public partial class OracleGIVersionCollection
    {
        /// <summary>
        /// List GiVersion resources by Location
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GiVersions_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleGIVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OracleGIVersionResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<OracleGIVersionResource> GetAll(CancellationToken cancellationToken) => GetAll(cancellationToken: cancellationToken);

        /// <summary>
        /// List GiVersion resources by Location
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GiVersions_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleGIVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OracleGIVersionResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<OracleGIVersionResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(cancellationToken: cancellationToken);
    }
}
