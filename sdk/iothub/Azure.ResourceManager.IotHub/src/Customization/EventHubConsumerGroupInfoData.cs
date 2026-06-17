// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    public partial class EventHubConsumerGroupInfoData
    {
        /// <summary> The properties. </summary>
        [CodeGenMember("Properties")]
        public IReadOnlyDictionary<string, BinaryData> Properties { get; }
    }
}
