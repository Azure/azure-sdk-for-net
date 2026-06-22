// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // The converted TypeSpec keeps the Event Hub consumer group payload's JSON "properties" bag as a
    // dictionary-shaped model member. This partial preserves the previous SDK's ability to expose that
    // bag directly as raw BinaryData values, which is useful because the service can add properties that
    // are not represented by strongly typed generated members. The CodeGenMember mapping ties this
    // public compatibility property back to the generated "Properties" member instead of introducing a
    // second serialized property.
    public partial class EventHubConsumerGroupInfoData
    {
        /// <summary> The properties. </summary>
        [CodeGenMember("Properties")]
        public IReadOnlyDictionary<string, BinaryData> Properties { get; }
    }
}
