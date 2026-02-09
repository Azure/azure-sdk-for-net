// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.OracleDatabase
{
    public partial class OracleDBSystemShapeCollection
    {
        /// <summary>
        /// List DbSystemShape resources by Location
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DbSystemShapes_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleDBSystemShapeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OracleDBSystemShapeResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<OracleDBSystemShapeResource> GetAll(CancellationToken cancellationToken) => GetAll(null, null, cancellationToken);

        /// <summary>
        /// List DbSystemShape resources by Location
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DbSystemShapes_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleDBSystemShapeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OracleDBSystemShapeResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<OracleDBSystemShapeResource> GetAllAsync(CancellationToken cancellationToken) => GetAllAsync(null, null, cancellationToken);

        /// <summary>
        /// List DbSystemShape resources by SubscriptionLocationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DbSystemShape_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleDBSystemShapeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="zone"> Filters the result for the given Azure Availability Zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OracleDBSystemShapeResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<OracleDBSystemShapeResource> GetAllAsync(string zone, CancellationToken cancellationToken) => GetAllAsync(zone, null, cancellationToken);

        /// <summary>
        /// List DbSystemShape resources by SubscriptionLocationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemShapes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DbSystemShape_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleDBSystemShapeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="zone"> Filters the result for the given Azure Availability Zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OracleDBSystemShapeResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<OracleDBSystemShapeResource> GetAll(string zone, CancellationToken cancellationToken) => GetAll(zone, null, cancellationToken);
    }
}
