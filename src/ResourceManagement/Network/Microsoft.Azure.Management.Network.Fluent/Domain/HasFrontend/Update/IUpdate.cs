// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update
{


    /// <summary>
    /// The stage of an update allowing to specify a frontend.
    /// @param <ReturnT> the next stage of the update
    /// </summary>
    public interface IWithFrontend<ReturnT> 
    {
        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">frontendName an existing frontend name from this load balancer</param>
        /// <returns>the next stage of the update</returns>
        ReturnT WithFrontend(string frontendName);

    }
}