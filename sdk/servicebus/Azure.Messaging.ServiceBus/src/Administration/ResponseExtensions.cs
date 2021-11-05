// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class ResponseExtensions
    {
        public static async Task<string> ReadAsStringAsync(this Response response)
        {
            using StreamReader reader = new StreamReader(
                stream: response.ContentStream,
                detectEncodingFromByteOrderMarks: true,
                encoding: Encoding.UTF8,
                // same default as https://github.com/microsoft/referencesource/blob/master/mscorlib/system/io/streamreader.cs#L59
                bufferSize: 1024,
                // leave the Response open
                leaveOpen: true);
            string content = await reader.ReadToEndAsync().ConfigureAwait(false);
            response.ContentStream.Position = 0;
            return content;
        }
    }
}
