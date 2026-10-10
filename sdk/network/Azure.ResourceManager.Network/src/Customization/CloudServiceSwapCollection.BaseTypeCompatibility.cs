// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CloudServiceSwapCollection type. </summary>
    public partial class CloudServiceSwapCollection : IEnumerable<CloudServiceSwapResource>, IAsyncEnumerable<CloudServiceSwapResource>
    {
        IEnumerator<CloudServiceSwapResource> IEnumerable<CloudServiceSwapResource>.GetEnumerator() => ((IEnumerable<CloudServiceSwapResource>)Array.Empty<CloudServiceSwapResource>()).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => Array.Empty<CloudServiceSwapResource>().GetEnumerator();
        IAsyncEnumerator<CloudServiceSwapResource> IAsyncEnumerable<CloudServiceSwapResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new EmptyAsyncEnumerator<CloudServiceSwapResource>();
    }
}
