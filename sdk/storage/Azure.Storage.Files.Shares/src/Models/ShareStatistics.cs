// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Stats for the share.
    /// </summary>
    public partial class ShareStatistics
    {
        /// <summary>
        /// Warning: Share usage may exceed int.MaxValue.  Use ShareUsageInBytes instead.
        /// </summary>
        public int ShareUsageBytes {
            get
            {
                if (ShareUsageInBytes > int.MaxValue)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new OverflowException("ShareUsageInBytes exceeds int.MaxValue");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return (int)ShareUsageInBytes;
            }
            internal set { ShareUsageInBytes = value; }
        }
    }
}
