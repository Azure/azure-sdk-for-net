// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateResource : HciClusterUpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="UpdateResource"/>. </summary>
        protected UpdateResource()
        {
        }
    }
}
