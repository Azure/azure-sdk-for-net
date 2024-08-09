// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.RecordingProxy;

/// <summary>
/// The options for the recording test proxy transport.
/// </summary>
public class ProxyTransportOptions
{
    private Func<PipelineRequest?, RequestRecordMode>? _shouldRecordRequest;

    /// <summary>
    /// Gets or sets the test proxy HTTP endpoint.
    /// </summary>
    required public Uri HttpEndpoint { get; set; }

    /// <summary>
    /// Gets or sets the test proxy  HTTPS endpoint.
    /// </summary>
    required public Uri HttpsEndpoint { get; set; }

    /// <summary>
    /// Gets or sets the current test recording mode.
    /// </summary>
    required public RecordedTestMode Mode { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the recording.
    /// </summary>
    required public string RecordingId { get; set; }

    /// <summary>
    /// The ID for the request. Please make sure that a consistent ID is used during recording and playback to avoid
    /// mismatches.
    /// </summary>
    required public string RequestId { get; set; }

    /// <summary>
    /// Gets or sets the delegate used to get/set the test recording mismatch exception.
    /// </summary>
    public PropertyDelegate<TestRecordingMismatchException>? MismatchException { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use Fiddler. If this is true, the transport will be updated to accept
    /// the Fiddler root certificate.
    /// </summary>
    public bool UseFiddler { get; set; }

    /// <summary>
    /// Gets or sets the predicate used to determine whether or not a particular request should not be recorded.
    /// Default behaviour is to defer to what the matchers/sanitizers do.
    /// </summary>
    public Func<PipelineRequest?, RequestRecordMode> ShouldRecordRequest
    {
        get => _shouldRecordRequest ?? (_ => RequestRecordMode.Record);
        set => _shouldRecordRequest = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to allow cookies while sending and receiving requests.
    /// </summary>
    public bool AllowCookies { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to allow auto redirect when processing server responses.
    /// </summary>
    public bool AllowAutoRedirect { get; set; }
}
