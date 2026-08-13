// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds a parameterless constructor to EdgeNode for backward API compatibility with the previous SDK.
    // Reason: The old SDK allowed creating EdgeNode instances via a parameterless constructor,
    // but the TypeSpec generator no longer generates this constructor. It is preserved here and marked as EditorBrowsable.Never.
    public partial class EdgeNode
    {
        /// <summary> Initializes a new instance of <see cref="EdgeNode"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EdgeNode()
        { }
    }
}
