// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// EntitiesTask.
    /// </summary>
    [CodeGenModel("EntitiesTask")]
    public partial class EntitiesTask
    {
        /// <summary>
        /// Parameters for EntitiesTask
        /// </summary>
        public EntitiesTaskParameters Parameters { get; set; }
    }
}
