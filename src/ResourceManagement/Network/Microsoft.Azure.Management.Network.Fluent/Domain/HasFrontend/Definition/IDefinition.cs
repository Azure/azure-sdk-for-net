// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition
{
    /// <summary>
    /// The stage of a definition allowing to specify a load balancer frontend.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    public interface IWithFrontend<ReturnT> 
    {
        /// <summary>
        /// Specifies the frontend to associate.
        /// </summary>
        /// <param name="frontendName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFrontend(string frontendName);
    }
}