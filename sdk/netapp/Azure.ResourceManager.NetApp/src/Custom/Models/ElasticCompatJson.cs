// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    internal static class ElasticCompatJson
    {
        internal static T Create<T>(System.BinaryData data, System.Func<T> factory)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            _ = reader;
            return factory();
        }

        internal static System.BinaryData Write(ModelReaderWriterOptions options)
        {
            _ = options;
            return System.BinaryData.FromString("{}");
        }
    }
}
