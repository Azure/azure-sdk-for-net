// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class AzureFirewallResource
    {
        /// <summary> Runs a packet capture on AzureFirewall. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait for completion; <see cref="WaitUntil.Started"/> to return after starting the operation. </param>
        /// <param name="content"> Parameters supplied to run packet capture on azure firewall. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> PacketCaptureAsync(WaitUntil waitUntil, FirewallPacketCaptureContent content, CancellationToken cancellationToken = default)
        {
            return await PacketCaptureAsync(waitUntil, content.ToNewRequestContent(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Runs a packet capture on AzureFirewall. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait for completion; <see cref="WaitUntil.Started"/> to return after starting the operation. </param>
        /// <param name="content"> Parameters supplied to run packet capture on azure firewall. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation PacketCapture(WaitUntil waitUntil, FirewallPacketCaptureContent content, CancellationToken cancellationToken = default)
        {
            return PacketCapture(waitUntil, content.ToNewRequestContent(), cancellationToken);
        }
    }
}
