// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T"></typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public class DataFactoryExpression<T> : IUtf8JsonSerializable
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// .
        /// </summary>
        internal string Type { get; }

        /// <summary>
        /// .
        /// </summary>
        internal bool HasValue { get; }

        /// <summary>
        /// .
        /// </summary>
        internal T Value { get; }

        /// <summary>
        /// .
        /// </summary>
        internal string Expression { get; }

        /// <summary>
        /// .
        /// </summary>
        protected DataFactoryExpression() { }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="value"></param>
        public DataFactoryExpression(T value)
        {
            Value = value;
            HasValue = true;
            Expression = value.ToString();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="expression"></param>
        public DataFactoryExpression(string expression)
        {
            if (!expression.Contains("@"))
            {
                Value = (T)(object)expression;
                HasValue = true;
                Expression = expression;
            }
            else
            {
                Type = "Expression";
                Expression = expression;
            }
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            if (HasValue)
                return Value.ToString();
            return Expression;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns></returns>
        public string GetString() => ToString();

        /// <summary>
        /// .
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool TryGetValue(out T value)
        {
            value = default;
            if (HasValue)
            {
                value = Value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator DataFactoryExpression<T>(T value) => new DataFactoryExpression<T>(value);

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (HasValue)
            {
                writer.WriteObjectValue(Value);
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
                writer.WritePropertyName("value");
                writer.WriteStringValue(Expression);
                writer.WriteEndObject();
            }
        }

        internal static DataFactoryExpression<T> DeserializeActivityDependency(JsonElement element)
        {
            string expression = default;

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
                return new DataFactoryExpression<T>(expression);
            }
            else
            {
                return new DataFactoryExpression<T>((T)element.GetObject());
            }
        }
    }
}
