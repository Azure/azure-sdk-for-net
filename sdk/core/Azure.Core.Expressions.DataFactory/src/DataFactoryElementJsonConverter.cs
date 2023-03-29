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
            if (TryGetGenericDataFactoryList(typeToConvert, out Type? genericListType))
            {
                var methodInfo = GetGenericSerializationMethod(genericListType!, nameof(DeserializeGenericList));
                return methodInfo!.Invoke(null, new object[] { document.RootElement })!;
            }

            throw new InvalidOperationException($"Unable to convert {typeToConvert.Name} into a DataFactoryExpression<T>");
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case DataFactoryElement<string?> stringExpression:
                    Serialize(writer, stringExpression);
                    break;
                case DataFactoryElement<int> intExpression:
                    Serialize(writer, intExpression);
                    break;
                case DataFactoryElement<int?> nullableIntExpression:
                    Serialize(writer, nullableIntExpression);
                    break;
                case DataFactoryElement<double> doubleExpression:
                    Serialize(writer, doubleExpression);
                    break;
                case DataFactoryElement<double?> nullableDoubleExpression:
                    Serialize(writer, nullableDoubleExpression);
                    break;
                case DataFactoryElement<bool> boolExpression:
                    Serialize(writer, boolExpression);
                    break;
                case DataFactoryElement<bool?> nullableBoolExpression:
                    Serialize(writer, nullableBoolExpression);
                    break;
                case DataFactoryElement<DateTimeOffset> dtoExpression:
                    Serialize(writer, dtoExpression);
                    break;
                case DataFactoryElement<DateTimeOffset?> nullableDtoExpression:
                    Serialize(writer, nullableDtoExpression);
                    break;
                case DataFactoryElement<TimeSpan> timespanExpression:
                    Serialize(writer, timespanExpression);
                    break;
                case DataFactoryElement<TimeSpan?> nullableTimespanExpression:
                    Serialize(writer, nullableTimespanExpression);
                    break;
                case DataFactoryElement<Uri?> uriExpression:
                    Serialize(writer, uriExpression);
                    break;
                case DataFactoryElement<IList<string?>?> stringListExpression:
                    Serialize<IList<string?>?>(writer, stringListExpression);
                    break;
                case DataFactoryElement<IDictionary<string, string?>?> keyValuePairExpression:
                    Serialize(writer, keyValuePairExpression);
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
                    default:
                        writer.WriteObjectValue(element.Literal!);
                        break;
                }
            }
            else
            {
                SerializeExpression(writer, element.Kind!, element.Expression!);
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
            else
            {
                SerializeExpression(writer, element.Kind, element.Expression!);
            }
        }

        private static void SerializeExpression(Utf8JsonWriter writer, DataFactoryElementKind kind, string value)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(kind.ToString());
            writer.WritePropertyName("value");
            writer.WriteStringValue(value);
            writer.WriteEndObject();
        }

        private static DataFactoryElement<IList<T?>> DeserializeGenericList<T>(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                var list = new List<T?>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<T>(item.GetRawText()!));
                }

                return new DataFactoryElement<IList<T?>>(list);
            }

            if (element.ValueKind == JsonValueKind.Object)
            {
                return DeserializeExpression<IList<T?>>(element);
            }

            throw new InvalidOperationException($"Cannot deserialize an {element.ValueKind} as a list.");
        }

        internal static DataFactoryElement<T?>? Deserialize<T>(JsonElement element)
        {
            T? value = default;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (element.ValueKind == JsonValueKind.Object
                && element.TryGetProperty("type", out JsonElement typeElement)
                && typeElement.ValueKind == JsonValueKind.String
                && typeElement.GetString() == "Expression")
            {
                return DeserializeExpression<T?>(element);
            }

            if (element.ValueKind == JsonValueKind.Object && typeof(T) == typeof(IDictionary<string, string>))
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var item in element.EnumerateObject())
                {
                    dictionary.Add(item.Name, item.Value.GetString()!);
                }

                return new DataFactoryElement<T?>((T)(object)dictionary);
            }

            if (element.ValueKind == JsonValueKind.Array && typeof(T) == typeof(IList<string>))
            {
                var list = new List<string?>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<string?>(item.GetRawText()!));
                }

                return new DataFactoryElement<T?>((T)(object)list);
            }

            if (typeof(T) == typeof(DateTimeOffset))
            {
                return new DataFactoryElement<T?>((T)(object)element.GetDateTimeOffset("O"));
            }

            if (typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?))
            {
                return new DataFactoryElement<T?>((T)(object)element.GetTimeSpan("c"));
            }

            if (typeof(T) == typeof(Uri))
            {
                return new DataFactoryElement<T?>((T)(object)new Uri(element.GetString()!));
            }

            var obj = element.GetObject();
            if (obj is not null)
                value = (T)obj;

            return new DataFactoryElement<T?>(value);
        }

        private static DataFactoryElement<T> DeserializeExpression<T>(JsonElement element)
        {
            string? expression = null;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    expression = property.Value.GetString();
                    break;
                }
            }

            if (expression is null)
                throw new InvalidOperationException("Could not be deserialized as an expression. Missing required parameter 'value'.");
            return DataFactoryElement<T>.FromExpression(expression);
        }
    }
}
