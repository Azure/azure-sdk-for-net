using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace Azure.Messaging.EventHubs.Processor.Tests.Snippets
{
    [TestFixture]
    public class Sample07_MockingEventProcessorClientTest
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task BasicEventProcessing()
        {
            #region Snippet:EventHubs_Processor_Sample07_MockingBasicEventProcessing

            var mockEventProcessorClient = new Mock<EventProcessorClient>();
            mockEventProcessorClient
                .Setup(c => c.StartProcessingAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockEventProcessorClient
                .Setup(c => c.StopProcessingAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var processor = mockEventProcessorClient.Object;

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    string partition = args.Partition.PartitionId;
                    byte[] eventBody = args.Data.EventBody.ToArray();
                    Debug.WriteLine($"Event from partition { partition } with length { eventBody.Length }.");
                }
                catch
                {
                    // It is very important that you always guard against
                    // exceptions in your handler code; the processor does
                    // not have enough understanding of your code to
                    // determine the correct action to take.  Any
                    // exceptions from your handlers go uncaught by
                    // the processor and will NOT be redirected to
                    // the error handler.
                }

                return Task.CompletedTask;
            }

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    Debug.WriteLine("Error in the EventProcessorClient");
                    Debug.WriteLine($"\tOperation: { args.Operation }");
                    Debug.WriteLine($"\tException: { args.Exception }");
                    Debug.WriteLine("");
                }
                catch (Exception ex)
                {
                    // It is very important that you always guard against
                    // exceptions in your handler code; the processor does
                    // not have enough understanding of your code to
                    // determine the correct action to take.  Any
                    // exceptions from your handlers go uncaught by
                    // the processor and will NOT be handled in any
                    // way.

                    Application.HandleErrorException(args, ex);
                }

                return Task.CompletedTask;
            }

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

                try
                {
                    await processor.StartProcessingAsync(cancellationSource.Token);
                    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
                }
                catch (TaskCanceledException)
                {
                    // This is expected if the cancellation token is
                    // signaled.
                }
                finally
                {
                    // This may take up to the length of time defined
                    // as part of the configured TryTimeout of the processor;
                    // by default, this is 60 seconds.

                    await processor.StopProcessingAsync();
                }
            }
            catch
            {
                // The processor will automatically attempt to recover from any
                // failures, either transient or fatal, and continue processing.
                // Errors in the processor's operation will be surfaced through
                // its error handler.
                //
                // If this block is invoked, then something external to the
                // processor was the source of the exception.
            }
            finally
            {
                // It is encouraged that you unregister your handlers when you have
                // finished using the Event Processor to ensure proper cleanup.  This
                // is especially important when using lambda expressions or handlers
                // in any form that may contain closure scopes or hold other references.

                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            #endregion
        }
    }
}
