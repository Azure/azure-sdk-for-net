// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.RecordingProxy.Models;

/// <summary>
/// Settings for the test proxy transport.
/// </summary>
public class ProxyOptionsTransport()
{
    /// <summary> Gets or sets the allow auto redirect. </summary>
    public bool? AllowAutoRedirect { get; set; }
    /// <summary> Gets or sets the tls validation certificate subject. </summary>
    public string? TLSValidationCert { get; set; }
    /// <summary> Gets the certificates. </summary>
    public IList<ProxyOptionsTransportCertificatesItem>? Certificates { get; set; }
}
