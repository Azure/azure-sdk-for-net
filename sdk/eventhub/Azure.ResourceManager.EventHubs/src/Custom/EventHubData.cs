// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.EventHubs.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs
{
    // Suppress the generated MessageRetentionInDays property to add [Obsolete] and [EditorBrowsable(Never)] attributes
    // for backward compatibility with the old AutoRest-generated SDK.
    public partial class EventHubData
    {
        /// <summary> Number of days to retain the events for this Event Hub, value should be 1 to 7 days. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.messageRetentionInDays")]
        public long? MessageRetentionInDays
        {
            get
            {
                return Properties is null ? default : Properties.MessageRetentionInDays;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new EventhubProperties();
                }
                Properties.MessageRetentionInDays = value.Value;
            }
        }
    }
}
