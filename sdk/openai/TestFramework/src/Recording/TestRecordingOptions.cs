// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI.TestFramework.Recording.Common;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Recording.Transforms;

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// Options to configure a test recording. This can be used to set sanitizers to apply to the URI, headers, and/or body of a request
/// before matching, and before saving the recording. This can also be used to specify which matcher will be used to match a request
/// to a recorded one during playback. Finally this can be used to set the transforms applied to responses from the test proxy.
/// </summary>
public class TestRecordingOptions
{
    /// <summary>
    /// Creates a new instance
    /// </summary>
    public TestRecordingOptions()
    { }

    /// <summary>
    /// The list of sanitizers to apply to request before matching, and before saving a recording.
    /// </summary>
    public IList<BaseSanitizer> Sanitizers { get; } = new List<BaseSanitizer>();

    /// <summary>
    /// Gets or sets the matcher to use. If this is unset, a custom matcher will be created based on the options specified in this class.
    /// </summary>
    public BaseMatcher? Matcher { get; set; }

    /// <summary>
    /// The list of transforms to apply when returning a response during playback.
    /// </summary>
    public IList<BaseTransform> Transforms { get; } = new List<BaseTransform>();

    /// <summary>
    /// The sanitizers to remove from the list of default sanitizers. More details about default sanitizers can be found here:
    /// https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#removing-a-sanitizer.
    /// </summary>
    public ISet<string> SanitizersToRemove { get; } = new HashSet<string>()
    {
        "AZSDK2003", // Location header
        "AZSDK2006", // x-ms-rename-source
        "AZSDK2007", // x-ms-file-rename-source
        "AZSDK2008", // x-ms-copy-source
        "AZSDK2020", // x-ms-request-id
        "AZSDK2030", // Operation-location header
        "AZSDK3420", // $..targetResourceId
        "AZSDK3423", // $..source
        "AZSDK3424", // $..to
        "AZSDK3425", // $..from
        "AZSDK3430", // $..id
        "AZSDK3433", // $..userId
        "AZSDK3447", // $.key - app config key - not a secret
        "AZSDK3448", // $.value[*].key - search key - not a secret
        "AZSDK3451", // $..storageContainerUri - used for mixed reality - no sas token
        "AZSDK3478", // $..accountName
        "AZSDK3488", // $..targetResourceRegion
        "AZSDK3490", // $..etag
        "AZSDK3491", // $..functionUri
        "AZSDK3493", // $..name
        "AZSDK3494", // $..friendlyName
        "AZSDK3495", // $..targetModelLocation
        "AZSDK3496", // $..resourceLocation
        "AZSDK4001", // host name regex
    };

    /// <summary>
    /// Query parameters that we are only interested in checking if a value is set, but don't care about the actual value set.
    /// </summary>
    public ISet<string> IgnoredQueryParameters { get; } = new HashSet<string>();

    /// <summary>
    /// Headers that we are only interested in checking if a value is set, but don't care about the actual value set.
    /// </summary>
    public ISet<string> IgnoredHeaders { get; } = new HashSet<string>()
    {
        "Date",
        "x-ms-date",
        "x-ms-client-request-id",
        "User-Agent",
        "Request-Id",
        "traceparent",
    };

    /// <summary>
    /// Headers to completely disregard when recording and matching. In other words it is as if these headers were never set.
    /// </summary>
    public ISet<string> ExcludedHeaders { get; } = new HashSet<string>()
    {
        "Content-Type",
        "Content-Length",
        "Connection",
    };

    /// <summary>
    /// Whether or not we want to compare bodies from the request and the recorded request during playback. Default
    /// is true.
    /// </summary>
    public bool CompareBodies { get; set; } = true;

    /// <summary>
    /// A function used to override if recording is enabled for a particular request. This will override other settings present
    /// here.
    /// </summary>
    public Func<PipelineRequest?, RequestRecordMode>? RequestOverride { get; set; }

    /// <summary>
    /// Helper method to simplify sanitizing specific headers values. This will add a <see cref="HeaderRegexSanitizer"/> entry
    /// to <see cref="Sanitizers"/>. The default replacement value will be set to <see cref="Default.SanitizedValue"/>.
    /// </summary>
    /// <param name="keys">The keys to sanitize.</param>
    public void SanitizeHeaders(params string[] keys)
        => SanitizeHeaders(Default.SanitizedValue, keys);

    /// <summary>
    /// Helper method to simplify sanitizing specific headers values. This will add a <see cref="HeaderRegexSanitizer"/> entry
    /// to <see cref="Sanitizers"/>.
    /// </summary>
    /// <param name="sanitizedValue">The value to replace matches with.</param>
    /// <param name="keys">The keys to sanitize.</param>
    public virtual void SanitizeHeaders(string sanitizedValue, params string[] keys)
    {
        if (keys == null)
        {
            return;
        }

        foreach (var key in keys)
        {
            Sanitizers.Add(new HeaderRegexSanitizer(key) { Value = sanitizedValue });
        }
    }

    /// <summary>
    /// Helper method to sanitize specific parts of a JSON request body. This will add a <see cref="BodyKeySanitizer"/> entry
    /// to <see cref="Sanitizers"/> for each JSON path provided in <paramref name="jsonPaths"/>. The default replacement value
    /// will be set to <see cref="Default.SanitizedValue"/>.
    /// </summary>
    /// <param name="jsonPaths">The JSON paths to sanitize.</param>
    public void SanitizeJsonBody(params string[] jsonPaths)
        => SanitizeJsonBody(Default.SanitizedValue, jsonPaths);

    /// <summary>
    /// Helper method to sanitize specific parts of a JSON request body. This will add a <see cref="BodyKeySanitizer"/> entry
    /// to <see cref="Sanitizers"/> for each JSON path provided in <paramref name="jsonPaths"/>.
    /// </summary>
    /// <param name="sanitizedValue">The value to replace matches with.</param>
    /// <param name="jsonPaths">The JSON paths to sanitize.</param>
    public virtual void SanitizeJsonBody(string sanitizedValue, params string[] jsonPaths)
    {
        if (jsonPaths == null)
        {
            return;
        }

        foreach (var key in jsonPaths)
        {
            Sanitizers.Add(new BodyKeySanitizer(key) { Value = sanitizedValue });
        }
    }
}
