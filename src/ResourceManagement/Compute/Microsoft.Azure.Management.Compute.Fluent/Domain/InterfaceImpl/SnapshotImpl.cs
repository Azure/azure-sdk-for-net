// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Snapshot.Definition;
    using Snapshot.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    internal partial class SnapshotImpl 
    {
        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromSnapshot.WithDataFromSnapshot(string snapshotId)
        {
            return this.WithDataFromSnapshot(snapshotId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source data managed snapshot.
        /// </summary>
        /// <param name="snapshot">Snapshot resource.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromSnapshot.WithDataFromSnapshot(ISnapshot snapshot)
        {
            return this.WithDataFromSnapshot(snapshot) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the operating system type.
        /// </summary>
        /// <param name="osType">Operating system type.</param>
        /// <return>The next stage of the managed snapshot update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithOsSettings.WithOSType(OperatingSystemTypes osType)
        {
            return this.WithOSType(osType) as Snapshot.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the source data vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
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
        /// Gets the snapshot sku type.
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
        CreationSource Microsoft.Azure.Management.Compute.Fluent.ISnapshot.Source
        {
            get
            {
                return this.Source() as CreationSource;
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
        /// <return>The readonly SAS uri to the snapshot.</return>
        string Microsoft.Azure.Management.Compute.Fluent.ISnapshot.GrantAccess(int accessDurationInSeconds)
        {
            return this.GrantAccess(accessDurationInSeconds);
        }

        /// <summary>
        /// Gets the type of operating system in the snapshot.
        /// </summary>
        Models.OperatingSystemTypes? Microsoft.Azure.Management.Compute.Fluent.ISnapshot.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Specifies the id of source data managed disk.
        /// </summary>
        /// <param name="managedDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromDisk.WithDataFromDisk(string managedDiskId)
        {
            return this.WithDataFromDisk(managedDiskId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source data managed disk.
        /// </summary>
        /// <param name="managedDisk">Source managed disk.</param>
        /// <return>The next stage of the managed disk definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithDataSnapshotFromDisk.WithDataFromDisk(IDisk managedDisk)
        {
            return this.WithDataFromDisk(managedDisk) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the account type.
        /// </summary>
        /// <param name="sku">Sku type.</param>
        /// <return>The next stage of the managed snapshot update.</return>
        Snapshot.Update.IUpdate Snapshot.Update.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku) as Snapshot.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the sku type.
        /// </summary>
        /// <param name="sku">Sku type.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSku.WithSku(DiskSkuTypes sku)
        {
            return this.WithSku(sku) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the disk size.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromSnapshot(string sourceSnapshotId)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshotId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshot) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source specialized or generalized Linux OS vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromVhd(string vhdUrl)
        {
            return this.WithLinuxFromVhd(vhdUrl) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromDisk(string sourceDiskId)
        {
            return this.WithLinuxFromDisk(sourceDiskId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Linux OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithLinuxSnapshotSource.WithLinuxFromDisk(IDisk sourceDisk)
        {
            return this.WithLinuxFromDisk(sourceDisk) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.ISnapshot Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.ISnapshot>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.ISnapshot;
        }

        /// <summary>
        /// Specifies the source specialized or generalized Windows OS vhd.
        /// </summary>
        /// <param name="vhdUrl">The source vhd url.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromVhd(string vhdUrl)
        {
            return this.WithWindowsFromVhd(vhdUrl) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshotId">Snapshot resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromSnapshot(string sourceSnapshotId)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshotId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed snapshot.
        /// </summary>
        /// <param name="sourceSnapshot">Source snapshot.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromSnapshot(ISnapshot sourceSnapshot)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshot) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDiskId">Source managed disk resource id.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromDisk(string sourceDiskId)
        {
            return this.WithWindowsFromDisk(sourceDiskId) as Snapshot.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the source Windows OS managed disk.
        /// </summary>
        /// <param name="sourceDisk">Source managed disk.</param>
        /// <return>The next stage of the managed snapshot definition.</return>
        Snapshot.Definition.IWithCreate Snapshot.Definition.IWithWindowsSnapshotSource.WithWindowsFromDisk(IDisk sourceDisk)
        {
            return this.WithWindowsFromDisk(sourceDisk) as Snapshot.Definition.IWithCreate;
        }
    }
}