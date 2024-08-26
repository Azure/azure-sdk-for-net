// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

public static partial class ModelReaderWriter
{
    private class StructWapper<T> : IJsonModel<StructWapper<T>> where T : IJsonModel<T>
    {
        public StructWapper(T value) => Value = value;

        public T Value { get; private set; }

        public StructWapper<T> Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => new StructWapper<T>(Value.Create(ref reader, options));

        public StructWapper<T> Create(BinaryData data, ModelReaderWriterOptions options)
            => new StructWapper<T>(Value.Create(data, options));

        public string GetFormatFromOptions(ModelReaderWriterOptions options)
            => Value.GetFormatFromOptions(options);

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => Value.Write(writer, options);

        public BinaryData Write(ModelReaderWriterOptions options)
            => Value.Write(options);

        public static implicit operator T(StructWapper<T> wrapper) => wrapper.Value;
    }
}
