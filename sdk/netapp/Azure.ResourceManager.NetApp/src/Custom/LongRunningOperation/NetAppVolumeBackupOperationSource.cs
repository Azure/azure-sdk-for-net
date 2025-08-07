// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    internal class NetAppVolumeBackupOperationSource : IOperationSource<NetAppVolumeBackupResource>
    {
        private readonly ArmClient _client;

        internal NetAppVolumeBackupOperationSource(ArmClient client)
        {
            _client = client;
        }

        NetAppVolumeBackupResource IOperationSource<NetAppVolumeBackupResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = NetAppBackupData.DeserializeNetAppBackupData(document.RootElement);
            return new NetAppVolumeBackupResource(_client, data);
        }

        async ValueTask<NetAppVolumeBackupResource> IOperationSource<NetAppVolumeBackupResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = NetAppBackupData.DeserializeNetAppBackupData(document.RootElement);
            return new NetAppVolumeBackupResource(_client, data);
        }
    }
}
