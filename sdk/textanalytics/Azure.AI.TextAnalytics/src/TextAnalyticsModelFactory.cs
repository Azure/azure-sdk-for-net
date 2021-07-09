﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Model factory that enables mocking for the Text Analytics library.
    /// </summary>
    [CodeGenType(nameof(TextAnalyticsModelFactory))]
    public static partial class TextAnalyticsModelFactory
    {
        #region Common
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.TextDocumentStatistics"/> for mocking purposes.
        /// </summary>
        /// <param name="characterCount">Sets the <see cref="TextDocumentStatistics.CharacterCount"/> property.</param>
        /// <param name="transactionCount">Sets the <see cref="TextDocumentStatistics.TransactionCount"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.TextDocumentStatistics"/> for mocking purposes.</returns>
        public static TextDocumentStatistics TextDocumentStatistics(int characterCount, int transactionCount)
        {
            return new TextDocumentStatistics(characterCount, transactionCount);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.TextDocumentBatchStatistics"/> for mocking purposes.
        /// </summary>
        /// <param name="documentCount">Sets the <see cref="TextDocumentBatchStatistics.DocumentCount"/> property.</param>
        /// <param name="validDocumentCount">Sets the <see cref="TextDocumentBatchStatistics.ValidDocumentCount"/> property.</param>
        /// <param name="invalidDocumentCount">Sets the <see cref="TextDocumentBatchStatistics.InvalidDocumentCount"/> property.</param>
        /// <param name="transactionCount">Sets the <see cref="TextDocumentBatchStatistics.TransactionCount"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.TextDocumentBatchStatistics"/> for mocking purposes.</returns>
        public static TextDocumentBatchStatistics TextDocumentBatchStatistics(int documentCount, int validDocumentCount, int invalidDocumentCount, long transactionCount)
        {
            return new TextDocumentBatchStatistics(documentCount, validDocumentCount, invalidDocumentCount, transactionCount);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.TextAnalyticsError"/> for mocking purposes.
        /// </summary>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <param name="target">Sets the <see cref="TextAnalyticsError.Target"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.TextAnalyticsError"/> for mocking purposes.</returns>
        public static TextAnalyticsError TextAnalyticsError(string code, string message, string target = default)
        {
            return new TextAnalyticsError(code, message, target);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.TextAnalyticsWarning"/> for mocking purposes.
        /// </summary>
        /// <param name="code">Sets the <see cref="TextAnalyticsWarning.WarningCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsWarning.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.TextAnalyticsWarning"/> for mocking purposes.</returns>
        public static TextAnalyticsWarning TextAnalyticsWarning(string code, string message)
        {
            return new TextAnalyticsWarning(new TextAnalyticsWarningInternal(code, message));
        }

        #endregion Common

        #region Analyze Sentiment
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.SentimentConfidenceScores"/> for mocking purposes.
        /// </summary>
        /// <param name="positiveScore">Sets the <see cref="SentimentConfidenceScores.Positive"/> property.</param>
        /// <param name="neutralScore">Sets the <see cref="SentimentConfidenceScores.Neutral"/> property.</param>
        /// <param name="negativeScore">Sets the <see cref="SentimentConfidenceScores.Negative"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.SentimentConfidenceScores"/> for mocking purposes.</returns>
        public static SentimentConfidenceScores SentimentConfidenceScores(double positiveScore, double neutralScore, double negativeScore)
        {
            return new SentimentConfidenceScores(positiveScore, neutralScore, negativeScore);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.DocumentSentiment"/> for mocking purposes.
        /// </summary>
        /// <param name="sentiment">Sets the <see cref="DocumentSentiment.Sentiment"/> property.</param>
        /// <param name="positiveScore">Sets the <see cref="SentimentConfidenceScores.Positive"/> property.</param>
        /// <param name="neutralScore">Sets the <see cref="SentimentConfidenceScores.Neutral"/> property.</param>
        /// <param name="negativeScore">Sets the <see cref="SentimentConfidenceScores.Negative"/> property.</param>
        /// <param name="sentenceSentiments">Sets the <see cref="DocumentSentiment.Sentences"/> property.</param>
        /// <param name="warnings">Sets the <see cref="DetectedLanguage.Warnings"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.DocumentSentiment"/> for mocking purposes.</returns>
        public static DocumentSentiment DocumentSentiment(TextSentiment sentiment, double positiveScore, double neutralScore, double negativeScore, List<SentenceSentiment> sentenceSentiments, IList<TextAnalyticsWarning> warnings = default)
        {
            warnings ??= new List<TextAnalyticsWarning>();
            return new DocumentSentiment(sentiment, positiveScore, neutralScore, negativeScore, sentenceSentiments, warnings);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.SentenceSentiment"/> for mocking purposes.
        /// </summary>
        /// <param name="sentiment">Sets the <see cref="SentenceSentiment.Sentiment"/> property.</param>
        /// <param name="text">Sets the <see cref="SentenceSentiment.Text"/> property.</param>
        /// <param name="positiveScore">Sets the <see cref="SentimentConfidenceScores.Positive"/> property.</param>
        /// <param name="neutralScore">Sets the <see cref="SentimentConfidenceScores.Neutral"/> property.</param>
        /// <param name="negativeScore">Sets the <see cref="SentimentConfidenceScores.Negative"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.SentenceSentiment"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SentenceSentiment SentenceSentiment(TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore)
        {
            return new SentenceSentiment(sentiment, text, positiveScore, neutralScore, negativeScore, default, default, new List<SentenceOpinion>());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.SentenceSentiment"/> for mocking purposes.
        /// </summary>
        /// <param name="sentiment">Sets the <see cref="SentenceSentiment.Sentiment"/> property.</param>
        /// <param name="text">Sets the <see cref="SentenceSentiment.Text"/> property.</param>
        /// <param name="positiveScore">Sets the <see cref="SentimentConfidenceScores.Positive"/> property.</param>
        /// <param name="neutralScore">Sets the <see cref="SentimentConfidenceScores.Neutral"/> property.</param>
        /// <param name="negativeScore">Sets the <see cref="SentimentConfidenceScores.Negative"/> property.</param>
        /// <param name="offset">Sets the <see cref="SentenceSentiment.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="SentenceSentiment.Length"/> property.</param>
        /// <param name="opinions">Sets the <see cref="SentenceSentiment.Opinions"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.SentenceSentiment"/> for mocking purposes.</returns>
        public static SentenceSentiment SentenceSentiment(TextSentiment sentiment, string text, double positiveScore, double neutralScore, double negativeScore, int offset, int length, IEnumerable<SentenceOpinion> opinions)
        {
            opinions ??= new List<SentenceOpinion>();
            return new SentenceSentiment(sentiment, text, positiveScore, neutralScore, negativeScore, offset, length, opinions.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.TargetSentiment"/> for mocking purposes.
        /// </summary>
        /// <param name="sentiment">Sets the <see cref="TargetSentiment.Sentiment"/> property.</param>
        /// <param name="text">Sets the <see cref="TargetSentiment.Text"/> property.</param>
        /// <param name="positiveScore">Sets the <see cref="SentimentConfidenceScores.Positive"/> property.</param>
        /// <param name="negativeScore">Sets the <see cref="SentimentConfidenceScores.Negative"/> property.</param>
        /// <param name="offset">Sets the <see cref="TargetSentiment.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="TargetSentiment.Length"/> property.</param>
        /// <returns>>A new instance of <see cref="TextAnalytics.TargetSentiment"/> for mocking purposes.</returns>
        public static TargetSentiment TargetSentiment(TextSentiment sentiment, string text, double positiveScore, double negativeScore, int offset, int length)
        {
            return new TargetSentiment(sentiment, text, positiveScore, negativeScore, offset, length);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AssessmentSentiment"/> for mocking purposes.
        /// </summary>
        /// <param name="sentiment">Sets the <see cref="AssessmentSentiment.Sentiment"/> property.</param>
        /// <param name="positiveScore">Sets the <see cref="SentimentConfidenceScores.Positive"/> property.</param>
        /// <param name="negativeScore">Sets the <see cref="SentimentConfidenceScores.Negative"/> property.</param>
        /// <param name="text">Sets the <see cref="AssessmentSentiment.Text"/> property.</param>
        /// <param name="isNegated">Sets the <see cref="AssessmentSentiment.IsNegated"/> property.</param>
        /// <param name="offset">Sets the <see cref="AssessmentSentiment.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="AssessmentSentiment.Length"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AssessmentSentiment"/> for mocking purposes.</returns>
        public static AssessmentSentiment AssessmentSentiment(TextSentiment sentiment, double positiveScore, double negativeScore, string text, bool isNegated, int offset, int length)
        {
            return new AssessmentSentiment(sentiment, positiveScore, negativeScore, text, isNegated, offset, length);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.SentenceOpinion"/> for mocking purposes.
        /// </summary>
        /// <param name="target">Sets the <see cref="SentenceOpinion.Target"/> property.</param>
        /// <param name="assessments">Sets the <see cref="SentenceOpinion.Assessments"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.SentenceOpinion"/> for mocking purposes.</returns>
        public static SentenceOpinion SentenceOpinion(TargetSentiment target, IEnumerable<AssessmentSentiment> assessments)
        {
            return new SentenceOpinion(target, assessments.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeSentimentResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="documentSentiment">Sets the <see cref="AnalyzeSentimentResult.DocumentSentiment"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeSentimentResult"/> for mocking purposes.</returns>
        public static AnalyzeSentimentResult AnalyzeSentimentResult(string id, TextDocumentStatistics statistics, DocumentSentiment documentSentiment)
        {
            return new AnalyzeSentimentResult(id, statistics, documentSentiment);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeSentimentResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="error">Sets the <see cref="TextAnalyticsResult.Error"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeSentimentResult"/> for mocking purposes.</returns>
        public static AnalyzeSentimentResult AnalyzeSentimentResult(string id, TextAnalyticsError error)
        {
            return new AnalyzeSentimentResult(id, error);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeSentimentResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.AnalyzeSentimentResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="AnalyzeSentimentResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="AnalyzeSentimentResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeSentimentResultCollection"/> for mocking purposes.</returns>
        public static AnalyzeSentimentResultCollection AnalyzeSentimentResultCollection(IEnumerable<AnalyzeSentimentResult> list, TextDocumentBatchStatistics statistics, string modelVersion)
        {
            return new AnalyzeSentimentResultCollection(list.ToList(), statistics, modelVersion);
        }

        #endregion Analyze Sentiment

        #region Detect Language
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.DetectedLanguage"/> for mocking purposes.
        /// </summary>
        /// <param name="name">Sets the <see cref="DetectedLanguage.Name"/> property.</param>
        /// <param name="iso6391Name">Sets the <see cref="DetectedLanguage.Iso6391Name"/> property.</param>
        /// <param name="confidenceScore">Sets the <see cref="DetectedLanguage.ConfidenceScore"/> property.</param>
        /// <param name="warnings">Sets the <see cref="DetectedLanguage.Warnings"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.DetectedLanguage"/> for mocking purposes.</returns>
        public static DetectedLanguage DetectedLanguage(string name, string iso6391Name, double confidenceScore, IList<TextAnalyticsWarning> warnings = default)
        {
            warnings ??= new List<TextAnalyticsWarning>();
            return new DetectedLanguage(new DetectedLanguageInternal(name, iso6391Name, confidenceScore), warnings);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.DetectLanguageResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="detectedLanguage">Sets the <see cref="TextAnalytics.DetectedLanguage"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.DetectLanguageResult"/> for mocking purposes.</returns>
        public static DetectLanguageResult DetectLanguageResult(string id, TextDocumentStatistics statistics, DetectedLanguage detectedLanguage)
        {
            return new DetectLanguageResult(id, statistics, detectedLanguage);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.DetectLanguageResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="error">Sets the <see cref="TextAnalyticsResult.Error"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.DetectLanguageResult"/> for mocking purposes.</returns>
        public static DetectLanguageResult DetectLanguageResult(string id, TextAnalyticsError error)
        {
            return new DetectLanguageResult(id, error);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.DetectLanguageResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.DetectLanguageResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="DetectLanguageResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="DetectLanguageResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.DetectLanguageResultCollection"/> for mocking purposes.</returns>
        public static DetectLanguageResultCollection DetectLanguageResultCollection(IEnumerable<DetectLanguageResult> list, TextDocumentBatchStatistics statistics, string modelVersion)
        {
            return new DetectLanguageResultCollection(list.ToList(), statistics, modelVersion);
        }

        #endregion Detect Language

        #region Recognize Entities
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.CategorizedEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="CategorizedEntity.Text"/> property.</param>
        /// <param name="category">Sets the <see cref="CategorizedEntity.Category"/> property.</param>
        /// <param name="subCategory">Sets the <see cref="CategorizedEntity.SubCategory"/> property.</param>
        /// <param name="score">Sets the <see cref="CategorizedEntity.ConfidenceScore"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.CategorizedEntity"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CategorizedEntity CategorizedEntity(string text, string category, string subCategory, double score)
        {
            return new CategorizedEntity(new Entity(text, category, subCategory, default, default, score));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.CategorizedEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="CategorizedEntity.Text"/> property.</param>
        /// <param name="category">Sets the <see cref="CategorizedEntity.Category"/> property.</param>
        /// <param name="subCategory">Sets the <see cref="CategorizedEntity.SubCategory"/> property.</param>
        /// <param name="score">Sets the <see cref="CategorizedEntity.ConfidenceScore"/> property.</param>
        /// <param name="offset">Sets the <see cref="CategorizedEntity.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="CategorizedEntity.Length"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.CategorizedEntity"/> for mocking purposes.</returns>
        public static CategorizedEntity CategorizedEntity(string text, string category, string subCategory, double score, int offset, int length)
        {
            return new CategorizedEntity(new Entity(text, category, subCategory, offset, length, score));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.CategorizedEntityCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="entities">Sets the collection of <see cref="TextAnalytics.CategorizedEntity"/>.</param>
        /// <param name="warnings">Sets the <see cref="CategorizedEntityCollection.Warnings"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.CategorizedEntityCollection"/> for mocking purposes.</returns>
        public static CategorizedEntityCollection CategorizedEntityCollection(IList<CategorizedEntity> entities, IList<TextAnalyticsWarning> warnings = default)
        {
            warnings ??= new List<TextAnalyticsWarning>();
            return new CategorizedEntityCollection(entities, warnings);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="entities">Sets the collection of <see cref="TextAnalytics.CategorizedEntityCollection"/>.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeEntitiesResult"/> for mocking purposes.</returns>
        public static RecognizeEntitiesResult RecognizeEntitiesResult(string id, TextDocumentStatistics statistics, CategorizedEntityCollection entities)
        {
            return new RecognizeEntitiesResult(id, statistics, entities);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="error">Sets the <see cref="TextAnalyticsResult.Error"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeEntitiesResult"/> for mocking purposes.</returns>
        public static RecognizeEntitiesResult RecognizeEntitiesResult(string id, TextAnalyticsError error)
        {
            return new RecognizeEntitiesResult(id, error);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeEntitiesResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.RecognizeEntitiesResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="RecognizeEntitiesResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="RecognizeEntitiesResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeEntitiesResultCollection"/> for mocking purposes.</returns>
        public static RecognizeEntitiesResultCollection RecognizeEntitiesResultCollection(IEnumerable<RecognizeEntitiesResult> list, TextDocumentBatchStatistics statistics, string modelVersion)
        {
            return new RecognizeEntitiesResultCollection(list.ToList(), statistics, modelVersion);
        }

        #endregion Recognize Entities

        #region Recognize PII Entities
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.PiiEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="PiiEntity.Text"/> property.</param>
        /// <param name="category">Sets the <see cref="PiiEntity.Category"/> property.</param>
        /// <param name="subCategory">Sets the <see cref="PiiEntity.SubCategory"/> property.</param>
        /// <param name="score">Sets the <see cref="PiiEntity.ConfidenceScore"/> property.</param>
        /// <param name="offset">Sets the <see cref="PiiEntity.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="PiiEntity.Length"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.PiiEntity"/> for mocking purposes.</returns>
        public static PiiEntity PiiEntity(string text, string category, string subCategory, double score, int offset, int length)
        {
            return new PiiEntity(new Entity(text, category, subCategory, offset, length, score));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.PiiEntityCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="entities">Sets the collection of <see cref="TextAnalytics.PiiEntity"/>.</param>
        /// <param name="redactedText">Sets the <see cref="PiiEntityCollection.RedactedText"/> property.</param>
        /// <param name="warnings">Sets the <see cref="PiiEntityCollection.Warnings"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.PiiEntityCollection"/> for mocking purposes.</returns>
        public static PiiEntityCollection PiiEntityCollection(IEnumerable<PiiEntity> entities, string redactedText, IEnumerable<TextAnalyticsWarning> warnings = default)
        {
            warnings ??= new List<TextAnalyticsWarning>();
            return new PiiEntityCollection(entities.ToList(), redactedText, warnings.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizePiiEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="entities">Sets the collection of <see cref="TextAnalytics.PiiEntityCollection"/>.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizePiiEntitiesResult"/> for mocking purposes.</returns>
        public static RecognizePiiEntitiesResult RecognizePiiEntitiesResult(string id, TextDocumentStatistics statistics, PiiEntityCollection entities)
        {
            return new RecognizePiiEntitiesResult(id, statistics, entities);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizePiiEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="error">Sets the <see cref="TextAnalyticsResult.Error"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizePiiEntitiesResult"/> for mocking purposes.</returns>
        public static RecognizePiiEntitiesResult RecognizePiiEntitiesResult(string id, TextAnalyticsError error)
        {
            return new RecognizePiiEntitiesResult(id, error);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizePiiEntitiesResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.RecognizePiiEntitiesResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="RecognizePiiEntitiesResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="RecognizePiiEntitiesResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizePiiEntitiesResultCollection"/> for mocking purposes.</returns>
        public static RecognizePiiEntitiesResultCollection RecognizePiiEntitiesResultCollection(IEnumerable<RecognizePiiEntitiesResult> list, TextDocumentBatchStatistics statistics, string modelVersion)
        {
            return new RecognizePiiEntitiesResultCollection(list.ToList(), statistics, modelVersion);
        }

        #endregion Recognize PII Entities

        #region Extract KeyPhrase
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.ExtractKeyPhrasesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="keyPhrases">Sets the <see cref="ExtractKeyPhrasesResult.KeyPhrases"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.ExtractKeyPhrasesResult"/> for mocking purposes.</returns>
        public static ExtractKeyPhrasesResult ExtractKeyPhrasesResult(string id, TextDocumentStatistics statistics, KeyPhraseCollection keyPhrases)
        {
            return new ExtractKeyPhrasesResult(id, statistics, keyPhrases);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.KeyPhraseCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="keyPhrases">Sets the collection of <see cref="string"/> key phrases.</param>
        /// <param name="warnings">Sets the <see cref="KeyPhraseCollection.Warnings"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.KeyPhraseCollection"/> for mocking purposes.</returns>
        public static KeyPhraseCollection KeyPhraseCollection(IList<string> keyPhrases, IList<TextAnalyticsWarning> warnings = default)
        {
            warnings ??= new List<TextAnalyticsWarning>();
            return new KeyPhraseCollection(keyPhrases, warnings);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.ExtractKeyPhrasesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="error">Sets the <see cref="TextAnalyticsResult.Error"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.ExtractKeyPhrasesResult"/> for mocking purposes.</returns>
        public static ExtractKeyPhrasesResult ExtractKeyPhrasesResult(string id, TextAnalyticsError error)
        {
            return new ExtractKeyPhrasesResult(id, error);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.ExtractKeyPhrasesResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.ExtractKeyPhrasesResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="ExtractKeyPhrasesResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="ExtractKeyPhrasesResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.ExtractKeyPhrasesResultCollection"/> for mocking purposes.</returns>
        public static ExtractKeyPhrasesResultCollection ExtractKeyPhrasesResultCollection(IEnumerable<ExtractKeyPhrasesResult> list, TextDocumentBatchStatistics statistics, string modelVersion)
        {
            return new ExtractKeyPhrasesResultCollection(list.ToList(), statistics, modelVersion);
        }

        #endregion Extract KeyPhrase

        #region Linked Entities
        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.LinkedEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="name">Sets the <see cref="LinkedEntity.Name"/> property.</param>
        /// <param name="dataSourceEntityId">Sets the <see cref="LinkedEntity.DataSourceEntityId"/> property.</param>
        /// <param name="language">Sets the <see cref="LinkedEntity.Language"/> property.</param>
        /// <param name="dataSource">Sets the <see cref="LinkedEntity.DataSource"/> property.</param>
        /// <param name="url">Sets the <see cref="LinkedEntity.Url"/> property.</param>
        /// <param name="matches">Sets the <see cref="LinkedEntity.Matches"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.LinkedEntity"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LinkedEntity LinkedEntity(string name, string dataSourceEntityId, string language, string dataSource, Uri url, IEnumerable<LinkedEntityMatch> matches)
        {
            return new LinkedEntity(name, matches, language, dataSourceEntityId, url, dataSource, default);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.LinkedEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="name">Sets the <see cref="LinkedEntity.Name"/> property.</param>
        /// <param name="dataSourceEntityId">Sets the <see cref="LinkedEntity.DataSourceEntityId"/> property.</param>
        /// <param name="language">Sets the <see cref="LinkedEntity.Language"/> property.</param>
        /// <param name="dataSource">Sets the <see cref="LinkedEntity.DataSource"/> property.</param>
        /// <param name="url">Sets the <see cref="LinkedEntity.Url"/> property.</param>
        /// <param name="matches">Sets the <see cref="LinkedEntity.Matches"/> property.</param>
        /// <param name="bingEntitySearchApiId">Sets the <see cref="LinkedEntity.BingEntitySearchApiId"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.LinkedEntity"/> for mocking purposes.</returns>
        public static LinkedEntity LinkedEntity(string name, string dataSourceEntityId, string language, string dataSource, Uri url, IEnumerable<LinkedEntityMatch> matches, string bingEntitySearchApiId)
        {
            return new LinkedEntity(name, matches, language, dataSourceEntityId, url, dataSource, bingEntitySearchApiId);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.LinkedEntityMatch"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="LinkedEntityMatch.Text"/> property.</param>
        /// <param name="score">Sets the <see cref="LinkedEntityMatch.ConfidenceScore"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.LinkedEntityMatch"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LinkedEntityMatch LinkedEntityMatch(string text, double score)
        {
            return new LinkedEntityMatch(score, text, default, default);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.LinkedEntityMatch"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="LinkedEntityMatch.Text"/> property.</param>
        /// <param name="score">Sets the <see cref="LinkedEntityMatch.ConfidenceScore"/> property.</param>
        /// <param name="offset">Sets the <see cref="LinkedEntityMatch.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="LinkedEntityMatch.Length"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.LinkedEntityMatch"/> for mocking purposes.</returns>
        public static LinkedEntityMatch LinkedEntityMatch(string text, double score, int offset, int length)
        {
            return new LinkedEntityMatch(score, text, offset, length);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.LinkedEntityCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="entities">Sets the collection of <see cref="TextAnalytics.LinkedEntity"/>.</param>
        /// <param name="warnings">Sets the <see cref="LinkedEntityCollection.Warnings"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.LinkedEntityCollection"/> for mocking purposes.</returns>
        public static LinkedEntityCollection LinkedEntityCollection(IList<LinkedEntity> entities, IList<TextAnalyticsWarning> warnings = default)
        {
            warnings ??= new List<TextAnalyticsWarning>();
            return new LinkedEntityCollection(entities, warnings);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="linkedEntities">Sets the collection of <see cref="TextAnalytics.LinkedEntity"/>.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesResult"/> for mocking purposes.</returns>
        public static RecognizeLinkedEntitiesResult RecognizeLinkedEntitiesResult(string id, TextDocumentStatistics statistics, LinkedEntityCollection linkedEntities)
        {
            return new RecognizeLinkedEntitiesResult(id, statistics, linkedEntities);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="error">Sets the <see cref="TextAnalyticsResult.Error"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesResult"/> for mocking purposes.</returns>
        public static RecognizeLinkedEntitiesResult RecognizeLinkedEntitiesResult(string id, TextAnalyticsError error)
        {
            return new RecognizeLinkedEntitiesResult(id, error);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.RecognizeLinkedEntitiesResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="RecognizeLinkedEntitiesResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="RecognizeLinkedEntitiesResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesResultCollection"/> for mocking purposes.</returns>
        public static RecognizeLinkedEntitiesResultCollection RecognizeLinkedEntitiesResultCollection(IEnumerable<RecognizeLinkedEntitiesResult> list, TextDocumentBatchStatistics statistics, string modelVersion)
        {
            return new RecognizeLinkedEntitiesResultCollection(list.ToList(), statistics, modelVersion);
        }

        /// <summary> Initializes new instance of LinkedEntity structure. </summary>
        /// <param name="name"> Entity Linking formal name. </param>
        /// <param name="matches"> List of instances this entity appears in the text. </param>
        /// <param name="language"> Language used in the data source. </param>
        /// <param name="dataSourceEntityId"> Unique identifier of the recognized entity from the data source. </param>
        /// <param name="url"> URL for the entity&apos;s page from the data source. </param>
        /// <param name="dataSource"> Data source used to extract entity linking, such as Wiki/Bing etc. </param>
        /// <param name="bingEntitySearchApiId"> Bing Entity Search API unique identifier of the recognized entity. </param>
        /// <returns> A new <see cref="TextAnalytics.LinkedEntity"/> instance for mocking. </returns>
        internal static LinkedEntity LinkedEntity(string name = default, IEnumerable<LinkedEntityMatch> matches = default, string language = default, string dataSourceEntityId = default, Uri url = default, string dataSource = default, string bingEntitySearchApiId = default)
        {
            matches ??= new List<LinkedEntityMatch>();
            return new LinkedEntity(name, matches, language, dataSourceEntityId, url, dataSource, bingEntitySearchApiId);
        }

        /// <summary> Initializes new instance of LinkedEntityMatch structure. </summary>
        /// <param name="confidenceScore"> If a well known item is recognized, a decimal number denoting the confidence level between 0 and 1 will be returned. </param>
        /// <param name="text"> Entity text as appears in the request. </param>
        /// <param name="offset"> Start position for the entity match text. </param>
        /// <param name="length"> Length for the entity match text. </param>
        /// <returns> A new <see cref="TextAnalytics.LinkedEntityMatch"/> instance for mocking. </returns>
        internal static LinkedEntityMatch LinkedEntityMatch(double confidenceScore = default, string text = default, int offset = default, int length = default)
        {
            return new LinkedEntityMatch(confidenceScore, text, offset, length);
        }

        #endregion Linked Entities

        #region Action Result Models

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeActionsResult"/> for mocking purposes.
        /// </summary>
        /// <param name="extractKeyPhrasesActionResult">Sets the collection of <see cref="TextAnalytics.ExtractKeyPhrasesActionResult"/>.</param>
        /// <param name="recognizeEntitiesActionResults">Sets the collection of <see cref="TextAnalytics.RecognizeEntitiesActionResult"/>.</param>
        /// <param name="recognizePiiEntitiesActionResults">Sets the collection of <see cref="TextAnalytics.RecognizePiiEntitiesActionResult"/>.</param>
        /// <param name="recognizeLinkedEntitiesActionsResults">Sets the collection of <see cref="TextAnalytics.RecognizeLinkedEntitiesActionResult"/>.</param>
        /// <param name="analyzeSentimentActionsResults">Sets the collection of <see cref="TextAnalytics.AnalyzeSentimentActionResult"/>.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeActionsResult"/> for mocking purposes.</returns>
        public static AnalyzeActionsResult AnalyzeActionsResult(
            IEnumerable<ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResult,
            IEnumerable<RecognizeEntitiesActionResult> recognizeEntitiesActionResults,
            IEnumerable<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults,
            IEnumerable<RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionsResults,
            IEnumerable<AnalyzeSentimentActionResult> analyzeSentimentActionsResults)
        {
            return new AnalyzeActionsResult(
                extractKeyPhrasesActionResult.ToList(),
                recognizeEntitiesActionResults.ToList(),
                recognizePiiEntitiesActionResults.ToList(),
                recognizeLinkedEntitiesActionsResults.ToList(),
                analyzeSentimentActionsResults.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.ExtractKeyPhrasesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="result">Sets the <see cref="ExtractKeyPhrasesActionResult.DocumentsResults"/> property.</param>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.ExtractKeyPhrasesActionResult"/> for mocking purposes.</returns>
        public static ExtractKeyPhrasesActionResult ExtractKeyPhrasesActionResult(
            ExtractKeyPhrasesResultCollection result,
            DateTimeOffset completedOn)
        {
            return new ExtractKeyPhrasesActionResult(result, completedOn);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.ExtractKeyPhrasesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.ExtractKeyPhrasesActionResult"/> for mocking purposes.</returns>
        public static ExtractKeyPhrasesActionResult ExtractKeyPhrasesActionResult(
            DateTimeOffset completedOn,
            string code,
            string message)
        {
            return new ExtractKeyPhrasesActionResult(completedOn, new TextAnalyticsErrorInternal(code, message));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeSentimentActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="result">Sets the <see cref="AnalyzeSentimentActionResult.DocumentsResults"/> property.</param>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeSentimentActionResult"/> for mocking purposes.</returns>
        public static AnalyzeSentimentActionResult AnalyzeSentimentActionResult(
            AnalyzeSentimentResultCollection result,
            DateTimeOffset completedOn)
        {
            return new AnalyzeSentimentActionResult(result, completedOn);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeSentimentActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeSentimentActionResult"/> for mocking purposes.</returns>
        public static AnalyzeSentimentActionResult AnalyzeSentimentActionResult(
            DateTimeOffset completedOn,
            string code,
            string message)
        {
            return new AnalyzeSentimentActionResult(completedOn, new TextAnalyticsErrorInternal(code, message));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="result">Sets the <see cref="RecognizeLinkedEntitiesActionResult.DocumentsResults"/> property.</param>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesActionResult"/> for mocking purposes.</returns>
        public static RecognizeLinkedEntitiesActionResult RecognizeLinkedEntitiesActionResult(
            RecognizeLinkedEntitiesResultCollection result,
            DateTimeOffset completedOn)
        {
            return new RecognizeLinkedEntitiesActionResult(result, completedOn);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeLinkedEntitiesActionResult"/> for mocking purposes.</returns>
        public static RecognizeLinkedEntitiesActionResult RecognizeLinkedEntitiesActionResult(
            DateTimeOffset completedOn,
            string code,
            string message)
        {
            return new RecognizeLinkedEntitiesActionResult(completedOn, new TextAnalyticsErrorInternal(code, message));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeEntitiesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="result">Sets the <see cref="RecognizeEntitiesActionResult.DocumentsResults"/> property.</param>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeEntitiesActionResult"/> for mocking purposes.</returns>
        public static RecognizeEntitiesActionResult RecognizeEntitiesActionResult(
            RecognizeEntitiesResultCollection result,
            DateTimeOffset completedOn)
        {
            return new RecognizeEntitiesActionResult(result, completedOn);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizeEntitiesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizeEntitiesActionResult"/> for mocking purposes.</returns>
        public static RecognizeEntitiesActionResult RecognizeEntitiesActionResult(
            DateTimeOffset completedOn,
            string code,
            string message)
        {
            return new RecognizeEntitiesActionResult(completedOn, new TextAnalyticsErrorInternal(code, message));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizePiiEntitiesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="result">Sets the <see cref="RecognizePiiEntitiesActionResult.DocumentsResults"/> property.</param>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizePiiEntitiesActionResult"/> for mocking purposes.</returns>
        public static RecognizePiiEntitiesActionResult RecognizePiiEntitiesActionResult(
            RecognizePiiEntitiesResultCollection result,
            DateTimeOffset completedOn)
        {
            return new RecognizePiiEntitiesActionResult(result, completedOn);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.RecognizePiiEntitiesActionResult"/> for mocking purposes.
        /// </summary>
        /// <param name="completedOn">Sets the <see cref="TextAnalyticsActionResult.CompletedOn"/> property.</param>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.RecognizePiiEntitiesActionResult"/> for mocking purposes.</returns>
        public static RecognizePiiEntitiesActionResult RecognizePiiEntitiesActionResult(
            DateTimeOffset completedOn,
            string code,
            string message)
        {
            return new RecognizePiiEntitiesActionResult(completedOn, new TextAnalyticsErrorInternal(code, message));
        }

        #endregion Action Result Models

        #region Healthcare

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="statistics">Sets the <see cref="TextAnalyticsResult.Statistics"/> property.</param>
        /// <param name="healthcareEntities">Sets the collection of <see cref="TextAnalytics.HealthcareEntity"/>.</param>
        /// <param name="entityRelations">Sets the collection of <see cref="TextAnalytics.HealthcareEntityRelation"/>.</param>
        /// <param name="warnings">Sets the collection of <see cref="TextAnalytics.TextAnalyticsWarning"/>.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResult"/> for mocking purposes.</returns>
        public static AnalyzeHealthcareEntitiesResult AnalyzeHealthcareEntitiesResult(
            string id,
            TextDocumentStatistics statistics,
            IEnumerable<HealthcareEntity> healthcareEntities,
            IEnumerable<HealthcareEntityRelation> entityRelations,
            IEnumerable<TextAnalyticsWarning> warnings)
        {
            return new AnalyzeHealthcareEntitiesResult(id, statistics, healthcareEntities.ToList(), entityRelations.ToList(), warnings.ToList());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TextAnalyticsResult.Id"/> property.</param>
        /// <param name="code">Sets the <see cref="TextAnalyticsError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="TextAnalyticsError.Message"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResult"/> for mocking purposes.</returns>
        public static AnalyzeHealthcareEntitiesResult AnalyzeHealthcareEntitiesResult(
            string id,
            string code,
            string message)
        {
            return new AnalyzeHealthcareEntitiesResult(id, new TextAnalyticsError(code, message));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResultCollection"/> for mocking purposes.
        /// </summary>
        /// <param name="list">Sets the collection of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResult"/>.</param>
        /// <param name="statistics">Sets the <see cref="AnalyzeHealthcareEntitiesResultCollection.Statistics"/> property.</param>
        /// <param name="modelVersion">Sets the <see cref="AnalyzeHealthcareEntitiesResultCollection.ModelVersion"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.AnalyzeHealthcareEntitiesResultCollection"/> for mocking purposes.</returns>
        public static AnalyzeHealthcareEntitiesResultCollection AnalyzeHealthcareEntitiesResultCollection(
            IEnumerable<AnalyzeHealthcareEntitiesResult> list,
            TextDocumentBatchStatistics statistics,
            string modelVersion)
        {
            return new AnalyzeHealthcareEntitiesResultCollection(list.ToList(), statistics, modelVersion);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.HealthcareEntity"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="HealthcareEntity.Text"/> property.</param>
        /// <param name="category">Sets the <see cref="HealthcareEntity.Category"/> property.</param>
        /// <param name="offset">Sets the <see cref="HealthcareEntity.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="HealthcareEntity.Length"/> property.</param>
        /// <param name="confidenceScore">Sets the <see cref="HealthcareEntity.ConfidenceScore"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.HealthcareEntity"/> for mocking purposes.</returns>
        public static HealthcareEntity HealthcareEntity(
            string text,
            string category,
            int offset,
            int length,
            double confidenceScore)
        {
            return new HealthcareEntity(new HealthcareEntityInternal(text, category, offset, length, confidenceScore));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.HealthcareEntityRelationRole"/> for mocking purposes.
        /// </summary>
        /// <param name="text">Sets the <see cref="HealthcareEntity.Text"/> property.</param>
        /// <param name="category">Sets the <see cref="HealthcareEntity.Category"/> property.</param>
        /// <param name="offset">Sets the <see cref="HealthcareEntity.Offset"/> property.</param>
        /// <param name="length">Sets the <see cref="HealthcareEntity.Length"/> property.</param>
        /// <param name="confidenceScore">Sets the <see cref="HealthcareEntity.ConfidenceScore"/> property.</param>
        /// <param name="entityName">Sets the <see cref="HealthcareEntityRelationRole.Name"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.HealthcareEntityRelationRole"/> for mocking purposes.</returns>
        public static HealthcareEntityRelationRole HealthcareEntityRelationRole(
            string text,
            string category,
            int offset,
            int length,
            double confidenceScore,
            string entityName)
        {
            return new HealthcareEntityRelationRole(new HealthcareEntityInternal(text, category, offset, length, confidenceScore), entityName);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextAnalytics.HealthcareEntityRelation"/> for mocking purposes.
        /// </summary>
        /// <param name="relationType">Sets the <see cref="HealthcareEntityRelation.RelationType"/> property.</param>
        /// <param name="roles">Sets the collection of <see cref="HealthcareEntityRelation.Roles"/> property.</param>
        /// <returns>A new instance of <see cref="TextAnalytics.HealthcareEntityRelation"/> for mocking purposes.</returns>
        public static HealthcareEntityRelation HealthcareEntityRelation(
            HealthcareEntityRelationType relationType,
            IEnumerable<HealthcareEntityRelationRole> roles)
        {
            return new HealthcareEntityRelation(relationType, roles.ToList());
        }
        #endregion Healthcare
    }
}
