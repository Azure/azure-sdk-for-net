// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ComputeSchedule.Models
{
    public partial class SubmitHibernateContent
    {
        /// <summary> Initializes a new instance of <see cref="SubmitHibernateContent"/>. </summary>
        /// <param name="schedule"> The schedule for the request. </param>
        /// <param name="executionParameters"> The execution parameters for the request. </param>
        /// <param name="resources"> The resources for the request. </param>
        /// <param name="correlationId"> CorrelationId item. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="schedule"/>, <paramref name="executionParameters"/>, <paramref name="resources"/> or <paramref name="correlationId"/> is null. </exception>
        public SubmitHibernateContent(UserRequestSchedule schedule, ScheduledActionExecutionParameterDetail executionParameters, UserRequestResources resources, string correlationId)
        {
            Argument.AssertNotNull(schedule, nameof(schedule));
            Argument.AssertNotNull(executionParameters, nameof(executionParameters));
            Argument.AssertNotNull(resources, nameof(resources));
            Argument.AssertNotNull(correlationId, nameof(correlationId));

            Schedule = schedule;
            ExecutionParameters = executionParameters;
            Resources = resources;
            CorrelationId = correlationId;
        }
    }
}
