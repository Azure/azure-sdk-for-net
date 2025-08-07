// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    [CodeGenSuppress("CreateUpdateRequest", typeof(string), typeof(string), typeof(string), typeof(string), typeof(NotificationHubPatch))]
    [CodeGenSuppress("UpdateAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(NotificationHubPatch), typeof(CancellationToken))]
    [CodeGenSuppress("Update", typeof(string), typeof(string), typeof(string), typeof(string), typeof(NotificationHubPatch), typeof(CancellationToken))]
    internal partial class NotificationHubsRestOperations
    {
        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, NotificationHubUpdateContent patchContent)
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
            uri.AppendPath("/providers/Microsoft.NotificationHubs/namespaces/", false);
            uri.AppendPath(namespaceName, true);
            uri.AppendPath("/notificationHubs/", false);
            uri.AppendPath(notificationHubName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(patchContent);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Patch a NotificationHub in a namespace. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="namespaceName"> Namespace name. </param>
        /// <param name="notificationHubName"> Notification Hub name. </param>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="namespaceName"/>, <paramref name="notificationHubName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="namespaceName"/> or <paramref name="notificationHubName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NotificationHubData>> UpdateAsync(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(notificationHubName, nameof(notificationHubName));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, namespaceName, notificationHubName, content);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NotificationHubData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NotificationHubData.DeserializeNotificationHubData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch a NotificationHub in a namespace. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="namespaceName"> Namespace name. </param>
        /// <param name="notificationHubName"> Notification Hub name. </param>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="namespaceName"/>, <paramref name="notificationHubName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="namespaceName"/> or <paramref name="notificationHubName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NotificationHubData> Update(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(notificationHubName, nameof(notificationHubName));
            Argument.AssertNotNull(content, nameof(content));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, namespaceName, notificationHubName, content);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NotificationHubData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NotificationHubData.DeserializeNotificationHubData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
