// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    internal class FailureTrackingTransfer
    {
        internal SingleTransferOptions _singleOptions;
        internal ContainerTransferOptions _containerOptions;

        public List<TransferFailedEventArgs> FailedArguments { get; internal set; }

        public FailureTrackingTransfer(SingleTransferOptions transferOptions)
        {
            _singleOptions = transferOptions;
            _singleOptions.TransferFailed += GetFailedMessageEventArg;
            FailedArguments = new List<TransferFailedEventArgs>();
        }

        public FailureTrackingTransfer(ContainerTransferOptions transferOptions)
        {
            _containerOptions = transferOptions;
            _containerOptions.TransferFailed += GetFailedMessageEventArg;
            FailedArguments = new List<TransferFailedEventArgs>();
        }

        public Task GetFailedMessageEventArg(TransferFailedEventArgs args)
        {
            FailedArguments.Add(args);
            return Task.CompletedTask;
        }

        public void AssertIfFailuresOccured()
        {
            foreach ( TransferFailedEventArgs args in FailedArguments)
            {
                Assert.Fail($"Test failure at transfer id: {args.TransferId}.\n" +
                    $"Source Resource: {args.SourceResource.Uri.AbsoluteUri}\n" +
                    $"Destination Resource: {args.DestinationResource.Uri.AbsoluteUri}\n" +
                    $"Exception Message:\n{args.Exception.Message}\n" +
                    $"Stack Trace:\n{args.Exception.StackTrace}\n");
            }
        }
    }
}
