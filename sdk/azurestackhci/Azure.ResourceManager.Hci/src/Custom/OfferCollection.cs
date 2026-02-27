// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterOfferCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferCollection : HciClusterOfferCollection, IEnumerable<OfferResource>, IAsyncEnumerable<OfferResource>
    {
        /// <summary> Initializes a new instance of <see cref="OfferCollection"/>. </summary>
        protected OfferCollection()
        {
        }

        IEnumerator<OfferResource> IEnumerable<OfferResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<OfferResource>
                ?? throw new NotSupportedException("Use HciClusterOfferCollection instead.");
        }

        IAsyncEnumerator<OfferResource> IAsyncEnumerable<OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<OfferResource>
                ?? throw new NotSupportedException("Use HciClusterOfferCollection instead.");
        }
    }
}
