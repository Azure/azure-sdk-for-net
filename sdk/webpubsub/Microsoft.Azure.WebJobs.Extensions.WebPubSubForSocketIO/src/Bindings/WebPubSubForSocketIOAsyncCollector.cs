// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.BaseActions;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOAsyncCollector : IAsyncCollector<SocketIOAction>
    {
        private readonly IWebPubSubForSocketIOService _service;
        private readonly SocketLifetimeStore _socketLifetimeStore;

        internal WebPubSubForSocketIOAsyncCollector(IWebPubSubForSocketIOService service, SocketLifetimeStore socketLifetimeStore)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _socketLifetimeStore = socketLifetimeStore ?? throw new ArgumentNullException(nameof(socketLifetimeStore));
        }

        public async Task AddAsync(SocketIOAction item, CancellationToken cancellationToken = default)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var requestContext = new RequestContext { CancellationToken = cancellationToken };

            switch (item)
            {
                case AddSocketToRoomAction addToRoom:
                    {
                        AssertNotNullOrEmpty(addToRoom.Room, nameof(addToRoom.Room));
                        AssertNotNullOrEmpty(addToRoom.Namespace, nameof(addToRoom.Namespace));
                        AssertNotNullOrEmpty(addToRoom.SocketId, nameof(addToRoom.SocketId));

                        if (!_socketLifetimeStore.TryFindConnectionIdBySocketId(addToRoom.SocketId, out var connId, out var @namespace))
                        {
                            await SendToService(new AddConnectionsToGroupsAction
                            {
                                Groups = new string[] { Utilities.GetGroupNameByNamespaceRoom(addToRoom.Namespace, addToRoom.Room) },
                                // SocketId is also a room name.
                                Filter = Utilities.GenerateRoomFilter(addToRoom.Namespace, addToRoom.SocketId, false),
                            }, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            // Use AddConnectionToGroup is faster if we can.
                            await SendToService(new AddConnectionToGroupAction
                            {
                                ConnectionId = connId,
                                Group = Utilities.GetGroupNameByNamespaceRoom(@namespace, addToRoom.Room),
                            }, cancellationToken).ConfigureAwait(false);
                        }
                        break;
                    }
                case RemoveSocketFromRoomAction removeFromRoom:
                    {
                        AssertNotNullOrEmpty(removeFromRoom.Room, nameof(removeFromRoom.Room));
                        AssertNotNullOrEmpty(removeFromRoom.Namespace, nameof(removeFromRoom.Namespace));
                        AssertNotNullOrEmpty(removeFromRoom.SocketId, nameof(removeFromRoom.SocketId));

                        if (!_socketLifetimeStore.TryFindConnectionIdBySocketId(removeFromRoom.SocketId, out var connId, out var @namespace))
                        {
                            await SendToService(new RemoveConnectionsFromGroupsAction
                            {
                                Groups = new string[] { Utilities.GetGroupNameByNamespaceRoom(removeFromRoom.Namespace, removeFromRoom.Room) },
                                // SocketId is also a room name.
                                Filter = Utilities.GenerateRoomFilter(removeFromRoom.Namespace, removeFromRoom.SocketId, false),
                            }, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            await SendToService(new RemoveConnectionFromGroupAction
                            {
                                ConnectionId = connId,
                                Group = Utilities.GetGroupNameByNamespaceRoom(@namespace, removeFromRoom.Room),
                            }, cancellationToken).ConfigureAwait(false);
                        }
                        break;
                    }
                case DisconnectSocketsAction disconnect:
                    {
                        AssertNotNullOrEmpty(disconnect.Namespace, nameof(disconnect.Namespace));

                        var data = string.Empty;
                        if (disconnect.CloseUnderlyingConnection)
                        {
                            data = JsonConvert.SerializeObject(new { close = true });
                        }

                        await SendToService(new SendToAllAction
                        {
                            Data = BinaryData.FromBytes(EngineIOProtocol.EncodePacket(new SocketIOPacket(SocketIOPacketType.Disconnect, disconnect.Namespace, data))),
                            DataType = WebPubSubDataType.Text,
                            Filter = Utilities.GenerateRoomFilter(disconnect.Namespace, disconnect.Rooms, null, true),
                        }, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                case SendToNamespaceAction sendToNamespace:
                    {
                        AssertNotNullOrEmpty(sendToNamespace.Namespace, nameof(sendToNamespace.Namespace));
                        AssertNotNullOrEmpty(sendToNamespace.EventName, nameof(sendToNamespace.EventName));

                        var dataList = GetData(sendToNamespace.EventName, sendToNamespace.Parameters);
                        var data = EngineIOProtocol.EncodePacket(new SocketIOPacket(SocketIOPacketType.Event,
                            sendToNamespace.Namespace,
                            JsonConvert.SerializeObject(dataList)));
                        await SendToService(new SendToGroupAction
                        {
                            Data = BinaryData.FromBytes(data),
                            DataType = WebPubSubDataType.Text,
                            Group = Utilities.GetGroupNameByNamespace(sendToNamespace.Namespace),
                            Filter = Utilities.GenerateRoomFilter(sendToNamespace.Namespace, null, sendToNamespace.ExceptRooms, false),
                        }, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                case SendToRoomsAction sendToRoom:
                    {
                        AssertNotNullOrEmpty(sendToRoom.Namespace, nameof(sendToRoom.Namespace));
                        AssertNotNullOrEmpty(sendToRoom.Rooms, nameof(sendToRoom.Rooms));
                        AssertNotNullOrEmpty(sendToRoom.EventName, nameof(sendToRoom.EventName));

                        var dataList = GetData(sendToRoom.EventName, sendToRoom.Parameters);
                        var data = EngineIOProtocol.EncodePacket(new SocketIOPacket(SocketIOPacketType.Event,
                            sendToRoom.Namespace,
                            JsonConvert.SerializeObject(dataList)));

                        if (sendToRoom.Rooms.Count == 1)
                        {
                            await SendToService(new SendToGroupAction
                            {
                                Data = BinaryData.FromBytes(data),
                                DataType = WebPubSubDataType.Text,
                                Group = Utilities.GetGroupNameByNamespaceRoom(sendToRoom.Namespace, sendToRoom.Rooms[0]),
                                Filter = Utilities.GenerateRoomFilter(sendToRoom.Namespace, null, sendToRoom.ExceptRooms, false),
                            }, cancellationToken).ConfigureAwait(false);
                            break;
                        }
                        else
                        {
                            await SendToService(new SendToAllAction
                            {
                                Data = BinaryData.FromBytes(data),
                                DataType = WebPubSubDataType.Text,
                                Filter = Utilities.GenerateRoomFilter(sendToRoom.Namespace, sendToRoom.Rooms, sendToRoom.ExceptRooms, true),
                            }, cancellationToken).ConfigureAwait(false);
                            break;
                        }
                    }
                case SendToSocketAction sendToSocket:
                    {
                        AssertNotNullOrEmpty(sendToSocket.Namespace, nameof(sendToSocket.Namespace));
                        AssertNotNullOrEmpty(sendToSocket.EventName, nameof(sendToSocket.EventName));
                        AssertNotNullOrEmpty(sendToSocket.SocketId, nameof(sendToSocket.SocketId));

                        var dataList = GetData(sendToSocket.EventName, sendToSocket.Parameters);
                        var data = EngineIOProtocol.EncodePacket(new SocketIOPacket(SocketIOPacketType.Event,
                            sendToSocket.Namespace,
                            JsonConvert.SerializeObject(dataList)));

                        if (!_socketLifetimeStore.TryFindConnectionIdBySocketId(sendToSocket.SocketId, out var connId, out var @namespace))
                        {
                            // If socket is not in local, try to use same-name room for a general send.
                            await SendToService(new SendToGroupAction
                            {
                                Data = BinaryData.FromBytes(data),
                                DataType = WebPubSubDataType.Text,
                                Group = Utilities.GetGroupNameByNamespaceRoom(sendToSocket.Namespace, sendToSocket.SocketId),
                            }, cancellationToken).ConfigureAwait(false);
                            break;
                        }
                        else
                        {
                            await SendToService(new SendToConnectionAction
                            {
                                Data = BinaryData.FromBytes(data),
                                ConnectionId = connId,
                            }, cancellationToken).ConfigureAwait(false);
                            break;
                        }
                    }
                 default:
                    throw new ArgumentException($"Not supported WebPubSubOperation: {item.GetType().Name}.");
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        private async Task SendToService(WebPubSubAction action, CancellationToken cancellationToken)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };

            switch (action)
            {
                case SendToAllAction sendToAll:
                    await _service.Client.SendToAllAsync(RequestContent.Create(sendToAll.Data),
                        Utilities.GetContentType(sendToAll.DataType), sendToAll.Excluded, sendToAll.Filter, requestContext).ConfigureAwait(false);
                    break;
                case SendToConnectionAction sendToConnection:
                    await _service.Client.SendToConnectionAsync(sendToConnection.ConnectionId, RequestContent.Create(sendToConnection.Data),
                        Utilities.GetContentType(sendToConnection.DataType), requestContext).ConfigureAwait(false);
                    break;
                case SendToGroupAction sendToGroup:
                    await _service.Client.SendToGroupAsync(sendToGroup.Group, RequestContent.Create(sendToGroup.Data),
                        Utilities.GetContentType(sendToGroup.DataType), sendToGroup.Excluded, sendToGroup.Filter, requestContext).ConfigureAwait(false);
                    break;
                case AddConnectionToGroupAction addConnectionToGroup:
                    await _service.Client.AddConnectionToGroupAsync(addConnectionToGroup.Group, addConnectionToGroup.ConnectionId, requestContext).ConfigureAwait(false);
                    break;
                case RemoveConnectionFromGroupAction removeConnectionFromGroup:
                    await _service.Client.RemoveConnectionFromGroupAsync(removeConnectionFromGroup.Group, removeConnectionFromGroup.ConnectionId, requestContext).ConfigureAwait(false);
                    break;
                case CloseAllConnectionsAction closeAllConnections:
                    await _service.Client.CloseAllConnectionsAsync(closeAllConnections.Excluded, closeAllConnections.Reason, requestContext).ConfigureAwait(false);
                    break;
                case CloseClientConnectionAction closeClientConnection:
                    await _service.Client.CloseConnectionAsync(closeClientConnection.ConnectionId, closeClientConnection.Reason, requestContext).ConfigureAwait(false);
                    break;
                case CloseGroupConnectionsAction closeGroupConnections:
                    await _service.Client.CloseGroupConnectionsAsync(closeGroupConnections.Group, closeGroupConnections.Excluded, closeGroupConnections.Reason, requestContext).ConfigureAwait(false);
                    break;
                case AddConnectionsToGroupsAction addConnectionsToGroupsAction:
                    await _service.Client.AddConnectionsToGroupsAsync(addConnectionsToGroupsAction.Groups, addConnectionsToGroupsAction.Filter, requestContext).ConfigureAwait(false);
                    break;
                case RemoveConnectionsFromGroupsAction removeConnectionsFromGroupsAction:
                    await _service.Client.RemoveConnectionsFromGroupsAsync(removeConnectionsFromGroupsAction.Groups, removeConnectionsFromGroupsAction.Filter, requestContext).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentException($"Not supported WebPubSubOperation: {nameof(action)}.");
            }
        }
        private IList<object> GetData(string eventName, IEnumerable<object> arguments)
        {
            var rst = new List<object> { eventName };
            if (arguments != null)
            {
                rst.AddRange(arguments);
            }
            return rst;
        }

        private void AssertNotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{name} cannot be null or empty.");
            }
        }

        private void AssertNotNullOrEmpty(IEnumerable<string> value, string name)
        {
            if (value == null || value.Count() == 0)
            {
                throw new ArgumentException($"{name} cannot be null or empty.");
            }
        }
    }
}
