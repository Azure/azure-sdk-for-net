// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

public static partial class ModelReaderWriter
{
    private class StructWrapper<T> : StructWrapper, IJsonModel<StructWrapper<T>> where T : IJsonModel<T>
    {
        public StructWrapper(T value) : base(value)
        {
            Value = value;
        }

        public new T Value { get; private set; }

        public StructWrapper<T> Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => new StructWrapper<T>(Value.Create(ref reader, options));

        public StructWrapper<T> Create(BinaryData data, ModelReaderWriterOptions options)
            => new StructWrapper<T>(Value.Create(data, options));

        public string GetFormatFromOptions(ModelReaderWriterOptions options)
            => Value.GetFormatFromOptions(options);

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => Value.Write(writer, options);

        public BinaryData Write(ModelReaderWriterOptions options)
            => Value.Write(options);
    }

    private class StructWrapper
    {
        public StructWrapper(object value)
        {
            Value = value;
        }

        public object Value { get; }
    }
}
