// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    internal class DataFactoryElementJsonConverter : JsonConverter<object?>
    {
        private static readonly ModelReaderWriterOptions s_options = new ModelReaderWriterOptions("W");

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
            switch (typeToConvert)
            {
                case Type t when t == typeof(DataFactoryElement<string?>):
                    return ((IJsonModel<DataFactoryElement<string?>>)new DataFactoryElement<string?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<int?>):
                    return ((IJsonModel<DataFactoryElement<int?>>)new DataFactoryElement<int?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<int>):
                    return ((IJsonModel<DataFactoryElement<int>>)new DataFactoryElement<int>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<double?>):
                    return ((IJsonModel<DataFactoryElement<double?>>)new DataFactoryElement<double?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<double>):
                    return ((IJsonModel<DataFactoryElement<double>>)new DataFactoryElement<double>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<bool?>):
                    return ((IJsonModel<DataFactoryElement<bool?>>)new DataFactoryElement<bool?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<bool>):
                    return ((IJsonModel<DataFactoryElement<bool>>)new DataFactoryElement<bool>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<DateTimeOffset?>):
                    return ((IJsonModel<DataFactoryElement<DateTimeOffset?>>)new DataFactoryElement<DateTimeOffset?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<DateTimeOffset>):
                    return ((IJsonModel<DataFactoryElement<DateTimeOffset>>)new DataFactoryElement<DateTimeOffset>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<TimeSpan?>):
                    return ((IJsonModel<DataFactoryElement<TimeSpan?>>)new DataFactoryElement<TimeSpan?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<TimeSpan>):
                    return ((IJsonModel<DataFactoryElement<TimeSpan>>)new DataFactoryElement<TimeSpan>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<Uri?>):
                    return ((IJsonModel<DataFactoryElement<Uri?>>)new DataFactoryElement<Uri?>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<Uri>):
                    return ((IJsonModel<DataFactoryElement<Uri>>)new DataFactoryElement<Uri>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<IList<string>>):
                    return ((IJsonModel<DataFactoryElement<IList<string>>>)new DataFactoryElement<IList<string>>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<IDictionary<string, string>>):
                    return ((IJsonModel<DataFactoryElement<IDictionary<string, string>>>)new DataFactoryElement<IDictionary<string, string>>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<IDictionary<string, BinaryData>>):
                    return ((IJsonModel<DataFactoryElement<IDictionary<string, BinaryData>>>)new DataFactoryElement<IDictionary<string, BinaryData>>(default)).Create(ref reader, s_options);
                case Type t when t == typeof(DataFactoryElement<BinaryData>):
                    return ((IJsonModel<DataFactoryElement<BinaryData>>)new DataFactoryElement<BinaryData>(default)).Create(ref reader, s_options);
                default:
                    {
                        using var document = JsonDocument.ParseValue(ref reader);
                        if (TryGetGenericDataFactoryList(typeToConvert, out Type? genericListType))
                        {
                            var methodInfo = GetGenericSerializationMethod(genericListType!, nameof(DeserializeGenericList));
                            return methodInfo!.Invoke(null, new object[] { document.RootElement })!;
                        }

                        throw new InvalidOperationException($"Unable to convert {typeToConvert.Name} into a DataFactoryElement<T>");
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case DataFactoryElement<string?> stringElement:
                    ((IJsonModel<DataFactoryElement<string?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<int> intElement:
                    ((IJsonModel<DataFactoryElement<int>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<int?> nullableIntElement:
                    ((IJsonModel<DataFactoryElement<int?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<double> doubleElement:
                    ((IJsonModel<DataFactoryElement<double>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<double?> nullableDoubleElement:
                    ((IJsonModel<DataFactoryElement<double?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<bool> boolElement:
                    ((IJsonModel<DataFactoryElement<bool>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<bool?> nullableBoolElement:
                    ((IJsonModel<DataFactoryElement<bool?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<DateTimeOffset> dtoElement:
                    ((IJsonModel<DataFactoryElement<DateTimeOffset>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<DateTimeOffset?> nullableDtoElement:
                    ((IJsonModel<DataFactoryElement<DateTimeOffset?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<TimeSpan> timespanElement:
                    ((IJsonModel<DataFactoryElement<TimeSpan>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<TimeSpan?> nullableTimespanElement:
                    ((IJsonModel<DataFactoryElement<TimeSpan?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<Uri?> uriElement:
                    ((IJsonModel<DataFactoryElement<Uri?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<IList<string?>?> stringListElement:
                    ((IJsonModel<DataFactoryElement<IList<string?>?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<IDictionary<string, string?>?> keyValuePairElement:
                    ((IJsonModel<DataFactoryElement<IDictionary<string, string?>?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<IDictionary<string, BinaryData?>?> keyValuePairElement:
                    ((IJsonModel<DataFactoryElement<IDictionary<string, BinaryData?>?>>)value).Write(writer, s_options);
                    break;
                case DataFactoryElement<BinaryData?> binaryDataElement:
                    ((IJsonModel<DataFactoryElement<BinaryData?>>)value).Write(writer, s_options);
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
                ((IUtf8JsonSerializable)element.Secret!).Write(writer);
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

        internal static DataFactoryElement<IList<T?>?> DeserializeGenericList<T>(JsonElement json)
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
                    element = DataFactoryElement<T?>.FromSecretBase(DataFactorySecret.DeserializeDataFactorySecretBaseDefinition(json)!);
                }
            }

            return element != null;
        }
    }
}
