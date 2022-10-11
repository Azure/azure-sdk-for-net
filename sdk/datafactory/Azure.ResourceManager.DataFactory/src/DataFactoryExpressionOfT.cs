// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// A class representing either a primitive value or an expression.
    /// For details on DataFactoryExpressions see https://learn.microsoft.com/en-us/azure/data-factory/control-flow-expression-language-functions#expressions.
    /// </summary>
    /// <typeparam name="T"> Can be one of <see cref="string"/>, <see cref="bool"/>, <see cref="int"/>, <see cref="float"/>, <see cref="List{T}"/>. </typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public class DataFactoryExpression<T> : IUtf8JsonSerializable
#pragma warning restore SA1649 // File name should match first type name
    {
        private string _type;
        private T _value;
        private string _expression;

        /// <summary>
        /// Gets whether this instance was constructed by a primitive value.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Gets the primitive value unless this instance is an expression.
        /// </summary>
        /// <exception cref="InvalidOperationException"> HasValue is false. </exception>
        public T Value
        {
            get
            {
                if (HasValue)
                    return _value;
                throw new InvalidOperationException("Cannot get value from Expression.");
            }
        }

        internal DataFactoryExpression(Optional<T> value, string expression)
        {
            if (value.HasValue)
            {
                HasValue = true;
                _value = value.Value;
            }
            else
            {
                _type = "Expression";
                _expression = expression;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (HasValue)
                return _value.ToString();
            return _expression;
        }

        /// <summary>
        /// Converts a primitive value into a expression representing that value.
        /// </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator DataFactoryExpression<T>(T value) => new DataFactoryExpression<T>(value, null);

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (HasValue)
            {
                writer.WriteObjectValue(_value);
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

        internal static DataFactoryExpression<T> DeserializeActivityDependency(JsonElement element)
        {
            string expression = default;
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
                return new DataFactoryExpression<T>((T)element.GetObject(), null);
            }
        }
    }
}
