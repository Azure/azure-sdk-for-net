// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.TestFramework.Models;

namespace Azure.Core.TestFramework
{
    public class RecordedTestSanitizer
    {
        public const string SanitizeValue = "Sanitized";

        /// <summary>
        /// The list of JSON path sanitizers to use when sanitizing a JSON request or response body.
        /// By default, "$..primaryKey", "$..secondaryKey", "$..primaryConnectionString", "$..secondaryConnectionString",
        /// and "$..connectionString" are included.
        /// </summary>
        public List<string> JsonPathSanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="BodyKeySanitizer"/> to use while sanitizing request and response bodies. This is similar to
        /// <see cref="JsonPathSanitizers"/>, but provides additional features such as regex matching, and customizing the sanitization replacement.
        /// </summary>
        public List<BodyKeySanitizer> BodyKeySanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="BodyRegexSanitizer"/> to use while sanitizing request and response bodies. This allows you to specify a
        /// regex for matching on specific content in the body.
        /// </summary>
        public List<BodyRegexSanitizer> BodyRegexSanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="UriRegexSanitizer"/> to use while sanitizing request and response URIs. This allows you to specify
        /// a regex for matching on the URI. <seealso cref="SanitizedQueryParameters"/> is a convenience property that allows you to sanitize
        /// query parameters without constructing the <see cref="UriRegexSanitizer"/> yourself.
        /// </summary>
        public List<UriRegexSanitizer> UriRegexSanitizers { get; } = new();

        /// <summary>
        /// The list of <see cref="HeaderTransform"/> to apply in Playback mode to the response headers.
        /// </summary>
        public List<HeaderTransform> HeaderTransforms = new();

        /// <summary>
        /// The list of <see cref="HeaderRegexSanitizer"/> to apply to the request and response headers. This allows you to specify
        /// a regex for matching on the header values. For simple use cases where you need to sanitize based solely on header key, use
        /// <see cref="SanitizedHeaders"/> instead. <seealso cref="SanitizedQueryParametersInHeaders"/> is a convenience property that allows
        /// you to sanitize query parameters out of specific headers without constructing the <see cref="HeaderRegexSanitizer"/> yourself.
        /// </summary>
        public List<HeaderRegexSanitizer> HeaderRegexSanitizers { get; } = new();

        /// <summary>
        /// The list of headers that will be sanitized on the request and response. By default, the "Authorization" header is included.
        /// </summary>
        public List<string> SanitizedHeaders { get; } = new() { "Authorization" };

        /// <summary>
        /// The list of query parameters that will be sanitized on the request and response URIs.
        /// </summary>
        public List<string> SanitizedQueryParameters { get; } = new();

        /// <summary>
        /// The list of header keys and query parameter tuples where the associated query parameter that should be sanitized from the corresponding
        /// request and response headers.
        /// </summary>
        public List<(string Header, string QueryParameter)> SanitizedQueryParametersInHeaders { get; } = new();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ReplacementHost
        {
            get => _replacementHost;
            set
            {
                _replacementHost = value;
                UriRegexSanitizers.Add(
                    new UriRegexSanitizer(@"https://(?<host>[^/]+)/", _replacementHost)
                    {
                        GroupForReplace = "host"
                    });
            }
        }

        private string _replacementHost;

        public RecordedTestSanitizer()
        {
            // Lazy sanitize fields in the request and response bodies
            JsonPathSanitizers.Add("$..primaryKey");
            JsonPathSanitizers.Add("$..secondaryKey");
            JsonPathSanitizers.Add("$..primaryConnectionString");
            JsonPathSanitizers.Add("$..secondaryConnectionString");
            JsonPathSanitizers.Add("$..connectionString");
        }
    }
}
