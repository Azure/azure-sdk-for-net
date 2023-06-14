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

namespace Azure.ResourceManager
{
    internal class GenericResourceOperationSource<T> : IOperationSource<T>
    {
        private readonly ArmClient _client;
        private readonly Type _dataType;

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
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ModelJsonConverter());
            var result = JsonSerializer.Deserialize(response.Content, _dataType, options);
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { _client, result }, null);
        }
    }
}
