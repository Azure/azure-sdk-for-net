// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventHubs
{
    /// <summary> A class representing the EventHubsNamespace data model. </summary>
    /// <summary> MessageRetentionInDays :- Number of days to retain the events for this Event Hub, value should be 1 to 7 days. </summary>
    public partial class EventHubData : ResourceData
    {
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? MessageRetentionInDays { get; set; }
    }
}
