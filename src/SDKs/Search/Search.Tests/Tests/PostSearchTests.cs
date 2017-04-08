// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class PostSearchTests : SearchTests
    {
        [Fact]
        public void CanSearchStaticallyTypedDocuments()
        {
            Run(TestCanSearchStaticallyTypedDocuments);
        }

        [Fact]
        public void CanSearchDynamicDocuments()
        {
            Run(TestCanSearchDynamicDocuments);
        }

        [Fact]
        public void SearchThrowsWhenRequestIsMalformed()
        {
            Run(TestSearchThrowsWhenRequestIsMalformed);
        }

        [Fact]
        public void DefaultSearchModeIsAny()
        {
            Run(TestDefaultSearchModeIsAny);
        }

        [Fact]
        public void CanSearchWithSearchModeAll()
        {
            Run(TestCanSearchWithSearchModeAll);
        }

        [Fact]
        public void CanGetResultCountInSearch()
        {
            Run(TestCanGetResultCountInSearch);
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
        public void SearchWithoutOrderBySortsByScore()
        {
            Run(TestSearchWithoutOrderBySortsByScore);
        }

        [Fact]
        public void CanSearchWithSelectedFields()
        {
            Run(TestCanSearchWithSelectedFields);
        }

        [Fact]
        public void CanSearchWithLuceneSyntax()
        {
            Run(TestCanSearchWithLuceneSyntax);
        }

        [Fact]
        public void CanSearchWithRegex()
        {
            Run(TestCanSearchWithRegex);
        }

        [Fact]
        public void CanSearchWithSpecialCharsInRegex()
        {
            Run(TestCanSearchWithEscapedSpecialCharsInRegex);
        }

        [Fact]
        public void SearchThrowsWhenSpecialCharInRegexIsUnescaped()
        {
            Run(TestSearchThrowsWhenSpecialCharInRegexIsUnescaped);
        }

        [Fact]
        public void CanUseTopAndSkipForClientSidePaging()
        {
            Run(TestCanUseTopAndSkipForClientSidePaging);
        }

        [Fact]
        public void SearchWithScoringProfileBoostsScore()
        {
            Run(TestSearchWithScoringProfileBoostsScore);
        }

        [Fact]
        public void CanSearchWithRangeFacets()
        {
            Run(TestCanSearchWithRangeFacets);
        }

        [Fact]
        public void CanSearchWithValueFacets()
        {
            Run(TestCanSearchWithValueFacets);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanContinueSearchForStaticallyTypedDocuments()
        {
            Run(TestCanContinueSearchForStaticallyTypedDocuments);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanContinueSearchForDynamicDocuments()
        {
            Run(TestCanContinueSearchForDynamicDocuments);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanContinueSearchWithoutTop()
        {
            Run(TestCanContinueSearchWithoutTop);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.LiveBVT)]
        public void CanSearchWithMinimumCoverage()
        {
            Run(TestCanSearchWithMinimumCoverage);
        }

        [Fact]
        public void CanSearchWithDateTimeInStaticModel()
        {
            Run(TestCanSearchWithDateTimeInStaticModel);
        }

        [Fact]
        public void CanRoundTripNonNullableValueTypes()
        {
            Run(TestCanRoundTripNonNullableValueTypes);
        }

        [Fact]
        public void NullCannotBeConvertedToValueType()
        {
            Run(TestNullCannotBeConvertedToValueType);
        }

        [Fact]
        public void CanFilterNonNullableType()
        {
            Run(TestCanFilterNonNullableType);
        }

        [Fact]
        public void CanSearchWithCustomContractResolver()
        {
            Run(TestCanSearchWithCustomContractResolver);
        }

        [Fact]
        public void CanSearchWithCustomConverterViaSettings()
        {
            Run(TestCanSearchWithCustomConverterViaSettings);
        }

        [Fact]
        public void CanSearchWithCustomConverter()
        {
            Run(TestCanSearchWithCustomConverter);
        }
    }
}
