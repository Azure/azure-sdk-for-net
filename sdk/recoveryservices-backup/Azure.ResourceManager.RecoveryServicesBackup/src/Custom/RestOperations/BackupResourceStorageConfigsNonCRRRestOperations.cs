// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

// TODO: need further investigation to determine why the behavior of this operation is different but spec is same.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    internal partial class BackupResourceStorageConfigsNonCRRRestOperations
    {
        /// <summary> Updates vault storage model type. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="vaultName"> The name of the VaultResource. </param>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vaultName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<BackupResourceConfigData>> PatchAsync(string subscriptionId, string resourceGroupName, string vaultName, BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreatePatchRequest(subscriptionId, resourceGroupName, vaultName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BackupResourceConfigData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = BackupResourceConfigData.DeserializeBackupResourceConfigData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((BackupResourceConfigData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates vault storage model type. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="vaultName"> The name of the VaultResource. </param>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="vaultName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<BackupResourceConfigData> Patch(string subscriptionId, string resourceGroupName, string vaultName, BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreatePatchRequest(subscriptionId, resourceGroupName, vaultName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        BackupResourceConfigData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = BackupResourceConfigData.DeserializeBackupResourceConfigData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((BackupResourceConfigData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
