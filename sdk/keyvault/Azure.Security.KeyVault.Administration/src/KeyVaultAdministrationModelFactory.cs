// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// A factory class which constructs model classes for mocking purposes.
    /// </summary>
    [CodeGenSuppress("KeyVaultSetting", typeof(string), typeof(KeyVaultSettingType?), typeof(string))]
    public static partial class KeyVaultAdministrationModelFactory
    {
        /// <summary> Initializes a new instance of KeyVaultRoleDefinition. </summary>
        /// <param name="id"> The role definition ID. </param>
        /// <param name="name"> The role definition name. </param>
        /// <param name="type"> The role definition type. </param>
        /// <param name="roleName"> The role name. </param>
        /// <param name="description"> The role definition description. </param>
        /// <param name="roleType"> The role type. </param>
        /// <param name="permissions"> Role definition permissions. </param>
        /// <param name="assignableScopes"> Role definition assignable scopes. </param>
        /// <returns> A new <see cref="Administration.KeyVaultRoleDefinition"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KeyVaultRoleDefinition KeyVaultRoleDefinition(string id, string name, KeyVaultRoleDefinitionType? type, string roleName, string description, KeyVaultRoleType? roleType, IList<KeyVaultPermission> permissions, IList<KeyVaultRoleScope> assignableScopes)
        {
            return new KeyVaultRoleDefinition(id, name, type, new RoleDefinitionProperties(roleName, description, roleType, permissions, assignableScopes, new Dictionary<string, BinaryData>()), new Dictionary<string, BinaryData>());
        }

        /// <summary>
        /// Initializes a new instance of RoleDefinition.
        /// </summary>
        /// <param name="id"> The role definition ID. </param>
        /// <param name="name"> The role definition name. </param>
        /// <param name="type"> The role definition type. </param>
        /// <param name="roleName"> The role name. </param>
        /// <param name="description"> The role definition description. </param>
        /// <param name="roleType"> The role type. </param>
        /// <param name="permissions"> Role definition permissions. </param>
        /// <param name="assignableScopes"> Role definition assignable scopes. </param>
        public static KeyVaultRoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, IList<KeyVaultPermission> permissions, IList<KeyVaultRoleScope> assignableScopes) =>
            new KeyVaultRoleDefinition(id, name, type, new RoleDefinitionProperties(roleName, description, roleType, permissions, assignableScopes, new Dictionary<string, BinaryData>()), new Dictionary<string, BinaryData>());

        /// <summary>
        /// Initializes a new instance of RoleAssignment.
        /// </summary>
        /// <param name="id"> The role assignment ID. </param>
        /// <param name="name"> The role assignment name. </param>
        /// <param name="type"> The role assignment type. </param>
        /// <param name="properties"> Role assignment properties. </param>
        public static KeyVaultRoleAssignment RoleAssignment(string id, string name, string type, KeyVaultRoleAssignmentProperties properties) =>
            new KeyVaultRoleAssignment(id, name, type, properties, new Dictionary<string, BinaryData>());

        /// <summary>
        /// Initializes a new instance of a <see cref="KeyVaultRestoreOperation"/> for mocking purposes.
        /// </summary>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="KeyVaultRestoreOperation.GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id"> Identifier for the restore operation.</param>
        /// <param name="startTime"> The start time of the restore operation.</param>
        /// <param name="endTime"> The end time of the restore operation.</param>
        /// <param name="errorMessage">The error message generated from the operation, if any.</param>
        public static KeyVaultRestoreOperation RestoreOperation(Response response, KeyVaultBackupClient client, string id, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string errorMessage = null) =>
            new KeyVaultRestoreOperation(new RestoreDetailsInternal(
                null,
                null,
                errorMessage == null ? null : new KeyVaultServiceError(string.Empty, errorMessage, null),
                id,
                startTime,
                endTime,
                new Dictionary<string, BinaryData>()), response, client);

        /// <summary>
        /// Initializes a new instance of a <see cref="KeyVaultBackupOperation"/> for mocking purposes.
        /// </summary>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="KeyVaultBackupOperation.GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id"> Identifier for the restore operation.</param>
        /// <param name="blobContainerUri">The Blob Container Uri containing the backup.</param>
        /// <param name="startTime"> The start time of the restore operation.</param>
        /// <param name="endTime"> The end time of the restore operation.</param>
        /// <param name="errorMessage">The error message generated from the operation, if any.</param>
        public static KeyVaultBackupOperation BackupOperation(Response response, KeyVaultBackupClient client, string id, Uri blobContainerUri, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string errorMessage = null) =>
            new KeyVaultBackupOperation(new FullBackupDetailsInternal(
                null,
                null,
                errorMessage == null ? null : new KeyVaultServiceError(string.Empty, errorMessage, null),
                startTime,
                endTime,
                id,
                blobContainerUri.AbsoluteUri,
                new Dictionary<string, BinaryData>()), response, client);

        /// <summary>
        /// Initializes a new instance of a <see cref="KeyVaultBackupResult"/> for mocking purposes.
        /// </summary>
        /// <param name="folderUri">The location of the backup.</param>
        /// <param name="startTime">The start time of the backup operation.</param>
        /// <param name="endTime">The end time of the backup operation.</param>
        /// <returns>A new <see cref="KeyVaultBackupResult"/> instance.</returns>
        public static KeyVaultBackupResult BackupResult(Uri folderUri, DateTimeOffset startTime, DateTimeOffset endTime) =>
            new KeyVaultBackupResult(folderUri, startTime, endTime);

        /// <summary>
        /// Initializes a new instance of a <see cref="KeyVaultRestoreResult"/> for mocking purposes.
        /// </summary>
        /// <param name="startTime">The start time of the restore operation.</param>
        /// <param name="endTime">The end time of the restore operation.</param>
        /// <returns>A new <see cref="KeyVaultRestoreResult"/> instance.</returns>
        public static KeyVaultRestoreResult RestoreResult(DateTimeOffset startTime, DateTimeOffset endTime) =>
            new KeyVaultRestoreResult(startTime, endTime);

        /// <summary>
        /// Initializes a new instance of a <see cref="KeyVaultRestoreResult"/> for mocking purposes.
        /// </summary>
        /// <param name="startTime">The start time of the restore operation.</param>
        /// <param name="endTime">The end time of the restore operation.</param>
        /// <returns>A new <see cref="KeyVaultRestoreResult"/> instance.</returns>
        public static KeyVaultRestoreResult SelectiveKeyRestoreResult(DateTimeOffset startTime, DateTimeOffset endTime) =>
            new KeyVaultRestoreResult(startTime, endTime);

        /// <summary> Initializes a new instance of <see cref="Administration.KeyVaultRoleDefinition"/>. </summary>
        /// <param name="id"> The role definition ID. </param>
        /// <param name="name"> The role definition name. </param>
        /// <param name="type"> The role definition type. </param>
        /// <param name="roleName"> The role name. </param>
        /// <param name="description"> The role definition description. </param>
        /// <param name="roleType"> The role type. </param>
        /// <param name="permissions"> Role definition permissions. </param>
        /// <param name="assignableScopes"> Role definition assignable scopes. </param>
        /// <returns> A new <see cref="Administration.KeyVaultRoleDefinition"/> instance for mocking. </returns>
        public static KeyVaultRoleDefinition KeyVaultRoleDefinition(string id = null, string name = null, KeyVaultRoleDefinitionType? type = null, string roleName = null, string description = null, KeyVaultRoleType? roleType = null, IEnumerable<KeyVaultPermission> permissions = null, IEnumerable<KeyVaultRoleScope> assignableScopes = null)
        {
            permissions ??= new List<KeyVaultPermission>();
            assignableScopes ??= new List<KeyVaultRoleScope>();

            return new KeyVaultRoleDefinition(
                id,
                name,
                type,
                new RoleDefinitionProperties(
                    roleName,
                    description,
                    roleType,
                    permissions.ToList(),
                    assignableScopes.ToList(),
                    new Dictionary<string, BinaryData>()),
                new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Administration.KeyVaultSetting"/>. </summary>
        /// <param name="name"> The account setting to be updated. </param>
        /// <param name="content"> The value of the pool setting. </param>
        /// <param name="settingType"> The type specifier of the value. </param>
        /// <returns> A new <see cref="Administration.KeyVaultSetting"/> instance for mocking. </returns>
        public static KeyVaultSetting KeyVaultSetting(string name = null, string content = null, KeyVaultSettingType? settingType = null)
        {
            return new KeyVaultSetting(name, content, settingType, new Dictionary<string, BinaryData>());
        }
    }
}
