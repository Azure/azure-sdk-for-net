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
using System.Collections.Generic;
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
                    MinimumCoverage = 33.33,
                    OrderBy = new[] { "field1 asc", "field2 desc" },
                    SearchFields = new[] { "field1", "field2" },
                    Select = new[] { "field1", "field2" },
                    Top = 5,
                    UseFuzzyMatching = true
                };

            const string ExpectedQueryString =
                "$filter=field%20eq%20value&highlightPreTag=%3Cb%3E&highlightPostTag=%3C%2Fb%3E&" +
                "minimumCoverage=33.33&$orderby=field1 asc,field2 desc&searchFields=field1,field2&" +
                "$select=field1,field2&$top=5&fuzzy=true";

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

        [Fact]
        public void CanConvertToPostPayload()
        {
            var parameters =
                new SuggestParameters()
                {
                    Filter = "x eq y",
                    HighlightPostTag = "</em>",
                    HighlightPreTag = "<em>",
                    MinimumCoverage = 33.3,
                    OrderBy = new[] { "a", "b desc" },
                    SearchFields = new[] { "a", "b", "c" },
                    Select = new[] { "e", "f", "g" },
                    Top = 5,
                    UseFuzzyMatching = true
                };

            SuggestParametersPayload payload = parameters.ToPayload("find me", "mySuggester");

            Assert.Equal(parameters.Filter, payload.Filter);
            Assert.Equal(parameters.HighlightPostTag, payload.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, payload.HighlightPreTag);
            Assert.Equal(parameters.MinimumCoverage, payload.MinimumCoverage);
            Assert.Equal(parameters.OrderBy.ToCommaSeparatedString(), payload.OrderBy);
            Assert.Equal("find me", payload.Search);
            Assert.Equal(parameters.SearchFields.ToCommaSeparatedString(), payload.SearchFields);
            Assert.Equal(parameters.Select.ToCommaSeparatedString(), payload.Select);
            Assert.Equal("mySuggester", payload.SuggesterName);
            Assert.Equal(parameters.Top, payload.Top);
            Assert.Equal(parameters.UseFuzzyMatching, payload.Fuzzy);
        }

        [Fact]
        public void MissingParametersAreMissingInThePayload()
        {
            var parameters = new SuggestParameters();

            // Search text and suggester name can never be null.
            SuggestParametersPayload payload = parameters.ToPayload("find me", "mySuggester");

            Assert.Null(payload.Filter);
            Assert.Null(payload.HighlightPostTag);
            Assert.Null(payload.HighlightPreTag);
            Assert.Null(payload.MinimumCoverage);
            Assert.Null(payload.OrderBy);
            Assert.Equal("find me", payload.Search);
            Assert.Null(payload.SearchFields);
            Assert.Equal("*", payload.Select);  // Nothing selected for Suggest means select everything.
            Assert.Equal("mySuggester", payload.SuggesterName);
            Assert.Null(payload.Top);
            Assert.True(payload.Fuzzy.HasValue);
            Assert.False(payload.Fuzzy.Value);  // Fuzzy is non-nullable in the client-side contract.
        }
    }
}
