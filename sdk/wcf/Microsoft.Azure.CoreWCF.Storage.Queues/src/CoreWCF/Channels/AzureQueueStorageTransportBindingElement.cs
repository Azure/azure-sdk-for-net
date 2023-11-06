// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common;
using CoreWCF.Queue.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.Storage.CoreWCF.Channels
{
    /// <summary>
    /// Class that represents Azure Queue Storage transport binding element.
    /// </summary>
    public class AzureQueueStorageTransportBindingElement : QueueBaseTransportBindingElement, ITransportServiceBuilder
    {
        private long _maxReceivedMessageSize;
        private TimeSpan _receiveMessagevisibilityTimeout = TransportDefaults.ReceiveMessagevisibilityTimeout;

        /// <summary>
        /// Creates a new instance of the AzureQueueStorageTransportBindingElement Class.
        /// </summary>
        public AzureQueueStorageTransportBindingElement()
        {
        }

        /// <summary>
        /// Creates a new instance of this class from an existing instance.
        /// </summary>
        protected AzureQueueStorageTransportBindingElement(AzureQueueStorageTransportBindingElement other) : base(other)
        {
            MaxReceivedMessageSize = other.MaxReceivedMessageSize;
            ConnectionString = other.ConnectionString;
            QueueUri = other.QueueUri;
            DeadLetterQueueName = other.DeadLetterQueueName;
            PollingInterval = other.PollingInterval;
            QueueMessageEncoding = other.QueueMessageEncoding;
        }

        /// <summary>
        /// Overridden method to return a copy of the binding AzureQueueStorageTransportBindingElement object.
        /// </summary>
        public override BindingElement Clone()
        {
            return new AzureQueueStorageTransportBindingElement();
        }

        /// <summary>
        /// Gets a property from the specified BindingContext.
        /// </summary>
        public override T GetProperty<T>(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (typeof(T) == typeof(ITransportServiceBuilder))
            {
                return (T)(object) this;
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

        void ITransportServiceBuilder.Configure(IApplicationBuilder app)
        {
            var serviceBuilder = app.ApplicationServices.GetRequiredService<IServiceBuilder>();
            Uri baseAddress = AzureQueueStorageChannelHelpers.CreateEndpointUriFromConnectionString(ConnectionString);
            if (!serviceBuilder.BaseAddresses.Contains(baseAddress))
            {
                serviceBuilder.BaseAddresses.Add(baseAddress);
            }
        }

        /// <summary>
        /// Gets the URI scheme for the transport.
        /// </summary>
        public override string Scheme
        {
            get { return CurrentVersion.Scheme; }
        }

        /// <summary>
        /// Gets or sets the maximum allowable message size, in bytes, that can be received.
        /// </summary>
        public override long MaxReceivedMessageSize
        {
            get { return _maxReceivedMessageSize; }
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
        /// Gets or Sets the receive Message Visibility Timeout for the queue.
        /// </summary>
        public TimeSpan MaxReceivedTimeout
        {
            get { return _receiveMessagevisibilityTimeout; }
            set { _receiveMessagevisibilityTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the connection string of Azure queue Storage.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets uri of Azure queue Storage.
        /// </summary>
        public Uri QueueUri { get; set; }

        /// <summary>
        /// Gets or sets name of Azure queue Storage dead letter queue.
        /// </summary>
        public string DeadLetterQueueName { get; set; }

        /// <summary>
        /// Gets or sets name of Azure queue Storage dead letter queue.
        /// https://learn.microsoft.com/en-us/azure/storage/queues/storage-performance-checklist#queue-polling-interval
        /// </summary>
        public TimeSpan PollingInterval { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets the QueueMessageEncoding for the transport.
        /// </summary>
        public QueueMessageEncoding QueueMessageEncoding { get; set; }
    }
}
