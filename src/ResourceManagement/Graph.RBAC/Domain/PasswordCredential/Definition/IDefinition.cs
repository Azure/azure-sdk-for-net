// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System;
    using System.IO;

    /// <summary>
    /// The final stage of the credential definition.
    /// At this stage, more settings can be specified, or the credential definition can be
    /// attached to the parent application / service principal definition
    /// using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithStartDate<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithDuration<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithAuthFile<ParentT>
    {
    }

    /// <summary>
    /// The credential definition stage allowing the the password or certificate to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithKey<ParentT>
    {
        /// <summary>
        /// Use a password as a key.
        /// </summary>
        /// <param name="password">The password value.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithAttach<ParentT> WithPasswordValue(string password);
    }

    /// <summary>
    /// The credential definition stage allowing start date to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithStartDate<ParentT>
    {
        /// <summary>
        /// Specifies the start date after which password or key would be valid. Default value is current time.
        /// </summary>
        /// <param name="startDate">The start date for validity.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithAttach<ParentT> WithStartDate(DateTime startDate);
    }

    /// <summary>
    /// The entirety of a credential definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT> :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The credential definition stage allowing the duration of key validity to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDuration<ParentT>
    {
        /// <summary>
        /// Specifies the duration for which password or key would be valid. Default value is 1 year.
        /// </summary>
        /// <param name="duration">The duration of validity.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithAttach<ParentT> WithDuration(TimeSpan duration);
    }

    /// <summary>
    /// A credential definition stage allowing exporting the auth file for the service principal.
    /// </summary>
    public interface IWithAuthFile<ParentT>
    {
        /// <summary>
        /// Export the information of this service principal into an auth file.
        /// </summary>
        /// <param name="outputStream">The output stream to export the file.</param>
        /// <return>The next stage in credential definition.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithAttach<ParentT> WithAuthFileToExport(StreamWriter outputStream);
    }

    /// <summary>
    /// The first stage of a credential definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.Graph.RBAC.Fluent.PasswordCredential.Definition.IWithKey<ParentT>
    {
    }
}