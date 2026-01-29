// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.ClientModel.TestFramework.TestProxy.Admin;

public partial class HeaderRegexSanitizer
{
    /// <summary>
    /// Creates a new <see cref="HeaderRegexSanitizer"/> instance configured to sanitize
    /// query parameters within HTTP header values during test recording.
    /// </summary>
    /// <param name="headerKey">
    /// The name of the HTTP header to sanitize. This should be the exact header name
    /// (e.g., "Authorization", "Location").
    /// </param>
    /// <param name="queryParameter">
    /// The name of the query parameter within the header value to sanitize. This should
    /// be the exact parameter name without the '=' sign (e.g., "api-version", "subscription-id").
    /// </param>
    /// <param name="sanitizedValue">
    /// The replacement value to use when sanitizing the query parameter. This value
    /// will replace the actual parameter value in recorded test sessions.
    /// </param>
    /// <returns>
    /// A configured <see cref="HeaderRegexSanitizer"/> that will match and sanitize
    /// the specified query parameter within the specified header value.
    /// </returns>
    public static HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string sanitizedValue) =>
        new(new HeaderRegexSanitizerBody(key: headerKey, value: sanitizedValue, regex: $@"([\x0026|&|?]{queryParameter}=)(?<group>[^&]+)", groupForReplace: "group", condition: null, additionalBinaryDataProperties: null));
}
