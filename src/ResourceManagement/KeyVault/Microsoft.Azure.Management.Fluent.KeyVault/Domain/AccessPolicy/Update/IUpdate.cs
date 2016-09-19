/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update;
    using Microsoft.Azure.Management.KeyVault.Models;
    using System.Collections.Generic;
    /// <summary>
    /// The entirety of an access policy update as part of a key vault update.
    /// </summary>
    public interface IUpdate  :
        IWithPermissions,
        ISettable<Microsoft.Azure.Management.Fluent.KeyVault.Vault.Update.IUpdate>
    {
    }
    /// <summary>
    /// The access policy update stage allowing permissions to be added or removed.
    /// </summary>
    public interface IWithPermissions 
    {
        /// <summary>
        /// Allow all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate AllowKeyAllPermissions ();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate AllowKeyPermission (KeyPermissions permission);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate AllowKeyPermissions (IList<KeyPermissions> permissions);

        /// <summary>
        /// Revoke all permissions for the AD identity to access keys.
        /// </summary>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate DisallowKeyAllPermissions ();

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate DisallowKeyPermission (KeyPermissions permission);

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access keys.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate DisallowKeyPermissions (IList<KeyPermissions> permissions);

        /// <summary>
        /// Allow all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate AllowSecretAllPermissions ();

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate AllowSecretPermission (SecretPermissions permission);

        /// <summary>
        /// Allow a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions allowed</param>
        /// <returns>the next stage of access policy definition</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate AllowSecretPermissions (IList<SecretPermissions> permissions);

        /// <summary>
        /// Revoke all permissions for the AD identity to access secrets.
        /// </summary>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate DisallowSecretAllPermissions ();

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate DisallowSecretPermission (SecretPermissions permission);

        /// <summary>
        /// Revoke a list of permissions for the AD identity to access secrets.
        /// </summary>
        /// <param name="permissions">permissions the list of permissions to revoke</param>
        /// <returns>the next stage of access policy update</returns>
        Microsoft.Azure.Management.Fluent.KeyVault.AccessPolicy.Update.IUpdate DisallowSecretPermissions (IList<SecretPermissions> permissions);

    }
}