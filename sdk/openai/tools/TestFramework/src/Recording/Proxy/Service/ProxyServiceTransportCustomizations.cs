// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.Proxy.Service;

/// <summary>
/// Transport customizations for the test proxy service.
/// </summary>
public class ProxyServiceTransportCustomizations()
{
    /// <summary> Gets or sets the allow auto redirect. </summary>
    public bool? AllowAutoRedirect { get; set; }

    /// <summary>
    /// If specified, the public key contained here will be used during validation of the SSL connection by
    /// comparing thumbprints.
    ///</summary>
    public string? TLSValidationCert { get; set; }

    /// <summary>
    /// If specified, the <see cref="TLSValidationCert"/> will only be applied to the specified host.
    /// </summary>
    public string? TSLValidationCertHost { get; set; }

    /// <summary>
    /// Each certificate pair contained within this list should be added to the clientHandler for the server
    /// or an individual recording.
    /// </summary>
    public IList<PemPair>? Certificates { get; set; }

    /// <summary>
    ///  During playback, a response is normally returned all at once. By offering this response time, we can
	/// "stretch" the writing of the response bytes over a time range of milliseconds.
    /// </summary>
    [JsonConverter(typeof(TimespanToMillisecondConverter))]
    public TimeSpan? PlaybackResponseTime { get; set; }
}
