// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.WCF.Channels;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Azure.Storage.WCF
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
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the AzureQueueStorageBinding class with the specified parameters.
        /// </summary>
        public AzureQueueStorageBinding(string connectionString, AzureQueueStorageMessageEncoding azureQueueStorageMessageEncoding)
        {
            _connectionString = connectionString;

            MessageEncoding = azureQueueStorageMessageEncoding;
            Initialize();
        }

        /// <summary>
        /// Gets the URI scheme that specifies the transport used by the channel and listener
        /// factories that are built by the bindings.
        /// </summary>
        public override string Scheme { get { return "net.aqs"; } }

        /// <summary>
        /// Gets the Soap version used by the channel and listener
        /// factories that are built by the bindings.
        /// </summary>
        public EnvelopeVersion SoapVersion
        {
            get { return EnvelopeVersion.Soap12; }
        }

        /// <summary>
        /// Overidden method to create a collection that contains the binding elements that are part of the current binding.
        /// </summary>
        public override BindingElementCollection CreateBindingElements()
        {
            _transport.ConnectionString = _connectionString;

            BindingElementCollection elements = new BindingElementCollection();

            switch (MessageEncoding)
            {
                case AzureQueueStorageMessageEncoding.Binary:
                    elements.Add(_binaryMessageEncodingBindingElement);
                    _transport.QueueMessageEncoding = Azure.Storage.Queues.QueueMessageEncoding.Base64;
                    break;
                case AzureQueueStorageMessageEncoding.Text:
                    elements.Add(_textMessageEncodingBindingElement);
                    _transport.QueueMessageEncoding = Azure.Storage.Queues.QueueMessageEncoding.None;
                    break;
                default:
                    elements.Add(_textMessageEncodingBindingElement);
                    _transport.QueueMessageEncoding = Azure.Storage.Queues.QueueMessageEncoding.None;
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
                _isInitialized = true;
            }
        }

        /// <summary>
        /// Gets and sets the message encoding.
        /// </summary>
        public AzureQueueStorageMessageEncoding MessageEncoding { get; set; } = AzureQueueStorageMessageEncoding.Text;
    }
}
