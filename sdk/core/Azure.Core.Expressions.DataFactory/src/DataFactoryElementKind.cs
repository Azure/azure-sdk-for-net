﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// Represents the kind of data factory element.
    /// </summary>
    public readonly struct DataFactoryElementKind : IEquatable<DataFactoryElementKind>
    {
        private readonly string _kind;

        /// <summary>
        /// A literal element.
        /// </summary>
        public static DataFactoryElementKind Literal { get; } = new DataFactoryElementKind("Literal");

        /// <summary>
        /// An expression element.
        /// </summary>
        public static DataFactoryElementKind Expression { get; } = new DataFactoryElementKind("Expression");

        /// <summary>
        /// A Secret string element.
        /// </summary>
        public static DataFactoryElementKind SecretString { get; } = new DataFactoryElementKind("SecureString");

        /// <summary>
        /// A KeyVaultSecretReference element.
        /// </summary>
        public static DataFactoryElementKind KeyVaultSecretReference { get; } = new DataFactoryElementKind("AzureKeyVaultSecret");

        /// <summary>
        /// Creates an instance of <see cref="DataFactoryElementKind"/>.
        /// </summary>
        /// <param name="kind">The element kind.</param>
        public DataFactoryElementKind(string kind)
        {
            Argument.AssertNotNull(kind, nameof(kind));

            _kind = kind;
        }

        /// <inheritdoc />
        public bool Equals(DataFactoryElementKind other)
        {
            return string.Equals(_kind, other._kind, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
            => (obj is DataFactoryElementKind other && Equals(other)) ||
               (obj is string str && str.Equals(_kind, StringComparison.Ordinal));

        /// <inheritdoc />
        public override int GetHashCode()
            => _kind?.GetHashCode() ?? 0;

        /// <summary>
        /// Compares equality of two <see cref="DataFactoryElementKind"/> instances.
        /// </summary>
        /// <param name="left">The kind to compare.</param>
        /// <param name="right">The kind to compare against.</param>
        /// <returns><c>true</c> if <see cref="DataFactoryElementKind"/> values are equal for <paramref name="left"/> and <paramref name="right"/>, otherwise <c>false</c>.</returns>
        public static bool operator ==(DataFactoryElementKind left, DataFactoryElementKind right)
            => left.Equals(right);

        /// <summary>
        /// Compares inequality of two <see cref="DataFactoryElementKind"/> instances.
        /// </summary>
        /// <param name="left">The kind to compare.</param>
        /// <param name="right">The kind to compare against.</param>
        /// <returns><c>true</c> if <see cref="DataFactoryElementKind"/> values are equal for <paramref name="left"/> and <paramref name="right"/>, otherwise <c>false</c>.</returns>
        public static bool operator !=(DataFactoryElementKind left, DataFactoryElementKind right)
            => !left.Equals(right);

        /// <inheritdoc />
        public override string ToString() => _kind ?? "";
    }
}