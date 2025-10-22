// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Stress
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
    /// Which would mainly occur during <see cref="TransferErrorMode.ContinueOnFailure"/>
    /// </summary>
    public class StressEventsRaised : IDisposable
    {
        private static readonly TransferStatus InProgressStatus = new TransferStatusInternal(TransferState.InProgress, false, false);
        private static readonly TransferStatus InProgressFailedStatus = new TransferStatusInternal(TransferState.InProgress, true, false);
        private static readonly TransferStatus InProgressSkippedStatus = new TransferStatusInternal(TransferState.InProgress, false, true);
        private static readonly TransferStatus StoppingFailedStatus = new TransferStatusInternal(TransferState.Stopping, true, false);
        private static readonly TransferStatus SuccessfulCompletedStatus = new TransferStatusInternal(TransferState.Completed, false, false);
        private static readonly TransferStatus SkippedCompletedStatus = new TransferStatusInternal(TransferState.Completed, false, true);
        private static readonly TransferStatus FailedCompletedStatus = new TransferStatusInternal(TransferState.Completed, true, false);

        public List<TransferItemFailedEventArgs> FailedEvents { get; internal set; }
        private object _failedEventsLock = new();
        public List<TransferStatusEventArgs> StatusEvents { get; internal set; }
        public List<TransferItemSkippedEventArgs> SkippedEvents { get; internal set; }
        public ConcurrentBag<TransferItemCompletedEventArgs> SingleCompletedEvents { get; internal set; }

        private List<TransferOptions> _options;

        private StressEventsRaised()
        {
            FailedEvents = new List<TransferItemFailedEventArgs>();
            StatusEvents = new List<TransferStatusEventArgs>();
            SkippedEvents = new List<TransferItemSkippedEventArgs>();
            SingleCompletedEvents = new ConcurrentBag<TransferItemCompletedEventArgs>();
        }

        public StressEventsRaised(TransferOptions options)
            : this()
        {
            options.ItemTransferFailed += AppendFailedArg;
            options.TransferStatusChanged += AppendStatusArg;
            options.ItemTransferSkipped += AppendSkippedArg;
            options.ItemTransferCompleted += AppendSingleTransferCompleted;
            _options = new List<TransferOptions> { options };
        }

        public StressEventsRaised(List<TransferOptions> optionsList)
            : this()
        {
            _options = new List<TransferOptions>();
            foreach (TransferOptions options in optionsList)
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
            foreach (TransferOptions options in _options)
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

        private void AssertTransferStatusCollection(TransferStatus[] expected, TransferStatus[] actual)
        {
            Assert.That(actual.Length, Is.EqualTo(expected.Length));
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    if (!expected[i].Equals(actual[i]))
                    {
                        // Compared to individual Assert statements, this makes it clear when running the test, what's failing.
                        Assert.Fail($"Transfer State Mismatch:" +
                            $"Expected {nameof(TransferStatus.State)}: {expected[i].State}; Actual {nameof(TransferStatus.State)}: {actual[i].State}\n" +
                            $"Expected {nameof(TransferStatus.HasFailedItems)}: {expected[i].HasFailedItems}; Actual {nameof(TransferStatus.HasFailedItems)}: {actual[i].HasFailedItems}\n" +
                            $"Expected {nameof(TransferStatus.HasSkippedItems)}: {expected[i].HasSkippedItems}; Actual {nameof(TransferStatus.HasSkippedItems)}: {actual[i].HasSkippedItems}\n");
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
                        $"Source Resource Path: {failure.Source.Uri.AbsoluteUri}\n" +
                        $"Destination Resource Path: {failure.Destination.Uri.AbsoluteUri}\n" +
                        $"Exception Message: {failure.Exception.Message}\n" +
                        $"Exception Stack: {failure.Exception.StackTrace}\n");
                }
            });
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="TransferState.Completed"/> at the end without any skips
        /// or failures.
        /// </summary>
        public async Task AssertSingleCompletedCheck()
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SkippedEvents);
            Assert.IsEmpty(SingleCompletedEvents);

            AssertTransferStatusCollection(
                new TransferStatus[] {
                    InProgressStatus,
                    SuccessfulCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="TransferState.CompletedWithSkippedTransfers"/> at the end without any
        /// or failures.
        /// </summary>
        public async Task AssertSingleSkippedCheck()
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.IsEmpty(SingleCompletedEvents);
            Assert.That(SkippedEvents.Count, Is.EqualTo(1));
            Assert.NotNull(SkippedEvents.First().Source.Uri);
            Assert.NotNull(SkippedEvents.First().Destination.Uri);

            AssertTransferStatusCollection(
                new TransferStatus[] {
                    InProgressStatus,
                    InProgressSkippedStatus,
                    SkippedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a single transfer that is expected
        /// to have a <see cref="TransferState.CompletedWithFailedTransfers"/> at the end without any skips.
        /// </summary>
        public async Task AssertSingleFailedCheck(int failureCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            Assert.IsEmpty(SkippedEvents);
            Assert.IsEmpty(SingleCompletedEvents);
            Assert.That(FailedEvents.Count, Is.EqualTo(failureCount));
            foreach (TransferItemFailedEventArgs args in FailedEvents)
            {
                Assert.NotNull(args.Exception);
                Assert.NotNull(args.Source.Uri);
                Assert.NotNull(args.Destination.Uri);
            }

            AssertTransferStatusCollection(
                new TransferStatus[] {
                    InProgressStatus,
                    InProgressFailedStatus,
                    StoppingFailedStatus,
                    FailedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="TransferState.Completed"/> at the end without any skips
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
            Assert.That(SingleCompletedEvents.Count, Is.EqualTo(transferCount));

            AssertTransferStatusCollection(
                new TransferStatus[] {
                    InProgressStatus,
                    SuccessfulCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="TransferState.CompletedWithFailure"/> at the end without any skips.
        /// Assuming <see cref="TransferErrorMode.StopOnAnyFailure"/> was set.
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
                    Assert.That(FailedEvents.Count, Is.EqualTo(expectedFailureCount));
                });
            }
            Assert.IsEmpty(SkippedEvents);

            AssertTransferStatusCollection(
                new TransferStatus[] {
                    InProgressStatus,
                    InProgressFailedStatus,
                    StoppingFailedStatus,
                    FailedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="TransferState.CompletedWithFailure"/> at the end without any skips.
        /// Assuming <see cref="TransferErrorMode.ContinueOnFailure"/> was set.
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
                    Assert.That(FailedEvents.Count, Is.EqualTo(expectedFailureCount));
                });
            }
            Assert.IsEmpty(SkippedEvents);

            AssertTransferStatusCollection(
                new TransferStatus[] {
                    InProgressStatus,
                    InProgressFailedStatus,
                    FailedCompletedStatus },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// This asserts that the expected events occurred during a container transfer that is expected
        /// to have a <see cref="TransferState.CompletedWithSkippedTransfers"/> at the end without any failures.
        /// </summary>
        /// <param name="expectedSkipCount">
        /// Expected amount of skipped single transfers to occur within the container transfers.
        /// </param>
        public async Task AssertContainerCompletedWithSkippedCheck(int expectedSkipCount)
        {
            await WaitForStatusEventsAsync().ConfigureAwait(false);

            AssertUnexpectedFailureCheck();
            Assert.That(SkippedEvents.Count, Is.EqualTo(expectedSkipCount));

            AssertTransferStatusCollection(
                new TransferStatus[] {
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
                new TransferStatus[] {
                    InProgressStatus,
                    new TransferStatusInternal(TransferState.Paused, false, false) },
                StatusEvents.Select(e => e.TransferStatus).ToArray());
        }

        /// <summary>
        /// Static method which populates option bags event handlers being used by the StressEventsRaised in order
        /// to keep track of all the events that occur during the transfer.
        /// </summary>
        /// <param name="transferCount">The expected amount of options.</param>
        /// <param name="listOptions">The options bag reference. If there are existing options, use the existing options,
        /// if not default options will be created so event args can be added to the event handlers</param>
        /// <returns>A respective list of Events Raised coordinating with the options given.</returns>
        internal static List<StressEventsRaised> PopulateTestOptions(int transferCount, ref List<TransferOptions> listOptions)
        {
            List<StressEventsRaised> eventRaisedList = new List<StressEventsRaised>(transferCount);
            if (listOptions == default || listOptions?.Count == 0)
            {
                listOptions ??= new List<TransferOptions>(transferCount);
                for (int i = 0; i < transferCount; i++)
                {
                    TransferOptions currentOptions = new TransferOptions();
                    StressEventsRaised testEventRaisedCurrent = new StressEventsRaised(currentOptions);
                    listOptions.Add(currentOptions);
                    eventRaisedList.Add(testEventRaisedCurrent);
                }
            }
            else
            {
                // If blobNames is populated make sure these number of blobs match
                Assert.That(listOptions.Count, Is.EqualTo(transferCount));
                // Add TestEventRaised to each option
                foreach (TransferOptions currentOptions in listOptions)
                {
                    StressEventsRaised testEventRaisedCurrent = new StressEventsRaised(currentOptions);
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
