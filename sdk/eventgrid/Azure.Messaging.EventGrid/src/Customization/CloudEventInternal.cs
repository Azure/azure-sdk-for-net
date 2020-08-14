// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Models
{
    [CodeGenModel("CloudEvent")]
    internal partial class CloudEventInternal
    {
        public JsonElement? Data { get; set; }
    }
}
