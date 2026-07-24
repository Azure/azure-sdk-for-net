// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public partial class ExecuteDeleteContent
    {
        /// <summary> Initializes a new instance of <see cref="ExecuteDeleteContent"/>. </summary>
        /// <param name="executionParameters"> The execution parameters for the request. </param>
        /// <param name="resources"> The resources for the request. </param>
        /// <remarks>
        /// Retained for binary/source compatibility with 1.1.0. resources is now optional; prefer the
        /// single-parameter constructor and set <see cref="Resources"/> or <see cref="ResourcesWithContext"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExecuteDeleteContent(BulkActionExecutionParameterDetail executionParameters, UserRequestResources resources)
            : this(executionParameters)
        {
            Resources = resources;
        }
    }
}
