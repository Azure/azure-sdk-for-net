// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to specify the frontend port.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    public interface IWithFrontendPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFrontendPort(int port);
    }
}