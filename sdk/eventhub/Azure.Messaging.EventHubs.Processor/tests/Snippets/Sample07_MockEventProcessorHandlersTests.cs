// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample07_MockEventProcessorHandlersTests sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample07_MockEventProcessorHandlersTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventHandlerCancellation()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerCancellation

            var cancelledToken = new CancellationToken(true);

            var mockProcessEventArgs = new ProcessEventArgs(
                It.IsAny<Consumer.PartitionContext>(),
                It.IsAny<EventData>(),
                _ => Task.CompletedTask,
                cancelledToken);

            await SampleApplication.ProcessorEventHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventHandlerEnqueuedTimeMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerEnqueuedTimeMock

            var yesterdayEnqueuedTime = DateTime.Now.Date.AddDays(-1);

            var mockEventBody = new BinaryData("This is a sample event body");

            var mockEventData = EventHubsModelFactory.EventData(
                mockEventBody,
                It.IsAny<IDictionary<string, object>>(),
                It.IsAny<IReadOnlyDictionary<string, object>>(),
                It.IsAny<string>(),
                It.IsAny<long>(),
                It.IsAny<long>(),
                yesterdayEnqueuedTime);

            var mockProcessEventArgs = new ProcessEventArgs(
                It.IsAny<Consumer.PartitionContext>(),
                mockEventData,
                _ => Task.CompletedTask);

            await SampleApplication.ProcessorEventHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventHandlerCustomPropertiesMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerCustomPropertiesMock

            var customEventHubProperties = new Dictionary<string, object>()
            {
                { "MyProperty1", "MyValue1" }
            };

            var mockEventBody = new BinaryData("This is a sample event body");
            var mockEventData = EventHubsModelFactory.EventData(
                mockEventBody,
                It.IsAny<IDictionary<string, object>>());

            var mockProcessEventArgs = new ProcessEventArgs(
                It.IsAny<Consumer.PartitionContext>(),
                mockEventData,
                _ => Task.CompletedTask);

            await SampleApplication.ProcessorEventHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventHandlerPartitionContextMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerPartitionContextMock

            var mockPartitionId = "<< Event Hub Partion Id >>";
            var mockPartitionContext = EventHubsModelFactory.PartitionContext(mockPartitionId);

            var mockEventBody = new BinaryData("This is a sample event body");
            var mockEventData = EventHubsModelFactory.EventData(mockEventBody);

            var mockProcessEventArgs = new ProcessEventArgs(
                mockPartitionContext,
                mockEventData,
                _ => Task.CompletedTask);

            await SampleApplication.ProcessorEventHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventHandlerLastEnqueuedEventPropertiesMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessEventHandlerLastEnqueuedEventPropertiesMock

            var twoMinutesAgo = DateTime.UtcNow.AddMinutes(-2);
            var mockLastEnqueuedEventProperties = new LastEnqueuedEventProperties(
                It.IsAny<long>(),
                It.IsAny<long>(),
                It.IsAny<DateTimeOffset>(),
                twoMinutesAgo);

            var mockPartitionId = "<< Event Hub Partion Id >>";
            var mockPartitionContext = EventHubsModelFactory.PartitionContext(mockPartitionId, mockLastEnqueuedEventProperties);

            var mockEventBody = new BinaryData("This is a sample event body");
            var mockEventData = EventHubsModelFactory.EventData(mockEventBody);

            var mockProcessEventArgs = new ProcessEventArgs(
                mockPartitionContext,
                mockEventData,
                _ => Task.CompletedTask);

            await SampleApplication.ProcessorEventHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorHandlerExceptionMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_ProcessErrorHandlerExceptionMock

            var mockException = new Exception("mock exception");

            var mockProcessEventArgs = new ProcessErrorEventArgs(
                It.IsAny<string>(),
                It.IsAny<string>(),
                mockException);

            await SampleApplication.ProcessorErrorHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task InitializeEventHandlerEventPositionMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_InitializeEventHandlerEventPositionMock

            var fiveMinutesAgo = DateTime.UtcNow.AddMinutes(-5);

            var mockEventPosition = EventPosition.FromEnqueuedTime(fiveMinutesAgo);

            var mockPartitionInitEventArgs = new PartitionInitializingEventArgs (
                It.IsAny<string>(),
                mockEventPosition);

            await SampleApplication.InitializeEventHandler(mockPartitionInitEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CloseEventHandlerOwnershipLostMock()
        {
            #region Snippet:EventHubs_Processor_Sample07_CloseEventHandlerOwnershipLostMock

            var mockPartitionCloseEventArgs = new PartitionClosingEventArgs(
                It.IsAny<string>(),
                ProcessingStoppedReason.OwnershipLost);

            await SampleApplication.CloseEventHandler(mockPartitionCloseEventArgs);

            #endregion
        }

        /// <summary>
        ///   Serves as a simulation of the host application for
        ///   examples.
        /// </summary>
        ///
        private static class SampleApplication
        {
            /// <summary>
            ///   A simulated method that an application would register as partition initialization event handler.
            /// </summary>
            ///
            /// <param name="initEventArgs">The arguments associated with the partition initialization event.</param>
            ///
            public static Task InitializeEventHandler(PartitionInitializingEventArgs initEventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would register as an event handler.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the event.</param>
            ///
            public static Task ProcessorEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would register as an error handler.
            /// </summary>
            ///
            /// <param name="errorEventArgs">The arguments associated with the error.</param>
            ///
            public static Task ProcessorErrorHandler(ProcessErrorEventArgs errorEventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would register as partition closing event handler.
            /// </summary>
            ///
            /// <param name="errorEventArgs">The arguments associated with the partition closing event.</param>
            ///
            public static Task CloseEventHandler(PartitionClosingEventArgs args) => Task.CompletedTask;
        }
    }
}
