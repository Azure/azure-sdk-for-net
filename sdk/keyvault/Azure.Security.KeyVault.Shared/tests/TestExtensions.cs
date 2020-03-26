// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    internal static class TestExtensions
    {
        public static TestCaseData ConditionalIgnore(this TestCaseData source, bool condition, string reason)
        {
            if (condition)
            {
                return source.Ignore(reason);
            }

            return source;
        }

        public static Stream ToStream(this AccessToken token)
        {
            var stream = new MemoryStream();
            using (var json = new Utf8JsonWriter(stream))
            {
                json.WriteStartObject();

                json.WriteString("access_token", token.Token);
                json.WriteNumber("expires_in", (long)(token.ExpiresOn - DateTimeOffset.UtcNow).TotalSeconds);

                json.WriteEndObject();
                json.Flush();
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public static Stream ToStream(this IJsonSerializable obj)
        {
            var stream = new MemoryStream();
            using (var json = new Utf8JsonWriter(stream))
            {
                json.WriteStartObject();

                obj.WriteProperties(json);

                json.WriteEndObject();
                json.Flush();
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}
