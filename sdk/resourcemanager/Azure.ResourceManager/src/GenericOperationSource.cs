// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager
{
    internal class GenericOperationSource<T> : IOperationSource<T> where T: class, IModelSerializable
    {
        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private static T CreateResult(Response response)
        {
            return ModelSerializer.Deserialize<T>(response.Content);
        }
    }
}
