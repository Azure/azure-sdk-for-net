// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager
{
    internal class GenericOperationSource<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : IOperationSource<T>
    {
        private readonly ArmClient _client;
        private readonly bool _isResource;

        public GenericOperationSource(ArmClient client, bool isResource)
        {
            _client = client;
            _isResource = isResource;
        }

        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private T CreateResult(Response response)
        {
            // This call will never be invoked with a collection of models, so we can safely disable the warning
#pragma warning disable AZC0150 // Use ModelReaderWriter overloads with ModelReaderWriterContext
            object data = ModelReaderWriter.Read(response.Content, typeof(T));
#pragma warning restore AZC0150 // Use ModelReaderWriter overloads with ModelReaderWriterContext
            return _isResource
                ? (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { _client, data }, null)
                : (T)data;
        }
    }
}
