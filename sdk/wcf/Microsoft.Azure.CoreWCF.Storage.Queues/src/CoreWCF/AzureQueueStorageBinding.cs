// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF.Channels;
using Azure.Storage.Queues;
using CoreWCF.Channels;

namespace Azure.Storage.CoreWCF
{
    /// <summary>
    /// The class that contains the binding elements that specify the protocols, transports,
    /// and message encoders used for communication between clients and services.
    /// </summary>
    public class AzureQueueStorageBinding : Binding
    {
        private TextMessageEncodingBindingElement _textMessageEncodingBindingElement;
        private AzureQueueStorageTransportBindingElement _transport;
        private BinaryMessageEncodingBindingElement _binaryMessageEncodingBindingElement;
        private bool _isInitialized;
        private readonly string _connectionString;
        private readonly string _deadLetterQueueName;

        /// <summary>
        /// Initializes a new instance of the AzureQueueStorageBinding class with the provided Azure Storage Queue
        /// connection string and optional dead letter queue name.
        /// </summary>
        /// <param name="connectionString">A string representing the connection string to the Azure Storage Queue.</param>
        /// <param name="deadLetterQueueName">A string representing the name of the dead letter queue. If not specified,
        /// the default name is "DefaultDeadLetterQueue".</param>
        public AzureQueueStorageBinding(string connectionString, string deadLetterQueueName = "DefaultDeadLetterQueue")
        {
            _connectionString = connectionString;
            _deadLetterQueueName = deadLetterQueueName;
            Initialize();
        }

        /// <summary>
        /// Overidden method to create a collection that contains the binding elements that are part of the current binding.
        /// </summary>
        public override BindingElementCollection CreateBindingElements()
        {
            _transport.MaxReceivedMessageSize = TransportDefaults.DefaultMaxMessageSize;
            _transport.ConnectionString = _connectionString;
            _transport.DeadLetterQueueName = _deadLetterQueueName;

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
        /// Gets the URI scheme that specifies the transport used by the channel and listener
        /// factories that are built by the bindings.
        /// </summary>
        public override string Scheme
        {
            get { return _transport.Scheme; }
        }

        /// <summary>
        /// Gets or sets the maximum encoded message size.
        /// </summary>
        public long MaxMessageSize
        {
            get => _transport.MaxReceivedMessageSize;
            set => _transport.MaxReceivedMessageSize = value;
        }

        /// <summary>
        /// Gets and sets the message encoding.
        /// </summary>
        public AzureQueueStorageMessageEncoding MessageEncoding { get; set; } = AzureQueueStorageMessageEncoding.Text;
    }
}
