// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using System;
using System.ServiceModel.Channels;

namespace Microsoft.WCF.Azure.StorageQueues.Channels
{
    /// <summary>
    /// Class that represents Azure Queue Storage transport binding element.
    /// </summary>
    public class AzureQueueStorageTransportBindingElement : TransportBindingElement
    {
        private AzureClientCredentialType _clientCredentialType;

        /// <summary>
        /// Creates a new instance of the AzureQueueStorageTransportBindingElement Class.
        /// </summary>
        public AzureQueueStorageTransportBindingElement()
        {
            ClientCredentialType = AzureClientCredentialType.Default;
        }

        /// <summary>
        /// Creates a new instance of this class from an existing instance.
        /// </summary>
        protected AzureQueueStorageTransportBindingElement(AzureQueueStorageTransportBindingElement other) : base(other)
        {
            ClientCredentialType = other.ClientCredentialType;
            QueueMessageEncoding = other.QueueMessageEncoding;
        }

        /// <summary>
        /// Overridden method to build channel factory from binding context.
        /// </summary>
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
            return typeof(TChannel) == typeof(IOutputChannel);
        }

        /// <summary>
        /// Gets or sets the type of client credential used for authentication.
        /// </summary>
        /// <value>The client credential type.</value>
        public AzureClientCredentialType ClientCredentialType
        {
            get { return _clientCredentialType; }
            set
            {
                if (!AzureClientCredentialTypeHelper.IsDefined(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _clientCredentialType = value;
            }
        }

        /// <summary>
        /// Gets the URI scheme for the transport.
        /// </summary>
        public override string Scheme => AzureQueueStorageConstants.Scheme;

        /// <summary>
        /// Overridden method to return a copy of the binding AzureQueueStorageTransportBindingElement object.
        /// </summary>
        public override BindingElement Clone() => new AzureQueueStorageTransportBindingElement(this);

        /// <summary>
        /// Gets a property from the specified BindingContext.
        /// </summary>
        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.GetInnerProperty<T>();
        }

        /// <summary>
        /// Gets the QueueMessageEncoding for the transport.
        /// </summary>
        public QueueMessageEncoding QueueMessageEncoding { get; set; }
    }
}
