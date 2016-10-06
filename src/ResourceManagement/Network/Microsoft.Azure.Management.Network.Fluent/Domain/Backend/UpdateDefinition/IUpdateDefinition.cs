// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Backend.UpdateDefinition
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    /// <summary>
    /// The first stage of the backend definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// The entirety of a probe definition as part of a load balancer update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// The final stage of the backend definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }
}