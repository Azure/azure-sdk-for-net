// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    ///
    /// </summary>
    public class ShareSetPropertiesOptions
    {
        /// <summary>
        /// Optional, the maximum size to set on the share in GB.
        /// </summary>
        public int? QuotaInGB { get; set; }

        /// <summary>
        /// Optional, the access tier to set on the share.
        /// </summary>
        public ShareAccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional, valid for NFS shares only.
        /// </summary>
        public ShareRootSquash? RootSquash { get; set; }

        /// <summary>
        /// Optional. Supported in version 2023-08-03 and above.  Only applicable for premium file storage accounts.
        /// Specifies whether the snapshot virtual directory should be accessible at the root of share mount point when NFS is enabled.
        /// If not specified, the default is true.
        /// </summary>

        public bool? EnableSnapshotVirtualDirectoryAccess { get; set; }

        /// <summary>
        ///  Optional. Supported in version 2024-11-04 and above.  Only applicable for premium file storage accounts.
        ///  This property enables paid bursting on premium file storage accounts.
        /// </summary>
        public bool? EnablePaidBursting { get; set; }

        /// <summary>
        ///  Optional. Supported in version 2024-11-04 and above.  Only applicable for premium file storage accounts.
        ///  Default if not specified is the maximum IOPS the file share can support. Current maximum for a file share is 102,400 IOPS.
        /// </summary>
        public long? PaidBurstingMaxIops { get; set; }

        /// <summary>
        ///  Optional. Supported in version 2024-11-04 and above.  Only applicable for premium file storage accounts.
        ///  Default if not specified is the maximum throughput the file share can support. Current maximum for a file share is 10,340 MiB/sec.
        /// </summary>
        public long? PaidBurstingMaxBandwidthMibps { get; set; }

        /// <summary>
        /// Optional.  Supported in version 2025-01-05 and above.  Only applicable to provisioned v2 storage accounts.
        /// Sets the max provisioned IOPs for a share. For SSD, min IOPs is 3,000 and max is 100,000.
        /// For HDD, min IOPs is 500 and max is 50,000.
        /// </summary>
        public long? ProvisionedMaxIops { get; set; }

        /// <summary>
        /// Optional.  Supported in version 2025-01-05 and above.  Only applicable to provisioned v2 storage accounts.
        /// Sets the max provisioned brandwith for a share.  For SSD, min bandwidth is 125 MiB/sec and max is 10,340 MiB/sec.
        /// For HDD, min bandwidth is 60 MiB/sec and max is 5,120 MiB/sec.
        /// </summary>
        public long? ProvisionedMaxBandwidthMibps { get; set; }

        /// <summary>
        /// Optional, default value is true.  Ony applicable to SMB shares.
        /// Specifies whether granting of new directory leases for directories present in a share are to be enabled or disabled.
        /// An input of true specifies that granting of new directory leases is to be allowed.
        /// An input of false specifies that granting of new directory leases is to be blocked.
        /// </summary>
        public bool? EnableDirectoryLease { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the share's properties.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
