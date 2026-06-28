// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.AppService;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class WorkflowExpressionResourceErrorInfo : WebAppErrorInfo
    {
        // Missing property: Details
        /// <summary>
        /// The error details.
        /// </summary>
        [WirePath("details")]
        public IReadOnlyList<WorkflowExpressionResourceErrorInfo> Details { get; }
    }
}
