// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class EventGridTriggerAttribute : Attribute
    {
        public EventGridTriggerAttribute()
        {
        }
    }
}
