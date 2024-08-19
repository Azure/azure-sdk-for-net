// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Blobs.Stress;

/// <summary>
///   The set of roles that can be run by any test scenario.
/// </summary>
///
public enum Role
{
    Sender,
    Receiver,
    SessionSender,
    SessionReceiver,
    Processor,
    SessionProcessor,
    TransactionSender,
    TransactionReceiver
}
