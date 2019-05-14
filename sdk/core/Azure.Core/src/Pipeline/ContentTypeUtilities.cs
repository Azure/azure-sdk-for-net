// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Core.Pipeline
{
    internal class ContentTypeUtilities
    {
        public static bool IsText(string contentType, out Encoding encoding)
        {
            const string charsetMarker = "; charset=";
            const string utf8Charset = "utf-8";
            const string textContentTypePrefix = "text/";
            const string jsonSuffix = "json";
            const string xmlSuffix = "xml";

            if (contentType == null)
            {
                encoding = null;
                return false;
            }

            var charsetIndex = contentType.IndexOf(charsetMarker, StringComparison.InvariantCultureIgnoreCase);
            if (charsetIndex != -1)
            {
                ReadOnlySpan<char> charset = contentType.AsSpan().Slice(charsetIndex + charsetMarker.Length);
                if (charset.StartsWith(utf8Charset.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    encoding = Encoding.UTF8;
                    return true;
                }
            }

            if (contentType.StartsWith(textContentTypePrefix) ||
                contentType.EndsWith(jsonSuffix) ||
                contentType.EndsWith(xmlSuffix))
            {
                encoding = Encoding.UTF8;
                return true;
            }

            encoding = null;
            return false;
        }
    }
}
