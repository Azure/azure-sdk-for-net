// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class MachineLearningServicesModelRegisteredEventData
    {
        /// <summary> The tags of the model that was registered. </summary>
        public object ModelTags { get; }
        /// <summary> The properties of the model that was registered. </summary>
        public object ModelProperties { get; }
    }
}
