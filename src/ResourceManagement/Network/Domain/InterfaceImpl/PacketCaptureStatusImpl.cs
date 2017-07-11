// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    internal partial class PacketCaptureStatusImpl 
    {
        /// <summary>
        /// Gets the status of the packet capture session. Possible values include:
        /// 'NotStarted', 'Running', 'Stopped', 'Error', 'Unknown'.
        /// </summary>
        /// <summary>
        /// Gets the packetCaptureStatus value.
        /// </summary>
        Models.PcStatus Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus.PacketCaptureStatus
        {
            get
            {
                return this.PacketCaptureStatus() as Models.PcStatus;
            }
        }

        /// <summary>
        /// Gets the start time of the packet capture session.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus.CaptureStartTime
        {
            get
            {
                return this.CaptureStartTime();
            }
        }

        /// <summary>
        /// Gets the name of the packet capture resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the reason the current packet capture session was stopped.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus.StopReason
        {
            get
            {
                return this.StopReason();
            }
        }

        /// <summary>
        /// Gets the ID of the packet capture resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the list of errors of packet capture session.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.PcError> Microsoft.Azure.Management.Network.Fluent.IPacketCaptureStatus.PacketCaptureErrors
        {
            get
            {
                return this.PacketCaptureErrors() as System.Collections.Generic.IReadOnlyList<Models.PcError>;
            }
        }
    }
}