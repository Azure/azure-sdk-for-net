// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    internal static partial class Transforms
    {
        #region Common

        public static readonly Regex _targetRegex = new Regex("#/tasks/(keyPhraseExtractionTasks|entityRecognitionPiiTasks|entityRecognitionTasks|entityLinkingTasks|sentimentAnalysisTasks|customSingleClassificationTasks|customMultiClassificationTasks|customEntityRecognitionTasks)/(\\d+)", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        internal static TextAnalyticsError ConvertToError(Error error)
        {
            var innerError = error.Innererror;

            return (innerError != null)
                ? new TextAnalyticsError(innerError.Code.ToString(), innerError.Message, innerError.Target)
                : new TextAnalyticsError(error.Code.ToString(), error.Message, error.Target);
        }

        internal static List<TextAnalyticsError> ConvertToErrors(IReadOnlyList<Error> internalErrors)
        {
            List<TextAnalyticsError> textAnalyticsErrors = new List<TextAnalyticsError>(internalErrors.Count);
            foreach (var error in internalErrors)
            {
                textAnalyticsErrors.Add(Transforms.ConvertToError(error));
            }

            return textAnalyticsErrors;
        }

        internal static List<TextAnalyticsWarning> ConvertToWarnings(IReadOnlyList<TextAnalyticsWarningInternal> internalWarnings)
        {
            var warnings = new List<TextAnalyticsWarning>();

            if (internalWarnings == null)
            {
                return warnings;
            }

            foreach (TextAnalyticsWarningInternal warning in internalWarnings)
            {
                warnings.Add(new TextAnalyticsWarning(warning));
            }
            return warnings;
        }

        internal static List<TextAnalyticsWarning> ConvertToWarnings(IList<DocumentWarning> documentWarnings)
        {
            var warnings = new List<TextAnalyticsWarning>();

            if (documentWarnings == null)
            {
                return warnings;
            }

            foreach (var warning in documentWarnings)
            {
                warnings.Add(new TextAnalyticsWarning(warning));
            }

            return warnings;
        }

        #endregion

        #region DetectLanguage

        internal static DetectedLanguage ConvertToDetectedLanguage(LanguageDetectionDocumentResult documentLanguage)
        {
            List<TextAnalyticsWarning> warnings = ConvertToWarnings(documentLanguage.Warnings);
            return new DetectedLanguage(documentLanguage.DetectedLanguage, warnings);
        }

        internal static DetectedLanguage? ConvertToDetectedLanguage(DetectedLanguageInternal? detectedLanguageInternal)
        {
            return (detectedLanguageInternal is not null)
                ? new DetectedLanguage(
                    detectedLanguageInternal.Value.Name,
                    detectedLanguageInternal.Value.Iso6391Name,
                    detectedLanguageInternal.Value.ConfidenceScore,
                    detectedLanguageInternal.Value.Script,
                    default)
                : null;
        }

        internal static DetectLanguageResultCollection ConvertToDetectLanguageResultCollection(LanguageDetectionResult results, IDictionary<string, int> idToIndexMap)
        {
            var detectedLanguages = new List<DetectLanguageResult>(results.Documents.Count);

            //Read errors
            foreach (InputError error in results.Errors)
            {
                detectedLanguages.Add(new DetectLanguageResult(error.Id, ConvertToError(error.Error)));
            }

            //Read languages
            foreach (var language in results.Documents)
            {
                detectedLanguages.Add(new DetectLanguageResult(language.Id, language.Statistics ?? default, ConvertToDetectedLanguage(language)));
            }

            detectedLanguages = SortHeterogeneousCollection(detectedLanguages, idToIndexMap);

            return new DetectLanguageResultCollection(detectedLanguages, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region AnalyzeSentiment

        internal static AnalyzeSentimentResultCollection ConvertToAnalyzeSentimentResultCollection(SentimentResponse results, IDictionary<string, int> idToIndexMap)
        {
            var analyzedSentiments = new List<AnalyzeSentimentResult>(results.Documents.Count);

            //Read errors
            foreach (InputError error in results.Errors)
            {
                analyzedSentiments.Add(new AnalyzeSentimentResult(error.Id, ConvertToError(error.Error)));
            }

            //Read sentiments
            foreach (var document in results.Documents)
            {
                analyzedSentiments.Add(
                    new AnalyzeSentimentResult(
                        document.Id,
                        document.Statistics ?? default,
                        new DocumentSentiment(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage)));
            }

            analyzedSentiments = SortHeterogeneousCollection(analyzedSentiments, idToIndexMap);
            return new AnalyzeSentimentResultCollection(analyzedSentiments, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region KeyPhrases

        internal static KeyPhraseCollection ConvertToKeyPhraseCollection(KeyPhraseResultDocumentsItem documentKeyPhrases)
        {
            return new KeyPhraseCollection(documentKeyPhrases.KeyPhrases.ToList(), ConvertToWarnings(documentKeyPhrases.Warnings));
        }

        internal static ExtractKeyPhrasesResultCollection ConvertToExtractKeyPhrasesResultCollection(KeyPhraseResult results, IDictionary<string, int> idToIndexMap)
        {
            var keyPhrases = new List<ExtractKeyPhrasesResult>(results.Documents.Count);

            //Read errors
            foreach (InputError error in results.Errors)
            {
                keyPhrases.Add(new ExtractKeyPhrasesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read Key phrases
            foreach (KeyPhraseResultDocumentsItem document in results.Documents)
            {
                keyPhrases.Add(
                    new ExtractKeyPhrasesResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToKeyPhraseCollection(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage)));
            }

            keyPhrases = SortHeterogeneousCollection(keyPhrases, idToIndexMap);
            return new ExtractKeyPhrasesResultCollection(keyPhrases, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Recognize Entities

        internal static List<CategorizedEntity> ConvertToCategorizedEntityList(List<EntityWithResolution> entities)
            => entities.Select((entity) => new CategorizedEntity(entity)).ToList();

        internal static CategorizedEntityCollection ConvertToCategorizedEntityCollection(EntitiesResultWithDetectedLanguage documentEntities)
        {
            return new CategorizedEntityCollection(ConvertToCategorizedEntityList(documentEntities.Entities.ToList()), ConvertToWarnings(documentEntities.Warnings));
        }

        internal static RecognizeEntitiesResultCollection ConvertToRecognizeEntitiesResultCollection(EntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizeEntitiesResult>(results.Documents.Count);

            //Read errors
            foreach (InputError error in results.Errors)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (var document in results.Documents)
            {
                recognizeEntities.Add(
                    new RecognizeEntitiesResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToCategorizedEntityCollection(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage)));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizeEntitiesResultCollection(recognizeEntities, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Recognize Custom Entities

        internal static CategorizedEntityCollection ConvertToCategorizedEntityCollection(CustomEntitiesResultDocumentsItem documentEntities)
        {
            return new CategorizedEntityCollection(ConvertToCategorizedEntityList(documentEntities.Entities.ToList()), ConvertToWarnings(documentEntities.Warnings));
        }

        internal static RecognizeCustomEntitiesResultCollection ConvertToRecognizeCustomEntitiesResultCollection(CustomEntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizeEntitiesResult>(results.Errors.Count);

            // Read errors.
            foreach (DocumentError error in results.Errors)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            // Read document entities.
            foreach (var document in results.Documents)
            {
                recognizeEntities.Add(
                    new RecognizeEntitiesResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToCategorizedEntityCollection(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage)));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizeCustomEntitiesResultCollection(recognizeEntities, results.Statistics, results.ProjectName, results.DeploymentName);
        }

        internal static RecognizeCustomEntitiesResultCollection ConvertToRecognizeCustomEntitiesResultCollection(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            AnalyzeTextLROResult task = jobState.Tasks.Items[0];
            if (task.Kind == AnalyzeTextLROResultsKind.CustomEntityRecognitionLROResults)
            {
                return ConvertToRecognizeCustomEntitiesResultCollection((task as CustomEntityRecognitionLROResult).Results, map);
            }

            throw new InvalidOperationException($"Invalid task executed. Expected a {nameof(AnalyzeTextLROResultsKind.CustomEntityRecognitionLROResults)} but instead got {task.Kind}.");
        }

        #endregion

        #region Recognize PII Entities

        internal static List<PiiEntity> ConvertToPiiEntityList(List<Entity> entities)
        {
            var entityList = new List<PiiEntity>(entities.Count);

            foreach (var entity in entities)
            {
                entityList.Add(new PiiEntity(entity));
            }

            return entityList;
        }

        internal static PiiEntityCollection ConvertToPiiEntityCollection(PIIResultWithDetectedLanguage piiResult)
        {
            var entities = new List<PiiEntity>(piiResult.Entities.Count);
            foreach (var entity in piiResult.Entities)
            {
                var piiEntity = new PiiEntity(entity);
                entities.Add(piiEntity);
            }

            return new PiiEntityCollection(entities, piiResult.RedactedText, ConvertToWarnings(piiResult.Warnings));
        }

        internal static RecognizePiiEntitiesResultCollection ConvertToRecognizePiiEntitiesResultCollection(PiiEntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizePiiEntitiesResult>(results.Documents.Count);

            // Read errors.
            foreach (InputError error in results.Errors)
            {
                recognizeEntities.Add(new RecognizePiiEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            // Read document entities.
            foreach (var document in results.Documents)
            {
                recognizeEntities.Add(
                    new RecognizePiiEntitiesResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToPiiEntityCollection(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage)));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizePiiEntitiesResultCollection(recognizeEntities, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Recognize Linked Entities

        internal static LinkedEntityCollection ConvertToLinkedEntityCollection(EntityLinkingResultWithDetectedLanguage documentEntities)
        {
            return new LinkedEntityCollection(documentEntities.Entities.ToList(), ConvertToWarnings(documentEntities.Warnings));
        }

        internal static RecognizeLinkedEntitiesResultCollection ConvertToLinkedEntitiesResultCollection(EntityLinkingResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeLinkedEntities = new List<RecognizeLinkedEntitiesResult>(results.Documents.Count);

            // Read errors.
            foreach (InputError error in results.Errors)
            {
                recognizeLinkedEntities.Add(new RecognizeLinkedEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            // Read document entities.
            foreach (EntityLinkingResultWithDetectedLanguage document in results.Documents)
            {
                recognizeLinkedEntities.Add(
                    new RecognizeLinkedEntitiesResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToLinkedEntityCollection(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage)));
            }

            recognizeLinkedEntities = SortHeterogeneousCollection(recognizeLinkedEntities, idToIndexMap);
            return new RecognizeLinkedEntitiesResultCollection(recognizeLinkedEntities, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Healthcare

        internal static BinaryData ConvertToFhirBundle(JsonElement fhirBundle) =>
            fhirBundle.ValueKind switch
            {
                JsonValueKind.Undefined => null, // A FHIR bundle was not included in the response.
                JsonValueKind.Object => new BinaryData(fhirBundle),
                _ => throw new InvalidOperationException($"This value's ValueKind is not Object.")
            };

        internal static List<HealthcareEntity> ConvertToHealthcareEntityCollection(IEnumerable<HealthcareEntityInternal> healthcareEntities)
        {
            return healthcareEntities.Select((entity) => new HealthcareEntity(entity)).ToList();
        }

        internal static AnalyzeHealthcareEntitiesResultCollection ConvertToAnalyzeHealthcareEntitiesResultCollection(HealthcareResult results, IDictionary<string, int> idToIndexMap)
        {
            var healthcareEntitiesResults = new List<AnalyzeHealthcareEntitiesResult>(results.Documents.Count);

            // Read errors.
            foreach (InputError error in results.Errors)
            {
                healthcareEntitiesResults.Add(new AnalyzeHealthcareEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            // Read entities.
            foreach (var document in results.Documents)
            {
                healthcareEntitiesResults.Add(new AnalyzeHealthcareEntitiesResult(
                    document.Id,
                    document.Statistics ?? default,
                    ConvertToHealthcareEntityCollection(document.Entities),
                    ConvertToHealthcareEntityRelationsCollection(document.Entities, document.Relations),
                    ConvertToFhirBundle(document.FhirBundle),
                    document.DetectedLanguage,
                    ConvertToWarnings(document.Warnings)));
            }

            healthcareEntitiesResults = healthcareEntitiesResults.OrderBy(result => idToIndexMap[result.Id]).ToList();

            return new AnalyzeHealthcareEntitiesResultCollection(healthcareEntitiesResults, results.Statistics, results.ModelVersion);
        }

        private static IList<HealthcareEntityRelation> ConvertToHealthcareEntityRelationsCollection(IList<HealthcareEntityInternal> healthcareEntities, IList<HealthcareRelationInternal> healthcareRelations)
        {
            List<HealthcareEntityRelation> result = new List<HealthcareEntityRelation>();
            foreach (HealthcareRelationInternal relation in healthcareRelations)
            {
                result.Add(new HealthcareEntityRelation(
                    relation.RelationType,
                    ConvertToHealthcareEntityRelationRoleCollection(relation.Entities, healthcareEntities),
                    relation.ConfidenceScore));
            }
            return result;
        }

        private static IReadOnlyCollection<HealthcareEntityRelationRole> ConvertToHealthcareEntityRelationRoleCollection(IList<HealthcareRelationEntity> entities, IList<HealthcareEntityInternal> healthcareEntities)
        {
            List<HealthcareEntityRelationRole> result = new List<HealthcareEntityRelationRole>();

            foreach (HealthcareRelationEntity entity in entities)
            {
                int refIndex = ParseHealthcareEntityIndex(entity.Ref);
                HealthcareEntityInternal refEntity = healthcareEntities[refIndex];

                result.Add(new HealthcareEntityRelationRole(refEntity, entity.Role));
            }

            return result;
        }

        private static int ParseHealthcareEntityIndex(string reference)
        {
            Match healthcareEntityMatch = _healthcareEntityRegex.Match(reference);
            if (healthcareEntityMatch.Success)
            {
                return int.Parse(healthcareEntityMatch.Groups["entityIndex"].Value, CultureInfo.InvariantCulture);
            }

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }

        private static Regex _healthcareEntityRegex = new Regex(@"\#/results/documents\/(?<documentIndex>\d*)\/entities\/(?<entityIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        private static AnalyzeHealthcareEntitiesResultCollection ExtractHealthcareActionResult(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            var healthcareTask = jobState.Tasks.Items[0];
            if (healthcareTask.Kind == AnalyzeTextLROResultsKind.HealthcareLROResults)
            {
                return ConvertToAnalyzeHealthcareEntitiesResultCollection((healthcareTask as HealthcareLROResult).Results, map);
            }
            throw new InvalidOperationException($"Invalid task executed. Expected a {nameof(AnalyzeTextLROResultsKind.HealthcareLROResults)} but instead got {healthcareTask.Kind}.");
        }

        #endregion

        #region Label Classify

        internal static List<ClassificationCategory> ConvertToClassificationCategoryList(List<ClassificationResult> results)
            => results.Select((result) => new ClassificationCategory(result)).ToList();

        internal static ClassificationCategoryCollection ConvertToClassificationCategoryCollection(CustomLabelClassificationResultDocumentsItem extractedClassificationsDocuments)
        {
            return new ClassificationCategoryCollection(ConvertToClassificationCategoryList(extractedClassificationsDocuments.Class.ToList()), ConvertToWarnings(extractedClassificationsDocuments.Warnings));
        }

        internal static ClassifyDocumentResultCollection ConvertToClassifyDocumentResultCollection(CustomLabelClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            var classifiedCustomCategoryResults = new List<ClassifyDocumentResult>(results.Errors.Count);

            // Read errors.
            foreach (DocumentError error in results.Errors)
            {
                classifiedCustomCategoryResults.Add(new ClassifyDocumentResult(error.Id, ConvertToError(error.Error)));
            }

            // Read classifications.
            foreach (var document in results.Documents)
            {
                classifiedCustomCategoryResults.Add(
                    new ClassifyDocumentResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToClassificationCategoryCollection(document),
                        ConvertToDetectedLanguage(document.DetectedLanguage),
                        ConvertToWarnings(document.Warnings)));
            }

            classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);
            return new ClassifyDocumentResultCollection(classifiedCustomCategoryResults, results.Statistics, results.ProjectName, results.DeploymentName);
        }

        internal static ClassifyDocumentResultCollection ConvertClassifyDocumentResultCollection(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            AnalyzeTextLROResult task = jobState.Tasks.Items[0];
            if (task.Kind == AnalyzeTextLROResultsKind.CustomSingleLabelClassificationLROResults)
            {
                return ConvertToClassifyDocumentResultCollection((task as CustomSingleLabelClassificationLROResult).Results, map);
            }

            if (task.Kind == AnalyzeTextLROResultsKind.CustomMultiLabelClassificationLROResults)
            {
                return ConvertToClassifyDocumentResultCollection((task as CustomMultiLabelClassificationLROResult).Results, map);
            }

            throw new InvalidOperationException($"Invalid task executed. Expected a {nameof(AnalyzeTextLROResultsKind.CustomSingleLabelClassificationLROResults)} or {nameof(AnalyzeTextLROResultsKind.CustomMultiLabelClassificationLROResults)} but instead got {task.Kind}.");
        }

        #endregion

        #region Dynamic Classify

        internal static ClassificationCategoryCollection ConvertToClassificationCategoryCollection(DynamicClassificationResultDocumentsItem document)
        {
            return new ClassificationCategoryCollection(ConvertToClassificationCategoryList(document.Classifications.ToList()), ConvertToWarnings(document.Warnings));
        }

        internal static DynamicClassifyDocumentResultCollection ConvertToDynamicClassifyDocumentResultCollection(DynamicClassificationResult result, IDictionary<string, int> idToIndexMap)
        {
            var documentResults = new List<ClassifyDocumentResult>(result.Documents.Count);

            // Read errors.
            foreach (InputError error in result.Errors)
            {
                documentResults.Add(new ClassifyDocumentResult(error.Id, ConvertToError(error.Error)));
            }

            // Read results.
            foreach (DynamicClassificationResultDocumentsItem document in result.Documents)
            {
                documentResults.Add(
                    new ClassifyDocumentResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToClassificationCategoryCollection(document),
                        detectedLanguage: default,
                        ConvertToWarnings(document.Warnings)));
            }

            documentResults = SortHeterogeneousCollection(documentResults, idToIndexMap);
            return new DynamicClassifyDocumentResultCollection(documentResults, result.Statistics, result.ModelVersion);
        }

        #endregion

        #region Extractive Summarize

        internal static List<ExtractiveSummarySentence> ConvertToExtractiveSummarySentenceList(IEnumerable<ExtractedSummarySentence> sentences)
            => sentences.Select((sentence) => new ExtractiveSummarySentence(sentence)).ToList();

        internal static ExtractiveSummarizeResultCollection ConvertToExtractiveSummarizeResultCollection(
            ExtractiveSummarizationResult results,
            IDictionary<string, int> idToIndexMap)
        {
            List<ExtractiveSummarizeResult> extractiveSummarizeResults = new(results.Documents.Count);

            // Read errors.
            foreach (InputError error in results.Errors)
            {
                extractiveSummarizeResults.Add(new ExtractiveSummarizeResult(error.Id, ConvertToError(error.Error)));
            }

            // Read results.
            foreach (ExtractedSummaryDocumentResultWithDetectedLanguage document in results.Documents)
            {
                extractiveSummarizeResults.Add(
                    new ExtractiveSummarizeResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToExtractiveSummarySentenceList(document.Sentences),
                        ConvertToDetectedLanguage(document.DetectedLanguage),
                        ConvertToWarnings(document.Warnings)));
            }

            extractiveSummarizeResults = SortHeterogeneousCollection(extractiveSummarizeResults, idToIndexMap);

            return new ExtractiveSummarizeResultCollection(extractiveSummarizeResults, results.Statistics, results.ModelVersion);
        }

        internal static ExtractiveSummarizeResultCollection ConvertToExtractiveSummarizeResultCollection(
            AnalyzeTextJobState jobState,
            IDictionary<string, int> idToIndexMap)
        {
            AnalyzeTextLROResult task = jobState.Tasks.Items[0];
            if (task.Kind == AnalyzeTextLROResultsKind.ExtractiveSummarizationLROResults)
            {
                return ConvertToExtractiveSummarizeResultCollection((task as ExtractiveSummarizationLROResult).Results, idToIndexMap);
            }
            throw new InvalidOperationException($"Invalid task executed. Expected a {nameof(AnalyzeTextLROResultsKind.ExtractiveSummarizationLROResults)} but instead got {task.Kind}.");
        }

        #endregion

        #region Abstractive Summarize

        internal static List<AbstractiveSummary> ConvertToSummaryList(IEnumerable<AbstractiveSummaryInternal> summaries)
            => summaries.Select((summary) => new AbstractiveSummary(summary)).ToList();

        internal static AbstractiveSummarizeResultCollection ConvertToAbstractiveSummarizeResultCollection(
            AbstractiveSummarizationResult results,
            IDictionary<string, int> idToIndexMap)
        {
            List<AbstractiveSummarizeResult> abstractiveSummarizeResults = new(results.Documents.Count);

            // Read errors.
            foreach (InputError error in results.Errors)
            {
                abstractiveSummarizeResults.Add(new AbstractiveSummarizeResult(error.Id, ConvertToError(error.Error)));
            }

            // Read results.
            foreach (AbstractiveSummaryDocumentResultWithDetectedLanguage document in results.Documents)
            {
                abstractiveSummarizeResults.Add(
                    new AbstractiveSummarizeResult(
                        document.Id,
                        document.Statistics ?? default,
                        ConvertToSummaryList(document.Summaries),
                        ConvertToDetectedLanguage(document.DetectedLanguage),
                        ConvertToWarnings(document.Warnings)));
            }

            abstractiveSummarizeResults = SortHeterogeneousCollection(abstractiveSummarizeResults, idToIndexMap);

            return new AbstractiveSummarizeResultCollection(abstractiveSummarizeResults, results.Statistics, results.ModelVersion);
        }

        internal static AbstractiveSummarizeResultCollection ConvertToAbstractiveSummarizeResultCollection(
            AnalyzeTextJobState jobState,
            IDictionary<string, int> idToIndexMap)
        {
            AnalyzeTextLROResult task = jobState.Tasks.Items[0];
            if (task.Kind == AnalyzeTextLROResultsKind.AbstractiveSummarizationLROResults)
            {
                return ConvertToAbstractiveSummarizeResultCollection((task as AbstractiveSummarizationLROResult).Results, idToIndexMap);
            }
            throw new InvalidOperationException($"Invalid task executed. Expected a {nameof(AnalyzeTextLROResultsKind.AbstractiveSummarizationLROResults)} but instead got {task.Kind}.");
        }

        #endregion

        #region Analyze Operation

        internal static PiiLROTask ConvertToPiiTask(RecognizePiiEntitiesAction action)
        {
            var parameters = new PiiTaskParameters()
            {
                Domain = action.DomainFilter.GetString() ?? (PiiDomain?)null,
                ModelVersion = action.ModelVersion,
                StringIndexType = Constants.DefaultStringIndexType,
                LoggingOptOut = action.DisableServiceLogs
            };

            if (action.CategoriesFilter.Count > 0)
            {
                parameters.PiiCategories = action.CategoriesFilter;
            }

            return new PiiLROTask()
            {
                Parameters = parameters,
                TaskName = action.ActionName
            };
        }

        internal static EntityLinkingLROTask ConvertToLinkedEntitiesTask(RecognizeLinkedEntitiesAction action)
        {
            return new EntityLinkingLROTask()
            {
                Parameters = new EntityLinkingTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs
                },
                TaskName = action.ActionName
            };
        }

        internal static EntitiesLROTask ConvertToEntitiesTask(RecognizeEntitiesAction action)
        {
            return new EntitiesLROTask()
            {
                Parameters = new EntitiesTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs
                },
                TaskName = action.ActionName
            };
        }

        internal static KeyPhraseLROTask ConvertToKeyPhrasesTask(ExtractKeyPhrasesAction action)
        {
            return new KeyPhraseLROTask()
            {
                Parameters = new KeyPhraseTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    LoggingOptOut = action.DisableServiceLogs
                },
                TaskName = action.ActionName
            };
        }

        internal static SentimentAnalysisLROTask ConvertToSentimentAnalysisTask(AnalyzeSentimentAction action)
        {
            return new SentimentAnalysisLROTask()
            {
                Parameters = new SentimentAnalysisTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs,
                    OpinionMining = action.IncludeOpinionMining
                },
                TaskName = action.ActionName
            };
        }

        internal static HealthcareLROTask ConvertToHealthcareTask(AnalyzeHealthcareEntitiesAction action)
        {
            return new HealthcareLROTask()
            {
                Parameters = new HealthcareTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs,
                    FhirVersion = action.FhirVersion,
                    DocumentType = action.DocumentType,
                },
                TaskName = action.ActionName,
            };
        }

        internal static CustomEntitiesLROTask ConvertToCustomEntitiesLROTask(RecognizeCustomEntitiesAction action)
        {
            return new CustomEntitiesLROTask()
            {
                Parameters = new CustomEntitiesTaskParameters(action.ProjectName, action.DeploymentName)
                {
                    LoggingOptOut = action.DisableServiceLogs,
                },
                TaskName = action.ActionName
            };
        }

        internal static CustomSingleLabelClassificationLROTask ConvertToCustomSingleClassificationTask(SingleLabelClassifyAction action)
        {
            return new CustomSingleLabelClassificationLROTask()
            {
                Parameters = new CustomSingleLabelClassificationTaskParameters(action.ProjectName, action.DeploymentName)
                {
                    LoggingOptOut = action.DisableServiceLogs,
                },
                TaskName = action.ActionName
            };
        }

        internal static CustomMultiLabelClassificationLROTask ConvertToCustomMultiClassificationTask(MultiLabelClassifyAction action)
        {
            return new CustomMultiLabelClassificationLROTask()
            {
                Parameters = new CustomMultiLabelClassificationTaskParameters(action.ProjectName, action.DeploymentName)
                {
                    LoggingOptOut = action.DisableServiceLogs,
                },
                TaskName = action.ActionName
            };
        }

        internal static ExtractiveSummarizationLROTask ConvertToExtractiveSummarizationTask(ExtractiveSummarizeAction action)
        {
            return new ExtractiveSummarizationLROTask()
            {
                Parameters = new ExtractiveSummarizationTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs,
                    SentenceCount = action.MaxSentenceCount,
                    SortBy = action.OrderBy
                },
                TaskName = action.ActionName
            };
        }

        internal static AbstractiveSummarizationLROTask ConvertToAbstractiveSummarizationTask(AbstractiveSummarizeAction action)
        {
            AbstractiveSummarizationTaskParameters parameters = new()
            {
                ModelVersion = action.ModelVersion,
                StringIndexType = Constants.DefaultStringIndexType,
                LoggingOptOut = action.DisableServiceLogs,
                SentenceCount = action.MaxSentenceCount,
            };

            return new AbstractiveSummarizationLROTask(parameters)
            {
                TaskName = action.ActionName
            };
        }

        internal static IList<EntityLinkingLROTask> ConvertFromRecognizeLinkedEntitiesActionsToTasks(IReadOnlyCollection<RecognizeLinkedEntitiesAction> recognizeLinkedEntitiesActions)
        {
            List<EntityLinkingLROTask> list = new(recognizeLinkedEntitiesActions.Count);

            foreach (RecognizeLinkedEntitiesAction action in recognizeLinkedEntitiesActions)
            {
                list.Add(ConvertToLinkedEntitiesTask(action));
            }

            return list;
        }

        internal static IList<EntitiesLROTask> ConvertFromRecognizeEntitiesActionsToTasks(IReadOnlyCollection<RecognizeEntitiesAction> recognizeEntitiesActions)
        {
            List<EntitiesLROTask> list = new(recognizeEntitiesActions.Count);

            foreach (RecognizeEntitiesAction action in recognizeEntitiesActions)
            {
                list.Add(ConvertToEntitiesTask(action));
            }

            return list;
        }

        internal static IList<KeyPhraseLROTask> ConvertFromExtractKeyPhrasesActionsToTasks(IReadOnlyCollection<ExtractKeyPhrasesAction> extractKeyPhrasesActions)
        {
            List<KeyPhraseLROTask> list = new(extractKeyPhrasesActions.Count);

            foreach (ExtractKeyPhrasesAction action in extractKeyPhrasesActions)
            {
                list.Add(ConvertToKeyPhrasesTask(action));
            }

            return list;
        }

        internal static IList<PiiLROTask> ConvertFromRecognizePiiEntitiesActionsToTasks(IReadOnlyCollection<RecognizePiiEntitiesAction> recognizePiiEntitiesActions)
        {
            List<PiiLROTask> list = new(recognizePiiEntitiesActions.Count);

            foreach (RecognizePiiEntitiesAction action in recognizePiiEntitiesActions)
            {
                list.Add(ConvertToPiiTask(action));
            }

            return list;
        }

        internal static IList<SentimentAnalysisLROTask> ConvertFromAnalyzeSentimentActionsToTasks(IReadOnlyCollection<AnalyzeSentimentAction> analyzeSentimentActions)
        {
            List<SentimentAnalysisLROTask> list = new(analyzeSentimentActions.Count);

            foreach (AnalyzeSentimentAction action in analyzeSentimentActions)
            {
                list.Add(ConvertToSentimentAnalysisTask(action));
            }

            return list;
        }

        internal static IList<HealthcareLROTask> ConvertFromAnalyzeHealthcareEntitiesActionsToTasks(IReadOnlyCollection<AnalyzeHealthcareEntitiesAction> analyzeHealthcareEntitiesActions)
        {
            List<HealthcareLROTask> list = new(analyzeHealthcareEntitiesActions.Count);

            foreach (AnalyzeHealthcareEntitiesAction action in analyzeHealthcareEntitiesActions)
            {
                list.Add(ConvertToHealthcareTask(action));
            }

            return list;
        }

        internal static IList<CustomSingleLabelClassificationLROTask> ConvertFromSingleLabelClassifyActionsToTasks(IReadOnlyCollection<SingleLabelClassifyAction> singleLabelClassifyActions)
        {
            List<CustomSingleLabelClassificationLROTask> list = new(singleLabelClassifyActions.Count);

            foreach (SingleLabelClassifyAction action in singleLabelClassifyActions)
            {
                list.Add(ConvertToCustomSingleClassificationTask(action));
            }

            return list;
        }

        internal static IList<CustomMultiLabelClassificationLROTask> ConvertFromMultiLabelClassifyActionsToTasks(IReadOnlyCollection<MultiLabelClassifyAction> multiLabelClassifyActions)
        {
            List<CustomMultiLabelClassificationLROTask> list = new(multiLabelClassifyActions.Count);

            foreach (MultiLabelClassifyAction action in multiLabelClassifyActions)
            {
                list.Add(ConvertToCustomMultiClassificationTask(action));
            }

            return list;
        }

        internal static IList<CustomEntitiesLROTask> ConvertFromRecognizeCustomEntitiesActionsToTasks(IReadOnlyCollection<RecognizeCustomEntitiesAction> recognizeCustomEntitiesActions)
        {
            List<CustomEntitiesLROTask> list = new(recognizeCustomEntitiesActions.Count);

            foreach (var action in recognizeCustomEntitiesActions)
            {
                list.Add(ConvertToCustomEntitiesLROTask(action));
            }

            return list;
        }

        internal static IList<ExtractiveSummarizationLROTask> ConvertFromExtractiveSummarizeActionsToTasks(IReadOnlyCollection<ExtractiveSummarizeAction> extractiveSummarizeActions)
        {
            List<ExtractiveSummarizationLROTask> list = new(extractiveSummarizeActions.Count);

            foreach (ExtractiveSummarizeAction action in extractiveSummarizeActions)
            {
                list.Add(ConvertToExtractiveSummarizationTask(action));
            }

            return list;
        }

        internal static IList<AbstractiveSummarizationLROTask> ConvertFromAbstractiveSummarizeActionsToTasks(IReadOnlyCollection<AbstractiveSummarizeAction> abstractiveSummarizeActions)
        {
            List<AbstractiveSummarizationLROTask> list = new(abstractiveSummarizeActions.Count);

            foreach (AbstractiveSummarizeAction action in abstractiveSummarizeActions)
            {
                list.Add(ConvertToAbstractiveSummarizationTask(action));
            }

            return list;
        }

        internal static AnalyzeActionsResult ConvertToAnalyzeActionsResult(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            List<ExtractKeyPhrasesActionResult> keyPhrases = new();
            List<RecognizeEntitiesActionResult> entitiesRecognition = new();
            List<RecognizePiiEntitiesActionResult> entitiesPiiRecognition = new();
            List<RecognizeLinkedEntitiesActionResult> entitiesLinkingRecognition = new();
            List<AnalyzeSentimentActionResult> analyzeSentiment = new();
            List<RecognizeCustomEntitiesActionResult> customEntitiesRecognition = new();
            List<SingleLabelClassifyActionResult> singleLabelClassify = new();
            List<MultiLabelClassifyActionResult> multiLabelClassify = new();
            List<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntities = new();
            List<ExtractiveSummarizeActionResult> extractiveSummarize = new();
            List<AbstractiveSummarizeActionResult> abstractiveSummarize = new();

            foreach (AnalyzeTextLROResult task in jobState.Tasks.Items)
            {
                if (task.Kind == AnalyzeTextLROResultsKind.KeyPhraseExtractionLROResults)
                {
                    keyPhrases.Add(new ExtractKeyPhrasesActionResult(ConvertToExtractKeyPhrasesResultCollection((task as KeyPhraseExtractionLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.EntityRecognitionLROResults)
                {
                    entitiesRecognition.Add(new RecognizeEntitiesActionResult(ConvertToRecognizeEntitiesResultCollection((task as EntityRecognitionLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.PiiEntityRecognitionLROResults)
                {
                    entitiesPiiRecognition.Add(new RecognizePiiEntitiesActionResult(ConvertToRecognizePiiEntitiesResultCollection((task as PiiEntityRecognitionLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.EntityLinkingLROResults)
                {
                    entitiesLinkingRecognition.Add(new RecognizeLinkedEntitiesActionResult(ConvertToLinkedEntitiesResultCollection((task as EntityLinkingLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.SentimentAnalysisLROResults)
                {
                    analyzeSentiment.Add(new AnalyzeSentimentActionResult(ConvertToAnalyzeSentimentResultCollection((task as SentimentLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.CustomEntityRecognitionLROResults)
                {
                    customEntitiesRecognition.Add(new RecognizeCustomEntitiesActionResult(ConvertToRecognizeCustomEntitiesResultCollection((task as CustomEntityRecognitionLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.CustomSingleLabelClassificationLROResults)
                {
                    singleLabelClassify.Add(new SingleLabelClassifyActionResult(ConvertToClassifyDocumentResultCollection((task as CustomSingleLabelClassificationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.CustomMultiLabelClassificationLROResults)
                {
                    multiLabelClassify.Add(new MultiLabelClassifyActionResult(ConvertToClassifyDocumentResultCollection((task as CustomMultiLabelClassificationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.HealthcareLROResults)
                {
                    analyzeHealthcareEntities.Add(new AnalyzeHealthcareEntitiesActionResult(ConvertToAnalyzeHealthcareEntitiesResultCollection((task as HealthcareLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.ExtractiveSummarizationLROResults)
                {
                    extractiveSummarize.Add(new ExtractiveSummarizeActionResult(ConvertToExtractiveSummarizeResultCollection((task as ExtractiveSummarizationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.AbstractiveSummarizationLROResults)
                {
                    abstractiveSummarize.Add(new AbstractiveSummarizeActionResult(ConvertToAbstractiveSummarizeResultCollection((task as AbstractiveSummarizationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
            }

            return new AnalyzeActionsResult(
                keyPhrases,
                entitiesRecognition,
                entitiesPiiRecognition,
                entitiesLinkingRecognition,
                analyzeSentiment,
                customEntitiesRecognition,
                singleLabelClassify,
                multiLabelClassify,
                analyzeHealthcareEntities,
                extractiveSummarize,
                abstractiveSummarize);
        }

        #endregion

        #region Long Running Operations

        internal static AnalyzeTextJobStatusResult ConvertToAnalyzeTextJobStatusResult(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            var result = new AnalyzeTextJobStatusResult
            {
                DisplayName = jobState.DisplayName,
                NextLink = jobState.NextLink,
                CreatedOn = jobState.CreatedDateTime,
                LastModifiedOn = jobState.LastUpdatedDateTime,
                ExpiresOn = jobState.ExpirationDateTime,
                AcionsSucceeded = jobState.Tasks.Completed,
                AcionsInProgress = jobState.Tasks.InProgress,
                ActionsFailed = jobState.Tasks.Failed,
                ActionsTotal = jobState.Tasks.Total,
                Status = jobState.Status
            };

            if (result.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                result.Result = ConvertToAnalyzeActionsResult(jobState, map);
            }

            foreach (var error in jobState.Errors)
            {
                result.Errors.Add(error);
            }

            return result;
        }

        internal static HealthcareJobStatusResult ConvertToHealthcareJobStatusResult(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            var result = new HealthcareJobStatusResult
            {
                NextLink = jobState.NextLink,
                CreatedOn = jobState.CreatedDateTime,
                LastModifiedOn = jobState.LastUpdatedDateTime,
                ExpiresOn = jobState.ExpirationDateTime,
                Status = jobState.Status,
                DisplayName = jobState.DisplayName,
            };

            if (result.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                result.Result = ExtractHealthcareActionResult(jobState, map);
            }

            foreach (var error in jobState.Errors)
            {
                result.Errors.Add(error);
            }

            return result;
        }

        private static TCollection ExtractActionResult<TCollection, TResult>(AnalyzeTextJobState jobState, IDictionary<string, int> map, AnalyzeTextLROResultsKind kind, Func<TResult, IDictionary<string, int>, TCollection> convert)
            where TResult : AnalyzeTextLROResult
        {
            AnalyzeTextLROResult task = jobState.Tasks.Items[0];
            if (task.Kind == kind)
            {
                return convert(task as TResult, map);
            }
            throw new InvalidOperationException($"Invalid task executed. Expected a {kind} but instead got {task.Kind}.");
        }

        internal static JobStatusResult<TCollection> ConvertToJobStatusResult<TCollection, TResult>(AnalyzeTextJobState jobState, IDictionary<string, int> map, AnalyzeTextLROResultsKind kind, Func<TResult, IDictionary<string, int>, TCollection> convert)
            where TResult : AnalyzeTextLROResult
        {
            var result = new JobStatusResult<TCollection>
            {
                NextLink = jobState.NextLink,
                CreatedOn = jobState.CreatedDateTime,
                LastModifiedOn = jobState.LastUpdatedDateTime,
                ExpiresOn = jobState.ExpirationDateTime,
                Status = jobState.Status
            };

            if (result.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                result.Result = ExtractActionResult<TCollection, TResult>(jobState, map, kind, convert);
            }

            foreach (var error in jobState.Errors)
            {
                result.Errors.Add(error);
            }

            return result;
        }

        #endregion

        private static List<T> SortHeterogeneousCollection<T>(List<T> collection, IDictionary<string, int> idToIndexMap) where T : TextAnalyticsResult
        {
            return collection.OrderBy(result => idToIndexMap[result.Id]).ToList();
        }
    }
}
