// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    /// <summary>Attribute to specify parameters for the Event Grid output binding.</summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class EventGridAttribute : Attribute
    {
        /// <summary>Gets or sets the topic events endpoint URI. Eg: https://topic1.westus2-1.eventgrid.azure.net/api/events
        /// This is found in the Event Grid Topic's definition. You can find information on getting the Url for a topic here: https://docs.microsoft.com/en-us/azure/event-grid/custom-event-quickstart#send-an-event-to-your-topic
        /// </summary>
        [AppSetting]
        public string TopicEndpointUri { get; set; }

        /// <summary>Gets or sets the Topic Key setting. You can find information on getting the Key for a topic here: https://docs.microsoft.com/en-us/azure/event-grid/custom-event-quickstart#send-an-event-to-your-topic </summary>
        [AppSetting]
        public string TopicKeySetting { get; set; }
    }
}