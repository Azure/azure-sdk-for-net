// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Status code count. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class StatusCodeCount
    {
        /// <summary> Initializes a new instance of StatusCodeCount. </summary>
        internal StatusCodeCount() { }

        /// <summary> The instance view status code. </summary>
        public string Code { get; }
        /// <summary> The number of instances having a particular status code. </summary>
        public int? Count { get; }
    }
}
