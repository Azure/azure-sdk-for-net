// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager
{
    internal class GenericOperationSource<T> : IOperationSource<T> where T : ISerializable, new()
    {
        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new(CreateResult(response));

        private static T CreateResult(Response response)
        {
            var model = new T();
            var memoryStream = new MemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            ((ISerializable)model).TryDeserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), out int bytesConsumed);
            return model;
        }
    }
}
