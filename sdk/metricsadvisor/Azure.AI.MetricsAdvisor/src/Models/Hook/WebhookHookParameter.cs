// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The WebhookHookParameter. </summary>
    internal partial class WebhookHookParameter
    {
        public IDictionary<string, string> Headers { get; internal set; }
    }
}
