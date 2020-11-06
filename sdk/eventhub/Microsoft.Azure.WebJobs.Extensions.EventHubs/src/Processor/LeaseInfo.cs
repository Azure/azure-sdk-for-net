// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class LeaseInfo
    {
        public long Offset { get; }
        public long SequenceNumber { get; }

        public LeaseInfo(long offset, long sequenceNumber)
        {
            Offset = offset;
            SequenceNumber = sequenceNumber;
        }
    }
}
