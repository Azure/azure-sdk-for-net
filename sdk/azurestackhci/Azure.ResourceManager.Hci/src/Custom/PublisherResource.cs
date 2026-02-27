// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterPublisherResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherResource : HciClusterPublisherResource
    {
        /// <summary> Initializes a new instance of <see cref="PublisherResource"/>. </summary>
        protected PublisherResource()
        {
        }
    }
}
