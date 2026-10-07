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
    internal class EmptyAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        /// <summary> Compatibility member. </summary>
        public T Current { get; }
        /// <summary> Invokes the DisposeAsync compatibility operation. </summary>
        public ValueTask DisposeAsync() => new ValueTask();
        /// <summary> Invokes the MoveNextAsync compatibility operation. </summary>
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(false);
    }
}
