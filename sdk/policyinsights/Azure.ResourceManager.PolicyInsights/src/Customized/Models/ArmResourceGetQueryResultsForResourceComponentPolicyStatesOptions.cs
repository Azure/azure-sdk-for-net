// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    /// <summary>
    /// [Obsolete] Retained only so the obsolete extension method signature compiles. Do not use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This options class is no longer supported. Use the new ComponentPolicyStatesResource + PolicyQuerySettings overloads instead.")]
    public partial class ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions
    {
        /// <summary> [Obsolete] Do not use. </summary>
        public ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions() { }

        /// <summary> [Obsolete] Do not use. </summary>
        public ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions(ComponentPolicyStatesResource componentPolicyStatesResource)
        {
            ComponentPolicyStatesResource = componentPolicyStatesResource;
        }

        /// <summary> [Obsolete] Do not use. </summary>
        public ComponentPolicyStatesResource ComponentPolicyStatesResource { get; }

        /// <summary> [Obsolete] Do not use. </summary>
        public DateTimeOffset? From { get; set; }

        /// <summary> [Obsolete] Do not use. </summary>
        public DateTimeOffset? To { get; set; }

        /// <summary> [Obsolete] Do not use. </summary>
        public int? Top { get; set; }

        /// <summary> [Obsolete] Do not use. </summary>
        public string Apply { get; set; }

        /// <summary> [Obsolete] Do not use. </summary>
        public string Expand { get; set; }
        /// <summary> [Obsolete] Do not use. </summary>
        public string Filter { get; set; }

        /// <summary> [Obsolete] Do not use. </summary>
        public string OrderBy { get; set; }

        /// <summary> [Obsolete] Do not use. </summary>
        public string Select { get; set; }
    }
}
