// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    /// <summary>
    /// [Obsolete] Retained as a type only so the obsolete extension method signature compiles. Do not use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This options class is no longer supported. Use the new ComponentPolicyStatesResource + PolicyQuerySettings overloads instead.")]
    public partial class ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions
    {
        /// <summary> [Obsolete] Do not use. </summary>
        public ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions() { }
    }
}
