// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class ContainerScanInfo
    {
        public ICollection<ITriggerExecutor<BlobTriggerExecutorContext>> Registrations { get; set; }

        public DateTimeOffset PollingStartTime { get; set; }

        public DateTimeOffset LastSweepCycleLatestModified { get; set; }

        public DateTimeOffset CurrentSweepCycleLatestModified { get; set; }

        public string ContinuationToken { get; set; }
    }
}
