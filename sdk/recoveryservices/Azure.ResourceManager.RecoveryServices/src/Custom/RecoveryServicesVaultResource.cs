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
        public virtual async Task<ArmOperation<RecoveryServicesVaultResource>> UpdateAsync(WaitUntil waitUntil, RecoveryServicesVaultPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _recoveryServicesVaultVaultsClientDiagnostics.CreateScope("RecoveryServicesVaultResource.Update");
            scope.Start();
            try
            {
                var response = await _recoveryServicesVaultVaultsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, null, cancellationToken).ConfigureAwait(false);
                var operation = new RecoveryServicesArmOperation<RecoveryServicesVaultResource>(new RecoveryServicesVaultOperationSource(Client), _recoveryServicesVaultVaultsClientDiagnostics, Pipeline, _recoveryServicesVaultVaultsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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
        public virtual ArmOperation<RecoveryServicesVaultResource> Update(WaitUntil waitUntil, RecoveryServicesVaultPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _recoveryServicesVaultVaultsClientDiagnostics.CreateScope("RecoveryServicesVaultResource.Update");
            scope.Start();
            try
            {
                var response = _recoveryServicesVaultVaultsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, null, cancellationToken);
                var operation = new RecoveryServicesArmOperation<RecoveryServicesVaultResource>(new RecoveryServicesVaultOperationSource(Client), _recoveryServicesVaultVaultsClientDiagnostics, Pipeline, _recoveryServicesVaultVaultsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
