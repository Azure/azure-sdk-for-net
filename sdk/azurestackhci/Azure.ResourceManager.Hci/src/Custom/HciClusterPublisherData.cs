// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: Publisher is a read-only resource (no PUT/PATCH), so the generator
    // only produces an internal constructor. The old SDK had a public parameterless constructor.
    public partial class HciClusterPublisherData
    {
        /// <summary> Initializes a new instance of <see cref="HciClusterPublisherData"/>. </summary>
        public HciClusterPublisherData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HciClusterPublisherData"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciClusterPublisherData(ResourceIdentifier id) : this()
        {
        }
    }
}
