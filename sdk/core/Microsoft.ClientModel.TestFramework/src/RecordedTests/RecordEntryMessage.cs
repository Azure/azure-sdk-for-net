// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Represents a recorded HTTP message entry containing headers and body data.
/// Used for storing and retrieving HTTP request/response information during test recording and playback.
/// </summary>
public class RecordEntryMessage
{
    /// <summary>
    /// Gets or sets the HTTP headers for this message entry.
    /// Headers are stored in a case-insensitive sorted dictionary where each header name maps to an array of values.
    /// </summary>
    public SortedDictionary<string, string[]> Headers { get; set; } = new SortedDictionary<string, string[]>(StringComparer.InvariantCultureIgnoreCase);

    /// <summary>
    /// Gets or sets the HTTP message body as a byte array.
    /// </summary>
    public byte[]? Body { get; set; }

    /// <summary>
    /// Attempts to retrieve the Content-Type header value from the message headers.
    /// </summary>
    /// <param name="contentType">When this method returns, contains the Content-Type header value if found; otherwise, null.</param>
    /// <returns>true if the Content-Type header was found and has exactly one value; otherwise, false.</returns>
    public bool TryGetContentType(out string? contentType)
    {
        contentType = null;
        if (Headers.TryGetValue("Content-Type", out var contentTypes) &&
            contentTypes.Length == 1)
        {
            contentType = contentTypes[0];
            return true;
        }
        return false;
    }

    /// <summary>
    /// Determines whether the message has a text-based content type and retrieves the associated encoding.
    /// </summary>
    /// <param name="encoding">When this method returns, contains the text encoding if the content type is text-based; otherwise, null.</param>
    /// <returns>true if the content type is text-based and an encoding was determined; otherwise, false.</returns>
    public bool IsTextContentType(out Encoding? encoding)
    {
        encoding = null;
        return TryGetContentType(out string? contentType) &&
                ContentTypeUtilities.TryGetTextEncoding(contentType!, out encoding);
    }

    /// <summary>
    /// Attempts to retrieve the message body as a text string if it has a text-based content type.
    /// </summary>
    /// <param name="text">When this method returns, contains the body content as a string if it's text-based; otherwise, null.</param>
    /// <returns>true if the body was successfully converted to text; otherwise, false.</returns>
    public bool TryGetBodyAsText(out string? text)
    {
        text = null;

        if (IsTextContentType(out Encoding? encoding))
        {
            text = encoding?.GetString(Body!);

            return true;
        }

        return false;
    }
}
