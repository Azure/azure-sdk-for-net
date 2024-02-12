// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Attribute used to bind a parameter to a ServiceBus Queue message, causing the function to run when a
    /// message is enqueued.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description><see cref="ServiceBusReceivedMessage"/></description></item>
    /// <item><description><see cref="string"/></description></item>
    /// <item><description><see cref="byte"/>array</description></item>
    /// <item><description><see cref="BinaryData"/></description></item>
    /// <item><description>A user-defined type (serialized as JSON)</description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Parameter)]
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [ConnectionProvider(typeof(ServiceBusAccountAttribute))]
    [Binding]
    public sealed class ServiceBusTriggerAttribute : Attribute, IConnectionProvider
    {
        private readonly string _queueName;
        private readonly string _topicName;
        private readonly string _subscriptionName;
        private bool? _autoCompleteMessages;
        private int? _maxMessageBatchSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusTriggerAttribute"/> class.
        /// </summary>
        /// <param name="queueName">The name of the queue to which to bind.</param>
        public ServiceBusTriggerAttribute(string queueName)
        {
            _queueName = queueName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusTriggerAttribute"/> class.
        /// </summary>
        /// <param name="topicName">The name of the topic to bind to.</param>
        /// <param name="subscriptionName">The name of the subscription in <paramref name="topicName"/> to bind to.</param>
        public ServiceBusTriggerAttribute(string topicName, string subscriptionName)
        {
            _topicName = topicName;
            _subscriptionName = subscriptionName;
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the Service Bus connection string.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Gets the name of the queue to bind to.
        /// </summary>
        /// <remarks>When binding to a subscription in a topic, returns <see langword="null"/>.</remarks>
        public string QueueName
        {
            get { return _queueName; }
        }

        /// <summary>
        /// Gets the name of the topic to bind to.
        /// </summary>
        /// <remarks>When binding to a queue, returns <see langword="null"/>.</remarks>
        public string TopicName
        {
            get { return _topicName; }
        }

        /// <summary>
        /// Gets the name of the subscription in <see cref="TopicName"/> to bind to.
        /// </summary>
        /// <remarks>When binding to a queue, returns <see langword="null"/>.</remarks>
        public string SubscriptionName
        {
            get { return _subscriptionName; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether sessions are enabled.
        /// </summary>
        public bool IsSessionsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether trigger should automatically complete the message after successful processing. If not explicitly set, the behavior will be based on the <see cref="ServiceBusOptions.AutoCompleteMessages"/> value.
        /// </summary>
        public bool AutoCompleteMessages
        {
            get
            {
                return _autoCompleteMessages.HasValue ? _autoCompleteMessages.Value : true;
            }
            set
            {
                _autoCompleteMessages = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of messages that will be passed to each function call. This only applies for functions that receive
        /// a batch of messages.
        /// </summary>
        public int MaxMessageBatchSize
        {
            get
            {
                return _maxMessageBatchSize.HasValue ? _maxMessageBatchSize.Value : 1000;
            }
            set
            {
                _maxMessageBatchSize = value;
            }
        }

        /// <summary>
        /// Gets a boolean to check if auto complete messages option was set on the trigger.
        /// Since a nullable property can't be used in the attribute. This is a work around for it.
        /// </summary>
        internal bool IsAutoCompleteMessagesOptionSet { get { return _autoCompleteMessages.HasValue; } }

        /// <summary>
        /// Gets a boolean to check if maximum message batch option was set on the trigger.
        /// Since a nullable property can't be used in the attribute. This is a work around for it.
        /// </summary>
        internal bool IsMaxMessageBatchSizeOptionSet { get { return _maxMessageBatchSize.HasValue; } }

        private string DebuggerDisplay
        {
            get
            {
                if (_queueName != null)
                {
                    return _queueName;
                }
                else
                {
                    return _topicName + "/" + _subscriptionName;
                }
            }
        }
    }
}
