// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network.HasFrontend.Definition
{


    /// <summary>
    /// The stage of a definition allowing to specify a load balancer frontend.
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithFrontend<ReturnT> 
    {
        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name on this load balancer</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithFrontend (string frontendName);

    }
}