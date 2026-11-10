// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace System.ClientModel.Internal;

internal class ContentTypeUtilities
{
    private const string Utf8Charset = "utf-8";
    private const string CharsetPrefix = "charset";
    private const string TextContentTypePrefix = "text/";
    private const string JsonSuffix = "json";
    private const string AppJsonPrefix = "application/json";
    private const string XmlSuffix = "xml";
    private const string UrlEncodedSuffix = "-urlencoded";

    // Default is technically US-ASCII, but will default to UTF-8 which is a superset.
    private const string AppFormUrlEncoded = "application/x-www-form-urlencoded";

    public static bool TryGetTextEncoding(string contentType, out Encoding? encoding)
    {
        if (string.IsNullOrWhiteSpace(contentType))
        {
            encoding = null;
            return false;
        }

        if (HasUtf8Charset(contentType))
        {
            encoding = Encoding.UTF8;
            return true;
        }

        int semicolonIndex = contentType.IndexOf(';');
        string mediaType = (semicolonIndex == -1 ? contentType : contentType.Substring(0, semicolonIndex)).Trim();

        if (mediaType.StartsWith(TextContentTypePrefix, StringComparison.OrdinalIgnoreCase) ||
            mediaType.EndsWith(JsonSuffix, StringComparison.OrdinalIgnoreCase) ||
            mediaType.EndsWith(XmlSuffix, StringComparison.OrdinalIgnoreCase) ||
            mediaType.EndsWith(UrlEncodedSuffix, StringComparison.OrdinalIgnoreCase) ||
            mediaType.StartsWith(AppJsonPrefix, StringComparison.OrdinalIgnoreCase) ||
            mediaType.StartsWith(AppFormUrlEncoded, StringComparison.OrdinalIgnoreCase))
        {
            encoding = Encoding.UTF8;
            return true;
        }

        encoding = null;
        return false;
    }

    private static bool HasUtf8Charset(string contentType)
    {
        int index = 0;
        while (index < contentType.Length)
        {
            int semiIndex = contentType.IndexOf(';', index);
            if (semiIndex == -1)
            {
                break;
            }

            ReadOnlySpan<char> param = contentType.AsSpan().Slice(semiIndex + 1).TrimStart();
            if (param.StartsWith(CharsetPrefix.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                ReadOnlySpan<char> afterCharset = param.Slice(CharsetPrefix.Length).TrimStart();
                if (!afterCharset.IsEmpty && afterCharset[0] == '=')
                {
                    ReadOnlySpan<char> value = afterCharset.Slice(1).TrimStart();
                    if (!value.IsEmpty && value[0] == '"')
                    {
                        value = value.Slice(1);
                    }

                    if (value.StartsWith(Utf8Charset.AsSpan(), StringComparison.OrdinalIgnoreCase))
                    {
                        ReadOnlySpan<char> rest = value.Slice(Utf8Charset.Length);
                        if (rest.IsEmpty || rest[0] == '"' || rest[0] == ';' || char.IsWhiteSpace(rest[0]))
                        {
                            return true;
                        }
                    }
                }
            }

            index = semiIndex + 1;
        }

        return false;
    }
}
