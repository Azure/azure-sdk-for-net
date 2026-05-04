// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public partial class SshPublicKeyResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(CancellationToken cancellationToken)
            => await GenerateKeyPairAsync(null, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(CancellationToken cancellationToken)
            => GenerateKeyPair(null, cancellationToken);
    }
}
