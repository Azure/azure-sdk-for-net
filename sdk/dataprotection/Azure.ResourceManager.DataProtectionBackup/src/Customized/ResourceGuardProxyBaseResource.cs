// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataProtectionBackup
{
    /// <summary>
    /// A Class representing a ResourceGuardProxyBaseResource along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="ResourceGuardProxyBaseResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetResourceGuardProxyBaseResource method.
    /// Otherwise you can get one from its parent resource <see cref="DataProtectionBackupVaultResource"/> using the GetResourceGuardProxyBaseResource method.
    /// </summary>
    public partial class ResourceGuardProxyBaseResource
    {
        /// <summary>
        /// UnlockDelete call for ResourceGuardProxy, executed before one can delete it
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupResourceGuardProxies/{resourceGuardProxyName}/unlockDelete</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DppResourceGuardProxy_UnlockDelete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResourceGuardProxyBaseResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request body for operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataProtectionUnlockDeleteResult>> UnlockDeleteAsync(DataProtectionUnlockDeleteContent content, CancellationToken cancellationToken)
        {
            return await UnlockDeleteAsync(content, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// UnlockDelete call for ResourceGuardProxy, executed before one can delete it
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/backupVaults/{vaultName}/backupResourceGuardProxies/{resourceGuardProxyName}/unlockDelete</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DppResourceGuardProxy_UnlockDelete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ResourceGuardProxyBaseResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request body for operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataProtectionUnlockDeleteResult> UnlockDelete(DataProtectionUnlockDeleteContent content, CancellationToken cancellationToken)
        {
            return UnlockDelete(content, null, cancellationToken);
        }
    }
}
