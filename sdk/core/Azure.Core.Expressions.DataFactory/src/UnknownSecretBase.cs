// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> The UnknownSecretBase. </summary>
    internal partial class UnknownSecretBase : DataFactorySecretBaseDefinition
    {
        /// <summary> Initializes a new instance of UnknownSecretBase. </summary>
        /// <param name="secretBaseType"> Type of the secret. </param>
        internal UnknownSecretBase(string? secretBaseType) : base(secretBaseType)
        {
            SecretBaseType = secretBaseType ?? "Unknown";
        }
    }
}
