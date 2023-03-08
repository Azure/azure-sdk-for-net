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
    internal class GenericOperationSource<T> : IOperationSource<T>
    {
        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            if (typeof(T).GetInterface(nameof(ISerializable)) is null)
            {
                throw new InvalidOperationException("Invalid type");
            }
            ISerializable serializable = (ISerializable)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, null, null, null);
            var memoryStream = new MemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            serializable.TryDeserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), out int bytesConsumed);
            return (T)serializable;
        }

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            if (typeof(T).GetInterface(nameof(ISerializable)) is null)
            {
                throw new InvalidOperationException("Invalid type");
            }
            ISerializable serializable = (ISerializable)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, null, null, null);
            var memoryStream = new MemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            serializable.TryDeserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), out int bytesConsumed);
            return new ValueTask<T>((T)serializable);
        }
    }
}
