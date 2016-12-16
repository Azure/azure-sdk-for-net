// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update
{
    /// <summary>
    /// The stage of an update allowing to specify a frontend.
    /// </summary>
    /// <typeparam name="Return">The next stage of the update.</typeparam>
    public interface IWithFrontend<ReturnT> 
    {
        /// <summary>
        /// Specifies the frontend.
        /// </summary>
        /// <param name="frontendName">An existing frontend name from this load balancer.</param>
        /// <return>The next stage of the update.</return>
        ReturnT WithFrontend(string frontendName);
    }
}