// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating exception policy.
    /// </summary>
    public class CreateExceptionPolicyOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="exceptionPolicyId"> Id of the policy. </param>
        /// <param name="exceptionRules"> A dictionary collection of exception rules on the exception policy. Key is the Id of each exception rule. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionRules"/> is null. </exception>
        public CreateExceptionPolicyOptions(string exceptionPolicyId, IDictionary<string, ExceptionRule> exceptionRules)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));
            Argument.AssertNotNullOrEmpty(exceptionRules, nameof(exceptionRules));

            ExceptionPolicyId = exceptionPolicyId;
            ExceptionRules = exceptionRules;
        }

        /// <summary>
        /// The Id of this policy.
        /// </summary>
        public string ExceptionPolicyId { get; }

        /// <summary>
        /// A dictionary collection of exception rules on the exception policy. Key is the Id of each exception rule.
        /// </summary>
        public IDictionary<string, ExceptionRule> ExceptionRules { get; }

        /// <summary> (Optional) The name of the exception policy. </summary>
        public string Name { get; set; }
    }
}
