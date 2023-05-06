// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Amqp
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpSender" />
    ///   class.
    /// </summary>
    ///
    public class AmqpSenderTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpSender.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncBuildsAnAmqpEventBatchWithTheOptions()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 512 };
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            sender
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureSenderStateAsync",
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaxMessageSize(sender.Object, options.MaxSizeInBytes.Value + 982))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using TransportMessageBatch batch = await sender.Object.CreateMessageBatchAsync(options, default);

            Assert.That(batch, Is.Not.Null, "The created batch should be populated.");
            Assert.That(batch, Is.InstanceOf<AmqpMessageBatch>(), $"The created batch should be an {nameof(AmqpMessageBatch)}.");
            Assert.That(GetEventBatchOptions((AmqpMessageBatch)batch), Is.SameAs(options), "The provided options should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchDoesNotDisposeTheEventDataBatch()
        {
            var expectedMaximumSize = 512;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            sender
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureSenderStateAsync",
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaxMessageSize(sender.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            sender
                .Protected()
                .Setup<Task>("SendBatchInternalAsync",
                    ItExpr.IsAny<IReadOnlyCollection<AmqpMessage>>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            using TransportMessageBatch transportBatch = await sender.Object.CreateMessageBatchAsync(options, default);

            using var batch = new ServiceBusMessageBatch(transportBatch, new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock"));
            batch.TryAddMessage(new ServiceBusMessage(new byte[] { 0x15 }));

            await sender.Object.SendBatchAsync(batch, CancellationToken.None);

            Assert.That(batch, Is.Not.Null, "The batch should not have been set to null.");
            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new byte[] { 0x23 })), Throws.Nothing, "The batch should not have been disposed.");
        }

        /// <summary>
        ///   Gets set of batch options that a <see cref="AmqpMessageBatch" /> is using
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="batch">The batch to retrieve the source policy from.</param>
        ///
        /// <returns>The batch options.</returns>
        ///
        private static CreateMessageBatchOptions GetEventBatchOptions(AmqpMessageBatch batch) =>
            (CreateMessageBatchOptions)
                typeof(AmqpMessageBatch)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

        /// <summary>
        ///   Sets the max message size for the given sender, using its
        ///   private accessor.
        /// </summary>
        ///
        private static void SetMaxMessageSize(AmqpSender target, long value)
        {
            typeof(AmqpSender)
                .GetProperty("MaxMessageSize", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty)
                .SetValue(target, value);
        }

        /// <summary>
        ///    Creates an <see cref="AmqpSender"/> for use with test cases.
        /// </summary>
        /// <returns>An <see cref="Amqp"/> with arbitrary configuration.</returns>
        private AmqpSender CreatSender() =>
            new AmqpSender(
                "somePath",
                Mock.Of<AmqpConnectionScope>(),
                Mock.Of<ServiceBusRetryPolicy>(),
                "someIdentifier",
                Mock.Of<AmqpMessageConverter>());
    }
}
