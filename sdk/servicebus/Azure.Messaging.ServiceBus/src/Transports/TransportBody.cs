// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.ServiceBus.Transports
{
    internal interface ITransportBody
    {
        BinaryData Body { get; set; }
    }
}
