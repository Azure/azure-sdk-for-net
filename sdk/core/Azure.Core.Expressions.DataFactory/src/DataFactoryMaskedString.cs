// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// Represents a value that will be masked with asterisks when it is returned from the service.
    /// </summary>
    public class DataFactoryMaskedString
    {
        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            Value = value;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(int value)
        {
            Value = value.ToString();
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(bool value)
        {
            Value = value.ToString();
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(double value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(TimeSpan value)
        {
            Value = value.ToString();
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(DateTimeOffset value)
        {
            Value = value.ToString();
        }

        /// <summary>
        /// Constructs a new instance of <see cref="DataFactoryMaskedString"/>.
        /// </summary>
        /// <param name="value">The unmasked value of the secure string.</param>
        public DataFactoryMaskedString(Uri value)
        {
            Argument.AssertNotNull(value, nameof(value));
            Value = value.AbsoluteUri;
        }

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>

        public static implicit operator DataFactoryMaskedString(string literal) => new DataFactoryMaskedString(literal);
        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryMaskedString(int literal) => new DataFactoryMaskedString(literal);

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryMaskedString(bool literal) => new DataFactoryMaskedString(literal);

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryMaskedString(double literal) => new DataFactoryMaskedString(literal);

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryMaskedString(TimeSpan literal) => new DataFactoryMaskedString(literal);

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryMaskedString(DateTimeOffset literal) => new DataFactoryMaskedString(literal);

        /// <summary>
        /// Converts a literal value into a <see cref="DataFactoryMaskedString"/> representing that value.
        /// </summary>
        /// <param name="literal"> The literal value. </param>
        public static implicit operator DataFactoryMaskedString(Uri literal) => new DataFactoryMaskedString(literal);

        /// <summary>
        /// Gets the string value of the secure string. This will be masked with asterisks for output types.
        /// </summary>
        public string Value { get; }
    }
}