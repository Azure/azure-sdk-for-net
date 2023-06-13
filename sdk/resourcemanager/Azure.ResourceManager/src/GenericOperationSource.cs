// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager
{
    internal class GenericOperationSource<T> : IOperationSource<T>
    {
        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private static T CreateResult(Response response)
        {
            if (typeof(T).GetInterface(nameof(ISerializable)) is null)
            {
                throw new InvalidOperationException("Type T should implement ISerializable. ");
            }
            //var model = Activator.CreateInstance(typeof(T));
            var memoryStream = new MemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter());
            var result = JsonSerializer.Deserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), typeof(T), options);
            //((ISerializable)model).TryDeserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), out int bytesConsumed);
            return (T)result;
        }
    }
}
