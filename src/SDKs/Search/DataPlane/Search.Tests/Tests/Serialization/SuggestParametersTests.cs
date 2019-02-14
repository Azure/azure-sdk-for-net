// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Common;
    using Models;
    using Xunit;

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
        public void CanConvertToPostRequestPayload()
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

            SuggestRequest request = parameters.ToRequest("find me", "mySuggester");

            Assert.Equal(parameters.Filter, request.Filter);
            Assert.Equal(parameters.HighlightPostTag, request.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, request.HighlightPreTag);
            Assert.Equal(parameters.MinimumCoverage, request.MinimumCoverage);
            Assert.Equal(parameters.OrderBy.ToCommaSeparatedString(), request.OrderBy);
            Assert.Equal("find me", request.Search);
            Assert.Equal(parameters.SearchFields.ToCommaSeparatedString(), request.SearchFields);
            Assert.Equal(parameters.Select.ToCommaSeparatedString(), request.Select);
            Assert.Equal("mySuggester", request.SuggesterName);
            Assert.Equal(parameters.Top, request.Top);
            Assert.Equal(parameters.UseFuzzyMatching, request.Fuzzy);
        }

        [Fact]
        public void MissingParametersAreMissingInTheRequest()
        {
            var parameters = new SuggestParameters();

            // Search text and suggester name can never be null.
            SuggestRequest request = parameters.ToRequest("find me", "mySuggester");

            Assert.Null(request.Filter);
            Assert.Null(request.HighlightPostTag);
            Assert.Null(request.HighlightPreTag);
            Assert.Null(request.MinimumCoverage);
            Assert.Null(request.OrderBy);
            Assert.Equal("find me", request.Search);
            Assert.Null(request.SearchFields);
            Assert.Equal("*", request.Select);  // Nothing selected for Suggest means select everything.
            Assert.Equal("mySuggester", request.SuggesterName);
            Assert.Null(request.Top);
            Assert.True(request.Fuzzy.HasValue);
            Assert.False(request.Fuzzy.Value);  // Fuzzy is non-nullable in the client-side contract.
        }
    }
}
