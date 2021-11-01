// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub.Operations;

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

            switch (item)
            {
                case SendToAll sendToAll:
                    await _service.Client.SendToAllAsync(RequestContent.Create(sendToAll.Message),
                        Utilities.GetContentType(sendToAll.DataType), sendToAll.Excluded).ConfigureAwait(false);
                    break;
                case SendToConnection sendToConnection:
                    await _service.Client.SendToConnectionAsync(sendToConnection.ConnectionId, RequestContent.Create(sendToConnection.Message),
                        Utilities.GetContentType(sendToConnection.DataType)).ConfigureAwait(false);
                    break;
                case SendToUser sendToUser:
                    await _service.Client.SendToUserAsync(sendToUser.UserId, RequestContent.Create(sendToUser.Message),
                        Utilities.GetContentType(sendToUser.DataType)).ConfigureAwait(false);
                    break;
                case SendToGroup sendToGroup:
                    await _service.Client.SendToGroupAsync(sendToGroup.Group, RequestContent.Create(sendToGroup.Message),
                        Utilities.GetContentType(sendToGroup.DataType), sendToGroup.Excluded).ConfigureAwait(false);
                    break;
                case AddUserToGroup addUserToGroup:
                    await _service.Client.AddUserToGroupAsync(addUserToGroup.Group, addUserToGroup.UserId).ConfigureAwait(false);
                    break;
                case RemoveUserFromGroup removeUserFromGroup:
                    await _service.Client.RemoveUserFromGroupAsync(removeUserFromGroup.Group, removeUserFromGroup.UserId).ConfigureAwait(false);
                    break;
                case RemoveUserFromAllGroups removeUserFromAllGroups:
                    await _service.Client.RemoveUserFromAllGroupsAsync(removeUserFromAllGroups.UserId).ConfigureAwait(false);
                    break;
                case AddConnectionToGroup addConnectionToGroup:
                    await _service.Client.AddConnectionToGroupAsync(addConnectionToGroup.Group, addConnectionToGroup.ConnectionId).ConfigureAwait(false);
                    break;
                case RemoveConnectionFromGroup removeConnectionFromGroup:
                    await _service.Client.RemoveConnectionFromGroupAsync(removeConnectionFromGroup.Group, removeConnectionFromGroup.ConnectionId).ConfigureAwait(false);
                    break;
                case CloseAllConnections closeAllConnections:
                    await _service.Client.CloseAllConnectionsAsync(closeAllConnections.Excluded, closeAllConnections.Reason).ConfigureAwait(false);
                    break;
                case CloseClientConnection closeClientConnection:
                    await _service.Client.CloseConnectionAsync(closeClientConnection.ConnectionId, closeClientConnection.Reason).ConfigureAwait(false);
                    break;
                case CloseGroupConnections closeGroupConnections:
                    await _service.Client.CloseGroupConnectionsAsync(closeGroupConnections.Group, closeGroupConnections.Excluded, closeGroupConnections.Reason).ConfigureAwait(false);
                    break;
                case GrantPermission grantPermission:
                    await _service.Client.GrantPermissionAsync(grantPermission.Permission, grantPermission.ConnectionId, grantPermission.TargetName).ConfigureAwait(false);
                    break;
                case RevokePermission revokePermission:
                    await _service.Client.RevokePermissionAsync(revokePermission.Permission, revokePermission.ConnectionId, revokePermission.TargetName).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentException($"Not supported WebPubSubOperation: {nameof(item)}.");
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
