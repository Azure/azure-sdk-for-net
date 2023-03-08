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
    internal class GenericResourceOperationSource<TResource, TData> : IOperationSource<TResource> where TData : ISerializable, new()
    {
        private readonly ArmClient _client;
        private readonly IOperationSource<TData> _dataOperation;

        public GenericResourceOperationSource(ArmClient client)
        {
            _client = client;
            _dataOperation = new GenericOperationSource<TData>();
        }

        TResource IOperationSource<TResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            TData data = _dataOperation.CreateResult(response, cancellationToken);
            return (TResource)Activator.CreateInstance(typeof(TResource), BindingFlags.NonPublic | BindingFlags.Instance, _client, data);
        }

        ValueTask<TResource> IOperationSource<TResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            TData data = _dataOperation.CreateResult(response, cancellationToken);
            var resource = (TResource)Activator.CreateInstance(typeof(TResource), BindingFlags.NonPublic | BindingFlags.Instance, _client, data);
            return new ValueTask<TResource>(resource);
        }
    }
}
