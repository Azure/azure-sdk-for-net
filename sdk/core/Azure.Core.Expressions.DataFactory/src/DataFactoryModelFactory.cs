// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// Model factory to construct types for mocking.
    /// </summary>
    public static class DataFactoryModelFactory
    {
        /// <summary>
        /// Constructs a <see cref="DataFactorySecretString"/> for mocking.
        /// </summary>
        /// <param name="value">The secret string value.</param>
        /// <returns>The constructed <see cref="DataFactorySecretString"/>.</returns>
        public static DataFactorySecretString DataFactorySecretString(string value) =>
            new DataFactorySecretString(value);

        /// <summary>
        /// Constructs a <see cref="DataFactoryKeyVaultSecretReference"/> for mocking.
        /// </summary>
        /// <param name="store">The linked store.</param>
        /// <param name="secretName">The secret name.</param>
        /// <param name="secretVersion">The secret version.</param>
        /// <returns>The constructed <see cref="DataFactoryKeyVaultSecretReference"/>.</returns>
        public static DataFactoryKeyVaultSecretReference DataFactoryKeyVaultSecretReference(
            DataFactoryLinkedServiceReference store,
            DataFactoryElement<string> secretName,
            DataFactoryElement<string> secretVersion) =>
            new DataFactoryKeyVaultSecretReference(store, secretName) { SecretVersion = secretVersion };

        /// <summary>
        /// Constructs a <see cref="DataFactorySecretBaseDefinition"/> for mocking.
        /// </summary>
        /// <param name="secretBaseType">The secret base type.</param>
        /// <returns>The constructed <see cref="DataFactorySecretBaseDefinition"/>.</returns>
        public static DataFactorySecretBaseDefinition DataFactorySecretBaseDefinition(string secretBaseType) =>
            new UnknownSecretBase(secretBaseType);

        /// <summary>
        /// Constructs a <see cref="DataFactoryLinkedServiceReference"/> for mocking.
        /// </summary>
        /// <param name="referenceType">The reference type.</param>
        /// <param name="referenceName">The reference name.</param>
        /// <param name="parameters">The reference parameters.</param>
        /// <returns>The constructed <see cref="DataFactoryLinkedServiceReference"/>.</returns>
        public static DataFactoryLinkedServiceReference DataFactoryLinkedServiceReference(
            DataFactoryLinkedServiceReferenceType referenceType,
            string? referenceName,
            IDictionary<string, BinaryData?> parameters) =>
            new DataFactoryLinkedServiceReference(referenceType, referenceName, parameters);
    }
}