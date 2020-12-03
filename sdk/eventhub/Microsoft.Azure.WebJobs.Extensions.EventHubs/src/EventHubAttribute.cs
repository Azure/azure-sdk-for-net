// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Setup an 'output' binding to an EventHub. This can be any output type compatible with an IAsyncCollector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class EventHubAttribute : Attribute
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="EventHubAttribute"/>
        /// </summary>
        /// <param name="eventHubName">Name of the event hub.</param>
        public EventHubAttribute(string eventHubName)
        {
            EventHubName = eventHubName;
        }

        /// <summary>
        /// The name of the event hub.
        /// </summary>
        public string EventHubName { get; }

        /// <summary>
        /// Gets or sets the optional connection string name that contains the Event Hub connection string. If missing, tries to use a registered event hub sender.
        /// </summary>
        [AutoResolve]
        public string Connection { get; set; }
    }
}