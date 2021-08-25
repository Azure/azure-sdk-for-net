﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public void QueryAnswerOptionWithNoCount()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = QueryAnswer.None;
            Assert.AreEqual($"{QueryAnswer.None}|count-1", searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswerCount);

            searchOptions.QueryAnswer = QueryAnswer.Extractive;
            Assert.AreEqual($"{QueryAnswer.Extractive}|count-1", searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswerCount);

            searchOptions.QueryAnswerRaw = "none";
            Assert.AreEqual(QueryAnswer.None, searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyCount()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryAnswer);
            Assert.IsNull(searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswerCount = 0;
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);

            searchOptions.QueryAnswerCount = 100;
            Assert.IsNull(searchOptions.QueryAnswerRaw);
            Assert.IsNull(searchOptions.QueryAnswer);

            searchOptions.QueryAnswerRaw = "|count-3";
            Assert.AreEqual(3, searchOptions.QueryAnswerCount);
            Assert.IsNull(searchOptions.QueryAnswer);
        }

        [Test]
        public void QueryAnswerOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.QueryAnswerCount = 3;

            // We can set `QueryAnswer` to one of the known values, using either a string or a pre-defined value.
            searchOptions.QueryAnswer = "none";
            Assert.AreEqual($"{QueryAnswer.None}|count-{searchOptions.QueryAnswerCount}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = QueryAnswer.None;
            Assert.AreEqual($"{QueryAnswer.None}|count-{searchOptions.QueryAnswerCount}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = "extractive";
            Assert.AreEqual($"{QueryAnswer.Extractive}|count-{searchOptions.QueryAnswerCount}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = QueryAnswer.Extractive;
            Assert.AreEqual($"{QueryAnswer.Extractive}|count-{searchOptions.QueryAnswerCount}", searchOptions.QueryAnswerRaw);

            // We can also set `QueryAnswer` to a value unknown to the SDK.
            searchOptions.QueryAnswer = "unknown";
            Assert.AreEqual($"unknown|count-{searchOptions.QueryAnswerCount}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswer = new QueryAnswer("unknown");
            Assert.AreEqual($"unknown|count-{searchOptions.QueryAnswerCount}", searchOptions.QueryAnswerRaw);

            searchOptions.QueryAnswerRaw = "unknown|count-10";
            Assert.AreEqual("unknown", $"{searchOptions.QueryAnswer}");
            Assert.AreEqual(10, searchOptions.QueryAnswerCount);
        }

        [Test]
        public void QueryCaptionOptionWithNoHighlight()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryCaption);
            Assert.IsNull(searchOptions.QueryCaptionHighlight);
            Assert.IsNull(searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaption = QueryCaption.None;
            Assert.AreEqual($"{QueryCaption.None}|highlight-True", searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaptionHighlight);

            searchOptions.QueryCaption = QueryCaption.Extractive;
            Assert.AreEqual($"{QueryCaption.Extractive}|highlight-True", searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaptionHighlight);

            searchOptions.QueryCaptionRaw = "none";
            Assert.AreEqual(QueryCaption.None, searchOptions.QueryCaption);
            Assert.IsNull(searchOptions.QueryCaptionHighlight);
        }

        [Test]
        public void QueryCaptionOptionWithOnlyHighlight()
        {
            SearchOptions searchOptions = new();

            Assert.IsNull(searchOptions.QueryCaption);
            Assert.IsNull(searchOptions.QueryCaptionHighlight);
            Assert.IsNull(searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionHighlight = true;
            Assert.IsNull(searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaption);

            searchOptions.QueryCaptionHighlight = false;
            Assert.IsNull(searchOptions.QueryCaptionRaw);
            Assert.IsNull(searchOptions.QueryCaption);
        }

        [Test]
        public void QueryCaptionOption()
        {
            SearchOptions searchOptions = new();

            // We can set `QueryCaption` to one of the known values, using either a string or a predefined value.
            searchOptions.QueryCaption = "none";
            Assert.AreEqual($"{QueryCaption.None}|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaption = QueryCaption.None;
            Assert.AreEqual($"{QueryCaption.None}|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionHighlight = false;

            searchOptions.QueryCaption = "extractive";
            Assert.AreEqual($"{QueryCaption.Extractive}|highlight-False", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaption = QueryCaption.Extractive;
            Assert.AreEqual($"{QueryCaption.Extractive}|highlight-False", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionHighlight = true;

            // We can also set `QueryCaption` to a value unknown to the SDK.
            searchOptions.QueryCaption = "unknown";
            Assert.AreEqual($"unknown|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryAnswer = new QueryAnswer("unknown");
            Assert.AreEqual($"unknown|highlight-True", searchOptions.QueryCaptionRaw);

            searchOptions.QueryCaptionRaw = "unknown";
            Assert.AreEqual("unknown", $"{searchOptions.QueryAnswer}");
            Assert.IsNull(searchOptions.QueryCaptionHighlight);

            searchOptions.QueryCaptionRaw = "unknown|highlight-False";
            Assert.AreEqual("unknown", $"{searchOptions.QueryAnswer}");
            Assert.AreEqual(false, searchOptions.QueryCaptionHighlight);
        }

        [Test]
        public void SearchOptionsForSemanticSearch()
        {
            SearchOptions semanticSearchOptions = new()
            {
                QueryType = SearchQueryType.Semantic,
                QueryLanguage = QueryLanguage.EnUs,
                QueryAnswer = QueryAnswer.Extractive,
                QueryAnswerCount = 5,
                QueryCaption = QueryCaption.Extractive,
            };

            Assert.AreEqual("extractive|count-5", semanticSearchOptions.QueryAnswerRaw);
            Assert.AreEqual("extractive|highlight-True", semanticSearchOptions.QueryCaptionRaw);
        }
    }
}
