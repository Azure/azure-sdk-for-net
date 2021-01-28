// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class ExceptionReceivedEventArgs
    {
        public string Action { get; }
        public string Hostname { get; }
        public string PartitionId { get; }
        public Exception Exception { get; }

        public ExceptionReceivedEventArgs(string hostname, string action, string partitionId, Exception exception)
        {
            Action = action;
            Hostname = hostname;
            PartitionId = partitionId;
            Exception = exception;
        }
    }
}
