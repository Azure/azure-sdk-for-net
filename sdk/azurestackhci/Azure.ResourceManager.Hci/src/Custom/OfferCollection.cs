// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterOfferCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferCollection : HciClusterOfferCollection
    {
        /// <summary> Initializes a new instance of <see cref="OfferCollection"/>. </summary>
        protected OfferCollection()
        {
        }
    }
}
