// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text;

namespace Azure.Core.Pipeline
{
#if !TESTFRAMEWORK
    internal static class ContentTypeUtilities
#else
#pragma warning disable SA1649 // File name should match first type name
    internal static class TestFrameworkContentTypeUtilities
#pragma warning restore SA1649 // File name should match first type name
#endif
    {
        public static bool TryGetTextEncoding(string contentType, out Encoding encoding)
        {
            const string charsetMarker = "; charset=";
            const string utf8Charset = "utf-8";
            const string textContentTypePrefix = "text/";
            const string jsonSuffix = "json";
            const string xmlSuffix = "xml";
            const string urlEncodedSuffix = "-urlencoded";

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
                contentType.EndsWith(urlEncodedSuffix, StringComparison.OrdinalIgnoreCase))
            {
                encoding = Encoding.UTF8;
                return true;
            }

            encoding = null;
            return false;
        }
    }
}
