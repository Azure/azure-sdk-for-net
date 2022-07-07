// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    internal static partial class Transforms
    {
        #region Common

        public static readonly Regex _targetRegex = new Regex("#/tasks/(keyPhraseExtractionTasks|entityRecognitionPiiTasks|entityRecognitionTasks|entityLinkingTasks|sentimentAnalysisTasks|extractiveSummarizationTasks|customSingleClassificationTasks|customMultiClassificationTasks|customEntityRecognitionTasks)/(\\d+)", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

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

        internal static DetectLanguageResultCollection ConvertToDetectLanguageResultCollection(LanguageDetectionResult results, IDictionary<string, int> idToIndexMap)
        {
            var detectedLanguages = new List<DetectLanguageResult>(results.Documents.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
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
            foreach (DocumentError error in results.Errors)
            {
                analyzedSentiments.Add(new AnalyzeSentimentResult(error.Id, ConvertToError(error.Error)));
            }

            //Read sentiments
            foreach (var docSentiment in results.Documents)
            {
                analyzedSentiments.Add(new AnalyzeSentimentResult(docSentiment.Id, docSentiment.Statistics ?? default, new DocumentSentiment(docSentiment)));
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
            foreach (DocumentError error in results.Errors)
            {
                keyPhrases.Add(new ExtractKeyPhrasesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read Key phrases
            foreach (KeyPhraseResultDocumentsItem docKeyPhrases in results.Documents)
            {
                keyPhrases.Add(new ExtractKeyPhrasesResult(docKeyPhrases.Id, docKeyPhrases.Statistics ?? default, ConvertToKeyPhraseCollection(docKeyPhrases)));
            }

            keyPhrases = SortHeterogeneousCollection(keyPhrases, idToIndexMap);
            return new ExtractKeyPhrasesResultCollection(keyPhrases, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Recognize Entities

        internal static List<CategorizedEntity> ConvertToCategorizedEntityList(List<Entity> entities)
            => entities.Select((entity) => new CategorizedEntity(entity)).ToList();

        internal static CategorizedEntityCollection ConvertToCategorizedEntityCollection(EntitiesResultDocumentsItem documentEntities)
        {
            return new CategorizedEntityCollection(ConvertToCategorizedEntityList(documentEntities.Entities.ToList()), ConvertToWarnings(documentEntities.Warnings));
        }

        internal static RecognizeEntitiesResultCollection ConvertToRecognizeEntitiesResultCollection(EntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizeEntitiesResult>(results.Documents.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (var docEntities in results.Documents)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToCategorizedEntityCollection(docEntities)));
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

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (var docEntities in results.Documents)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToCategorizedEntityCollection(docEntities)));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizeCustomEntitiesResultCollection(recognizeEntities, results.Statistics, results.ProjectName, results.DeploymentName);
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

        internal static PiiEntityCollection ConvertToPiiEntityCollection(PiiResultDocumentsItem piiResult)
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

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                recognizeEntities.Add(new RecognizePiiEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (var docEntities in results.Documents)
            {
                recognizeEntities.Add(new RecognizePiiEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToPiiEntityCollection(docEntities)));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizePiiEntitiesResultCollection(recognizeEntities, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Recognize Linked Entities

        internal static LinkedEntityCollection ConvertToLinkedEntityCollection(EntityLinkingResultDocumentsItem documentEntities)
        {
            return new LinkedEntityCollection(documentEntities.Entities.ToList(), ConvertToWarnings(documentEntities.Warnings));
        }

        internal static RecognizeLinkedEntitiesResultCollection ConvertToLinkedEntitiesResultCollection(EntityLinkingResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeLinkedEntities = new List<RecognizeLinkedEntitiesResult>(results.Documents.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                recognizeLinkedEntities.Add(new RecognizeLinkedEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (EntityLinkingResultDocumentsItem docEntities in results.Documents)
            {
                recognizeLinkedEntities.Add(new RecognizeLinkedEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToLinkedEntityCollection(docEntities)));
            }

            recognizeLinkedEntities = SortHeterogeneousCollection(recognizeLinkedEntities, idToIndexMap);
            return new RecognizeLinkedEntitiesResultCollection(recognizeLinkedEntities, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Healthcare

        internal static List<HealthcareEntity> ConvertToHealthcareEntityCollection(IEnumerable<HealthcareEntityInternal> healthcareEntities)
        {
            return healthcareEntities.Select((entity) => new HealthcareEntity(entity)).ToList();
        }

        internal static AnalyzeHealthcareEntitiesResultCollection ConvertToAnalyzeHealthcareEntitiesResultCollection(HealthcareResult results, IDictionary<string, int> idToIndexMap)
        {
            var healthcareEntititesResults = new List<AnalyzeHealthcareEntitiesResult>(results.Documents.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                healthcareEntititesResults.Add(new AnalyzeHealthcareEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read entities
            foreach (var documentHealthcareEntities in results.Documents)
            {
                healthcareEntititesResults.Add(new AnalyzeHealthcareEntitiesResult(
                    documentHealthcareEntities.Id,
                    documentHealthcareEntities.Statistics ?? default,
                    ConvertToHealthcareEntityCollection(documentHealthcareEntities.Entities),
                    ConvertToHealthcareEntityRelationsCollection(documentHealthcareEntities.Entities, documentHealthcareEntities.Relations),
                    ConvertToWarnings(documentHealthcareEntities.Warnings),
                    documentHealthcareEntities.FhirBundle));
            }

            healthcareEntititesResults = healthcareEntititesResults.OrderBy(result => idToIndexMap[result.Id]).ToList();

            return new AnalyzeHealthcareEntitiesResultCollection(healthcareEntititesResults, results.Statistics, results.ModelVersion);
        }

        private static IList<HealthcareEntityRelation> ConvertToHealthcareEntityRelationsCollection(IList<HealthcareEntityInternal> healthcareEntities, IList<HealthcareRelationInternal> healthcareRelations)
        {
            List<HealthcareEntityRelation> result = new List<HealthcareEntityRelation>();
            foreach (HealthcareRelationInternal relation in healthcareRelations)
            {
                result.Add(new HealthcareEntityRelation(relation.RelationType, ConvertToHealthcareEntityRelationRoleCollection(relation.Entities, healthcareEntities)));
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
                return Transforms.ConvertToAnalyzeHealthcareEntitiesResultCollection((healthcareTask as HealthcareLROResult).Results, map);
            }
            throw new InvalidOperationException($"Invalid task executed. Expected a HealthcareLROResults but instead got {healthcareTask.Kind}.");
        }

        #endregion

        #region Extract Summary

        internal static List<SummarySentence> ConvertToSummarySentenceList(List<ExtractedSummarySentence> sentences)
            => sentences.Select((sentence) => new SummarySentence(sentence)).ToList();

        internal static SummarySentenceCollection ConvertToSummarySentenceCollection(ExtractiveSummarizationResultDocumentsItem documentSummary)
        {
            return new SummarySentenceCollection(ConvertToSummarySentenceList(documentSummary.Sentences.ToList()), ConvertToWarnings(documentSummary.Warnings));
        }

        internal static ExtractSummaryResultCollection ConvertToExtractSummaryResultCollection(ExtractiveSummarizationResult results, IDictionary<string, int> idToIndexMap)
        {
            var extractedSummaries = new List<ExtractSummaryResult>(results.Errors.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                extractedSummaries.Add(new ExtractSummaryResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document summaries
            foreach (var docSummary in results.Documents)
            {
                extractedSummaries.Add(new ExtractSummaryResult(docSummary.Id, docSummary.Statistics ?? default, ConvertToSummarySentenceCollection(docSummary)));
            }

            extractedSummaries = SortHeterogeneousCollection(extractedSummaries, idToIndexMap);
            return new ExtractSummaryResultCollection(extractedSummaries, results.Statistics, results.ModelVersion);
        }

        #endregion

        #region Multi-Category Classify
        internal static List<ClassificationCategory> ConvertToClassificationCategoryList(List<ClassificationResult> classifications)
            => classifications.Select((classification) => new ClassificationCategory(classification)).ToList();

        internal static ClassificationCategoryCollection ConvertToClassificationCategoryCollection(CustomMultiLabelClassificationResultDocumentsItem extractedClassificationsDocuments)
        {
            return new ClassificationCategoryCollection(ConvertToClassificationCategoryList(extractedClassificationsDocuments.Class.ToList()), ConvertToWarnings(extractedClassificationsDocuments.Warnings));
        }

        internal static MultiCategoryClassifyResultCollection ConvertToMultiCategoryClassifyResultCollection(CustomMultiLabelClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            var classifiedCustomCategoryResults = new List<MultiCategoryClassifyResult>(results.Errors.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                classifiedCustomCategoryResults.Add(new MultiCategoryClassifyResult(error.Id, ConvertToError(error.Error)));
            }

            //Read classifications
            foreach (var classificationsDocument in results.Documents)
            {
                classifiedCustomCategoryResults.Add(new MultiCategoryClassifyResult(
                    classificationsDocument.Id,
                    classificationsDocument.Statistics ?? default,
                    ConvertToClassificationCategoryCollection(classificationsDocument),
                    ConvertToWarnings(classificationsDocument.Warnings)));
            }

            classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);
            return new MultiCategoryClassifyResultCollection(classifiedCustomCategoryResults, results.Statistics, results.ProjectName, results.DeploymentName);
        }

        #endregion

        #region Single Category Classify
        internal static SingleCategoryClassifyResultCollection ConvertToSingleCategoryClassifyResultCollection(CustomSingleLabelClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            var classifiedCustomCategoryResults = new List<SingleCategoryClassifyResult>(results.Errors.Count);

            //Read errors
            foreach (DocumentError error in results.Errors)
            {
                classifiedCustomCategoryResults.Add(new SingleCategoryClassifyResult(error.Id, ConvertToError(error.Error)));
            }

            //Read classifications
            foreach (var classificationDocument in results.Documents)
            {
                classifiedCustomCategoryResults.Add(new SingleCategoryClassifyResult(
                    classificationDocument.Id,
                    classificationDocument.Statistics ?? default,
                    new ClassificationCategory(classificationDocument.Class),
                    ConvertToWarnings(classificationDocument.Warnings)));
            }

            classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);
            return new SingleCategoryClassifyResultCollection(classifiedCustomCategoryResults, results.Statistics, results.ProjectName, results.DeploymentName);
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

        internal static ExtractiveSummarizationLROTask ConvertToExtractiveSummarizationTask(ExtractSummaryAction action)
        {
            return new ExtractiveSummarizationLROTask()
            {
                Parameters = new ExtractiveSummarizationTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs,
                    SentenceCount = action.MaxSentenceCount,
                    SortBy = action.OrderBy == null ? (ExtractiveSummarizationSortingCriteria?)null : action.OrderBy.ToString(),
                },
                TaskName = action.ActionName
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

        internal static CustomSingleLabelClassificationLROTask ConvertToCustomSingleClassificationTask(SingleCategoryClassifyAction action)
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

        internal static CustomMultiLabelClassificationLROTask ConvertToCustomMultiClassificationTask(MultiCategoryClassifyAction action)
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

        internal static IList<ExtractiveSummarizationLROTask> ConvertFromExtractSummaryActionsToTasks(IReadOnlyCollection<ExtractSummaryAction> extractSummaryActions)
        {
            List<ExtractiveSummarizationLROTask> list = new(extractSummaryActions.Count);

            foreach (ExtractSummaryAction action in extractSummaryActions)
            {
                list.Add(ConvertToExtractiveSummarizationTask(action));
            }

            return list;
        }

        internal static IList<CustomSingleLabelClassificationLROTask> ConvertFromSingleCategoryClassifyActionsToTasks(IReadOnlyCollection<SingleCategoryClassifyAction> singleCategoryClassifyActions)
        {
            List<CustomSingleLabelClassificationLROTask> list = new(singleCategoryClassifyActions.Count);

            foreach (SingleCategoryClassifyAction action in singleCategoryClassifyActions)
            {
                list.Add(ConvertToCustomSingleClassificationTask(action));
            }

            return list;
        }

        internal static IList<CustomMultiLabelClassificationLROTask> ConvertFromMultiCategoryClassifyActionsToTasks(IReadOnlyCollection<MultiCategoryClassifyAction> MultiCategoryClassifyActions)
        {
            List<CustomMultiLabelClassificationLROTask> list = new(MultiCategoryClassifyActions.Count);

            foreach (MultiCategoryClassifyAction action in MultiCategoryClassifyActions)
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

        internal static AnalyzeActionsResult ConvertToAnalyzeActionsResult(AnalyzeTextJobState jobState, IDictionary<string, int> map)
        {
            List<ExtractKeyPhrasesActionResult> keyPhrases = new();
            List<RecognizeEntitiesActionResult> entitiesRecognition = new();
            List<RecognizePiiEntitiesActionResult> entitiesPiiRecognition = new();
            List<RecognizeLinkedEntitiesActionResult> entitiesLinkingRecognition = new();
            List<AnalyzeSentimentActionResult> analyzeSentiment = new();
            List<ExtractSummaryActionResult> extractSummary = new();
            List<RecognizeCustomEntitiesActionResult> customEntitiesRecognition = new();
            List<SingleCategoryClassifyActionResult> singleCategoryClassify = new();
            List<MultiCategoryClassifyActionResult> multiCategoryClassify = new();

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
                else if (task.Kind == AnalyzeTextLROResultsKind.ExtractiveSummarizationLROResults)
                {
                    extractSummary.Add(new ExtractSummaryActionResult(ConvertToExtractSummaryResultCollection((task as ExtractiveSummarizationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.CustomEntityRecognitionLROResults)
                {
                    customEntitiesRecognition.Add(new RecognizeCustomEntitiesActionResult(ConvertToRecognizeCustomEntitiesResultCollection((task as CustomEntityRecognitionLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.CustomSingleLabelClassificationLROResults)
                {
                    singleCategoryClassify.Add(new SingleCategoryClassifyActionResult(ConvertToSingleCategoryClassifyResultCollection((task as CustomSingleLabelClassificationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
                else if (task.Kind == AnalyzeTextLROResultsKind.CustomMultiLabelClassificationLROResults)
                {
                    multiCategoryClassify.Add(new MultiCategoryClassifyActionResult(ConvertToMultiCategoryClassifyResultCollection((task as CustomMultiLabelClassificationLROResult).Results, map), task.TaskName, task.LastUpdateDateTime));
                }
            }

            return new AnalyzeActionsResult(
                keyPhrases,
                entitiesRecognition,
                entitiesPiiRecognition,
                entitiesLinkingRecognition,
                analyzeSentiment,
                extractSummary,
                customEntitiesRecognition,
                singleCategoryClassify,
                multiCategoryClassify);
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
                LastModifiedOn = jobState.LastUpdateDateTime,
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
                LastModifiedOn = jobState.LastUpdateDateTime,
                ExpiresOn = jobState.ExpirationDateTime,
                Status = jobState.Status
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

        #endregion

        private static List<T> SortHeterogeneousCollection<T>(List<T> collection, IDictionary<string, int> idToIndexMap) where T : TextAnalyticsResult
        {
            return collection.OrderBy(result => idToIndexMap[result.Id]).ToList();
        }
    }
}
