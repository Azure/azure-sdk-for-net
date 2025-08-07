// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Matchers;

/// <summary>
/// This matcher exposes the default matcher in a customizable way. Currently this merely includes enabling/disabling body match and
/// adding additional excluded headers. All optional settings are safely defaulted. This means that providing zero additional
/// configuration will produce a sanitizer that is functionally identical to the default.
/// </summary>
public class CustomMatcher() : BaseMatcher("CustomDefaultMatcher")
{
    /// <summary>
    /// A comma separated list of additional headers that should be excluded during matching. "Excluded" headers are entirely ignored.
    /// Unlike "ignored" headers, the presence (or lack of presence) of a header will not cause mismatch.
    /// </summary>
    public string? ExcludedHeaders { get; set; }

    /// <summary>
    /// Should the body value be compared during lookup operations?
    /// </summary>
    public bool? CompareBodies { get; set; }

    /// <summary>
    /// A comma separated list of additional headers that should be ignored during matching. Any headers that are "ignored" will not
    /// do value comparison when matching. This means that if the recording has a header that isn't in the request, a test mismatch
    /// exception will be thrown noting the lack of header in the request. This also applies if the header is present in the request
    /// but not recording. 
    /// </summary>
    public string? IgnoredHeaders { get; set; }

    /// <summary>
    /// A comma separated list of query parameters that should be ignored during matching.
    /// </summary>
    public string? IgnoredQueryParameters { get; set; }

    /// <summary>
    /// By default, the test-proxy does not sort query params before matching. Setting true will sort query params alphabetically
    /// before comparing URI.
    /// </summary>
    public bool? IgnoreQueryOrdering { get; set; }
}
