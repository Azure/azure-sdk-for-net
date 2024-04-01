// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Purview.Models
{
    /// <summary> The account endpoints. </summary>
    public partial class PurviewAccountEndpoint
    {
        /// <summary> Gets the guardian endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Guardian { get; }
    }
}
