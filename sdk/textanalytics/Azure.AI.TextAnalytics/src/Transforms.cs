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
    internal static class Transforms
    {
        #region Needs Review

        //
        // REGION: Common
        //
        internal static TextAnalyticsError ConvertToError(TextAnalyticsErrorInternal error) => throw new NotImplementedException("I think the TextAnalyticsInternalType is no longer used.");
        internal static List<TextAnalyticsError> ConvertToErrors(IReadOnlyList<TextAnalyticsErrorInternal> internalErrors) => throw new NotImplementedException("I think the TextAnalyticsInternalType is no longer used.");

        #endregion

        #region Common

        public static readonly Regex _targetRegex = new Regex("#/tasks/(keyPhraseExtractionTasks|entityRecognitionPiiTasks|entityRecognitionTasks|entityLinkingTasks|sentimentAnalysisTasks|extractiveSummarizationTasks|customSingleClassificationTasks|customMultiClassificationTasks|customEntityRecognitionTasks)/(\\d+)", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        internal static TextAnalyticsError ConvertToError(Legacy.TextAnalyticsError error)
        {
            var innerError = error.Innererror;

            return (innerError != null)
                ? new TextAnalyticsError(innerError.Code.ToString(), innerError.Message, innerError.Target)
                : new TextAnalyticsError(error.Code.ToString(), error.Message, error.Target);
        }

        internal static TextAnalyticsError ConvertToError(DocumentError error)
        {
            var innerError = error.Error.Innererror;

            return (innerError != null)
                ? new TextAnalyticsError(innerError.Code.ToString(), innerError.Message, innerError.Target)
                : new TextAnalyticsError(error.Error.Code.ToString(), error.Error.Message, error.Error.Target);
        }

        internal static List<TextAnalyticsError> ConvertToErrors(IReadOnlyList<Legacy.TextAnalyticsError> internalErrors)
        {
            var errors = new List<TextAnalyticsError>();

            if (internalErrors == null)
            {
                return errors;
            }

            foreach (var error in internalErrors)
            {
                errors.Add(ConvertToError(error));
            }

            return errors;
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

        #endregion

        #region DetectLanguage

        internal static DetectedLanguage ConvertToDetectedLanguage(Legacy.DocumentLanguage documentLanguage)
        {
            var detected = documentLanguage.DetectedLanguage;
            return new DetectedLanguage(detected.Name, detected.Iso6391Name, detected.ConfidenceScore, ConvertToWarnings(documentLanguage.Warnings));
        }

        // CHANGED: added overload for New Swagger
        internal static DetectedLanguage ConvertToDetectedLanguage(LanguageDetectionDocumentResult documentLanguage)
        {
            List<TextAnalyticsWarning> warnings = new List<TextAnalyticsWarning>();
            foreach (var warning in documentLanguage.Warnings)
            {
                warnings.Add(new TextAnalyticsWarning(warning));
            }
            return new DetectedLanguage(documentLanguage.DetectedLanguage, warnings);
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

        // CHANGED: added overload for New Swagger
        internal static DetectLanguageResultCollection ConvertToDetectLanguageResultCollection(LanguageDetectionTaskResult results, IDictionary<string, int> idToIndexMap)
        {
            var detectedLanguages = new List<DetectLanguageResult>(results.Results.Errors.Count);

            //Read errors
            foreach (DocumentError error in results.Results.Errors)
            {
                detectedLanguages.Add(new DetectLanguageResult(error.Id, ConvertToError(error)));
            }

            //Read languages
            foreach (var language in results.Results.Documents)
            {
                detectedLanguages.Add(new DetectLanguageResult(language.Id, language.Statistics ?? default, ConvertToDetectedLanguage(language)));
            }

            detectedLanguages = SortHeterogeneousCollection(detectedLanguages, idToIndexMap);

            return new DetectLanguageResultCollection(detectedLanguages, results.Results.Statistics, results.Results.ModelVersion);
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
                _ => throw new NotSupportedException($"The document sentiment, { sentiment }, is not supported for conversion.")
            };

        //TODO:  Check this conversion.  Seems to match: https://github.com/Azure/azure-sdk-for-net/blob/Azure.AI.TextAnalytics_5.2.0-beta.2/sdk/textanalytics/Azure.AI.TextAnalytics/src/DocumentSentiment.cs#L56
        internal static List<SentenceOpinion> ConvertToSentenceOpinions(IReadOnlyList<Legacy.SentenceAssessment> assessments)
        {
            var assessmentList = new List<AssessmentSentiment>(assessments.Count);
            var targetList = new List<TargetSentiment>(assessments.Count);

            foreach (var assessment in assessments)
            {
                targetList.Add(new TargetSentiment(
                    ConvertToTextSentiment(assessment.Sentiment),
                    assessment.Text,
                    assessment.ConfidenceScores.Positive,
                    assessment.ConfidenceScores.Negative,
                    assessment.Offset,
                    assessment.Length));

                assessmentList.Add(new AssessmentSentiment(
                    ConvertToTextSentiment(assessment.Sentiment),
                    assessment.ConfidenceScores.Positive,
                    assessment.ConfidenceScores.Negative,
                    assessment.Text,
                    assessment.IsNegated,
                    assessment.Offset,
                    assessment.Length));
            }

            var opinions = new List<SentenceOpinion>(targetList.Count);

            foreach (var target in targetList)
            {
                opinions.Add(new SentenceOpinion(target, assessmentList));
            }

            return opinions;
        }

        //TODO: Check this conversion.  The assessment conversion is odd, but seems to match the legacy version.
        internal static List<SentenceSentiment> ConvertToSentenceSentiments(IReadOnlyList<Legacy.SentenceSentiment> legacySentiments)
        {
            var sentences = new List<SentenceSentiment>(legacySentiments.Count);

            foreach (var sentiment in legacySentiments)
            {
                sentences.Add(new SentenceSentiment(
                    ConvertToTextSentiment(sentiment.Sentiment),
                    sentiment.Text,
                    sentiment.ConfidenceScores.Positive,
                    sentiment.ConfidenceScores.Neutral,
                    sentiment.ConfidenceScores.Negative,
                    sentiment.Offset,
                    sentiment.Length,
                    ConvertToSentenceOpinions(sentiment.Assessments)));
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

        internal static AnalyzeSentimentResultCollection ConvertToAnalyzeSentimentResultCollection(SentimentResponse results, IDictionary<string, int> idToIndexMap)
        {
            //var analyzedSentiments = new List<AnalyzeSentimentResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    analyzedSentiments.Add(new AnalyzeSentimentResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read sentiments
            //foreach (DocumentSentimentInternal docSentiment in results.Documents)
            //{
            //    analyzedSentiments.Add(new AnalyzeSentimentResult(docSentiment.Id, docSentiment.Statistics ?? default, new DocumentSentiment(docSentiment)));
            //}

            //analyzedSentiments = SortHeterogeneousCollection(analyzedSentiments, idToIndexMap);

            //return new AnalyzeSentimentResultCollection(analyzedSentiments, results.Statistics, results.ModelVersion);

            throw new NotImplementedException();
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

        internal static ExtractKeyPhrasesResultCollection ConvertToExtractKeyPhrasesResultCollection(KeyPhraseResult results, IDictionary<string, int> idToIndexMap)
        {
            //var keyPhrases = new List<ExtractKeyPhrasesResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    keyPhrases.Add(new ExtractKeyPhrasesResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read Key phrases
            //foreach (DocumentKeyPhrases docKeyPhrases in results.Documents)
            //{
            //    keyPhrases.Add(new ExtractKeyPhrasesResult(docKeyPhrases.Id, docKeyPhrases.Statistics ?? default, ConvertToKeyPhraseCollection(docKeyPhrases)));
            //}

            //keyPhrases = SortHeterogeneousCollection(keyPhrases, idToIndexMap);

            //return new ExtractKeyPhrasesResultCollection(keyPhrases, results.Statistics, results.ModelVersion);

            throw new NotImplementedException();
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

        internal static List<CategorizedEntity> ConvertToCategorizedEntityList(IList<Entity> entities)
        {
            var entityList = new List<CategorizedEntity>(entities.Count);

            foreach (var entity in entities)
            {
                entityList.Add(new CategorizedEntity(entity));
            }

            return entityList;
        }

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

        internal static CategorizedEntityCollection ConvertToCategorizedEntityCollection(Legacy.DocumentEntities documentEntities) =>
            new CategorizedEntityCollection(ConvertToCategorizedEntityList(documentEntities.Entities), ConvertToWarnings(documentEntities.Warnings));

        internal static LinkedEntityCollection ConvertToLinkedEntityCollection(Legacy.DocumentLinkedEntities documentEntities) =>
            new LinkedEntityCollection(ConvertToLinkedEntityList(documentEntities.Entities), ConvertToWarnings(documentEntities.Warnings));

        // CHANGED: added overload for New Swagger
        internal static CategorizedEntityCollection ConvertToCategorizedEntityCollection(EntitiesResultDocumentsItem documentEntities)
        {
            List<TextAnalyticsWarning> warnings = new List<TextAnalyticsWarning>();
            foreach (var warning in documentEntities.Warnings)
            {
                warnings.Add(new TextAnalyticsWarning(warning));
            }
            return new CategorizedEntityCollection(ConvertToCategorizedEntityList(documentEntities.Entities), warnings);
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

        internal static RecognizeEntitiesResultCollection ConvertToRecognizeEntitiesResultCollection(EntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            //var recognizeEntities = new List<RecognizeEntitiesResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read document entities
            //foreach (DocumentEntities docEntities in results.Documents)
            //{
            //    recognizeEntities.Add(new RecognizeEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToCategorizedEntityCollection(docEntities)));
            //}

            //recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);

            //return new RecognizeEntitiesResultCollection(recognizeEntities, results.Statistics, results.ModelVersion);
            throw new NotImplementedException();
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
        internal static RecognizeCustomEntitiesResultCollection ConvertToRecognizeCustomEntitiesResultCollection(CustomEntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            //var recognizeEntities = new List<RecognizeEntitiesResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    recognizeEntities.Add(new RecognizeEntitiesResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read document entities
            //foreach (DocumentEntities docEntities in results.Documents)
            //{
            //    recognizeEntities.Add(new RecognizeEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToCategorizedEntityCollection(docEntities)));
            //}

            //recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);

            //return new RecognizeCustomEntitiesResultCollection(recognizeEntities, results.Statistics, results.ProjectName, results.DeploymentName);

            throw new NotImplementedException();
        }

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

        internal static List<PiiEntity> ConvertToPiiEntityList(List<Entity> entities)
        {
            var entityList = new List<PiiEntity>(entities.Count);

            foreach (var entity in entities)
            {
                entityList.Add(new PiiEntity(entity));
            }

            return entityList;
        }

        // CHANGED: added overload for New Swagger
        internal static PiiEntityCollection ConvertToPiiEntityCollection(PiiResultDocumentsItem piiResult)
        {
            //List<TextAnalyticsWarning> warnings = new List<TextAnalyticsWarning>();
            //foreach (var warning in documentLanguage.Warnings)
            //{
            //    warnings.Add(new TextAnalyticsWarning(warning));
            //}
            //return new DetectedLanguage(documentLanguage.DetectedLanguage, warnings);

            throw new NotImplementedException();
        }

        internal static RecognizePiiEntitiesResultCollection ConvertToRecognizePiiEntitiesResultCollection(PiiEntitiesResult results, IDictionary<string, int> idToIndexMap)
        {
            //var recognizeEntities = new List<RecognizePiiEntitiesResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    recognizeEntities.Add(new RecognizePiiEntitiesResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read document entities
            //foreach (PiiDocumentEntities docEntities in results.Documents)
            //{
            //    recognizeEntities.Add(new RecognizePiiEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToPiiEntityCollection(docEntities)));
            //}

            //recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);

            //return new RecognizePiiEntitiesResultCollection(recognizeEntities, results.Statistics, results.ModelVersion);

            throw new NotImplementedException();
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
                parameters.PiiCategories = new List<Legacy.PiiEntityCategory>(action.CategoriesFilter.Count);

                foreach (var category in action.CategoriesFilter)
                {
                    parameters.PiiCategories.Add(new Legacy.PiiEntityCategory(category.ToString()));
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

        //internal static LinkedEntityCollection ConvertToLinkedEntityCollection(DocumentLinkedEntities documentEntities)
        //{
        //    return new LinkedEntityCollection(documentEntities.Entities.ToList(), ConvertToWarnings(documentEntities.Warnings));
        //}

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

        internal static RecognizeLinkedEntitiesResultCollection ConvertToRecognizeLinkedEntitiesResultCollection(EntityLinkingResult results, IDictionary<string, int> idToIndexMap)
        {
            //var recognizeEntities = new List<RecognizeLinkedEntitiesResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    recognizeEntities.Add(new RecognizeLinkedEntitiesResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read document linked entities
            //foreach (DocumentLinkedEntities docEntities in results.Documents)
            //{
            //    recognizeEntities.Add(new RecognizeLinkedEntitiesResult(docEntities.Id, docEntities.Statistics ?? default, ConvertToLinkedEntityCollection(docEntities)));
            //}

            //recognizeEntities = SortHeterogeneousCollection(recognizeEntities, idToIndexMap);

            //return new RecognizeLinkedEntitiesResultCollection(recognizeEntities, results.Statistics, results.ModelVersion);

            throw new NotImplementedException();
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

        internal static List<HealthcareEntity> ConvertToHealthcareEntityCollection(IEnumerable<HealthcareEntityInternal> healthcareEntities)
        {
            return healthcareEntities.Select((entity) => new HealthcareEntity(entity)).ToList();
        }

        internal static AnalyzeHealthcareEntitiesResultCollection ConvertToAnalyzeHealthcareEntitiesResultCollection(HealthcareResult results, IDictionary<string, int> idToIndexMap)
        {
            //var healthcareEntititesResults = new List<AnalyzeHealthcareEntitiesResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    healthcareEntititesResults.Add(new AnalyzeHealthcareEntitiesResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read entities
            //foreach (DocumentHealthcareEntitiesInternal documentHealthcareEntities in results.Documents)
            //{
            //    healthcareEntititesResults.Add(new AnalyzeHealthcareEntitiesResult(
            //        documentHealthcareEntities.Id,
            //        documentHealthcareEntities.Statistics ?? default,
            //        ConvertToHealthcareEntityCollection(documentHealthcareEntities.Entities),
            //        ConvertToHealthcareEntityRelationsCollection(documentHealthcareEntities.Entities, documentHealthcareEntities.Relations),
            //        ConvertToWarnings(documentHealthcareEntities.Warnings)));
            //}

            //healthcareEntititesResults = healthcareEntititesResults.OrderBy(result => idToIndexMap[result.Id]).ToList();

            //return new AnalyzeHealthcareEntitiesResultCollection(healthcareEntititesResults, results.Statistics, results.ModelVersion);

            throw new NotImplementedException();
        }

        private static IList<HealthcareEntityRelation> ConvertToHealthcareEntityRelationsCollection(IReadOnlyList<HealthcareEntityInternal> healthcareEntities, IReadOnlyList<HealthcareRelationInternal> healthcareRelations)
        {
            //List<HealthcareEntityRelation> result = new List<HealthcareEntityRelation>();
            //foreach (HealthcareRelationInternal relation in healthcareRelations)
            //{
            //    result.Add(new HealthcareEntityRelation(relation.RelationType, ConvertToHealthcareEntityRelationRoleCollection(relation.Entities, healthcareEntities)));
            //}
            //return result;

            throw new NotImplementedException();
        }

        private static IReadOnlyCollection<HealthcareEntityRelationRole> ConvertToHealthcareEntityRelationRoleCollection(IReadOnlyList<HealthcareRelationEntity> entities, IReadOnlyList<HealthcareEntityInternal> healthcareEntities)
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

        #endregion

        #region Extract Summary

        internal static List<SummarySentence> ConvertToSummarySentenceList(List<ExtractedSummarySentence> sentences)
            => sentences.Select((sentence) => new SummarySentence(sentence)).ToList();

        //internal static SummarySentenceCollection ConvertToSummarySentenceCollection(ExtractedDocumentSummary documentSummary)
        //{
        //    return new SummarySentenceCollection(ConvertToSummarySentenceList(documentSummary.Sentences.ToList()), ConvertToWarnings(documentSummary.Warnings));
        //}

        internal static ExtractSummaryResultCollection ConvertToExtractSummaryResultCollection(ExtractiveSummarizationResult results, IDictionary<string, int> idToIndexMap)
        {
            //var extractedSummaries = new List<ExtractSummaryResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    extractedSummaries.Add(new ExtractSummaryResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read document summaries
            //foreach (ExtractedDocumentSummary docSummary in results.Documents)
            //{
            //    extractedSummaries.Add(new ExtractSummaryResult(docSummary.Id, docSummary.Statistics ?? default, ConvertToSummarySentenceCollection(docSummary)));
            //}

            //extractedSummaries = SortHeterogeneousCollection(extractedSummaries, idToIndexMap);

            //return new ExtractSummaryResultCollection(extractedSummaries, results.Statistics, results.ModelVersion);

            throw new NotImplementedException();
        }

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

        #endregion

        #region Multi-Category Classify
        internal static List<ClassificationCategory> ConvertToClassificationCategoryList(List<ClassificationResult> classifications)
            => classifications.Select((classification) => new ClassificationCategory(classification)).ToList();

        //internal static ClassificationCategoryCollection ConvertToClassificationCategoryCollection(MultiClassificationDocument extractedClassificationsDocuments)
        //{
        //    return new ClassificationCategoryCollection(ConvertToClassificationCategoryList(extractedClassificationsDocuments.Classifications.ToList()), ConvertToWarnings(extractedClassificationsDocuments.Warnings));
        //}

        internal static MultiCategoryClassifyResultCollection ConvertToMultiCategoryClassifyResultCollection(CustomMultiLabelClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            //var classifiedCustomCategoryResults = new List<MultiCategoryClassifyResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    classifiedCustomCategoryResults.Add(new MultiCategoryClassifyResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read classifications
            //foreach (MultiClassificationDocument classificationsDocument in results.Documents)
            //{
            //    classifiedCustomCategoryResults.Add(new MultiCategoryClassifyResult(classificationsDocument.Id, classificationsDocument.Statistics ?? default, ConvertToClassificationCategoryCollection(classificationsDocument), ConvertToWarnings(classificationsDocument.Warnings)));
            //}

            //classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);

            //return new MultiCategoryClassifyResultCollection(classifiedCustomCategoryResults, results.Statistics, results.ProjectName, results.DeploymentName);

            throw new NotImplementedException();
        }

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

        #endregion

        #region Single Category Classify
        internal static SingleCategoryClassifyResultCollection ConvertToSingleCategoryClassifyResultCollection(CustomSingleLabelClassificationResult results, IDictionary<string, int> idToIndexMap)
        {
            //var classifiedCustomCategoryResults = new List<SingleCategoryClassifyResult>(results.Errors.Count);

            ////Read errors
            //foreach (DocumentError error in results.Errors)
            //{
            //    classifiedCustomCategoryResults.Add(new SingleCategoryClassifyResult(error.Id, ConvertToError(error.Error)));
            //}

            ////Read classifications
            //foreach (SingleClassificationDocument classificationDocument in results.Documents)
            //{
            //    classifiedCustomCategoryResults.Add(new SingleCategoryClassifyResult(classificationDocument.Id, classificationDocument.Statistics ?? default, new ClassificationCategory(classificationDocument), ConvertToWarnings(classificationDocument.Warnings)));
            //}

            //classifiedCustomCategoryResults = SortHeterogeneousCollection(classifiedCustomCategoryResults, idToIndexMap);

            //return new SingleCategoryClassifyResultCollection(classifiedCustomCategoryResults, results.Statistics, results.ProjectName, results.DeploymentName);

            throw new NotImplementedException();
        }

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

        #endregion

        #region Analyze Operation

        //internal static PiiTask ConvertToPiiTask(RecognizePiiEntitiesAction action)
        //{
        //    var parameters = new PiiTaskParameters()
        //    {
        //        Domain = action.DomainFilter.GetString() ?? (PiiTaskParametersDomain?)null,
        //        ModelVersion = action.ModelVersion,
        //        StringIndexType = Constants.DefaultStringIndexType,
        //        LoggingOptOut = action.DisableServiceLogs
        //    };

        //    if (action.CategoriesFilter.Count > 0)
        //    {
        //        parameters.PiiCategories = action.CategoriesFilter;
        //    }

        //    return new PiiTask()
        //    {
        //        Parameters = parameters,
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static EntityLinkingTask ConvertToLinkedEntitiesTask(RecognizeLinkedEntitiesAction action)
        //{
        //    return new EntityLinkingTask()
        //    {
        //        Parameters = new EntityLinkingTaskParameters()
        //        {
        //            ModelVersion = action.ModelVersion,
        //            StringIndexType = Constants.DefaultStringIndexType,
        //            LoggingOptOut = action.DisableServiceLogs
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static EntitiesTask ConvertToEntitiesTask(RecognizeEntitiesAction action)
        //{
        //    return new EntitiesTask()
        //    {
        //        Parameters = new EntitiesTaskParameters()
        //        {
        //            ModelVersion = action.ModelVersion,
        //            StringIndexType = Constants.DefaultStringIndexType,
        //            LoggingOptOut = action.DisableServiceLogs
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static KeyPhrasesTask ConvertToKeyPhrasesTask(ExtractKeyPhrasesAction action)
        //{
        //    return new KeyPhrasesTask()
        //    {
        //        Parameters = new KeyPhrasesTaskParameters()
        //        {
        //            ModelVersion = action.ModelVersion,
        //            LoggingOptOut = action.DisableServiceLogs
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static SentimentAnalysisTask ConvertToSentimentAnalysisTask(AnalyzeSentimentAction action)
        //{
        //    return new SentimentAnalysisTask()
        //    {
        //        Parameters = new SentimentAnalysisTaskParameters()
        //        {
        //            ModelVersion = action.ModelVersion,
        //            StringIndexType = Constants.DefaultStringIndexType,
        //            LoggingOptOut = action.DisableServiceLogs,
        //            OpinionMining = action.IncludeOpinionMining
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static ExtractiveSummarizationTask ConvertToExtractiveSummarizationTask(ExtractSummaryAction action)
        //{
        //    return new ExtractiveSummarizationTask()
        //    {
        //        Parameters = new ExtractiveSummarizationTaskParameters()
        //        {
        //            ModelVersion = action.ModelVersion,
        //            StringIndexType = Constants.DefaultStringIndexType,
        //            LoggingOptOut = action.DisableServiceLogs,
        //            SentenceCount = action.MaxSentenceCount,
        //            SortBy = action.OrderBy
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static CustomEntitiesTask ConvertToCustomEntitiesTask(RecognizeCustomEntitiesAction action)
        //{
        //    return new CustomEntitiesTask()
        //    {
        //        Parameters = new CustomEntitiesTaskParameters(action.ProjectName, action.DeploymentName)
        //        {
        //            LoggingOptOut = action.DisableServiceLogs,
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static CustomSingleClassificationTask ConvertToCustomSingleClassificationTask(SingleCategoryClassifyAction action)
        //{
        //    return new CustomSingleClassificationTask()
        //    {
        //        Parameters = new CustomSingleClassificationTaskParameters(action.ProjectName, action.DeploymentName)
        //        {
        //            LoggingOptOut = action.DisableServiceLogs,
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static CustomMultiClassificationTask ConvertToCustomMultiClassificationTask(MultiCategoryClassifyAction action)
        //{
        //    return new CustomMultiClassificationTask()
        //    {
        //        Parameters = new CustomMultiClassificationTaskParameters(action.ProjectName, action.DeploymentName)
        //        {
        //            LoggingOptOut = action.DisableServiceLogs,
        //        },
        //        TaskName = action.ActionName
        //    };
        //}

        //internal static IList<EntityLinkingTask> ConvertFromRecognizeLinkedEntitiesActionsToTasks(IReadOnlyCollection<RecognizeLinkedEntitiesAction> recognizeLinkedEntitiesActions)
        //{
        //    List<EntityLinkingTask> list = new List<EntityLinkingTask>(recognizeLinkedEntitiesActions.Count);

        //    foreach (RecognizeLinkedEntitiesAction action in recognizeLinkedEntitiesActions)
        //    {
        //        list.Add(ConvertToLinkedEntitiesTask(action));
        //    }

        //    return list;
        //}

        //internal static IList<EntitiesTask> ConvertFromRecognizeEntitiesActionsToTasks(IReadOnlyCollection<RecognizeEntitiesAction> recognizeEntitiesActions)
        //{
        //    List<EntitiesTask> list = new List<EntitiesTask>(recognizeEntitiesActions.Count);

        //    foreach (RecognizeEntitiesAction action in recognizeEntitiesActions)
        //    {
        //        list.Add(ConvertToEntitiesTask(action));
        //    }

        //    return list;
        //}

        //internal static IList<KeyPhrasesTask> ConvertFromExtractKeyPhrasesActionsToTasks(IReadOnlyCollection<ExtractKeyPhrasesAction> extractKeyPhrasesActions)
        //{
        //    List<KeyPhrasesTask> list = new List<KeyPhrasesTask>(extractKeyPhrasesActions.Count);

        //    foreach (ExtractKeyPhrasesAction action in extractKeyPhrasesActions)
        //    {
        //        list.Add(ConvertToKeyPhrasesTask(action));
        //    }

        //    return list;
        //}

        //internal static IList<PiiTask> ConvertFromRecognizePiiEntitiesActionsToTasks(IReadOnlyCollection<RecognizePiiEntitiesAction> recognizePiiEntitiesActions)
        //{
        //    List <PiiTask> list = new List<PiiTask>(recognizePiiEntitiesActions.Count);

        //    foreach (RecognizePiiEntitiesAction action in recognizePiiEntitiesActions)
        //    {
        //        list.Add(ConvertToPiiTask(action));
        //    }

        //    return list;
        //}

        //internal static IList<SentimentAnalysisTask> ConvertFromAnalyzeSentimentActionsToTasks(IReadOnlyCollection<AnalyzeSentimentAction> analyzeSentimentActions)
        //{
        //    List<SentimentAnalysisTask> list = new List<SentimentAnalysisTask>(analyzeSentimentActions.Count);

        //    foreach (AnalyzeSentimentAction action in analyzeSentimentActions)
        //    {
        //        list.Add(ConvertToSentimentAnalysisTask(action));
        //    }

        //    return list;
        //}

        //internal static IList<ExtractiveSummarizationTask> ConvertFromExtractSummaryActionsToTasks(IReadOnlyCollection<ExtractSummaryAction> extractSummaryActions)
        //{
        //    List<ExtractiveSummarizationTask> list = new List<ExtractiveSummarizationTask>(extractSummaryActions.Count);

        //    foreach (ExtractSummaryAction action in extractSummaryActions)
        //    {
        //        list.Add(ConvertToExtractiveSummarizationTask(action));
        //    }

        //    return list;
        //}
        //internal static IList<CustomSingleClassificationTask> ConvertFromSingleCategoryClassifyActionsToTasks(IReadOnlyCollection<SingleCategoryClassifyAction> singleCategoryClassifyActions)
        //{
        //    List<CustomSingleClassificationTask> list = new List<CustomSingleClassificationTask>(singleCategoryClassifyActions.Count);

        //    foreach (SingleCategoryClassifyAction action in singleCategoryClassifyActions)
        //    {
        //        list.Add(ConvertToCustomSingleClassificationTask(action));
        //    }

        //    return list;
        //}

        //internal static IList<CustomMultiClassificationTask> ConvertFromMultiCategoryClassifyActionsToTasks(IReadOnlyCollection<MultiCategoryClassifyAction> MultiCategoryClassifyActions)
        //{
        //    List<CustomMultiClassificationTask> list = new List<CustomMultiClassificationTask>(MultiCategoryClassifyActions.Count);

        //    foreach (MultiCategoryClassifyAction action in MultiCategoryClassifyActions)
        //    {
        //        list.Add(ConvertToCustomMultiClassificationTask(action));
        //    }

        //    return list;
        //}
        //internal static IList<CustomEntitiesTask> ConvertFromRecognizeCustomEntitiesActionsToTasks(IReadOnlyCollection<RecognizeCustomEntitiesAction> recognizeCustomEntitiesActions)
        //{
        //    var list = new List<CustomEntitiesTask>(recognizeCustomEntitiesActions.Count);

        //    foreach (var action in recognizeCustomEntitiesActions)
        //    {
        //        list.Add(ConvertToCustomEntitiesTask(action));
        //    }

        //    return list;
        //}

        //private static string[] parseActionErrorTarget(string targetReference)
        //{
        //    if (string.IsNullOrEmpty(targetReference))
        //    {
        //        throw new InvalidOperationException("Expected an error with a target field referencing an action but did not get one");
        //    }

        //    // action could be failed and the target reference is "#/tasks/keyPhraseExtractionTasks/0";
        //    Match targetMatch = _targetRegex.Match(targetReference);

        //    string[] taskNameIdPair = new string[2];
        //    if (targetMatch.Success && targetMatch.Groups.Count == 3)
        //    {
        //        taskNameIdPair[0] = targetMatch.Groups[1].Value;
        //        taskNameIdPair[1] = targetMatch.Groups[2].Value;
        //        return taskNameIdPair;
        //    }
        //    return null;
        //}

        //internal static AnalyzeActionsResult ConvertToAnalyzeActionsResult(AnalyzeJobState jobState, IDictionary<string, int> map)
        //{
        //    IDictionary<int, TextAnalyticsErrorInternal> keyPhraseErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> entitiesRecognitionErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> entitiesPiiRecognitionErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> entitiesLinkingRecognitionErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> analyzeSentimentErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> extractSummaryErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> customEntitiesRecognitionErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> singleCategoryClassifyErrors = new Dictionary<int, TextAnalyticsErrorInternal>();
        //    IDictionary<int, TextAnalyticsErrorInternal> multiCategoryClassifyErrors = new Dictionary<int, TextAnalyticsErrorInternal>();

        //    if (jobState.Errors.Any())
        //    {
        //        foreach (TextAnalyticsErrorInternal error in jobState.Errors)
        //        {
        //            string[] targetPair = parseActionErrorTarget(error.Target);
        //            if (targetPair == null)
        //                throw new InvalidOperationException($"Invalid action/id error. \n Additional information: Error code: {error.Code} Error message: {error.Message}");

        //            string taskName = targetPair[0];
        //            int taskIndex = int.Parse(targetPair[1], CultureInfo.InvariantCulture);

        //            if ("entityRecognitionTasks".Equals(taskName))
        //            {
        //                entitiesRecognitionErrors.Add(taskIndex, error);
        //            }
        //            else if ("entityRecognitionPiiTasks".Equals(taskName))
        //            {
        //                entitiesPiiRecognitionErrors.Add(taskIndex, error);
        //            }
        //            else if ("keyPhraseExtractionTasks".Equals(taskName))
        //            {
        //                keyPhraseErrors.Add(taskIndex, error);
        //            }
        //            else if ("entityLinkingTasks".Equals(taskName))
        //            {
        //                entitiesLinkingRecognitionErrors.Add(taskIndex, error);
        //            }
        //            else if ("sentimentAnalysisTasks".Equals(taskName))
        //            {
        //                analyzeSentimentErrors.Add(taskIndex, error);
        //            }
        //            else if ("extractiveSummarizationTasks".Equals(taskName))
        //            {
        //                extractSummaryErrors.Add(taskIndex, error);
        //            }
        //            else if ("customEntityRecognitionTasks".Equals(taskName))
        //            {
        //                customEntitiesRecognitionErrors.Add(taskIndex, error);
        //            }
        //            else if ("customSingleClassificationTasks".Equals(taskName))
        //            {
        //                singleCategoryClassifyErrors.Add(taskIndex, error);
        //            }
        //            else if ("customMultiClassificationTasks".Equals(taskName))
        //            {
        //                multiCategoryClassifyErrors.Add(taskIndex, error);
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException($"Invalid task name in target reference - {taskName}. \n Additional information: Error code: {error.Code} Error message: {error.Message}");
        //            }
        //        }
        //    }

        //    return new AnalyzeActionsResult(
        //        ConvertToExtractKeyPhrasesActionResults(jobState, map, keyPhraseErrors),
        //        ConvertToRecognizeEntitiesActionsResults(jobState, map, entitiesRecognitionErrors),
        //        ConvertToRecognizePiiEntitiesActionsResults(jobState, map, entitiesPiiRecognitionErrors),
        //        ConvertToRecognizeLinkedEntitiesActionsResults(jobState, map, entitiesLinkingRecognitionErrors),
        //        ConvertToAnalyzeSentimentActionsResults(jobState, map, analyzeSentimentErrors),
        //        ConvertToExtractSummaryActionsResults(jobState, map, extractSummaryErrors),
        //        ConvertToRecognizeCustomEntitiesActionsResults(jobState, map, customEntitiesRecognitionErrors),
        //        ConvertToSingleCategoryClassifyResults(jobState, map, singleCategoryClassifyErrors),
        //        ConvertToMultiCategoryClassifyActionsResults(jobState, map, multiCategoryClassifyErrors)
        //        );
        //}

        //private static IReadOnlyCollection<MultiCategoryClassifyActionResult> ConvertToMultiCategoryClassifyActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<MultiCategoryClassifyActionResult>(jobState.Tasks.CustomMultiClassificationTasks.Count);
        //    int index = 0;
        //    foreach (CustomMultiClassificationTasksItem task in jobState.Tasks.CustomMultiClassificationTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new MultiCategoryClassifyActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new MultiCategoryClassifyActionResult(ConvertToMultiCategoryClassifyResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<SingleCategoryClassifyActionResult> ConvertToSingleCategoryClassifyResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<SingleCategoryClassifyActionResult>(jobState.Tasks.CustomSingleClassificationTasks.Count);
        //    int index = 0;
        //    foreach (CustomSingleClassificationTasksItem task in jobState.Tasks.CustomSingleClassificationTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new SingleCategoryClassifyActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new SingleCategoryClassifyActionResult(ConvertToSingleCategoryClassifyResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<AnalyzeSentimentActionResult> ConvertToAnalyzeSentimentActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<AnalyzeSentimentActionResult>(jobState.Tasks.SentimentAnalysisTasks.Count);
        //    int index = 0;
        //    foreach (SentimentAnalysisTasksItem task in jobState.Tasks.SentimentAnalysisTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new AnalyzeSentimentActionResult( task.TaskName,task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new AnalyzeSentimentActionResult(ConvertToAnalyzeSentimentResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> ConvertToRecognizeLinkedEntitiesActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<RecognizeLinkedEntitiesActionResult>(jobState.Tasks.EntityLinkingTasks.Count);
        //    int index = 0;
        //    foreach (EntityLinkingTasksItem task in jobState.Tasks.EntityLinkingTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new RecognizeLinkedEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new RecognizeLinkedEntitiesActionResult(ConvertToRecognizeLinkedEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<ExtractKeyPhrasesActionResult> ConvertToExtractKeyPhrasesActionResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<ExtractKeyPhrasesActionResult>(jobState.Tasks.KeyPhraseExtractionTasks.Count);
        //    int index = 0;
        //    foreach (KeyPhraseExtractionTasksItem task in jobState.Tasks.KeyPhraseExtractionTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new ExtractKeyPhrasesActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new ExtractKeyPhrasesActionResult(ConvertToExtractKeyPhrasesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<RecognizePiiEntitiesActionResult> ConvertToRecognizePiiEntitiesActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<RecognizePiiEntitiesActionResult>(jobState.Tasks.EntityRecognitionPiiTasks.Count);
        //    int index = 0;
        //    foreach (EntityRecognitionPiiTasksItem task in jobState.Tasks.EntityRecognitionPiiTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new RecognizePiiEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new RecognizePiiEntitiesActionResult(ConvertToRecognizePiiEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<RecognizeEntitiesActionResult> ConvertToRecognizeEntitiesActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<RecognizeEntitiesActionResult>(jobState.Tasks.EntityRecognitionTasks.Count);
        //    int index = 0;
        //    foreach (EntityRecognitionTasksItem task in jobState.Tasks.EntityRecognitionTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new RecognizeEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new RecognizeEntitiesActionResult(ConvertToRecognizeEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<RecognizeCustomEntitiesActionResult> ConvertToRecognizeCustomEntitiesActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<RecognizeCustomEntitiesActionResult>(jobState.Tasks.CustomEntityRecognitionTasks.Count);
        //    int index = 0;
        //    foreach (var task in jobState.Tasks.CustomEntityRecognitionTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new RecognizeCustomEntitiesActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new RecognizeCustomEntitiesActionResult(ConvertToRecognizeCustomEntitiesResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        //private static IReadOnlyCollection<ExtractSummaryActionResult> ConvertToExtractSummaryActionsResults(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap, IDictionary<int, TextAnalyticsErrorInternal> tasksErrors)
        //{
        //    var collection = new List<ExtractSummaryActionResult>(jobState.Tasks.ExtractiveSummarizationTasks.Count);
        //    int index = 0;
        //    foreach (ExtractiveSummarizationTasksItem task in jobState.Tasks.ExtractiveSummarizationTasks)
        //    {
        //        tasksErrors.TryGetValue(index, out TextAnalyticsErrorInternal taskError);

        //        if (taskError != null)
        //        {
        //            collection.Add(new ExtractSummaryActionResult(task.TaskName, task.LastUpdateDateTime, taskError));
        //        }
        //        else
        //        {
        //            collection.Add(new ExtractSummaryActionResult(ConvertToExtractSummaryResultCollection(task.Results, idToIndexMap), task.TaskName, task.LastUpdateDateTime));
        //        }
        //        index++;
        //    }

        //    return collection;
        //}

        #endregion

        private static List<T> SortHeterogeneousCollection<T>(List<T> collection, IDictionary<string, int> idToIndexMap) where T : TextAnalyticsResult
        {
            return collection.OrderBy(result => idToIndexMap[result.Id]).ToList();
        }
    }
}
