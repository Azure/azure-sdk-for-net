// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager
{
    internal class GenericResourceOperationSource<T> : IOperationSource<T>
    {
        private readonly ArmClient _client;
        private readonly IResource _resource;

        public GenericResourceOperationSource(ArmClient client, IResource resource)
        {
            _client = client;
            _resource = resource;
        }

        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private T CreateResult(Response response)
        {
            var model = _resource.DataBag;
            var memoryStream = new MemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            model.TryDeserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), out int bytesConsumed);
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { _client, model }, null);
        }
    }
}
