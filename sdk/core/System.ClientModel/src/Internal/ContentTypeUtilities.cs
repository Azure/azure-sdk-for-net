// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace System.ClientModel.Internal;

internal class ContentTypeUtilities
{
    public static bool TryGetTextEncoding(string contentType, out Encoding? encoding)
    {
        const string charsetMarker = "; charset=";
        const string utf8Charset = "utf-8";
        const string textContentTypePrefix = "text/";
        const string jsonSuffix = "json";
        const string appJsonPrefix = "application/json";
        const string xmlSuffix = "xml";
        const string urlEncodedSuffix = "-urlencoded";

        // Default is technically US-ASCII, but will default to UTF-8 which is a superset.
        const string appFormUrlEncoded = "application/x-www-form-urlencoded";

        if (contentType == null)
        {
            encoding = null;
            return false;
        }

        var charsetIndex = contentType.IndexOf(charsetMarker, StringComparison.OrdinalIgnoreCase);
        if (charsetIndex != -1)
        {
            ReadOnlySpan<char> charset = contentType.AsSpan().Slice(charsetIndex + charsetMarker.Length);
            if (charset.StartsWith(utf8Charset.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                encoding = Encoding.UTF8;
                return true;
            }
        }

        if (contentType.StartsWith(textContentTypePrefix, StringComparison.OrdinalIgnoreCase) ||
            contentType.EndsWith(jsonSuffix, StringComparison.OrdinalIgnoreCase) ||
            contentType.EndsWith(xmlSuffix, StringComparison.OrdinalIgnoreCase) ||
            contentType.EndsWith(urlEncodedSuffix, StringComparison.OrdinalIgnoreCase) ||
            contentType.StartsWith(appJsonPrefix, StringComparison.OrdinalIgnoreCase) ||
            contentType.StartsWith(appFormUrlEncoded, StringComparison.OrdinalIgnoreCase))
        {
            encoding = Encoding.UTF8;
            return true;
        }

        encoding = null;
        return false;
    }
}
