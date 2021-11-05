// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// SubscriptionClient can be used for all basic interactions with a Service Bus Subscription.
    /// </summary>
    /// <example>
    /// Create a new SubscriptionClient
    /// <code>
    /// ISubscriptionClient subscriptionClient = new SubscriptionClient(
    ///     namespaceConnectionString,
    ///     topicName,
    ///     subscriptionName,
    ///     ReceiveMode.PeekLock,
    ///     RetryExponential);
    /// </code>
    ///
    /// Register a message handler which will be invoked every time a message is received.
    /// <code>
    /// subscriptionClient.RegisterMessageHandler(
    ///        async (message, token) =&gt;
    ///        {
    ///            // Process the message
    ///            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
    ///
    ///            // Complete the message so that it is not received again.
    ///            // This can be done only if the subscriptionClient is opened in ReceiveMode.PeekLock mode.
    ///            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
    ///        },
    ///        async (exceptionEvent) =&gt;
    ///        {
    ///            // Process the exception
    ///            Console.WriteLine("Exception = " + exceptionEvent.Exception);
    ///            return Task.CompletedTask;
    ///        });
    /// </code>
    /// </example>
    /// <remarks>Use <see cref="MessageReceiver"/> for advanced set of functionality.</remarks>
    public interface ISubscriptionClient : IReceiverClient
    {
        /// <summary>
        /// Gets the path of the topic, for this subscription.
        /// </summary>
        string TopicPath { get; }

        /// <summary>
        /// Gets the name of subscription.
        /// </summary>
        string SubscriptionName { get; }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that will decide filter which messages from the topic should reach the subscription.
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        Task AddRuleAsync(string ruleName, Filter filter);

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that will decide filter which messages from the topic should reach the subscription.
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        Task AddRuleAsync(RuleDescription description);

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        Task RemoveRuleAsync(string ruleName);

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        Task<IEnumerable<RuleDescription>> GetRulesAsync();

        /// <summary>
        /// Receive session messages continuously from the subscription. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{T1,T2,T3,TResult}"/>) is awaited on every time a new message is received by the subscription client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{IMessageSession, Message, CancellationToken, Task}"/> that processes messages.
        /// <see cref="IMessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="Message"/></param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.
        /// Use <see cref="RegisterSessionHandler(Func{IMessageSession,Message,CancellationToken,Task}, SessionHandlerOptions)"/> to configure the settings of the pump.</remarks>
        void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler);

        /// <summary>
        /// Receive session messages continuously from the subscription. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{IMessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the subscription client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{IMessageSession, Message, CancellationToken, Task}"/> that processes messages.
        /// <see cref="IMessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="Message"/></param>
        /// <param name="sessionHandlerOptions">Options used to configure the settings of the session pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate. </remarks>
        void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, SessionHandlerOptions sessionHandlerOptions);

        /// <summary>
        /// Unregister session handler from the receiver if there is an active session handler registered. This operation waits for the completion
        /// of inflight receive and session handling operations to finish and unregisters future receives on the session handler which previously 
        /// registered. 
        /// </summary>
        /// <param name="inflightSessionHandlerTasksWaitTimeout"> is the maximum waitTimeout for inflight session handling tasks.</param>
        Task UnregisterSessionHandlerAsync(TimeSpan inflightSessionHandlerTasksWaitTimeout);
    }
}