// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubAsyncCollector : IAsyncCollector<WebPubSubAction>
    {
        private readonly IWebPubSubService _service;

        internal WebPubSubAsyncCollector(IWebPubSubService service)
        {
            _service = service;
        }

        public async Task AddAsync(WebPubSubAction item, CancellationToken cancellationToken = default)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            switch (item)
            {
                case SendToAllAction sendToAll:
                    await _service.Client.SendToAllAsync(RequestContent.Create(sendToAll.Data),
                        Utilities.GetContentType(sendToAll.DataType), sendToAll.Excluded).ConfigureAwait(false);
                    break;
                case SendToConnectionAction sendToConnection:
                    await _service.Client.SendToConnectionAsync(sendToConnection.ConnectionId, RequestContent.Create(sendToConnection.Data),
                        Utilities.GetContentType(sendToConnection.DataType)).ConfigureAwait(false);
                    break;
                case SendToUserAction sendToUser:
                    await _service.Client.SendToUserAsync(sendToUser.UserId, RequestContent.Create(sendToUser.Data),
                        Utilities.GetContentType(sendToUser.DataType)).ConfigureAwait(false);
                    break;
                case SendToGroupAction sendToGroup:
                    await _service.Client.SendToGroupAsync(sendToGroup.Group, RequestContent.Create(sendToGroup.Data),
                        Utilities.GetContentType(sendToGroup.DataType), sendToGroup.Excluded).ConfigureAwait(false);
                    break;
                case AddUserToGroupAction addUserToGroup:
                    await _service.Client.AddUserToGroupAsync(addUserToGroup.Group, addUserToGroup.UserId).ConfigureAwait(false);
                    break;
                case RemoveUserFromGroupAction removeUserFromGroup:
                    await _service.Client.RemoveUserFromGroupAsync(removeUserFromGroup.Group, removeUserFromGroup.UserId).ConfigureAwait(false);
                    break;
                case RemoveUserFromAllGroupsAction removeUserFromAllGroups:
                    await _service.Client.RemoveUserFromAllGroupsAsync(removeUserFromAllGroups.UserId).ConfigureAwait(false);
                    break;
                case AddConnectionToGroupAction addConnectionToGroup:
                    await _service.Client.AddConnectionToGroupAsync(addConnectionToGroup.Group, addConnectionToGroup.ConnectionId).ConfigureAwait(false);
                    break;
                case RemoveConnectionFromGroupAction removeConnectionFromGroup:
                    await _service.Client.RemoveConnectionFromGroupAsync(removeConnectionFromGroup.Group, removeConnectionFromGroup.ConnectionId).ConfigureAwait(false);
                    break;
                case CloseAllConnectionsAction closeAllConnections:
                    await _service.Client.CloseAllConnectionsAsync(closeAllConnections.Excluded, closeAllConnections.Reason).ConfigureAwait(false);
                    break;
                case CloseClientConnectionAction closeClientConnection:
                    await _service.Client.CloseConnectionAsync(closeClientConnection.ConnectionId, closeClientConnection.Reason).ConfigureAwait(false);
                    break;
                case CloseGroupConnectionsAction closeGroupConnections:
                    await _service.Client.CloseGroupConnectionsAsync(closeGroupConnections.Group, closeGroupConnections.Excluded, closeGroupConnections.Reason).ConfigureAwait(false);
                    break;
                case GrantPermissionAction grantPermission:
                    await _service.Client.GrantPermissionAsync(grantPermission.Permission, grantPermission.ConnectionId, grantPermission.TargetName).ConfigureAwait(false);
                    break;
                case RevokePermissionAction revokePermission:
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
