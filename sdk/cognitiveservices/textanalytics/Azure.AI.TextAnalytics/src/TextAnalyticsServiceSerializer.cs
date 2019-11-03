// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
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
            json.WriteString("id", "1");
            json.WriteString("text", inputText);
            json.WriteEndObject();
            json.WriteEndArray();
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

        public static ReadOnlyMemory<byte> SerializeLanguageInputs(List<string> inputs, string countryHint)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteStartArray("documents");
            int id = 1;
            foreach (var input in inputs)
            {
                json.WriteStartObject();
                json.WriteString("countryHint", countryHint);   // TODO: allow per-input country hints
                json.WriteNumber("id", id++);                   // TODO: allow user-specified ids
                json.WriteString("text", input);
                json.WriteEndObject();
            }
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

        internal static ResultBatch<List<DetectedLanguage>> ParseDetectedLanguageBatch(Response response)
        {
            // In this method, we get back a language result, and ignore some properties of it to create a collection of DetectedLanguage
            // TODO: we plan to return the full result in a more advanced scenario
            Stream content = response.ContentStream;
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                JsonElement documentsArray = json.RootElement.GetProperty("documents");
                int length = documentsArray.GetArrayLength();
                List<DetectedLanguage>[] values = new List<DetectedLanguage>[length];

                int i = 0;
                foreach (JsonElement documentElement in documentsArray.EnumerateArray())
                {
                    var detectedLanguages = new List<DetectedLanguage>();
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

                            // TODO: we're passing back a default struct here to indicate an error occured.
                            // Work through clarifying this.
                            detectedLanguages.Add(language.Name != null ? language : default);
                        }
                    }

                    values[i++] = detectedLanguages;
                }

                // The service doesn't currently support paging in the languages endpoint, but we expose
                // it in the SDK this way to allow the service to add this in the future without introducing
                // breaking changes to the API's SDK.  In the meantime, NextBatchLink in ResultBatch is null.
                return new ResultBatch<List<DetectedLanguage>>(values, null);
            }
        }
    }
}
