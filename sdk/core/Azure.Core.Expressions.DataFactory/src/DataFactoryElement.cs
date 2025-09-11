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
#pragma warning disable SCM0005 // Type must have a parameterless constructor
    [JsonConverter(typeof(DataFactoryElementJsonConverter))]
    public sealed partial class DataFactoryElement<T>
#pragma warning disable SCM0005 // Type must have a parameterless constructor
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly T? _literal;
        private readonly DataFactoryElementKind _kind;
        internal DataFactorySecret? Secret { get; }
        internal string? ExpressionString { get; }

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

        internal DataFactoryElement(string? expressionString, DataFactoryElementKind kind)
        {
            _kind = kind;
            ExpressionString = expressionString;
        }

        internal DataFactoryElement(DataFactorySecret secret, DataFactoryElementKind kind)
        {
            _kind = kind;
            Secret = secret;
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            if (_kind == DataFactoryElementKind.Literal)
            {
                return _literal?.ToString();
            }
            if (_kind == DataFactoryElementKind.SecretString)
            {
                return ((DataFactorySecretString)Secret!).Value;
            }
            if (_kind == DataFactoryElementKind.KeyVaultSecret)
            {
                // TODO should this include the version and the Reference name?
                return ((DataFactoryKeyVaultSecret)Secret!).SecretName.ToString();
            }

            return ExpressionString;
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
        /// <param name="secret"> The key vault secret reference value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<string?> FromKeyVaultSecret(DataFactoryKeyVaultSecret secret)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<string?>(secret, DataFactoryElementKind.KeyVaultSecret);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataFactoryElement{T}"/> using the KeyVaultSecretReference value.
        /// </summary>
        /// <param name="secretString"> The unmasked string value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<string?> FromSecretString(DataFactorySecretString secretString)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<string?>(secretString, DataFactoryElementKind.SecretString);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataFactoryElement{T}"/> using the KeyVaultSecretReference value.
        /// </summary>
        /// <param name="secret"> The unmasked string value. </param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        internal static DataFactoryElement<T?> FromSecretBase(DataFactorySecret secret)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new DataFactoryElement<T?>(secret, new DataFactoryElementKind(secret.SecretBaseType!));
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataFactoryElement{T}"/> using the literal value.
        /// </summary>
        /// <param name="literal">The literal value.</param>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static DataFactoryElement<T> FromLiteral(T? literal)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
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
