// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The WebPubSubService PubSub client.
    /// </summary>
    [SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "WebPubSub clients are Websocket based and don't use ClientOptions functionality")]
    [SuppressMessage("Usage", "AZC0004:DO provide both asynchronous and synchronous variants for all service methods.", Justification = "Synchronous methods doesn't make sense in the scenario of WebPubSub client")]
    [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "WebPubSubClient is not a HTTP-based client.")]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "We don't want user to use client within a using block")]
    public class WebPubSubClient
    {
        /// <summary>
        /// The connection ID of the client. The ID is assigned when the client connects.
        /// </summary>
        public string ConnectionId { get; }

        /// <summary>
        /// Initializes a Web PubSub client.
        /// </summary>
        /// <param name="clientAccessUri">The uri to connect to the service.</param>
        public WebPubSubClient(Uri clientAccessUri) : this(clientAccessUri, null)
        {
        }

        /// <summary>
        /// Initializes a Web PubSub client.
        /// </summary>
        /// <param name="clientAccessUri">The uri to connect to the service.</param>
        /// <param name="options">A option for the client.</param>
        public WebPubSubClient(Uri clientAccessUri, WebPubSubClientOptions options) : this(new WebPubSubClientCredential(clientAccessUri), options)
        {
        }

        /// <summary>
        /// Initializes a Web PubSub client.
        /// </summary>
        /// <param name="credential">A uri provider that will be called to return the uri for each connecting or reconnecting.</param>
        /// <param name="options">A option for the client.</param>
        public WebPubSubClient(WebPubSubClientCredential credential, WebPubSubClientOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor for mock.
        /// </summary>
        protected WebPubSubClient()
        {
        }

        /// <summary>
        /// Start connecting to the service.
        /// </summary>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns></returns>
        public virtual Task StartAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop the client.
        /// </summary>
        /// <returns></returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Task StopAsync()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop and close the client to the service
        /// </summary>
        /// <returns></returns>
#pragma warning disable AZC0003 // DO make service methods virtual.
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public ValueTask DisposeAsync()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
#pragma warning restore AZC0003 // DO make service methods virtual.
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop and close the client to the service
        /// </summary>
        protected virtual ValueTask DisposeAsyncCore()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Join the target group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="ackId">An optional ack id. It's generated by SDK if not assigned.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation.</returns>
        public virtual Task<WebPubSubResult> JoinGroupAsync(string group, ulong? ackId = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Leave the target group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="ackId">An optional ack id. It's generated by SDK if not assigned.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation</returns>
        public virtual Task<WebPubSubResult> LeaveGroupAsync(string group, ulong? ackId = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publish data to group and wait for the ack.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="content">The data content.</param>
        /// <param name="dataType">The data type.</param>
        /// <param name="noEcho">If set to true, this message is not echoed back to the same connection. If not set, the default value is false.</param>
        /// <param name="fireAndForget">If set to true, the service won't return ack for this message. The return value will be Task of null </param>
        /// <param name="ackId">The ack-id for the operation. The message with the same ack-id is treated as the same message. Leave it omitted to generate by library.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation</returns>
        public virtual Task<WebPubSubResult> SendToGroupAsync(string group, BinaryData content, WebPubSubDataType dataType, ulong? ackId = null, bool noEcho = false, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send custom event and wait for the ack.
        /// </summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="content">The data content.</param>
        /// <param name="dataType">The data type.</param>
        /// <param name="ackId">The ack-id for the operation. The message with the same ack-id is treated as the same message. Leave it omitted to generate by library.</param>
        /// <param name="fireAndForget">If set to true, the service won't return ack for this message. The return value will be Task of null </param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>The ack for the operation</returns>
        public virtual Task<WebPubSubResult> SendEventAsync(string eventName, BinaryData content, WebPubSubDataType dataType, ulong? ackId = null, bool fireAndForget = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// An event triggered when the connection is connected
        /// </summary>
        public event Func<WebPubSubConnectedEventArgs, Task> Connected;

        /// <summary>
        /// An event triggered when the connection is disconnected
        /// </summary>
        public event Func<WebPubSubDisconnectedEventArgs, Task> Disconnected;

        /// <summary>
        /// An event triggered when the connection is stopped
        /// </summary>
        public event Func<WebPubSubStoppedEventArgs, Task> Stopped;

        /// <summary>
        /// A event triggered when received server data messages.
        /// </summary>
        public event Func<WebPubSubServerMessageEventArgs, Task> ServerMessageReceived;

        /// <summary>
        /// A event triggered when received group data messages.
        /// </summary>
        public event Func<WebPubSubGroupMessageEventArgs, Task> GroupMessageReceived;

        /// <summary>
        /// A event triggered when rejoin group failed in reconnection.
        /// </summary>
        public event Func<WebPubSubRejoinGroupFailedEventArgs, Task> RejoinGroupFailed;
    }
}
