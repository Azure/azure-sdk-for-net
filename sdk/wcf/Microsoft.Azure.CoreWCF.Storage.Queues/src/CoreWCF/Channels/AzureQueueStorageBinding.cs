// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF.Channels;

namespace Azure.Storage.CoreWCF.Channels
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
        private string _connectionString;
        private string _queueName;
        private string _deadLetterQueueName;

        /// <summary>
        /// Initializes a new instance of the AzureQueueStorageBinding class with the specified parameters.
        /// </summary>
        public AzureQueueStorageBinding(string connectionString, string queueName = "", string deadLetterQueueName = "DefaultDeadLetterQueue")
        {
            _connectionString = connectionString;
            _queueName = queueName;
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
            _transport.QueueName = _queueName;
            _transport.DeadLetterQueueName = _deadLetterQueueName;

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
