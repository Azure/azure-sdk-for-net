// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition
{


    /// <summary>
    /// The stage of a definition allowing to specify the backend port.
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithBackendPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the backend port.
        /// <p>
        /// If not specified, the same backend port number is assumed as that used by the frontend.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithBackendPort(int port);

    }
}