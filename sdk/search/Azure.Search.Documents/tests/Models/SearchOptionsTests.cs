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
            Assert.That(searchOptions.QueryType, Is.EqualTo(SearchQueryType.Full));

            searchOptions.QueryType = SearchQueryType.Semantic;
            Assert.That(searchOptions.QueryType, Is.EqualTo(SearchQueryType.Semantic));

            searchOptions.QueryType = SearchQueryType.Simple;
            Assert.That(searchOptions.QueryType, Is.EqualTo(SearchQueryType.Simple));
        }

        [Test]
        public void QueryAnswerOptionWithNoCountThresholdAndMaxCharLength()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.None);
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"{QueryAnswerType.None}"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"{QueryAnswerType.Extractive}"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("none");
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.None));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyCount()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            searchOptions.SemanticSearch.QueryAnswer.Count = 0;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(0));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-0"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(100));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-100"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|count-3";
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(3));
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
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
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Threshold, Is.EqualTo(0));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|threshold-0"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Threshold, Is.EqualTo(0.9));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|threshold-0.9"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|threshold-0.5";
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Threshold, Is.EqualTo(0.5));
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);
        }

        [Test]
        public void QueryAnswerOptionWithOnlyMaxCharLength()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            searchOptions.SemanticSearch.QueryAnswer.MaxCharLength = 1;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(1));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|maxcharlength-1"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.MaxCharLength = 300;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(300));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|maxcharlength-300"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Count);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|maxcharlength-300";
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(300));
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
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
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(0));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-0,threshold-0"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            searchOptions.SemanticSearch.QueryAnswer.Threshold = 0.9;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(100));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Threshold, Is.EqualTo(0.9));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-100,threshold-0.9"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|threshold-0.5,count-3";
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(3));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Threshold, Is.EqualTo(0.5));
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
        }

        [Test]
        public void QueryAnswerOptionWithCountAndMaxCharLength()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer);

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive);
            searchOptions.SemanticSearch.QueryAnswer.Count = 0;
            searchOptions.SemanticSearch.QueryAnswer.MaxCharLength = 0;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(0));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(0));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-0,maxcharlength-0"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.Count = 100;
            searchOptions.SemanticSearch.QueryAnswer.MaxCharLength = 300;
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(100));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(300));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-100,maxcharlength-300"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.AnswerType, Is.EqualTo(QueryAnswerType.Extractive));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|maxcharlength-500,count-3";
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(3));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(500));
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryAnswer.Threshold);
        }

        [Test]
        public void QueryAnswerOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            // We can set `QueryAnswer` to one of the known values, using either a string or a pre-defined value.
            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("none") { Count = 3, Threshold = 0.9, MaxCharLength = 300  };
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"{QueryAnswerType.None}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold},maxcharlength-{searchOptions.SemanticSearch.QueryAnswer.MaxCharLength}"));

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.None) { Count = 3, Threshold = 0.9, MaxCharLength = 300 };
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"{QueryAnswerType.None}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold},maxcharlength-{searchOptions.SemanticSearch.QueryAnswer.MaxCharLength}"));

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("extractive") { Count = 3, Threshold = 0.9, MaxCharLength = 300 };
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"{QueryAnswerType.Extractive}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold},maxcharlength-{searchOptions.SemanticSearch.QueryAnswer.MaxCharLength}"));

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive) { Count = 3, Threshold = 0.9, MaxCharLength = 300 };
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"{QueryAnswerType.Extractive}|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold},maxcharlength-{searchOptions.SemanticSearch.QueryAnswer.MaxCharLength}"));

            // We can also set `QueryAnswer` to a value unknown to the SDK.
            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer("unknown") { Count = 3, Threshold = 0.9, MaxCharLength = 300 };
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"unknown|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold},maxcharlength-{searchOptions.SemanticSearch.QueryAnswer.MaxCharLength}"));

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(new QueryAnswerType("unknown")) { Count = 3, Threshold = 0.9, MaxCharLength = 300 };
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo($"unknown|count-{searchOptions.SemanticSearch.QueryAnswer.Count},threshold-{searchOptions.SemanticSearch.QueryAnswer.Threshold},maxcharlength-{searchOptions.SemanticSearch.QueryAnswer.MaxCharLength}"));

            searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw = "unknown|count-10,threshold-0.8,maxcharlength-400";
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Count, Is.EqualTo(10));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.Threshold, Is.EqualTo(0.8));
            Assert.That(searchOptions.SemanticSearch.QueryAnswer.MaxCharLength, Is.EqualTo(400));
        }

        [Test]
        public void QueryCaptionOptionWithNoHighlight()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.None);
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.None}"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled, Is.True);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.Extractive);
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-True"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled, Is.True);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption("none");
            Assert.That(searchOptions.SemanticSearch.QueryCaption.CaptionType, Is.EqualTo(QueryCaptionType.None));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled, Is.True);
        }

        [Test]
        public void QueryCaptionOptionWithHighlight()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.Extractive) { HighlightEnabled = false };
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-False"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled, Is.False);
        }

        [Test]
        public void QueryCaptionOptionWithMaxLengthChar()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryCaption);

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.Extractive) { MaxCharLength = 300 };
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-True,maxcharlength-300"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled, Is.True);
            Assert.That(searchOptions.SemanticSearch.QueryCaption.MaxCharLength, Is.EqualTo(300));
        }

        [Test]
        public void QueryCaptionOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            // We can set `QueryCaption` to one of the known values, using either a string or a predefined value.
            searchOptions.SemanticSearch.QueryCaption = new QueryCaption("none");
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.None}"));

            searchOptions.SemanticSearch.QueryCaption = new QueryCaption(QueryCaptionType.None);
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.None}"));

            searchOptions.SemanticSearch.QueryCaption.HighlightEnabled = false;

            searchOptions.SemanticSearch.QueryCaption.CaptionType = "extractive";
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-False"));

            searchOptions.SemanticSearch.QueryCaption.CaptionType = QueryCaptionType.Extractive;
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-False"));

            searchOptions.SemanticSearch.QueryCaption.MaxCharLength = 300;
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-False,maxcharlength-300"));

            searchOptions.SemanticSearch.QueryCaption.HighlightEnabled = true;
            searchOptions.SemanticSearch.QueryCaption.MaxCharLength = 300;
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"{QueryCaptionType.Extractive}|highlight-True,maxcharlength-300"));

            // We can also set `QueryCaption` to a value unknown to the SDK.
            searchOptions.SemanticSearch.QueryCaption.CaptionType = "unknown";
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"unknown"));

            searchOptions.SemanticSearch.QueryAnswer = new QueryAnswer(new QueryAnswerType("unknown"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo($"unknown"));

            searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw = "unknown";
            Assert.That($"{searchOptions.SemanticSearch.QueryAnswer.AnswerType}", Is.EqualTo("unknown"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.HighlightEnabled, Is.True);
        }

        [Test]
        public void QueryRewritesOptionWithNoCount()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryRewrites);

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites(QueryRewritesType.None);
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw, Is.EqualTo($"{QueryRewritesType.None}"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryRewrites.Count);

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites(QueryRewritesType.Generative);
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw, Is.EqualTo($"{QueryRewritesType.Generative}"));
            Assert.IsNull(searchOptions.SemanticSearch.QueryRewrites.Count);

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites("none");
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.RewritesType, Is.EqualTo(QueryRewritesType.None));
            Assert.IsNull(searchOptions.SemanticSearch.QueryRewrites.Count);
        }

        [Test]
        public void QueryRewritesOptionWithCount()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            Assert.IsNull(searchOptions.SemanticSearch.QueryRewrites);

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites(QueryRewritesType.Generative);
            searchOptions.SemanticSearch.QueryRewrites.Count = 0;
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.Count, Is.EqualTo(0));
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw, Is.EqualTo("generative|count-0"));
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.RewritesType, Is.EqualTo(QueryRewritesType.Generative));

            searchOptions.SemanticSearch.QueryRewrites.Count = 100;
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.Count, Is.EqualTo(100));
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw, Is.EqualTo("generative|count-100"));
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.RewritesType, Is.EqualTo(QueryRewritesType.Generative));

            searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw = "unknown|count-3";
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.Count, Is.EqualTo(3));
            Assert.That($"{searchOptions.SemanticSearch.QueryRewrites.RewritesType}", Is.EqualTo("unknown"));
        }

        [Test]
        public void QueryRewritesOption()
        {
            SearchOptions searchOptions = new();
            searchOptions.SemanticSearch = new SemanticSearchOptions();

            // We can set `QueryRewrites` to one of the known values, using either a string or a pre-defined value.
            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites("none") { Count = 3 };
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw,
                Is.EqualTo($"{QueryRewritesType.None}|count-{searchOptions.SemanticSearch.QueryRewrites.Count}"));

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites(QueryRewritesType.None) { Count = 4 };
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw,
                Is.EqualTo($"{QueryRewritesType.None}|count-{searchOptions.SemanticSearch.QueryRewrites.Count}"));

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites("generative") { Count = 5};
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw,
                Is.EqualTo($"{QueryRewritesType.Generative}|count-{searchOptions.SemanticSearch.QueryRewrites.Count}"));

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites(QueryRewritesType.Generative) { Count = 6 };
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw,
                Is.EqualTo($"{QueryRewritesType.Generative}|count-{searchOptions.SemanticSearch.QueryRewrites.Count}"));

            // We can also set `QueryRewrites` to a value unknown to the SDK.
            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites("unknown") { Count = 7 };
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw,
                Is.EqualTo($"unknown|count-{searchOptions.SemanticSearch.QueryRewrites.Count}"));

            searchOptions.SemanticSearch.QueryRewrites = new QueryRewrites(new QueryRewritesType("unknown")) { Count = 8 };
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw,
                Is.EqualTo($"unknown|count-{searchOptions.SemanticSearch.QueryRewrites.Count}"));

            searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw = "unknown|count-9";
            Assert.That($"{searchOptions.SemanticSearch.QueryRewrites.RewritesType}", Is.EqualTo("unknown"));
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.Count, Is.EqualTo(9));
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
                    QueryCaption = new(QueryCaptionType.Extractive) { MaxCharLength = 300},
                    QueryAnswer = new(QueryAnswerType.Extractive){ Count = 5, Threshold = 0.8, MaxCharLength = 300 },
                    QueryRewrites = new(QueryRewritesType.Generative) { Count = 3 }
                },
            };

            Assert.That(searchOptions.SemanticSearch.QueryAnswer.QueryAnswerRaw, Is.EqualTo("extractive|count-5,threshold-0.8,maxcharlength-300"));
            Assert.That(searchOptions.SemanticSearch.QueryCaption.QueryCaptionRaw, Is.EqualTo("extractive|highlight-True,maxcharlength-300"));
            Assert.That(searchOptions.SemanticSearch.QueryRewrites.QueryRewritesRaw, Is.EqualTo("generative|count-3"));
        }

        [Test]
        public void VectorSearchOption()
        {
            SearchOptions searchOptions = new();
            Assert.IsNull(searchOptions.VectorSearch);

            searchOptions.VectorSearch = new();
            ReadOnlyMemory<float> vectors = new float[] { -0.011113605f, -0.01902812f, 0.047524072f };
            searchOptions.VectorSearch.Queries = new[] { new VectorizedQuery(vectors) };

            Assert.That(searchOptions.VectorSearch.Queries.Count, Is.EqualTo(1));
            Assert.That((searchOptions.VectorSearch.Queries[0] as VectorizedQuery).Vector, Is.EqualTo(vectors));
            Assert.IsNull(searchOptions.VectorSearch.FilterMode);

            searchOptions.VectorSearch.FilterMode = VectorFilterMode.PostFilter;
            Assert.That(searchOptions.VectorSearch.Queries.Count, Is.EqualTo(1));
            Assert.That((searchOptions.VectorSearch.Queries[0] as VectorizedQuery).Vector, Is.EqualTo(vectors));
            Assert.That(searchOptions.VectorSearch.FilterMode, Is.EqualTo(VectorFilterMode.PostFilter));
        }
    }
}
