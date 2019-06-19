// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class GetSuggestTests : SuggestTests
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestStaticallyTypedDocuments()
        {
            Run(TestCanSuggestStaticallyTypedDocuments);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestDynamicDocuments()
        {
            Run(TestCanSuggestDynamicDocuments);
        }

        [Fact]
        public void SuggestThrowsWhenRequestIsMalformed()
        {
            Run(TestSuggestThrowsWhenRequestIsMalformed);
        }

        [Fact]
        public void SuggestThrowsWhenGivenBadSuggesterName()
        {
            Run(TestSuggestThrowsWhenGivenBadSuggesterName);
        }

        [Fact]
        public void FuzzyIsOffByDefault()
        {
            Run(TestFuzzyIsOffByDefault);
        }

        [Fact]
        public void CanGetFuzzySuggestions()
        {
            Run(TestCanGetFuzzySuggestions);
        }

        [Fact]
        public void CanFilter()
        {
            Run(TestCanFilter);
        }

        [Fact]
        public void CanUseHitHighlighting()
        {
            Run(TestCanUseHitHighlighting);
        }

        [Fact]
        public void OrderByProgressivelyBreaksTies()
        {
            Run(TestOrderByProgressivelyBreaksTies);
        }

        [Fact]
        public void TopTrimsResults()
        {
            Run(TestTopTrimsResults);
        }

        [Fact]
        public void CanSuggestWithSelectedFields()
        {
            Run(TestCanSuggestWithSelectedFields);
        }

        [Fact]
        public void SearchFieldsExcludesFieldsFromSuggest()
        {
            Run(TestSearchFieldsExcludesFieldsFromSuggest);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestWithMinimumCoverage()
        {
            Run(TestCanSuggestWithMinimumCoverage);
        }

        [Fact]
        public void CanSuggestWithDateTimeInStaticModel()
        {
            Run(TestCanSuggestWithDateTimeInStaticModel);
        }

        [Fact]
        public void CanSuggestWithCustomContractResolver()
        {
            Run(TestCanSuggestWithCustomContractResolver);
        }

        [Fact]
        public void CanSuggestWithCustomConverterViaSettings()
        {
            Run(TestCanSuggestWithCustomConverterViaSettings);
        }

        [Fact]
        public void CanSuggestWithCustomConverter()
        {
            Run(TestCanSuggestWithCustomConverter);
        }

        protected override SearchIndexClient GetClient()
        {
            SearchIndexClient client = base.GetClient();
            client.UseHttpGetForQueries = true;
            return client;
        }

        protected override SearchIndexClient GetClientForQuery()
        {
            SearchIndexClient client = base.GetClientForQuery();
            client.UseHttpGetForQueries = true;
            return client;
        }
    }
}
