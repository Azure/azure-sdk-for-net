// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateRunResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunResource : HciClusterUpdateRunResource
    {
        /// <summary> Initializes a new instance of <see cref="UpdateRunResource"/>. </summary>
        protected UpdateRunResource()
        {
        }
    }
}
