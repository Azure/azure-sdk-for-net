// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Castle.Components.DictionaryAdapter;
using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.TestFramework
{
    public class AddDeleteAfterTagPolicy : HttpPipelineSynchronousPolicy
    {
        private DateTime RemoveDate { get; set; }
        private Regex _resourceGroupPattern = new Regex(@"/subscriptions/[^/]+/resourcegroups/([^?/]+)\?api-version");

        public AddDeleteAfterTagPolicy(DateTimeOffset dateTimeOffset)
        {
            RemoveDate = dateTimeOffset.DateTime;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Method == RequestMethod.Put)
            {
                var match = _resourceGroupPattern.Match(message.Request.Uri.ToString());
                if (match.Success)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        var newContent = new Utf8JsonRequestContent();
                        Utf8JsonWriter utf8JsonWriter = newContent.JsonWriter;
                        var stream = new MemoryStream();
                        message.Request.Content.WriteTo(stream, System.Threading.CancellationToken.None);
                        stream.Position = 0;
                        using (JsonDocument jsonDocument = JsonDocument.Parse(stream))
                        {
                            utf8JsonWriter.WriteStartObject();
                            if (jsonDocument.RootElement.TryGetProperty("tags", out _))
                            {
                                foreach (var element in jsonDocument.RootElement.EnumerateObject())
                                {
                                    if (element.Name == "tags")
                                    {
                                        if (!element.Value.TryGetProperty("DeleteAfter", out _))
                                        {
                                            utf8JsonWriter.WritePropertyName(element.Name);
                                            utf8JsonWriter.WriteStartObject();
                                            utf8JsonWriter.WritePropertyName("DeleteAfter");
                                            utf8JsonWriter.WriteStringValue(RemoveDate.AddHours(8).ToString("o", CultureInfo.InvariantCulture));

                                            foreach (var testDataElement in element.Value.EnumerateObject())
                                            {
                                                testDataElement.WriteTo(utf8JsonWriter);
                                            }
                                            utf8JsonWriter.WriteEndObject();
                                        }
                                        else
                                        {
                                            element.WriteTo(utf8JsonWriter);
                                        }
                                    }
                                    else
                                    {
                                        element.WriteTo(utf8JsonWriter);
                                    }
                                }
                            }
                            else
                            {
                                foreach (var testDataElement in jsonDocument.RootElement.EnumerateObject())
                                {
                                    testDataElement.WriteTo(utf8JsonWriter);
                                }
                                utf8JsonWriter.WritePropertyName("tags");
                                utf8JsonWriter.WriteStartObject();
                                utf8JsonWriter.WritePropertyName("DeleteAfter");
                                utf8JsonWriter.WriteStringValue(RemoveDate.AddHours(8).ToString("o", CultureInfo.InvariantCulture));
                                utf8JsonWriter.WriteEndObject();
                            }
                            utf8JsonWriter.WriteEndObject();
                            utf8JsonWriter.Flush();
                        }
                        message.Request.Content = newContent;
                    }
                }
            }
        }
    }
}
