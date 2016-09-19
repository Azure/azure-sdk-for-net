/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition
{

    using Microsoft.Azure.Management.KeyVault.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC;
    using System;
    /// <summary>
    /// The entirety of an access policy definition.
    /// @param <ParentT> the return type of the final {@link Attachable#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// The first stage of an access policy definition.
    /// 
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithIdentity<ParentT>
    {
    }
    /// <summary>
    /// The access policy definition stage allowing permissions to be added.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithPermissions<ParentT> 
    {
        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> AllowKeyAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> AllowKeyPermission (KeyPermissions permission);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> AllowKeyPermissions (IList<KeyPermissions> permissions);

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> AllowSecretAllPermissions();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> AllowSecretPermission (SecretPermissions permission);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> AllowSecretPermissions (IList<SecretPermissions> permissions);

    }
    /// <summary>
    /// The final stage of the access policy definition.
    /// <p>
    /// At this stage, more permissions can be added or application ID can be specified,
    /// or the access policy definition can be attached to the parent key vault definition
    /// using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithPermissions<ParentT>
    {
    }
    /// <summary>
    /// The access policy definition stage allowing the Active Directory identity to be specified.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithIdentity<ParentT> 
    {
        /// <summary>
        /// Specifies the object ID of the Active Directory identity this access policy is for.
        /// </summary>
        /// <param name="objectId">objectId the object ID of the AD identity</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> ForObjectId (Guid objectId);

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="user">user the AD user object</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> ForUser (IUser user);

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="userPrincipalName">userPrincipalName the user principal name of the AD user</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> ForUser (string userPrincipalName);

        /// <summary>
        /// Specifies the Active Directory group this access policy is for.
        /// </summary>
        /// <param name="group">group the AD group object</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> ForGroup (IActiveDirectoryGroup group);

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipal">servicePrincipal the AD service principal object</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> ForServicePrincipal (IServicePrincipal servicePrincipal);

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipalName">servicePrincipalName the service principal name of the AD user</param>
        /// <returns>the next stage of access policy definition</returns>
        IWithAttach<ParentT> ForServicePrincipal (string servicePrincipalName);

    }
}