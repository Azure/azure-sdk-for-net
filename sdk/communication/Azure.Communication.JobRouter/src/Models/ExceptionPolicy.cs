// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ExceptionPolicy
    {
        /// <summary> Initializes a new instance of an exception policy. </summary>
        /// <param name="exceptionPolicyId"> Id of an exception policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        public ExceptionPolicy(string exceptionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));

            Id = exceptionPolicyId;
        }

        /// <summary> A collection of exception rules on the exception policy. </summary>
        public IList<ExceptionRule> ExceptionRules { get; } = new List<ExceptionRule>();

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary> The entity tag for this resource. </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; internal set; }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
