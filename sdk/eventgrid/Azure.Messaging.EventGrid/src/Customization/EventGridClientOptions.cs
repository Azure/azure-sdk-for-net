// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventGrid.Customization
{
    public class EventGridClientOptions : ClientOptions
    {
        public EventGridClientOptions(ServiceVersion version = ServiceVersion.V1_0)
        {
        }

        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V1_0 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
