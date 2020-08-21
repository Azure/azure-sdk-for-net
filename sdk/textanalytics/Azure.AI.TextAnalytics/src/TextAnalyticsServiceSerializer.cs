// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    internal static class TextAnalyticsServiceSerializer
    {
        // TODO (pri 2): make the deserializer version resilient

        private static List<T> SortHeterogeneousCollection<T>(List<T> collection, IDictionary<string, int> idToIndexMap) where T : TextAnalyticsResult
        {
            return collection.OrderBy(result => idToIndexMap[result.Id]).ToList();
        }

        #region Serialize Inputs

        private static readonly JsonEncodedText s_documents = JsonEncodedText.Encode("documents");
        private static readonly JsonEncodedText s_id = JsonEncodedText.Encode("id");
        private static readonly JsonEncodedText s_language = JsonEncodedText.Encode("language");
        private static readonly JsonEncodedText s_text = JsonEncodedText.Encode("text");

        public static ReadOnlyMemory<byte> SerializeDocumentInputs(IEnumerable<TextDocumentInput> inputs, string defaultLanguage)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteStartArray(s_documents);
            foreach (var input in inputs)
            {
                json.WriteStartObject();
                json.WriteString(s_language, input.Language ?? defaultLanguage);
                json.WriteString(s_id, input.Id);
                json.WriteString(s_text, input.Text);
                json.WriteEndObject();
            }
            json.WriteEndArray();
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

        #endregion Serialize Inputs

        #region Deserialize Common

        private static string ReadDocumentId(JsonElement documentElement)
        {
            if (documentElement.TryGetProperty("id", out JsonElement idValue))
                return idValue.ToString();

            return default;
        }

        private static TextDocumentStatistics ReadDocumentStatistics(JsonElement documentElement)
        {
            if (documentElement.TryGetProperty("statistics", out JsonElement statisticsValue))
            {
                int characterCount = default;
                int transactionCount = default;

                if (statisticsValue.TryGetProperty("charactersCount", out JsonElement characterCountValue))
                    characterCount = characterCountValue.GetInt32();
                if (statisticsValue.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                    transactionCount = transactionCountValue.GetInt32();

                return new TextDocumentStatistics(characterCount, transactionCount);
            }

            return default;
        }

        internal static IEnumerable<TextAnalyticsResult> ReadDocumentErrors(JsonElement documentElement)
        {
            List<TextAnalyticsResult> errors = new List<TextAnalyticsResult>();

            if (documentElement.TryGetProperty("errors", out JsonElement errorsValue))
            {
                foreach (JsonElement errorElement in errorsValue.EnumerateArray())
                {
                    string id = default;

                    if (errorElement.TryGetProperty("id", out JsonElement idValue))
                        id = idValue.ToString();
                    if (errorElement.TryGetProperty("error", out JsonElement errorValue))
                    {
                        errors.Add(new TextAnalyticsResult(id, ReadTextAnalyticsError(errorValue)));
                    }
                }
            }

            return errors;
        }

        internal static TextAnalyticsError ReadTextAnalyticsError(JsonElement element)
        {
            string errorCode = default;
            string message = default;
            string target = default;
            TextAnalyticsError innerError = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    errorCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    innerError = ReadTextAnalyticsError(property.Value);
                    continue;
                }
            }

            // Return the innermost error, which should be only one level down.
            return innerError.ErrorCode == default ? new TextAnalyticsError(errorCode, message, target) : innerError;
        }

        private static List<TextAnalyticsWarning> ReadDocumentWarnings(JsonElement documentElement)
        {
            List<TextAnalyticsWarning> warnings = new List<TextAnalyticsWarning>();

            foreach (JsonElement warningElement in documentElement.EnumerateArray())
            {
                string code = default;
                string message = default;

                if (warningElement.TryGetProperty("code", out JsonElement codeValue))
                {
                    code = codeValue.ToString();
                }

                if (warningElement.TryGetProperty("message", out JsonElement messageValue))
                {
                    message = messageValue.ToString();
                }

                warnings.Add(new TextAnalyticsWarning(code, message));
            }

            return warnings;
        }

        private static string ReadModelVersion(JsonElement documentElement)
        {
            if (documentElement.TryGetProperty("modelVersion", out JsonElement modelVersionValue))
            {
                return modelVersionValue.ToString();
            }

            return default;
        }

        private static TextDocumentBatchStatistics ReadDocumentBatchStatistics(JsonElement documentElement)
        {
            if (documentElement.TryGetProperty("statistics", out JsonElement statisticsElement))
            {
                int documentCount = default;
                int validDocumentCount = default;
                int invalidDocumentCount = default;
                long transactionCount = default;

                if (statisticsElement.TryGetProperty("documentsCount", out JsonElement documentCountValue))
                    documentCount = documentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("validDocumentsCount", out JsonElement validDocumentCountValue))
                    validDocumentCount = validDocumentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("erroneousDocumentsCount", out JsonElement erroneousDocumentCountValue))
                    invalidDocumentCount = erroneousDocumentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                    transactionCount = transactionCountValue.GetInt64();

                return new TextDocumentBatchStatistics(documentCount, validDocumentCount, invalidDocumentCount, transactionCount);
            }

            return default;
        }

        #endregion Deserialize Common

        #region Linked Entities

        public static async Task<RecognizeLinkedEntitiesResultCollection> DeserializeLinkedEntityResponseAsync(Stream content, IDictionary<string, int> idToIndexMap, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadLinkedEntityResultCollection(root, idToIndexMap);
        }

        public static RecognizeLinkedEntitiesResultCollection DeserializeLinkedEntityResponse(Stream content, IDictionary<string, int> idToIndexMap)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadLinkedEntityResultCollection(root, idToIndexMap);
        }

        private static RecognizeLinkedEntitiesResultCollection ReadLinkedEntityResultCollection(JsonElement root, IDictionary<string, int> idToIndexMap)
        {
            var collection = new List<RecognizeLinkedEntitiesResult>();

            TextDocumentBatchStatistics statistics = ReadDocumentBatchStatistics(root);
            string modelVersion = ReadModelVersion(root);

            foreach (var error in ReadDocumentErrors(root))
            {
                collection.Add(new RecognizeLinkedEntitiesResult(error.Id, error.Error));
            }

            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    collection.Add(ReadLinkedEntityResult(documentElement));
                }
            }

            collection = SortHeterogeneousCollection(collection, idToIndexMap);

            return new RecognizeLinkedEntitiesResultCollection(collection, statistics, modelVersion);
        }

        private static RecognizeLinkedEntitiesResult ReadLinkedEntityResult(JsonElement documentElement)
        {
            List<LinkedEntity> entities = new List<LinkedEntity>();
            List<TextAnalyticsWarning> warnings = default;

            if (documentElement.TryGetProperty("entities", out JsonElement entitiesValue))
            {
                foreach (JsonElement entityElement in entitiesValue.EnumerateArray())
                {
                    entities.Add(ReadLinkedEntity(entityElement));
                }
            }

            if (documentElement.TryGetProperty("warnings", out JsonElement warningsValue))
            {
                warnings = ReadDocumentWarnings(warningsValue);
            }

            return new RecognizeLinkedEntitiesResult(
                ReadDocumentId(documentElement),
                ReadDocumentStatistics(documentElement),
                new LinkedEntityCollection(entities, warnings));
        }

        private static LinkedEntity ReadLinkedEntity(JsonElement entityElement)
        {
            string name = default;
            string id = default;
            string language = default;
            string dataSource = default;
            Uri url = default;

            if (entityElement.TryGetProperty("name", out JsonElement nameElement))
                name = nameElement.ToString();
            if (entityElement.TryGetProperty("id", out JsonElement idElement))
                id = idElement.ToString();
            if (entityElement.TryGetProperty("language", out JsonElement languageElement))
                language = languageElement.ToString();
            if (entityElement.TryGetProperty("dataSource", out JsonElement dataSourceValue))
                dataSource = dataSourceValue.ToString();
            if (entityElement.TryGetProperty("url", out JsonElement urlValue))
                url = new Uri(urlValue.ToString());

            IEnumerable<LinkedEntityMatch> matches = ReadLinkedEntityMatches(entityElement);

            return new LinkedEntity(name, id, language, dataSource, url, matches);
        }

        private static IEnumerable<LinkedEntityMatch> ReadLinkedEntityMatches(JsonElement entityElement)
        {
            if (entityElement.TryGetProperty("matches", out JsonElement matchesElement))
            {
                List<LinkedEntityMatch> matches = new List<LinkedEntityMatch>();

                foreach (JsonElement matchElement in matchesElement.EnumerateArray())
                {
                    string text = default;
                    double confidenceScore = default;

                    if (matchElement.TryGetProperty("text", out JsonElement textValue))
                        text = textValue.ToString();

                    if (matchElement.TryGetProperty("confidenceScore", out JsonElement scoreValue))
                        scoreValue.TryGetDouble(out confidenceScore);

                    matches.Add(new LinkedEntityMatch(text, confidenceScore));
                }

                return matches;
            }

            return default;
        }

        #endregion  Entity Linking

    }
}
