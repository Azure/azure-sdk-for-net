// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition
{
    /// <summary>
    /// The stage of a definition allowing to specify the backend port.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithBackendPort<ReturnT> 
    {
        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT ToBackendPort(int port);
    }
}