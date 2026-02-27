// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateRunCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunCollection : HciClusterUpdateRunCollection, IEnumerable<UpdateRunResource>, IAsyncEnumerable<UpdateRunResource>
    {
        /// <summary> Initializes a new instance of <see cref="UpdateRunCollection"/>. </summary>
        protected UpdateRunCollection()
        {
        }

        IEnumerator<UpdateRunResource> IEnumerable<UpdateRunResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<UpdateRunResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateRunCollection instead.");
        }

        IAsyncEnumerator<UpdateRunResource> IAsyncEnumerable<UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<UpdateRunResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateRunCollection instead.");
        }
    }
}
