﻿// 
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

using System;
using Microsoft.Azure.Search.Models;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SearchParametersTests
    {
        [Fact]
        public void AllOptionsUnsetGivesDefaultQueryString()
        {
            Assert.Equal("$count=false&searchMode=any", new SearchParameters().ToString());
        }

        [Fact]
        public void AllOptionsPropagatedToQueryString()
        {
            var parameters =
                new SearchParameters()
                {
                    IncludeTotalResultCount = true,
                    Facets = new[] { "field,option:value" },
                    Filter = "field eq value",
                    HighlightFields = new[] { "field1", "field2" },
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                    MinimumCoverage = 66.67,
                    OrderBy = new[] { "field1 asc", "field2 desc" },
                    ScoringParameters = new[] { "name:value" },
                    ScoringProfile = "myprofile",
                    SearchFields = new[] { "field1", "field2" },
                    SearchMode = SearchMode.All,
                    Select = new[] { "field1", "field2" },
                    Skip = 10,
                    Top = 5
                };

            const string ExpectedQueryString =
                "$count=true&facet=field%2Coption%3Avalue&$filter=field%20eq%20value&highlight=field1,field2&" +
                "highlightPreTag=%3Cb%3E&highlightPostTag=%3C%2Fb%3E&minimumCoverage=66.67&" +
                "$orderby=field1 asc,field2 desc&scoringParameter=name:value&scoringProfile=myprofile&" +
                "searchFields=field1,field2&searchMode=all&$select=field1,field2&$skip=10&$top=5";

            Assert.Equal(ExpectedQueryString, parameters.ToString());
        }

        [Fact]
        public void SomeCollectionParametersRepeat()
        {
            var parameters =
                new SearchParameters()
                {
                    Facets = new[] { "field,option:value", "field2,option2:value2" },
                    ScoringParameters = new[] { "name:value", "name2:value2" }
                };

            const string ExpectedQueryString =
                "$count=false&facet=field%2Coption%3Avalue&facet=field2%2Coption2%3Avalue2&" +
                "scoringParameter=name:value&scoringParameter=name2:value2&searchMode=any";

            Assert.Equal(ExpectedQueryString, parameters.ToString());
        }

        [Fact]
        public void SelectStarPropagatesToQueryString()
        {
            var parameters = new SearchParameters() { Select = new[] { "*" } };
            Assert.Equal("$count=false&searchMode=any&$select=*", parameters.ToString());
        }

        [Fact]
        public void AllOpenStringParametersAreEscaped()
        {
            const string UnescapedString = "a+%=@#b";
            const string EscapedString = "a%2B%25%3D%40%23b";

            var parameters =
                new SearchParameters()
                {
                    Filter = UnescapedString,
                    HighlightPreTag = UnescapedString,
                    HighlightPostTag = UnescapedString,
                    Facets = new[] { UnescapedString }
                };

            const string ExpectedQueryStringFormat =
                "$count=false&facet={0}&$filter={0}&highlightPreTag={0}&highlightPostTag={0}&searchMode=any";

            Assert.Equal(String.Format(ExpectedQueryStringFormat, EscapedString), parameters.ToString());
        }
    }
}
