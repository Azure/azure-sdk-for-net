// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition
{


    /// <summary>
    /// The stage of a definition allowing to specify the protocol.
    /// @param <ReturnT> the next stage of the definition
    /// @param <ProtocolT> the protocol type of the value
    /// </summary>
    public interface IWithProtocol<ReturnT,ProtocolT> 
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">protocol a transport protocol</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithProtocol(ProtocolT protocol);

    }
}