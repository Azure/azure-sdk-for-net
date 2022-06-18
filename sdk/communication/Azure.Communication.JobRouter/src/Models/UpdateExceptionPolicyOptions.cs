// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating exception policy.
    /// </summary>
    public class UpdateExceptionPolicyOptions
    {
        /// <summary> (Optional) The name of the exception policy. </summary>
        public string? Name { get; set; }

        /// <summary> (Optional) A dictionary collection of exception rules on the exception policy. Key is the Id of each exception rule. </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, ExceptionRule?>? ExceptionRules { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
