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
    internal class DataFactoryExpressionJsonConverter : JsonConverter<object?>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DataFactoryExpression<string?>) ||
                   typeToConvert == typeof(DataFactoryExpression<int?>) ||
                   typeToConvert == typeof(DataFactoryExpression<int>) ||
                   typeToConvert == typeof(DataFactoryExpression<double?>) ||
                   typeToConvert == typeof(DataFactoryExpression<double>) ||
                   typeToConvert == typeof(DataFactoryExpression<Array?>) ||
                   typeToConvert == typeof(DataFactoryExpression<bool?>) ||
                   typeToConvert == typeof(DataFactoryExpression<bool>) ||
                   TryGetGenericDataFactoryList(typeToConvert, out _);
        }

        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            if (typeToConvert == typeof(DataFactoryExpression<string?>))
                return Deserialize<string>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<int?>) || typeToConvert == typeof(DataFactoryExpression<int>))
                return Deserialize<int>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<double?>) || typeToConvert == typeof(DataFactoryExpression<double>))
                return Deserialize<double>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<Array?>))
                return Deserialize<Array>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<bool?>) || typeToConvert == typeof(DataFactoryExpression<bool>))
                return Deserialize<bool>(document.RootElement);
            if (TryGetGenericDataFactoryList(typeToConvert, out Type? genericListType))
            {
                var methodInfo = GetGenericSerializationMethod(genericListType!, nameof(DeserializeList));
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
                case DataFactoryExpression<string?> stringExpression:
                    Serialize(writer, stringExpression);
                    break;
                case DataFactoryExpression<int> intExpression:
                    Serialize(writer, intExpression);
                    break;
                case DataFactoryExpression<int?> nullableIntExpression:
                    Serialize(writer, nullableIntExpression);
                    break;
                case DataFactoryExpression<double> doubleExpression:
                    Serialize(writer, doubleExpression);
                    break;
                case DataFactoryExpression<double?> nullableDoubleExpression:
                    Serialize(writer, nullableDoubleExpression);
                    break;
                case DataFactoryExpression<Array?> arrayExpression:
                    Serialize(writer, arrayExpression);
                    break;
                case DataFactoryExpression<bool> boolExpression:
                    Serialize(writer, boolExpression);
                    break;
                case DataFactoryExpression<bool?> nullableBoolExpression:
                    Serialize(writer, nullableBoolExpression);
                    break;
                default:
                {
                    if (TryGetGenericDataFactoryList(value.GetType(), out Type? genericListType))
                    {
                        var methodInfo = GetGenericSerializationMethod(genericListType!, nameof(SerializeList));
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
            return typeof(DataFactoryExpressionJsonConverter)
                .GetMethod(
                    methodName,
                    BindingFlags.Static | BindingFlags.NonPublic)!
                .MakeGenericMethod(typeToConvert.GenericTypeArguments[0].GenericTypeArguments[0]);
        }

        private static bool TryGetGenericDataFactoryList(Type type, out Type? genericType)
        {
            genericType = null;

            if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(DataFactoryExpression<>))
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

        private static void Serialize<T>(Utf8JsonWriter writer, DataFactoryExpression<T?> expression)
        {
            if (expression.HasLiteral)
            {
                writer.WriteObjectValue(expression.Literal!);
            }
            else
            {
                SerializeExpression(writer, expression.Type!, expression.Expression!);
            }
        }

        private static void SerializeList<T>(Utf8JsonWriter writer, DataFactoryExpression<IList<T?>> expression)
        {
            if (expression.HasLiteral)
            {
                if (expression.Literal == null)
                {
                    writer.WriteNullValue();
                    return;
                }

                writer.WriteStartArray();
                foreach (T? elem in expression.Literal!)
                {
                    JsonSerializer.Serialize(writer, elem);
                }
                writer.WriteEndArray();
            }
            else
            {
                SerializeExpression(writer, expression.Type!, expression.Expression!);
            }
        }

        private static void SerializeExpression(Utf8JsonWriter writer, string type, string value)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(type);
            writer.WritePropertyName("value");
            writer.WriteStringValue(value);
            writer.WriteEndObject();
        }

        private static DataFactoryExpression<IList<T?>> DeserializeList<T>(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                var list = new List<T?>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<T>(item.ToString()!));
                }

                return new DataFactoryExpression<IList<T?>>(list);
            }

            if (element.ValueKind == JsonValueKind.Object)
            {
                return DeserializeExpression<IList<T?>>(element);
            }

            throw new InvalidOperationException($"Cannot deserialize an {element.ValueKind} as a list.");
        }

        internal static DataFactoryExpression<T>? Deserialize<T>(JsonElement element)
        {
            T? value = default;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            // TODO - The current assumption is that if we have a JSON object, then the value must be an expression.
            // This may not always be true in the future, in which case we would need to check the payload to see if it is
            // an expression or a literal.

            if (element.ValueKind == JsonValueKind.Object)
            {
                return DeserializeExpression<T>(element);
            }

            var obj = element.GetObject();
            if (obj is not null)
                value = (T)obj;
            return new DataFactoryExpression<T>(value);
        }

        private static DataFactoryExpression<T> DeserializeExpression<T>(JsonElement element)
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
            return DataFactoryExpression<T>.FromExpression(expression);
        }
    }
}
