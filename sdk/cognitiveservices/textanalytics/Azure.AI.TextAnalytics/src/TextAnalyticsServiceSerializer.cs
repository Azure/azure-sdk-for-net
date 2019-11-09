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
                DocumentStatistics statistics = new DocumentStatistics();

                if (statisticsValue.TryGetProperty("charactersCount", out JsonElement characterCountValue))
                    statistics.CharacterCount = characterCountValue.GetInt32();
                if (statisticsValue.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                    statistics.TransactionCount = transactionCountValue.GetInt32();

                return statistics;
            }

            return default;
        }

        private static void ReadDocumentErrors(JsonElement documentElement, List<DocumentError> errors)
        {
            if (documentElement.TryGetProperty("errors", out JsonElement errorsValue))
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

                    errors.Add(error);
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
                DocumentBatchStatistics statistics = new DocumentBatchStatistics();

                if (statisticsElement.TryGetProperty("documentsCount", out JsonElement documentCountValue))
                    statistics.DocumentCount = documentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("validDocumentsCount", out JsonElement validDocumentCountValue))
                    statistics.ValidDocumentCount = validDocumentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("erroneousDocumentsCount", out JsonElement erroneousDocumentCountValue))
                    statistics.ErroneousDocumentCount = erroneousDocumentCountValue.GetInt32();
                if (statisticsElement.TryGetProperty("transactionsCount", out JsonElement transactionCountValue))
                    statistics.DocumentCount = transactionCountValue.GetInt32();

                return statistics;
            }

            return default;
        }

        #endregion Deserialize Common

        #region Detect Languages

        public static async Task<DocumentResultCollection<DetectedLanguage>> DeserializeDetectLanguageResponseAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadDetectLanguageResultCollection(root);
            }
        }

        public static DocumentResultCollection<DetectedLanguage> DeserializeDetectLanguageResponse(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadDetectLanguageResultCollection(root);
            }
        }

        public static async Task<IEnumerable<DetectedLanguage>> DeserializeDetectedLanguageCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadDetectedLanguageCollection(root);
            }
        }

        public static IEnumerable<DetectedLanguage> DeserializeDetectedLanguageCollection(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                JsonElement root = json.RootElement;
                return ReadDetectedLanguageCollection(root);
            }
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
            var documentResult = new DocumentResult<DetectedLanguage>
            {
                Id = ReadDocumentId(documentElement),
                Statistics = ReadDocumentStatistics(documentElement)
            };

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
            var language = new DetectedLanguage();

            if (languageElement.TryGetProperty("name", out JsonElement name))
                language.Name = name.GetString();
            if (languageElement.TryGetProperty("iso6391Name", out JsonElement iso6391Name))
                language.Iso6391Name = iso6391Name.ToString();
            if (languageElement.TryGetProperty("score", out JsonElement scoreValue))
                if (scoreValue.TryGetDouble(out double score))
                    language.Score = score;

            return language;
        }

        #endregion Detect Languages

        #region Recognize Entities

        public static async Task<DocumentResultCollection<Entity>> DeserializeRecognizeEntitiesResponseAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadEntityResultCollection(root);
            }
        }

        public static DocumentResultCollection<Entity> DeserializeRecognizeEntitiesResponse(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadEntityResultCollection(root);
            }
        }

        public static async Task<IEnumerable<IEnumerable<Entity>>> DeserializeEntityCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadEntityCollection(root);
            }
        }

        public static IEnumerable<IEnumerable<Entity>> DeserializeEntityCollection(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                JsonElement root = json.RootElement;
                return ReadEntityCollection(root);
            }
        }

        private static DocumentResultCollection<Entity> ReadEntityResultCollection(JsonElement root)
        {
            var result = new DocumentResultCollection<Entity>();
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

        private static IEnumerable<IEnumerable<Entity>> ReadEntityCollection(JsonElement root)
        {
            var result = new List<List<Entity>>();
            if (root.TryGetProperty("documents", out JsonElement documentsValue))
            {
                foreach (JsonElement documentElement in documentsValue.EnumerateArray())
                {
                    result.Add(ReadEntityResult(documentElement).ToList());
                }
            }

            return result;
        }

        private static DocumentResult<Entity> ReadEntityResult(JsonElement documentElement)
        {
            var documentResult = new DocumentResult<Entity>
            {
                Id = ReadDocumentId(documentElement),
                Statistics = ReadDocumentStatistics(documentElement)
            };

            if (documentElement.TryGetProperty("entities", out JsonElement entitiesValue))
            {
                foreach (JsonElement entityElement in entitiesValue.EnumerateArray())
                {
                    documentResult.Add(ReadEntity(entityElement));
                }
            }

            return documentResult;
        }

        private static Entity ReadEntity(JsonElement entityElement)
        {
            var entity = new Entity();

            if (entityElement.TryGetProperty("text", out JsonElement text))
                entity.Text = text.GetString();
            if (entityElement.TryGetProperty("type", out JsonElement type))
                entity.Type = type.ToString();
            if (entityElement.TryGetProperty("subType", out JsonElement subType))
                entity.SubType = subType.ToString();
            if (entityElement.TryGetProperty("offset", out JsonElement offsetValue))
                if (offsetValue.TryGetInt32(out int offset))
                    entity.Offset = offset;
            if (entityElement.TryGetProperty("length", out JsonElement lengthValue))
                if (lengthValue.TryGetInt32(out int length))
                    entity.Length = length;
            if (entityElement.TryGetProperty("score", out JsonElement scoreValue))
                if (scoreValue.TryGetDouble(out double score))
                    entity.Score = score;

            return entity;
        }

        #endregion Recognize Entities

        #region Analyze Sentiment

        public static async Task<SentimentResultCollection> DeserializeAnalyzeSentimentResponseAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadSentimentResult(root);
            }
        }

        public static SentimentResultCollection DeserializeAnalyzeSentimentResponse(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadSentimentResult(root);
            }
        }

        public static async Task<IEnumerable<Sentiment>> DeserializeSentimentCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadSentimentCollection(root);
            }
        }

        public static IEnumerable<Sentiment> DeserializeSentimentCollection(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                JsonElement root = json.RootElement;
                return ReadSentimentCollection(root);
            }
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
            var documentResult = new SentimentResult
            {
                Id = ReadDocumentId(documentElement),
                Statistics = ReadDocumentStatistics(documentElement),

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
            var sentiment = new Sentiment();

            if (documentElement.TryGetProperty("sentiment", out JsonElement sentimentValue))
            {
                sentiment.SentimentClass = (SentimentClass)Enum.Parse(typeof(SentimentClass), sentimentValue.ToString(), ignoreCase: true);
            }

            if (documentElement.TryGetProperty(scoresElementName, out JsonElement scoreValues))
            {
                if (scoreValues.TryGetProperty("positive", out JsonElement positiveValue))
                    if (positiveValue.TryGetDouble(out double score))
                        sentiment.PositiveScore = score;

                if (scoreValues.TryGetProperty("neutral", out JsonElement neutralValue))
                    if (neutralValue.TryGetDouble(out double score))
                        sentiment.NeutralScore = score;

                if (scoreValues.TryGetProperty("negative", out JsonElement negativeValue))
                    if (negativeValue.TryGetDouble(out double score))
                        sentiment.NegativeScore = score;
            }

            if (documentElement.TryGetProperty("offset", out JsonElement offsetValue))
                if (offsetValue.TryGetInt32(out int offset))
                    sentiment.Offset = offset;

            if (documentElement.TryGetProperty("length", out JsonElement lengthValue))
                if (lengthValue.TryGetInt32(out int length))
                    sentiment.Length = length;

            return sentiment;
        }
        #endregion

        #region ExtractKeyPhrases

        public static async Task<DocumentResultCollection<string>> DeserializeKeyPhraseResponseAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadKeyPhraseResultCollection(root);
            }
        }

        public static DocumentResultCollection<string> DeserializeKeyPhraseResponse(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadKeyPhraseResultCollection(root);
            }
        }

        public static async Task<IEnumerable<IEnumerable<string>>> DeserializeKeyPhraseCollectionAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadKeyPhraseCollection(root);
            }
        }

        public static IEnumerable<IEnumerable<string>> DeserializeKeyPhraseCollection(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                JsonElement root = json.RootElement;
                return ReadKeyPhraseCollection(root);
            }
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
            var documentResult = new DocumentResult<string>
            {
                Id = ReadDocumentId(documentElement),
                Statistics = ReadDocumentStatistics(documentElement)
            };

            if (documentElement.TryGetProperty("keyPhrases", out JsonElement keyPhrasesValue))
            {
                foreach (JsonElement keyPhraseElement in keyPhrasesValue.EnumerateArray())
                {
                    documentResult.Add(keyPhraseElement.ToString());
                }
            }

            return documentResult;
        }

        #endregion Recognize Entities
    }
}
