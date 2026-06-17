// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public partial class ExecuteDeleteContent
    {
        /// <summary> Initializes a new instance of <see cref="ExecuteDeleteContent"/>. </summary>
        /// <param name="executionParameters"> The execution parameters for the request. </param>
        /// <param name="resources"> The resources for the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="executionParameters"/>, <paramref name="resources"/> is null. </exception>
        public ExecuteDeleteContent(ScheduledActionExecutionParameterDetail executionParameters, UserRequestResources resources)
        {
            Argument.AssertNotNull(executionParameters, nameof(executionParameters));
            Argument.AssertNotNull(resources, nameof(resources));

            ExecutionParameters = executionParameters;
            Resources = resources;
        }
    }
}
