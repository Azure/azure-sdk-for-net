// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.StorageSync.Tests.CustomPolicy
{
    /// <summary>
    /// The filter policy gets applied to incoming HTTP responses to filter out null key/values. This policy replaces
    /// https://github.com/Azure/azure-sdk-for-net/blob/808591fea35fa8780bf9eb99672d9c855fafa50a/common/ManagementTestShared/Redesign/ResponseNullFilterPolicy.cs
    /// and mitigates the regular expression bug that incorrectly replaces nested values.
    /// </summary>
    public class StorageSyncResponseNullFilterPolicy : HttpPipelineSynchronousPolicy
    {
        public override void OnReceivedResponse(HttpMessage message)
        {
            //The delete method response only contains "value":null, after filter, nothing would left
            if (message.Request.Method != RequestMethod.Delete && message.Response.ContentStream != null)
            {
                using (var reader = new StreamReader(message.Response.ContentStream))
                {
                    string content = reader.ReadToEnd();
                    if (content.Contains(":null"))
                    {
                        // Replace previously serialized "":null, with ,
                        content = Regex.Replace(content, "(,?)\\s*\\\\\"[^\\\"]*\\\\\":null,?|,(})", "$1$2");
                        // Replace "":null, with ,
                        content = Regex.Replace(content, "(,?)\\s*\\\"[^\\\"]*\\\":null,?|,(})", "$1$2");
                        // Remove trailing comma
                        content = Regex.Replace(content, ",}", "}");
                    }
                    var jsonDocument = string.IsNullOrEmpty(content) ? JsonDocument.Parse("{}") : JsonDocument.Parse(content);
                    var stream = new MemoryStream();
                    Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                    jsonDocument.WriteTo(writer);
                    writer.Flush();
                    message.Response.ContentStream = stream;
                    message.Response.ContentStream.Position = 0;
                }
            }
        }
    }
}
