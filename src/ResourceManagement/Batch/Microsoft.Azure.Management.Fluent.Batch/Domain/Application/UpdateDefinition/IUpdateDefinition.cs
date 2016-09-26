// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    /// <summary>
    /// The entirety of a application definition as a part of parent update.
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// The final stage of the application definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the application definition
    /// can be attached to the parent batch account definition using {@link Application.DefinitionStages.WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link Application.DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithApplicationPackage<ParentT>
    {
        /// <summary>
        /// Allow automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">allowUpdates true to allow the automatic updates of application, otherwise false</param>
        /// <returns>parent batch account update definition.</returns>
        IWithAttach<ParentT> WithAllowUpdates (bool allowUpdates);

        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">displayName display name for the application.</param>
        /// <returns>parent batch account update definition.</returns>
        IWithAttach<ParentT> WithDisplayName (string displayName);

    }
    /// <summary>
    /// The first stage of a application definition.
    /// 
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// A application definition to allow creation of application package.
    /// 
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IWithApplicationPackage<ParentT> 
    {
        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">version the version of the application</param>
        /// <returns>next stage to create the application.</returns>
        IWithAttach<ParentT> DefineNewApplicationPackage (string version);

    }
}