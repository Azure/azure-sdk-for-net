// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.RecordingProxy.Models;

/// <summary>
/// Options for the test proxy.
/// </summary>
public class RecordingProxyOptions
{
    /// <summary>
    /// Options for the transport.
    /// </summary>
    public ProxyOptionsTransport? Transport { get; set; }
}
