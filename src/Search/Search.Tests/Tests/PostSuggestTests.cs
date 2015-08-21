// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public class PostSuggestTests : SuggestTests
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
    }
}
