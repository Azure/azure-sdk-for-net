// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to references a frontend.
    /// </summary>
    public interface IHasFrontend 
    {
        /// <summary>
        /// Gets the associated frontend.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend Frontend { get; }
    }
}