// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Security.KeyVault.Administration.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary> A long-running operation on an External Key Manager (EKM) proxy private endpoint. </summary>
    [CodeGenType("EkmPrivateEndpointOperation")]
    public partial class KeyVaultEkmPrivateEndpointOperation
    {
        /// <summary> Error encountered, if any, during the operation. </summary>
        [CodeGenMember("Error")]
        internal KeyVaultServiceError Error { get; }

        /// <summary> The code of the error encountered, if any, during the operation. </summary>
        public string ErrorCode => Error?.Code;

        /// <summary> The message of the error encountered, if any, during the operation. </summary>
        public string ErrorMessage => Error?.Message;
    }
}
