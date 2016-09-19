/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault
{

    using Microsoft.Azure.Management.Fluent.Graph.RBAC;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update;
    using System;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition;
    public partial class AccessPolicyImpl 
    {
        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.AllowSecretPermission (SecretPermissions permissions) {
            return this.AllowSecretPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.AllowSecretPermissions (IList<SecretPermissions> permissions) {
            return this.AllowSecretPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.AllowKeyAllPermissions ()
        {
                return this.AllowKeyAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }
        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.AllowSecretAllPermissions ()
        {
            return this.AllowSecretAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }
        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.AllowKeyPermission (KeyPermissions permissions) {
            return this.AllowKeyPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.AllowKeyPermissions (IList<KeyPermissions> permissions) {
            return this.AllowKeyPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.AllowSecretPermission (SecretPermissions permissions) {
            return this.AllowSecretPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.AllowSecretPermissions (IList<SecretPermissions> permissions) {
            return this.AllowSecretPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.AllowKeyAllPermissions ()
        {
            return this.AllowKeyAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }
        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.AllowSecretAllPermissions ()
        {
            return this.AllowSecretAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }
        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.AllowKeyPermission (KeyPermissions permissions) {
            return this.AllowKeyPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithPermissions<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.AllowKeyPermissions (IList<KeyPermissions> permissions) {
            return this.AllowKeyPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <returns>The object ID of a user or service principal in the Azure Active</returns>
        /// <returns>Directory tenant for the vault.</returns>
        string Microsoft.Azure.Management.Fluent.KeyVault.IAccessPolicy.ObjectId
        {
            get
            {
                return this.ObjectId as string;
            }
        }
        /// <returns>The Azure Active Directory tenant ID that should be used for</returns>
        /// <returns>authenticating requests to the key vault.</returns>
        string Microsoft.Azure.Management.Fluent.KeyVault.IAccessPolicy.TenantId
        {
            get
            {
                return this.TenantId as string;
            }
        }
        /// <returns>Permissions the identity has for keys and secrets.</returns>
        Microsoft.Azure.Management.KeyVault.Models.Permissions Microsoft.Azure.Management.Fluent.KeyVault.IAccessPolicy.Permissions
        {
            get
            {
                return this.Permissions as Microsoft.Azure.Management.KeyVault.Models.Permissions;
            }
        }
        /// <returns>Application ID of the client making request on behalf of a principal.</returns>
        string Microsoft.Azure.Management.Fluent.KeyVault.IAccessPolicy.ApplicationId
        {
            get
            {
                return this.ApplicationId as string;
            }
        }
        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipal">servicePrincipal the AD service principal object</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.ForServicePrincipal (IServicePrincipal servicePrincipal) {
            return this.ForServicePrincipal( servicePrincipal) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipalName">servicePrincipalName the service principal name of the AD user</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.ForServicePrincipal (string servicePrincipalName) {
            return this.ForServicePrincipal( servicePrincipalName) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="user">user the AD user object</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.ForUser (IUser user) {
            return this.ForUser( user) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="userPrincipalName">userPrincipalName the user principal name of the AD user</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.ForUser (string userPrincipalName) {
            return this.ForUser( userPrincipalName) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the Active Directory group this access policy is for.
        /// </summary>
        /// <param name="group">group the AD group object</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.ForGroup (IActiveDirectoryGroup group) {
            return this.ForGroup( group) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the object ID of the Active Directory identity this access policy is for.
        /// </summary>
        /// <param name="objectId">objectId the object ID of the AD identity</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.ForObjectId (Guid objectId) {
            return this.ForObjectId( objectId) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipal">servicePrincipal the AD service principal object</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.ForServicePrincipal (IServicePrincipal servicePrincipal) {
            return this.ForServicePrincipal( servicePrincipal) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the Active Directory service principal this access policy is for.
        /// </summary>
        /// <param name="servicePrincipalName">servicePrincipalName the service principal name of the AD user</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.ForServicePrincipal (string servicePrincipalName) {
            return this.ForServicePrincipal( servicePrincipalName) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="user">user the AD user object</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.ForUser (IUser user) {
            return this.ForUser( user) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the Active Directory user this access policy is for.
        /// </summary>
        /// <param name="userPrincipalName">userPrincipalName the user principal name of the AD user</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.ForUser (string userPrincipalName) {
            return this.ForUser( userPrincipalName) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the Active Directory group this access policy is for.
        /// </summary>
        /// <param name="group">group the AD group object</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.ForGroup (IActiveDirectoryGroup group) {
            return this.ForGroup( group) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the object ID of the Active Directory identity this access policy is for.
        /// </summary>
        /// <param name="objectId">objectId the object ID of the AD identity</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate> Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithIdentity<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>.ForObjectId (Guid objectId) {
            return this.ForObjectId( objectId) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Definition.IWithAttach<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <returns>the next stage of the parent definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate;
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.DisallowSecretPermission (SecretPermissions permissions) {
            return this.DisallowSecretPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.DisallowSecretPermissions (IList<SecretPermissions> permissions) {
            return this.DisallowSecretPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.DisallowKeyPermission (KeyPermissions permissions) {
            return this.DisallowKeyPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.DisallowKeyPermissions (IList<KeyPermissions> permissions) {
            return this.DisallowKeyPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.AllowSecretPermission (SecretPermissions permissions) {
            return this.AllowSecretPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.AllowSecretPermissions (IList<SecretPermissions> permissions) {
            return this.AllowSecretPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.AllowKeyAllPermissions () {
            return this.AllowKeyAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Revoke all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.DisallowSecretAllPermissions () {
            return this.DisallowSecretAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.AllowSecretAllPermissions () {
            return this.AllowSecretAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Revoke all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.DisallowKeyAllPermissions () {
            return this.DisallowKeyAllPermissions() as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.AllowKeyPermission (KeyPermissions permissions) {
            return this.AllowKeyPermission( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IWithPermissions.AllowKeyPermissions (IList<KeyPermissions> permissions) {
            return this.AllowKeyPermissions( permissions) as Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate;
        }

    }
}