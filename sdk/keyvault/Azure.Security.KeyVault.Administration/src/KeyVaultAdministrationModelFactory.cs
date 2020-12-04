// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// A factory class which constructs model classes for mocking purposes.
    /// </summary>
    public static class KeyVaultAdministrationModelFactory
    {
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
        public static KeyVaultRoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, IList<KeyVaultPermission> permissions, IList<string> assignableScopes) =>
            new KeyVaultRoleDefinition(id, name, type, roleName, description, roleType, permissions, assignableScopes);

        /// <summary>
        /// Initializes a new instance of RoleAssignment.
        /// </summary>
        /// <param name="id"> The role assignment ID. </param>
        /// <param name="name"> The role assignment name. </param>
        /// <param name="type"> The role assignment type. </param>
        /// <param name="properties"> Role assignment properties. </param>
        public static KeyVaultRoleAssignment RoleAssignment(string id, string name, string type, KeyVaultRoleAssignmentPropertiesWithScope properties) =>
            new KeyVaultRoleAssignment(id, name, type, properties);

        /// <summary>
        /// Initializes a new instance of a FullRestoreOperation for mocking purposes.
        /// </summary>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="RestoreOperation.GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id"> Identifier for the restore operation.</param>
        /// <param name="startTime"> The start time of the restore operation.</param>
        /// <param name="endTime"> The end time of the restore operation.</param>
        /// <param name="errorMessage">The error message generated from the operation, if any.</param>
        public static RestoreOperation RestoreOperation(Response response, KeyVaultBackupClient client, string id, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string errorMessage = null) =>
            new RestoreOperation(new RestoreDetailsInternal(
                null,
                null,
                errorMessage == null ? null : new KeyVaultServiceError(string.Empty, errorMessage, null),
                id,
                startTime,
                endTime), response, client);

        /// <summary>
        /// Initializes a new instance of a FullBackupOperation for mocking purposes.
        /// </summary>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="BackupOperation.GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id"> Identifier for the restore operation.</param>
        /// <param name="blobContainerUri">The Blob Container Uri containing the backup.</param>
        /// <param name="startTime"> The start time of the restore operation.</param>
        /// <param name="endTime"> The end time of the restore operation.</param>
        /// <param name="errorMessage">The error message generated from the operation, if any.</param>
        public static BackupOperation BackupOperation(Response response, KeyVaultBackupClient client, string id, Uri blobContainerUri, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string errorMessage = null) =>
            new BackupOperation(new FullBackupDetailsInternal(
                null,
                null,
                errorMessage == null ? null : new KeyVaultServiceError(string.Empty, errorMessage, null),
                startTime,
                endTime,
                id,
                blobContainerUri.AbsoluteUri), response, client);

        /// <summary>
        /// Initializes a new instance of a <see cref="BackupResult"/> for mocking purposes.
        /// </summary>
        /// <param name="folderUri">The location of the backup.</param>
        /// <param name="startTime">The start time of the backup operation.</param>
        /// <param name="endTime">The end time of the backup operation.</param>
        /// <returns>A new <see cref="BackupResult"/> instance.</returns>
        public static BackupResult BackupResult(Uri folderUri, DateTimeOffset startTime, DateTimeOffset endTime) =>
            new BackupResult(folderUri, startTime, endTime);

        /// <summary>
        /// Initializes a new instance of a <see cref="RestoreResult"/> for mocking purposes.
        /// </summary>
        /// <param name="startTime">The start time of the restore operation.</param>
        /// <param name="endTime">The end time of the restore operation.</param>
        /// <returns>A new <see cref="BackupResult"/> instance.</returns>
        public static RestoreResult RestoreResult(DateTimeOffset startTime, DateTimeOffset endTime) =>
            new RestoreResult(startTime, endTime);

        /// <summary>
        /// Initializes a new instance of a <see cref="SelectiveKeyRestoreResult"/> for mocking purposes.
        /// </summary>
        /// <param name="startTime">The start time of the restore operation.</param>
        /// <param name="endTime">The end time of the restore operation.</param>
        /// <returns>A new <see cref="BackupResult"/> instance.</returns>
        public static RestoreResult SelectiveKeyRestoreResult(DateTimeOffset startTime, DateTimeOffset endTime) =>
            new RestoreResult(startTime, endTime);
    }
}
