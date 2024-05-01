// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Microsoft.WCF.Azure.StorageQueues.Channels;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.WCF.Azure.StorageQueues
{
    /// <summary>
    /// The class that contains the binding elements that specify the protocols, transports,
    /// and message encoders used for communication between clients and services.
    /// </summary>
    public class AzureQueueStorageBinding : Binding
    {
        private AzureQueueStorageTransportBindingElement _transport;
        private TextMessageEncodingBindingElement _textMessageEncodingBindingElement;
        private BinaryMessageEncodingBindingElement _binaryMessageEncodingBindingElement;
        private bool _isInitialized;

        /// <summary>
        /// Initializes a new instance of the AzureQueueStorageBinding class.
        /// </summary>
        public AzureQueueStorageBinding()
        {
            Security = new AzureQueueStorageSecurity();
            Initialize();
        }

        /// <summary>
        /// Gets the URI scheme that specifies the transport used by the channel and listener
        /// factories that are built by the bindings.
        /// </summary>
        public override string Scheme => _transport.Scheme;

        /// <summary>
        /// Gets or sets the security used with this binding.
        /// </summary>
        public AzureQueueStorageSecurity Security { get; set; }

        /// <summary>
        /// Overidden method to create a collection that contains the binding elements that are part of the current binding.
        /// </summary>
        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection elements = new();

            switch (MessageEncoding)
            {
                case AzureQueueStorageMessageEncoding.Binary:
                    elements.Add(_binaryMessageEncodingBindingElement);
                    _transport.QueueMessageEncoding = QueueMessageEncoding.Base64;
                    break;
                case AzureQueueStorageMessageEncoding.Text:
                    elements.Add(_textMessageEncodingBindingElement);
                    _transport.QueueMessageEncoding = QueueMessageEncoding.None;
                    break;
                default:
                    elements.Add(_textMessageEncodingBindingElement);
                    _transport.QueueMessageEncoding = QueueMessageEncoding.None;
                    break;
            }
            Security.Transport.ConfigureTransportSecurity(_transport);
            elements.Add(_transport);

            return elements;
        }

        private void Initialize()
        {
            if (!_isInitialized)
            {
                _transport = new AzureQueueStorageTransportBindingElement();
                _textMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
                _binaryMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
                _isInitialized = true;
            }
        }

        /// <summary>
        /// Gets and sets the message encoding.
        /// </summary>
        public AzureQueueStorageMessageEncoding MessageEncoding { get; set; } = AzureQueueStorageMessageEncoding.Binary;
    }
}
