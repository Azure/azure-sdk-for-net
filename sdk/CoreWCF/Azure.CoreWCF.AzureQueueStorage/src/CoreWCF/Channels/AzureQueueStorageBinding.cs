// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.Storage.Queues;
using CoreWCF.Channels;

namespace Azure.Storage.CoreWCF.Channels
{
    /// <summary>
    /// The class storing binding information
    /// </summary>
    public class AzureQueueStorageBinding : Binding
    {
        private TextMessageEncodingBindingElement _textMessageEncodingBindingElement;
        private AzureQueueStorageTransportBindingElement _transport;
        private BinaryMessageEncodingBindingElement _binaryMessageEncodingBindingElement;
        private bool _isInitialized;

        /// <summary>
        /// Constructor to initialize member variables.
        /// </summary>
        public AzureQueueStorageBinding()
        {
            Initialize();
        }

        /// <summary>
        /// Method to create Binding elements
        /// </summary>
        public override BindingElementCollection CreateBindingElements()
        {
            //_transport.BrokerProtocol = BrokerProtocol;
            _transport.MaxReceivedMessageSize = TransportDefaults.DefaultMaxMessageSize;
            BindingElementCollection elements = new BindingElementCollection();

            switch (MessageEncoding)
            {
                case AzureQueueStorageMessageEncoding.Binary:
                    elements.Add(_binaryMessageEncodingBindingElement);
                    break;
                case AzureQueueStorageMessageEncoding.Text:
                    elements.Add(_textMessageEncodingBindingElement);
                    break;
                default:
                    elements.Add(_textMessageEncodingBindingElement);
                    break;
            }

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
                MaxMessageSize = TransportDefaults.DefaultMaxMessageSize;
                _isInitialized = true;
            }
        }

        /// <summary>
        /// Gets the scheme used by the binding, soap.amqp
        /// </summary>
        public override string Scheme
        {
            get { return _transport.Scheme; }
        }

        /// <summary>
        /// Specifies the maximum encoded message size
        /// </summary>
        public long MaxMessageSize
        {
            get => _transport.MaxReceivedMessageSize;
            set => _transport.MaxReceivedMessageSize = value;
        }

        /// <summary>
        /// Sets the message encoding.
        /// </summary>
        public AzureQueueStorageMessageEncoding MessageEncoding { get; set; } = AzureQueueStorageMessageEncoding.Text;
    }
}
