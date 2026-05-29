// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    // Stand-in for the real EventHubProducerClient so the CustomChainedTokenCredential snippet
    // compiles without taking a project reference on Azure.Messaging.EventHubs (which would
    // create a circular dependency back through Azure.Core).
    internal class EventHubProducerClient
    {
        public EventHubProducerClient(string fullyQualifiedNamespace, string eventHubName, TokenCredential credential)
        {
        }
    }
}
