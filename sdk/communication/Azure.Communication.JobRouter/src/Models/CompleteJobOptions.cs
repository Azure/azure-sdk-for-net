// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for completing a job.
    /// </summary>
    public partial class CompleteJobOptions
    {
        /// <summary>
        /// Custom supplied note.
        /// </summary>
        public string Note { get; set; }
    }
}
