// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.ClientModel.Primitives;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // generated WriteObjectValue<T> dispatch does not recognize the DataFactory expression
    // wrapper types. Add overloads that delegate serialization to their System.Text.Json converters.
    // TODO: remove once the generator/core types serialize these wrappers directly (#59298).
    internal static partial class ModelSerializationExtensions
    {
        public static void WriteObjectValue<T>(this Utf8JsonWriter writer, DataFactoryElement<T> value, ModelReaderWriterOptions options = null)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }
            JsonSerializer.Serialize(writer, value);
        }

        public static void WriteObjectValue(this Utf8JsonWriter writer, DataFactoryLinkedServiceReference value, ModelReaderWriterOptions options = null)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }
            JsonSerializer.Serialize(writer, value);
        }

        public static void WriteObjectValue(this Utf8JsonWriter writer, DataFactorySecret value, ModelReaderWriterOptions options = null)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }
            JsonSerializer.Serialize(writer, value);
        }

        public static void WriteObjectValue(this Utf8JsonWriter writer, DataFactorySecretString value, ModelReaderWriterOptions options = null)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }
            JsonSerializer.Serialize(writer, value);
        }

        public static void WriteObjectValue(this Utf8JsonWriter writer, DataFactoryKeyVaultSecret value, ModelReaderWriterOptions options = null)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }
            JsonSerializer.Serialize(writer, value);
        }
    }
}
