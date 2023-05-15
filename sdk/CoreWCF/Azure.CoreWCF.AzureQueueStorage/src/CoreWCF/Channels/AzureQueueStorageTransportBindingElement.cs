// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common;
using CoreWCF.Queue.Common.Configuration;

namespace Azure.Storage.CoreWCF.Channels
{
    /// <summary>
    /// Class for the Queue binding element.
    /// </summary>
    public class AzureQueueStorageTransportBindingElement : QueueBaseTransportBindingElement
    {
        private long _maxReceivedMessageSize;
        private TimeSpan _receiveMessagevisibilityTimeout = TransportDefaults.ReceiveMessagevisibilityTimeout;

        /// <summary>
        /// Creates a new instance of the AzureQueueStorageTransportBindingElement Class using the default protocol.
        /// </summary>
        public AzureQueueStorageTransportBindingElement()
        {
        }

        /// <summary>
        /// Constructor to initialize member variables.
        /// </summary>
        protected AzureQueueStorageTransportBindingElement(AzureQueueStorageTransportBindingElement other) : base(other)
        {
            MaxReceivedMessageSize = other.MaxReceivedMessageSize;
        }

        /// <summary>
        /// overridden method to clone binding element.
        /// </summary>
        public override BindingElement Clone()
        {
            return new AzureQueueStorageTransportBindingElement();
        }

        /// <summary>
        /// Return property of Binding Context.
        /// </summary>
        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                //throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(nameof(context));
            }

            return base.GetProperty<T>(context);
        }

        /// <summary>
        /// Method to build transport pump from binding context.
        /// </summary>
        public override QueueTransportPump BuildQueueTransportPump(BindingContext context)
        {
            IQueueTransport queueTransport = CreateMyQueueTransport(context);
            return QueueTransportPump.CreateDefaultPump(queueTransport);
        }

        private IQueueTransport CreateMyQueueTransport(BindingContext context)
        {
            var serviceDispatcher = context.BindingParameters.Find<IServiceDispatcher>();
            var serviceProvider = context.BindingParameters.Find<IServiceProvider>();
            return new AzureQueueStorageQueueTransport(serviceDispatcher, serviceProvider, this);
        }

        /// <summary>
        /// Gets the scheme used by the binding, soap.amqp
        /// </summary>
        public override string Scheme
        {
            get { return CurrentVersion.Scheme; }
        }

        /// <summary>
        /// The largest receivable encoded message
        /// </summary>
        public override long MaxReceivedMessageSize
        {
            get { return _maxReceivedMessageSize;  }
            set
            {
                if (value < 0 || value > 8000L)
                {
                    throw new ArgumentOutOfRangeException(nameof(MaxReceivedMessageSize), "MaxReceivedMessageSize must not be more than 64K.");
                }
                _maxReceivedMessageSize = value;
            }
        }

        /// <summary>
        /// Property to set the receive Message Visibility Timeout for the queue.
        /// </summary>
        public TimeSpan MaxReceivedTimeout
        {
            get { return _receiveMessagevisibilityTimeout; }
            set { _receiveMessagevisibilityTimeout = value; }
        }
    }
}
