// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;
using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Stats for the share.
    /// </summary>
    [CodeGenModel("ShareStats")]
    public partial class ShareStatistics
    {
        internal ShareStatistics() { }

        /// <summary>
        /// Warning: ShareUsageBytes may exceed int.MaxValue.  Use ShareUsageInBytes instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ShareUsageBytes
        {
            get
            {
                if (ShareUsageInBytes > int.MaxValue)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new OverflowException(Constants.File.Errors.ShareUsageBytesOverflow);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return (int)ShareUsageInBytes;
            }
            internal set { ShareUsageInBytes = value; }
        }

        /// <summary>
        /// The approximate size of the data stored in bytes, rounded up to the nearest gigabyte. Note that this value may not include all recently created or recently resized files.
        /// </summary>
        public long ShareUsageInBytes { get; internal set; }

        internal static ShareStatistics DeserializeShareStatistics(XElement element)
        {
            long shareUsageIsBytes = default;
            if (element.Element("ShareUsageBytes") is XElement shareUsageBytesElement)
            {
                shareUsageIsBytes = (long)shareUsageBytesElement;
            }
            return new ShareStatistics
            {
                ShareUsageInBytes = shareUsageIsBytes
            };
        }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new PermissionInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareStatistics ShareStatistics(int shareUsageBytes)
            => new ShareStatistics
            {
                ShareUsageBytes = shareUsageBytes
            };
    }
}
