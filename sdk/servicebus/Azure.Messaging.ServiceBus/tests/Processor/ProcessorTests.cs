// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class ProcessorTests : ServiceBusTestBase
    {
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            Assert.That(() => processor.ProcessMessageAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.ProcessMessageAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void CannotRemoveHandlerThatHasNotBeenAdded()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            // First scenario: no handler has been set.

            Assert.That(() => processor.ProcessMessageAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());

            // Second scenario: there is a handler set, but it's not the one we are trying to remove.

            processor.ProcessMessageAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.ProcessMessageAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CanRemoveHandlerThatHasBeenAdded()
        {
            var processor = new ServiceBusProcessor(
                GetMockedConnection(),
                "entityPath",
                false,
                new ServiceBusProcessorOptions());

            Func<ProcessMessageEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            processor.ProcessMessageAsync += eventHandler;
            processor.ProcessErrorAsync += errorHandler;

            Assert.That(() => processor.ProcessMessageAsync -= eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);

            // Assert that handlers can be added again.

            Assert.That(() => processor.ProcessMessageAsync += eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
        }

        //[Test]
        //public async Task CannotAddHandlerWhileProcessorIsRunning()
        //{
        //    var mockReceiver = new Mock<ServiceBusReceiver>(
        //        GetMockedConnection(),
        //        "entityPath",
        //        false,
        //        Mock.Of<ServiceBusReceiverOptions>(),
        //        default);

        //    var mockProcessor = new Mock<ServiceBusProcessor>(
        //        GetMockedConnection(),
        //        "entityPath",
        //        false,
        //        Mock.Of<ServiceBusProcessorOptions>(),
        //        default) { CallBase = true };

        //    mockReceiver
        //        .Setup(receiver => receiver.ReceiveAsync(It.IsAny<CancellationToken>()))
        //        .Returns(Task.FromResult<ServiceBusReceivedMessage>(null));

        //    mockProcessor
        //        .Setup(processor => processor.Receiver)
        //        .Returns(mockReceiver.Object);

        //    mockProcessor.Object.ProcessMessageAsync += eventArgs => Task.CompletedTask;
        //    mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

        //    using var cancellationSource = new CancellationTokenSource();
        //    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

        //    await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

        //    Assert.That(() => mockProcessor.Object.ProcessMessageAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
        //    Assert.That(() => mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());

        //    await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

        //    // Once stopped, the processor should allow handlers to be added again.

        //    Assert.That(() => mockProcessor.Object.ProcessMessageAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
        //    Assert.That(() => mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
        //}

    }
}
