// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> The UnknownSecretBase. </summary>
    internal partial class UnknownSecret : DataFactorySecret
    {
        /// <summary> Initializes a new instance of UnknownSecret. </summary>
        internal UnknownSecret()
        {
        }
        /// <summary> Initializes a new instance of UnknownSecretBase. </summary>
        /// <param name="secretBaseType"> Type of the secret. </param>
        internal UnknownSecret(string? secretBaseType) : base(secretBaseType)
        {
            SecretBaseType = secretBaseType ?? "Unknown";
        }
    }
}
