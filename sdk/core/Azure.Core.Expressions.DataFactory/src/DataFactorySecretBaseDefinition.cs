// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// The base definition of a secret type.
    /// Please note <see cref="DataFactorySecretBaseDefinition"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DataFactorySecretString"/> and <see cref="DataFactoryKeyVaultSecretReference"/>.
    /// </summary>
    [PropertyReferenceType(new string[0], new[]{ nameof(SecretBaseType)})]
    public abstract partial class DataFactorySecretBaseDefinition
    {
        /// <summary> Initializes a new instance of DataFactorySecretBaseDefinition. </summary>
        [InitializationConstructor]
        protected DataFactorySecretBaseDefinition()
        {
        }

        /// <summary> Initializes a new instance of DataFactorySecretBaseDefinition. </summary>
        /// <param name="secretBaseType"> Type of the secret. </param>
        [SerializationConstructor]
        internal DataFactorySecretBaseDefinition(string? secretBaseType)
        {
            SecretBaseType = secretBaseType;
        }

        /// <summary> Type of the secret. </summary>
        internal string? SecretBaseType { get; set; }
    }
}
