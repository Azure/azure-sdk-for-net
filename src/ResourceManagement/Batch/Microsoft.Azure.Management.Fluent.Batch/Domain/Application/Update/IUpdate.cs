// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch.Application.Update
{

    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    /// <summary>
    /// The stage of the application update allowing to enable or disable auto upgrade of the
    /// application.
    /// </summary>
    public interface IWithOptionalProperties 
    {
        /// <summary>
        /// Allow automatic application updates.
        /// </summary>
        /// <param name="allowUpdates">allowUpdates true to allow the automatic updates of application, otherwise false</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate WithAllowUpdates (bool allowUpdates);

        /// <summary>
        /// Specifies the display name for the application.
        /// </summary>
        /// <param name="displayName">displayName the displayName value to set</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate WithDisplayName (string displayName);

    }
    /// <summary>
    /// A application definition to allow creation of application package.
    /// </summary>
    public interface IWithApplicationPackage 
    {
        /// <summary>
        /// First stage to create new application package in Batch account application.
        /// </summary>
        /// <param name="version">version the version of the application</param>
        /// <returns>next stage to create the application.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate DefineNewApplicationPackage (string version);

        /// <summary>
        /// Deletes specified application package from the application.
        /// </summary>
        /// <param name="version">version the reference version of the application to be removed</param>
        /// <returns>the stage representing updatable batch account definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate WithoutApplicationPackage (string version);

    }
    /// <summary>
    /// The entirety of application update as a part of parent batch account update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>,
        IWithOptionalProperties,
        IWithApplicationPackage
    {
    }
}