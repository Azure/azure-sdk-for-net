// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public partial class ExecuteDeallocateContent
    {
        /// <summary> Initializes a new instance of <see cref="ExecuteDeallocateContent"/>. </summary>
        /// <param name="executionParameters"> The execution parameters for the request. </param>
        /// <param name="resources"> The resources the operation should apply to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="executionParameters"/> or <paramref name="resources"/> is null. </exception>
        public ExecuteDeallocateContent(BulkActionExecutionParameterDetail executionParameters, UserRequestResources resources)
            : this(executionParameters)
        {
            if (resources is null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            Resources = resources;
        }
    }
}
