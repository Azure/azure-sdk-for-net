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
    [JsonConverter(typeof(DataFactoryElementJsonConverter))]
    public sealed class DataFactoryElement<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly T? _literal;
        private readonly DataFactoryElementKind _kind;
        internal string? Expression { get; }

        /// <summary>
        /// Initializes a new instance of DataFactoryExpression with a literal value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public DataFactoryElement(T? literal) : this (literal, false)
        {
        }

        internal DataFactoryElement(T? literal, bool asSecureString)
        {
            _kind = asSecureString ? DataFactoryElementKind.SecureString : DataFactoryElementKind.Literal;
            _literal = literal;
        }

        /// <summary>
        ///
        /// </summary>
        public DataFactoryElementKind Kind => _kind;

        // /// <summary>
        // /// Gets whether this instance was constructed by a primitive value.
        // /// </summary>
        // public bool HasLiteral { get; }

        /// <summary>
        /// Gets the primitive value unless this instance is an expression.
        /// </summary>
        /// <exception cref="InvalidOperationException"> HasValue is false. </exception>
        public T? Literal
        {
            get
            {
                if (_kind == DataFactoryElementKind.Literal)
                    return _literal;
                throw new InvalidOperationException("Cannot get value from non-literal.");
            }
        }

        internal DataFactoryElement(string expression, DataFactoryElementKind kind)
        {
            _kind = kind;
            Expression = expression;
        }

        /// <inheritdoc/>
        public override string? ToString() => _kind == DataFactoryElementKind.Literal ? _literal?.ToString() : Expression;

        /// <summary>
        /// Converts a primitive value into a expression representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryElement<T>(T literal) => new DataFactoryElement<T>(literal);

        /// <summary>
        /// Creates a new instance of DataFactoryExpression using the expression value.
        /// </summary>
        /// <param name="expression"> The expression value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromExpression(string expression)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<T>(expression, DataFactoryElementKind.Expression);
        }

        /// <summary>
        /// Creates a new instance of DataFactoryExpression using the KeyVaultReference value.
        /// </summary>
        /// <param name="keyVaultReference"> The key vault reference value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromKeyVaultReference(string keyVaultReference)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<T>(keyVaultReference, DataFactoryElementKind.KeyVaultReference);
        }

        /// <summary>
        /// Creates a new instance of DataFactoryExpression using the literal value.
        /// </summary>
        /// <param name="literal"></param>
        /// <param name="asSecureString"></param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromLiteral(T literal, bool asSecureString)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            if (asSecureString)
            {
                var literalString = literal?.ToString() ?? string.Empty;
                var secureString = new string('*', literalString.Length);
                return new DataFactoryElement<T>(secureString, DataFactoryElementKind.SecureString);
            }
            return new DataFactoryElement<T>(literal);
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
