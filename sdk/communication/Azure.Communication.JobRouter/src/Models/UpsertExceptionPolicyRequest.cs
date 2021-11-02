// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter.Models
{
    internal partial class UpsertExceptionPolicyRequest
    {
        /// <summary> (Optional) A collection of exception rules on the exception policy. </summary>
        public IEnumerable<ExceptionRule> ExceptionRules { get; set; }
    }
}
