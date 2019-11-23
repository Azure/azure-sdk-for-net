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

        #region Serialize Inputs

        public static ReadOnlyMemory<byte> SerializeDetectLanguageInputs(IEnumerable<string> inputs, string countryHint)
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

        public static ReadOnlyMemory<byte> SerializeDetectLanguageInputs(IEnumerable<DetectLanguageInput> inputs)
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

        public static ReadOnlyMemory<byte> SerializeDocumentInputs(IEnumerable<string> inputs, string language)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteStartArray("documents");
            int id = 1;
            foreach (var input in inputs)
            {
                json.WriteStartObject();
                json.WriteString("language", language);
                json.WriteNumber("id", id++);
                json.WriteString("text", input);
                json.WriteEndObject();
            }
            json.WriteEndArray();
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

        public static ReadOnlyMemory<byte> SerializeDocumentInputs(IEnumerable<DocumentInput> inputs)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteStartArray("documents");
            foreach (var input in inputs)
            {
                json.WriteStartObject();
                json.WriteString("language", input.Language);
                json.WriteString("id", input.Id);
                json.WriteString("text", input.Text);
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

        private static DocumentStatistics ReadDocumentStatistics(JsonElement documentElement)
        {
            if (documentElement.TryGetProperty("statistics", out JsonElement statisticsValue))
            {
                int characterCount = default;
                int transactionCount = default;

                if (statisticsValue.TryGetProperty("charactersCount", out JsonElement characterCountValue))
                    characterCount = characterCountValue.GetInt32();
                if (statisticsValue.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                    transactionCount = transactionCountValue.GetInt32();

                return new DocumentStatistics(characterCount, transactionCount);
            }

            return default;
        }

        private static void ReadDocumentErrors(JsonElement documentElement, List<DocumentError> errors)
        {
            if (documentElement.TryGetProperty("errors", out JsonElement errorsValue))
            {
                foreach (JsonElement errorElement in errorsValue.EnumerateArray())
                {
                    string id = default;
                    string message = default;

                    if (errorElement.TryGetProperty("id", out JsonElement idValue))
                        id = idValue.ToString();
                    if (errorElement.TryGetProperty("error", out JsonElement errorValue))
                    {
                        if (errorsValue.TryGetProperty("message", out JsonElement messageValue))
                        {
                            message = messageValue.ToString();
                        }
                    }

                    errors.Add(new DocumentError(id, message));
                }
            }
        }

        private static string ReadModelVersion(JsonElement documentElement)
        {
            if (documentElement.TryGetProperty("modelVersion", out JsonElement modelVersionValue))
            {
                return modelVersionValue.ToString();
            }

            return default;
        }

        private static DocumentBatchStatistics ReadDocumentBatchStatistics(JsonElement documentElement)
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

                return new DocumentBatchStatistics(documentCount, validDocumentCount, invalidDocumentCount, transactionCount);
            }

            return default;
        }

        #endregion Deserialize Common

        #region Detect Languages

        public static async Task<DocumentResultCollection<DetectedLanguage>> DeserializeDetectLanguageResponseAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadDetectLanguageResultCollection(root);
        }

        public static DocumentResultCollection<DetectedLanguage> DeserializeDetectLanguageResponse(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadDetectLanguageResultCollection(root);
        }

        public static async Task<IEnumerable<DetectedLanguage>> DeserializeDetectedLanguageCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadDetectedLanguageCollection(root);
        }

        public static IEnumerable<DetectedLanguage> DeserializeDetectedLanguageCollection(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content);
            JsonElement root = json.RootElement;
            return ReadDetectedLanguageCollection(root);
        }

        private static DocumentResultCollection<DetectedLanguage> ReadDetectLanguageResultCollection(JsonElement root)
        {
            var result = new DocumentResultCollection<DetectedLanguage>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadDetectedLanguageResult(documentElement));
                }
            }

            ReadDocumentErrors(root, result.Errors);
            result.ModelVersion = ReadModelVersion(root);
            result.Statistics = ReadDocumentBatchStatistics(root);

            return result;
        }

        private static IEnumerable<DetectedLanguage> ReadDetectedLanguageCollection(JsonElement root)
        {
            var result = new List<DetectedLanguage>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    DocumentResult<DetectedLanguage> results = ReadDetectedLanguageResult(documentElement);

                    // TODO: If needed, sort by score to get the value with the highest confidence.
                    DetectedLanguage language = results.FirstOrDefault();
                    result.Add(language);
                }
            }

            return result;
        }

        private static DocumentResult<DetectedLanguage> ReadDetectedLanguageResult(JsonElement documentElement)
        {
            var documentResult = new DocumentResult<DetectedLanguage>(
                ReadDocumentId(documentElement),
                ReadDocumentStatistics(documentElement));

            if (documentElement.TryGetProperty("detectedLanguages", out JsonElement detectedLanguagesValue))
            {
                foreach (JsonElement languageElement in detectedLanguagesValue.EnumerateArray())
                {
                    documentResult.Add(ReadDetectedLanguage(languageElement));
                }
            }


            return documentResult;
        }

        private static DetectedLanguage ReadDetectedLanguage(JsonElement languageElement)
        {
            string name = null;
            string iso6391Name = null;
            double score = default;

            if (languageElement.TryGetProperty("name", out JsonElement nameValue))
                name = nameValue.GetString();
            if (languageElement.TryGetProperty("iso6391Name", out JsonElement iso6391NameValue))
                iso6391Name = iso6391NameValue.ToString();
            if (languageElement.TryGetProperty("score", out JsonElement scoreValue))
                scoreValue.TryGetDouble(out score);

            return new DetectedLanguage(name, iso6391Name, score);
        }

        #endregion Detect Languages

        #region Recognize Entities

        public static async Task<DocumentResultCollection<NamedEntity>> DeserializeRecognizeEntitiesResponseAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadEntityResultCollection(root);
        }

        public static DocumentResultCollection<NamedEntity> DeserializeRecognizeEntitiesResponse(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadEntityResultCollection(root);
        }

        public static async Task<IEnumerable<IEnumerable<NamedEntity>>> DeserializeEntityCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadEntityCollection(root);
        }

        public static IEnumerable<IEnumerable<NamedEntity>> DeserializeEntityCollection(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content);
            JsonElement root = json.RootElement;
            return ReadEntityCollection(root);
        }

        private static DocumentResultCollection<NamedEntity> ReadEntityResultCollection(JsonElement root)
        {
            var result = new DocumentResultCollection<NamedEntity>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadEntityResult(documentElement));
                }
            }

            ReadDocumentErrors(root, result.Errors);
            result.ModelVersion = ReadModelVersion(root);
            result.Statistics = ReadDocumentBatchStatistics(root);

            return result;
        }

        private static IEnumerable<IEnumerable<NamedEntity>> ReadEntityCollection(JsonElement root)
        {
            var result = new List<List<NamedEntity>>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadEntityResult(documentElement).ToList());
                }
            }

            return result;
        }

        private static DocumentResult<NamedEntity> ReadEntityResult(JsonElement documentElement)
        {
            var documentResult = new DocumentResult<NamedEntity>(
                ReadDocumentId(documentElement),
                ReadDocumentStatistics(documentElement)
            );

            if (documentElement.TryGetProperty("entities", out JsonElement entitiesValue))
            {
                foreach (JsonElement entityElement in entitiesValue.EnumerateArray())
                {
                    documentResult.Add(ReadEntity(entityElement));
                }
            }

            return documentResult;
        }

        private static NamedEntity ReadEntity(JsonElement entityElement)
        {
            string text = default;
            string type = default;
            string subType = default;
            int offset = default;
            int length = default;
            double score = default;

            if (entityElement.TryGetProperty("text", out JsonElement textValue))
                text = textValue.GetString();
            if (entityElement.TryGetProperty("type", out JsonElement typeValue))
                type = typeValue.ToString();
            if (entityElement.TryGetProperty("subType", out JsonElement subTypeValue))
                subType = subTypeValue.ToString();
            if (entityElement.TryGetProperty("offset", out JsonElement offsetValue))
                offsetValue.TryGetInt32(out offset);
            if (entityElement.TryGetProperty("length", out JsonElement lengthValue))
                lengthValue.TryGetInt32(out length);
            if (entityElement.TryGetProperty("score", out JsonElement scoreValue))
                scoreValue.TryGetDouble(out score);

            return new NamedEntity(text, type, subType, offset, length, score);
        }

        #endregion Recognize Entities

        #region Analyze Sentiment

        public static async Task<SentimentResultCollection> DeserializeAnalyzeSentimentResponseAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadSentimentResult(root);
        }

        public static SentimentResultCollection DeserializeAnalyzeSentimentResponse(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadSentimentResult(root);
        }

        public static async Task<IEnumerable<Sentiment>> DeserializeSentimentCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadSentimentCollection(root);
        }

        public static IEnumerable<Sentiment> DeserializeSentimentCollection(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content);
            JsonElement root = json.RootElement;
            return ReadSentimentCollection(root);
        }

        private static SentimentResultCollection ReadSentimentResult(JsonElement root)
        {
            var result = new SentimentResultCollection();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadDocumentSentimentResult(documentElement));
                }
            }

            ReadDocumentErrors(root, result.Errors);
            result.ModelVersion = ReadModelVersion(root);
            result.Statistics = ReadDocumentBatchStatistics(root);

            return result;
        }

        private static IEnumerable<Sentiment> ReadSentimentCollection(JsonElement root)
        {
            var result = new List<Sentiment>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadDocumentSentimentResult(documentElement).DocumentSentiment);
                }
            }

            return result;
        }

        private static SentimentResult ReadDocumentSentimentResult(JsonElement documentElement)
        {
            var documentResult = new SentimentResult(
                ReadDocumentId(documentElement),
                ReadDocumentStatistics(documentElement))
            {
                DocumentSentiment = ReadSentiment(documentElement, "documentScores")
            };

            if (documentElement.TryGetProperty("sentences", out JsonElement sentencesElement))
            {
                foreach (JsonElement sentenceElement in sentencesElement.EnumerateArray())
                {
                    documentResult.Add(ReadSentiment(sentenceElement, "sentenceScores"));
                }
            }

            return documentResult;
        }

        private static Sentiment ReadSentiment(JsonElement documentElement, string scoresElementName)
        {
            SentimentClass sentimentClass = default;
            double positiveScore = default;
            double neutralScore = default;
            double negativeScore = default;
            int offset = default;
            int length = default;

            if (documentElement.TryGetProperty("sentiment", out JsonElement sentimentValue))
            {
                sentimentClass = (SentimentClass)Enum.Parse(typeof(SentimentClass), sentimentValue.ToString(), ignoreCase: true);
            }

            if (documentElement.TryGetProperty(scoresElementName, out JsonElement scoreValues))
            {
                if (scoreValues.TryGetProperty("positive", out JsonElement positiveValue))
                    positiveValue.TryGetDouble(out positiveScore);

                if (scoreValues.TryGetProperty("neutral", out JsonElement neutralValue))
                    neutralValue.TryGetDouble(out neutralScore);

                if (scoreValues.TryGetProperty("negative", out JsonElement negativeValue))
                    negativeValue.TryGetDouble(out negativeScore);
            }

            if (documentElement.TryGetProperty("offset", out JsonElement offsetValue))
                offsetValue.TryGetInt32(out offset);

            if (documentElement.TryGetProperty("length", out JsonElement lengthValue))
                lengthValue.TryGetInt32(out length);

            return new Sentiment(sentimentClass, positiveScore, neutralScore, negativeScore, offset, length);
        }
        #endregion

        #region Extract Key Phrases

        public static async Task<DocumentResultCollection<string>> DeserializeKeyPhraseResponseAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadKeyPhraseResultCollection(root);
        }

        public static DocumentResultCollection<string> DeserializeKeyPhraseResponse(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadKeyPhraseResultCollection(root);
        }

        public static async Task<IEnumerable<IEnumerable<string>>> DeserializeKeyPhraseCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadKeyPhraseCollection(root);
        }

        public static IEnumerable<IEnumerable<string>> DeserializeKeyPhraseCollection(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content);
            JsonElement root = json.RootElement;
            return ReadKeyPhraseCollection(root);
        }

        private static DocumentResultCollection<string> ReadKeyPhraseResultCollection(JsonElement root)
        {
            var result = new DocumentResultCollection<string>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadKeyPhraseResult(documentElement));
                }
            }

            ReadDocumentErrors(root, result.Errors);
            result.ModelVersion = ReadModelVersion(root);
            result.Statistics = ReadDocumentBatchStatistics(root);

            return result;
        }

        private static IEnumerable<IEnumerable<string>> ReadKeyPhraseCollection(JsonElement root)
        {
            var result = new List<List<string>>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadKeyPhraseResult(documentElement).ToList());
                }
            }

            return result;
        }

        private static DocumentResult<string> ReadKeyPhraseResult(JsonElement documentElement)
        {
            var documentResult = new DocumentResult<string>(
                ReadDocumentId(documentElement),
                ReadDocumentStatistics(documentElement));

            if (documentElement.TryGetProperty("keyPhrases", out JsonElement keyPhrasesValue))
            {
                foreach (JsonElement keyPhraseElement in keyPhrasesValue.EnumerateArray())
                {
                    documentResult.Add(keyPhraseElement.ToString());
                }
            }

            return documentResult;
        }

        #endregion Extract Key Phrases

        #region Entity Linking

        public static async Task<DocumentResultCollection<LinkedEntity>> DeserializeLinkedEntityResponseAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadLinkedEntityResultCollection(root);
        }

        public static DocumentResultCollection<LinkedEntity> DeserializeLinkedEntityResponse(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadLinkedEntityResultCollection(root);
        }

        public static async Task<IEnumerable<IEnumerable<LinkedEntity>>> DeserializeLinkedEntityCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadLinkedEntityCollection(root);
        }

        public static IEnumerable<IEnumerable<LinkedEntity>> DeserializeLinkedEntityCollection(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content);
            JsonElement root = json.RootElement;
            return ReadLinkedEntityCollection(root);
        }

        private static DocumentResultCollection<LinkedEntity> ReadLinkedEntityResultCollection(JsonElement root)
        {
            var result = new DocumentResultCollection<LinkedEntity>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadLinkedEntityResult(documentElement));
                }
            }

            ReadDocumentErrors(root, result.Errors);
            result.ModelVersion = ReadModelVersion(root);
            result.Statistics = ReadDocumentBatchStatistics(root);

            return result;
        }

        private static IEnumerable<IEnumerable<LinkedEntity>> ReadLinkedEntityCollection(JsonElement root)
        {
            var result = new List<List<LinkedEntity>>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadLinkedEntityResult(documentElement).ToList());
                }
            }

            return result;
        }

        private static DocumentResult<LinkedEntity> ReadLinkedEntityResult(JsonElement documentElement)
        {
            var documentResult = new DocumentResult<LinkedEntity>(
                ReadDocumentId(documentElement),
                ReadDocumentStatistics(documentElement));

            if (documentElement.TryGetProperty("entities", out JsonElement entitiesValue))
            {
                foreach (JsonElement entityElement in entitiesValue.EnumerateArray())
                {
                    documentResult.Add(ReadLinkedEntity(entityElement));
                }
            }

            return documentResult;
        }

        private static LinkedEntity ReadLinkedEntity(JsonElement entityElement)
        {
            string name = default;
            string id = default;
            string language = default;
            string dataSource = default;
            Uri uri = default;

            if (entityElement.TryGetProperty("name", out JsonElement nameElement))
                name = nameElement.ToString();
            if (entityElement.TryGetProperty("id", out JsonElement idElement))
                id = idElement.ToString();
            if (entityElement.TryGetProperty("language", out JsonElement languageElement))
                language = languageElement.ToString();
            if (entityElement.TryGetProperty("dataSource", out JsonElement dataSourceValue))
                dataSource = dataSourceValue.ToString();
            if (entityElement.TryGetProperty("url", out JsonElement urlValue))
                uri = new Uri(urlValue.ToString());

            IEnumerable<LinkedEntityMatch> matches = ReadLinkedEntityMatches(entityElement);

            return new LinkedEntity(name, id, language, dataSource, uri, matches);
        }

        private static IEnumerable<LinkedEntityMatch> ReadLinkedEntityMatches(JsonElement entityElement)
        {
            if (entityElement.TryGetProperty("matches", out JsonElement matchesElement))
            {
                List<LinkedEntityMatch> matches = new List<LinkedEntityMatch>();

                foreach (JsonElement matchElement in matchesElement.EnumerateArray())
                {
                    string text = default;
                    double score = default;
                    int offset = default;
                    int length = default;

                    if (matchElement.TryGetProperty("text", out JsonElement textValue))
                        text = textValue.ToString();

                    if (matchElement.TryGetProperty("score", out JsonElement scoreValue))
                        scoreValue.TryGetDouble(out score);

                    if (matchElement.TryGetProperty("offset", out JsonElement offsetValue))
                        offsetValue.TryGetInt32(out offset);

                    if (matchElement.TryGetProperty("length", out JsonElement lengthValue))
                        lengthValue.TryGetInt32(out length);

                    matches.Add(new LinkedEntityMatch(text, score, offset, length));
                }

                return matches;
            }

            return default;
        }

        #endregion  Entity Linking
    }
}
