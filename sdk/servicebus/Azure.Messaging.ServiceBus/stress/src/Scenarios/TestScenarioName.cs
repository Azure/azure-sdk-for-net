// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The set of test scenarios that can be run.
/// </summary>
///
public enum TestScenarioName
{
    SendReceiveTest,
    SendReceiveBatchesTest,
    SessionSendReceiveTest,
    SendProcessTest,
    SessionSendProcessTest
}