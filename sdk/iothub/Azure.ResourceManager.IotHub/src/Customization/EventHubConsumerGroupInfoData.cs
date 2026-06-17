// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    public partial class EventHubConsumerGroupInfoData
    {
        /// <summary> The tags. </summary>
        [CodeGenMember("Properties")]
        public IReadOnlyDictionary<string, BinaryData> Properties { get; }

        /// <summary> The etag. </summary>
        [CodeGenMember("Etag")]
        public ETag? ETag { get; }
    }
}
