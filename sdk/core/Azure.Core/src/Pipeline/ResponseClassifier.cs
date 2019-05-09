// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;

namespace Azure.Core.Pipeline
{
    public class ResponseClassifier
    {
        /// <summary>
        /// Specifies if the response should terminate the pipeline and not be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(Response response)
        {
            return response.Status == 429 || response.Status == 503;
        }

        /// <summary>
        /// Specifies if the exception should terminate the pipeline and not be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
        {
            return (exception is IOException);
        }

        /// <summary>
        /// Specifies if the response is not successful but can be retried.
        /// </summary>
        public virtual bool IsErrorResponse(Response response)
        {
            var statusKind = response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }

        public static bool IsTextResponse(Response response, out Encoding encoding)
        {
            const string charsetMarker = "; charset=";
            const string utf8Charset = "utf-8";
            const string textContentTypePrefix = "text/";

            var contentType = response.Headers.ContentType;
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

            if (contentType.StartsWith(textContentTypePrefix))
            {
                encoding = Encoding.UTF8;
                return true;
            }

            encoding = null;
            return false;
        }
    }
}
