// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasHostName.Definition
{
    /// <summary>
    /// The stage of a definition allowing to specify a host name.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    public interface IWithHostName<ReturnT> 
    {
        /// <summary>
        /// Specifies the hostname to reference.
        /// </summary>
        /// <param name="hostName">An existing frontend name on this load balancer.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithHostName(string hostName);
    }
}