// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// A class representing either a literal value, a masked literal value (also known as a SecureString), an expression, or a Key Vault reference.
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
        internal string? StringValue { get; }

        internal DataFactoryElement(T? literal)
        {
            _kind = DataFactoryElementKind.Literal;
            _literal = literal;
        }

        /// <summary>
        /// Gets the kind of the element.
        /// </summary>
        public DataFactoryElementKind Kind => _kind;

        /// <summary>
        /// Gets the literal value if the element has a <see cref="Kind"/> of <see cref="DataFactoryElementKind.Literal"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"> <see cref="Kind"/> is not <see cref="DataFactoryElementKind.Literal"/>.</exception>
        public T? Literal
        {
            get
            {
                if (_kind == DataFactoryElementKind.Literal)
                    return _literal;
                throw new InvalidOperationException("Cannot get value from non-literal.");
            }
        }

        internal DataFactoryElement(string stringValue, DataFactoryElementKind kind)
        {
            _kind = kind;
            StringValue = stringValue;
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return _kind == DataFactoryElementKind.Literal ? _literal?.ToString() : StringValue;
        }

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryElement{T}"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryElement<T>(T literal) => new DataFactoryElement<T>(literal);

        /// <summary>
        /// Creates a new instance of <see cref="DataFactoryElement{T}"/> using the expression value.
        /// </summary>
        /// <param name="expression"> The expression value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromExpression(string expression)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<T>(expression, DataFactoryElementKind.Expression);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataFactoryElement{T}"/> using the KeyVaultSecretReference value.
        /// </summary>
        /// <param name="keyVaultSecretReference"> The key vault secret reference value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromKeyVaultSecretReference(string keyVaultSecretReference)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<T>(keyVaultSecretReference, DataFactoryElementKind.KeyVaultSecretReference);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataFactoryElement{T}"/> using the literal value.
        /// </summary>
        /// <param name="literal">The literal value.</param>
        /// <param name="asSecureString">Whether to create the element as a secure string. If set to <value>true</value>, the value
        /// will be masked with asterisks when subsequently retrieved from the service. By default, this is <value>false</value>. The value will
        /// NOT be masked when calling <see cref="ToString"/> after creating the element from a literal.</param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromLiteral(T? literal, bool asSecureString = false)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            if (asSecureString)
            {
                var literalString = literal?.ToString() ?? string.Empty;
                return new DataFactoryElement<T>(literalString, DataFactoryElementKind.SecureString);
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
