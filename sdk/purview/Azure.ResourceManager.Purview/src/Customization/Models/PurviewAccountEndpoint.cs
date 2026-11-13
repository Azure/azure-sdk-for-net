// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Purview.Models
{
    // Backward compatibility: the Guardian endpoint property was removed in API version
    // 2024-04-01-preview. The old SDK (1.1.0) exposed it publicly. We keep it here with
    // [EditorBrowsable(Never)] so existing consumers don't break.
    public partial class PurviewAccountEndpoint
    {
        internal PurviewAccountEndpoint(string catalog, string guardian, string scan, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : this(catalog, scan, additionalBinaryDataProperties)
        {
            Guardian = guardian;
        }

        /// <summary> Gets the guardian endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Guardian { get; }
    }
}
