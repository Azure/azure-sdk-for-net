// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Expressions.DataFactory
{
#pragma warning disable SA1649 // File name should match first type name
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
}
