// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public partial class ExecuteStartContent
    {
        /// <summary> Initializes a new instance of <see cref="ExecuteStartContent"/>. </summary>
        /// <param name="executionParameters"> The execution parameters for the request. </param>
        /// <param name="resources"> The resources for the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="executionParameters"/>, <paramref name="resources"/> is null. </exception>
        public ExecuteStartContent(ScheduledActionExecutionParameterDetail executionParameters, UserRequestResources resources)
        {
            Argument.AssertNotNull(executionParameters, nameof(executionParameters));
            Argument.AssertNotNull(resources, nameof(resources));

            ExecutionParameters = executionParameters;
            Resources = resources;
        }
    }
}
