// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update
{
    /// <summary>
    /// The stage of an update allowing to modify the backend port.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the update.</typeparam>
    public interface IWithBackendPort<ReturnT> 
    {
        /// <summary>
        /// Specifies a backend port to send network traffic to.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the update.</return>
        ReturnT ToBackendPort(int port);
    }
}