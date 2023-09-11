// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

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
            MemoryStream memoryStream = response.ContentStream as MemoryStream;
            var model = Activator.CreateInstance(typeof(T), true) as IModelSerializable<T>;
            if (memoryStream == null)
            {
                return (T)model!.Deserialize(BinaryData.FromStream(response.ContentStream), new ModelSerializerOptions());
            }
            return (T)model!.Deserialize(new BinaryData(memoryStream.GetBuffer().AsMemory(0, (int)response.ContentStream.Length)), new ModelSerializerOptions());
        }
    }
}
