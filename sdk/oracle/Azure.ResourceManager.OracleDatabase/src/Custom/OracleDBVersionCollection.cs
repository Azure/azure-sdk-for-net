// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.OracleDatabase.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing a collection of <see cref="OracleDBVersionResource"/> and their operations.
    /// Each <see cref="OracleDBVersionResource"/> in the collection will belong to the same instance of <see cref="SubscriptionResource"/>.
    /// To get a <see cref="OracleDBVersionCollection"/> instance call the GetOracleDBVersions method from an instance of <see cref="SubscriptionResource"/>.
    /// </summary>
    public partial class OracleDBVersionCollection : ArmCollection, IEnumerable<OracleDBVersionResource>, IAsyncEnumerable<OracleDBVersionResource>
    {
        /// <summary>
        /// List DbVersion resources by SubscriptionLocationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemDbVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DbVersion_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleDBVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OracleDBVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OracleDBVersionResource> GetAllAsync(OracleDBVersionCollectionGetAllOptions options, CancellationToken cancellationToken)
            => GetAllAsync(options.DbSystemShape, options.DbSystemId, options.StorageManagement, options.IsUpgradeSupported, options.IsDatabaseSoftwareImageSupported, options.ShapeFamily, cancellationToken);

        /// <summary>
        /// List DbVersion resources by SubscriptionLocationResource
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Oracle.Database/locations/{location}/dbSystemDbVersions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DbVersion_ListByLocation</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OracleDBVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OracleDBVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OracleDBVersionResource> GetAll(OracleDBVersionCollectionGetAllOptions options, CancellationToken cancellationToken)
            => GetAll(options.DbSystemShape, options.DbSystemId, options.StorageManagement, options.IsUpgradeSupported, options.IsDatabaseSoftwareImageSupported, options.ShapeFamily, cancellationToken);
    }
}
