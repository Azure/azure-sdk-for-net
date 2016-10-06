// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update
{


    /// <summary>
    /// The stage of an update allowing to modify the backend port.
    /// @param <ReturnT> the next stage of the update
    /// </summary>
    public interface IWithBackendPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the backend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        ReturnT WithBackendPort(int port);

    }
}