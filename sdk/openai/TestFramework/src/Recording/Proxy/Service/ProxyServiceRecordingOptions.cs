// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Proxy.Service;

/// <summary>
/// Options for the test proxy.
/// </summary>
public class ProxyServiceRecordingOptions
{
    /// <summary>
    /// Whether or not to follow redirects
    /// </summary>
    public bool? HandleRedirects { get; set; }

    /// <summary>
    /// If set, this will change the "root" path the test proxy uses when loading a recording.
    /// </summary>
    public string? ContextDirectory { get; set; }

    /// <summary>
    /// Options for the transport.
    /// </summary>
    public ProxyServiceTransportCustomizations? Transport { get; set; }
}
