// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    internal class DataFactoryExpressionJsonConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DataFactoryExpression<string>) ||
                    typeToConvert == typeof(DataFactoryExpression<int>) ||
                    typeToConvert == typeof(DataFactoryExpression<double>) ||
                    typeToConvert == typeof(DataFactoryExpression<Array>) ||
                    typeToConvert == typeof(DataFactoryExpression<bool>) ||
                   IsGenericDataFactoryList(typeToConvert);
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            if (typeToConvert == typeof(DataFactoryExpression<string>))
                return Deserialize<string>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<int>))
                return Deserialize<int>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<double>))
                return Deserialize<double>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<Array>))
                return Deserialize<Array>(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<bool>))
                return Deserialize<bool>(document.RootElement);
            if (IsGenericDataFactoryList(typeToConvert))
            {
                var methodInfo = typeof(DataFactoryExpressionJsonConverter)
                    .GetMethod(
                        "DeserializeList",
                        BindingFlags.Static | BindingFlags.NonPublic)!
                    .MakeGenericMethod(typeToConvert.GenericTypeArguments[0].GenericTypeArguments[0]);
                return methodInfo!.Invoke(null, new object[] { document.RootElement })!;
            }
            throw new InvalidOperationException($"Unable to convert {typeToConvert.Name} into a DataFactoryExpression<T>");
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is DataFactoryExpression<string> stringExpression)
                Serialize(writer, stringExpression);
            else if (value is DataFactoryExpression<int> intExpression)
                Serialize(writer, intExpression);
            else if (value is DataFactoryExpression<double> doubleExpression)
                Serialize(writer, doubleExpression);
            else if (value is DataFactoryExpression<Array> arrayExpression)
                Serialize(writer, arrayExpression);
            else if (value is DataFactoryExpression<bool> boolExpression)
                Serialize(writer, boolExpression);
            else if (IsGenericDataFactoryList(value.GetType()))
            {
                var methodInfo = typeof(DataFactoryExpressionJsonConverter)
                    .GetMethod(
                        "SerializeList",
                        BindingFlags.Static | BindingFlags.NonPublic)!
                    .MakeGenericMethod(value.GetType().GenericTypeArguments[0].GenericTypeArguments[0]);
                methodInfo!.Invoke(null, new object[] { writer, value });
            }
            else
            {
                throw new InvalidOperationException($"Unable to convert {value.GetType().Name} into a DataFactoryExpression<T>");
            }
        }

        private static bool IsGenericDataFactoryList(Type type)
        {
            return type.IsGenericType &&
                   type.GetGenericTypeDefinition() == typeof(DataFactoryExpression<>) &&
                   type.GenericTypeArguments[0].IsGenericType &&
                   type.GenericTypeArguments[0].GetGenericTypeDefinition() == typeof(List<>) &&
                   type.GenericTypeArguments[0].GenericTypeArguments[0].GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
        }

        internal static void Serialize<T>(Utf8JsonWriter writer, DataFactoryExpression<T> expression)
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

        internal static void SerializeList<T>(Utf8JsonWriter writer, DataFactoryExpression<List<T>> expression)
        {
            if (expression.HasLiteral)
            {
                writer.WriteStartArray();
                foreach (T? elem in expression.LiteralInternal!)
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

        internal static DataFactoryExpression<List<T>> DeserializeList<T>(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                var list = new List<T>();
                foreach (var item in element.EnumerateArray())
                {
                    list.Add(JsonSerializer.Deserialize<T>(item.ToString()!)!);
                }

                return new DataFactoryExpression<List<T>>(list);
            }

            throw new InvalidOperationException("Can only be called on an array");
        }

        internal static DataFactoryExpression<T> Deserialize<T>(JsonElement element)
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
                if (expression is null)
                    throw new InvalidOperationException("Missing required parameter 'value'");
                return DataFactoryExpression<T>.FromExpression(expression);
            }
            else
            {
                var obj = element.GetObject();
                if (obj is not null)
                    value = (T)obj;
                return new DataFactoryExpression<T>(value);
            }
        }
    }
}
