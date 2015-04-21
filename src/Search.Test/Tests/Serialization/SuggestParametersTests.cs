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

using System;
using Microsoft.Azure.Search.Models;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SuggestParametersTests
    {
        [Fact]
        public void AllOptionsUnsetGivesDefaultQueryString()
        {
            Assert.Equal("$select=*&fuzzy=false", new SuggestParameters().ToString());
        }

        [Fact]
        public void AllOptionsPropagatedToQueryString()
        {
            var parameters =
                new SuggestParameters()
                {
                    Filter = "field eq value",
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                    OrderBy = new[] { "field1 asc", "field2 desc" },
                    SearchFields = new[] { "field1", "field2" },
                    Select = new[] { "field1", "field2" },
                    Top = 5,
                    UseFuzzyMatching = true
                };

            const string ExpectedQueryString =
                "$filter=field%20eq%20value&highlightPreTag=%3Cb%3E&highlightPostTag=%3C%2Fb%3E&" +
                "$orderby=field1 asc,field2 desc&searchFields=field1,field2&$select=field1,field2&" +
                "$top=5&fuzzy=true";

            Assert.Equal(ExpectedQueryString, parameters.ToString());
        }

        [Fact]
        public void SelectStarPropagatesToQueryString()
        {
            var parameters = new SuggestParameters() { Select = new[] { "*" } };
            Assert.Equal("$select=*&fuzzy=false", parameters.ToString());
        }

        [Fact]
        public void AllOpenStringParametersAreEscaped()
        {
            const string UnescapedString = "a+%=@#b";
            const string EscapedString = "a%2B%25%3D%40%23b";

            var parameters =
                new SuggestParameters()
                {
                    Filter = UnescapedString,
                    HighlightPreTag = UnescapedString,
                    HighlightPostTag = UnescapedString
                };

            const string ExpectedQueryStringFormat =
                "$filter={0}&highlightPreTag={0}&highlightPostTag={0}&$select=*&fuzzy=false";

            Assert.Equal(String.Format(ExpectedQueryStringFormat, EscapedString), parameters.ToString());
        }
    }
}
