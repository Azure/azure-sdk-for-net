// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: GA exposed Simulate on SubscriptionSecurityAlertCollection.
    // The TypeSpec route is generated on SecurityCenterLocationResource, so keep the collection
    // overloads as forwarding helpers to preserve the GA public API.
    public partial class SubscriptionSecurityAlertCollection
    {
        /// <summary> Simulate security alerts. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The content to use in the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> SimulateAsync(WaitUntil waitUntil, SecurityAlertSimulatorContent content, CancellationToken cancellationToken = default)
        {
            return new SecurityCenterLocationResource(Client, Id).SimulateAsync(waitUntil, content, cancellationToken);
        }

        /// <summary> Simulate security alerts. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="content"> The content to use in the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Simulate(WaitUntil waitUntil, SecurityAlertSimulatorContent content, CancellationToken cancellationToken = default)
        {
            return new SecurityCenterLocationResource(Client, Id).Simulate(waitUntil, content, cancellationToken);
        }
    }
}
