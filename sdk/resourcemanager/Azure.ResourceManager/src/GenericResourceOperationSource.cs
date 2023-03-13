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
    internal class GenericResourceOperationSource<TResource, TModel> : IOperationSource<TResource>
        where TModel: ISerializable, new()
    {
        private readonly ArmClient _client;
        private readonly IOperationSource<TModel> _dataOperation;

        public GenericResourceOperationSource(ArmClient client)
        {
            _client = client;
            _dataOperation = new GenericOperationSource<TModel>();
        }

        TResource IOperationSource<TResource>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response, cancellationToken);

        ValueTask<TResource> IOperationSource<TResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new(CreateResult(response, cancellationToken));

        private TResource CreateResult(Response response, CancellationToken cancellationToken)
        {
            TModel data = _dataOperation.CreateResult(response, cancellationToken);
            return (TResource)Activator.CreateInstance(typeof(TResource), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { _client, data }, null);
        }
    }
}
