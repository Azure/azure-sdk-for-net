// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure Redis cache with Premium SKU.
    /// </summary>
    public interface IRedisCachePremium  :
        IRedisCache
    {
        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">rebootType specifies which Redis node(s) to reboot. Depending on this value data loss is</param>
        /// <param name="possible.">possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.</param>
        /// <param name="shardId">shardId    In case of cluster cache, this specifies shard id which should be rebooted.</param>
        void ForceReboot (string rebootType, int shardId);

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">rebootType specifies which Redis node(s) to reboot. Depending on this value data loss is</param>
        /// <param name="possible.">possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.</param>
        void ForceReboot (string rebootType);

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">files      files to import.</param>
        /// <param name="fileFormat">fileFormat specifies file format.</param>
        void ImportData (IList<string> files, string fileFormat);

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">files files to import.</param>
        void ImportData (IList<string> files);

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">containerSASUrl container name to export to.</param>
        /// <param name="prefix">prefix          prefix to use for exported files.</param>
        void ExportData (string containerSASUrl, string prefix);

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">containerSASUrl container name to export to.</param>
        /// <param name="prefix">prefix          prefix to use for exported files.</param>
        /// <param name="fileFormat">fileFormat      specifies file format.</param>
        void ExportData (string containerSASUrl, string prefix, string fileFormat);

        /// <summary>
        /// Gets the patching schedule for Redis Cache.
        /// </summary>
        /// <returns>List of patch schedules for current Redis Cache.</returns>
        IList<ScheduleEntry> GetPatchSchedules();

        /// <summary>
        /// Deletes the patching schedule for Redis Cache.
        /// </summary>
        void DeletePatchSchedule ();

    }
}