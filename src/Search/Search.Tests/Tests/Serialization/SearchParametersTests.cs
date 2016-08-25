// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Spatial;
    using Xunit;

    public sealed class SearchParametersTests
    {
        [Fact]
        public void AllOptionsUnsetGivesDefaultQueryString()
        {
            Assert.Equal("$count=false&queryType=simple&searchMode=any", new SearchParameters().ToString());
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
                    QueryType = QueryType.Full,
                    ScoringParameters = new[] 
                    { 
                        new ScoringParameter("name", new[] { "Hello, O'Brien", "Smith" }), 
                        new ScoringParameter("point", GeographyPoint.Create(48.5, -120.1))
                    },
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
                "$orderby=field1 asc,field2 desc&queryType=full&scoringParameter=name-'Hello, O''Brien','Smith'&" +
                "scoringParameter=point-'-120.1','48.5'&scoringProfile=myprofile&searchFields=field1,field2&" +
                "searchMode=all&$select=field1,field2&$skip=10&$top=5";

            Assert.Equal(ExpectedQueryString, parameters.ToString());
        }

        [Fact]
        public void SomeCollectionParametersRepeat()
        {
            var parameters =
                new SearchParameters()
                {
                    Facets = new[] { "field,option:value", "field2,option2:value2" },
                    ScoringParameters = new[] 
                    {
                        new ScoringParameter("name", new[] { "value1", "value2" }),
                        new ScoringParameter("name2", new[] { "value3", "value4" })
                    }
                };

            const string ExpectedQueryString =
                "$count=false&facet=field%2Coption%3Avalue&facet=field2%2Coption2%3Avalue2&queryType=simple&" +
                "scoringParameter=name-'value1','value2'&scoringParameter=name2-'value3','value4'&searchMode=any";

            Assert.Equal(ExpectedQueryString, parameters.ToString());
        }

        [Fact]
        public void SelectStarPropagatesToQueryString()
        {
            var parameters = new SearchParameters() { Select = new[] { "*" } };
            Assert.Equal("$count=false&queryType=simple&searchMode=any&$select=*", parameters.ToString());
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
                "$count=false&facet={0}&$filter={0}&highlightPreTag={0}&highlightPostTag={0}&queryType=simple&" +
                "searchMode=any";

            Assert.Equal(String.Format(ExpectedQueryStringFormat, EscapedString), parameters.ToString());
        }

        [Fact]
        public void CanConvertToPostPayload()
        {
            var parameters =
                new SearchParameters()
                {
                    Facets = new[] { "abc", "efg" },
                    Filter = "x eq y",
                    HighlightFields = new[] { "a", "b" },
                    HighlightPostTag = "</em>",
                    HighlightPreTag = "<em>",
                    IncludeTotalResultCount = true,
                    MinimumCoverage = 33.3,
                    OrderBy = new[] { "a", "b desc" },
                    QueryType = QueryType.Full,
                    ScoringParameters = new[] 
                    { 
                        new ScoringParameter("a", new[] { "b" }), 
                        new ScoringParameter("c", GeographyPoint.Create(-16, 55))
                    },
                    ScoringProfile = "xyz",
                    SearchFields = new[] { "a", "b", "c" },
                    SearchMode = SearchMode.All,
                    Select = new[] { "e", "f", "g" },
                    Skip = 10,
                    Top = 5
                };

            SearchParametersPayload payload = parameters.ToPayload("find me");

            Assert.True(parameters.Facets.SequenceEqual(payload.Facets));
            Assert.Equal(parameters.Filter, payload.Filter);
            Assert.Equal(parameters.HighlightFields.ToCommaSeparatedString(), payload.Highlight);
            Assert.Equal(parameters.HighlightPostTag, payload.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, payload.HighlightPreTag);
            Assert.Equal(parameters.IncludeTotalResultCount, payload.Count);
            Assert.Equal(parameters.MinimumCoverage, payload.MinimumCoverage);
            Assert.Equal(parameters.OrderBy.ToCommaSeparatedString(), payload.OrderBy);
            Assert.Equal(parameters.QueryType, payload.QueryType);
            Assert.True(parameters.ScoringParameters.Select(p => p.ToString()).SequenceEqual(payload.ScoringParameters));
            Assert.Equal(parameters.ScoringProfile, payload.ScoringProfile);
            Assert.Equal("find me", payload.Search);
            Assert.Equal(parameters.SearchFields.ToCommaSeparatedString(), payload.SearchFields);
            Assert.Equal(parameters.SearchMode, payload.SearchMode);
            Assert.Equal(parameters.Select.ToCommaSeparatedString(), payload.Select);
            Assert.Equal(parameters.Skip, payload.Skip);
            Assert.Equal(parameters.Top, payload.Top);
        }

        [Fact]
        public void MissingParametersAreMissingInThePayload()
        {
            var parameters = new SearchParameters();

            // Search text can never be null.
            SearchParametersPayload payload = parameters.ToPayload("*");

            Assert.True(payload.Count.HasValue);
            Assert.False(payload.Count.Value);  // IncludeTotalCount is non-nullable in the client contract.
            Assert.NotNull(payload.Facets);
            Assert.False(payload.Facets.Any());
            Assert.Null(payload.Filter);
            Assert.Null(payload.Highlight);
            Assert.Null(payload.HighlightPostTag);
            Assert.Null(payload.HighlightPreTag);
            Assert.Null(payload.MinimumCoverage);
            Assert.Null(payload.OrderBy);
            Assert.True(payload.QueryType.HasValue);
            Assert.Equal(QueryType.Simple, payload.QueryType.Value); // QueryType is non-nullable in the client contract.
            Assert.NotNull(payload.ScoringParameters);
            Assert.False(payload.ScoringParameters.Any());
            Assert.Null(payload.ScoringProfile);
            Assert.Equal("*", payload.Search);
            Assert.Null(payload.SearchFields);
            Assert.True(payload.SearchMode.HasValue);
            Assert.Equal(SearchMode.Any, payload.SearchMode.Value); // SearchMode is non-nullable in the client contract.
            Assert.Null(payload.Select);
            Assert.Null(payload.Skip);
            Assert.Null(payload.Top);
        }
    }
}
