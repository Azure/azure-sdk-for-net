// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of roles that can be run by any test scenario.
/// </summary>
///
public enum Role
{
    Publisher,
    BufferedPublisher,
    PartitionPublisher,
    Processor,
    Consumer
}