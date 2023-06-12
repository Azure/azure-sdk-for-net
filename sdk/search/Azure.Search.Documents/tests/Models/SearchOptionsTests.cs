// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
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
        public void QueryLanguageOption()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryLanguage);

            // We can set `QueryLanguage` to one of the known values, using either a string or a pre-defined value.
            searchOptions.QueryLanguage = "en-us";
            Assert.AreEqual(QueryLanguage.EnUs, searchOptions.QueryLanguage);

            searchOptions.QueryLanguage = QueryLanguage.EnUs;
            Assert.AreEqual(QueryLanguage.EnUs, searchOptions.QueryLanguage);

            // We can also set `QueryLanguage` to a value unknown to the SDK.
            searchOptions.QueryLanguage = "unknown";
            Assert.AreEqual("unknown", searchOptions.QueryLanguage.ToString());
        }

        [Test]
        public void QueryAnswerOptionWithNoCountAndThreshold()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = QueryAnswerType.None;
            Assert.AreEqual($"{QueryAnswerType.None}", searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);

            searchOptions.QueryAnswer = QueryAnswerType.Extractive;
            Assert.AreEqual($"{QueryAnswerType.Extractive}", searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswerCount);

            searchOptions.QueryAnswerRaw = "none";
            Assert.AreEqual(QueryAnswerType.None, searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyCount()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswerCount = 0;
            Assert.AreEqual(0, searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);

            searchOptions.QueryAnswerCount = 100;
            Assert.AreEqual(100, searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);

            searchOptions.QueryAnswerRaw = "|count-3";
            Assert.AreEqual(3, searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyThreshold()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswerThreshold = 0;
            Assert.AreEqual(0, searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);

            searchOptions.QueryAnswerThreshold = 0.9;
            Assert.AreEqual(0.9, searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);

            searchOptions.QueryAnswerRaw = "|threshold-0.5";
            Assert.AreEqual(0.5, searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
        }

        [Test]
        public void QueryAnswerOptionWithCountAndThreshold()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswerCount = 0;
            searchOptions.QueryAnswerThreshold = 0;
            Assert.AreEqual(0, searchOptions.QueryAnswerCount);
            Assert.AreEqual(0, searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);

            searchOptions.QueryAnswerCount = 100;
            searchOptions.QueryAnswerThreshold = 0.9;
            Assert.AreEqual(100, searchOptions.QueryAnswerCount);
            Assert.AreEqual(0.9, searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);

            searchOptions.QueryAnswerRaw = "|threshold-0.5,count-3";
            Assert.AreEqual(3, searchOptions.QueryAnswerCount);
            Assert.AreEqual(0.5, searchOptions.QueryAnswerThreshold);
            Assert.IsNull(searchOptions.QueryAnswer);
        }

        [Test]
        public void QueryAnswerOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.QueryAnswerCount = 3;
            searchOptions.QueryAnswerThreshold = 0.9;

            // We can set `QueryAnswer` to one of the known values, using either a string or a pre-defined value.
            searchOptions.QueryAnswer = "none";
            Assert.AreEqual($"{QueryAnswerType.None}|count-{searchOptions.QueryAnswerCount},threshold-{searchOptions.QueryAnswerThreshold}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = QueryAnswerType.None;
            Assert.AreEqual($"{QueryAnswerType.None}|count-{searchOptions.QueryAnswerCount},threshold-{searchOptions.QueryAnswerThreshold}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = "extractive";
            Assert.AreEqual($"{QueryAnswerType.Extractive}|count-{searchOptions.QueryAnswerCount},threshold-{searchOptions.QueryAnswerThreshold}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = QueryAnswerType.Extractive;
            Assert.AreEqual($"{QueryAnswerType.Extractive}|count-{searchOptions.QueryAnswerCount},threshold-{searchOptions.QueryAnswerThreshold}", searchOptions.QueryAnswerRaw);

            // We can also set `QueryAnswer` to a value unknown to the SDK.
            searchOptions.QueryAnswer = "unknown";
            Assert.AreEqual($"unknown|count-{searchOptions.QueryAnswerCount},threshold-{searchOptions.QueryAnswerThreshold}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = new QueryAnswerType("unknown");
            Assert.AreEqual($"unknown|count-{searchOptions.QueryAnswerCount},threshold-{searchOptions.QueryAnswerThreshold}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswerRaw = "unknown|count-10,threshold-0.8";
            Assert.AreEqual("unknown", $"{searchOptions.QueryAnswer}");
            Assert.AreEqual(10, searchOptions.QueryAnswerCount);
            Assert.AreEqual(0.8, searchOptions.QueryAnswerThreshold);
        }

        [Test]
        public void QueryCaptionOptionWithNoHighlight()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryCaption);
            Assert.IsNull(searchOptions.QueryCaptionHighlightEnabled);
            Assert.IsNull(searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaption = QueryCaptionType.None;
            Assert.AreEqual($"{QueryCaptionType.None}|highlight-True", searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaptionHighlightEnabled);

            searchOptions.QueryCaption = QueryCaptionType.Extractive;
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-True", searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaptionHighlightEnabled);

            searchOptions.QueryCaptionRaw = "none";
            Assert.AreEqual(QueryCaptionType.None, searchOptions.QueryCaption);
            Assert.IsNull(searchOptions.QueryCaptionHighlightEnabled);
        }

        [Test]
        public void QueryCaptionOptionWithOnlyHighlight()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryCaption);
            Assert.IsNull(searchOptions.QueryCaptionHighlightEnabled);
            Assert.IsNull(searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionHighlightEnabled = true;
            Assert.IsNull(searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaption);

            searchOptions.QueryCaptionHighlightEnabled = false;
            Assert.IsNull(searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaption);
        }

        [Test]
        public void QueryCaptionOption()
        {
            SearchOptions searchOptions = new();

            // We can set `QueryCaption` to one of the known values, using either a string or a predefined value.
            searchOptions.QueryCaption = "none";
            Assert.AreEqual($"{QueryCaptionType.None}|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaption = QueryCaptionType.None;
            Assert.AreEqual($"{QueryCaptionType.None}|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionHighlightEnabled = false;

            searchOptions.QueryCaption = "extractive";
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-False", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaption = QueryCaptionType.Extractive;
            Assert.AreEqual($"{QueryCaptionType.Extractive}|highlight-False", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionHighlightEnabled = true;

            // We can also set `QueryCaption` to a value unknown to the SDK.
            searchOptions.QueryCaption = "unknown";
            Assert.AreEqual($"unknown|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryAnswer = new QueryAnswerType("unknown");
            Assert.AreEqual($"unknown|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionRaw = "unknown";
            Assert.AreEqual("unknown", $"{searchOptions.QueryAnswer}");
            Assert.IsNull(searchOptions.QueryCaptionHighlightEnabled);

            searchOptions.QueryCaptionRaw = "unknown|highlight-False";
            Assert.AreEqual("unknown", $"{searchOptions.QueryAnswer}");
            Assert.AreEqual(false, searchOptions.QueryCaptionHighlightEnabled);
        }

        [Test]
        public void SearchOptionsForSemanticSearch()
        {
            SearchOptions semanticSearchOptions = new()
            {
                QueryType = SearchQueryType.Semantic,
                QueryLanguage = QueryLanguage.EnUs,
                QueryAnswer = QueryAnswerType.Extractive,
                QueryAnswerCount = 5,
                QueryAnswerThreshold = 0.8,
                QueryCaption = QueryCaptionType.Extractive,
            };

            Assert.AreEqual("extractive|count-5,threshold-0.8", semanticSearchOptions.QueryAnswerRaw);
            Assert.AreEqual("extractive|highlight-True", semanticSearchOptions.QueryCaptionRaw);
        }
    }
}
