// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Proxy.Service;

/// <summary>
/// Information about certificates for the test proxy service.
/// </summary>
public class PemPair
{
    /// <summary> Gets or sets the pem value. </summary>
    public string? PemValue { get; set; }
    /// <summary> Gets or sets the pem key. </summary>
    public string? PemKey { get; set; }
}
