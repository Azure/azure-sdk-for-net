// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.OracleDatabase.Models;

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
        /// <term>Resource</term>
        /// <description><see cref="OracleGIVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OracleGIVersionResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<OracleGIVersionResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, null, cancellationToken);

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
        /// <term>Resource</term>
        /// <description><see cref="OracleGIVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OracleGIVersionResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<OracleGIVersionResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, null, cancellationToken);

        /// <summary>
        /// List GiVersion resources by SubscriptionLocationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GiVersion_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleGIVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shape"> If provided, filters the results for the given shape. </param>
        /// <param name="zone"> Filters the result for the given Azure Availability Zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OracleGIVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OracleGIVersionResource> GetAllAsync(OracleDatabaseSystemShape? shape, string zone, CancellationToken cancellationToken) =>
            GetAllAsync(shape, zone, null, cancellationToken);

        /// <summary>
        /// List GiVersion resources by SubscriptionLocationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/giVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GiVersion_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleGIVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="shape"> If provided, filters the results for the given shape. </param>
        /// <param name="zone"> Filters the result for the given Azure Availability Zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OracleGIVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OracleGIVersionResource> GetAll(OracleDatabaseSystemShape? shape, string zone, CancellationToken cancellationToken = default) =>
            GetAll(shape, zone, null, cancellationToken);
    }
}
