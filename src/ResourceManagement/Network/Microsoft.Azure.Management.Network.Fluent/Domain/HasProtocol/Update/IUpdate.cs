// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update
{
    /// <summary>
    /// The stage of an update allowing to modify the transport protocol.
    /// </summary>
    /// <typeparam name="Return">The next stage of the update.</typeparam>
    /// <typeparam name="Protocol">The type of the protocol value.</typeparam>
    public interface IWithProtocol<ReturnT,ProtocolT> 
    {
        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        ReturnT WithProtocol(ProtocolT protocol);
    }
}