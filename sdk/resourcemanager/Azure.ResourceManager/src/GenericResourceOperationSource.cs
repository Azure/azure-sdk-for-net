// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager
{
    internal class GenericResourceOperationSource<T> : IOperationSource<T>
    {
        private readonly ArmClient _client;
        private readonly IOperationSource<object> _dataOperation;

        public GenericResourceOperationSource(ArmClient client)
        {
            _client = client;
            _dataOperation = new GenericOperationSource<object>();
        }

        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            object data = _dataOperation.CreateResult(response, cancellationToken);
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, _client, data);
        }

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            object data = _dataOperation.CreateResult(response, cancellationToken);
            var resource = (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, _client, data);
            return new ValueTask<T>(resource);
        }
    }
}
