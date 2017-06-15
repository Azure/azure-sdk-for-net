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
        Microsoft.Azure.Management.Redis.Fluent.IRedisCache
    {
        /// <summary>
        /// Gets the patching schedule for Redis Cache.
        /// </summary>
        /// <return>List of patch schedules for current Redis Cache.</return>
        System.Collections.Generic.IReadOnlyList<Models.ScheduleEntry> ListPatchSchedules();

        /// <summary>
        /// Deletes the patching schedule for Redis Cache.
        /// </summary>
        void DeletePatchSchedule();

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">
        /// Specifies which Redis node(s) to reboot. Depending on this value data loss is
        /// possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.
        /// </param>
        /// <param name="shardId">In case of cluster cache, this specifies shard id which should be rebooted.</param>
        void ForceReboot(string rebootType, int shardId);

        /// <summary>
        /// Reboot specified Redis node(s). This operation requires write permission to the cache resource. There can be potential data loss.
        /// </summary>
        /// <param name="rebootType">
        /// Specifies which Redis node(s) to reboot. Depending on this value data loss is
        /// possible. Possible values include: 'PrimaryNode', 'SecondaryNode', 'AllNodes'.
        /// </param>
        void ForceReboot(string rebootType);

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">Files to import.</param>
        /// <param name="fileFormat">Specifies file format.</param>
        void ImportData(IList<string> files, string fileFormat);

        /// <summary>
        /// Import data into Redis Cache.
        /// </summary>
        /// <param name="files">Files to import.</param>
        void ImportData(IList<string> files);

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">Container name to export to.</param>
        /// <param name="prefix">Prefix to use for exported files.</param>
        void ExportData(string containerSASUrl, string prefix);

        /// <summary>
        /// Export data from Redis Cache.
        /// </summary>
        /// <param name="containerSASUrl">Container name to export to.</param>
        /// <param name="prefix">Prefix to use for exported files.</param>
        /// <param name="fileFormat">Specifies file format.</param>
        void ExportData(string containerSASUrl, string prefix, string fileFormat);
    }
}