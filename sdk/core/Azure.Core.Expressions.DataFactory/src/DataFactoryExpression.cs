// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// A class representing either a primitive value or an expression.
    /// For details on DataFactoryExpressions see https://learn.microsoft.com/en-us/azure/data-factory/control-flow-expression-language-functions#expressions.
    /// </summary>
    /// <typeparam name="T"> Can be one of <see cref="string"/>, <see cref="bool"/>, <see cref="int"/>, <see cref="double"/>, <see cref="TimeSpan"/>,
    /// <see cref="DateTimeOffset"/>, <see cref="Uri"/>, <see cref="IList{String}"/>, <see cref="IList{TElement}"/> where TElement has a <see cref="JsonConverter"/> defined,
    /// or <see cref="IDictionary{String,String}"/>.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    [JsonConverter(typeof(DataFactoryExpressionJsonConverter))]
    public sealed class DataFactoryExpression<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        internal string? Type { get; }
        private readonly T? _literal;
        internal string? Expression { get; }

        /// <summary>
        /// Initializes a new instance of DataFactoryExpression with a literal value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public DataFactoryExpression(T? literal)
        {
            HasLiteral = true;
            _literal = literal;
        }

        /// <summary>
        /// Gets whether this instance was constructed by a primitive value.
        /// </summary>
        public bool HasLiteral { get; }

        /// <summary>
        /// Gets the primitive value unless this instance is an expression.
        /// </summary>
        /// <exception cref="InvalidOperationException"> HasValue is false. </exception>
        public T? Literal
        {
            get
            {
                if (HasLiteral)
                    return _literal;
                throw new InvalidOperationException("Cannot get value from Expression.");
            }
        }

        internal DataFactoryExpression(string expression, string type)
        {
            Type = type;
            Expression = expression;
        }

        /// <inheritdoc/>
        public override string? ToString() => HasLiteral ? _literal?.ToString() : Expression;

        /// <summary>
        /// Converts a primitive value into a expression representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryExpression<T>(T literal) => new DataFactoryExpression<T>(literal);

        /// <summary>
        /// Creates a new instance of DataFactoryExpression using the expression value.
        /// </summary>
        /// <param name="expression"> The expresion value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryExpression<T> FromExpression(string expression)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryExpression<T>(expression, "Expression");
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
