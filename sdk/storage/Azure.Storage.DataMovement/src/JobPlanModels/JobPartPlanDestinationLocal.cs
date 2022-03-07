﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.JobPlanModels
{
    /// <summary>
    /// This matching the JobPartPlanDstLocal of azcopy
    /// </summary>
    internal class JobPartPlanDestinationLocal
    {
        // Once set, the following fields are constants; they should never be modified

        // Specifies whether the timestamp of destination file has to be set to the modified time of source file
        public bool PreserveLastModifiedTime;

        // says how MD5 verification failures should be actioned
        // uint_8
        public byte MD5VerificationOption;
    }
}
