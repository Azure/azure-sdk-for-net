// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerResource : ArmResource
    {
        /// <summary> Gets a collection of PostgreSqlFlexibleServerActiveDirectoryAdministratorResources in the PostgreSqlFlexibleServer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrators' instead.")]
        public virtual PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection GetPostgreSqlFlexibleServerActiveDirectoryAdministrators()
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrators' instead.");
        }

        /// <summary> Gets information about a server administrator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrator' instead.")]
        [ForwardsClientCalls]
        public virtual Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetPostgreSqlFlexibleServerActiveDirectoryAdministrator(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrator' instead.");
        }

        /// <summary> Gets information about a server administrator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorAsync' instead.")]
        [ForwardsClientCalls]
        public virtual async Task<Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetPostgreSqlFlexibleServerActiveDirectoryAdministratorAsync(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorAsync' instead.");
        }

        /// <summary> Get server capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerCapabilityProperties> GetServerCapabilities(CancellationToken cancellationToken = default)
            => GetAll(cancellationToken);

        /// <summary> Get server capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> GetServerCapabilitiesAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken);

        /// <summary> Get log files. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerLogFile> GetPostgreSqlFlexibleServerLogFiles(CancellationToken cancellationToken = default)
            => GetCapturedLogsByServer(cancellationToken);

        /// <summary> Get log files. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerLogFile> GetPostgreSqlFlexibleServerLogFilesAsync(CancellationToken cancellationToken = default)
            => GetCapturedLogsByServerAsync(cancellationToken);

        /// <summary> Check migration name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlCheckMigrationNameAvailabilityContent> CheckPostgreSqlMigrationNameAvailability(PostgreSqlCheckMigrationNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Check migration name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlCheckMigrationNameAvailabilityContent>> CheckPostgreSqlMigrationNameAvailabilityAsync(PostgreSqlCheckMigrationNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => await CheckNameAvailabilityAsync(content, cancellationToken).ConfigureAwait(false);

        /// <summary> Start LTR backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PostgreSqlFlexibleServerLtrBackupResult> StartLtrBackupFlexibleServer(WaitUntil waitUntil, PostgreSqlFlexibleServerLtrBackupContent content, CancellationToken cancellationToken = default)
            => Start(waitUntil, content, cancellationToken);

        /// <summary> Start LTR backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerLtrBackupResult>> StartLtrBackupFlexibleServerAsync(WaitUntil waitUntil, PostgreSqlFlexibleServerLtrBackupContent content, CancellationToken cancellationToken = default)
            => await StartAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Trigger LTR pre-backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerLtrPreBackupResult> TriggerLtrPreBackupFlexibleServer(PostgreSqlFlexibleServerLtrPreBackupContent content, CancellationToken cancellationToken = default)
            => CheckPrerequisites(content, cancellationToken);

        /// <summary> Trigger LTR pre-backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerLtrPreBackupResult>> TriggerLtrPreBackupFlexibleServerAsync(PostgreSqlFlexibleServerLtrPreBackupContent content, CancellationToken cancellationToken = default)
            => await CheckPrerequisitesAsync(content, cancellationToken).ConfigureAwait(false);
    }
}
