﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class ContainerScanInfo
    {
        public ICollection<ITriggerExecutor<BlobTriggerExecutorContext>> Registrations { get; set; }

        public DateTime LastSweepCycleLatestModified { get; set; }

        public DateTime CurrentSweepCycleLatestModified { get; set; }

        public BlobContinuationToken ContinuationToken { get; set; }
    }
}
