// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    /// <summary>
    /// An immutable client-side representation of a private frontend of an internal load balancer.
    /// </summary>
    public interface IPrivateFrontend  :
        IFrontend,
        IHasPrivateIpAddress,
        IHasSubnet
    {
        /// <returns>the private IP allocation method within the associated subnet for this private frontend</returns>
        string PrivateIpAllocationMethod { get; }

    }
}