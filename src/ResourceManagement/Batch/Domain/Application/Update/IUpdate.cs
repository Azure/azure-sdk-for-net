// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.Application.Update
{
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application update allowing to enable or disable auto upgrade of the
    /// application.
    /// </summary>
    public interface IWithOptionalProperties 
    {
        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">A display name.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IUpdate WithDisplayName(string displayName);

        /// <summary>
        /// Allows automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">True to allow the automatic updates of the application, otherwise false.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IUpdate WithAllowUpdates(bool allowUpdates);
    }

    /// <summary>
    /// The stage of a Batch application update allowing the creation of an application package.
    /// </summary>
    public interface IWithApplicationPackage 
    {
        /// <summary>
        /// Deletes specified application package from the application.
        /// </summary>
        /// <param name="version">The reference version of the application to be removed.</param>
        /// <return>The stage representing updatable batch account definition.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IUpdate WithoutApplicationPackage(string version);

        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">The version of the application.</param>
        /// <return>Next stage to create the application.</return>
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IUpdate DefineNewApplicationPackage(string version);
    }

    /// <summary>
    /// The entirety of a Batch application update as a part of a Batch account update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update.IUpdate>,
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IWithOptionalProperties,
        Microsoft.Azure.Management.Batch.Fluent.Application.Update.IWithApplicationPackage
    {
    }
}