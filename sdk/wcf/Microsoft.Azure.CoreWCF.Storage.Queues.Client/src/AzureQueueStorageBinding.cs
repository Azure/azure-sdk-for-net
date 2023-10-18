// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ServiceModel.AQS
{
    public class AzureQueueStorageBinding : Binding
    {
        private AzureQueueStorageTransportBindingElement _transport;
        private TextMessageEncodingBindingElement _textMessageEncodingBindingElement;
        private BinaryMessageEncodingBindingElement _binaryMessageEncodingBindingElement;
        private bool _isInitialized;

        public AzureQueueStorageBinding(AzureQueueStorageMessageEncoding azureQueueStorageMessageEncoding)
        {
            this.MessageEncoding = azureQueueStorageMessageEncoding;
            Initialize();
        }

        public override string Scheme { get { return "net.aqs"; } }

        public EnvelopeVersion SoapVersion
        {
            get { return EnvelopeVersion.Soap12; }
        }

        /// <summary>
        /// Create the set of binding elements that make up this binding. 
        /// NOTE: order of binding elements is important.
        /// </summary>
        /// <returns></returns>
        public override BindingElementCollection CreateBindingElements()
        {
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

        public AzureQueueStorageMessageEncoding MessageEncoding { get; set; } = AzureQueueStorageMessageEncoding.Text;
    }
}
