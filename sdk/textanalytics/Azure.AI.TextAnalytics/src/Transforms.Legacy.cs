// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    ///   This portion of the class defines the transformations needed for interacting
    ///   with the legacy Text Analytics REST API generated types.
    /// </summary>
    internal static partial class Transforms
    {
        /// <summary>The expression used for extracting indexes from a sentence sentiment assessment.</summary>
        private static readonly Regex s_sentenceSentimentAssessmentRegex = new(@"/documents/(?<documentIndex>\d*)/sentences/(?<sentenceIndex>\d*)/assessments/(?<assessmentIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        private static readonly Regex s_legacyHealthcareEntityRegex = new Regex(@"\#/results/documents\/(?<documentIndex>\d*)\/entities\/(?<entityIndex>\d*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        #region Common

        internal static Models.InnerErrorModel ConvertToLanguageError(Legacy.InnerError error)
        {
            if (error == null)
            {
                return null;
            }

            // The legacy details are a read-only dictionary.  It cannot be assumed that
            // casting to IDictionary is safe; attempt a cast and fall back to making a copy,
            // if needed.

            var errorDetails = error.Details switch
            {
                IDictionary<string, string> dictionary => dictionary,
                _=> error.Details.ToDictionary(x => x.Key, x => x.Value)
            };

            return new Models.InnerErrorModel(
                error.Code.ToString(),
                error.Message,
                errorDetails,
                error.Target,
                ConvertToLanguageError(error.Innererror));
        }

        internal static Models.Error ConvertToLanguageError(Legacy.TextAnalyticsError error)
        {
            if (error == null)
            {
                return null;
            }

            var errorDetails = default(List<Models.Error>);

            if (error.Details != null)
            {
                errorDetails = new List<Models.Error>(error.Details.Count);

                foreach (var errorDetail in error.Details)
                {
                    errorDetails.Add(ConvertToLanguageError(errorDetail));
                }
            }

            return new Models.Error(
                error.Code.ToString(),
                error.Message,
                error.Target,
                errorDetails,
                ConvertToLanguageError(error.Innererror), null);
        }

        internal static TextAnalyticsError ConvertToError(Legacy.TextAnalyticsError error)
        {
            var innerError = error.Innererror;

            return (innerError != null)
                ? new TextAnalyticsError(innerError.Code.ToString(), innerError.Message, innerError.Target)
                : new TextAnalyticsError(error.Code.ToString(), error.Message, error.Target);
        }

        internal static List<TextAnalyticsWarning> ConvertToWarnings(IReadOnlyList<Legacy.TextAnalyticsWarning> internalWarnings)
        {
            var warnings = new List<TextAnalyticsWarning>();

            if (internalWarnings == null)
            {
                return warnings;
            }

            foreach (var warning in internalWarnings)
            {
                warnings.Add(new TextAnalyticsWarning(warning.Code.ToString(), warning.Message));
            }

            return warnings;
        }

        internal static TextDocumentStatistics ConvertToDocumentStatistics(Legacy.DocumentStatistics legacyStatistics) =>
            (legacyStatistics != null)
                ? new TextDocumentStatistics(legacyStatistics.CharactersCount, legacyStatistics.TransactionsCount)
                : default;

        internal static TextDocumentBatchStatistics ConvertToBatchStatistics(Legacy.RequestStatistics legacyStatistics) =>
            (legacyStatistics != null)
                ? new TextDocumentBatchStatistics(legacyStatistics.DocumentsCount, legacyStatistics.ValidDocumentsCount, legacyStatistics.ErroneousDocumentsCount, legacyStatistics.TransactionsCount)
                : default;

        internal static TextAnalyticsOperationStatus ConvertToTextAnalyticsOperationStatus(Legacy.Models.State legacyState) =>
            legacyState switch
            {
                Legacy.Models.State.Cancelling => TextAnalyticsOperationStatus.Cancelling,
                Legacy.Models.State.Cancelled => TextAnalyticsOperationStatus.Cancelled,
                Legacy.Models.State.Failed => TextAnalyticsOperationStatus.Failed,
                Legacy.Models.State.Running => TextAnalyticsOperationStatus.Running,
                Legacy.Models.State.Succeeded => TextAnalyticsOperationStatus.Succeeded,
                Legacy.Models.State.NotStarted => TextAnalyticsOperationStatus.NotStarted,
                Legacy.Models.State.Rejected => TextAnalyticsOperationStatus.Rejected,
                _ => new TextAnalyticsOperationStatus(legacyState.ToString())
            };

        #endregion

        #region DetectLanguage

        internal static DetectedLanguage ConvertToDetectedLanguage(Legacy.DocumentLanguage documentLanguage)
        {
            var detected = documentLanguage.DetectedLanguage;
            return new DetectedLanguage(detected.Name, detected.Iso6391Name, detected.ConfidenceScore, default, ConvertToWarnings(documentLanguage.Warnings));
        }

        internal static DetectLanguageResultCollection ConvertToDetectLanguageResultCollection(Legacy.LanguageResult results, IDictionary<string, int> idToIndexMap)
        {
            var detectedLanguages = new List<DetectLanguageResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                detectedLanguages.Add(new DetectLanguageResult(error.Id, ConvertToError(error.Error)));
            }

            //Read languages
            foreach (var language in results.Documents)
            {
                detectedLanguages.Add(new DetectLanguageResult(language.Id, ConvertToDocumentStatistics(language.Statistics), ConvertToDetectedLanguage(language)));
            }

            detectedLanguages = SortHeterogeneousCollection(detectedLanguages, idToIndexMap);

            return new DetectLanguageResultCollection(detectedLanguages, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        #endregion

        #region AnalyzeSentiment

        internal static TextSentiment ConvertToTextSentiment(Legacy.Models.SentenceSentimentValue sentiment) =>
            sentiment switch
            {
                Legacy.Models.SentenceSentimentValue.Neutral => TextSentiment.Neutral,
                Legacy.Models.SentenceSentimentValue.Positive => TextSentiment.Positive,
                Legacy.Models.SentenceSentimentValue.Negative => TextSentiment.Negative,
                _ => throw new NotSupportedException($"The sentence sentiment, { sentiment }, is not supported for conversion.")
            };

        internal static TextSentiment ConvertToTextSentiment(Legacy.Models.TokenSentimentValue sentiment) =>
            sentiment switch
            {
                Legacy.Models.TokenSentimentValue.Mixed => TextSentiment.Neutral,
                Legacy.Models.TokenSentimentValue.Positive => TextSentiment.Positive,
                Legacy.Models.TokenSentimentValue.Negative => TextSentiment.Negative,
                _ => throw new NotSupportedException($"The token sentiment, { sentiment }, is not supported for conversion.")
            };

        internal static TextSentiment ConvertToTextSentiment(Legacy.Models.DocumentSentimentValue sentiment) =>
            sentiment switch
            {
                Legacy.Models.DocumentSentimentValue.Neutral => TextSentiment.Neutral,
                Legacy.Models.DocumentSentimentValue.Positive => TextSentiment.Positive,
                Legacy.Models.DocumentSentimentValue.Negative => TextSentiment.Negative,
                Legacy.Models.DocumentSentimentValue.Mixed => TextSentiment.Mixed,
                _ => throw new NotSupportedException($"The document sentiment, { sentiment }, is not supported for conversion.")
            };

        internal static List<SentenceOpinion> ConvertToSentenceOpinions(Legacy.SentenceSentiment currentSentence, IReadOnlyList<Legacy.SentenceSentiment> allSentences)
        {
            var opinions = new List<SentenceOpinion>();

            foreach (var target in currentSentence.Targets)
            {
                var assessments = new List<AssessmentSentiment>();

                foreach (var relation in target.Relations)
                {
                    if (relation.RelationType == Legacy.Models.TargetRelationType.Assessment)
                    {
                        assessments.Add(ResolveAssessmentReference(allSentences, relation.Ref));
                    }
                }

                var targetSentiment = new TargetSentiment(
                    ConvertToTextSentiment(target.Sentiment),
                    target.Text,
                    target.ConfidenceScores.Positive,
                    target.ConfidenceScores.Negative,
                    target.Offset,
                    target.Length);

                opinions.Add(new SentenceOpinion(targetSentiment, assessments));
            }

            return opinions;
        }

        internal static List<SentenceSentiment> ConvertToSentenceSentiments(IReadOnlyList<Legacy.SentenceSentiment> legacySentences)
        {
            var sentences = new List<SentenceSentiment>(legacySentences.Count);

            foreach (var legacySentence in legacySentences)
            {
                sentences.Add(new SentenceSentiment(
                    ConvertToTextSentiment(legacySentence.Sentiment),
                    legacySentence.Text,
                    legacySentence.ConfidenceScores.Positive,
                    legacySentence.ConfidenceScores.Neutral,
                    legacySentence.ConfidenceScores.Negative,
                    legacySentence.Offset,
                    legacySentence.Length,
                    ConvertToSentenceOpinions(legacySentence, legacySentences)));
            }

            return sentences;
        }

        internal static DocumentSentiment ConvertToDocumentSentiment(Legacy.DocumentSentiment legacySentiment) =>
            new DocumentSentiment(
                sentiment: ConvertToTextSentiment(legacySentiment.Sentiment),
                positiveScore: legacySentiment.ConfidenceScores.Positive,
                neutralScore: legacySentiment.ConfidenceScores.Neutral,
                negativeScore: legacySentiment.ConfidenceScores.Negative,
                sentenceSentiments: ConvertToSentenceSentiments(legacySentiment.Sentences),
                warnings: ConvertToWarnings(legacySentiment.Warnings));

        internal static AnalyzeSentimentResultCollection ConvertToAnalyzeSentimentResultCollection(Legacy.SentimentResponse results, IDictionary<string, int> idToIndexMap)
        {
            var analyzedSentiments = new List<AnalyzeSentimentResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                analyzedSentiments.Add(new AnalyzeSentimentResult(error.Id, ConvertToError(error.Error)));
            }

            //Read sentiments
            foreach (var docSentiment in results.Documents)
            {
                analyzedSentiments.Add(
                    new AnalyzeSentimentResult(
                        docSentiment.Id,
                        ConvertToDocumentStatistics(docSentiment.Statistics),
                        ConvertToDocumentSentiment(docSentiment),
                        default));
            }

            analyzedSentiments = SortHeterogeneousCollection(analyzedSentiments, idToIndexMap);
            return new AnalyzeSentimentResultCollection(analyzedSentiments, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        internal static Legacy.SentimentAnalysisTask ConvertToLegacySentimentAnalysisTask(AnalyzeSentimentAction action)
        {
            return new Legacy.SentimentAnalysisTask()
            {
                Parameters = new Legacy.Models.SentimentAnalysisTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultLegacyStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs,
                    OpinionMining = action.IncludeOpinionMining
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.SentimentAnalysisTask> ConvertFromAnalyzeSentimentActionsToLegacyTasks(IReadOnlyCollection<AnalyzeSentimentAction> analyzeSentimentActions)
        {
            List<Legacy.SentimentAnalysisTask> list = new List<Legacy.SentimentAnalysisTask>(analyzeSentimentActions.Count);

            foreach (AnalyzeSentimentAction action in analyzeSentimentActions)
            {
                list.Add(ConvertToLegacySentimentAnalysisTask(action));
            }

            return list;
        }

        private static AssessmentSentiment ResolveAssessmentReference(IReadOnlyList<Legacy.SentenceSentiment> sentences, string reference)
        {
            // Example:
            //   The following should result in sentenceIndex = 2, assessmentIndex = 1. (there will not be cases where sentences from other documents are referenced)
            //   "#/documents/0/sentences/2/assessments/1"

            var assessmentMatch = s_sentenceSentimentAssessmentRegex.Match(reference);

            if (assessmentMatch.Success
                 && assessmentMatch.Groups.Count == 4
                 && int.TryParse(assessmentMatch.Groups["sentenceIndex"]?.Value, out var sentenceIndex)
                 && int.TryParse(assessmentMatch.Groups["assessmentIndex"]?.Value, out var assessmentIndex)
                 && sentenceIndex < sentences.Count
                 && assessmentIndex < sentences[sentenceIndex].Assessments.Count)
            {
                var assessment = sentences[sentenceIndex].Assessments[assessmentIndex];

                return new AssessmentSentiment(
                    ConvertToTextSentiment(assessment.Sentiment),
                    assessment.ConfidenceScores.Positive,
                    assessment.ConfidenceScores.Negative,
                    assessment.Text,
                    assessment.IsNegated,
                    assessment.Offset,
                    assessment.Length);
            }

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }

        #endregion

        #region KeyPhrases

        internal static KeyPhraseCollection ConvertToKeyPhraseCollection(Legacy.DocumentKeyPhrases documentKeyPhrases) =>
            new KeyPhraseCollection(documentKeyPhrases.KeyPhrases.ToList(), ConvertToWarnings(documentKeyPhrases.Warnings));

        internal static ExtractKeyPhrasesResultCollection ConvertToExtractKeyPhrasesResultCollection(Legacy.KeyPhraseResult results, IDictionary<string, int> idToIndexMap)
        {
            var keyPhrases = new List<ExtractKeyPhrasesResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                keyPhrases.Add(new ExtractKeyPhrasesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read Key phrases
            foreach (var docKeyPhrases in results.Documents)
            {
                keyPhrases.Add(
                    new ExtractKeyPhrasesResult(
                        docKeyPhrases.Id,
                        ConvertToDocumentStatistics(docKeyPhrases.Statistics),
                        ConvertToKeyPhraseCollection(docKeyPhrases),
                        default));
            }

            keyPhrases = SortHeterogeneousCollection(keyPhrases, idToIndexMap);
            return new ExtractKeyPhrasesResultCollection(keyPhrases, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        internal static Legacy.KeyPhrasesTask ConvertToLegacyKeyPhrasesTask(ExtractKeyPhrasesAction action)
        {
            return new Legacy.KeyPhrasesTask()
            {
                Parameters = new Legacy.Models.KeyPhrasesTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    LoggingOptOut = action.DisableServiceLogs
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.KeyPhrasesTask> ConvertFromExtractKeyPhrasesActionsToLegacyTasks(IReadOnlyCollection<ExtractKeyPhrasesAction> extractKeyPhrasesActions)
        {
            List<Legacy.KeyPhrasesTask> list = new List<Legacy.KeyPhrasesTask>(extractKeyPhrasesActions.Count);

            foreach (ExtractKeyPhrasesAction action in extractKeyPhrasesActions)
            {
                list.Add(ConvertToLegacyKeyPhrasesTask(action));
            }

            return list;
        }

        #endregion

        #region Recognize Entities

        internal static List<CategorizedEntity> ConvertToCategorizedEntityList(IReadOnlyList<Legacy.Entity> entities)
        {
            var entityList = new List<CategorizedEntity>(entities.Count);

            foreach (var entity in entities)
            {
                entityList.Add(new CategorizedEntity(entity.Text, entity.Category, entity.Subcategory, entity.ConfidenceScore, entity.Offset, entity.Length, default));
            }

            return entityList;
        }

        internal static RecognizeEntitiesResultCollection ConvertToRecognizeEntitiesResultCollection(Legacy.EntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizeEntitiesResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (var docEntities in results.Documents)
            {
                recognizeEntities.Add(
                    new RecognizeEntitiesResult(
                        docEntities.Id,
                        ConvertToDocumentStatistics(docEntities.Statistics),
                        ConvertToCategorizedEntityCollection(docEntities),
                        default));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizeEntitiesResultCollection(recognizeEntities, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        internal static Legacy.EntitiesTask ConvertToLegacyEntitiesTask(RecognizeEntitiesAction action)
        {
            return new Legacy.EntitiesTask()
            {
                Parameters = new Legacy.Models.EntitiesTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultLegacyStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.EntitiesTask> ConvertFromRecognizeEntitiesActionsToLegacyTasks(IReadOnlyCollection<RecognizeEntitiesAction> recognizeEntitiesActions)
        {
            List<Legacy.EntitiesTask> list = new List<Legacy.EntitiesTask>(recognizeEntitiesActions.Count);

            foreach (RecognizeEntitiesAction action in recognizeEntitiesActions)
            {
                list.Add(ConvertToLegacyEntitiesTask(action));
            }

            return list;
        }

        #endregion

        #region Recognize PII Entities

        internal static PiiEntityCollection ConvertToPiiEntityCollection(Legacy.PiiDocumentEntities documentEntities)
        {
            var entities = new List<PiiEntity>(documentEntities.Entities.Count);

            foreach (var entity in documentEntities.Entities)
            {
                entities.Add(new PiiEntity(entity.Text, entity.Category, entity.Subcategory, entity.ConfidenceScore, entity.Offset, entity.Length));
            }

            return new PiiEntityCollection(entities, documentEntities.RedactedText, ConvertToWarnings(documentEntities.Warnings));
        }

        internal static RecognizePiiEntitiesResultCollection ConvertToRecognizePiiEntitiesResultCollection(Legacy.PiiResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizePiiEntitiesResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                recognizeEntities.Add(new RecognizePiiEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document entities
            foreach (var docEntities in results.Documents)
            {
                recognizeEntities.Add(
                    new RecognizePiiEntitiesResult(
                        docEntities.Id,
                        ConvertToDocumentStatistics(docEntities.Statistics),
                        ConvertToPiiEntityCollection(docEntities),
                        default));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizePiiEntitiesResultCollection(recognizeEntities, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        internal static Legacy.PiiTask ConvertToLegacyPiiTask(RecognizePiiEntitiesAction action)
        {
            var parameters = new Legacy.PiiTaskParameters()
            {
                Domain = action.DomainFilter.GetString() ?? (Legacy.Models.PiiTaskParametersDomain?)null,
                ModelVersion = action.ModelVersion,
                StringIndexType = Constants.DefaultLegacyStringIndexType,
                LoggingOptOut = action.DisableServiceLogs
            };

            if (action.CategoriesFilter.Count > 0)
            {
                parameters.PiiCategories = new List<Legacy.Models.PiiEntityLegacyCategory>(action.CategoriesFilter.Count);

                foreach (var category in action.CategoriesFilter)
                {
                    parameters.PiiCategories.Add(new Legacy.Models.PiiEntityLegacyCategory(category.ToString()));
                }
            }

            return new Legacy.PiiTask()
            {
                Parameters = parameters,
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.PiiTask> ConvertFromRecognizePiiEntitiesActionsToLegacyTasks(IReadOnlyCollection<RecognizePiiEntitiesAction> recognizePiiEntitiesActions)
        {
            List<Legacy.PiiTask> list = new List<Legacy.PiiTask>(recognizePiiEntitiesActions.Count);

            foreach (RecognizePiiEntitiesAction action in recognizePiiEntitiesActions)
            {
                list.Add(ConvertToLegacyPiiTask(action));
            }

            return list;
        }

        #endregion

        #region Recognize Linked Entities

        internal static CategorizedEntityCollection ConvertToCategorizedEntityCollection(Legacy.DocumentEntities documentEntities) =>
            new CategorizedEntityCollection(ConvertToCategorizedEntityList(documentEntities.Entities), ConvertToWarnings(documentEntities.Warnings));

        internal static LinkedEntityCollection ConvertToLinkedEntityCollection(Legacy.DocumentLinkedEntities documentEntities) =>
            new LinkedEntityCollection(ConvertToLinkedEntityList(documentEntities.Entities), ConvertToWarnings(documentEntities.Warnings));

        internal static List<LinkedEntityMatch> ConvertToLinkedEntityMatches(IReadOnlyList<Legacy.Match> matches)
        {
            var matchesList = new List<LinkedEntityMatch>(matches.Count);

            foreach (var match in matches)
            {
                matchesList.Add(new LinkedEntityMatch(match.ConfidenceScore, match.Text, match.Offset, match.Length));
            }

            return matchesList;
        }

        internal static List<LinkedEntity> ConvertToLinkedEntityList(IReadOnlyList<Legacy.LinkedEntity> entities)
        {
            var entitiesList = new List<LinkedEntity>(entities.Count);

            foreach (var entity in entities)
            {
                entitiesList.Add(new LinkedEntity(entity.Name, ConvertToLinkedEntityMatches(entity.Matches), entity.Language, entity.Id, new Uri(entity.Url), entity.DataSource, entity.BingId));
            }

            return entitiesList;
        }

        internal static RecognizeLinkedEntitiesResultCollection ConvertToRecognizeLinkedEntitiesResultCollection(Legacy.EntityLinkingResult results, IDictionary<string, int> idToIndexMap)
        {
            var recognizeEntities = new List<RecognizeLinkedEntitiesResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                recognizeEntities.Add(new RecognizeLinkedEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document linked entities
            foreach (var docEntities in results.Documents)
            {
                recognizeEntities.Add(
                    new RecognizeLinkedEntitiesResult(
                        docEntities.Id,
                        ConvertToDocumentStatistics(docEntities.Statistics),
                        ConvertToLinkedEntityCollection(docEntities),
                        default));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizeLinkedEntitiesResultCollection(recognizeEntities, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        internal static Legacy.EntityLinkingTask ConvertToLegacyLinkedEntitiesTask(RecognizeLinkedEntitiesAction action)
        {
            return new Legacy.EntityLinkingTask()
            {
                Parameters = new Legacy.Models.EntityLinkingTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultLegacyStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.EntityLinkingTask> ConvertFromRecognizeLinkedEntitiesActionsToLegacyTasks(IReadOnlyCollection<RecognizeLinkedEntitiesAction> recognizeLinkedEntitiesActions)
        {
            List<Legacy.EntityLinkingTask> list = new List<Legacy.EntityLinkingTask>(recognizeLinkedEntitiesActions.Count);

            foreach (RecognizeLinkedEntitiesAction action in recognizeLinkedEntitiesActions)
            {
                list.Add(ConvertToLegacyLinkedEntitiesTask(action));
            }

            return list;
        }

        #endregion

        #region Healthcare

        internal static HealthcareEntity ConvertToHealthcareEntity(Legacy.HealthcareEntity entity) =>
            new HealthcareEntity(
                entity.Text,
                entity.Category,
                entity.Subcategory,
                entity.ConfidenceScore,
                entity.Offset,
                entity.Length,
                ConvertToEntityDataSource(entity.Links),
                ConvertToHealthcareEntityAssertion(entity.Assertion),
                entity.Name);

        internal static HealthcareEntityAssertion ConvertToHealthcareEntityAssertion(Legacy.HealthcareAssertion assertion)
        {
            if (assertion == null)
                return null;

            return new HealthcareEntityAssertion(
                ConvertToEntityConditionality(assertion.Conditionality),
                ConvertToEntityCertainty(assertion.Certainty),
                ConvertToEntityAssociation(assertion.Association));
        }

        internal static EntityConditionality? ConvertToEntityConditionality(Legacy.Models.Conditionality? legacyConditionality) =>
            legacyConditionality switch
            {
                null => (EntityConditionality?)null,
                Legacy.Models.Conditionality.Hypothetical => EntityConditionality.Hypothetical,
                Legacy.Models.Conditionality.Conditional => EntityConditionality.Conditional,
                _ => throw new NotSupportedException($"The conditionality, {legacyConditionality}, is not supported for conversion.")
            };

        internal static EntityCertainty? ConvertToEntityCertainty(Legacy.Models.Certainty? legacyCertainty) =>
            legacyCertainty switch
            {
                null => null,
                Legacy.Models.Certainty.Positive => EntityCertainty.Positive,
                Legacy.Models.Certainty.PositivePossible => EntityCertainty.PositivePossible,
                Legacy.Models.Certainty.NeutralPossible => EntityCertainty.NeutralPossible,
                Legacy.Models.Certainty.NegativePossible => EntityCertainty.NegativePossible,
                Legacy.Models.Certainty.Negative => EntityCertainty.Negative,
                _ => throw new NotSupportedException($"The certainty, {legacyCertainty}, is not supported for conversion.")
            };

        internal static EntityAssociation? ConvertToEntityAssociation(Legacy.Models.Association? legacyAssociation) =>
            legacyAssociation switch
            {
                null => null,
                Legacy.Models.Association.Subject => EntityAssociation.Subject,
                Legacy.Models.Association.Other => EntityAssociation.Other,
                _ => throw new NotSupportedException($"The association, {legacyAssociation}, is not supported for conversion.")
            };

        internal static List<EntityDataSource> ConvertToEntityDataSource(IReadOnlyList<Legacy.HealthcareEntityLink> healthcareEntityLinks)
        {
            var dataSources = new List<EntityDataSource>(healthcareEntityLinks.Count);

            foreach (var dataSource in healthcareEntityLinks)
            {
                dataSources.Add(new EntityDataSource(dataSource.DataSource, dataSource.Id));
            }

            return dataSources;
        }

        internal static List<HealthcareEntity> ConvertToHealthcareEntityCollection(IReadOnlyList<Legacy.HealthcareEntity> healthcareEntities)
        {
            var entityList = new List<HealthcareEntity>(healthcareEntities.Count);

            foreach (var entity in healthcareEntities)
            {
                entityList.Add(ConvertToHealthcareEntity(entity));
            }

            return entityList;
        }

        internal static AnalyzeHealthcareEntitiesResultCollection ConvertToAnalyzeHealthcareEntitiesResultCollection(Legacy.HealthcareResult results, IDictionary<string, int> idToIndexMap)
        {
            List<AnalyzeHealthcareEntitiesResult> healthcareEntititesResults = new(results.Errors.Count);

            // Read errors.
            foreach (Legacy.DocumentError error in results.Errors)
            {
                healthcareEntititesResults.Add(new AnalyzeHealthcareEntitiesResult(error.Id, ConvertToError(error.Error)));
            }

            // Read entities.
            foreach (Legacy.DocumentHealthcareEntities documentHealthcareEntities in results.Documents)
            {
                healthcareEntititesResults.Add(
                    new AnalyzeHealthcareEntitiesResult(
                        documentHealthcareEntities.Id,
                        ConvertToDocumentStatistics(documentHealthcareEntities.Statistics),
                        ConvertToHealthcareEntityCollection(documentHealthcareEntities.Entities),
                        ConvertToHealthcareEntityRelationsCollection(documentHealthcareEntities.Entities, documentHealthcareEntities.Relations),
                        default,
                        default,
                        ConvertToWarnings(documentHealthcareEntities.Warnings)));
            }

            healthcareEntititesResults = healthcareEntititesResults.OrderBy(result => idToIndexMap[result.Id]).ToList();

            return new AnalyzeHealthcareEntitiesResultCollection(healthcareEntititesResults, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        private static IList<HealthcareEntityRelation> ConvertToHealthcareEntityRelationsCollection(IReadOnlyList<Legacy.HealthcareEntity> healthcareEntities, IReadOnlyList<Legacy.HealthcareRelation> healthcareRelations)
        {
            List<HealthcareEntityRelation> result = new List<HealthcareEntityRelation>();
            foreach (var relation in healthcareRelations)
            {
                result.Add(new HealthcareEntityRelation(
                    relation.RelationType.ToString(),
                    ConvertToHealthcareEntityRelationRoleCollection(relation.Entities, healthcareEntities),
                    default));
            }
            return result;
        }

        private static IReadOnlyCollection<HealthcareEntityRelationRole> ConvertToHealthcareEntityRelationRoleCollection(IReadOnlyList<Legacy.HealthcareRelationEntity> entities, IReadOnlyList<Legacy.HealthcareEntity> healthcareEntities)
        {
            List<HealthcareEntityRelationRole> result = new List<HealthcareEntityRelationRole>();

            foreach (var entity in entities)
            {
                int refIndex = ParseLegacyHealthcareEntityIndex(entity.Ref);
                Legacy.HealthcareEntity refEntity = healthcareEntities[refIndex];

                result.Add(new HealthcareEntityRelationRole(ConvertToHealthcareEntity(refEntity), entity.Role));
            }

            return result;
        }

        private static int ParseLegacyHealthcareEntityIndex(string reference)
        {
            Match healthcareEntityMatch = s_legacyHealthcareEntityRegex.Match(reference);
            if (healthcareEntityMatch.Success)
            {
                return int.Parse(healthcareEntityMatch.Groups["entityIndex"].Value, CultureInfo.InvariantCulture);
            }

            throw new InvalidOperationException($"Failed to parse element reference: {reference}");
        }

        internal static Models.HealthcareJobStatusResult ConvertToHealthcareJobStatusResult(Legacy.HealthcareJobState legacyJobState, IDictionary<string, int> map)
        {
            var result = new Models.HealthcareJobStatusResult
            {
                NextLink = legacyJobState.NextLink,
                CreatedOn = legacyJobState.CreatedDateTime,
                LastModifiedOn = legacyJobState.LastUpdateDateTime,
                ExpiresOn = legacyJobState.ExpirationDateTime,
                Status = ConvertToTextAnalyticsOperationStatus(legacyJobState.Status)
            };

            if (result.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                result.Result = ConvertToAnalyzeHealthcareEntitiesResultCollection(legacyJobState.Results, map);
            }

            foreach (var error in legacyJobState.Errors)
            {
                result.Errors.Add(ConvertToLanguageError(error));
            }

            return result;
        }

        #endregion

        #region Long Running Operations

        private static string[] parseActionErrorTarget(string targetReference)
        {
            if (string.IsNullOrEmpty(targetReference))
            {
                throw new InvalidOperationException("Expected an error with a target field referencing an action but did not get one");
            }

            // action could be failed and the target reference is "#/tasks/keyPhraseExtractionTasks/0";
            Match targetMatch = _targetRegex.Match(targetReference);

            string[] taskNameIdPair = new string[2];
            if (targetMatch.Success && targetMatch.Groups.Count == 3)
            {
                taskNameIdPair[0] = targetMatch.Groups[1].Value;
                taskNameIdPair[1] = targetMatch.Groups[2].Value;
                return taskNameIdPair;
            }
            return null;
        }

        internal static AnalyzeActionsResult ConvertToAnalyzeActionsResult(Legacy.AnalyzeJobState jobState, IDictionary<string, int> map)
        {
            IDictionary<int, Legacy.TextAnalyticsError> keyPhraseErrors = new Dictionary<int, Legacy.TextAnalyticsError>();
            IDictionary<int, Legacy.TextAnalyticsError> entitiesRecognitionErrors = new Dictionary<int, Legacy.TextAnalyticsError>();
            IDictionary<int, Legacy.TextAnalyticsError> entitiesPiiRecognitionErrors = new Dictionary<int, Legacy.TextAnalyticsError>();
            IDictionary<int, Legacy.TextAnalyticsError> entitiesLinkingRecognitionErrors = new Dictionary<int, Legacy.TextAnalyticsError>();
            IDictionary<int, Legacy.TextAnalyticsError> analyzeSentimentErrors = new Dictionary<int, Legacy.TextAnalyticsError>();

            if (jobState.Errors.Any())
            {
                foreach (Legacy.TextAnalyticsError error in jobState.Errors)
                {
                    string[] targetPair = parseActionErrorTarget(error.Target);
                    if (targetPair == null)
                        throw new InvalidOperationException($"Invalid action/id error. \n Additional information: Error code: {error.Code} Error message: {error.Message}");

                    string taskName = targetPair[0];
                    int taskIndex = int.Parse(targetPair[1], CultureInfo.InvariantCulture);

                    if ("entityRecognitionTasks".Equals(taskName))
                    {
                        entitiesRecognitionErrors.Add(taskIndex, error);
                    }
                    else if ("entityRecognitionPiiTasks".Equals(taskName))
                    {
                        entitiesPiiRecognitionErrors.Add(taskIndex, error);
                    }
                    else if ("keyPhraseExtractionTasks".Equals(taskName))
                    {
                        keyPhraseErrors.Add(taskIndex, error);
                    }
                    else if ("entityLinkingTasks".Equals(taskName))
                    {
                        entitiesLinkingRecognitionErrors.Add(taskIndex, error);
                    }
                    else if ("sentimentAnalysisTasks".Equals(taskName))
                    {
                        analyzeSentimentErrors.Add(taskIndex, error);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Invalid task name in target reference - {taskName}. \n Additional information: Error code: {error.Code} Error message: {error.Message}");
                    }
                }
            }

            return new AnalyzeActionsResult(
                ConvertToExtractKeyPhrasesActionResults(jobState, map, keyPhraseErrors),
                ConvertToRecognizeEntitiesActionsResults(jobState, map, entitiesRecognitionErrors),
                ConvertToRecognizePiiEntitiesActionsResults(jobState, map, entitiesPiiRecognitionErrors),
                ConvertToRecognizeLinkedEntitiesActionsResults(jobState, map, entitiesLinkingRecognitionErrors),
                ConvertToAnalyzeSentimentActionsResults(jobState, map, analyzeSentimentErrors));
        }

        private static IReadOnlyCollection<AnalyzeSentimentActionResult> ConvertToAnalyzeSentimentActionsResults(Legacy.AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, Legacy.TextAnalyticsError> tasksErrors)
        {
            var collection = new List<AnalyzeSentimentActionResult>(jobState.Tasks.SentimentAnalysisTasks.Count);
            int index = 0;
            foreach (var task in jobState.Tasks.SentimentAnalysisTasks)
            {
                tasksErrors.TryGetValue(index, out Legacy.TextAnalyticsError taskError);

                if (taskError != null)
                {
                    collection.Add(new AnalyzeSentimentActionResult(task.TaskName, task.LastUpdateDateTime, ConvertToLanguageError(taskError)));
                }
                else
                {
                    collection.Add(new AnalyzeSentimentActionResult(ConvertToAnalyzeSentimentResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
                }
                index++;
            }

            return collection;
        }

        private static IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> ConvertToRecognizeLinkedEntitiesActionsResults(Legacy.AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, Legacy.TextAnalyticsError> tasksErrors)
        {
            var collection = new List<RecognizeLinkedEntitiesActionResult>(jobState.Tasks.EntityLinkingTasks.Count);
            int index = 0;
            foreach (var task in jobState.Tasks.EntityLinkingTasks)
            {
                tasksErrors.TryGetValue(index, out Legacy.TextAnalyticsError taskError);

                if (taskError != null)
                {
                    collection.Add(new RecognizeLinkedEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, ConvertToLanguageError(taskError)));
                }
                else
                {
                    collection.Add(new RecognizeLinkedEntitiesActionResult(ConvertToRecognizeLinkedEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
                }
                index++;
            }

            return collection;
        }

        private static IReadOnlyCollection<ExtractKeyPhrasesActionResult> ConvertToExtractKeyPhrasesActionResults(Legacy.AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, Legacy.TextAnalyticsError> tasksErrors)
        {
            var collection = new List<ExtractKeyPhrasesActionResult>(jobState.Tasks.KeyPhraseExtractionTasks.Count);
            int index = 0;
            foreach (var task in jobState.Tasks.KeyPhraseExtractionTasks)
            {
                tasksErrors.TryGetValue(index, out Legacy.TextAnalyticsError taskError);

                if (taskError != null)
                {
                    collection.Add(new ExtractKeyPhrasesActionResult(task.TaskName, task.LastUpdateDateTime, ConvertToLanguageError(taskError)));
                }
                else
                {
                    collection.Add(new ExtractKeyPhrasesActionResult(ConvertToExtractKeyPhrasesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
                }
                index++;
            }

            return collection;
        }

        private static IReadOnlyCollection<RecognizePiiEntitiesActionResult> ConvertToRecognizePiiEntitiesActionsResults(Legacy.AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, Legacy.TextAnalyticsError> tasksErrors)
        {
            var collection = new List<RecognizePiiEntitiesActionResult>(jobState.Tasks.EntityRecognitionPiiTasks.Count);
            int index = 0;
            foreach (var task in jobState.Tasks.EntityRecognitionPiiTasks)
            {
                tasksErrors.TryGetValue(index, out Legacy.TextAnalyticsError taskError);

                if (taskError != null)
                {
                    collection.Add(new RecognizePiiEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, ConvertToLanguageError(taskError)));
                }
                else
                {
                    collection.Add(new RecognizePiiEntitiesActionResult(ConvertToRecognizePiiEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
                }
                index++;
            }

            return collection;
        }

        private static IReadOnlyCollection<RecognizeEntitiesActionResult> ConvertToRecognizeEntitiesActionsResults(Legacy.AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, Legacy.TextAnalyticsError> tasksErrors)
        {
            var collection = new List<RecognizeEntitiesActionResult>(jobState.Tasks.EntityRecognitionTasks.Count);
            int index = 0;
            foreach (var task in jobState.Tasks.EntityRecognitionTasks)
            {
                tasksErrors.TryGetValue(index, out Legacy.TextAnalyticsError taskError);

                if (taskError != null)
                {
                    collection.Add(new RecognizeEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, ConvertToLanguageError(taskError)));
                }
                else
                {
                    collection.Add(new RecognizeEntitiesActionResult(ConvertToRecognizeEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
                }
                index++;
            }

            return collection;
        }

        internal static Models.AnalyzeTextJobStatusResult ConvertToAnalyzeTextJobStatusResult(Legacy.AnalyzeJobState legacyJobState, IDictionary<string, int> map)
        {
            var result = new Models.AnalyzeTextJobStatusResult
            {
                DisplayName = legacyJobState.DisplayName,
                NextLink = legacyJobState.NextLink,
                CreatedOn = legacyJobState.CreatedDateTime,
                LastModifiedOn = legacyJobState.LastUpdateDateTime,
                ExpiresOn = legacyJobState.ExpirationDateTime,
                AcionsSucceeded = legacyJobState.Tasks.Completed,
                AcionsInProgress = legacyJobState.Tasks.InProgress,
                ActionsFailed = legacyJobState.Tasks.Failed,
                ActionsTotal = legacyJobState.Tasks.Total,
                Status = ConvertToTextAnalyticsOperationStatus(legacyJobState.Status)
            };

            if (result.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                result.Result = ConvertToAnalyzeActionsResult(legacyJobState, map);
            }

            foreach (var error in legacyJobState.Errors)
            {
                result.Errors.Add(ConvertToLanguageError(error));
            }

            return result;
        }

        #endregion
    }
}
