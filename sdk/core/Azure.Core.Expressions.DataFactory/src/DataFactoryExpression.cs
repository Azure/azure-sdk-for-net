// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Linq;
using System.Security;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// A class representing either a primitive value or an expression.
    /// For details on DataFactoryExpressions see https://learn.microsoft.com/en-us/azure/data-factory/control-flow-expression-language-functions#expressions.
    /// </summary>
    /// <typeparam name="T"> Can be one of <see cref="string"/>, <see cref="bool"/>, <see cref="int"/>, <see cref="double"/>, <see cref="Array"/>, <see cref="SecureString"/>. </typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public sealed partial class DataFactoryExpression<T> : IUtf8JsonSerializable
#pragma warning restore SA1649 // File name should match first type name
    {
        private string? _type;
        private T? _literal;
        private string? _expression;

        /// <summary>
        /// Initializes a new instance of DataFactoryExpression with a literal value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public DataFactoryExpression(T literal)
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

        internal DataFactoryExpression(Optional<T> literal, string? expression)
        {
            if (literal.HasValue)
            {
                HasLiteral = true;
                _literal = literal.Value;
            }
            else
            {
                _type = "Expression";
                _expression = expression;
            }
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            if (HasLiteral)
            {
                if (_literal is Array literalArray)
                {
                    return $"[{string.Join(",", literalArray.OfType<object>().Select(item => item?.ToString()))}]";
                }
                else
                {
                    return _literal?.ToString();
                }
            }
            return _expression!;
        }

        /// <summary>
        /// Converts a primitive value into a expression representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryExpression<T>(T literal) => new DataFactoryExpression<T>(literal, null);

        /// <summary>
        /// Creates a new instance of DataFactoryExpression using the expression value.
        /// </summary>
        /// <param name="expression"> The expresion value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryExpression<T> FromExpression(string expression)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            Optional<T> literal = default;
            return new DataFactoryExpression<T>(literal, expression);
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
