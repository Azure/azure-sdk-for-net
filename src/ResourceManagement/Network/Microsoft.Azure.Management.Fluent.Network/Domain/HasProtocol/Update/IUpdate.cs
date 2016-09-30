// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update
{


    /// <summary>
    /// The stage of an update allowing to modify the transport protocol.
    /// @param <ReturnT> the next stage of the update
    /// @param <ProtocolT> the type of the protocol value
    /// </summary>
    public interface IWithProtocol<ReturnT,ProtocolT> 
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the update</returns>
        ReturnT WithProtocol (ProtocolT protocol);

    }
}