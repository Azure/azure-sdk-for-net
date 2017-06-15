// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The entirety of a load balancer backend definition as part of a load balancer update.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of a load balancer backend definition.
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent load balancer definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a load balancer backend definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IWithAttach<ParentT>
    {
    }
}