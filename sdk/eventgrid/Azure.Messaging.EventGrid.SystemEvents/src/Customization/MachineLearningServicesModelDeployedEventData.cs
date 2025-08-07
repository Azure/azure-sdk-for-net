// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MachineLearningServicesModelDeployedEventData
    {
        /// <summary> The tags of the deployed service. </summary>
        public object ServiceTags { get; }
        /// <summary> The properties of the deployed service. </summary>
        public object ServiceProperties { get; }
    }
}
