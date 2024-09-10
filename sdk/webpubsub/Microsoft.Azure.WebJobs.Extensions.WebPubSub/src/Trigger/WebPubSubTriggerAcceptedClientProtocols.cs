// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

/// <summary>
/// Specifies which client protocol can trigger the Web PubSub trigger functions.
/// </summary>
public enum WebPubSubTriggerAcceptedClientProtocols
{
    /// <summary>
    /// Accepts all client protocols. Default value.
    /// </summary>
    All,
    /// <summary>
    /// Accepts only WebPubSub client protocol.
    /// </summary>
    WebPubSub,
    /// <summary>
    /// Accepts only MQTT client protocol.
    /// </summary>
    Mqtt,
}
