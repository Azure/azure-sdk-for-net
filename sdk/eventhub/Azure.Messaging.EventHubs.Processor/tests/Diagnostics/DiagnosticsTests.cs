// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Tests;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Messaging.EventHubs.Tests;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
{
    /// <summary>
    ///   The suite of tests for validating the diagnostics instrumentation
    ///   of the client library.  These tests are not constrained to a specific
    ///   class or functional area.
    /// </summary>
    ///
    /// <remarks>
    ///   Every instrumented operation will trigger diagnostics activities as
    ///   long as they are being listened to, making it possible for other
    ///   tests to interfere with these. For this reason, these tests are
    ///   marked as non-parallelizable.
    /// </remarks>
    ///
    [NonParallelizable]
    [TestFixture]
    public class DiagnosticsTests
    {
        /// <summary>
        ///   Verifies diagnostics functionality of the <see cref="EventProcessorClient.UpdateCheckpointAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UpdateCheckpointAsyncCreatesScope()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockContext = new Mock<PartitionContext>("65");
            var mockLogger = new Mock<EventProcessorClientEventSource>();
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "cg", "host", "hub", 50, Mock.Of<TokenCredential>(), null) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup<EventHubConnection>("CreateConnection")
                .Returns(Mock.Of<EventHubConnection>());

            mockLogger
                .Setup(log => log.UpdateCheckpointComplete(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor.Object.Logger = mockLogger.Object;

            using var listener = new ClientDiagnosticListener(EventDataInstrumentation.DiagnosticNamespace);
            await mockProcessor.Object.UpdateCheckpointAsync(new MockEventData(new byte[0], sequenceNumber: 65, offset: 998), mockContext.Object, default);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            ClientDiagnosticListener.ProducedDiagnosticScope scope = listener.Scopes.Single();
            Assert.That(scope.Name, Is.EqualTo(DiagnosticProperty.EventProcessorCheckpointActivityName));

            cancellationSource.Cancel();
        }
    }
}
