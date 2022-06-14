// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System.Collections.Generic;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating exception policy.
    /// </summary>
    public class CreateExceptionPolicyOptions
    {
        /// <summary> (Optional) The name of the exception policy. </summary>
        public string? Name { get; set; }
    }
}
