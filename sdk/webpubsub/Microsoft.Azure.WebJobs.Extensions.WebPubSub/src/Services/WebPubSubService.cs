// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubService : IWebPubSubService
    {
        private readonly WebPubSubServiceClient _client;
        private readonly ServiceConfigParser _serviceConfig;

        public WebPubSubService(string connectionString, string hubName)
        {
            _serviceConfig = new ServiceConfigParser(connectionString);
            UriBuilder endpoint = _serviceConfig.Port == 80 ?
                new UriBuilder(_serviceConfig.Endpoint) :
                new UriBuilder(_serviceConfig.Endpoint.Scheme, _serviceConfig.Endpoint.Host, _serviceConfig.Port);

            _client = new WebPubSubServiceClient(endpoint.Uri, hubName, new AzureKeyCredential(_serviceConfig.AccessKey));
        }

        internal WebPubSubConnection GetClientConnection(string userId = null, string[] roles = null)
        {
            var url = _client.GetClientAccessUri(userId, roles);

            #region TODO: Remove after SDK fix. Work-around to support http.
            if (!_serviceConfig.Endpoint.Scheme.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                var replaced = url.AbsoluteUri.Replace("wss", "ws");
                url = new Uri(replaced);
            }
            #endregion

            return new WebPubSubConnection(url);
        }

        public async Task AddConnectionToGroup(WebPubSubEvent webPubSubEvent)
        {
            await _client.AddConnectionToGroupAsync(webPubSubEvent.Group, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task AddUserToGroup(WebPubSubEvent webPubSubEvent)
        {
            await _client.AddUserToGroupAsync(webPubSubEvent.Group, webPubSubEvent.UserId).ConfigureAwait(false);
        }

        public async Task CloseClientConnection(WebPubSubEvent webPubSubEvent)
        {
            await _client.CloseClientConnectionAsync(webPubSubEvent.ConnectionId, webPubSubEvent.Reason).ConfigureAwait(false);
        }

        public async Task GrantGroupPermission(WebPubSubEvent webPubSubEvent)
        {
            await _client.GrantPermissionAsync(webPubSubEvent.Permission, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task RemoveConnectionFromGroup(WebPubSubEvent webPubSubEvent)
        {
            await _client.RemoveConnectionFromGroupAsync(webPubSubEvent.Group, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task RemoveUserFromAllGroups(WebPubSubEvent webPubSubEvent)
        {
            await _client.RemoveUserFromAllGroupsAsync(webPubSubEvent.UserId).ConfigureAwait(false);
        }

        public async Task RemoveUserFromGroup(WebPubSubEvent webPubSubEvent)
        {
            await _client.RemoveUserFromGroupAsync(webPubSubEvent.Group, webPubSubEvent.UserId).ConfigureAwait(false);
        }

        public async Task RevokeGroupPermission(WebPubSubEvent webPubSubEvent)
        {
            await _client.RevokePermissionAsync(webPubSubEvent.Permission, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task SendToAll(WebPubSubEvent webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message.ToBinaryData());
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToAllAsync(content, contentType, webPubSubEvent.Excluded).ConfigureAwait(false);
        }

        public async Task SendToConnection(WebPubSubEvent webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message.ToBinaryData());
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToConnectionAsync(webPubSubEvent.ConnectionId, content, contentType).ConfigureAwait(false);
        }

        public async Task SendToGroup(WebPubSubEvent webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message.ToBinaryData());
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToGroupAsync(webPubSubEvent.Group, content, contentType, webPubSubEvent.Excluded).ConfigureAwait(false);
        }

        public async Task SendToUser(WebPubSubEvent webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message.ToBinaryData());
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToUserAsync(webPubSubEvent.UserId, content, contentType).ConfigureAwait(false);
        }
    }
}
