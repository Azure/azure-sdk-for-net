// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    ///
    /// </summary>
    public static class DataFactoryModelFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataFactorySecretString DataFactorySecretString(string value) =>
            new DataFactorySecretString(value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="store"></param>
        /// <param name="secretName"></param>
        /// <param name="secretVersion"></param>
        /// <returns></returns>
        public static DataFactoryKeyVaultSecretReference DataFactoryKeyVaultSecretReference(
            DataFactoryLinkedServiceReference store,
            DataFactoryElement<string> secretName,
            DataFactoryElement<string> secretVersion) =>
            new DataFactoryKeyVaultSecretReference(store, secretName) { SecretVersion = secretVersion };

        /// <summary>
        ///
        /// </summary>
        /// <param name="secretBaseType"></param>
        /// <returns></returns>
        public static DataFactorySecretBaseDefinition DataFactorySecretBaseDefinition(string secretBaseType) =>
            new UnknownSecretBase(secretBaseType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="referenceType"></param>
        /// <param name="referenceName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataFactoryLinkedServiceReference DataFactoryLinkedServiceReference(
            DataFactoryLinkedServiceReferenceType referenceType,
            string? referenceName,
            IDictionary<string, BinaryData?> parameters) =>
            new DataFactoryLinkedServiceReference(referenceType, referenceName, parameters);
    }
}