// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{


    /// <summary>
    /// An interface representing a model's ability to reference a load balancer backend port.
    /// </summary>
    public interface IHasBackendPort 
    {
        /// <returns>the backend port number the network traffic is sent to</returns>
        int? BackendPort { get; }

    }
}