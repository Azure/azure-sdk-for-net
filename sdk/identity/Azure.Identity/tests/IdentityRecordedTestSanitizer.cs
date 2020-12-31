// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Identity.Tests
{
    public class IdentityRecordedTestSanitizer : RecordedTestSanitizer
    {
        public override void Sanitize(RecordEntry entry)
        {
            if (entry.RequestUri.Split('?')[0].EndsWith("/token"))
            {
                SanitizeTokenRequest(entry);
                SanitizeTokenResponse(entry);
            }

            base.Sanitize(entry);
        }

        private void SanitizeTokenRequest(RecordEntry entry)
        {
            entry.Request.Body = Encoding.UTF8.GetBytes("Sanitized");

            UpdateSanitizedContentLength(entry.Request.Headers, entry.Request.Body.Length);
        }

        private void SanitizeTokenResponse(RecordEntry entry)
        {
            if (entry.Response.Body == null)
            {
                return;
            }
            var originalJson = JsonDocument.Parse(entry.Response.Body).RootElement;

            var writer = new ArrayBufferWriter<byte>(entry.Response.Body.Length);

            using var sanitizedJson = new Utf8JsonWriter(writer);

            sanitizedJson.WriteStartObject();

            foreach (JsonProperty prop in originalJson.EnumerateObject())
            {
                sanitizedJson.WritePropertyName(prop.Name);

                switch (prop.Name)
                {
                    case "refresh_token":
                    case "access_token":
                        sanitizedJson.WriteStringValue("Sanitized");
                        break;

                    default:
                        prop.Value.WriteTo(sanitizedJson);
                        break;
                }
            }

            sanitizedJson.WriteEndObject();

            sanitizedJson.Flush();

            entry.Response.Body = writer.WrittenMemory.ToArray();
        }
    }
}
