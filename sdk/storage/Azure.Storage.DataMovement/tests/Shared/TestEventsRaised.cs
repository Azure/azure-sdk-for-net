// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    /// Which would mainly occur during <see cref="DataTransferErrorMode.ContinueOnFailure"/>
    /// </summary>
    public class TestEventsRaised : IDisposable
    {
        private static readonly DataTransferStatus InProgressStatus = new DataTransferStatusInternal(DataTransferState.InProgress, false, false);
        private static readonly DataTransferStatus InProgressFailedStatus = new DataTransferStatusInternal(DataTransferState.InProgress, true, false);
        private static readonly DataTransferStatus InProgressSkippedStatus = new DataTransferStatusInternal(DataTransferState.InProgress, false, true);
        private static readonly DataTransferStatus StoppingFailedStatus = new DataTransferStatusInternal(DataTransferState.Stopping, true, false);
        private static readonly DataTransferStatus SuccessfulCompletedStatus = new DataTransferStatusInternal(DataTransferState.Completed, false, false);
        private static readonly DataTransferStatus SkippedCompletedStatus = new DataTransferStatusInternal(DataTransferState.Completed, false, true);
        private static readonly DataTransferStatus FailedCompletedStatus = new DataTransferStatusInternal(DataTransferState.Completed, true, false);

        public List<TransferItemFailedEventArgs> FailedEvents { get; internal set; }
        private object _failedEventsLock = new();
        public List<TransferStatusEventArgs> StatusEvents { get; internal set; }
        public List<TransferItemSkippedEventArgs> SkippedEvents { get; internal set; }
        public ConcurrentBag<TransferItemCompletedEventArgs> SingleCompletedEvents { get; internal set; }

        private List<DataTransferOptions> _options;

        private TestEventsRaised()
        {
            FailedEvents = new List<TransferItemFailedEventArgs>();
            StatusEvents = new List<TransferStatusEventArgs>();
            SkippedEvents = new List<TransferItemSkippedEventArgs>();
            SingleCompletedEvents = new ConcurrentBag<TransferItemCompletedEventArgs>();
        }

        public TestEventsRaised(DataTransferOptions options)
            : this()
        {
            options.ItemTransferFailed += AppendFailedArg;
            options.TransferStatusChanged += AppendStatusArg;
            options.ItemTransferSkipped += AppendSkippedArg;
            options.ItemTransferCompleted += AppendSingleTransferCompleted;
            _options = new List<DataTransferOptions> { options };
        }

        public TestEventsRaised(List<DataTransferOptions> optionsList)
            : this()
        {
            _options = new List<DataTransferOptions>();
            foreach (DataTransferOptions options in optionsList)
            {
                options.ItemTransferFailed += AppendFailedArg;
                options.TransferStatusChanged += AppendStatusArg;
                options.ItemTransferSkipped += AppendSkippedArg;
                options.ItemTransferCompleted += AppendSingleTransferCompleted;
                _options.Add(options);
            }
        }

        public void Dispose()
        {
            foreach (DataTransferOptions options in _options)
            {
                options.ItemTransferFailed -= AppendFailedArg;
                options.TransferStatusChanged -= AppendStatusArg;
                options.ItemTransferSkipped -= AppendSkippedArg;
                options.ItemTransferCompleted -= AppendSingleTransferCompleted;
            }
        }

        private Task AppendFailedArg(TransferItemFailedEventArgs args)
        {
            lock (_failedEventsLock)
            {
                FailedEvents.Add(args);
            }
            return Task.CompletedTask;
        }

        private Task AppendStatusArg(TransferStatusEventArgs args)
        {
            StatusEvents.Add(args);
            return Task.CompletedTask;
        }

        private Task AppendSkippedArg(TransferItemSkippedEventArgs args)
        {
            SkippedEvents.Add(args);
            return Task.CompletedTask;
        }

        private Task AppendSingleTransferCompleted(TransferItemCompletedEventArgs args)
        {
            SingleCompletedEvents.Add(args);
            return Task.CompletedTask;
        }

        private void AssertTransferStatusCollection(DataTransferStatus[] expected, DataTransferStatus[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    if (!expected[i].Equals(actual[i]))
                    {
                        // Compared to individual Assert statements, this makes it clear when running the test, what's failing.
                        Assert.Fail($"Transfer State Mismatch:" +
                            $"Expected {nameof(DataTransferStatus.State)}: {expected[i].State}; Actual {nameof(DataTransferStatus.State)}: {actual[i].State}\n" +
                            $"Expected {nameof(DataTransferStatus.HasFailedItems)}: {expected[i].HasFailedItems}; Actual {nameof(DataTransferStatus.HasFailedItems)}: {actual[i].HasFailedItems}\n" +
                            $"Expected {nameof(DataTransferStatus.HasSkippedItems)}: {expected[i].HasSkippedItems}; Actual {nameof(DataTransferStatus.HasSkippedItems)}: {actual[i].HasSkippedItems}\n");
                    }
                }
            });
        }

        public void AssertUnexpectedFailureCheck()
        {
            Assert.Multiple(() =>
            {
                foreach (TransferItemFailedEventArgs failure in FailedEvents)
                {
                    Assert.Fail(
                        $"Failure occurred at Transfer id: {failure.TransferId}.\n" +
                        $"Source Resource Path: {failure.SourceResource.Uri.AbsoluteUri}\n" +
                        $"Destination Resource Path: {failure.DestinationResource.Uri.AbsoluteUri}\n" +
                        $"Exception Message: {failure.Exception.Message}\n" +
                        $"Exception Stack: {failure.Exception.StackTrace}\n");
                }
            });
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="DataTransferState.Completed"/> at the end without any skips
        /// or failures.
        /// </summary>
        public async Task AssertSingleCompletedCheck()
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);
            Assert.IsEmpty(SingleCompletedEvents);

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    SuccessfulCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="DataTransferState.CompletedWithSkippedTransfers"/> at the end without any
        /// or failures.
        /// </summary>
        public async Task AssertSingleSkippedCheck()
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SingleCompletedEvents);
            Assert.AreEqual(1, SkippedEvents.Count);
            Assert.NotNull(SkippedEvents.First().SourceResource.Uri);
            Assert.NotNull(SkippedEvents.First().DestinationResource.Uri);

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    InProgressSkippedStatus,
                    SkippedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="DataTransferState.CompletedWithFailedTransfers"/> at the end without any skips.
        /// </summary>
        public async Task AssertSingleFailedCheck(int failureCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            Assert.IsEmpty(SkippedEvents);
            Assert.IsEmpty(SingleCompletedEvents);
            Assert.AreEqual(failureCount, FailedEvents.Count);
            foreach (TransferItemFailedEventArgs args in FailedEvents)
            {
                Assert.NotNull(args.Exception);
                Assert.NotNull(args.SourceResource.Uri);
                Assert.NotNull(args.DestinationResource.Uri);
            }

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    InProgressFailedStatus,
                    StoppingFailedStatus,
                    FailedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="DataTransferState.Completed"/> at the end without any skips
        /// or failures.
        /// </summary>
        /// <param name="blobCount">
        /// Expected amount of single transfers within the container transfer.
        /// </param>
        public async Task AssertContainerCompletedCheck(int transferCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);
            Assert.AreEqual(transferCount, SingleCompletedEvents.Count);

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    SuccessfulCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="DataTransferState.CompletedWithFailure"/> at the end without any skips.
        /// Assuming <see cref="DataTransferErrorMode.StopOnAnyFailure"/> was set.
        /// </summary>
        /// <param name="expectedFailureCount">
        /// Expected amount of failure single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithFailedCheck(int expectedFailureCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

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

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    InProgressFailedStatus,
                    StoppingFailedStatus,
                    FailedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="DataTransferState.CompletedWithFailure"/> at the end without any skips.
        /// Assuming <see cref="DataTransferErrorMode.ContinueOnFailure"/> was set.
        /// </summary>
        /// <param name="expectedFailureCount">
        /// Expected amount of failure single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithFailedCheckContinue(int expectedFailureCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

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

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    InProgressFailedStatus,
                    FailedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="DataTransferState.CompletedWithSkippedTransfers"/> at the end without any failures.
        /// </summary>
        /// <param name="expectedSkipCount">
        /// Expected amount of skipped single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithSkippedCheck(int expectedSkipCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.AreEqual(expectedSkipCount, SkippedEvents.Count);

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    InProgressSkippedStatus,
                    SkippedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        public async Task AssertPausedCheck()
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);

            AssertTransferStatusCollection(
                new DataTransferStatus[] {
                    InProgressStatus,
                    new DataTransferStatusInternal(DataTransferState.Paused, false, false) },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// Static method which populates option bags event handlers being used by the TestEventsRaised in order
        /// to keep track of all the events that occur during the transfer.
        /// </summary>
        /// <param name="transferCount">The expected amount of options.</param>
        /// <param name="listOptions">The options bag reference. If there are existing options, use the existing options,
        /// if not default options will be created so event args can be added to the event handlers</param>
        /// <returns>A respective list of Events Raised coordinating with the options given.</returns>
        internal static List<TestEventsRaised> PopulateTestOptions(int transferCount, ref List<DataTransferOptions> listOptions)
        {
            List<TestEventsRaised> eventRaisedList = new List<TestEventsRaised>(transferCount);
            if (listOptions == default || listOptions?.Count == 0)
            {
                listOptions ??= new List<DataTransferOptions>(transferCount);
                for (int i = 0; i < transferCount; i++)
                {
                    DataTransferOptions currentOptions = new DataTransferOptions();
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
                foreach (DataTransferOptions currentOptions in listOptions)
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
