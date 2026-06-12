// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    // Backward-compat helper for model stubs preserved from the GA SDK surface.
    internal static class SqlCompatibilityModelSerialization
    {
        internal static void ValidateFormat(string modelName, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? "J" : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {modelName} does not support writing '{format}' format.");
            }
        }

        internal static BinaryData Write(Action<Utf8JsonWriter> write)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            write(writer);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        internal static T Create<T>(string modelName)
        {
            throw new NotSupportedException($"Deserializing the compatibility model {modelName} is not supported.");
        }
    }
}
