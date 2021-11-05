// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Models
{
    [CodeGenModel("EventGridEvent")]
    internal partial class EventGridEventInternal
    {
        public JsonElement Data { get; set; }
    }
}
