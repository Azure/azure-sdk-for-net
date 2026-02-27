// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterOfferResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferResource : HciClusterOfferResource
    {
        /// <summary> Initializes a new instance of <see cref="OfferResource"/>. </summary>
        protected OfferResource()
        {
        }
    }
}
