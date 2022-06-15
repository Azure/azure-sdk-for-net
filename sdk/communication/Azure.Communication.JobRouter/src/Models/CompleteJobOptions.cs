// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for completing a job.
    /// </summary>
    public class CompleteJobOptions
    {
        /// <summary>
        /// Custom supplied note.
        /// </summary>
        public string? Note { get; set; }
    }
}
