// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The stage of a public frontend definition allowing to specify an existing public IP address.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPublicIPAddress<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition.IWithPublicIPAddress<Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate>>
    {
    }

    /// <summary>
    /// The first stage of a public frontend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IWithPublicIPAddress<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a public frontend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IWithPublicIPAddress<ParentT>
    {
    }

    /// <summary>
    /// The final stage of a public frontend definition.
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }
}