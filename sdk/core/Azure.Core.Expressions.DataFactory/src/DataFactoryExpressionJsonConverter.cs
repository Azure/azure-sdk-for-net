// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    internal class DataFactoryExpressionJsonConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return (typeToConvert == typeof(DataFactoryExpression<string>) ||
                typeToConvert == typeof(DataFactoryExpression<int>) ||
                typeToConvert == typeof(DataFactoryExpression<double>) ||
                typeToConvert == typeof(DataFactoryExpression<Array>) ||
                typeToConvert == typeof(DataFactoryExpression<bool>));
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            if (typeToConvert == typeof(DataFactoryExpression<string>))
                return DataFactoryExpression<string>.DeserializeDataFactoryExpression(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<int>))
                return DataFactoryExpression<int>.DeserializeDataFactoryExpression(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<double>))
                return DataFactoryExpression<double>.DeserializeDataFactoryExpression(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<Array>))
                return DataFactoryExpression<Array>.DeserializeDataFactoryExpression(document.RootElement);
            if (typeToConvert == typeof(DataFactoryExpression<bool>))
                return DataFactoryExpression<bool>.DeserializeDataFactoryExpression(document.RootElement);
            throw new InvalidOperationException($"Unable to convert {typeToConvert.Name} into a DataFactoryExpression<T>");
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            writer.WriteObjectValue(value);
        }
    }
}
