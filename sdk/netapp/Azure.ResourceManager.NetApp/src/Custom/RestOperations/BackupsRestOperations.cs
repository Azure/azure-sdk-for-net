// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    internal partial class BackupsRestOperations
    {
        private readonly string _backup_old_apiVersion = "2022-11-01";

        internal HttpMessage CreateGetStatusRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backupStatus", false);
            uri.AppendQuery("api-version", _backup_old_apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get the status of the backup for a volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/> or <paramref name="volumeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/> or <paramref name="volumeName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NetAppVolumeBackupStatus>> GetStatusAsync(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));

            using var message = CreateGetStatusRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NetAppVolumeBackupStatus value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NetAppVolumeBackupStatus.DeserializeNetAppVolumeBackupStatus(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get the status of the backup for a volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/> or <paramref name="volumeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/> or <paramref name="volumeName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NetAppVolumeBackupStatus> GetStatus(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));

            using var message = CreateGetStatusRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NetAppVolumeBackupStatus value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NetAppVolumeBackupStatus.DeserializeNetAppVolumeBackupStatus(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create a backup for the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="data"> Backup object supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/>, <paramref name="backupName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Response> CreateAsync(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create a backup for the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="data"> Backup object supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/>, <paramref name="backupName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Response Create(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppBackupData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backups/", false);
            uri.AppendPath(backupName, true);
            uri.AppendQuery("api-version", _backup_old_apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backups/", false);
            uri.AppendPath(backupName, true);
            uri.AppendQuery("api-version", _backup_old_apiVersion, true);
            request.Uri = uri;
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateListRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backups", false);
            uri.AppendQuery("api-version", _backup_old_apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateRestoreFilesRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppVolumeBackupBackupRestoreFilesContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backups/", false);
            uri.AppendPath(backupName, true);
            uri.AppendPath("/restoreFiles", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var content0 = new Utf8JsonRequestContent();
            content0.JsonWriter.WriteObjectValue(content);
            request.Content = content0;
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppVolumeBackupPatch patch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backups/", false);
            uri.AppendPath(backupName, true);
            uri.AppendQuery("api-version", _backup_old_apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(patch);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Delete a backup of the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Response> DeleteAsync(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete a backup of the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Response Delete(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.NetApp/netAppAccounts/", false);
            uri.AppendPath(accountName, true);
            uri.AppendPath("/capacityPools/", false);
            uri.AppendPath(poolName, true);
            uri.AppendPath("/volumes/", false);
            uri.AppendPath(volumeName, true);
            uri.AppendPath("/backups/", false);
            uri.AppendPath(backupName, true);
            uri.AppendQuery("api-version", _backup_old_apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets the specified backup of the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NetAppBackupData>> GetAsync(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NetAppBackupData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NetAppBackupData.DeserializeNetAppBackupData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((NetAppBackupData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets the specified backup of the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NetAppBackupData> Get(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NetAppBackupData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NetAppBackupData.DeserializeNetAppBackupData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((NetAppBackupData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Restore the specified files from the specified backup to the active filesystem. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="content"> Restore payload supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/>, <paramref name="backupName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> RestoreFilesAsync(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppVolumeBackupBackupRestoreFilesContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateRestoreFilesRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName, content);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Restore the specified files from the specified backup to the active filesystem. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="content"> Restore payload supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/>, <paramref name="backupName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response RestoreFiles(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppVolumeBackupBackupRestoreFilesContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateRestoreFilesRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName, content);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch a backup for the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="patch"> Backup object supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/>, <paramref name="backupName"/> or <paramref name="patch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> UpdateAsync(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppVolumeBackupPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName, patch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch a backup for the volume. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the NetApp account. </param>
        /// <param name="poolName"> The name of the capacity pool. </param>
        /// <param name="volumeName"> The name of the volume. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="patch"> Backup object supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/>, <paramref name="backupName"/> or <paramref name="patch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="accountName"/>, <paramref name="poolName"/>, <paramref name="volumeName"/> or <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Update(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName, NetAppVolumeBackupPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(poolName, nameof(poolName));
            Argument.AssertNotNullOrEmpty(volumeName, nameof(volumeName));
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, accountName, poolName, volumeName, backupName, patch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
