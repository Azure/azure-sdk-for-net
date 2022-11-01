// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.IoT, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Core.Expressions.DataFactory
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.IoT, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
#pragma warning disable SA1649 // File name should match first type name
    [JsonConverter(typeof(DataFactoryExpressionConverter<>))]
    public sealed partial class DataFactoryExpression<T> : IUtf8JsonSerializable
#pragma warning restore SA1649 // File name should match first type name
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (HasLiteral)
            {
                writer.WriteObjectValue(_literal!);
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("type");
                writer.WriteStringValue(_type);
                writer.WritePropertyName("value");
                writer.WriteStringValue(_expression);
                writer.WriteEndObject();
            }
        }

        internal static DataFactoryExpression<T> DeserializeDataFactoryExpression(JsonElement element)
        {
            string? expression = default;
            Optional<T> value = default;

            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("value"))
                    {
                        expression = property.Value.GetString();
                        continue;
                    }
                }
                return new DataFactoryExpression<T>(value, expression);
            }
            else
            {
                var obj = element.GetObject();
                if (obj is not null)
                    value = (T)obj;
                return new DataFactoryExpression<T>(value, null);
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal partial class DataFactoryExpressionConverter<T> : JsonConverter<DataFactoryExpression<T>>
#pragma warning restore SA1402 // File may only contain a single type
    {
        public override void Write(Utf8JsonWriter writer, DataFactoryExpression<T> model, JsonSerializerOptions options)
        {
            writer.WriteObjectValue(model);
        }
        public override DataFactoryExpression<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            return DataFactoryExpression<T>.DeserializeDataFactoryExpression(document.RootElement);
        }
    }
}
