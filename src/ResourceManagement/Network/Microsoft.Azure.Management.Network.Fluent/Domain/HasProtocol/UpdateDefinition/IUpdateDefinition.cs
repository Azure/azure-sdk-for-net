// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to specify the protocol.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    /// <typeparam name="Protocol">The protocol type of the value.</typeparam>
    public interface IWithProtocol<ReturnT,ProtocolT> 
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithProtocol(ProtocolT protocol);
    }
}