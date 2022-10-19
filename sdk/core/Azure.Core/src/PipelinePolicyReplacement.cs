// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Represents a policy to replace in the pipeline.
    /// </summary>
    public enum PipelinePolicyReplacement
    {
        /// <summary>
        /// Replace the default pipeline retry policy with a custom
        /// retry policy. The provided retry policy will need to set
        /// relevant values in PipelineContext on HttpMessage.
        /// </summary>
        RetryPolicy
    }
}
