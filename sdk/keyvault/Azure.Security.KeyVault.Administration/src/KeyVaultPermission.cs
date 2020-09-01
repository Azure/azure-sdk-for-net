// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <inheritdoc/>
    public partial class KeyVaultPermission
    {
        /// <inheritdoc/>
        public IList<string> Actions { get; }
        /// <inheritdoc/>
        public IList<string> NotActions { get; }
        /// <inheritdoc/>
        public IList<string> DataActions { get; }
        /// <inheritdoc/>
        public IList<string> NotDataActions { get; }
    }
}
