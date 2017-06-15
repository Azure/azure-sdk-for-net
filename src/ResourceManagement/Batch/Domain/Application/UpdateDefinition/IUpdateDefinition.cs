// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The first stage of a Batch application definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of a Batch application definition.
    /// At this stage, any remaining optional settings can be specified, or the application definition
    /// can be attached to the parent batch Account update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account update to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IWithApplicationPackage<ParentT>
    {
        /// <summary>
        /// Specifies the display name for the Batch application.
        /// </summary>
        /// <param name="displayName">A display name for the application.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IWithAttach<ParentT> WithDisplayName(string displayName);

        /// <summary>
        /// Allows automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">True to allow automatic updates of a Batch application, otherwise false.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IWithAttach<ParentT> WithAllowUpdates(bool allowUpdates);
    }

    /// <summary>
    /// The stage of a Batch application definition allowing the creation of an application package.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IWithApplicationPackage<ParentT> 
    {
        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">The version of the application.</param>
        /// <return>Next stage to create the application.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IWithAttach<ParentT> DefineNewApplicationPackage(string version);
    }

    /// <summary>
    /// The entirety of a Batch application definition as a part of parent update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account update to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition.IWithAttach<ParentT>
    {
    }
}