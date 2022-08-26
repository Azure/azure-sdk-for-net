// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Compute.Batch.Models
{
    public partial class Job
    {
        public Job(string poolId, string jobId) : this()
        {
            Id = jobId;

            PoolInfo = new PoolInformation();
            PoolInfo.PoolId = poolId;
        }
    }
}
