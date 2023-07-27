// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/WebUtilities/src

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CA1806 // Didn't check TryParse
#pragma warning disable IDE0018 // Inline declaration

namespace Azure.Core.Http.Multipart
{
    /// <summary>
    /// Various extension methods for dealing with the section body stream
    /// </summary>
    internal static class MultipartSectionStreamExtensions
    {
        /// <summary>
        /// Reads the body of the section as a string
        /// </summary>
        /// <param name="section">The section to read from</param>
        /// <returns>The body steam as string</returns>
        public static async Task<string> ReadAsStringAsync(this MultipartSection section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            MediaTypeHeaderValue sectionMediaType;
            MediaTypeHeaderValue.TryParse(section.ContentType, out sectionMediaType);

            Encoding streamEncoding = sectionMediaType?.Encoding;
#pragma warning disable SYSLIB0001 // 'Encoding.UTF7' is obsolete: 'The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead.' - disabled because this code handles exactly that
            if (streamEncoding == null || streamEncoding == Encoding.UTF7)
#pragma warning restore SYSLIB0001
            {
                streamEncoding = Encoding.UTF8;
            }

            using (var reader = new StreamReader(
                section.Body,
                streamEncoding,
                detectEncodingFromByteOrderMarks: true,
                bufferSize: 1024,
                leaveOpen: true))
            {
                return await reader.ReadToEndAsync().ConfigureAwait(false);
            }
        }
    }
}
