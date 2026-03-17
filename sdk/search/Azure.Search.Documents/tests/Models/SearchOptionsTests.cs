// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public sealed class SearchOptionsTests
    {
        [Test]
        public void QueryTypeOption()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryType);

            // We can set `QueryType` to one of the valid values from the `SearchQueryType` enum.
            searchOptions.QueryType = SearchQueryType.Full;
            Assert.AreEqual(SearchQueryType.Full, searchOptions.QueryType);

            searchOptions.QueryType = SearchQueryType.Semantic;
            Assert.AreEqual(SearchQueryType.Semantic, searchOptions.QueryType);

            searchOptions.QueryType = SearchQueryType.Simple;
            Assert.AreEqual(SearchQueryType.Simple, searchOptions.QueryType);
        }

        [Test]
        public void QueryAnswerOptionWithNoCountAndThreshold()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.None);
            Assert.AreEqual($"{QueryAnswerType.None}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            Assert.AreEqual($"{QueryAnswerType.Extractive}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("none");
            Assert.AreEqual(QueryAnswerType.None, searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyCount()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            searchOptions.SemanticSearch.QueryAnswer.Count = 0;
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual("extractive|count-0", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual(QueryAnswerType.Extractive, searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            Assert.AreEqual(100, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual("extractive|count-100", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual(QueryAnswerType.Extractive, searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|count-3";
            Assert.AreEqual(3, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual("unknown", $"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}");
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyThreshold()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0;
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.AreEqual("extractive|threshold-0", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual(QueryAnswerType.Extractive, searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;
            Assert.AreEqual(0.9, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.AreEqual("extractive|threshold-0.9", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual(QueryAnswerType.Extractive, searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|threshold-0.5";
            Assert.AreEqual(0.5, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.AreEqual("unknown", $"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}");
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
        }

        [Test]
        public void QueryAnswerOptionWithCountAndThreshold()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            searchOptions.SemanticSearch.QueryAnswer.Count = 0;
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0;
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual("extractive|count-0,threshold-0", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual(QueryAnswerType.Extractive, searchOptions.SemanticSearch.QueryAnswer.AnswerType);

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;
            Assert.AreEqual(100, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual(0.9, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.AreEqual("extractive|count-100,threshold-0.9", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual(QueryAnswerType.Extractive, searchOptions.SemanticSearch.QueryAnswer.AnswerType);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|threshold-0.5,count-3";
            Assert.AreEqual(3, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual(0.5, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.AreEqual("unknown", $"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}");
        }

        [Test]
        public void QueryAnswerOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            // We can set `QueryAnswer` to one of the known values, using either a string or a pre-defined value.
            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("none") { Count = 3, Threshold = 0.9  };
            Assert.AreEqual($"{QueryAnswerType.None}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.None) { Count = 3, Threshold = 0.9 };
            Assert.AreEqual($"{QueryAnswerType.None}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("extractive") { Count = 3, Threshold = 0.9 };
            Assert.AreEqual($"{QueryAnswerType.Extractive}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive) { Count = 3, Threshold = 0.9 };
            Assert.AreEqual($"{QueryAnswerType.Extractive}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            // We can also set `QueryAnswer` to a value unknown to the SDK.
            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("unknown") { Count = 3, Threshold = 0.9 };
            Assert.AreEqual($"unknown|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(new QueryAnswerType("unknown")) { Count = 3, Threshold = 0.9 };
            Assert.AreEqual($"unknown|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|count-10,threshold-0.8";
            Assert.AreEqual("unknown", $"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}");
            Assert.AreEqual(10, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual(0.8, searchOptions.SemanticSearch.QueryAnswer.Threshold);
        }

        [Test]
        public void QueryCaptionOptionWithNoHighlight()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.None);
            Assert.AreEqual($"{QueryCaptionType.None}", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.True(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.Extractive);
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-True", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.True(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption("none");
            Assert.AreEqual(QueryCaptionType.None, searchOptions.SemanticSearch.QueryCaption.CaptionType);
            Assert.True(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
        }

        [Test]
        public void QueryCaptionOptionWithHighlight()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.Extractive) { HighlightEnabled = false };
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-False", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.False(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
        }

        [Test]
        public void QueryCaptionOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            // We can set `QueryCaption` to one of the known values, using either a string or a predefined value.
            searchOptions.SemanticSearch.QueryCaption = new QueryCaption("none");
            Assert.AreEqual($"{QueryCaptionType.None}", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.None);
            Assert.AreEqual($"{QueryCaptionType.None}", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.HighlightEnabled = false;

            searchOptions.SemanticSearch.QueryCaption.CaptionType = "extractive";
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-False", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.CaptionType = QueryCaptionType.Extractive;
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-False", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.HighlightEnabled = true;

            // We can also set `QueryCaption` to a value unknown to the SDK.
            searchOptions.SemanticSearch.QueryCaption.CaptionType = "unknown";
            Assert.AreEqual($"unknown", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(new QueryAnswerType("unknown"));
            Assert.AreEqual($"unknown", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw = "unknown";
            Assert.AreEqual("unknown", $"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}");
            Assert.True(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
        }

        [Test]
        public void SearchOptionsForSemanticSearch()
        {
            var searchOptions = new SearchOptions
            {
                QueryType = SearchQueryType.Semantic,
                SemanticSearch = new()
                {
                    SemanticConfigurationName = "my-semantic-config",
                    QueryCaption = new(QueryCaptionType.Extractive),
                    QueryAnswer = new(QueryAnswerType.Extractive){ Count = 5, Threshold = 0.8 }
                },
            };

            Assert.AreEqual("extractive|count-5,threshold-0.8", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual("extractive|highlight-True", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
        }

        [Test]
        public void VectorSearchOption()
        {
            SearchOptions searchOptions = new();
            Assert.IsNull(searchOptions.VectorSearch);

            searchOptions.VectorSearch = new();
            ReadOnlyMemory<float> vectors = new float[] { -0.011113605f, -0.01902812f, 0.047524072f };
            searchOptions.VectorSearch.Queries = new[] { new VectorizedQuery(vectors) };

            Assert.AreEqual(1, searchOptions.VectorSearch.Queries.Count);
            Assert.AreEqual(vectors, (searchOptions.VectorSearch.Queries[0] as VectorizedQuery).Vector);
            Assert.IsNull(searchOptions.VectorSearch.FilterMode);

            searchOptions.VectorSearch.FilterMode = VectorFilterMode.PostFilter;
            Assert.AreEqual(1, searchOptions.VectorSearch.Queries.Count);
            Assert.AreEqual(vectors, (searchOptions.VectorSearch.Queries[0] as VectorizedQuery).Vector);
            Assert.AreEqual(VectorFilterMode.PostFilter, searchOptions.VectorSearch.FilterMode);
        }
    }
}
