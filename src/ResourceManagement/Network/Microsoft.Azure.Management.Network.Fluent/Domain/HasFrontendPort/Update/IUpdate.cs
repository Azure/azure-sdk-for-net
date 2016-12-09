// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Update
{
    /// <summary>
    /// The stage of an update allowing to specify the frontend port.
    /// </summary>
    public interface IWithFrontendPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        ReturnT WithFrontendPort(int port);
    }
}