// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Stores the option bag and failures as the test progresses.
    ///
    /// This prevents a test from being torn down terribly when doing
    /// an Assert.Failure in the middle of an event.
    ///
    /// Alos if there's multiple failures then we will catch all of them.
    /// (Which would mainly occur during <see cref="ErrorHandlingOptions.ContinueOnFailure"/>
    /// </summary>
    internal class FailureTransferHolder
    {
        public List<TransferFailedEventArgs> FailedEvents { get; internal set; }

        private FailureTransferHolder()
        {
            FailedEvents = new List<TransferFailedEventArgs>();
        }

        public FailureTransferHolder(ContainerTransferOptions options)
            : base()
        {
            options.TransferFailed += AppendFailedArg;
        }

        public FailureTransferHolder(SingleTransferOptions options)
            : base()
        {
            options.TransferFailed += AppendFailedArg;
        }

        public FailureTransferHolder(List<SingleTransferOptions> optionsList)
            : base()
        {
            foreach (SingleTransferOptions options in optionsList)
            {
                options.TransferFailed += AppendFailedArg;
            }
        }
        public FailureTransferHolder(List<ContainerTransferOptions> optionsList)
            : base()
        {
            foreach (ContainerTransferOptions options in optionsList)
            {
                options.TransferFailed += AppendFailedArg;
            }
        }

        private Task AppendFailedArg(TransferFailedEventArgs args)
        {
            FailedEvents.Add(args);
            return Task.CompletedTask;
        }

        public void AssertFailureCheck()
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
    }
}
