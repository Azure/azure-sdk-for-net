// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.StandbyPool.Models
{
    /// <summary> Displays the counts of container groups in each state, as known by the StandbyPool resource provider. </summary>
    public partial class ContainerGroupInstanceCountSummary
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupInstanceCountSummary"/>. </summary>
        /// <param name="instanceCountsByState"> The count of pooled resources in each state. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ContainerGroupInstanceCountSummary(IReadOnlyList<PoolResourceStateCount> instanceCountsByState, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            InstanceCountsByState = instanceCountsByState;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary> The count of pooled resources in each state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PoolResourceStateCount> InstanceCountsByState { get; }
    }
}
