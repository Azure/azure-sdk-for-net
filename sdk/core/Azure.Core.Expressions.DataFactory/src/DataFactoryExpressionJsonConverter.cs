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
                   IsGenericDataFactoryList(typeToConvert);
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
            if (IsGenericDataFactoryList(typeToConvert))
            {
                string methodName = typeToConvert.GenericTypeArguments[0].GetGenericTypeDefinition() == typeof(IList<>)
                    ? nameof(DeserializeList)
                    : nameof(DeserializeReadOnlyList);
                var methodInfo = GetGenericSerializationMethod(typeToConvert, methodName);
                return methodInfo!.Invoke(null, new object[] { document.RootElement })!;
            }

            throw new InvalidOperationException($"Unable to convert {typeToConvert.Name} into a DataFactoryExpression<T>");
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            if (value is null)
                writer.WriteNullValue();
            else if (value is DataFactoryExpression<string?> stringExpression)
                Serialize(writer, stringExpression);
            else if (value is DataFactoryExpression<int> intExpression)
                Serialize(writer, intExpression);
            else if (value is DataFactoryExpression<int?> nullableIntExpression)
                Serialize(writer, nullableIntExpression);
            else if (value is DataFactoryExpression<double> doubleExpression)
                Serialize(writer, doubleExpression);
            else if (value is DataFactoryExpression<double?> nullableDoubleExpression)
                Serialize(writer, nullableDoubleExpression);
            else if (value is DataFactoryExpression<Array?> arrayExpression)
                Serialize(writer, arrayExpression);
            else if (value is DataFactoryExpression<bool> boolExpression)
                Serialize(writer, boolExpression);
            else if (value is DataFactoryExpression<bool?> nullableBoolExpression)
                Serialize(writer, nullableBoolExpression);
            else
            {
                Type typeToConvert = value.GetType();
                if (IsGenericDataFactoryList(typeToConvert))
                {
                    string methodName = typeToConvert.GenericTypeArguments[0].GetGenericTypeDefinition() == typeof(IList<>)
                        ? nameof(SerializeList)
                        : nameof(SerializeReadOnlyList);
                    var methodInfo = GetGenericSerializationMethod(typeToConvert, methodName);
                    methodInfo!.Invoke(null, new object[] { writer, value });
                }
                else
                {
                    throw new InvalidOperationException($"Unable to convert {value.GetType().Name} into a DataFactoryExpression<T>");
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

        private static bool IsGenericDataFactoryList(Type type)
        {
            return type.IsGenericType &&
                   type.GetGenericTypeDefinition() == typeof(DataFactoryExpression<>) &&
                   type.GenericTypeArguments[0].IsGenericType &&
                   IsGenericListType(type.GenericTypeArguments[0].GetGenericTypeDefinition()) &&
                   type.GenericTypeArguments[0].GenericTypeArguments[0].GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
        }

        private static bool IsGenericListType(Type type) => type == typeof(IList<>) || type == typeof(IReadOnlyList<>);

        private static void Serialize<T>(Utf8JsonWriter writer, DataFactoryExpression<T?> expression)
        {
            if (expression.HasLiteral)
            {
                writer.WriteObjectValue(expression.LiteralInternal!);
            }
            else
            {
                SerializeExpression(writer, expression.Type!, expression.Expression!);
            }
        }

        private static void SerializeList<T>(Utf8JsonWriter writer, DataFactoryExpression<IList<T?>> expression)
        {
            if (expression.HasLiteral && expression.Literal == null)
            {
                writer.WriteNullValue();
                return;
            }
            if (expression.HasLiteral)
            {
                SerializeListCore(writer, expression.Literal!.AsEnumerable());
            }
            else
            {
                SerializeExpression(writer, expression.Type!, expression.Expression!);
            }
        }

        private static void SerializeReadOnlyList<T>(Utf8JsonWriter writer, DataFactoryExpression<IReadOnlyList<T?>> expression)
        {
            if (expression.HasLiteral && expression.Literal == null)
            {
                writer.WriteNullValue();
                return;
            }
            if (expression.HasLiteral)
            {
                SerializeListCore(writer, expression.Literal!.AsEnumerable());
            }
            else
            {
                SerializeExpression(writer, expression.Type!, expression.Expression!);
            }
        }

        private static void SerializeListCore<T>(Utf8JsonWriter writer, IEnumerable<T> enumerable)
        {
            writer.WriteStartArray();
            foreach (T? elem in enumerable)
            {
                JsonSerializer.Serialize(writer, elem);
            }
            writer.WriteEndArray();
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
                var list = new ChangeTrackingList<T?>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<T>(item.ToString()!));
                }

                return new DataFactoryExpression<IList<T?>>(list);
            }

            throw new InvalidOperationException($"Cannot deserialize an {element.ValueKind} as a list.");
        }

        private static DataFactoryExpression<IReadOnlyList<T?>> DeserializeReadOnlyList<T>(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                var list = new ChangeTrackingList<T?>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(item.ValueKind == JsonValueKind.Null ? default : JsonSerializer.Deserialize<T>(item.ToString()!));
                }

                return new DataFactoryExpression<IReadOnlyList<T?>>(list);
            }

            throw new InvalidOperationException($"Cannot deserialize an {element.ValueKind} as a list.");
        }

        internal static DataFactoryExpression<T>? Deserialize<T>(JsonElement element)
        {
            string? expression = default;
            Optional<T> value = default;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("value"))
                    {
                        expression = property.Value.GetString();
                    }
                }
                if (expression is null)
                    throw new InvalidOperationException("Missing required parameter 'value'");
                return DataFactoryExpression<T>.FromExpression(expression);
            }

            var obj = element.GetObject();
            if (obj is not null)
                value = (T)obj;
            return new DataFactoryExpression<T>(value);
        }
    }
}
