// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> The UnknownSecretBase. </summary>
#pragma warning disable SCM0005 // Type must have a parameterless constructor
    internal partial class UnknownSecret : DataFactorySecret
#pragma warning restore SCM0005 // Type must have a parameterless constructor
    {
        /// <summary> Initializes a new instance of UnknownSecretBase. </summary>
        /// <param name="secretBaseType"> Type of the secret. </param>
        internal UnknownSecret(string? secretBaseType) : base(secretBaseType)
        {
            SecretBaseType = secretBaseType ?? "Unknown";
        }
    }
}
