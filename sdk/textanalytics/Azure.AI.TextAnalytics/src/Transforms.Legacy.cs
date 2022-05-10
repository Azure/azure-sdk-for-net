// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        internal static ClassificationCategory ConvertToClassificationCategory(Legacy.ClassificationResult legacyClassification) =>
            new ClassificationCategory(new Models.ClassificationResult(legacyClassification.Category, legacyClassification.ConfidenceScore));

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
            return new DetectedLanguage(detected.Name, detected.Iso6391Name, detected.ConfidenceScore, ConvertToWarnings(documentLanguage.Warnings));
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
                negativeScore: legacySentiment.ConfidenceScores.Negative,
                neutralScore: legacySentiment.ConfidenceScores.Neutral,
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
                analyzedSentiments.Add(new AnalyzeSentimentResult(docSentiment.Id, ConvertToDocumentStatistics(docSentiment.Statistics), ConvertToDocumentSentiment(docSentiment)));
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
                keyPhrases.Add(new ExtractKeyPhrasesResult(docKeyPhrases.Id, ConvertToDocumentStatistics(docKeyPhrases.Statistics), ConvertToKeyPhraseCollection(docKeyPhrases)));
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

        internal static ExtractKeyPhrasesResult ConvertToExtractKeyPhrasesResult(string id, Legacy.KeyPhraseResult legacyResult)
        {
            if (legacyResult.Errors.Count > 0)
            {
                var docError = default(Legacy.DocumentError);

                foreach (var error in legacyResult.Errors)
                {
                    if (docError.Id == id)
                    {
                        docError = error;
                        break;
                    }
                }

                if (docError != null)
                {
                    return new ExtractKeyPhrasesResult(id, ConvertToError(docError.Error));
                }
            }

            throw new NotImplementedException();
            //var x = new ExtractKeyPhrasesResult(id, ConvertToDocumentStatistics(legacyResult.Statistics), ConvertToKeyPhraseCollection(legacyResult.Documents))
        }

        #endregion

        #region Recognize Entities

        internal static List<CategorizedEntity> ConvertToCategorizedEntityList(IReadOnlyList<Legacy.Entity> entities)
        {
            var entityList = new List<CategorizedEntity>(entities.Count);

            foreach (var entity in entities)
            {
                entityList.Add(new CategorizedEntity(entity.Text, entity.Category, entity.Subcategory, entity.ConfidenceScore, entity.Offset, entity.Length));
            }

            return entityList;
        }

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
                recognizeEntities.Add(new RecognizeEntitiesResult(docEntities.Id, ConvertToDocumentStatistics(docEntities.Statistics), ConvertToCategorizedEntityCollection(docEntities)));
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

        #region Recognize Custom Entities

        internal static Legacy.CustomEntitiesTask ConvertToCustomEntitiesTask(RecognizeCustomEntitiesAction action)
        {
            return new Legacy.CustomEntitiesTask()
            {
                Parameters = new Legacy.Models.CustomEntitiesTaskParameters(action.ProjectName, action.DeploymentName)
                {
                    LoggingOptOut = action.DisableServiceLogs,
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.CustomEntitiesTask> ConvertFromRecognizeCustomEntitiesActionsToLegacyTasks(IReadOnlyCollection<RecognizeCustomEntitiesAction> recognizeCustomEntitiesActions)
        {
            var list = new List<Legacy.CustomEntitiesTask>(recognizeCustomEntitiesActions.Count);

            foreach (var action in recognizeCustomEntitiesActions)
            {
                list.Add(ConvertToCustomEntitiesTask(action));
            }

            return list;
        }

        internal static RecognizeCustomEntitiesResultCollection ConvertToRecognizeCustomEntitiesResultCollection(Legacy.CustomEntitiesResult results, IDictionary<string, int> idToIndexMap)
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
                recognizeEntities.Add(new RecognizeEntitiesResult(docEntities.Id, ConvertToDocumentStatistics(docEntities.Statistics), ConvertToCategorizedEntityCollection(docEntities)));
            }

            recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);
            return new RecognizeCustomEntitiesResultCollection(recognizeEntities, ConvertToBatchStatistics(results.Statistics), results.ProjectName, results.DeploymentName);
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
                recognizeEntities.Add(new RecognizePiiEntitiesResult(docEntities.Id, ConvertToDocumentStatistics(docEntities.Statistics), ConvertToPiiEntityCollection(docEntities)));
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
                recognizeEntities.Add(new RecognizeLinkedEntitiesResult(docEntities.Id, ConvertToDocumentStatistics(docEntities.Statistics), ConvertToLinkedEntityCollection(docEntities)));
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

        #region Extract Summary

        internal static Legacy.ExtractiveSummarizationTask ConvertToLegacyExtractiveSummarizationTask(ExtractSummaryAction action)
        {
            var sortBy = action.OrderBy switch
            {
                null => null,
                SummarySentencesOrder.Rank => Legacy.Models.ExtractiveSummarizationTaskParametersSortBy.Rank,
                SummarySentencesOrder.Offset => Legacy.Models.ExtractiveSummarizationTaskParametersSortBy.Rank,
                _ => throw new NotSupportedException($"The sentence sort by, { action.OrderBy }, is not supported for conversion.")
            };

            return new Legacy.ExtractiveSummarizationTask()
            {
                Parameters = new Legacy.Models.ExtractiveSummarizationTaskParameters()
                {
                    ModelVersion = action.ModelVersion,
                    StringIndexType = Constants.DefaultLegacyStringIndexType,
                    LoggingOptOut = action.DisableServiceLogs,
                    SentenceCount = action.MaxSentenceCount,
                    SortBy = sortBy
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.ExtractiveSummarizationTask> ConvertFromExtractSummaryActionsToLegacyTasks(IReadOnlyCollection<ExtractSummaryAction> extractSummaryActions)
        {
            List<Legacy.ExtractiveSummarizationTask> list = new List<Legacy.ExtractiveSummarizationTask>(extractSummaryActions.Count);

            foreach (ExtractSummaryAction action in extractSummaryActions)
            {
                list.Add(ConvertToLegacyExtractiveSummarizationTask(action));
            }

            return list;
        }

        internal static ExtractSummaryResultCollection ConvertToExtractSummaryResultCollection(Legacy.ExtractiveSummarizationResult results, IDictionary<string, int> idToIndexMap)
        {
            var extractedSummaries = new List<ExtractSummaryResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                extractedSummaries.Add(new ExtractSummaryResult(error.Id, ConvertToError(error.Error)));
            }

            //Read document summaries
            foreach (var docSummary in results.Documents)
            {
                extractedSummaries.Add(new ExtractSummaryResult(docSummary.Id, ConvertToDocumentStatistics(docSummary.Statistics), ConvertToSummarySentenceCollection(docSummary)));
            }

            extractedSummaries = SortHeterogeneousCollection(extractedSummaries, idToIndexMap);
            return new ExtractSummaryResultCollection(extractedSummaries, ConvertToBatchStatistics(results.Statistics), results.ModelVersion);
        }

        internal static SummarySentenceCollection ConvertToSummarySentenceCollection(Legacy.ExtractedDocumentSummary documentSummary)
        {
            var sentences = new List<SummarySentence>(documentSummary.Sentences.Count);

            foreach (var sentence in documentSummary.Sentences)
            {
                sentences.Add(new SummarySentence(new Models.ExtractedSummarySentence(sentence.Text, sentence.RankScore, sentence.Offset, sentence.Length)));
            }

            return new SummarySentenceCollection(sentences, ConvertToWarnings(documentSummary.Warnings));
        }

        #endregion

        #region Multi-Category Classify

        internal static Legacy.CustomSingleClassificationTask ConvertToLegacyCustomSingleClassificationTask(SingleCategoryClassifyAction action)
        {
            return new Legacy.CustomSingleClassificationTask()
            {
                Parameters = new Legacy.Models.CustomSingleClassificationTaskParameters(action.ProjectName, action.DeploymentName)
                {
                    LoggingOptOut = action.DisableServiceLogs,
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.CustomMultiClassificationTask> ConvertFromMultiCategoryClassifyActionsToLegacyTasks(IReadOnlyCollection<MultiCategoryClassifyAction> MultiCategoryClassifyActions)
        {
            List<Legacy.CustomMultiClassificationTask> list = new List<Legacy.CustomMultiClassificationTask>(MultiCategoryClassifyActions.Count);

            foreach (MultiCategoryClassifyAction action in MultiCategoryClassifyActions)
            {
                list.Add(ConvertToLegacyCustomMultiClassificationTask(action));
            }

            return list;
        }

        internal static ClassificationCategoryCollection ConvertToClassificationCategoryCollection(Legacy.MultiClassificationDocument legacyDocument)
        {
            var results = new List<ClassificationCategory>(legacyDocument.Classifications.Count);

            foreach (var classification in legacyDocument.Classifications)
            {
                results.Add(ConvertToClassificationCategory(classification));
            }

            return new ClassificationCategoryCollection(results, ConvertToWarnings(legacyDocument.Warnings));
        }

        internal static MultiCategoryClassifyResultCollection ConvertToMultiCategoryClassifyResultCollection(Legacy.CustomMultiClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            var classifiedCustomCategoryResults = new List<MultiCategoryClassifyResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                classifiedCustomCategoryResults.Add(new MultiCategoryClassifyResult(error.Id, ConvertToError(error.Error)));
            }

            //Read classifications
            foreach (var classificationsDocument in results.Documents)
            {
                classifiedCustomCategoryResults.Add(new MultiCategoryClassifyResult(
                    classificationsDocument.Id,
                    ConvertToDocumentStatistics(classificationsDocument.Statistics),
                    ConvertToClassificationCategoryCollection(classificationsDocument),
                    ConvertToWarnings(classificationsDocument.Warnings)));
            }

            classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);
            return new MultiCategoryClassifyResultCollection(classifiedCustomCategoryResults, ConvertToBatchStatistics(results.Statistics), results.ProjectName, results.DeploymentName);
        }

        #endregion

        #region Single Category Classify

        internal static Legacy.CustomMultiClassificationTask ConvertToLegacyCustomMultiClassificationTask(MultiCategoryClassifyAction action)
        {
            return new Legacy.CustomMultiClassificationTask()
            {
                Parameters = new Legacy.Models.CustomMultiClassificationTaskParameters(action.ProjectName, action.DeploymentName)
                {
                    LoggingOptOut = action.DisableServiceLogs,
                },
                TaskName = action.ActionName
            };
        }

        internal static IList<Legacy.CustomSingleClassificationTask> ConvertFromSingleCategoryClassifyActionsToLegacyTasks(IReadOnlyCollection<SingleCategoryClassifyAction> singleCategoryClassifyActions)
        {
            List<Legacy.CustomSingleClassificationTask> list = new List<Legacy.CustomSingleClassificationTask>(singleCategoryClassifyActions.Count);

            foreach (SingleCategoryClassifyAction action in singleCategoryClassifyActions)
            {
                list.Add(ConvertToLegacyCustomSingleClassificationTask(action));
            }

            return list;
        }

        internal static SingleCategoryClassifyResultCollection ConvertToSingleCategoryClassifyResultCollection(Legacy.CustomSingleClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            var classifiedCustomCategoryResults = new List<SingleCategoryClassifyResult>(results.Errors.Count);

            //Read errors
            foreach (var error in results.Errors)
            {
                classifiedCustomCategoryResults.Add(new SingleCategoryClassifyResult(error.Id, ConvertToError(error.Error)));
            }

            //Read classifications
            foreach (var classificationDocument in results.Documents)
            {
                classifiedCustomCategoryResults.Add(new SingleCategoryClassifyResult(
                    classificationDocument.Id,
                    ConvertToDocumentStatistics(classificationDocument.Statistics),
                    ConvertToClassificationCategory(classificationDocument.Classification),
                    ConvertToWarnings(classificationDocument.Warnings)));
            }

            classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);
            return new SingleCategoryClassifyResultCollection(classifiedCustomCategoryResults, ConvertToBatchStatistics(results.Statistics), results.ProjectName, results.DeploymentName);
        }

        #endregion

        #region Long Running Operations

        internal static AnalyzeActionsResult ConvertToAnalyzeActionsResult(Legacy.AnalyzeJobState jobState, IDictionary<string, int> map)
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

            foreach (var task in jobState.Tasks.KeyPhraseExtractionTasks)
            {
                keyPhrases.Add(new ExtractKeyPhrasesActionResult(ConvertToExtractKeyPhrasesResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.EntityRecognitionTasks)
            {
                entitiesRecognition.Add(new RecognizeEntitiesActionResult(ConvertToRecognizeEntitiesResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.EntityRecognitionPiiTasks)
            {
                entitiesPiiRecognition.Add(new RecognizePiiEntitiesActionResult(ConvertToRecognizePiiEntitiesResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.EntityLinkingTasks)
            {
                entitiesLinkingRecognition.Add(new RecognizeLinkedEntitiesActionResult(ConvertToRecognizeLinkedEntitiesResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.SentimentAnalysisTasks)
            {
                analyzeSentiment.Add(new AnalyzeSentimentActionResult(ConvertToAnalyzeSentimentResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.ExtractiveSummarizationTasks)
            {
                extractSummary.Add(new ExtractSummaryActionResult(ConvertToExtractSummaryResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.CustomEntityRecognitionTasks)
            {
                customEntitiesRecognition.Add(new RecognizeCustomEntitiesActionResult(ConvertToRecognizeCustomEntitiesResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.CustomSingleClassificationTasks)
            {
                singleCategoryClassify.Add(new SingleCategoryClassifyActionResult(ConvertToSingleCategoryClassifyResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
            }

            foreach (var task in jobState.Tasks.CustomMultiClassificationTasks)
            {
                multiCategoryClassify.Add(new MultiCategoryClassifyActionResult(ConvertToMultiCategoryClassifyResultCollection(task.Results, map), task.TaskName, task.LastUpdateDateTime));
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

        internal static Models.AnalyzeTextJobStatusResult ConvertToAnalyzeTextJobStatusResult(Legacy.AnalyzeJobState legacyJobState, IDictionary<string, int> map)
        {
            var result = new Models.AnalyzeTextJobStatusResult
            {
                DisplayName = legacyJobState.DisplayName,
                NextLink = legacyJobState.NextLink,
                CreatedOn = legacyJobState.CreatedDateTime,
                LatModifiedOn = legacyJobState.LastUpdateDateTime,
                ExpiresOn = legacyJobState.ExpirationDateTime,
                AcionsSucceeded = legacyJobState.Tasks.Completed,
                AcionsInProgress = legacyJobState.Tasks.InProgress,
                ActionsFailed = legacyJobState.Tasks.Failed,
                ActionsTotal = legacyJobState.Tasks.Total,
                Result = ConvertToAnalyzeActionsResult(legacyJobState, map)
            };

            foreach (var error in legacyJobState.Errors)
            {
                result.Errors.Add(ConvertToLanguageError(error));
            }

            return result;
        }

        #endregion
    }
}
