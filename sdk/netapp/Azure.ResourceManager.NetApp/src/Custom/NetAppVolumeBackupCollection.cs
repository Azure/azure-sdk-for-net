// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    // Volume-scoped backups are no longer modeled as a resource collection in TypeSpec.
    // Retain the GA-shipped collection type for source compatibility, but all operations
    // throw with guidance to use the backup-vault scoped APIs instead.
    /// <summary>
    /// A class representing a collection of <see cref="NetAppVolumeBackupResource" /> and their operations.
    /// Each <see cref="NetAppVolumeBackupResource" /> in the collection will belong to the same instance of <see cref="NetAppVolumeResource" />.
    /// To get a <see cref="NetAppVolumeBackupCollection" /> instance call the GetNetAppVolumeBackups method from an instance of <see cref="NetAppVolumeResource" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future release. Volume-scoped backups have moved to NetAppBackupVaultBackupResource.", false)]
    public partial class NetAppVolumeBackupCollection : ArmCollection, IEnumerable<NetAppVolumeBackupResource>, IAsyncEnumerable<NetAppVolumeBackupResource>
    {
        private const string NotSupportedMessage = "Volume-scoped backups have moved to NetAppBackupVaultBackupResource. Use NetAppBackupVaultResource.GetNetAppBackupVaultBackups() instead.";

        /// <summary> Initializes a new instance of the <see cref="NetAppVolumeBackupCollection"/> class for mocking. </summary>
        protected NetAppVolumeBackupCollection()
        {
        }

        /// <summary> Create a backup for the volume. </summary>
        public virtual Task<ArmOperation<NetAppVolumeBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Create a backup for the volume. </summary>
        public virtual ArmOperation<NetAppVolumeBackupResource> CreateOrUpdate(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Gets the specified backup of the volume. </summary>
        public virtual Task<Response<NetAppVolumeBackupResource>> GetAsync(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Gets the specified backup of the volume. </summary>
        public virtual Response<NetAppVolumeBackupResource> Get(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> List all backups for a volume. </summary>
        public virtual AsyncPageable<NetAppVolumeBackupResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> List all backups for a volume. </summary>
        public virtual Pageable<NetAppVolumeBackupResource> GetAll(CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual Task<NullableResponse<NetAppVolumeBackupResource>> GetIfExistsAsync(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<NetAppVolumeBackupResource> GetIfExists(string backupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(NotSupportedMessage);

        IEnumerator<NetAppVolumeBackupResource> IEnumerable<NetAppVolumeBackupResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        IAsyncEnumerator<NetAppVolumeBackupResource> IAsyncEnumerable<NetAppVolumeBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
