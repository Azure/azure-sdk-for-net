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
        /// Initializes a new instance of CreateExceptionPolicyOptions.
        /// </summary>
        /// <param name="exceptionPolicyId"> Id of an exception policy. </param>
        /// <param name="exceptionRules"> A collection of exception rules on the exception policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionRules"/> is null. </exception>
        public CreateExceptionPolicyOptions(string exceptionPolicyId, IEnumerable<ExceptionRule> exceptionRules)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));
            Argument.AssertNotNull(exceptionRules, nameof(exceptionRules));

            ExceptionPolicyId = exceptionPolicyId;
            ExceptionRules.AddRange(exceptionRules);
        }

        /// <summary>
        /// Id of an exception policy.
        /// </summary>
        public string ExceptionPolicyId { get; }

        /// <summary>
        ///  A collection of exception rules on the exception policy.
        /// </summary>
        public IList<ExceptionRule> ExceptionRules { get; } = new List<ExceptionRule>();

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
