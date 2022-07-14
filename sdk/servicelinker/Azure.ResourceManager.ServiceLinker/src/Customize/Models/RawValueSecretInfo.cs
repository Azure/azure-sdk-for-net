// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary> The secret info when type is rawValue. It&apos;s for scenarios that user input the secret. </summary>
    [CodeGenSuppress("RawValueSecretInfo", typeof(LinkerSecretType), typeof(string))]
    public partial class RawValueSecretInfo : SecretBaseInfo
    {
        /// <summary> Initializes a new instance of RawValueSecretInfo. </summary>
        /// <param name="secretType"> The secret type. </param>
        /// <param name="value"> The actual value of the secret. </param>
        internal RawValueSecretInfo(LinkerSecretType secretType, string value)
        {
            Value = value;
            SecretType = secretType;
        }
    }
}
