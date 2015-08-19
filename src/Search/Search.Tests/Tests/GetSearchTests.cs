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
    public class GetSearchTests : SearchTests
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
