// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Testing
{
    public class RecordedTestSanitizer
    {
        protected const string SanitizeValue = "Sanitized";
        private static readonly string[] s_sanitizeValueArray = { SanitizeValue };

        private static readonly string[] s_sanitizedHeaders = { "Authorization" };

        public virtual string SanitizeUri(string uri)
        {
            return uri;
        }

        public virtual void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            foreach (var header in s_sanitizedHeaders)
            {
                if (headers.ContainsKey(header))
                {
                    headers[header] = s_sanitizeValueArray;
                }
            }
        }

        public virtual string SanitizeTextBody(string contentType, string body)
        {
            return body;
        }

        public virtual byte[] SanitizeBody(string contentType, byte[] body)
        {
            return body;
        }

        public virtual string SanitizeConnectionString(string connectionString) => connectionString;
        public virtual void SanitizeBody(RecordEntryMessage message)
        {
            if (message.Body != null)
            {
                int contentLength = message.Body.Length;

                message.TryGetContentType(out string contentType);

                if (message.TryGetBodyAsText(out string text))
                {
                    message.Body = Encoding.UTF8.GetBytes(SanitizeTextBody(contentType, text));
                }
                else
                {
                    message.Body = SanitizeBody(contentType, message.Body);
                }

                UpdateSanitizedContentLength(message.Headers, contentLength, message.Body?.Length ?? 0);
            }

        }

        public virtual void Sanitize(RecordEntry entry)
        {
            entry.RequestUri = SanitizeUri(entry.RequestUri);

            SanitizeHeaders(entry.Request.Headers);

            SanitizeBody(entry.Request);

            SanitizeHeaders(entry.Response.Headers);

            SanitizeBody(entry.Response);
        }


        /// <summary>
        /// Optionally update the Content-Length header if we've sanitized it
        /// and the new value is a different length from the original
        /// Content-Length header.  We don't add a Content-Length header if it
        /// wasn't already present.
        /// </summary>
        /// <param name="headers">The Request or Response headers</param>
        /// <param name="originalLength">THe original Content-Length</param>
        /// <param name="sanitizedLength">The sanitized Content-Length</param>
        protected static void UpdateSanitizedContentLength(IDictionary<string, string[]> headers, int originalLength, int sanitizedLength)
        {
            // Note: If the RequestBody/ResponseBody was set to null by our
            // sanitizer, we'll pass 0 as the sanitizedLength and use that as
            // our new Content-Length.  That's fine for all current scenarios
            // (i.e., we never do that), but it's possible we may want to
            // remove the Content-Length header in the future.
            if (originalLength != sanitizedLength && headers.ContainsKey("Content-Length"))
            {
                headers["Content-Length"] = new string[] { sanitizedLength.ToString() };
            }
        }

    }
}
