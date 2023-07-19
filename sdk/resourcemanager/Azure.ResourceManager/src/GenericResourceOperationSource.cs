// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager
{
    internal class GenericResourceOperationSource<T> : IOperationSource<T> where T: class, IModelSerializable
    {
        private readonly ArmClient _client;

        public GenericResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private T CreateResult(Response response)
        {
            object data;
            Type dataType = typeof(T).GetProperty("Data").PropertyType;
            MemoryStream memoryStream = response.ContentStream as MemoryStream;
            if (memoryStream == null)
            {
                data = ModelSerializer.Deserialize(BinaryData.FromStream(memoryStream), dataType, new ModelSerializerOptions());
            }
            else
            {
                data = ModelSerializer.Deserialize(new BinaryData(memoryStream.GetBuffer().AsMemory(0, (int)response.ContentStream.Length)), dataType, new ModelSerializerOptions());
            }
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { _client, data }, null);
        }
    }
}
