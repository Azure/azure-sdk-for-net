// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateRunCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunCollection : HciClusterUpdateRunCollection
    {
        /// <summary> Initializes a new instance of <see cref="UpdateRunCollection"/>. </summary>
        protected UpdateRunCollection()
        {
        }
    }
}
