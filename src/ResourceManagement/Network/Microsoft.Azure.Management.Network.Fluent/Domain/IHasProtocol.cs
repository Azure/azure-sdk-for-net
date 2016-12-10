// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to reference a transport protocol.
    /// </summary>
    /// <typeparam name="Protocol">The protocol type of the value.</typeparam>
    public interface IHasProtocol<ProtocolT> 
    {
        /// <summary>
        /// Gets the protocol.
        /// </summary>
        ProtocolT Protocol { get; }
    }
}