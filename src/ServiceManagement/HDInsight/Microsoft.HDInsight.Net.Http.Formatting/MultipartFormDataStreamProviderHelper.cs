// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    internal static class MultipartFormDataStreamProviderHelper
    {
        public static bool IsFileContent(HttpContent parent, HttpContentHeaders headers)
        {
            if (parent == null)
            {
                throw Error.ArgumentNull("parent");
            }

            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            // For form data, Content-Disposition header is a requirement.
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition == null)
            {
                // If no Content-Disposition header was present.
                throw Error.InvalidOperation(Resources.MultipartFormDataStreamProviderNoContentDisposition,
                    "Content-Disposition");
            }

            // The file name's existence indicates it is a file data.
            if (!String.IsNullOrEmpty(contentDisposition.FileName))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Read the non-file contents as form data.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the post processing.</returns>
        public static async Task ReadFormDataAsync(Collection<HttpContent> contents,
            NameValueCollection formData, CancellationToken cancellationToken)
        {
            // Find instances of HttpContent for which we created a memory stream and read them asynchronously
            // to get the string content and then add that as form data
            foreach (HttpContent content in contents)
            {
                ContentDispositionHeaderValue contentDisposition = content.Headers.ContentDisposition;
                // If FileName is null or empty, the content is form data and will be processed.
                if (String.IsNullOrEmpty(contentDisposition.FileName))
                {
                    // Extract name from Content-Disposition header. We know from earlier that the header is present.
                    string formFieldName = FormattingUtilities.UnquoteToken(contentDisposition.Name) ?? String.Empty;

                    // Read the contents as string data and add to form data
                    cancellationToken.ThrowIfCancellationRequested();
                    string formFieldValue = await content.ReadAsStringAsync();
                    formData.Add(formFieldName, formFieldValue);
                }
            }
        }
    }
}
