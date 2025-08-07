// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

#nullable disable

namespace Azure.ResourceManager.TestFramework
{
    public class ResponseNullFilterPolicy : HttpPipelineSynchronousPolicy
    {
        public override void OnReceivedResponse(HttpMessage message)
        {
            //The delete method response only contains "value":null, after filter, nothing would left
            if (message.Request.Method != RequestMethod.Delete && message.Response.ContentStream != null)
            {
                StreamReader reader = new StreamReader(message.Response.ContentStream);
                string content = reader.ReadToEnd();
                if (content.Contains(":null"))
                {
                    // Replace \"\":null, with ,   with any number of \
                    content = Regex.Replace(content, "(,?)\\s*\\\\+\"[^\\\\+\"]*\\\\+\":null,?|,(})", "$1$2");
                    // Replace "":null, with ,
                    content = Regex.Replace(content, "(,?)\\s*\\\"[^\\\"]*\\\":null,?|,(})", "$1$2");
                    // Remove trailing comma
                    content = Regex.Replace(content, ",}", "}");
                    var matches = Regex.Matches(content, @",\r\n\s+}");
                    if (matches.Count > 0)
                    {
                        foreach (var match in matches)
                        {
                            string patten = match.ToString();
                            string replacement = match.ToString().Substring(1);
                            content = Regex.Replace(content, patten, replacement);
                        }
                    }
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
