// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    [CodeGenSuppress("VMwareCbtEnableMigrationContent", typeof(ResourceIdentifier), typeof(IEnumerable<VMwareCbtDiskContent>), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(ResourceIdentifier), typeof(ResourceIdentifier))]
    public partial class VMwareCbtEnableMigrationContent
    {
        /// <summary> Initializes a new instance of <see cref="VMwareCbtEnableMigrationContent"/>. </summary>
        // TODO: Remove this compatibility constructor after https://github.com/microsoft/typespec/issues/11588 is fixed.
        public VMwareCbtEnableMigrationContent(ResourceIdentifier vmwareMachineId, IEnumerable<VMwareCbtDiskContent> disksToInclude, ResourceIdentifier dataMoverRunAsAccountId, ResourceIdentifier snapshotRunAsAccountId, ResourceIdentifier targetResourceGroupId, ResourceIdentifier targetNetworkId)
            : base("VMwareCbt")
        {
            Argument.AssertNotNull(vmwareMachineId, nameof(vmwareMachineId));
            Argument.AssertNotNull(disksToInclude, nameof(disksToInclude));
            Argument.AssertNotNull(dataMoverRunAsAccountId, nameof(dataMoverRunAsAccountId));
            Argument.AssertNotNull(snapshotRunAsAccountId, nameof(snapshotRunAsAccountId));
            Argument.AssertNotNull(targetResourceGroupId, nameof(targetResourceGroupId));
            Argument.AssertNotNull(targetNetworkId, nameof(targetNetworkId));

            VMwareMachineId = vmwareMachineId;
            DisksToInclude = disksToInclude.ToList();
            DataMoverRunAsAccountId = dataMoverRunAsAccountId;
            SnapshotRunAsAccountId = snapshotRunAsAccountId;
            TargetResourceGroupId = targetResourceGroupId;
            TargetNetworkId = targetNetworkId;
            TargetVmTags = new ChangeTrackingDictionary<string, string>();
            SeedDiskTags = new ChangeTrackingDictionary<string, string>();
            TargetDiskTags = new ChangeTrackingDictionary<string, string>();
            TargetNicTags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
