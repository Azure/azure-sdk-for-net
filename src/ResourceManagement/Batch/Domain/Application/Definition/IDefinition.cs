// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.Application.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The first stage of a batch application definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the application definition.
    /// At this stage, any remaining optional settings can be specified, or the application definition
    /// can be attached to the parent batch account definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IWithApplicationPackage<ParentT>
    {
        /// <summary>
        /// Specifies a display name for the Batch application.
        /// </summary>
        /// <param name="displayName">A display name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IWithAttach<ParentT> WithDisplayName(string displayName);

        /// <summary>
        /// The stage of a Batch application definition allowing automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">True to allow the automatic updates of application, otherwise false.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IWithAttach<ParentT> WithAllowUpdates(bool allowUpdates);
    }

    /// <summary>
    /// The stage of a Batch application definition that allows the creation of an application package.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IWithApplicationPackage<ParentT> 
    {
        /// <summary>
        /// The first stage of a new application package definition in a Batch account application.
        /// </summary>
        /// <param name="applicationPackageName">The version of the application.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IWithAttach<ParentT> DefineNewApplicationPackage(string applicationPackageName);
    }

    /// <summary>
    /// The entirety of a Batch application definition as a part of a Batch account definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent Batch account definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Batch.Fluent.Application.Definition.IWithAttach<ParentT>
    {
    }
}