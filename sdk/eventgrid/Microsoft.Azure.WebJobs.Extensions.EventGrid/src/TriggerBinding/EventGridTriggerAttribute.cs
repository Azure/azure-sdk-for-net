// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    /// <summary>
    /// Attribute used to mark a job function parameter that should be bound to Azure Event Grid events.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class EventGridTriggerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridTriggerAttribute"/> class.
        /// </summary>
        public EventGridTriggerAttribute()
        {
        }
    }
}
