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
            get { return (int)ShareUsageInBytes; }
            internal set { ShareUsageInBytes = value; }
        }
    }
}
