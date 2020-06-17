// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.ServiceBus.Core
{
    internal abstract class TransportBody
    {
        public BinaryData Body { get; set; }
    }
}
