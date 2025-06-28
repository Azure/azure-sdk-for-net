// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Security.KeyVault.Administration.Models
{
    [CodeGenType("KeyVaultErrorError")]
    internal partial class KeyVaultServiceError
    {
        internal KeyVaultServiceError(string code, string message, KeyVaultServiceError innerError)
        {
            Code = code;
            Message = message;
            InnerError = innerError;
        }
    }
}
