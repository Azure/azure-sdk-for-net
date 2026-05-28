// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense
{
    internal partial class FirmwaresRestOperations
    {
          internal RequestUriBuilder CreateGenerateDownloadUriRequestUri(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.IoTFirmwareDefense/workspaces/", false);
            uri.AppendPath(workspaceName, true);
            uri.AppendPath("/firmwares/", false);
            uri.AppendPath(firmwareId, true);
            uri.AppendPath("/generateDownloadUrl", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGenerateDownloadUriRequest(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId)
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
            uri.AppendPath("/providers/Microsoft.IoTFirmwareDefense/workspaces/", false);
            uri.AppendPath(workspaceName, true);
            uri.AppendPath("/firmwares/", false);
            uri.AppendPath(firmwareId, true);
            uri.AppendPath("/generateDownloadUrl", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to a url for file download. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="workspaceName"> The name of the firmware analysis workspace. </param>
        /// <param name="firmwareId"> The id of the firmware. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FirmwareUriToken>> GenerateDownloadUriAsync(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));
            Argument.AssertNotNullOrEmpty(firmwareId, nameof(firmwareId));

            using var message = CreateGenerateDownloadUriRequest(subscriptionId, resourceGroupName, workspaceName, firmwareId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FirmwareUriToken value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = FirmwareUriToken.DeserializeFirmwareUriToken(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to a url for file download. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="workspaceName"> The name of the firmware analysis workspace. </param>
        /// <param name="firmwareId"> The id of the firmware. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FirmwareUriToken> GenerateDownloadUri(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));
            Argument.AssertNotNullOrEmpty(firmwareId, nameof(firmwareId));

            using var message = CreateGenerateDownloadUriRequest(subscriptionId, resourceGroupName, workspaceName, firmwareId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FirmwareUriToken value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = FirmwareUriToken.DeserializeFirmwareUriToken(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateGenerateFilesystemDownloadUriRequestUri(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.IoTFirmwareDefense/workspaces/", false);
            uri.AppendPath(workspaceName, true);
            uri.AppendPath("/firmwares/", false);
            uri.AppendPath(firmwareId, true);
            uri.AppendPath("/generateFilesystemDownloadUrl", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGenerateFilesystemDownloadUriRequest(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId)
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
            uri.AppendPath("/providers/Microsoft.IoTFirmwareDefense/workspaces/", false);
            uri.AppendPath(workspaceName, true);
            uri.AppendPath("/firmwares/", false);
            uri.AppendPath(firmwareId, true);
            uri.AppendPath("/generateFilesystemDownloadUrl", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> The operation to a url for tar file download. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="workspaceName"> The name of the firmware analysis workspace. </param>
        /// <param name="firmwareId"> The id of the firmware. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FirmwareUriToken>> GenerateFilesystemDownloadUriAsync(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));
            Argument.AssertNotNullOrEmpty(firmwareId, nameof(firmwareId));

            using var message = CreateGenerateFilesystemDownloadUriRequest(subscriptionId, resourceGroupName, workspaceName, firmwareId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FirmwareUriToken value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = FirmwareUriToken.DeserializeFirmwareUriToken(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> The operation to a url for tar file download. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="workspaceName"> The name of the firmware analysis workspace. </param>
        /// <param name="firmwareId"> The id of the firmware. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="workspaceName"/> or <paramref name="firmwareId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FirmwareUriToken> GenerateFilesystemDownloadUri(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(workspaceName, nameof(workspaceName));
            Argument.AssertNotNullOrEmpty(firmwareId, nameof(firmwareId));

            using var message = CreateGenerateFilesystemDownloadUriRequest(subscriptionId, resourceGroupName, workspaceName, firmwareId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FirmwareUriToken value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = FirmwareUriToken.DeserializeFirmwareUriToken(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
