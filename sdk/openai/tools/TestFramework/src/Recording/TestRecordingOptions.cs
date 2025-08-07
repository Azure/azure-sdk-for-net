// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Recording.Transforms;
using OpenAI.TestFramework.Utils;

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
    /// <remarks>You can find the list of sanitizer IDs to remove in two ways:
    /// <list type="bullet">
    /// <item>Sending a GET request to http://{proxy_endpoint}/Info/Active</item>
    /// <item>Looking at the source code for the test proxy here:
    /// https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/Common/SanitizerDictionary.cs</item>
    /// </list>
    /// </remarks>
    public ISet<string> SanitizersToRemove { get; } = new HashSet<string>()
    {
        // For now, we should leave the default sanitizers in place since it is better to err on the side of caution
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
        "User-Agent",
    };

    /// <summary>
    /// Headers to completely disregard when recording and matching. In other words it is as if these headers were never set.
    /// </summary>
    public ISet<string> ExcludedHeaders { get; } = new HashSet<string>()
    {
#if NETFRAMEWORK
        // .Net framework will add some headers not found in newer .Net versions so let's completely ignore them here. It is also
        // different in how it handles setting the Content-Length header when there is no body as compared to .Net
        "Connection",
        "Content-Length",
#endif
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
    public virtual void SanitizeHeaders(string sanitizedValue, IEnumerable<string> keys)
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
    public virtual void SanitizeJsonBody(string sanitizedValue, IEnumerable<string> jsonPaths)
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
