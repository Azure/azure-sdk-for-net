// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ExpressRouteLagMember
    {
        // ApiCompat CP0002: 1.17.0 requires Type.get; retain a hidden alias of the required native ResourceType.
        /// <summary> Gets the resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Please use ResourceType instead.")]
        public string Type => ResourceType.ToString();
    }
}
