// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// The base definition of a secret type.
    /// Please note <see cref="DataFactorySecret"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DataFactorySecretString"/> and <see cref="DataFactoryKeyVaultSecret"/>.
    /// </summary>
    [PropertyReferenceType(new string[0], new[]{ nameof(SecretBaseType)})]
#pragma warning disable SCM0004 // Abstract type must have a PersistableModelProxy defined
    public abstract partial class DataFactorySecret
#pragma warning restore SCM0004 // Abstract type must have a PersistableModelProxy defined
    {
        /// <summary> Initializes a new instance of DataFactorySecretBaseDefinition. </summary>
        [InitializationConstructor]
        protected DataFactorySecret()
        {
        }

        /// <summary> Initializes a new instance of DataFactorySecretBaseDefinition. </summary>
        /// <param name="secretBaseType"> Type of the secret. </param>
        [SerializationConstructor]
        internal DataFactorySecret(string? secretBaseType)
        {
            SecretBaseType = secretBaseType;
        }

        /// <summary> Type of the secret. </summary>
        internal string? SecretBaseType { get; set; }
    }
}
