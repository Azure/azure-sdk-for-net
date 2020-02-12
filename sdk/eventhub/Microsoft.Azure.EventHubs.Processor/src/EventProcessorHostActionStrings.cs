// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    internal static class EventProcessorHostActionStrings
    {
        internal static readonly string DownloadingLeases = "Downloading Leases";
        internal static readonly string CheckingLeases = "Checking Leases";
        internal static readonly string RenewingLease = "Renewing Lease";
        internal static readonly string ReleasingLease = "Releasing Lease";
        internal static readonly string StealingLease = "Stealing Lease";
        internal static readonly string CreatingLease = "Creating Lease";
        internal static readonly string ClosingEventProcessor = "Closing Event Processor";
        internal static readonly string CreatingCheckpoint = "Creating Checkpoint";
        internal static readonly string CreatingCheckpointStore = "Creating Checkpoint Store";
        internal static readonly string CreatingEventProcessor = "Creating Event Processor";
        internal static readonly string CreatingLeaseStore = "Creating Lease Store";
        internal static readonly string InitializingStores = "Initializing Stores";
        internal static readonly string OpeningEventProcessor = "Opening Event Processor";
        internal static readonly string PartitionManagerCleanup = "Partition Manager Cleanup";
        internal static readonly string PartitionManagerMainLoop = "Partition Manager Main Loop";
        internal static readonly string PartitionPumpManagement = "Managing Partition Pumps";
    }
}