// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.AQS
{
    /// <summary>
    /// AzureQueueStorage Binding Element.  
    /// Used to configure and construct AzureQueueStorage ChannelFactories.
    /// </summary>
    public class AzureQueueStorageTransportBindingElement
        : TransportBindingElement // to signal that we're a transport
    {
        public AzureQueueStorageTransportBindingElement()
        {
        }

        protected AzureQueueStorageTransportBindingElement(AzureQueueStorageTransportBindingElement other)
            : base(other)
        {
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return (IChannelFactory<TChannel>)(object)new AzureQueueStorageChannelFactory(this, context);
        }

        /// <summary>
        /// Used by higher layers to determine what types of channel factories this
        /// binding element supports. Which in this case is just IOutputChannel.
        /// </summary>
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return (typeof(TChannel) == typeof(IOutputChannel));
        }

        public override string Scheme
        {
            get
            {
                return AzureQueueStorageConstants.Scheme;
            }
        }

        public override BindingElement Clone()
        {
            return new AzureQueueStorageTransportBindingElement(this);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.GetInnerProperty<T>();
        }

        public Azure.Storage.Queues.QueueMessageEncoding QueueMessageEncoding { get; set; }

    }
}
