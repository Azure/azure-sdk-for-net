// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubAsyncCollector : IAsyncCollector<WebPubSubOperation>
    {
        private readonly IWebPubSubService _service;

        internal WebPubSubAsyncCollector(IWebPubSubService service)
        {
            _service = service;
        }

        public async Task AddAsync(WebPubSubOperation item, CancellationToken cancellationToken = default)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var options = new RequestOptions
            {
                CancellationToken = cancellationToken
            };

            switch (item)
            {
                case SendToAll sendToAll:
                    await _service.Client.SendToAllAsync(RequestContent.Create(sendToAll.Message),
                        Utilities.GetContentType(sendToAll.DataType), sendToAll.Excluded, options).ConfigureAwait(false);
                    break;
                case SendToConnection sendToConnection:
                    await _service.Client.SendToConnectionAsync(sendToConnection.ConnectionId, RequestContent.Create(sendToConnection.Message),
                        Utilities.GetContentType(sendToConnection.DataType), options).ConfigureAwait(false);
                    break;
                case SendToUser sendToUser:
                    await _service.Client.SendToUserAsync(sendToUser.UserId, RequestContent.Create(sendToUser.Message),
                        Utilities.GetContentType(sendToUser.DataType), options).ConfigureAwait(false);
                    break;
                case SendToGroup sendToGroup:
                    await _service.Client.SendToGroupAsync(sendToGroup.Group, RequestContent.Create(sendToGroup.Message),
                        Utilities.GetContentType(sendToGroup.DataType), sendToGroup.Excluded, options).ConfigureAwait(false);
                    break;
                case AddUserToGroup addUserToGroup:
                    await _service.Client.AddUserToGroupAsync(addUserToGroup.Group, addUserToGroup.UserId, options).ConfigureAwait(false);
                    break;
                case RemoveUserFromGroup removeUserFromGroup:
                    await _service.Client.RemoveUserFromGroupAsync(removeUserFromGroup.Group, removeUserFromGroup.UserId, options).ConfigureAwait(false);
                    break;
                case RemoveUserFromAllGroups removeUserFromAllGroups:
                    await _service.Client.RemoveUserFromAllGroupsAsync(removeUserFromAllGroups.UserId, options).ConfigureAwait(false);
                    break;
                case AddConnectionToGroup addConnectionToGroup:
                    await _service.Client.AddConnectionToGroupAsync(addConnectionToGroup.Group, addConnectionToGroup.ConnectionId, options).ConfigureAwait(false);
                    break;
                case RemoveConnectionFromGroup removeConnectionFromGroup:
                    await _service.Client.RemoveConnectionFromGroupAsync(removeConnectionFromGroup.Group, removeConnectionFromGroup.ConnectionId, options).ConfigureAwait(false);
                    break;
                case CloseClientConnection closeClientConnection:
                    await _service.Client.CloseConnectionAsync(closeClientConnection.ConnectionId, closeClientConnection.Reason, options).ConfigureAwait(false);
                    break;
                case GrantGroupPermission grantGroupPermission:
                    await _service.Client.GrantPermissionAsync(grantGroupPermission.Permission, grantGroupPermission.ConnectionId, grantGroupPermission.TargetName, options).ConfigureAwait(false);
                    break;
                case RevokeGroupPermission revokeGroupPermission:
                    await _service.Client.RevokePermissionAsync(revokeGroupPermission.Permission, revokeGroupPermission.ConnectionId, revokeGroupPermission.TargetName, options).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentException("Not supported WebPubSubOperation");
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
