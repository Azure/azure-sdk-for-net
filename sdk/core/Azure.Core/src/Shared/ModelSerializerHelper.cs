// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace Azure.Core
{
    internal static class ModelSerializerHelper
    {
        public static BinaryData SerializeToBinaryData(Action<Utf8JsonWriter> serialize)
        {
            using var writer = new SequenceWriter();
            using var jsonWriter = new Utf8JsonWriter(writer);
            serialize(jsonWriter);
            jsonWriter.Flush();
            writer.TryComputeLength(out var length);
            using var stream = new MemoryStream((int)length);
            writer.CopyTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public static BinaryData SerializeToBinaryData(Action<XmlWriter> serialize)
        {
            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            serialize(writer);
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }
    }
}
