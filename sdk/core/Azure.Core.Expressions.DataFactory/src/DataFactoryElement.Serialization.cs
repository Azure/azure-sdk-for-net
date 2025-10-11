// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Azure.Core.Expressions.DataFactory
{
#pragma warning disable SCM0005 // Type must have a parameterless constructor
    public sealed partial class DataFactoryElement<T> : IJsonModel<DataFactoryElement<T>>
#pragma warning restore SCM0005 // Type must have a parameterless constructor
    {
        void IJsonModel<DataFactoryElement<T>>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryElement<T>>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryElement<T>)} does not support '{format}' format.");
            }

            if (Kind == DataFactoryElementKind.Literal)
            {
                SerializeLiteral(writer, options);
            }
            else if (Kind == DataFactoryElementKind.Expression)
            {
                SerializeExpression(writer, ExpressionString!);
            }
            else
            {
                ((IUtf8JsonSerializable)Secret!).Write(writer);
            }
        }

        DataFactoryElement<T> IJsonModel<DataFactoryElement<T>>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryElement<T>>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryElement<T>)} does not support '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            return Create(document.RootElement, options);
        }

        BinaryData IPersistableModel<DataFactoryElement<T>>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryElement<T>>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryElement<T>)} does not support '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, DataFactoryContext.Default);
        }

        DataFactoryElement<T> IPersistableModel<DataFactoryElement<T>>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryElement<T>>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryElement<T>)} does not support '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            return Create(document.RootElement, options);
        }

        string IPersistableModel<DataFactoryElement<T>>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static DataFactoryElement<T> Create(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null!;
            }

            // Check for Expression or Secret (non-literal) elements
            if (TryGetNonLiteral(element, out DataFactoryElement<T?>? nonLiteralElement))
            {
                return nonLiteralElement!;
            }

            // Handle literal values based on type T
            return CreateLiteralElement(element);
        }

        private void SerializeLiteral(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            switch (Literal)
            {
                case TimeSpan timeSpan:
                    writer.WriteStringValue(timeSpan, "c");
                    break;
                case Uri uri:
                    writer.WriteStringValue(uri.AbsoluteUri);
                    break;
                case IList<string> stringList:
                    writer.WriteStartArray();
                    foreach (string? item in stringList)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                    break;
                case IDictionary<string, string?> dictionary:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, string?> pair in dictionary)
                    {
                        writer.WritePropertyName(pair.Key);
                        writer.WriteStringValue(pair.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case IDictionary<string, BinaryData?> binaryDictionary:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, BinaryData?> pair in binaryDictionary)
                    {
                        writer.WritePropertyName(pair.Key);
                        if (pair.Value != null)
                        {
                            using JsonDocument document = JsonDocument.Parse(pair.Value.ToString());
                            document.RootElement.WriteTo(writer);
                        }
                        else
                        {
                            writer.WriteNullValue();
                        }
                    }
                    writer.WriteEndObject();
                    break;
                case BinaryData binaryData:
                    using (JsonDocument document = JsonDocument.Parse(binaryData.ToString()))
                    {
                        document.RootElement.WriteTo(writer);
                    }
                    break;
                default:
                    WriteObjectValue(writer, Literal!, options);
                    break;
            }
        }

        private void WriteObjectValue<T1>(Utf8JsonWriter writer, T1 value, ModelReaderWriterOptions options)
        {
            switch (value)
            {
                case IJsonModel<T1> jsonModel:
                    jsonModel.Write(writer, options);
                    break;
                case IEnumerable<KeyValuePair<string, object>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        WriteObjectValue(writer, pair.Value, options);
                    }
                    writer.WriteEndObject();
                    break;
                case IEnumerable<object> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object item in objectEnumerable)
                    {
                        WriteObjectValue(writer, item, options);
                    }
                    writer.WriteEndArray();
                    break;
                case null:
                case IUtf8JsonSerializable:
                case byte[]:
                case BinaryData:
                case JsonElement:
                case int:
                case decimal:
                case double:
                case float:
                case long:
                case string:
                case bool:
                case Guid:
                case DateTimeOffset:
                case DateTime:
                case TimeSpan:
                    writer.WriteObjectValue(value!);
                    break;

                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }

        private static void SerializeExpression(Utf8JsonWriter writer, string value)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue("Expression");
            writer.WritePropertyName("value");
            writer.WriteStringValue(value);
            writer.WriteEndObject();
        }

        private static bool TryGetNonLiteral(JsonElement json, out DataFactoryElement<T?>? element)
        {
            element = null;
            if (json.ValueKind == JsonValueKind.Object && json.TryGetProperty("type", out JsonElement typeValue))
            {
                if (typeValue.ValueEquals("Expression"))
                {
                    if (json.EnumerateObject().Count() != 2)
                    {
                        // Expression should only have two properties: type and value
                        return false;
                    }
                    var expressionValue = json.GetProperty("value").GetString();
                    element = new DataFactoryElement<T?>(expressionValue, DataFactoryElementKind.Expression);
                }
                else
                {
                    element = DataFactoryElement<T>.FromSecretBase(DataFactorySecret.DeserializeDataFactorySecretBaseDefinition(json)!);
                }
            }

            return element != null;
        }

        private static DataFactoryElement<T> CreateLiteralElement(JsonElement json)
        {
            T? value = default;

            // Handle specific type conversions
            if (typeof(T) == typeof(IDictionary<string, string>) && json.ValueKind == JsonValueKind.Object)
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var item in json.EnumerateObject())
                {
                    dictionary.Add(item.Name, item.Value.GetString()!);
                }
                return new DataFactoryElement<T>((T)(object)dictionary);
            }

            if (typeof(T) == typeof(IDictionary<string, BinaryData>) && json.ValueKind == JsonValueKind.Object)
            {
                var dictionary = new Dictionary<string, BinaryData>();
                foreach (var item in json.EnumerateObject())
                {
                    dictionary.Add(item.Name, BinaryData.FromString(item.Value.GetRawText()));
                }
                return new DataFactoryElement<T>((T)(object)dictionary);
            }

            if (typeof(T) == typeof(DateTimeOffset) || typeof(T) == typeof(DateTimeOffset?))
            {
                return new DataFactoryElement<T>((T)(object)json.GetDateTimeOffset("O"));
            }

            if (typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?))
            {
                return new DataFactoryElement<T>((T)(object)json.GetTimeSpan("c"));
            }

            if (typeof(T) == typeof(Uri))
            {
                return new DataFactoryElement<T>((T)(object)new Uri(json.GetString()!));
            }

            if (typeof(T) == typeof(BinaryData))
            {
                return new DataFactoryElement<T>((T)(object)BinaryData.FromString(json.GetRawText()!));
            }

            if (typeof(T).IsGenericType)
            {
                var methodInfo = GetGenericSerializationMethod(typeof(T).GenericTypeArguments[0]!, nameof(DataFactoryElementJsonConverter.DeserializeGenericList));
                return (DataFactoryElement<T>)methodInfo!.Invoke(null, new object[] { json })!;
            }

            // Handle primitive and other types
            var obj = json.GetObject();
            if (obj is not null)
                value = (T)obj;

            return new DataFactoryElement<T>(value);
        }

#pragma warning disable IL2060 // MakeGenericMethod is not AOT friendly
#pragma warning disable IL3050 // MakeGenericMethod is not AOT friendly
        private static MethodInfo GetGenericSerializationMethod(Type typeToConvert, string methodName)
        {
            return typeof(DataFactoryElementJsonConverter)
                .GetMethod(
                    methodName,
                    BindingFlags.Static | BindingFlags.NonPublic)!
                .MakeGenericMethod(typeToConvert);
        }
#pragma warning restore IL2060 // MakeGenericMethod is not AOT friendly
#pragma warning restore IL3050 // MakeGenericMethod is not AOT friendly
    }
}
