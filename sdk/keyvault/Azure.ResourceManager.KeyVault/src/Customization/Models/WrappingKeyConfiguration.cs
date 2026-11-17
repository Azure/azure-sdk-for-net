// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;
namespace Azure.ResourceManager.KeyVault.Models
{
    [CodeGenSuppress("WrappingKeyConfiguration", typeof(WrappingKeyValue), typeof(string))]
    public partial class WrappingKeyConfiguration
    {
        // The service only supports ServiceIdentity, so callers should not supply an ignored authentication type.
        /// <summary> Initializes a new instance of <see cref="WrappingKeyConfiguration"/>. </summary>
        /// <param name="keyValue"> Identifies the external wrapping key. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyValue"/> is null. </exception>
        public WrappingKeyConfiguration(WrappingKeyValue keyValue)
        {
            Argument.AssertNotNull(keyValue, nameof(keyValue));

            KeyValue = keyValue;
            KeyAuthenticationData = new WrappingKeyAuthenticationData();
        }
    }
}
