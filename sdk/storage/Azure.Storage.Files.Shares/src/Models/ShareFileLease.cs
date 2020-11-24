// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    public partial class ShareFileLease
    {
        /// <summary>
        /// Gets the approximate time remaining in the lease period, in
        /// seconds.  This is only provided when breaking a lease.
        /// </summary>
        public int? LeaseTime { get; internal set; }
    }
}
