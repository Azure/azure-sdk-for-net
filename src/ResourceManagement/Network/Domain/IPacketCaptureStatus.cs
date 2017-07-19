// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Status of packet capture session.
    /// </summary>
    public interface IPacketCaptureStatus  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.PacketCaptureQueryStatusResultInner>
    {
        /// <summary>
        /// Gets the reason the current packet capture session was stopped.
        /// </summary>
        string StopReason { get; }

        /// <summary>
        /// Gets the start time of the packet capture session.
        /// </summary>
        System.DateTime CaptureStartTime { get; }

        /// <summary>
        /// Gets the name of the packet capture resource.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the ID of the packet capture resource.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the status of the packet capture session. Possible values include:
        /// 'NotStarted', 'Running', 'Stopped', 'Error', 'Unknown'.
        /// </summary>
        /// <summary>
        /// Gets the packetCaptureStatus value.
        /// </summary>
        Models.PcStatus PacketCaptureStatus { get; }

        /// <summary>
        /// Gets the list of errors of packet capture session.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.PcError> PacketCaptureErrors { get; }
    }
}