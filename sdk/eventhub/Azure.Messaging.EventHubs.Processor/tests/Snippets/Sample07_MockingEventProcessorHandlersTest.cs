// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Moq;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    [TestFixture]
    public class Sample07_MockingEventProcessorHandlersTest
    {
        /// <summary>
        ///   Performs basic unit test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingProccessEventHandler()
        {
            #region Snippet:EventHubs_Processor_Sample07_MockingProcessEventArgs

            var mockPartitionId = "<< Event Hub Partion Id >>";
            var mockPartitionContext = EventHubsModelFactory.PartitionContext(mockPartitionId);
            var mockEventBody = new BinaryData("This is a sample event body");
            var mockEventData = EventHubsModelFactory.EventData(mockEventBody);

            var mockProcessEventArgs = new ProcessEventArgs(mockPartitionContext, mockEventData, updateToken => Task.CompletedTask, CancellationToken.None);

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    string partition = args.Partition.PartitionId;
                    var eventBody = args.Data.EventBody.ToString();

                    // asserting values
                    Assert.AreEqual(mockPartitionId, partition);
                    Assert.AreEqual(mockEventData.EventBody.ToString(), eventBody);
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

            await processEventHandler(mockProcessEventArgs);

            #endregion
        }

        /// <summary>
        ///   Performs basic unit test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MockingProccessErrorEventHandler()
        {
            #region Snippet:EventHubs_Processor_Sample07_MockingProcessErrorEventArgs

            var mockPartitionId = "<< Event Hub Partion Id >>";
            var mockOperation = "mock operation";
            var mockException = new Exception("mock exception");

            var mockProcessErrorEventArgs = new ProcessErrorEventArgs(mockPartitionId, mockOperation, mockException, CancellationToken.None);

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    Assert.AreEqual(mockOperation, args.Operation);
                    Assert.AreEqual(mockException.Message, args.Exception.Message);
                    Assert.AreEqual(mockException.GetType(), args.Exception.GetType());
                }
                catch
                {
                    // It is very important that you always guard against
                    // exceptions in your handler code; the processor does
                    // not have enough understanding of your code to
                    // determine the correct action to take.  Any
                    // exceptions from your handlers go uncaught by
                    // the processor and will NOT be handled in any
                    // way.
                }

                return Task.CompletedTask;
            }

            await processErrorHandler(mockProcessErrorEventArgs);

            #endregion
        }
    }
}
