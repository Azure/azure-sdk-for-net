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
    public partial class ResourceGuardProxyBaseResource
    {
        /// <summary>
        /// Backward compatibility overload without xMsAuthorizationAuxiliary parameter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataProtectionUnlockDeleteResult>> UnlockDeleteAsync(DataProtectionUnlockDeleteContent content, CancellationToken cancellationToken)
            => await UnlockDeleteAsync(content, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Backward compatibility overload without xMsAuthorizationAuxiliary parameter.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataProtectionUnlockDeleteResult> UnlockDelete(DataProtectionUnlockDeleteContent content, CancellationToken cancellationToken)
            => UnlockDelete(content, null, cancellationToken);
    }
}