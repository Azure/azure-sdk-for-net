// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Orbital.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Orbital
{
    /// <summary>
    /// A Class representing an OrbitalSpacecraft along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="OrbitalSpacecraftResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetOrbitalSpacecraftResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetOrbitalSpacecraft method.
    /// </summary>
    public partial class OrbitalSpacecraftResource : ArmResource
    {
        /// <summary>
        /// Returns list of available contacts. A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Orbital/spacecrafts/{spacecraftName}/listAvailableContacts
        /// Operation Id: Spacecrafts_ListAvailableContacts
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters to provide for the contacts. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<PageableOperation<OrbitalSpacecraftAvailableContact>> GetAvailableContactsAsync(WaitUntil waitUntil, OrbitalSpacecraftContactContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _orbitalSpacecraftSpacecraftsClientDiagnostics.CreateScope("OrbitalSpacecraftResource.GetAvailableContacts");
            scope.Start();
            try
            {
                var response = await _orbitalSpacecraftSpacecraftsRestClient.ListAvailableContactsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new OrbitalSpacecraftAvailableContactPageableOperation(new AvailableContactsListResultOperationSource(), _orbitalSpacecraftSpacecraftsClientDiagnostics, Pipeline, _orbitalSpacecraftSpacecraftsRestClient.CreateListAvailableContactsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response.GetRawResponse(), OperationFinalStateVia.Location, _orbitalSpacecraftSpacecraftsRestClient);
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
        /// Returns list of available contacts. A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Orbital/spacecrafts/{spacecraftName}/listAvailableContacts
        /// Operation Id: Spacecrafts_ListAvailableContacts
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The parameters to provide for the contacts. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual PageableOperation<OrbitalSpacecraftAvailableContact> GetAvailableContacts(WaitUntil waitUntil, OrbitalSpacecraftContactContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _orbitalSpacecraftSpacecraftsClientDiagnostics.CreateScope("OrbitalSpacecraftResource.GetAvailableContacts");
            scope.Start();
            try
            {
                var response = _orbitalSpacecraftSpacecraftsRestClient.ListAvailableContacts(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new OrbitalSpacecraftAvailableContactPageableOperation(new AvailableContactsListResultOperationSource(), _orbitalSpacecraftSpacecraftsClientDiagnostics, Pipeline, _orbitalSpacecraftSpacecraftsRestClient.CreateListAvailableContactsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response.GetRawResponse(), OperationFinalStateVia.Location, _orbitalSpacecraftSpacecraftsRestClient);
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
