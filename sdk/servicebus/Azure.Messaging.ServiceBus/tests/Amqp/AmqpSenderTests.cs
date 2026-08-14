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
                .Callback(() => SetLinkLimits(sender.Object, options.MaxSizeInBytes.Value + 982))
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
                .Callback(() => SetLinkLimits(sender.Object, expectedMaximumSize))
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
        ///   Sets the link limits tuple for the given sender via its
        ///   private <c>_linkLimits</c> field.  This simulates the effect of
        ///   <see cref="AmqpSender.CreateLinkAndEnsureSenderStateAsync" />.
        /// </summary>
        ///
        private static void SetLinkLimits(AmqpSender target, long maxMessageSize, long? maxBatchSize = null)
        {
            var defaultMaxBatchSize = (long)typeof(AmqpSender)
                .GetField("DefaultMaxBatchSize", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            var effectiveBatchSize = maxBatchSize ?? defaultMaxBatchSize;

            typeof(AmqpSender)
                .GetField("_linkLimits", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(target, (maxMessageSize, Math.Min(maxMessageSize, effectiveBatchSize)));
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

        /// <summary>
        ///   Verifies that concurrent calls to <see cref="AmqpSender.CreateMessageBatchAsync" />
        ///   always observe consistent link limits, preventing the
        ///   <see cref="ArgumentOutOfRangeException"/> caused by a TOCTOU race condition on separate
        ///   <c>MaxMessageSize</c> / <c>MaxBatchSize</c> fields.  The limits tuple is pre-populated
        ///   to validate the design invariant: once <c>_linkLimits</c> is set, all concurrent readers
        ///   observe a consistent pair.
        /// </summary>
        ///
        /// <seealso href="https://github.com/Azure/azure-sdk-for-net/issues/56301"/>
        ///
        [Test]
        public async Task CreateBatchAsyncReturnsConsistentSnapshotUnderConcurrency()
        {
            var expectedMaxMessageSize = 262_144L;
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            // Pre-populate the link limits to simulate a completed link creation.
            // This validates the design invariant: once _linkLimits is set, all concurrent
            // readers observe a consistent (MaxMessageSize, MaxBatchSize) pair.  Reproducing
            // the original TOCTOU during link creation would require timing-dependent thread
            // interleaving that makes for a flaky test; bundling both values in a single tuple
            // eliminates the race by construction.

            SetLinkLimits(sender.Object, expectedMaxMessageSize);

            // Launch multiple concurrent batch creation requests to verify that
            // reads always produce consistent MaxBatchSize values.

            var tasks = new Task<TransportMessageBatch>[8];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(async () =>
                    await sender.Object.CreateMessageBatchAsync(new CreateMessageBatchOptions(), default));
            }

            TransportMessageBatch[] batches = await Task.WhenAll(tasks);

            foreach (var batch in batches)
            {
                Assert.That(batch, Is.Not.Null, "Each batch should have been created successfully.");
                Assert.That(GetEventBatchOptions((AmqpMessageBatch)batch).MaxSizeInBytes, Is.EqualTo(expectedMaxMessageSize),
                    "Each batch should observe the correct MaxBatchSize from the link limits.");
                batch.Dispose();
            }
        }
        /// <summary>
        ///   Verifies that <see cref="AmqpSender.CreateMessageBatchAsync" /> enforces the
        ///   <c>MaxSizeInBytes</c> upper bound using the same limits it used to assign the
        ///   default, preventing a TOCTOU between the default assignment and the range check.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncRejectsMaxSizeExceedingSnapshotLimit()
        {
            var linkMaxMessageSize = 262_144L;
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            SetLinkLimits(sender.Object, linkMaxMessageSize);

            // Request a batch larger than the link's MaxBatchSize — this must throw.
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = linkMaxMessageSize + 1 };

            Assert.That(
                async () => await sender.Object.CreateMessageBatchAsync(options, default),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies that <see cref="AmqpSender.SendBatchInternalAsync" /> uses the link
        ///   limits to enforce the maximum message size and throws
        ///   <see cref="ServiceBusException"/> with <see cref="ServiceBusFailureReason.MessageSizeExceeded"/>
        ///   when the serialized message exceeds the limit.
        /// </summary>
        ///
        [Test]
        public void SendBatchInternalAsyncThrowsWhenMessageExceedsSnapshotLimit()
        {
            var linkMaxMessageSize = 256L;
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            SetLinkLimits(sender.Object, linkMaxMessageSize);

            sender
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureSenderStateAsync",
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            // Create a message whose serialized size exceeds the link limit.
            using var oversizedMessage = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[512]) });

            Assert.That(
                async () => await sender.Object.SendBatchInternalAsync(oversizedMessage, TimeSpan.FromSeconds(5), default),
                Throws.InstanceOf<ServiceBusException>()
                    .And.Property("Reason").EqualTo(ServiceBusFailureReason.MessageSizeExceeded));
        }

        /// <summary>
        ///   Verifies that when link creation does not populate the limits snapshot,
        ///   <see cref="AmqpSender.CreateMessageBatchAsync" /> throws a
        ///   <see cref="ServiceBusException"/> rather than dereferencing null.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncThrowsWhenLinkLimitsNotPopulated()
        {
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            // Mock CreateLinkAndEnsureSenderStateAsync to NOT populate _linkLimits,
            // simulating a link creation that fails to negotiate limits.

            sender
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureSenderStateAsync",
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            Assert.That(
                async () => await sender.Object.CreateMessageBatchAsync(new CreateMessageBatchOptions(), default),
                Throws.InstanceOf<ServiceBusException>()
                    .And.Property("Reason").EqualTo(ServiceBusFailureReason.ServiceCommunicationProblem));
        }

        /// <summary>
        ///   Verifies that when <see cref="AmqpSender.CreateLinkAndEnsureSenderStateAsync" /> is
        ///   called with no prior limits snapshot, the resulting <c>MaxBatchSize</c> is capped to
        ///   <c>Math.Min(MaxMessageSize, DefaultMaxBatchSize)</c>.  The mock callback simulates the
        ///   link creation side-effect by calling <see cref="SetLinkLimits"/>, which applies the same
        ///   <c>Math.Min</c> logic.  This validates that the test helper and the production code agree
        ///   on the fallback value.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncCapsMaxBatchSizeToLinkMaxMessageSize()
        {
            // Standard tier: link max message size (262144) < default batch size (1048576),
            // so MaxBatchSize should be capped to 262144.

            var standardTierMaxMessageSize = 262_144L;
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
                .Callback(() => SetLinkLimits(sender.Object, standardTierMaxMessageSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportMessageBatch batch = await sender.Object.CreateMessageBatchAsync(
                new CreateMessageBatchOptions(), default);

            // MaxBatchSize = Math.Min(262144, DefaultMaxBatchSize=1048576) = 262144
            Assert.That(GetEventBatchOptions((AmqpMessageBatch)batch).MaxSizeInBytes,
                Is.EqualTo(standardTierMaxMessageSize),
                "MaxBatchSize should be Math.Min(MaxMessageSize, DefaultMaxBatchSize).");
        }

        /// <summary>
        ///   Verifies that when the vendor property <c>com.microsoft:max-message-batch-size</c>
        ///   reports a batch limit smaller than <c>MaxMessageSize</c>, the batch uses the
        ///   vendor-reported limit.  This simulates a Premium tier large-message entity where
        ///   <c>MaxMessageSize</c> is 100 MB but the batch limit is 1 MB.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncUsesVendorPropertyWhenSmallerThanMaxMessageSize()
        {
            var premiumLargeMaxMessageSize = 100L * 1024 * 1024; // 100 MB
            var vendorBatchSize = 1_048_576L;                     // 1 MB
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
                .Callback(() => SetLinkLimits(sender.Object, premiumLargeMaxMessageSize, maxBatchSize: vendorBatchSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportMessageBatch batch = await sender.Object.CreateMessageBatchAsync(
                new CreateMessageBatchOptions(), default);

            Assert.That(GetEventBatchOptions((AmqpMessageBatch)batch).MaxSizeInBytes,
                Is.EqualTo(vendorBatchSize),
                "MaxBatchSize should use the vendor property (1 MB), not MaxMessageSize (100 MB).");
        }

        /// <summary>
        ///   Verifies that Standard tier batch sizing works when the vendor property reports
        ///   256 KB — the same value as <c>MaxMessageSize</c>.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncUsesVendorPropertyForStandardTier()
        {
            var standardMaxMessageSize = 262_144L; // 256 KB
            var vendorBatchSize = 262_144L;         // 256 KB (same as max-message-size on Standard)
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
                .Callback(() => SetLinkLimits(sender.Object, standardMaxMessageSize, maxBatchSize: vendorBatchSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportMessageBatch batch = await sender.Object.CreateMessageBatchAsync(
                new CreateMessageBatchOptions(), default);

            Assert.That(GetEventBatchOptions((AmqpMessageBatch)batch).MaxSizeInBytes,
                Is.EqualTo(vendorBatchSize),
                "Standard tier batch size should be 256 KB.");
        }

        /// <summary>
        ///   Verifies that when the vendor property is absent, the batch falls back to
        ///   <c>DefaultMaxBatchSize</c> (1 MB) — not the link's <c>MaxMessageSize</c>
        ///   when MaxMessageSize is larger.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncFallsBackToDefaultWhenVendorPropertyAbsent()
        {
            // Simulate a link that reports 100 MB max-message-size but no vendor property.
            // The fallback DefaultMaxBatchSize caps batch at 1 MB.

            var premiumLargeMaxMessageSize = 100L * 1024 * 1024;
            var expectedBatchSize = 1_048_576L; // DefaultMaxBatchSize
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
                .Callback(() => SetLinkLimits(sender.Object, premiumLargeMaxMessageSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportMessageBatch batch = await sender.Object.CreateMessageBatchAsync(
                new CreateMessageBatchOptions(), default);

            Assert.That(GetEventBatchOptions((AmqpMessageBatch)batch).MaxSizeInBytes,
                Is.EqualTo(expectedBatchSize),
                "Without vendor property, batch should fall back to DefaultMaxBatchSize (1 MB).");
        }

        /// <summary>
        ///   Verifies that the message count is not capped — batches are limited only
        ///   by byte size, not by message count.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncDoesNotEnforceMessageCountLimit()
        {
            var retryPolicy = new BasicRetryPolicy(new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var sender = new Mock<AmqpSender>("somePath", Mock.Of<AmqpConnectionScope>(), retryPolicy, "fake-id", new AmqpMessageConverter())
            {
                CallBase = true
            };

            // Use a large batch size (10 MB) to ensure we can fit well over 4500
            // tiny messages regardless of envelope overhead variations.
            SetLinkLimits(sender.Object, 10L * 1024 * 1024, maxBatchSize: 10L * 1024 * 1024);

            using TransportMessageBatch batch = await sender.Object.CreateMessageBatchAsync(
                new CreateMessageBatchOptions(), default);

            // Add 6000 tiny messages. Previously capped at 4500. With a 10 MB batch,
            // all 6000 should fit easily (each ~200 bytes = ~1.2 MB total).
            int added = 0;
            for (int i = 0; i < 6000; i++)
            {
                if (!batch.TryAddMessage(new ServiceBusMessage(new byte[] { 0x01 })))
                    break;
                added++;
            }

            Assert.That(added, Is.EqualTo(6000),
                "All 6000 messages should be accepted now that the count cap is removed.");
        }
    }
}
