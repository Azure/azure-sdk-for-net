// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The HookInfoPatch. </summary>
    internal partial class HookInfoPatch
    {
        /// <summary> hook administrators. </summary>
        public IReadOnlyList<string> Admins { get; internal set; }
    }
}
