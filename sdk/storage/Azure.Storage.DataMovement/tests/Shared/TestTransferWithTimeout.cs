// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public static class TestTransferWithTimeout
    {
        public static async Task WaitForCompletionAsync(
            TransferOperation transferOperation,
            TestEventsRaised testEventsRaised,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await transferOperation.WaitForCompletionAsync(cancellationToken);
            }
            catch (Exception ex)
            when (ex is OperationCanceledException || ex is TaskCanceledException)
            {
                PrintAllEvents(testEventsRaised);
            }
        }

        private static void PrintAllEvents(TestEventsRaised testEventsRaised)
        {
            // The transfer went for longer than we expected,
            // so waiting on the transfer has been cancelled.
            // Log that we cancelled the task and output any events seen.
            Console.Write("Transfer failed with Cancellation Token Timeout");
            if (testEventsRaised.FailedEvents.Count > 0)
            {
                testEventsRaised?.AssertUnexpectedFailureCheck();
            }
            else
            {
                Console.Write("No failures found during transfer before timeout. Transfer is likely hanging, or did not receive enough time.");
                Assert.Multiple(() =>
                {
                    if (testEventsRaised.SkippedEvents.Count == 0 ||
                        testEventsRaised.SingleCompletedEvents.Count == 0 ||
                        testEventsRaised.StatusEvents.Count == 0)
                    {
                        Assert.Fail("No Events Emitted during this transfer.");
                    }
                    else
                    {
                        foreach (TransferItemSkippedEventArgs skippedEvent in testEventsRaised.SkippedEvents)
                        {
                            Assert.Fail(
                                $"Skipped event occurred at Transfer id: {skippedEvent.TransferId}.\n" +
                                $"Source Resource Path: {skippedEvent.Source.Uri.AbsoluteUri}\n" +
                                $"Destination Resource Path: {skippedEvent.Destination.Uri.AbsoluteUri}\n");
                        }
                        foreach (TransferItemCompletedEventArgs singleCompletedEvent in testEventsRaised.SingleCompletedEvents)
                        {
                            Assert.Fail(
                                $"Single Item Transfer completed occurred at Transfer id: {singleCompletedEvent.TransferId}.\n" +
                                $"Source Resource Path: {singleCompletedEvent.Source.Uri.AbsoluteUri}\n" +
                                $"Destination Resource Path: {singleCompletedEvent.Destination.Uri.AbsoluteUri}\n");
                        }
                        foreach (TransferStatusEventArgs statusEvent in testEventsRaised.StatusEvents)
                        {
                            Assert.Fail(
                                $"Status Event at Transfer id: {statusEvent.TransferId}.\n" +
                                $"Transfer State: {Enum.GetName(typeof(TransferState), statusEvent.TransferStatus.State)}\n" +
                                $"HasCompletedSuccessfully: {statusEvent.TransferStatus.HasCompletedSuccessfully}\n" +
                                $"HasFailedItems: {statusEvent.TransferStatus.HasFailedItems}\n +" +
                                $"HasSkippedItems: {statusEvent.TransferStatus.HasSkippedItems}\n");
                        }
                    }
                });
            }
        }
    }
}
