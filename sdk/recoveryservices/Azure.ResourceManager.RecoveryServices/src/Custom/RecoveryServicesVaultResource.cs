// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServices
{
    /// <summary>
    /// A Class representing a RecoveryServicesVault along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="RecoveryServicesVaultResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetRecoveryServicesVaultResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetRecoveryServicesVault method.
    /// </summary>
    public partial class RecoveryServicesVaultResource
    {
        /// <summary>
        /// Updates the vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vault_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RecoveryServicesVaultResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Recovery Services Vault to be created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<RecoveryServicesVaultResource>> UpdateAsync(WaitUntil waitUntil, RecoveryServicesVaultPatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates the vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vault_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RecoveryServicesVaultResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Recovery Services Vault to be created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<RecoveryServicesVaultResource> Update(WaitUntil waitUntil, RecoveryServicesVaultPatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, cancellationToken);

                /// <summary>
        /// Unregisters the given container from your Recovery Services vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/registeredIdentities/{identityName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vault_DeleteRegisteredIdentity</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="identityName"> Name of the protection container to unregister. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="identityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="identityName"/> is null. </exception>
        public virtual async Task<Response> DeleteRegisteredIdentityAsync(string identityName, CancellationToken cancellationToken = default)
        {
            return null;
        }

                /// <summary>
        /// Unregisters the given container from your Recovery Services vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/registeredIdentities/{identityName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vault_DeleteRegisteredIdentity</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="identityName"> Name of the protection container to unregister. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="identityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="identityName"/> is null. </exception>
        public virtual Response DeleteRegisteredIdentity(string identityName, CancellationToken cancellationToken = default)
        {
            return null;
        }

                /// <summary>
        /// Uploads a certificate for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Certificate friendly name. </param>
        /// <param name="content"> Input parameters for uploading the vault certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateName"/> or <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<VaultCertificateResult>> CreateVaultCertificateAsync(string certificateName, RecoveryServicesCertificateContent content, CancellationToken cancellationToken = default)
        {
            return null;
        }

               /// <summary>
        /// Uploads a certificate for a resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Certificate friendly name. </param>
        /// <param name="content"> Input parameters for uploading the vault certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateName"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<VaultCertificateResult> CreateVaultCertificate(string certificateName, RecoveryServicesCertificateContent content, CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
