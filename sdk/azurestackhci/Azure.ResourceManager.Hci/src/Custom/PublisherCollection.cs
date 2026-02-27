// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterPublisherCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherCollection : HciClusterPublisherCollection, IEnumerable<PublisherResource>, IAsyncEnumerable<PublisherResource>
    {
        /// <summary> Initializes a new instance of <see cref="PublisherCollection"/>. </summary>
        protected PublisherCollection()
        {
        }

        IEnumerator<PublisherResource> IEnumerable<PublisherResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<PublisherResource>
                ?? throw new NotSupportedException("Use HciClusterPublisherCollection instead.");
        }

        IAsyncEnumerator<PublisherResource> IAsyncEnumerable<PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<PublisherResource>
                ?? throw new NotSupportedException("Use HciClusterPublisherCollection instead.");
        }
    }
}
