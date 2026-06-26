// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticBackupPolicyResource : IJsonModel<NetAppElasticBackupPolicyData>, IPersistableModel<NetAppElasticBackupPolicyData>
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupPolicyName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/elasticBackupPolicies/{backupPolicyName}");

        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        NetAppElasticBackupPolicyData IJsonModel<NetAppElasticBackupPolicyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupPolicyData(default);
        void IJsonModel<NetAppElasticBackupPolicyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();
        NetAppElasticBackupPolicyData IPersistableModel<NetAppElasticBackupPolicyData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticBackupPolicyData(default);
        string IPersistableModel<NetAppElasticBackupPolicyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticBackupPolicyData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
    }
}
