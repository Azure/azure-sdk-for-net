// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Filters;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class SubscriptionClient : ServiceBusReceiverClient
    {
        /// <summary>
        /// Gets the path of the corresponding topic.
        /// </summary>
        public string TopicPath { get; }

        /// <summary>
        /// Gets the formatted path of the subscription client.
        /// </summary>
        /// ="EntityNameHelper.FormatSubscriptionPath(string, string)"/>
        public string Path { get; }
        /// <summary>
        ///
        /// </summary>
        protected SubscriptionClient() { }
        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="receiveMode"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SubscriptionClient(string connectionString, ReceiveMode receiveMode)
            : base(connectionString, receiveMode, default(SubscriptionClientOptions))
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="receiveMode"></param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SubscriptionClient(string connectionString,
            ReceiveMode receiveMode,
                                      SubscriptionClientOptions clientOptions)
            : base(connectionString, receiveMode, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="subscriptionName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="receiveMode"></param>
        /// <param name="clientOptions"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="subscriptionName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public SubscriptionClient(string connectionString, string subscriptionName,
            ReceiveMode receiveMode = ReceiveMode.PeekLock, SubscriptionClientOptions clientOptions = default)
            : base(connectionString, subscriptionName, receiveMode, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="subscriptionName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="receiveMode"></param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public SubscriptionClient(
                                      string fullyQualifiedNamespace,
                                      string subscriptionName,
                                      TokenCredential credential,
                                      ReceiveMode receiveMode = ReceiveMode.PeekLock,
                                      SubscriptionClientOptions clientOptions = default)
            : base(fullyQualifiedNamespace, subscriptionName, credential, receiveMode)
        {
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default TrueFilter"/> rule named  RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// Max allowed length of rule name is 50 chars.
        /// </remarks>
        public virtual async Task AddRuleAsync(
            string ruleName, Filter filter, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        public virtual async Task AddRuleAsync(RuleDescription description, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);

        }

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public virtual async Task RemoveRuleAsync(string ruleName, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);

        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        public virtual async IAsyncEnumerable<RuleDescription> GetRulesAsync(
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            await foreach (var ServiceBusMessage in PeekRangeAsync(10).ConfigureAwait(false))
            {
                yield return new RuleDescription();
            }
        }
    }
}
