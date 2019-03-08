// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Linq;
    using Common;
    using Models;
    using Spatial;
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
        public void CanConvertToPostRequestPayload()
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

            SearchRequest request = parameters.ToRequest("find me");

            Assert.True(parameters.Facets.SequenceEqual(request.Facets));
            Assert.Equal(parameters.Filter, request.Filter);
            Assert.Equal(parameters.HighlightFields.ToCommaSeparatedString(), request.Highlight);
            Assert.Equal(parameters.HighlightPostTag, request.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, request.HighlightPreTag);
            Assert.Equal(parameters.IncludeTotalResultCount, request.Count);
            Assert.Equal(parameters.MinimumCoverage, request.MinimumCoverage);
            Assert.Equal(parameters.OrderBy.ToCommaSeparatedString(), request.OrderBy);
            Assert.Equal(parameters.QueryType, request.QueryType);
            Assert.True(parameters.ScoringParameters.Select(p => p.ToString()).SequenceEqual(request.ScoringParameters));
            Assert.Equal(parameters.ScoringProfile, request.ScoringProfile);
            Assert.Equal("find me", request.Search);
            Assert.Equal(parameters.SearchFields.ToCommaSeparatedString(), request.SearchFields);
            Assert.Equal(parameters.SearchMode, request.SearchMode);
            Assert.Equal(parameters.Select.ToCommaSeparatedString(), request.Select);
            Assert.Equal(parameters.Skip, request.Skip);
            Assert.Equal(parameters.Top, request.Top);
        }

        [Fact]
        public void MissingParametersAreMissingInTheRequest()
        {
            var parameters = new SearchParameters();

            // Search text can never be null.
            SearchRequest request = parameters.ToRequest("*");

            Assert.True(request.Count.HasValue);
            Assert.False(request.Count.Value);  // IncludeTotalCount is non-nullable in the client contract.
            Assert.NotNull(request.Facets);
            Assert.False(request.Facets.Any());
            Assert.Null(request.Filter);
            Assert.Null(request.Highlight);
            Assert.Null(request.HighlightPostTag);
            Assert.Null(request.HighlightPreTag);
            Assert.Null(request.MinimumCoverage);
            Assert.Null(request.OrderBy);
            Assert.True(request.QueryType.HasValue);
            Assert.Equal(QueryType.Simple, request.QueryType.Value); // QueryType is non-nullable in the client contract.
            Assert.NotNull(request.ScoringParameters);
            Assert.False(request.ScoringParameters.Any());
            Assert.Null(request.ScoringProfile);
            Assert.Equal("*", request.Search);
            Assert.Null(request.SearchFields);
            Assert.True(request.SearchMode.HasValue);
            Assert.Equal(SearchMode.Any, request.SearchMode.Value); // SearchMode is non-nullable in the client contract.
            Assert.Null(request.Select);
            Assert.Null(request.Skip);
            Assert.Null(request.Top);
        }
    }
}
