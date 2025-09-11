// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Router Job Worker Selector. </summary>
    public partial class AcsRouterWorkerSelector
    {
        /// <summary> Router Job Worker Selector Label Operator. </summary>
        [CodeGenMember("LabelOperator")]
        public AcsRouterLabelOperator? Operator { get; }

        /// <summary> Router Job Worker Selector Label Operator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator? LabelOperator
        {
            get
            {
                if (Operator.HasValue)
                {
                    return new Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator(Operator.Value.ToString());
                }

                return null;
            }
        }

        /// <summary> Router Job Worker Selector State. </summary>
        [CodeGenMember("State")]
        public AcsRouterWorkerSelectorState? SelectorState { get; }

        /// <summary> Router Job Worker Selector State. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState? State
        {
            get
            {
                if (SelectorState.HasValue)
                {
                    return new Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState(SelectorState.Value.ToString());
                }

                return null;
            }
        }

        /// <summary> Router Job Worker Selector Value. </summary>
        public object LabelValue { get; }

        internal double? TtlSeconds { get; }

        /// <summary> Router Job Worker Selector TTL. </summary>
        public TimeSpan? TimeToLive => TtlSeconds.HasValue ? TimeSpan.FromSeconds(TtlSeconds.Value) : null;
    }
}
