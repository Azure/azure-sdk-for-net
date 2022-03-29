// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Test.Shared
{
    public interface IDisposingContainer<TContainerClient> : IAsyncDisposable
    {
        public TContainerClient Container { get; }
    }
}
