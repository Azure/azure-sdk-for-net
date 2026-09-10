// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore timeout convenience constructor used by the flattened CommandJob.LimitsTimeout property.
    public partial class MachineLearningCommandJobLimits
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCommandJobLimits"/>. </summary>
        /// <param name="timeout"> The max run duration in ISO 8601 format, after which the job will be cancelled. </param>
        public MachineLearningCommandJobLimits(TimeSpan? timeout)
            : this()
        {
            Timeout = timeout;
        }
    }
}
