// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common;
using CoreWCF.Queue.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    /// <summary>
    /// Class that represents Azure Queue Storage transport binding element.
    /// </summary>
    public class AzureQueueStorageTransportBindingElement : QueueBaseTransportBindingElement, ITransportServiceBuilder
    {
        internal const string DummyNetAqsAddress = "net.aqs://tempuri.org/";
        private long _maxReceivedMessageSize;
        private TimeSpan _receiveMessagevisibilityTimeout = TransportDefaults.ReceiveMessagevisibilityTimeout;
        private AzureClientCredentialType _clientCredentialType;
        private TimeSpan _pollingInterval = TimeSpan.FromSeconds(1);
        private QueueMessageEncoding _queueMessageEncoding;
        private string _deadLetterQueueName;

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
            MaxReceivedMessageSize = other.MaxReceivedMessageSize;
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
                return (T)(object)this;
            }

            return base.GetProperty<T>(context);
        }

        /// <summary>
        /// Configures CoreWCF with a dummy net.aqs base address in the case that the endpoint uri is provided in a connection string.
        /// </summary>
        /// <param name="app">The ASP.NET Core application builder for the service</param>
        void ITransportServiceBuilder.Configure(IApplicationBuilder app)
        {
            // When using a ConnectionString, the queue endpoint url could be provided
            // in the connection string so the endpoint Uri passed to AddServiceEndpoint
            // could be the emptry string. In that case, CoreWCF will expect there to be
            // a configured base address for this binding. If there isn't a net.aqs base
            // address already configured, we add a dummy one.
            if (ClientCredentialType == AzureClientCredentialType.ConnectionString)
            {
                var serviceBuilder = app.ApplicationServices.GetRequiredService<IServiceBuilder>();
                if (!serviceBuilder.BaseAddresses.Where(u => u.Scheme == "net.aqs").Any())
                {
                    var dummyBaseAddress = new Uri(DummyNetAqsAddress);
                    serviceBuilder.BaseAddresses.Add(dummyBaseAddress);
                }
            }
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
            return new AzureQueueStorageQueueTransport(context, this);
        }

        /// <summary>
        /// Gets or sets the type of client credential used for authentication when communicating with Azure.
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
        public override string Scheme => "net.aqs";

        /// <summary>
        /// Gets or sets the maximum allowable message size, in bytes, that can be received. The default value is
        /// </summary>
        public override long MaxReceivedMessageSize
        {
            get { return _maxReceivedMessageSize; }
            set
            {
                if (value < 0 || value > 8000L)
                {
                    throw new ArgumentOutOfRangeException(nameof(MaxReceivedMessageSize), SR.MaxReceivedMessageSizeOutOfRange);
                }

                _maxReceivedMessageSize = value;
            }
        }

        /// <summary>
        /// Gets or Sets the receive Message Visibility Timeout for the queue. The default value is 15 minutes.
        /// </summary>
        public TimeSpan MaxReceiveTimeout
        {
            get { return _receiveMessagevisibilityTimeout; }
            set
            {
                if (value < TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(MaxReceiveTimeout), SR.MaxReceiveTimeoutGreaterThanOrEqualToZero);
                _receiveMessagevisibilityTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the Azure Queue Storage dead letter queue.
        /// </summary>
        public string DeadLetterQueueName
        {
            get => _deadLetterQueueName;
            set
            {
                if (!ValidateDeadLetterQueueName(value)) throw new ArgumentException(SR.InvalidDeadLetterQueueName, nameof(value));
                _deadLetterQueueName = value;
            }
        }

        /// <summary>
        /// Gets or sets the queue polling interval. See &lt;a href="https://learn.microsoft.com/azure/storage/queues/storage-performance-checklist#queue-polling-interval"&gt;Performance and scalability checklist for Queue Storage.&lt;/a&gt;
        /// The default value is 1 second;
        /// </summary>
        public TimeSpan PollingInterval
        {
            get => _pollingInterval;
            set
            {
                if (value <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(PollingInterval), SR.PollingIntervalMustBePositive);
                _pollingInterval = value;
            }
        }

        /// <summary>
        /// Gets the QueueMessageEncoding for the transport.
        /// </summary>
        public QueueMessageEncoding QueueMessageEncoding
        {
            get => _queueMessageEncoding;
            set
            {
                if (value != QueueMessageEncoding.None && value != QueueMessageEncoding.Base64) throw new ArgumentOutOfRangeException(nameof(QueueMessageEncoding));
                _queueMessageEncoding = value;
            }
        }

        private bool ValidateDeadLetterQueueName(string deadLetterQueueName)
        {
            if (deadLetterQueueName == null)
                return false;

            if (deadLetterQueueName.Length < 3 || deadLetterQueueName.Length > 63)
                return false;

            if (deadLetterQueueName[0] == '-' || deadLetterQueueName[deadLetterQueueName.Length - 1] == '-')
                return false;

            bool previousDash = false;
            for (int i = 0; i < deadLetterQueueName.Length; i++)
            {
                if (deadLetterQueueName[i] == '-')
                {
                    if (previousDash) return false;
                    previousDash = true;
                    continue;
                }

                if (!(char.IsLower(deadLetterQueueName[i]) || char.IsDigit(deadLetterQueueName[i])))
                    return false;

                previousDash = false;
            }

            return true;
        }
    }
}
