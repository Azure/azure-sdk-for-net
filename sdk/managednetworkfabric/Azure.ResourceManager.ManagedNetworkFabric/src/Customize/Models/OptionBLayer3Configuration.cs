// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class OptionBLayer3Configuration
    {
        // Backward compatibility for the previous SDK surface. The generated model now exposes
        // the nullable PeerAsn/VlanId constructor, but no longer generates the parameterless one.
        /// <summary> Initializes a new instance of <see cref="OptionBLayer3Configuration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OptionBLayer3Configuration() : this(default(long?), default(int?))
        {
        }
    }
}
