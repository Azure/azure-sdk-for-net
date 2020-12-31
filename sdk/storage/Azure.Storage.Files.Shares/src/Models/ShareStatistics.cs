// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Stats for the share.
    /// </summary>
    public partial class ShareStatistics
    {
        /// <summary>
        /// Warning: ShareUsageBytes may exceed int.MaxValue.  Use ShareUsageInBytes instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ShareUsageBytes {
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
