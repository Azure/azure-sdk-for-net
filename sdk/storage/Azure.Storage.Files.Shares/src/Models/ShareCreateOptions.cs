// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for creating a Share.
    /// </summary>
    public class ShareCreateOptions
    {
        /// <summary>
        /// Optional custom metadata to set for this share.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. Maximum size of the share in gigabytes.  If unspecified, use the service's default value.
        /// </summary>
        public int? QuotaInGB { get; set; }

        /// <summary>
        /// Optional.  Specifies the access tier of the share.
        /// </summary>
        public ShareAccessTier? AccessTier { get; set; }

        /// <summary>
        /// The protocols to enable for the share.
        /// </summary>
        public ShareProtocols? Protocols { get; set; }

        /// <summary>
        /// The root squash to set for the share.  Only valid for NFS shares.
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
        /// Optional.  Only applicable to provisioned v2 storage accounts.
        /// The provisioned IOPS of the share.  For SSD, minimum  IOPS is 3,000 and maximum is 100,000.  For HDD, minimum IOPS is 500 and maximum is 50,000.
        /// </summary>
        public long? ProvisionedMaxIops { get; set; }

        /// <summary>
        /// Optional.  Only applicable to provisioned v2 storage accounts.
        /// The provisioned throughput of the share.  For SSD, minimum  throughput is 125 MiB/sec and maximum is 10,340 MiB/sec.
        /// For HDD, minimum  throughput is 60 MiB/sec and maximum is 5,125 MiB/sec.
        /// </summary>
        public long? ProvisionedMaxBandwidthMibps { get; set; }

        ///// <summary>
        ///// Optional, default value is true.  Ony applicable to SMB shares.
        ///// Specifies whether granting of new directory leases for directories present in a share are to be enabled or disabled.
        ///// An input of true specifies that granting of new directory leases is to be allowed.
        ///// An input of false specifies that granting of new directory leases is to be blocked.
        ///// </summary>
        //public bool? EnableDirectoryLease { get; set; }
    }
}
