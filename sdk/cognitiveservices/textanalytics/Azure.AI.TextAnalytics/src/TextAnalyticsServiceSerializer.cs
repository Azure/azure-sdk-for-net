// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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
                json.WriteString("countryHint", countryHint);
                json.WriteNumber("id", id++);
                json.WriteString("text", input);
                json.WriteEndObject();
            }
            json.WriteEndArray();
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

        public static ReadOnlyMemory<byte> SerializeLanguageInputs(List<DetectLangageInput> inputs)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteStartArray("documents");
            foreach (var input in inputs)
            {
                json.WriteStartObject();
                json.WriteString("countryHint", input.CountryHint);
                json.WriteString("id", input.Id);
                json.WriteString("text", input.Text);
                json.WriteEndObject();
            }
            json.WriteEndArray();
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

        public static async Task<TextAnalyticsResult<DetectedLanguage>> DeserializeDetectLanguageResponseAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadDetectLanguageResult(root);
            }
        }

        public static TextAnalyticsResult<DetectedLanguage> DeserializeDetectLanguageResponse(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadDetectLanguageResult(root);
            }
        }

        private static TextAnalyticsResult<DetectedLanguage> ReadDetectLanguageResult(JsonElement root)
        {
            // TODO (pri 2): make the deserializer version resilient
            var result = new TextAnalyticsResult<DetectedLanguage>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    var documentResult = new DocumentResult<DetectedLanguage>();

                    if (documentElement.TryGetProperty("id", out JsonElement idValue))
                        documentResult.Id = idValue.ToString();

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

                            documentResult.Predictions.Add(language);
                        }
                    }

                    if (documentElement.TryGetProperty("statistics", out JsonElement statisticsValue))
                    {
                        DocumentStatistics statistics = new DocumentStatistics();

                        if (statisticsValue.TryGetProperty("charactersCount", out JsonElement characterCountValue))
                            statistics.CharacterCount = characterCountValue.GetInt32();
                        if (statisticsValue.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                            statistics.TransactionCount = transactionCountValue.GetInt32();

                        documentResult.Statistics = statistics;
                    }
                }
            }

            if (root.TryGetProperty("errors", out JsonElement errorsValue))
            {
                foreach (JsonElement errorElement in errorsValue.EnumerateArray())
                {
                    DocumentError error = new DocumentError();

                    if (errorElement.TryGetProperty("id", out JsonElement idValue))
                        error.Id = idValue.ToString();
                    if (errorElement.TryGetProperty("error", out JsonElement errorValue))
                    {
                        if (errorsValue.TryGetProperty("message", out JsonElement messageValue))
                        {
                            error.Message = messageValue.ToString();
                        }
                    }

                    result.Errors.Add(error);
                }
            }

            if (root.TryGetProperty("modelVersion", out JsonElement modelVersionValue))
            {
                result.ModelVersion = modelVersionValue.ToString();
            }

            if (root.TryGetProperty("statistics", out JsonElement statisticsElement))
            {
                RequestStatistics statistics = new RequestStatistics();

                if (statisticsElement.TryGetProperty("documentsCount", out JsonElement documentCountValue))
                    statistics.DocumentsCount = documentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("validDocumentsCount", out JsonElement validDocumentCountValue))
                    statistics.ValidDocumentCount = validDocumentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("erroneousDocumentsCount", out JsonElement erroneousDocumentCountValue))
                    statistics.ErroneousDocumentCount = erroneousDocumentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                    statistics.DocumentsCount = transactionCountValue.GetInt32();
            }

            return result;
        }

        // This is a "simple" version that only gets the first in the list of returned languages.
        public static async Task<ResultBatch<DetectedLanguage>> ParseDetectedLanguageBatchSimpleAsync(Response response, CancellationToken cancellation)
        {
            Stream content = response.ContentStream;
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                return ParseLanguageBatchSimple(json);
            }
        }

        // This is a "simple" version that only gets the first in the list of returned languages.
        public static ResultBatch<DetectedLanguage> ParseDetectedLanguageBatchSimple(Response response)
        {
            // In this method, we get back a language result, and ignore some properties of it to create a collection of DetectedLanguage
            // TODO: we plan to return the full result in a more advanced scenario
            Stream content = response.ContentStream;
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return ParseLanguageBatchSimple(json);
            }
        }

        // This is a "simple" version that only gets the first in the list of returned languages.
        public static ResultBatch<DetectedLanguage> ParseLanguageBatchSimple(JsonDocument json)
        {
            JsonElement documentsArray = json.RootElement.GetProperty("documents");
            int length = documentsArray.GetArrayLength();
            DetectedLanguage[] values = new DetectedLanguage[length];

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

                // TODO: If needed, sort by score to get the value with the highest confidence.
                values[i++] = detectedLanguages.FirstOrDefault();
            }

            // The service doesn't currently support paging in the languages endpoint, but we expose
            // it in the SDK this way to allow the service to add this in the future without introducing
            // breaking changes to the API's SDK.  In the meantime, NextBatchLink in ResultBatch is null.
            return new ResultBatch<DetectedLanguage>(values, null);
        }

        //public static ResultBatch<List<DetectedLanguage>> ParseLanguageResultBatch(Response response)
        //{
        //    Stream content = response.ContentStream;
        //    using (JsonDocument json = JsonDocument.Parse(content))
        //    {

        //        //JsonElement documentsArray = json.RootElement.GetProperty("documents");
        //        //int length = documentsArray.GetArrayLength();
        //        //List<LanguageResult>[] values = new List<LanguageResult>[length];

        //        //int i = 0;
        //        //foreach (JsonElement documentElement in documentsArray.EnumerateArray())
        //        //{
        //        //    LanguageResult result = new LanguageResult();
        //        //    if (documentElement.TryGetProperty("id", out JsonElement idValue))
        //        //        result.Id = idValue;

        //        //    if (documentElement.TryGetProperty("detectedLanguages", out JsonElement detectedLanguagesValue))
        //        //    {
        //        //        foreach (JsonElement languageElement in detectedLanguagesValue.EnumerateArray())
        //        //        {
        //        //            var language = new DetectedLanguage();
        //        //            if (languageElement.TryGetProperty("name", out JsonElement name))
        //        //                language.Name = name.GetString();
        //        //            if (languageElement.TryGetProperty("iso6391Name", out JsonElement iso6391Name))
        //        //                language.Iso6391Name = iso6391Name.ToString();
        //        //            if (languageElement.TryGetProperty("score", out JsonElement scoreValue))
        //        //                if (scoreValue.TryGetDouble(out double score))
        //        //                    language.Score = score;

        //        //            // TODO: we're passing back a default struct here to indicate an error occured.
        //        //            // Work through clarifying this.
        //        //            langu.Add(language.Name != null ? language : default);
        //        //        }
        //        //    }

        //        //}

        //        //values[i++] = detectedLanguages;

        //        //// The service doesn't currently support paging in the languages endpoint, but we expose
        //        //// it in the SDK this way to allow the service to add this in the future without introducing
        //        //// breaking changes to the API's SDK.  In the meantime, NextBatchLink in ResultBatch is null.
        //        //return new ResultBatch<List<LanguageResult>>(values, null);
        //    }
        //}
    }
}
