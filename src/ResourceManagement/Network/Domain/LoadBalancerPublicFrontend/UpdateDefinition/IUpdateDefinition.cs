// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.UpdateDefinition;

    /// <summary>
    /// The first stage of a public frontend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IWithPublicIPAddress<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the public frontend definition.
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The stage of a public frontend definition allowing to specify an existing public IP address.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPublicIPAddress<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.UpdateDefinition.IWithPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The entirety of a public frontend definition as part of an Internet-facing load balancer update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IWithPublicIPAddress<ParentT>
    {
    }
}