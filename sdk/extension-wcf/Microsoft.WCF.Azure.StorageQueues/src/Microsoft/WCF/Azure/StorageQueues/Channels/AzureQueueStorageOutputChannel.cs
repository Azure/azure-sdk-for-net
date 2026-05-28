// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Queues;
using Microsoft.WCF.Azure.Tokens;

namespace Microsoft.WCF.Azure.StorageQueues.Channels
{
    /// <summary>
    /// IOutputChannel implementation for AzureQueueStorage.
    /// </summary>
    internal class AzureQueueStorageOutputChannel : ChannelBase, IOutputChannel
    {
        #region member_variables
        private readonly EndpointAddress _remoteAddress;
        private readonly Uri _via;
        private readonly MessageEncoder _encoder;
        private readonly AzureQueueStorageChannelFactory _parent;
        private QueueClient _queueClient;
        private ArraySegment<byte> _messageBuffer;
        private ChannelParameterCollection _channelParameters;
        private SecurityTokenProviderContainer _tokenProvider;
        #endregion

        public AzureQueueStorageOutputChannel(
            AzureQueueStorageChannelFactory factory,
            EndpointAddress remoteAddress,
            Uri via,
            MessageEncoder encoder,
            AzureQueueStorageTransportBindingElement azureQueueStorageTransportBindingElement)
            : base(factory)
        {
            _remoteAddress = remoteAddress;
            _via = via;
            _encoder = encoder;
            _parent = factory;
            _queueClient = null;
        }

        #region IOutputChannel_Properties
        /// <summary>
        /// Gets the destination of the service to which messages are sent out on the output channel.
        /// </summary>
        EndpointAddress IOutputChannel.RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
        }

        /// <summary>
        /// Gets the URI that contains the transport address to which messages are sent on the output channel.
        /// </summary>
        Uri IOutputChannel.Via
        {
            get
            {
                return _via;
            }
        }
        #endregion

        public override T GetProperty<T>()
        {
            if (typeof(T) == typeof(IOutputChannel))
            {
                return (T)(object)this;
            }

            if (typeof(T) == typeof(ChannelParameterCollection))
            {
                if (State == CommunicationState.Created)
                {
                    lock (ThisLock)
                    {
                        if (_channelParameters == null)
                        {
                            _channelParameters = new ChannelParameterCollection();
                        }
                    }
                }
                return (T)(object)_channelParameters;
            }

            T messageEncoderProperty = _encoder.GetProperty<T>();
            if (messageEncoderProperty != null)
            {
                return messageEncoderProperty;
            }

            return base.GetProperty<T>();
        }

        /// <summary>
        /// Open the channel for use. We do not have any blocking work to perform so this is a no-op
        /// </summary>
        protected override void OnOpen(TimeSpan timeout)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            _tokenProvider = _parent.CreateAndOpenTokenProvider(timeout, _remoteAddress, _via, _channelParameters);
            EnsureQueueClient(timeoutHelper.RemainingTime());
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return OnOpenAsync(timeout).ToApm(callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            result.ToApmEnd();
        }

        private async Task OnOpenAsync(TimeSpan timeout)
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
            _tokenProvider = await _parent.CreateAndOpenTokenProviderAsync(timeout, _remoteAddress, _via, _channelParameters).ConfigureAwait(false);
            await EnsureQueueClientAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
        }

        #region Shutdown
        /// <summary>
        /// Shutdown ungracefully
        /// </summary>
        protected override void OnAbort()
        {
            if (_tokenProvider != null)
            {
                _tokenProvider.Abort();
            }
        }

        /// <summary>
        /// Shutdown gracefully
        /// </summary>
        protected override void OnClose(TimeSpan timeout)
        {
            CloseTokenProviders(timeout);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return OnCloseAsync(timeout).ToApm(callback, state);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            result.ToApmEnd();
        }

        private Task OnCloseAsync(TimeSpan timeout)
        {
            return CloseTokenProviderAsync(timeout);
        }

        private Task CloseTokenProviderAsync(TimeSpan timeout)
        {
            if (_tokenProvider != null)
            {
                return _tokenProvider.CloseAsync(timeout);
            }

            return Task.CompletedTask;
        }

        private void CloseTokenProviders(TimeSpan timeout)
        {
            if (_tokenProvider != null)
            {
                _tokenProvider.Close(timeout);
            }
        }
        #endregion

        #region Send_Synchronous
        public void Send(Message message)
        {
            Send(message, default);
        }

        public void Send(Message message, TimeSpan timeout)
        {
            using CancellationTokenSource cts = new(timeout);

            try
            {
                ArraySegment<byte> messageBuffer = EncodeMessage(message);
                BinaryData binaryData = new(new ReadOnlyMemory<byte>(messageBuffer.Array, messageBuffer.Offset, messageBuffer.Count));
                _queueClient.SendMessage(binaryData, default, default, cts.Token);
            }
            catch (Exception e)
            {
                throw AzureQueueStorageChannelHelpers.ConvertTransferException(e);
            }
            finally
            {
                CleanupBuffer();
            }
        }
        #endregion

        #region Send_Asynchronous
        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            return BeginSend(message, default, callback, state);
        }

        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            AzureQueueStorageChannelHelpers.ThrowIfDisposedOrNotOpen(state);
            return SendAsync(message, timeout).ToApm(callback, state);
        }

        public void EndSend(IAsyncResult result)
        {
            result.ToApmEnd();
        }

        private async Task SendAsync(Message message, TimeSpan timeout)
        {
            CancellationTokenSource cts = new(timeout);

            try
            {
                _messageBuffer = EncodeMessage(message);
                BinaryData binaryData = new(_messageBuffer);
                await _queueClient.SendMessageAsync(binaryData, default, default, cts.Token).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw AzureQueueStorageChannelHelpers.ConvertTransferException(e);
            }
            finally
            {
                CleanupBuffer();
                cts.Dispose();
            }
        }

        private async Task EnsureQueueClientAsync(TimeSpan timeout)
        {
            if (_queueClient == null)
            {
                QueueClient queueClient = await _parent.GetQueueClientAsync(_via, _tokenProvider, timeout).ConfigureAwait(false);
                var channelParameters = GetProperty<ChannelParameterCollection>();
                if (channelParameters is not null)
                {
                    foreach (object obj in channelParameters)
                    {
                        if (obj is Func<QueueClient, QueueClient> queueClientConfigfunc)
                        {
                            var configuredQueueClient = queueClientConfigfunc(queueClient);
                            if (configuredQueueClient != null)
                            {
                                queueClient = configuredQueueClient;
                            }
                        }
                    }
                }

                Interlocked.CompareExchange(ref _queueClient, queueClient, null);
            }
        }

        private void EnsureQueueClient(TimeSpan timeout)
        {
            if (_queueClient == null)
            {
                QueueClient queueClient = _parent.GetQueueClient(_via, _tokenProvider, timeout);
                var channelParameters = GetProperty<ChannelParameterCollection>();
                if (channelParameters is not null)
                {
                    foreach (object obj in channelParameters)
                    {
                        if (obj is Func<QueueClient, QueueClient> queueClientConfigfunc)
                        {
                            var configuredQueueClient = queueClientConfigfunc(queueClient);
                            if (configuredQueueClient != null)
                            {
                                queueClient = configuredQueueClient;
                            }
                        }
                    }
                }

                Interlocked.CompareExchange(ref _queueClient, queueClient, null);
            }
        }
        #endregion

        /// <summary>
        /// Address the Message and serialize it into a byte array.
        /// </summary>
        private ArraySegment<byte> EncodeMessage(Message message)
        {
            try
            {
                _remoteAddress.ApplyTo(message);
                return _encoder.WriteMessage(message, int.MaxValue, _parent.BufferManager);
            }
            finally
            {
                // We have consumed the message by serializing it, so clean up
                message.Close();
            }
        }

        private void CleanupBuffer()
        {
            if (_messageBuffer.Array != null)
            {
                _parent.BufferManager.ReturnBuffer(_messageBuffer.Array);
                _messageBuffer = default;
            }
        }
    }
}
