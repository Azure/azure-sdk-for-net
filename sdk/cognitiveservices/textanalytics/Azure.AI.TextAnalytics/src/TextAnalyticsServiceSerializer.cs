// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    internal static class TextAnalyticsServiceSerializer
    {
        public static ReadOnlyMemory<byte> SerializeLanguageInput(string inputText, string countryHint)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteStartArray("documents");
            json.WriteStartObject();
            json.WriteString("countryHint", countryHint);
            json.WriteString("id", "1");  // TODO: change default - make handle multiple
            json.WriteString("text", inputText);
            json.WriteEndObject();
            json.WriteEndArray();
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

#pragma warning disable CA1801
        public static async Task<LanguageResult> DeserializeLanguageResponseAsync(Stream contentStream, CancellationToken cancellation)
#pragma warning restore
        {
            // TODO: implement

            await Task.Run(() => { }).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        public static LanguageResult DeserializeLanguageResponse(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadLanguageResponse(root);
            }
        }

        private static LanguageResult ReadLanguageResponse(JsonElement root)
        {
            // TODO (pri 2): make the deserializer version resilient
            var result = new LanguageResult();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    // deserialize the detected lanugages
                    // TODO: handle the ids correctly

                    if (documentElement.TryGetProperty("detectedLanguages", out JsonElement detectedLanguagesValue))
                    {
                        foreach (JsonElement languageElement in detectedLanguagesValue.EnumerateArray())
                        {
                            var language = new DetectedLanguage();
                            if (languageElement.TryGetProperty("name", out JsonElement name))
                                language.Name = name.GetString();
                            if (languageElement.TryGetProperty("iso6391Name", out JsonElement iso6391Name))
                                language.Iso6391Name = iso6391Name.ToString();
                            if (languageElement.TryGetProperty("score", out JsonElement scoreValue))
                                if (scoreValue.TryGetDouble(out double score))
                                    language.Score = score;
                            result.DetectedLanguages.Add(language);
                        }
                    }
                }
            }

            return result;
        }
    }
}
