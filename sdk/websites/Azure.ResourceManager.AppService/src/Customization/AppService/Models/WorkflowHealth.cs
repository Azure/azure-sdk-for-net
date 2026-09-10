// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppService.Models
{
    public partial class WorkflowHealth
    {
        // Remove this customization when this issue is fixed: https://github.com/Azure/autorest.csharp/issues/4798
        /// <summary> Gets or sets the workflow error. </summary>
        [WirePath("error")]
        public ResponseError Error { get; }
    }
}
