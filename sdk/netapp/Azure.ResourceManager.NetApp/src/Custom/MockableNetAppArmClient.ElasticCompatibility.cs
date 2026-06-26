// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp.Mocking
{
    public partial class MockableNetAppArmClient
    {
        public virtual NetAppElasticAccountResource GetNetAppElasticAccountResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticCapacityPoolResource GetNetAppElasticCapacityPoolResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticVolumeResource GetNetAppElasticVolumeResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticSnapshotResource GetNetAppElasticSnapshotResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticSnapshotPolicyResource GetNetAppElasticSnapshotPolicyResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticBackupVaultResource GetNetAppElasticBackupVaultResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticBackupPolicyResource GetNetAppElasticBackupPolicyResource(ResourceIdentifier id) => throw new NotSupportedException();
        public virtual NetAppElasticBackupResource GetNetAppElasticBackupResource(ResourceIdentifier id) => throw new NotSupportedException();
    }
}
