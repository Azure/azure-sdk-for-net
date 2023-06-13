// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Stores the events raised as the test progresses.
    ///
    /// This will provide checks to ensure that the expected amount of events
    /// are raised during a test.
    ///
    /// This also prevents a test from being torn down terribly when doing
    /// an Assert.Failure in the middle of an event.
    ///
    /// Also if there's multiple failures then we will catch all of them.
    /// (Which would mainly occur during <see cref="ErrorHandlingOptions.ContinueOnFailure"/>
    /// </summary>
    internal class TestEventsRaised : IDisposable
    {
        public List<TransferFailedEventArgs> FailedEvents { get; internal set; }
        public List<TransferStatusEventArgs> StatusEvents { get; internal set; }
        public List<TransferSkippedEventArgs> SkippedEvents { get; internal set; }
        public List<SingleTransferCompletedEventArgs> SingleCompletedEvents { get; internal set; }

        private List<TransferOptions> _options;

        private TestEventsRaised()
        {
            FailedEvents = new List<TransferFailedEventArgs>();
            StatusEvents = new List<TransferStatusEventArgs>();
            SkippedEvents = new List<TransferSkippedEventArgs>();
            SingleCompletedEvents = new List<SingleTransferCompletedEventArgs>();
        }

        public TestEventsRaised(TransferOptions options)
            : this()
        {
            options.TransferFailed += AppendFailedArg;
            options.TransferStatus += AppendStatusArg;
            options.TransferSkipped += AppendSkippedArg;
            options.SingleTransferCompleted += AppendSingleTransferCompleted;
            _options = new List<TransferOptions> { options };
        }

        public TestEventsRaised(List<TransferOptions> optionsList)
            : this()
        {
            _options = new List<TransferOptions>();
            foreach (TransferOptions options in optionsList)
            {
                options.TransferFailed += AppendFailedArg;
                options.TransferStatus += AppendStatusArg;
                options.TransferSkipped += AppendSkippedArg;
                options.SingleTransferCompleted += AppendSingleTransferCompleted;
                _options.Add(options);
            }
        }

        public void Dispose()
        {
            foreach (TransferOptions options in _options)
            {
                options.TransferFailed -= AppendFailedArg;
                options.TransferStatus -= AppendStatusArg;
                options.TransferSkipped -= AppendSkippedArg;
                options.SingleTransferCompleted -= AppendSingleTransferCompleted;
            }
        }

        private Task AppendFailedArg(TransferFailedEventArgs args)
        {
            FailedEvents.Add(args);
            return Task.CompletedTask;
        }

        private Task AppendStatusArg(TransferStatusEventArgs args)
        {
            StatusEvents.Add(args);
            return Task.CompletedTask;
        }

        private Task AppendSkippedArg(TransferSkippedEventArgs args)
        {
            SkippedEvents.Add(args);
            return Task.CompletedTask;
        }

        private Task AppendSingleTransferCompleted(SingleTransferCompletedEventArgs args)
        {
            SingleCompletedEvents.Add(args);
            return Task.CompletedTask;
        }

        public void AssertUnexpectedFailureCheck()
        {
            Assert.Multiple(() =>
            {
                foreach (TransferFailedEventArgs failure in FailedEvents)
                {
                    Assert.Fail(
                        $"Failure occurred at Transfer id: {failure.TransferId}.\n" +
                        $"Source Resource Path: {failure.SourceResource.Path}\n" +
                        $"Destination Resource Path: {failure.DestinationResource.Path}\n" +
                        $"Exception Message: {failure.Exception.Message}\n" +
                        $"Exception Stack: {failure.Exception.StackTrace}\n");
                }
            });
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="StorageTransferStatus.Completed"/> at the end without any skips
        /// or failures.
        /// </summary>
        public void AssertSingleCompletedCheck()
        {
            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);
            Assert.IsEmpty(SingleCompletedEvents);
            /* TODO: Reenable check:  https://github.com/Azure/azure-sdk-for-net/issues/35976
            Assert.AreEqual(2, StatusEvents.Count);
            Assert.AreEqual(StorageTransferStatus.InProgress, StatusEvents.First().StorageTransferStatus);
            Assert.AreEqual(StorageTransferStatus.Completed, StatusEvents.ElementAt(1).StorageTransferStatus);
            */
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="StorageTransferStatus.CompletedWithSkippedTransfers"/> at the end without any
        /// or failures.
        /// </summary>
        public void AssertSingleSkippedCheck()
        {
            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SingleCompletedEvents);
            Assert.AreEqual(1, SkippedEvents.Count);
            /* TODO: Reenable check:  https://github.com/Azure/azure-sdk-for-net/issues/35976
            Assert.AreEqual(2, StatusEvents.Count);
            Assert.AreEqual(StorageTransferStatus.InProgress, StatusEvents.First().StorageTransferStatus);
            Assert.AreEqual(StorageTransferStatus.CompletedWithSkippedTransfers, StatusEvents.ElementAt(1).StorageTransferStatus);
            Assert.NotNull(SkippedEvents.First().SourceResource.Path);
            Assert.NotNull(SkippedEvents.First().DestinationResource.Path);
            */
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="StorageTransferStatus.CompletedWithFailedTransfers"/> at the end without any skips.
        /// </summary>
        public void AssertSingleFailedCheck()
        {
            Assert.IsEmpty(SkippedEvents);
            Assert.IsEmpty(SingleCompletedEvents);
            /* TODO: Reenable check:  https://github.com/Azure/azure-sdk-for-net/issues/35976
            Assert.AreEqual(1, FailedEvents.Count);
            Assert.AreEqual(3, StatusEvents.Count);
            Assert.AreEqual(StorageTransferStatus.InProgress, StatusEvents.First().StorageTransferStatus);
            Assert.AreEqual(StorageTransferStatus.CancellationInProgress, StatusEvents.ElementAt(1).StorageTransferStatus);
            Assert.AreEqual(StorageTransferStatus.CompletedWithFailedTransfers, StatusEvents.ElementAt(2).StorageTransferStatus);
            Assert.NotNull(FailedEvents.First().Exception);
            Assert.NotNull(FailedEvents.First().SourceResource.Path);
            Assert.NotNull(FailedEvents.First().DestinationResource.Path);
            */
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="StorageTransferStatus.Completed"/> at the end without any skips
        /// or failures.
        /// </summary>
        /// <param name="blobCount">
        /// Expected amount of single transfers within the container transfer.
        /// </param>
        public async Task AssertContainerCompletedCheck(int transferCount)
        {
            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);
            // TODO: Reenable check:  https://github.com/Azure/azure-sdk-for-net/issues/35976
            // Assert.AreEqual(transferCount, SingleCompletedEvents.Count);

            await WaitForStatusEventsAsync().ConfigureAwait(false);
            CollectionAssert.AreEqual(
                new StorageTransferStatus[] {
                    StorageTransferStatus.InProgress,
                    StorageTransferStatus.Completed },
                StatusEvents.Select(e => e.StorageTransferStatus));
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="StorageTransferStatus.CompletedWithFailure"/> at the end without any skips.
        /// Assuming <see cref="ErrorHandlingOptions.StopOnAllFailures"/> was set.
        /// </summary>
        /// <param name="expectedFailureCount">
        /// Expected amount of failure single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithFailedCheck(int expectedFailureCount)
        {
            if (expectedFailureCount != FailedEvents.Count)
            {
                // We want to call this to print out to see
                // what failures we received since it was the incorrect amount.
                Assert.Multiple(() =>
                {
                    AssertUnexpectedFailureCheck();
                    Assert.AreEqual(expectedFailureCount, FailedEvents.Count);
                });
            }
            Assert.IsEmpty(SkippedEvents);

            await WaitForStatusEventsAsync().ConfigureAwait(false);
            CollectionAssert.AreEqual(
                new StorageTransferStatus[] {
                    StorageTransferStatus.InProgress,
                    StorageTransferStatus.CancellationInProgress,
                    StorageTransferStatus.CompletedWithFailedTransfers },
                StatusEvents.Select(e => e.StorageTransferStatus));
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="StorageTransferStatus.CompletedWithFailure"/> at the end without any skips.
        /// Assuming <see cref="ErrorHandlingOptions.ContinueOnFailure"/> was set.
        /// </summary>
        /// <param name="expectedFailureCount">
        /// Expected amount of failure single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithFailedCheckContinue(int expectedFailureCount)
        {
            if (expectedFailureCount != FailedEvents.Count)
            {
                // We want to call this to print out to see
                // what failures we received since it was the incorrect amount.
                Assert.Multiple(() =>
                {
                    AssertUnexpectedFailureCheck();
                    Assert.AreEqual(expectedFailureCount, FailedEvents.Count);
                });
            }
            Assert.IsEmpty(SkippedEvents);

            await WaitForStatusEventsAsync().ConfigureAwait(false);
            CollectionAssert.AreEqual(
                new StorageTransferStatus[] {
                    StorageTransferStatus.InProgress,
                    StorageTransferStatus.CompletedWithFailedTransfers },
                StatusEvents.Select(e => e.StorageTransferStatus));
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="StorageTransferStatus.CompletedWithSkippedTransfers"/> at the end without any failures.
        /// </summary>
        /// <param name="expectedSkipCount">
        /// Expected amount of skipped single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithSkippedCheck(int expectedSkipCount)
        {
            AssertUnexpectedFailureCheck();
            Assert.AreEqual(expectedSkipCount, SkippedEvents.Count);

            await WaitForStatusEventsAsync().ConfigureAwait(false);
            CollectionAssert.AreEqual(
                new StorageTransferStatus[] {
                    StorageTransferStatus.InProgress,
                    StorageTransferStatus.CompletedWithSkippedTransfers },
                StatusEvents.Select(e => e.StorageTransferStatus));
        }

        public async Task AssertPausedCheck()
        {
            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);

            await WaitForStatusEventsAsync().ConfigureAwait(false);
            CollectionAssert.AreEqual(
                new StorageTransferStatus[] {
                    StorageTransferStatus.InProgress,
                    StorageTransferStatus.Paused },
                StatusEvents.Select(e => e.StorageTransferStatus));
        }

        /// <summary>
        /// Static method which populates option bags event handlers being used by the TestEventsRaised in order
        /// to keep track of all the events that occur during the transfer.
        /// </summary>
        /// <param name="transferCount">The expected amount of options.</param>
        /// <param name="listOptions">The options bag reference. If there are existing options, use the existing options,
        /// if not default options will be created so event args can be added to the event handlers</param>
        /// <returns>A respective list of Events Raised coordinating with the options given.</returns>
        internal static List<TestEventsRaised> PopulateTestOptions(int transferCount, ref List<TransferOptions> listOptions)
        {
            List<TestEventsRaised> eventRaisedList = new List<TestEventsRaised>(transferCount);
            if (listOptions == default || listOptions?.Count == 0)
            {
                listOptions ??= new List<TransferOptions>(transferCount);
                for (int i = 0; i < transferCount; i++)
                {
                    TransferOptions currentOptions = new TransferOptions();
                    TestEventsRaised testEventRaisedCurrent = new TestEventsRaised(currentOptions);
                    listOptions.Add(currentOptions);
                    eventRaisedList.Add(testEventRaisedCurrent);
                }
            }
            else
            {
                // If blobNames is populated make sure these number of blobs match
                Assert.AreEqual(transferCount, listOptions.Count);
                // Add TestEventRaised to each option
                foreach (TransferOptions currentOptions in listOptions)
                {
                    TestEventsRaised testEventRaisedCurrent = new TestEventsRaised(currentOptions);
                    eventRaisedList.Add(testEventRaisedCurrent);
                }
            }
            return eventRaisedList;
        }

        /// <summary>
        /// The final job status event can come in after the transfer is finished.
        /// This is expected so wait for a brief time to allow that event to come in.
        /// </summary>
        private Task WaitForStatusEventsAsync()
        {
            return Task.Delay(100);
        }
    }
}
