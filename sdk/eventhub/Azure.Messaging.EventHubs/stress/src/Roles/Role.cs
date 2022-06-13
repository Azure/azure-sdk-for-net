// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Stress;

public enum Role
{
    Publisher,
    BufferedPublisher,
    Processor,
    Consumer,
    SenderQueue,
    BufferedSenderQueue
}