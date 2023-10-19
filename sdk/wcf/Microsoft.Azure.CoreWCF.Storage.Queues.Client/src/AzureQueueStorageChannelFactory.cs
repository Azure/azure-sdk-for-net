// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Azure.Storage.WCF.Channels
{
    /// <summary>
    /// IChannelFactory implementation for AzureQueueStorage.
    /// </summary>
    internal class AzureQueueStorageChannelFactory : ChannelFactoryBase<IOutputChannel>
    {
        #region member_variables
        private BufferManager _bufferManager;
        private MessageEncoderFactory _messageEncoderFactory = null;
        #endregion

        public AzureQueueStorageChannelFactory(AzureQueueStorageTransportBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            this._bufferManager = BufferManager.CreateBufferManager(bindingElement.MaxBufferPoolSize, int.MaxValue);
        }

        public BufferManager BufferManager
        {
            get
            {
                return this._bufferManager;
            }
        }

        public MessageEncoderFactory MessageEncoderFactory
        {
            get
            {
                return this._messageEncoderFactory;
            }
        }

        public override T GetProperty<T>()
        {
            T messageEncoderProperty = this.MessageEncoderFactory.Encoder.GetProperty<T>();
            if (messageEncoderProperty != null)
            {
                return messageEncoderProperty;
            }

            if (typeof(T) == typeof(MessageVersion))
            {
                return (T)(object)this.MessageEncoderFactory.Encoder.MessageVersion;
            }

            return base.GetProperty<T>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return Task.CompletedTask.ToApm(callback,state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            result.ToApmEnd();
        }

        /// <summary>
        /// Create a new Azure Queue Storage Channel. Supports IOutputChannel.
        /// </summary>
        /// <param name="remoteAddress">The address of the remote endpoint</param>
        /// <param name="via">The via address.</param>
        /// <returns></returns>
        protected override IOutputChannel OnCreateChannel(EndpointAddress remoteAddress, Uri via)
        {
            return new AzureQueueStorageOutputChannel(this, remoteAddress, via, MessageEncoderFactory.Encoder);
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            this._bufferManager.Clear();
        }
    }
}
