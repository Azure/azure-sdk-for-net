// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{


    /// <summary>
    /// An interface representing a model's ability to reference a transport protocol.
    /// @param <ProtocolT> the protocol type of the value
    /// </summary>
    public interface IHasProtocol<ProtocolT> 
    {
        /// <returns>the protocol</returns>
        ProtocolT Protocol ();

    }
}