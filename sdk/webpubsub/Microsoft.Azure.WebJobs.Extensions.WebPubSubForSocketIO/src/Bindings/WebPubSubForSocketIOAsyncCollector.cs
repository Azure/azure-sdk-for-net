// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.BaseActions;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                        if (!_socketLifetimeStore.TryFindConnectionIdBySocketId(addToRoom.SocketId, out var connId, out var @namespace))
                        {
                            throw new InvalidOperationException($"SocketId {addToRoom.SocketId} not found.");
                        }
                        await SendToService(new AddConnectionToGroupAction
                        {
                            ConnectionId = connId,
                            Group = Utilities.GetGroupNameByNamespaceRoom(@namespace, addToRoom.Room),
                        }, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                case RemoveSocketFromRoomAction removeFromRoom:
                    {
                        if (!_socketLifetimeStore.TryFindConnectionIdBySocketId(removeFromRoom.SocketId, out var connId, out var @namespace))
                        {
                            break;
                        }
                        await SendToService(new RemoveConnectionFromGroupAction
                        {
                            ConnectionId = connId,
                            Group = Utilities.GetGroupNameByNamespaceRoom(@namespace, removeFromRoom.Room),
                        }, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                case DisconnectSocketsAction disconnect:
                    {
                        await SendToService(new SendToAllAction
                        {
                            Data = BinaryData.FromBytes(EngineIOProtocol.EncodePacket(new SocketIOPacket(SocketIOPacketType.Disconnect, disconnect.Namespace, string.Empty))),
                            DataType = WebPubSubDataType.Text,
                            Filter = GenerateRoomFilter(disconnect.Namespace, disconnect.Rooms, null, true),
                        }, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                case SendToNamespaceAction sendToNamespace:
                    {
                        var dataList = GetData(sendToNamespace.EventName, sendToNamespace.Parameters);
                        var data = EngineIOProtocol.EncodePacket(new SocketIOPacket(SocketIOPacketType.Event,
                            sendToNamespace.Namespace,
                            JsonConvert.SerializeObject(dataList)));
                        await SendToService(new SendToGroupAction
                        {
                            Data = BinaryData.FromBytes(data),
                            DataType = WebPubSubDataType.Text,
                            Group = Utilities.GetGroupNameByNamespace(sendToNamespace.Namespace),
                            Filter = GenerateRoomFilter(sendToNamespace.Namespace, null, sendToNamespace.ExceptRooms, false),
                        }, cancellationToken).ConfigureAwait(false);
                        break;
                    }
                case SendToRoomsAction sendToRoom:
                    {
                        if (sendToRoom.Rooms == null || sendToRoom.Rooms.Count == 0)
                        {
                            throw new ArgumentException("Rooms cannot be empty.");
                        }

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
                                Filter = GenerateRoomFilter(sendToRoom.Namespace, null, sendToRoom.ExceptRooms, false),
                            }, cancellationToken).ConfigureAwait(false);
                            break;
                        }
                        else
                        {
                            await SendToService(new SendToAllAction
                            {
                                Data = BinaryData.FromBytes(data),
                                DataType = WebPubSubDataType.Text,
                                Filter = GenerateRoomFilter(sendToRoom.Namespace, sendToRoom.Rooms, sendToRoom.ExceptRooms, true),
                            }, cancellationToken).ConfigureAwait(false);
                            break;
                        }
                    }
                case SendToSocketAction sendToSocket:
                    {
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
                default:
                    throw new ArgumentException($"Not supported WebPubSubOperation: {nameof(action)}.");
            }
        }

        private string GenerateRoomFilter(string @namespace, string room, bool containsNamespace)
        {
            return GenerateRoomFilter(@namespace, new string[] { room }, null, containsNamespace);
        }

        private string GenerateExceptRoomFilter(string @namespace, string exceptRoom, bool containsNamespace)
        {
            return GenerateRoomFilter(@namespace, null, new string[] { exceptRoom }, containsNamespace);
        }

        private string GenerateRoomFilter(string @namespace, IList<string> rooms, IList<string> exceptRooms, bool containsNamespace)
        {
            var filter = containsNamespace ? $"'{Utilities.GetGroupNameByNamespace(@namespace)}' in groups" : string.Empty;
            if ((rooms == null || rooms.Count == 0) && (exceptRooms == null || exceptRooms.Count == 0))
            {
                return filter;
            }

            if (rooms != null && rooms.Count > 0)
            {
                filter = $"'{Utilities.GetGroupNameByNamespaceRoom(@namespace, rooms[0])}' in groups";
                for (int i = 1; i < rooms.Count; i++)
                {
                    filter += $" or '{Utilities.GetGroupNameByNamespaceRoom(@namespace, rooms[i])}' in groups";
                }
            }

            var denyFilter = string.Empty;
            if (exceptRooms != null && exceptRooms.Count > 0)
            {
                denyFilter = $"not ('{Utilities.GetGroupNameByNamespaceRoom(@namespace, exceptRooms[0])}' in groups)";
                for (int i = 1; i < exceptRooms.Count; i++)
                {
                    denyFilter += $" and not ('{Utilities.GetGroupNameByNamespaceRoom(@namespace, exceptRooms[i])}' in groups)";
                }
            }

            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(denyFilter))
            {
                return $"{filter} and {denyFilter}";
            }
            else if (!string.IsNullOrEmpty(filter))
            {
                return filter;
            }
            else
            {
                return denyFilter;
            }
        }

        private IList<object> GetData(string eventName, IEnumerable<object> arguments)
        {
            var rst = new List<object> { eventName };
            rst.AddRange(arguments);
            return rst;
        }
    }
}
