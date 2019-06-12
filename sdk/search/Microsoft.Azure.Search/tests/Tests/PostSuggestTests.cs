// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Search.Tests.Infrastructure;
    using Xunit;

    public class PostSuggestTests : SuggestTests
    {
        [Fact]
		[LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestStaticallyTypedDocuments()
        {
            Run(TestCanSuggestStaticallyTypedDocuments);
        }

        [Fact]
		[LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestDynamicDocuments()
        {
            Run(TestCanSuggestDynamicDocuments);
        }

        [Fact]
		[LiveTest]
        public void SuggestThrowsWhenRequestIsMalformed()
        {
            Run(TestSuggestThrowsWhenRequestIsMalformed);
        }

        [Fact]
		[LiveTest]
        public void SuggestThrowsWhenGivenBadSuggesterName()
        {
            Run(TestSuggestThrowsWhenGivenBadSuggesterName);
        }

        [Fact]
		[LiveTest]
        public void FuzzyIsOffByDefault()
        {
            Run(TestFuzzyIsOffByDefault);
        }

        [Fact]
		[LiveTest]
        public void CanGetFuzzySuggestions()
        {
            Run(TestCanGetFuzzySuggestions);
        }

        [Fact]
		[LiveTest]
        public void CanFilter()
        {
            Run(TestCanFilter);
        }

        [Fact]
		[LiveTest]
        public void CanUseHitHighlighting()
        {
            Run(TestCanUseHitHighlighting);
        }

        [Fact]
		[LiveTest]
        public void OrderByProgressivelyBreaksTies()
        {
            Run(TestOrderByProgressivelyBreaksTies);
        }

        [Fact]
		[LiveTest]
        public void TopTrimsResults()
        {
            Run(TestTopTrimsResults);
        }

        [Fact]
		[LiveTest]
        public void CanSuggestWithSelectedFields()
        {
            Run(TestCanSuggestWithSelectedFields);
        }

        [Fact]
		[LiveTest]
        public void SearchFieldsExcludesFieldsFromSuggest()
        {
            Run(TestSearchFieldsExcludesFieldsFromSuggest);
        }

        [Fact]
		[LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSuggestWithMinimumCoverage()
        {
            Run(TestCanSuggestWithMinimumCoverage);
        }

        [Fact]
		[LiveTest]
        public void CanSuggestWithDateTimeInStaticModel()
        {
            Run(TestCanSuggestWithDateTimeInStaticModel);
        }

        [Fact]
		[LiveTest]
        public void CanSuggestWithCustomContractResolver()
        {
            Run(TestCanSuggestWithCustomContractResolver);
        }

        [Fact]
		[LiveTest]
        public void CanSuggestWithCustomConverterViaSettings()
        {
            Run(TestCanSuggestWithCustomConverterViaSettings);
        }

        [Fact]
		[LiveTest]
        public void CanSuggestWithCustomConverter()
        {
            Run(TestCanSuggestWithCustomConverter);
        }
    }
}
