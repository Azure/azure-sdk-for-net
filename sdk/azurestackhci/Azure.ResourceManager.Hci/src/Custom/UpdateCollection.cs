// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateCollection : HciClusterUpdateCollection
    {
        /// <summary> Initializes a new instance of <see cref="UpdateCollection"/>. </summary>
        protected UpdateCollection()
        {
        }
    }
}
