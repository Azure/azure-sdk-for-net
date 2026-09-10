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
        /// <summary> Generates and returns a public/private key pair and populates the SSH public key resource with the public key. The length of the key will be 3072 bits. This operation can only be performed once per SSH public key resource. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}/generateKeyPair. </description> </item> <item> <term> Operation Id. </term> <description> SshPublicKeyResources_GenerateKeyPair. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="SshPublicKeyResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(CancellationToken cancellationToken)
            => await GenerateKeyPairAsync(null, cancellationToken).ConfigureAwait(false);

        /// <summary> Generates and returns a public/private key pair and populates the SSH public key resource with the public key. The length of the key will be 3072 bits. This operation can only be performed once per SSH public key resource. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}/generateKeyPair. </description> </item> <item> <term> Operation Id. </term> <description> SshPublicKeyResources_GenerateKeyPair. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="SshPublicKeyResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(CancellationToken cancellationToken)
            => GenerateKeyPair(null, cancellationToken);
    }
}
