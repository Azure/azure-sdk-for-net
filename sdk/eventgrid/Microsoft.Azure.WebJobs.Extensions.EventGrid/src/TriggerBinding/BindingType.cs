// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    internal enum BindingType
    {
        Unknown,
        EventGridEvent,
        CloudEvent
    }
}