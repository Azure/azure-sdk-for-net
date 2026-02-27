// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateCollection : HciClusterUpdateCollection, IEnumerable<UpdateResource>, IAsyncEnumerable<UpdateResource>
    {
        /// <summary> Initializes a new instance of <see cref="UpdateCollection"/>. </summary>
        protected UpdateCollection()
        {
        }

        IEnumerator<UpdateResource> IEnumerable<UpdateResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<UpdateResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateCollection instead.");
        }

        IAsyncEnumerator<UpdateResource> IAsyncEnumerable<UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<UpdateResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateCollection instead.");
        }
    }
}
