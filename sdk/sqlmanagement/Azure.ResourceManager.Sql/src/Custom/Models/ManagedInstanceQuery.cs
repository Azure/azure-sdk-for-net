// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary>
    /// Database query model. Kept for backward compatibility; use <see cref="ManagedInstanceQueryData"/> instead.
    /// </summary>
    [Obsolete("This model is obsolete and will be removed in a future release. Use ManagedInstanceQueryData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ManagedInstanceQuery : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ManagedInstanceQuery"/>. </summary>
        public ManagedInstanceQuery()
        {
        }

        /// <summary> Query text. </summary>
        public string QueryText { get; set; }
    }
}
