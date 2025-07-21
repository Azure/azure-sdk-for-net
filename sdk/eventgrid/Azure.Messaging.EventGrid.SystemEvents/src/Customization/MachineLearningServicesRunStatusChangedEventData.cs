// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MachineLearningServicesRunStatusChangedEventData
    {
        /// <summary> The tags of the Machine Learning Run. </summary>
        public object RunTags { get; }
        /// <summary> The properties of the Machine Learning Run. </summary>
        public object RunProperties { get; }
    }
}
