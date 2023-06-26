// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal readonly struct LazyMsalTuple<T>
    {
        private readonly Lazy<T> _caeClient;
        private readonly Lazy<T> _nonCaeClient;

        public LazyMsalTuple(Lazy<T> caeClient, Lazy<T> nonCaeClient)
        {
            _caeClient = caeClient ?? throw new ArgumentNullException(nameof(caeClient));
            _nonCaeClient = nonCaeClient ?? throw new ArgumentNullException(nameof(nonCaeClient));
        }

        public T Client(bool withCae)
        {
            return withCae ? _caeClient.Value : _nonCaeClient.Value;
        }
    }
}
