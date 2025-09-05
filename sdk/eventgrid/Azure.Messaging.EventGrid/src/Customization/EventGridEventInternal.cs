// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Messaging.EventGrid.Models
{
    internal partial class EventGridEventInternal
    {
        public JsonElement Data { get; set; }
    }
}
