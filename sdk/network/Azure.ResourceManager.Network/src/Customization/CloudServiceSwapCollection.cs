// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Azure.ResourceManager.Network
{
    public partial class CloudServiceSwapCollection : IEnumerable<CloudServiceSwapResource>, IAsyncEnumerable<CloudServiceSwapResource>
    {
        IEnumerator<CloudServiceSwapResource> IEnumerable<CloudServiceSwapResource>.GetEnumerator() => ((IEnumerable<CloudServiceSwapResource>)Array.Empty<CloudServiceSwapResource>()).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Array.Empty<CloudServiceSwapResource>().GetEnumerator();
        IAsyncEnumerator<CloudServiceSwapResource> IAsyncEnumerable<CloudServiceSwapResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<CloudServiceSwapResource>();

        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<CloudServiceSwapResource> GetAllAsync(CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<CloudServiceSwapResource> GetAll(CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
