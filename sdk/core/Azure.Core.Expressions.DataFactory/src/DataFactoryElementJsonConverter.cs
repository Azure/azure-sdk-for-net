// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    internal class DataFactoryElementJsonConverter : JsonConverter<object?>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DataFactoryElement<string?>) ||
                   typeToConvert == typeof(DataFactoryElement<int?>) ||
                   typeToConvert == typeof(DataFactoryElement<int>) ||
                   typeToConvert == typeof(DataFactoryElement<double?>) ||
                   typeToConvert == typeof(DataFactoryElement<double>) ||
                   typeToConvert == typeof(DataFactoryElement<bool?>) ||
                   typeToConvert == typeof(DataFactoryElement<bool>) ||
                   typeToConvert == typeof(DataFactoryElement<DateTimeOffset?>) ||
                   typeToConvert == typeof(DataFactoryElement<DateTimeOffset>) ||
                   typeToConvert == typeof(DataFactoryElement<TimeSpan?>) ||
                   typeToConvert == typeof(DataFactoryElement<TimeSpan>) ||
                   typeToConvert == typeof(DataFactoryElement<Uri>) ||
                   typeToConvert == typeof(DataFactoryElement<IList<string>>) ||
                   typeToConvert == typeof(DataFactoryElement<IDictionary<string, string>>) ||
                   typeToConvert == typeof(DataFactoryElement<IDictionary<string, BinaryData>>) ||
                   typeToConvert == typeof(DataFactoryElement<BinaryData>) ||
                   TryGetGenericDataFactoryList(typeToConvert, out _);
        }

        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            if (typeToConvert == typeof(DataFactoryElement<string?>))
                return Deserialize<string>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<int?>) || typeToConvert == typeof(DataFactoryElement<int>))
                return Deserialize<int>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<double?>) || typeToConvert == typeof(DataFactoryElement<double>))
                return Deserialize<double>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<bool?>) || typeToConvert == typeof(DataFactoryElement<bool>))
                return Deserialize<bool>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<DateTimeOffset?>) || typeToConvert == typeof(DataFactoryElement<DateTimeOffset>))
                return Deserialize<DateTimeOffset>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<TimeSpan?>) || typeToConvert == typeof(DataFactoryElement<TimeSpan>))
                return Deserialize<TimeSpan>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<Uri>))
                return Deserialize<Uri>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<IList<string>>))
                return Deserialize<IList<string>>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<IDictionary<string, string>>))
                return Deserialize<IDictionary<string, string>>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<IDictionary<string, BinaryData>>))
                return Deserialize<IDictionary<string, BinaryData>>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryElement<BinaryData>))
                return Deserialize<BinaryData>(document.RootElement);
            if (TryGetGenericDataFactoryList(typeToConvert, out Type? genericListType))
            {
                var methodInfo = GetGenericSerializationMethod(genericListType!, nameof(DeserializeGenericList));
                return methodInfo!.Invoke(null, new object[] { document.RootElement })!;
            }

            throw new InvalidOperationException($"Unable to convert {typeToConvert.Name} into a DataFactoryElement<T>");
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case DataFactoryElement<string?> stringElement:
                    Serialize(writer, stringElement);
                    break;
                case DataFactoryElement<int> intElement:
                    Serialize(writer, intElement);
                    break;
                case DataFactoryElement<int?> nullableIntElement:
                    Serialize(writer, nullableIntElement);
                    break;
                case DataFactoryElement<double> doubleElement:
                    Serialize(writer, doubleElement);
                    break;
                case DataFactoryElement<double?> nullableDoubleElement:
                    Serialize(writer, nullableDoubleElement);
                    break;
                case DataFactoryElement<bool> boolElement:
                    Serialize(writer, boolElement);
                    break;
                case DataFactoryElement<bool?> nullableBoolElement:
                    Serialize(writer, nullableBoolElement);
                    break;
                case DataFactoryElement<DateTimeOffset> dtoElement:
                    Serialize(writer, dtoElement);
                    break;
                case DataFactoryElement<DateTimeOffset?> nullableDtoElement:
                    Serialize(writer, nullableDtoElement);
                    break;
                case DataFactoryElement<TimeSpan> timespanElement:
                    Serialize(writer, timespanElement);
                    break;
                case DataFactoryElement<TimeSpan?> nullableTimespanElement:
                    Serialize(writer, nullableTimespanElement);
                    break;
                case DataFactoryElement<Uri?> uriElement:
                    Serialize(writer, uriElement);
                    break;
                case DataFactoryElement<IList<string?>?> stringListElement:
                    Serialize<IList<string?>?>(writer, stringListElement);
                    break;
                case DataFactoryElement<IDictionary<string, string?>?> keyValuePairElement:
                    Serialize(writer, keyValuePairElement);
                    break;
                case DataFactoryElement<IDictionary<string, BinaryData?>?> keyValuePairElement:
                    Serialize(writer, keyValuePairElement);
                    break;
                case DataFactoryElement<BinaryData?> binaryDataElement:
                    Serialize(writer, binaryDataElement);
                    break;
                default:
                {
                    if (TryGetGenericDataFactoryList(value.GetType(), out Type? genericListType))
                    {
                        var methodInfo = GetGenericSerializationMethod(genericListType!, nameof(SerializeGenericList));
                        methodInfo!.Invoke(null, new object[] { writer, value });
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to convert {value.GetType().Name} into a DataFactoryExpression<T>");
                    }

                    break;
                }
            }
        }

        private static MethodInfo GetGenericSerializationMethod(Type typeToConvert, string methodName)
        {
            return typeof(DataFactoryElementJsonConverter)
                .GetMethod(
                    methodName,
                    BindingFlags.Static | BindingFlags.NonPublic)!
                .MakeGenericMethod(typeToConvert.GenericTypeArguments[0].GenericTypeArguments[0]);
        }

        private static bool TryGetGenericDataFactoryList(Type type, out Type? genericType)
        {
            genericType = null;

            if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(DataFactoryElement<>))
                return false;

            Type firstGeneric = type.GenericTypeArguments[0];

            if (!firstGeneric.IsGenericType || !IsGenericListType(type.GenericTypeArguments[0].GetGenericTypeDefinition()))
                return false;

            Type secondGeneric = type.GenericTypeArguments[0].GenericTypeArguments[0];

            if (secondGeneric.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute)))
            {
                genericType = type;
                return true;
            }

            return false;
        }

        private static bool IsGenericListType(Type type) => type == typeof(IList<>);

        private static void Serialize<T>(Utf8JsonWriter writer, DataFactoryElement<T?> element)
        {
            if (element.Kind == DataFactoryElementKind.Literal)
            {
                switch (element.Literal)
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
                    case IDictionary<string, BinaryData?> dictionary:
                        writer.WriteStartObject();
                        foreach (KeyValuePair<string, BinaryData?> pair in dictionary)
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
                        writer.WriteObjectValue(element.Literal!);
                        break;
                }
            }
            else if (element.Kind == DataFactoryElementKind.Expression)
            {
                SerializeExpression(writer, element.ExpressionString!);
            }
            else
            {
                writer.WriteObjectValue(element.Secret!);
            }
        }

        private static void SerializeGenericList<T>(Utf8JsonWriter writer, DataFactoryElement<IList<T?>?> element)
        {
            if (element.Kind == DataFactoryElementKind.Literal)
            {
                if (element.Literal == null)
                {
                    writer.WriteNullValue();
                    return;
                }

                writer.WriteStartArray();
                foreach (T? elem in element.Literal!)
                {
                    // underlying T must have a JsonConverter defined
                    JsonSerializer.Serialize(writer, elem!);
                }
                writer.WriteEndArray();
            }
            else if (element.Kind == DataFactoryElementKind.Expression)
            {
                SerializeExpression(writer, element.ExpressionString!);
            }
            else
            {
                writer.WriteObjectValue(element.Secret!);
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

        private static DataFactoryElement<IList<T?>?> DeserializeGenericList<T>(JsonElement json)
        {
            if (json.ValueKind == JsonValueKind.Array)
            {
                var list = new List<T?>();
                foreach (var item in json.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<T>(item.GetRawText()!));
                }

                return new DataFactoryElement<IList<T?>?>(list);
            }

            // Expression, SecretString, and AzureKeyVaultReference handling
            if (TryGetNonLiteral(json, out DataFactoryElement<IList<T?>?>? element))
            {
                return element!;
            }

            throw new InvalidOperationException($"Cannot deserialize an {json.ValueKind} as a list.");
        }

        internal static DataFactoryElement<T?>? Deserialize<T>(JsonElement json)
        {
            T? value = default;

            if (json.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            // Expression, SecretString, and AzureKeyVaultReference handling
            if (TryGetNonLiteral(json, out DataFactoryElement<T?>? element))
            {
                return element;
            }

            // Literal handling
            if (json.ValueKind == JsonValueKind.Object && typeof(T) == typeof(IDictionary<string, string>))
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var item in json.EnumerateObject())
                {
                    dictionary.Add(item.Name, item.Value.GetString()!);
                }

                return new DataFactoryElement<T?>((T)(object)dictionary);
            }

            if (json.ValueKind == JsonValueKind.Object && typeof(T) == typeof(IDictionary<string, BinaryData>))
            {
                var dictionary = new Dictionary<string, BinaryData>();
                foreach (var item in json.EnumerateObject())
                {
                    dictionary.Add(item.Name, BinaryData.FromString(item.Value.GetRawText()));
                }

                return new DataFactoryElement<T?>((T)(object)dictionary);
            }

            if (json.ValueKind == JsonValueKind.Array && typeof(T) == typeof(IList<string>))
            {
                var list = new List<string?>();
                foreach (var item in json.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<string?>(item.GetRawText()!));
                }

                return new DataFactoryElement<T?>((T)(object)list);
            }

            if (typeof(T) == typeof(DateTimeOffset))
            {
                return new DataFactoryElement<T?>((T)(object)json.GetDateTimeOffset("O"));
            }

            if (typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?))
            {
                return new DataFactoryElement<T?>((T)(object)json.GetTimeSpan("c"));
            }

            if (typeof(T) == typeof(Uri))
            {
                return new DataFactoryElement<T?>((T)(object)new Uri(json.GetString()!));
            }

            if (typeof(T) == typeof(BinaryData))
            {
                return new DataFactoryElement<T?>((T)(object)BinaryData.FromString(json.GetRawText()!));
            }

            var obj = json.GetObject();
            if (obj is not null)
                value = (T)obj;

            return new DataFactoryElement<T?>(value);
        }

        private static bool TryGetNonLiteral<T>(JsonElement json, out DataFactoryElement<T?>? element)
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
                    element = DataFactoryElement<T?>.FromSecretBase(DataFactorySecretBaseDefinition.DeserializeDataFactorySecretBaseDefinition(json)!);
                }
            }

            return element != null;
        }
    }
}
