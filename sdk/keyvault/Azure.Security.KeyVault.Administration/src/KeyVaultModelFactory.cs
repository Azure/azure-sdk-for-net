// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <summary>
    /// A factory class which constructs model classes for mocking purposes.
    /// </summary>
    public static class KeyVaultModelFactory
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
        public static RoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, IReadOnlyList<KeyVaultPermission> permissions, IReadOnlyList<string> assignableScopes) =>
            new RoleDefinition(id, name, type, roleName, description, roleType, permissions, assignableScopes);

        /// <summary>
        /// Initializes a new instance of RoleAssignment.
        /// </summary>
        /// <param name="id"> The role assignment ID. </param>
        /// <param name="name"> The role assignment name. </param>
        /// <param name="type"> The role assignment type. </param>
        /// <param name="properties"> Role assignment properties. </param>
        public static RoleAssignment RoleAssignment(string id, string name, string type, RoleAssignmentPropertiesWithScope properties) =>
            new RoleAssignment(id, name, type, properties);

        /// <summary> Initializes a new instance of FullBackupDetails. </summary>
        /// <param name="status"> Status of the backup operation. </param>
        /// <param name="statusDetails"> The status details of backup operation. </param>
        /// <param name="error"> Error encountered, if any, during the full backup operation. </param>
        /// <param name="startTime"> The start time of the backup operation in UTC. </param>
        /// <param name="endTime"> The end time of the backup operation in UTC. </param>
        /// <param name="jobId"> Identifier for the full backup operation. </param>
        /// <param name="azureStorageBlobContainerUri"> The Azure blob storage container Uri which contains the full backup. </param>
        public static FullBackupDetails FullBackupDetails(string status, string statusDetails, KeyVaultServiceError error, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobId, Uri azureStorageBlobContainerUri) =>
            new FullBackupDetails(status, statusDetails, error, startTime, endTime, jobId, azureStorageBlobContainerUri.AbsoluteUri);

        /// <summary> Initializes a new instance of FullRestoreDetails. </summary>
        /// <param name="status"> Status of the restore operation. </param>
        /// <param name="statusDetails"> The status details of restore operation. </param>
        /// <param name="error"> Error encountered, if any, during the full restore operation. </param>
        /// <param name="jobId"> Identifier for the full restore operation. </param>
        /// <param name="startTime"> The start time of the restore operation. </param>
        /// <param name="endTime"> The end time of the restore operation. </param>
        public static FullRestoreDetails FullRestoreDetails(string status, string statusDetails, KeyVaultServiceError error, string jobId, DateTimeOffset? startTime, DateTimeOffset? endTime) =>
            new FullRestoreDetails(status, statusDetails, error, jobId, startTime, endTime);

        /// <summary>
        /// Initializes a new instance of a FullRestoreOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="FullRestoreDetails" /> that will be returned from <see cref="RestoreOperation.Value" />.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="RestoreOperation.GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        public static RestoreOperation FullRestoreOperation(FullRestoreDetails value, Response response, KeyVaultBackupClient client) =>
            new RestoreOperation(value, response, client);

        /// <summary>
        /// Initializes a new instance of a FullBackupOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="FullBackupDetails" /> that will be returned from <see cref="BackupOperation.Value" />.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="BackupOperation.GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        public static BackupOperation FullBackupOperation(FullBackupDetails value, Response response, KeyVaultBackupClient client) =>
            new BackupOperation(value, response, client);
    }
}
