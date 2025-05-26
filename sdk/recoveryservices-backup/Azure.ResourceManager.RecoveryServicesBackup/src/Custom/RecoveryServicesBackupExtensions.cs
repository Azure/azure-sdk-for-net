// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.RecoveryServicesBackup.Mocking;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public static partial class RecoveryServicesBackupExtensions
    {
        /// <summary>
        /// Get the security PIN.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupSecurityPIN</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityPINs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetSecurityPin(string,SecurityPinContent,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> security pin request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<TokenInformation> GetSecurityPin(this ResourceGroupResource resourceGroupResource, string vaultName, SecurityPinContent content, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetSecurityPin(vaultName, content, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the security PIN.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupSecurityPIN</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityPINs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableRecoveryServicesBackupResourceGroupResource.GetSecurityPin(string,SecurityPinContent,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the recovery services vault. </param>
        /// <param name="content"> security pin request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="vaultName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<TokenInformation>> GetSecurityPinAsync(this ResourceGroupResource resourceGroupResource, string vaultName, SecurityPinContent content, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRecoveryServicesBackupResourceGroupResource(resourceGroupResource).GetSecurityPinAsync(vaultName, content, cancellationToken: cancellationToken);
        }
    }
}
