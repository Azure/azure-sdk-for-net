// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.JobPlanModels
{
    internal enum JobPlanFromTo
    {
        Upload = 0,
        Download = 1,
        ServiceToService = 2,
    }
}
