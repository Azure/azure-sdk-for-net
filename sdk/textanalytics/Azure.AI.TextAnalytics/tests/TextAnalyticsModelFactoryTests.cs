// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.TextAnalytics;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TextAnalyticsModelFactory"/> class.
    /// </summary>
    public class TextAnalyticsModelFactoryTests
    {
        #region Extract Summary

        [Test]
        public void ExtractSummaryResultWithoutError()
        {
            var id = "id";
            var statistics = TextAnalyticsModelFactory.TextDocumentStatistics(10, 20);
            var sentenceCollection = TextAnalyticsModelFactory.SummarySentenceCollection(new List<SummarySentence>());

            var extractSummaryResult = TextAnalyticsModelFactory.ExtractSummaryResult(id, statistics, sentenceCollection);

            Assert.AreEqual(id, extractSummaryResult.Id);
            Assert.AreEqual(statistics, extractSummaryResult.Statistics);
            Assert.AreEqual(sentenceCollection, extractSummaryResult.Sentences);

            Assert.IsFalse(extractSummaryResult.HasError);
            Assert.AreEqual(default(TextAnalyticsError), extractSummaryResult.Error);
        }

        [Test]
        public void ExtractSummaryResultWithError()
        {
            var id = "id";
            var error = TextAnalyticsModelFactory.TextAnalyticsError("code", "message", "target");

            var extractSummaryResult = TextAnalyticsModelFactory.ExtractSummaryResult(id, error);

            Assert.AreEqual(id, extractSummaryResult.Id);
            Assert.AreEqual(default(TextDocumentStatistics), extractSummaryResult.Statistics);
            Assert.Throws<InvalidOperationException>(() => _ = extractSummaryResult.Sentences);

            Assert.IsTrue(extractSummaryResult.HasError);
            Assert.AreEqual(error, extractSummaryResult.Error);
        }

        [Test]
        public void ExtractSummaryResultCollection()
        {
            var extractSummaryResult1 = TextAnalyticsModelFactory.ExtractSummaryResult(default, default, default);
            var extractSummaryResult2 = TextAnalyticsModelFactory.ExtractSummaryResult(default, default, default);

            var list = new List<ExtractSummaryResult>() { extractSummaryResult1, extractSummaryResult2 };
            var statistics = TextAnalyticsModelFactory.TextDocumentBatchStatistics(10, 20, 30, 40);
            var modelVersion = "modelVersion";

            var resultCollection = TextAnalyticsModelFactory.ExtractSummaryResultCollection(list, statistics, modelVersion);

            CollectionAssert.AreEquivalent(list, resultCollection);
            Assert.AreEqual(statistics, resultCollection.Statistics);
            Assert.AreEqual(modelVersion, resultCollection.ModelVersion);
        }

        [Test]
        public void SummarySentence()
        {
            var text = "text";
            var rankScore = 0.555;
            var offset = 10;
            var length = 20;

            var summarySentence = TextAnalyticsModelFactory.SummarySentence(text, rankScore, offset, length);

            Assert.AreEqual(text, summarySentence.Text);
            Assert.AreEqual(rankScore, summarySentence.RankScore);
            Assert.AreEqual(offset, summarySentence.Offset);
            Assert.AreEqual(length, summarySentence.Length);
        }

        [Test]
        public void SummarySentenceCollection()
        {
            var sentence1 = TextAnalyticsModelFactory.SummarySentence("text1", 0.1, 10, 20);
            var sentence2 = TextAnalyticsModelFactory.SummarySentence("text2", 0.2, 30, 40);

            var warning1 = TextAnalyticsModelFactory.TextAnalyticsWarning("code1", "message1");
            var warning2 = TextAnalyticsModelFactory.TextAnalyticsWarning("code2", "message2");

            var sentences = new List<SummarySentence>() { sentence1, sentence2 };
            var warnings = new List<TextAnalyticsWarning>() { warning1, warning2 };

            var sentenceCollection = TextAnalyticsModelFactory.SummarySentenceCollection(sentences, warnings);

            CollectionAssert.AreEquivalent(sentences, sentenceCollection);
            CollectionAssert.AreEquivalent(warnings, sentenceCollection.Warnings);
        }

        #endregion Extract Summary

        #region Action Result Models

        [Test]
        public void AnalyzeActionsResult()
        {
            var extractKeyPhrasesActionResults = new List<ExtractKeyPhrasesActionResult>()
            {
                TextAnalyticsModelFactory.ExtractKeyPhrasesActionResult(default, default),
                TextAnalyticsModelFactory.ExtractKeyPhrasesActionResult(default, default)
            };

            var recognizeEntitiesActionResults = new List<RecognizeEntitiesActionResult>()
            {
                TextAnalyticsModelFactory.RecognizeEntitiesActionResult(default, default),
                TextAnalyticsModelFactory.RecognizeEntitiesActionResult(default, default)
            };

            var recognizePiiEntitiesActionResults = new List<RecognizePiiEntitiesActionResult>()
            {
                TextAnalyticsModelFactory.RecognizePiiEntitiesActionResult(default, default),
                TextAnalyticsModelFactory.RecognizePiiEntitiesActionResult(default, default)
            };

            var recognizeLinkedEntitiesActionResults = new List<RecognizeLinkedEntitiesActionResult>()
            {
                TextAnalyticsModelFactory.RecognizeLinkedEntitiesActionResult(default, default),
                TextAnalyticsModelFactory.RecognizeLinkedEntitiesActionResult(default, default)
            };

            var analyzeSentimentActionResults = new List<AnalyzeSentimentActionResult>()
            {
                TextAnalyticsModelFactory.AnalyzeSentimentActionResult(default, default),
                TextAnalyticsModelFactory.AnalyzeSentimentActionResult(default, default)
            };

            var recognizeCustomEntitiesActionResults = new List<RecognizeCustomEntitiesActionResult>()
            {
                TextAnalyticsModelFactory.RecognizeCustomEntitiesActionResult(default, default),
                TextAnalyticsModelFactory.RecognizeCustomEntitiesActionResult(default, default)
            };

            var singleCategoryClassifyActionResults = new List<SingleCategoryClassifyActionResult>()
            {
                TextAnalyticsModelFactory.SingleCategoryClassifyActionResult(default, default),
                TextAnalyticsModelFactory.SingleCategoryClassifyActionResult(default, default)
            };

            var multiCategoryClassifyActionResults = new List<MultiCategoryClassifyActionResult>()
            {
                TextAnalyticsModelFactory.MultiCategoryClassifyActionResult(default, default),
                TextAnalyticsModelFactory.MultiCategoryClassifyActionResult(default, default)
            };

            var actionsResult = TextAnalyticsModelFactory.AnalyzeActionsResult(
                extractKeyPhrasesActionResults,
                recognizeEntitiesActionResults,
                recognizePiiEntitiesActionResults,
                recognizeLinkedEntitiesActionResults,
                analyzeSentimentActionResults);

            CollectionAssert.AreEquivalent(extractKeyPhrasesActionResults, actionsResult.ExtractKeyPhrasesResults);
            CollectionAssert.AreEquivalent(recognizeEntitiesActionResults, actionsResult.RecognizeEntitiesResults);
            CollectionAssert.AreEquivalent(recognizePiiEntitiesActionResults, actionsResult.RecognizePiiEntitiesResults);
            CollectionAssert.AreEquivalent(recognizeLinkedEntitiesActionResults, actionsResult.RecognizeLinkedEntitiesResults);
            CollectionAssert.AreEquivalent(analyzeSentimentActionResults, actionsResult.AnalyzeSentimentResults);
            Assert.IsEmpty(actionsResult.ExtractSummaryResults);

            var extractSummaryActionResults = new List<ExtractSummaryActionResult>()
            {
                TextAnalyticsModelFactory.ExtractSummaryActionResult(default, default),
                TextAnalyticsModelFactory.ExtractSummaryActionResult(default, default)
            };

            actionsResult = TextAnalyticsModelFactory.AnalyzeActionsResult(
                extractKeyPhrasesActionResults,
                recognizeEntitiesActionResults,
                recognizePiiEntitiesActionResults,
                recognizeLinkedEntitiesActionResults,
                analyzeSentimentActionResults,
                extractSummaryActionResults,
                recognizeCustomEntitiesActionResults,
                singleCategoryClassifyActionResults,
                multiCategoryClassifyActionResults);

            CollectionAssert.AreEquivalent(extractKeyPhrasesActionResults, actionsResult.ExtractKeyPhrasesResults);
            CollectionAssert.AreEquivalent(recognizeEntitiesActionResults, actionsResult.RecognizeEntitiesResults);
            CollectionAssert.AreEquivalent(recognizePiiEntitiesActionResults, actionsResult.RecognizePiiEntitiesResults);
            CollectionAssert.AreEquivalent(recognizeLinkedEntitiesActionResults, actionsResult.RecognizeLinkedEntitiesResults);
            CollectionAssert.AreEquivalent(analyzeSentimentActionResults, actionsResult.AnalyzeSentimentResults);
            CollectionAssert.AreEquivalent(extractSummaryActionResults, actionsResult.ExtractSummaryResults);
            CollectionAssert.AreEquivalent(recognizeCustomEntitiesActionResults, actionsResult.RecognizeCustomEntitiesResults);
            CollectionAssert.AreEquivalent(singleCategoryClassifyActionResults, actionsResult.SingleCategoryClassifyResults);
            CollectionAssert.AreEquivalent(multiCategoryClassifyActionResults, actionsResult.MultiCategoryClassifyResults);
        }

        [Test]
        public void ExtractSummaryActionResultWithoutError()
        {
            var result = TextAnalyticsModelFactory.ExtractSummaryResultCollection(new List<ExtractSummaryResult>(), default, default);
            var completedOn = DateTimeOffset.UtcNow;
            string actionName = "ExtractSummary";

            var actionResult = TextAnalyticsModelFactory.ExtractSummaryActionResult(result, actionName, completedOn);

            Assert.AreEqual(result, actionResult.DocumentsResults);
            Assert.AreEqual(completedOn, actionResult.CompletedOn);

            Assert.IsFalse(actionResult.HasError);
            Assert.AreEqual(default(TextAnalyticsError), actionResult.Error);
        }

        [Test]
        public void ExtractSummaryActionResultWithError()
        {
            var completedOn = DateTimeOffset.UtcNow;
            var code = "code";
            var message = "message";
            string actionName = "ExtractSummary";

            var actionResult = TextAnalyticsModelFactory.ExtractSummaryActionResult(actionName, completedOn, code, message);

            Assert.Throws<InvalidOperationException>(() => _ = actionResult.DocumentsResults);
            Assert.AreEqual(completedOn, actionResult.CompletedOn);

            Assert.IsTrue(actionResult.HasError);
            Assert.AreEqual(code, actionResult.Error.ErrorCode.ToString());
            Assert.AreEqual(message, actionResult.Error.Message);
        }

        #endregion Action Result Models
    }
}
