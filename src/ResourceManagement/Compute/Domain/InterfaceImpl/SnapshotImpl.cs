// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Snapshot.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.Snapshot.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;

    internal partial class SnapshotImpl 
    {
        /// <summary>
        /// Specifies the operating system type.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithOSSettings.WithOSType(OperatingSystemTypes osType)
        {
            return this.WithOSType(osType) as Snapshot.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromSnapshot.WithDataFromSnapshot(string snapshotId)
        {
            return this.WithDataFromSnapshot(snapshotId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">A snapshot resource.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromSnapshot.WithDataFromSnapshot(ISnapshot snapshot)
        {
            return this.WithDataFromSnapshot(snapshot) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source data VHD.
        /// </summary>
        /// <param name="vhdUrl">A source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromVhd.WithDataFromVhd(string vhdUrl)
        {
            return this.WithDataFromVhd(vhdUrl) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the snapshot creation method.
        /// </summary>
        Models.DiskCreateOption Microsoft.Azure.Management.Compute.Fluent.ISnapshot.CreationMethod
        {
            get
            {
                return this.CreationMethod();
            }
        }

        /// <summary>
        /// Gets disk size in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.ISnapshot.SizeInGB
        {
            get
            {
                return this.SizeInGB();
            }
        }

        /// <summary>
        /// Gets the snapshot SKU type.
        /// </summary>
        Models.DiskSkuTypes Microsoft.Azure.Management.Compute.Fluent.ISnapshot.Sku
        {
            get
            {
                return this.Sku() as Models.DiskSkuTypes;
            }
        }

        /// <summary>
        /// Gets the details of the source from which snapshot is created.
        /// </summary>
        Models.CreationSource Microsoft.Azure.Management.Compute.Fluent.ISnapshot.Source
        {
            get
            {
                return this.Source() as Models.CreationSource;
            }
        }

        /// <summary>
        /// Revoke access granted to the snapshot.
        /// </summary>
        void Microsoft.Azure.Management.Compute.Fluent.ISnapshot.RevokeAccess()
        {
 
            this.RevokeAccess();
        }

        /// <summary>
        /// Grants access to the snapshot.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>The read-only SAS URI to the snapshot.</return>
        string Microsoft.Azure.Management.Compute.Fluent.ISnapshot.GrantAccess(int accessDurationInSeconds)
        {
            return this.GrantAccess(accessDurationInSeconds);
        }

        /// <summary>
        /// Revoke access granted to the snapshot asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Compute.Fluent.ISnapshot.RevokeAccessAsync(CancellationToken cancellationToken)
        {
 
            await this.RevokeAccessAsync(cancellationToken);
        }

        /// <summary>
        /// Grants access to the snapshot asynchronously.
        /// </summary>
        /// <param name="accessDurationInSeconds">The access duration in seconds.</param>
        /// <return>A representation of the deferred computation of this call returning a read-only SAS URI to the disk.</return>
        async Task<string> Microsoft.Azure.Management.Compute.Fluent.ISnapshot.GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken)
        {
            return await this.GrantAccessAsync(accessDurationInSeconds, cancellationToken);
        }

        /// <summary>
        /// Gets the type of operating system in the snapshot.
        /// </summary>
        Models.OperatingSystemTypes? Microsoft.Azure.Management.Compute.Fluent.ISnapshot.OSType
        {
            get
            {
                return this.OSType();
            }
        }

        /// <summary>
        /// Specifies the ID of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromDisk.WithDataFromDisk(string managedDiskId)
        {
            return this.WithDataFromDisk(managedDiskId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromDisk.WithDataFromDisk(IDisk managedDisk)
        {
            return this.WithDataFromDisk(managedDisk) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the account type.
        /// </summary>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku) as Snapshot.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the SKU type.
        /// </summary>
        /// <param name="sku">SKU type.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromSnapshot(string sourceSnapshotId)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshotId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">A source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshot) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source specialized or generalized Linux OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromVhd(string vhdUrl)
        {
            return this.WithLinuxFromVhd(vhdUrl) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">A source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromDisk(string sourceDiskId)
        {
            return this.WithLinuxFromDisk(sourceDiskId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromDisk(IDisk sourceDisk)
        {
            return this.WithLinuxFromDisk(sourceDisk) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source specialized or generalized Windows OS VHD.
        /// </summary>
        /// <param name="vhdUrl">The source VHD URL.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromVhd(string vhdUrl)
        {
            return this.WithWindowsFromVhd(vhdUrl) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">A snapshot resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromSnapshot(string sourceSnapshotId)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshotId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">A source snapshot.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshot) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">A source managed disk resource ID.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromDisk(string sourceDiskId)
        {
            return this.WithWindowsFromDisk(sourceDiskId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">A source managed disk.</param>
        /// <return>The next stage of the definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromDisk(IDisk sourceDisk)
        {
            return this.WithWindowsFromDisk(sourceDisk) as Snapshot.Definition.IWithCreate;
        }
    }
}