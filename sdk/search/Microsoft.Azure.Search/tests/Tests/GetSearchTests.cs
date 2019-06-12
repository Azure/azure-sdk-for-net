// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Search.Tests.Infrastructure;

    public class GetSearchTests : SearchTests
    {
        [Fact]
        [LiveTest]
        public void CanSearchStaticallyTypedDocuments()
        {
            Run(TestCanSearchStaticallyTypedDocuments);
        }

        [Fact]
        [LiveTest]
        public void CanSearchDynamicDocuments()
        {
            Run(TestCanSearchDynamicDocuments);
        }

        [Fact]
        [LiveTest]
        public void SearchThrowsWhenRequestIsMalformed()
        {
            Run(TestSearchThrowsWhenRequestIsMalformed);
        }

        [Fact]
        [LiveTest]
        public void DefaultSearchModeIsAny()
        {
            Run(TestDefaultSearchModeIsAny);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithSearchModeAll()
        {
            Run(TestCanSearchWithSearchModeAll);
        }

        [Fact]
        [LiveTest]
        public void CanGetResultCountInSearch()
        {
            Run(TestCanGetResultCountInSearch);
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
        public void SearchWithoutOrderBySortsByScore()
        {
            Run(TestSearchWithoutOrderBySortsByScore);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithSelectedFields()
        {
            Run(TestCanSearchWithSelectedFields);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithLuceneSyntax()
        {
            Run(TestCanSearchWithLuceneSyntax);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithRegex()
        {
            Run(TestCanSearchWithRegex);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithSynonyms()
        {
            Run(TestCanSearchWithSynonyms);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithSpecialCharsInRegex()
        {
            Run(TestCanSearchWithEscapedSpecialCharsInRegex);
        }

        [Fact]
        [LiveTest]
        public void SearchThrowsWhenSpecialCharInRegexIsUnescaped()
        {
            Run(TestSearchThrowsWhenSpecialCharInRegexIsUnescaped);
        }

        [Fact]
        [LiveTest]
        public void CanUseTopAndSkipForClientSidePaging()
        {
            Run(TestCanUseTopAndSkipForClientSidePaging);
        }

        [Fact]
        [LiveTest]
        public void SearchWithScoringProfileBoostsScore()
        {
            Run(TestSearchWithScoringProfileBoostsScore);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithRangeFacets()
        {
            Run(TestCanSearchWithRangeFacets);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithValueFacets()
        {
            Run(TestCanSearchWithValueFacets);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanContinueSearchForStaticallyTypedDocuments()
        {
            Run(TestCanContinueSearchForStaticallyTypedDocuments);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanContinueSearchForDynamicDocuments()
        {
            Run(TestCanContinueSearchForDynamicDocuments);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanContinueSearchWithoutTop()
        {
            Run(TestCanContinueSearchWithoutTop);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSearchWithMinimumCoverage()
        {
            Run(TestCanSearchWithMinimumCoverage);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithDateTimeInStaticModel()
        {
            Run(TestCanSearchWithDateTimeInStaticModel);
        }

        [Fact]
        [LiveTest]
        public void CanRoundTripNonNullableValueTypes()
        {
            Run(TestCanRoundTripNonNullableValueTypes);
        }

        [Fact]
        [LiveTest]
        public void NullCannotBeConvertedToValueType()
        {
            Run(TestNullCannotBeConvertedToValueType);
        }

        [Fact]
        [LiveTest]
        public void CanFilterNonNullableType()
        {
            Run(TestCanFilterNonNullableType);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithCustomContractResolver()
        {
            Run(TestCanSearchWithCustomContractResolver);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithCustomConverterViaSettings()
        {
            Run(TestCanSearchWithCustomConverterViaSettings);
        }

        [Fact]
        [LiveTest]
        public void CanSearchWithCustomConverter()
        {
            Run(TestCanSearchWithCustomConverter);
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
