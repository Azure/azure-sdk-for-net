// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.ResourceManager.ComputeSchedule.Models
{
    public partial class ExecuteStartContent
    {
        /// <summary> Initializes a new instance of <see cref="ExecuteStartContent"/>. </summary>
        /// <param name="executionParameters"> The execution parameters for the request. </param>
        /// <param name="resources"> The resources for the request. </param>
        /// <param name="correlationId"> CorrelationId item. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="executionParameters"/>, <paramref name="resources"/> or <paramref name="correlationId"/> is null. </exception>
        public ExecuteStartContent(ScheduledActionExecutionParameterDetail executionParameters, UserRequestResources resources, string correlationId)
        {
            Argument.AssertNotNull(executionParameters, nameof(executionParameters));
            Argument.AssertNotNull(resources, nameof(resources));
            Argument.AssertNotNull(correlationId, nameof(correlationId));

            ExecutionParameters = executionParameters;
            Resources = resources;
            CorrelationId = correlationId;
        }
    }
}
