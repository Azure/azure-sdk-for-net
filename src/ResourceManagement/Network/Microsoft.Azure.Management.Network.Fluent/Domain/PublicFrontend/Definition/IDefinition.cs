// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.PublicFrontend.Definition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasPublicIpAddress.Definition;
    /// <summary>
    /// The final stage of a public frontend definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the frontend definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>
    {
    }
    /// <summary>
    /// The entirety of a public frontend definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IWithPublicIpAddress<ParentT>
    {
    }
    /// <summary>
    /// The first stage of a public frontend definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithPublicIpAddress<ParentT>
    {
    }
    /// <summary>
    /// The stage of a public frontend definition allowing to specify an existing public IP address.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithPublicIpAddress<ParentT>  :
        IWithExistingPublicIpAddress<Microsoft.Azure.Management.Fluent.Network.PublicFrontend.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>>
    {
    }
}