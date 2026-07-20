// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.AppService
{
    public partial class WorkflowRunActionData
    {
        /// <summary> Gets the retry histories. </summary>
        [WirePath("properties.retryHistory")]
        public IReadOnlyList<WebAppRetryHistory> RetryHistory { get; }  // Customize the property as IReadOnlyList is intentionally retained for backward compatibility.
    }
}
