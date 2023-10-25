// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = QueryAnswerType.None;
            Assert.AreEqual($"{QueryAnswerType.None}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = QueryAnswerType.Extractive;
            Assert.AreEqual($"{QueryAnswerType.Extractive}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "none";
            Assert.AreEqual(QueryAnswerType.None, searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyCount()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.Count = 0;
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            Assert.AreEqual(100, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "|count-3";
            Assert.AreEqual(3, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyThreshold()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0;
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;
            Assert.AreEqual(0.9, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "|threshold-0.5";
            Assert.AreEqual(0.5, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
        }

        [Test]
        public void QueryAnswerOptionWithCountAndThreshold()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.Count = 0;
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0;
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual(0, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;
            Assert.AreEqual(100, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual(0.9, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "|threshold-0.5,count-3";
            Assert.AreEqual(3, searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.AreEqual(0.5, searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.AnswerType);
        }

        [Test]
        public void QueryAnswerOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch.QueryAnswer.Count = 3;
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;

            // We can set `QueryAnswer` to one of the known values, using either a string or a pre-defined value.
            searchOptions.SemanticSearch.QueryAnswer.AnswerType = "none";
            Assert.AreEqual($"{QueryAnswerType.None}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = QueryAnswerType.None;
            Assert.AreEqual($"{QueryAnswerType.None}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = "extractive";
            Assert.AreEqual($"{QueryAnswerType.Extractive}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = QueryAnswerType.Extractive;
            Assert.AreEqual($"{QueryAnswerType.Extractive}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            // We can also set `QueryAnswer` to a value unknown to the SDK.
            searchOptions.SemanticSearch.QueryAnswer.AnswerType = "unknown";
            Assert.AreEqual($"unknown|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold}", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = new QueryAnswerType("unknown");
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

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.CaptionType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.CaptionType = QueryCaptionType.None;
            Assert.AreEqual($"{QueryCaptionType.None}", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);

            searchOptions.SemanticSearch.QueryCaption.CaptionType = QueryCaptionType.Extractive;
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-True", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);

            searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw = "none";
            Assert.AreEqual(QueryCaptionType.None, searchOptions.SemanticSearch.QueryCaption.CaptionType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
        }

        [Test]
        public void QueryCaptionOptionWithOnlyHighlight()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.CaptionType);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.HighlightEnabled = true;
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.CaptionType);

            searchOptions.SemanticSearch.QueryCaption.HighlightEnabled = false;
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.CaptionType);
        }

        [Test]
        public void QueryCaptionOption()
        {
            SearchOptions searchOptions = new();

            // We can set `QueryCaption` to one of the known values, using either a string or a predefined value.
            searchOptions.SemanticSearch.QueryCaption.CaptionType = "none";
            Assert.AreEqual($"{QueryCaptionType.None}", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.CaptionType = QueryCaptionType.None;
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

            searchOptions.SemanticSearch.QueryAnswer.AnswerType = new QueryAnswerType("unknown");
            Assert.AreEqual($"unknown", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);

            searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw = "unknown";
            Assert.AreEqual("unknown", $"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}");
            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled);
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
                    QueryCaption = new() { CaptionType = QueryCaptionType.Extractive },
                    QueryAnswer = new() { AnswerType = QueryAnswerType.Extractive, Count = 5, Threshold = 0.8 }
                },
            };

            Assert.AreEqual("extractive|count-5,threshold-0.8", searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw);
            Assert.AreEqual("extractive|highlight-True", searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw);
        }

        [Test]
        public void VectorSearchOption()
        {
            SearchOptions searchOptions = new();
            Assert.IsEmpty(searchOptions.VectorSearch.VectorizableQueries);
            Assert.IsNull(searchOptions.VectorSearch.FilterMode);

            IReadOnlyList<float> vectors = new List<float> { -0.011113605f, -0.01902812f, 0.047524072f };
            searchOptions.VectorSearch.VectorizableQueries = new[] { new VectorQuery(vectors) };

            Assert.AreEqual(1, searchOptions.VectorSearch.VectorizableQueries.Count);
            Assert.AreEqual(vectors, (searchOptions.VectorSearch.VectorizableQueries[0] as VectorQuery).Vector);
            Assert.IsNull(searchOptions.VectorSearch.FilterMode);

            searchOptions.VectorSearch.FilterMode = VectorFilterMode.PostFilter;
            Assert.AreEqual(1, searchOptions.VectorSearch.VectorizableQueries.Count);
            Assert.AreEqual(vectors, (searchOptions.VectorSearch.VectorizableQueries[0] as VectorQuery).Vector);
            Assert.AreEqual(VectorFilterMode.PostFilter, searchOptions.VectorSearch.FilterMode);
        }
    }
}
