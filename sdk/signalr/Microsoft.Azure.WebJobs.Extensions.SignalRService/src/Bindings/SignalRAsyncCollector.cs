// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// An SignalR async collector used to send SignalR message or group action.
    /// </summary>
    public class SignalRAsyncCollector<T> : IAsyncCollector<T>
    {
        private readonly IAzureSignalRSender _client;
        private readonly SignalROutputConverter _converter;

        internal SignalRAsyncCollector(IAzureSignalRSender client)
        {
            _client = client;
            _converter = new();
        }

        public async Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var convertItem = _converter.ConvertToSignalROutput(item);

            if (convertItem.GetType() == typeof(SignalRMessage))
            {
                var message = convertItem as SignalRMessage;
                var data = new SignalRData
                {
                    Target = message.Target,
                    Arguments = message.Arguments,
                    Endpoints = message.Endpoints
                };

                if (!string.IsNullOrEmpty(message.ConnectionId))
                {
                    await _client.SendToConnection(message.ConnectionId, data).ConfigureAwait(false);
                }
                else if (!string.IsNullOrEmpty(message.UserId))
                {
                    await _client.SendToUser(message.UserId, data).ConfigureAwait(false);
                }
                else if (!string.IsNullOrEmpty(message.GroupName))
                {
                    await _client.SendToGroup(message.GroupName, data).ConfigureAwait(false);
                }
                else
                {
                    await _client.SendToAll(data).ConfigureAwait(false);
                }
            }
            else if (convertItem.GetType() == typeof(SignalRGroupAction))
            {
                var groupAction = convertItem as SignalRGroupAction;

                if (!string.IsNullOrEmpty(groupAction.ConnectionId))
                {
                    switch (groupAction.Action)
                    {
                        case GroupAction.Add:
                            await _client.AddConnectionToGroup(groupAction).ConfigureAwait(false);
                            break;

                        case GroupAction.Remove:
                            await _client.RemoveConnectionFromGroup(groupAction).ConfigureAwait(false);
                            break;
                    }
                }
                else if (!string.IsNullOrEmpty(groupAction.UserId))
                {
                    switch (groupAction.Action)
                    {
                        case GroupAction.Add:
                            await _client.AddUserToGroup(groupAction).ConfigureAwait(false);
                            break;

                        case GroupAction.Remove:
                            await _client.RemoveUserFromGroup(groupAction).ConfigureAwait(false);
                            break;

                        case GroupAction.RemoveAll:
                            await _client.RemoveUserFromAllGroups(groupAction).ConfigureAwait(false);
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException($"ConnectionId and UserId cannot be null or empty together");
                }
            }
            else
            {
                throw new ArgumentException("Unsupport Binding Type.");
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }
    }
}