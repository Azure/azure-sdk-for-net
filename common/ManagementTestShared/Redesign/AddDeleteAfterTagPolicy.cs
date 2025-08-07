// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

#nullable disable

namespace Azure.ResourceManager.TestFramework
{
    public class AddDeleteAfterTagPolicy : HttpPipelineSynchronousPolicy
    {
        private DateTime RemoveDate { get; set; }
        private static readonly Regex _resourceGroupPattern = new Regex(@"/subscriptions/[^/]+/resourcegroups/([^?/]+)\?api-version");

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
                        message.Request.Content.WriteTo(stream, CancellationToken.None);
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

        // since we removed Utf8JsonRequestContent in the shared code, but this class needs it, therefore we temporarily add it back in this way here
        private class Utf8JsonRequestContent : RequestContent
        {
            private readonly MemoryStream _stream;
            private readonly RequestContent _content;

            public Utf8JsonRequestContent()
            {
                _stream = new MemoryStream();
                _content = Create(_stream);
                JsonWriter = new Utf8JsonWriter(_stream);
            }

            public Utf8JsonWriter JsonWriter { get; }

            public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
            {
                await JsonWriter.FlushAsync().ConfigureAwait(false);
                await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
            {
                JsonWriter.Flush();
                _content.WriteTo(stream, cancellationToken);
            }

            public override bool TryComputeLength(out long length)
            {
                length = JsonWriter.BytesCommitted + JsonWriter.BytesPending;
                return true;
            }

            public override void Dispose()
            {
                JsonWriter.Dispose();
                _content.Dispose();
                _stream.Dispose();
            }
        }
    }
}
