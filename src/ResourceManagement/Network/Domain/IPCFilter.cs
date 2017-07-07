// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Client-side representation of packet capture filter.
    /// </summary>
    public interface IPCFilter  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.PacketCaptureFilter>
    {
        /// <summary>
        /// Gets protocol to be filtered on.
        /// </summary>
        Models.PcProtocol Protocol { get; }

        /// <summary>
        /// Gets local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string LocalPort { get; }

        /// <summary>
        /// Gets remote IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string RemoteIPAddress { get; }

        /// <summary>
        /// Gets remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string RemotePort { get; }

        /// <summary>
        /// Gets local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range. "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string LocalIPAddress { get; }
    }
}