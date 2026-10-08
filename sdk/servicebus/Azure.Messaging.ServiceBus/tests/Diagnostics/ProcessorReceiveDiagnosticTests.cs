// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
#if NET5_0_OR_GREATER
    [NonParallelizable]
    [TestFixture(true)]
    [TestFixture(false)]
    public class ProcessorReceiveDiagnosticTests
    {
        private readonly bool _useActivitySource;
        private TestAppContextSwitch _featureSwitch;

        public ProcessorReceiveDiagnosticTests(bool useActivitySource)
        {
            _useActivitySource = useActivitySource;
        }

        [SetUp]
        public void SetUp()
        {
            _featureSwitch = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", _useActivitySource.ToString());
            ActivityExtensions.ResetFeatureSwitch();
        }

        [TearDown]
        public void TearDown()
        {
            _featureSwitch.Dispose();
            ActivityExtensions.ResetFeatureSwitch();
        }

        [Test]
        public async Task ReceiveActivities(
            [Values(true, false)] bool useSessions,
            [Values(true, false)] bool isProcessor,
            [Values(0, 1, 2)] int messageCount,
            [Values(true, false)] bool listenWithActivitySource)
        {
            using var activityListener = listenWithActivitySource
                ? new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace))
                : null;
            using var diagnosticListener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            using var parent = new Activity("Application").SetIdFormat(ActivityIdFormat.W3C).Start();
            var messages = Enumerable.Range(0, messageCount)
                .Select(_ => ServiceBusModelFactory.ServiceBusReceivedMessage(
                    properties: new Dictionary<string, object> { ["Diagnostic-Id"] = parent.Id }))
                .ToArray();
            var transport = new Mock<TransportReceiver>();
            transport.Setup(receiver => receiver.ReceiveMessagesAsync(2, It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(messages);
            var logger = new Mock<ServiceBusEventSource>();
            await using var receiver = CreateReceiver(transport, useSessions);
            receiver.Logger = logger.Object;

            var received = isProcessor
                ? await receiver.ReceiveMessagesAsync(2, default, true, CancellationToken.None)
                : await receiver.ReceiveMessagesAsync(2);

            Assert.AreSame(messages, received);
            Assert.AreSame(parent, Activity.Current);
            bool suppressed = isProcessor;
            AssertReceiveActivities(activityListener, diagnosticListener, suppressed ? 0 : 1);
            if (!suppressed)
            {
                Assert.AreEqual(parent.Id, diagnosticListener.Scopes.Single().Activity.ParentId);
                Assert.AreEqual(_useActivitySource && listenWithActivitySource ? 0 : messageCount,
                    diagnosticListener.Scopes.Single().Links.Count);
                if (_useActivitySource && listenWithActivitySource)
                {
                    Assert.AreEqual(ActivityKind.Client, activityListener.Activities.Single().Kind);
                    Assert.AreEqual(messageCount, activityListener.Activities.Single().Links.Count());
                }
            }
            logger.Verify(log => log.ReceiveMessageStart(receiver.Identifier, 2), Times.Once);
            logger.Verify(log => log.ReceiveMessageComplete(receiver.Identifier, messages), Times.Once);
            transport.Verify(inner => inner.ReceiveMessagesAsync(2, It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task FailedReceiveActivities(
            [Values(true, false)] bool useSessions,
            [Values(true, false)] bool isProcessor,
            [Values(true, false)] bool canceled,
            [Values(true, false)] bool listenWithActivitySource)
        {
            using var activityListener = listenWithActivitySource
                ? new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace))
                : null;
            using var diagnosticListener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            using var parent = new Activity("Application").SetIdFormat(ActivityIdFormat.W3C).Start();
            using var cancellation = new CancellationTokenSource();
            Exception exception = canceled
                ? new TaskCanceledException()
                : new ServiceBusException("Receive failed", ServiceBusFailureReason.ServiceCommunicationProblem);
            var transport = new Mock<TransportReceiver>();
            transport.Setup(receiver => receiver.ReceiveMessagesAsync(1, It.IsAny<TimeSpan?>(), cancellation.Token))
                .Returns(() =>
                {
                    if (canceled)
                    {
                        cancellation.Cancel();
                    }
                    return Task.FromException<IReadOnlyList<ServiceBusReceivedMessage>>(exception);
                });
            var logger = new Mock<ServiceBusEventSource>();
            await using var receiver = CreateReceiver(transport, useSessions);
            receiver.Logger = logger.Object;

            var thrown = Assert.ThrowsAsync(exception.GetType(), async () =>
            {
                if (isProcessor)
                {
                    await receiver.ReceiveMessagesAsync(1, default, true, cancellation.Token);
                }
                else
                {
                    await receiver.ReceiveMessagesAsync(1, cancellationToken: cancellation.Token);
                }
            });

            Assert.AreSame(exception, thrown);
            Assert.AreSame(parent, Activity.Current);
            bool suppressed = isProcessor;
            AssertReceiveActivities(activityListener, diagnosticListener, suppressed ? 0 : 1);
            if (!suppressed)
            {
                Assert.AreSame(exception, diagnosticListener.Scopes.Single().Exception);
                if (_useActivitySource && listenWithActivitySource)
                {
                    Assert.AreEqual(ActivityStatusCode.Error, activityListener.Activities.Single().Status);
                }
            }
            logger.Verify(log => log.ReceiveMessageStart(receiver.Identifier, 1), Times.Once);
            if (!canceled)
            {
                logger.Verify(log => log.ReceiveMessageException(receiver.Identifier,
                    It.Is<string>(text => text.Contains("Receive failed"))), Times.Once);
            }
        }

        [Test]
        public async Task CallbackReceiveActivities([Values(true, false)] bool useSessions)
        {
            using var activityListener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));
            using var diagnosticListener = new ClientDiagnosticListener(DiagnosticProperty.DiagnosticNamespace);
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(lockedUntil: DateTimeOffset.UtcNow.AddMinutes(5));
            var transport = new Mock<TransportReceiver>();
            transport.Setup(receiver => receiver.ReceiveMessagesAsync(1, It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { message });
            var connection = ServiceBusTestUtilities.GetMockedReceiverConnection(transport);
            await using var receiver = CreateReceiver(transport, useSessions);
            await using var processor = new ServiceBusProcessor(connection, "queue", false,
                new ServiceBusProcessorOptions { MaxAutoLockRenewalDuration = TimeSpan.Zero });
            var manager = new Mock<ReceiverManager>(processor, receiver.ClientDiagnostics, false);
            manager.SetupGet(value => value.Receiver).Returns(receiver);
            EventArgs args = useSessions
                ? new ProcessSessionMessageEventArgs(message, (ServiceBusSessionReceiver)receiver, CancellationToken.None)
                : new ProcessMessageEventArgs(message, receiver, CancellationToken.None);
            var actions = new ProcessorReceiveActions(args, manager.Object, false);

            try
            {
                var received = await actions.ReceiveMessagesAsync(1);

                Assert.AreSame(message, received.Single());
                AssertReceiveActivities(activityListener, diagnosticListener, 1);
            }
            finally
            {
                if (args is ProcessMessageEventArgs messageArgs)
                {
                    messageArgs.MessageLockLostCancellationSource.Dispose();
                }
            }
        }

        private void AssertReceiveActivities(
            TestActivitySourceListener activityListener,
            ClientDiagnosticListener diagnosticListener,
            int expectedCount)
        {
            Assert.AreEqual(expectedCount, diagnosticListener.Scopes.Count);
            Assert.IsTrue(diagnosticListener.Scopes.All(scope => scope.Name == DiagnosticProperty.ReceiveActivityName));
            if (activityListener != null)
            {
                Assert.AreEqual(_useActivitySource ? expectedCount : 0, activityListener.Activities.Count);
                Assert.IsTrue(activityListener.Activities.All(activity => activity.OperationName == DiagnosticProperty.ReceiveActivityName));
            }
        }

        private static ServiceBusReceiver CreateReceiver(Mock<TransportReceiver> transport, bool useSessions)
        {
            var connection = ServiceBusTestUtilities.GetMockedReceiverConnection(transport);
            return useSessions
                ? new ServiceBusSessionReceiver(connection, "queue", new ServiceBusSessionReceiverOptions(),
                    CancellationToken.None, "session", isProcessor: true)
                : new ServiceBusReceiver(connection, "queue", false, new ServiceBusReceiverOptions(), isProcessor: true);
        }
    }
#endif
}
