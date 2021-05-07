// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubService : IWebPubSubService
    {
        private readonly WebPubSubServiceClient _client;
        private readonly ServiceConfigParser _serviceConfig;

        public WebPubSubService(string connectionString, string hub)
        {
            _serviceConfig = new ServiceConfigParser(connectionString);
            _client = new WebPubSubServiceClient(connectionString, hub);
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

        public async Task AddConnectionToGroup(AddConnectionToGroup webPubSubEvent)
        {
            await _client.AddConnectionToGroupAsync(webPubSubEvent.Group, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task AddUserToGroup(AddUserToGroup webPubSubEvent)
        {
            await _client.AddUserToGroupAsync(webPubSubEvent.Group, webPubSubEvent.UserId).ConfigureAwait(false);
        }

        public async Task CloseClientConnection(CloseClientConnection webPubSubEvent)
        {
            await _client.CloseClientConnectionAsync(webPubSubEvent.ConnectionId, webPubSubEvent.Reason).ConfigureAwait(false);
        }

        public async Task GrantGroupPermission(GrantGroupPermission webPubSubEvent)
        {
            await _client.GrantPermissionAsync(webPubSubEvent.Permission, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task RemoveConnectionFromGroup(RemoveConnectionFromGroup webPubSubEvent)
        {
            await _client.RemoveConnectionFromGroupAsync(webPubSubEvent.Group, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task RemoveUserFromAllGroups(RemoveUserFromAllGroups webPubSubEvent)
        {
            await _client.RemoveUserFromAllGroupsAsync(webPubSubEvent.UserId).ConfigureAwait(false);
        }

        public async Task RemoveUserFromGroup(RemoveUserFromGroup webPubSubEvent)
        {
            await _client.RemoveUserFromGroupAsync(webPubSubEvent.Group, webPubSubEvent.UserId).ConfigureAwait(false);
        }

        public async Task RevokeGroupPermission(RevokeGroupPermission webPubSubEvent)
        {
            await _client.RevokePermissionAsync(webPubSubEvent.Permission, webPubSubEvent.ConnectionId).ConfigureAwait(false);
        }

        public async Task SendToAll(SendToAll webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message);
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToAllAsync(content, contentType, webPubSubEvent.Excluded).ConfigureAwait(false);
        }

        public async Task SendToConnection(SendToConnection webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message);
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToConnectionAsync(webPubSubEvent.ConnectionId, content, contentType).ConfigureAwait(false);
        }

        public async Task SendToGroup(SendToGroup webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message);
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToGroupAsync(webPubSubEvent.Group, content, contentType, webPubSubEvent.Excluded).ConfigureAwait(false);
        }

        public async Task SendToUser(SendToUser webPubSubEvent)
        {
            var content = RequestContent.Create(webPubSubEvent.Message);
            var contentType = Utilities.GetContentType(webPubSubEvent.DataType);
            await _client.SendToUserAsync(webPubSubEvent.UserId, content, contentType).ConfigureAwait(false);
        }
    }
}
