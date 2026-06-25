// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // The converted TypeSpec keeps the Event Hub consumer group payload's JSON "properties" bag as a
    // dictionary-shaped model member. This partial preserves the previous SDK's ability to expose that
    // bag directly as raw BinaryData values, which is useful because the service can add properties that
    // are not represented by strongly typed generated members.
    /// <summary> The properties of the EventHubConsumerGroupInfo object. </summary>
    public partial class EventHubConsumerGroupInfoData
    {
        /// <summary> The properties. </summary>
        public IReadOnlyDictionary<string, BinaryData> Properties { get; }
    }
}
