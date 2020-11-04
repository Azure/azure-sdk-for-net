// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <inheritdoc/>
    [CodeGenModel("Permission", Usage = new[] { "input", "output" })]
    public partial class KeyVaultPermission
    {

        /// <summary> Denied actions. </summary>
        [CodeGenMember("NotActions")]
        public IList<string> DenyActions { get; }

        /// <summary> Denied Data actions. </summary>
        [CodeGenMember("NotDataActions")]
        public IList<string> DenyDataActions { get; }
    }
}
