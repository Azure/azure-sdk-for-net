// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization added as a workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298
// The generated WriteObjectValue<T> dispatcher does not recognize DataFactoryElement<T> or the
// DataFactory secret / linked-service-reference family types because the shipped 1.0.0 build of
// Azure.Core.Expressions.DataFactory does not implement IJsonModel<T>/IPersistableModel<T>; the
// types serialize via a [JsonConverter] attribute instead. We add more-specific non-generic
// overloads so C# overload resolution picks these for known DataFactory wrapper types and
// delegates to System.Text.Json which honours the [JsonConverter] attribute.

#nullable disable

using System.Text.Json;
using System.ClientModel.Primitives;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory
{
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
