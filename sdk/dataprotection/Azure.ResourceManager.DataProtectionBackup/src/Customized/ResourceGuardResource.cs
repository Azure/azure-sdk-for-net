// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DataProtectionBackup.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup
{
    public partial class ResourceGuardResource
    {
        /// <summary>
        /// Backward compatibility overload using deprecated DataProtectionBackupPatch type.
        /// </summary>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use UpdateAsync(ResourceGuardPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ResourceGuardResource>> UpdateAsync(DataProtectionBackupPatch patch, CancellationToken cancellationToken = default)
        {
            ResourceGuardPatch input = new ResourceGuardPatch();
            foreach (var tag in patch.Tags)
            {
                input.Tags.Add(tag);
            }
            return await UpdateAsync(input, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Backward compatibility overload using deprecated DataProtectionBackupPatch type.
        /// </summary>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use Update(ResourceGuardPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ResourceGuardResource> Update(DataProtectionBackupPatch patch, CancellationToken cancellationToken = default)
        {
            ResourceGuardPatch input = new ResourceGuardPatch();
            foreach (var tag in patch.Tags)
            {
                input.Tags.Add(tag);
            }
            return Update(input, cancellationToken);
        }
    }
}