// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;

    /// <summary>
    /// The entirety of a public frontend update as part of an Internet-facing load balancer update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update.IWithPublicIPAddress
    {
    }

    /// <summary>
    /// The stage of a public frontend update allowing to specify an existing public IP address.
    /// </summary>
    public interface IWithPublicIPAddress  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update.IWithPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update.IUpdate>
    {
    }
}