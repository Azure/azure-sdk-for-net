// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal struct CheckpointInfo
    {
        public string Offset { get; }
        public long SequenceNumber { get; }
        public DateTimeOffset? LastModified { get; }

        public CheckpointInfo(string offset, long sequenceNumber, DateTimeOffset? lastModified)
        {
            Offset = offset;
            SequenceNumber = sequenceNumber;
            LastModified = lastModified;
        }
    }
}
