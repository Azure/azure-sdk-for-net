// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Shared;

namespace Azure.ResourceManager
{
    internal class GenericResourceOperationSource<TResource, TModel> : IOperationSource<TResource>
        where TModel: ISerializable, new()
        where TResource : IData<TModel>
    {
        private readonly ArmClient _client;
        private readonly IOperationSource<TModel> _dataOperation;

        public GenericResourceOperationSource(ArmClient client)
        {
            _client = client;
            _dataOperation = new GenericOperationSource<TModel>();
        }

        TResource IOperationSource<TResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            TModel data = _dataOperation.CreateResult(response, cancellationToken);
            return (TResource)Activator.CreateInstance(typeof(TResource), BindingFlags.NonPublic | BindingFlags.Instance, _client, data);
        }

        ValueTask<TResource> IOperationSource<TResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            object data = _dataOperation.CreateResult(response, cancellationToken);
            var resource = (TResource)Activator.CreateInstance(typeof(TResource), BindingFlags.NonPublic | BindingFlags.Instance, _client, data);
            return new ValueTask<TResource>(resource);
        }
    }
}
