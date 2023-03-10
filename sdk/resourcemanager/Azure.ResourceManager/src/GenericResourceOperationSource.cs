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
        private readonly Type _modelType;

        public GenericResourceOperationSource(ArmClient client, Type modelType)
        {
            _client = client;
            _modelType = modelType;
        }

        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            return CreateResult(response);
        }

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            return new ValueTask<T>(CreateResult(response));
        }

        private T CreateResult(Response response)
        {
            if (_modelType.GetInterface(nameof(ISerializable)) is null)
            {
                throw new InvalidOperationException($"The model type {_modelType.Name} should implement ISerializable. ");
            }
            var model = Activator.CreateInstance(_modelType);
            var memoryStream = new MemoryStream();
            response.ContentStream.CopyTo(memoryStream);
            ((ISerializable)model).TryDeserialize(new ReadOnlySpan<byte>(memoryStream.ToArray()), out int bytesConsumed);
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { _client, model }, null);
        }
    }
}
