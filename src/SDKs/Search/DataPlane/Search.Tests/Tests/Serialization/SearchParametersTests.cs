// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Linq;
    using Common;
    using Models;
    using Spatial;
    using Xunit;

    public sealed class SearchParametersTests
    {
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
            Assert.Equal(parameters.HighlightFields.ToCommaSeparatedString(), request.HighlightFields);
            Assert.Equal(parameters.HighlightPostTag, request.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, request.HighlightPreTag);
            Assert.Equal(parameters.IncludeTotalResultCount, request.IncludeTotalResultCount);
            Assert.Equal(parameters.MinimumCoverage, request.MinimumCoverage);
            Assert.Equal(parameters.OrderBy.ToCommaSeparatedString(), request.OrderBy);
            Assert.Equal(parameters.QueryType, request.QueryType);
            Assert.True(parameters.ScoringParameters.Select(p => p.ToString()).SequenceEqual(request.ScoringParameters));
            Assert.Equal(parameters.ScoringProfile, request.ScoringProfile);
            Assert.Equal("find me", request.SearchText);
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

            Assert.True(request.IncludeTotalResultCount.HasValue);
            Assert.False(request.IncludeTotalResultCount.Value);  // IncludeTotalCount is non-nullable in the client contract.
            Assert.NotNull(request.Facets);
            Assert.False(request.Facets.Any());
            Assert.Null(request.Filter);
            Assert.Null(request.HighlightFields);
            Assert.Null(request.HighlightPostTag);
            Assert.Null(request.HighlightPreTag);
            Assert.Null(request.MinimumCoverage);
            Assert.Null(request.OrderBy);
            Assert.True(request.QueryType.HasValue);
            Assert.Equal(QueryType.Simple, request.QueryType.Value); // QueryType is non-nullable in the client contract.
            Assert.NotNull(request.ScoringParameters);
            Assert.False(request.ScoringParameters.Any());
            Assert.Null(request.ScoringProfile);
            Assert.Equal("*", request.SearchText);
            Assert.Null(request.SearchFields);
            Assert.True(request.SearchMode.HasValue);
            Assert.Equal(SearchMode.Any, request.SearchMode.Value); // SearchMode is non-nullable in the client contract.
            Assert.Null(request.Select);
            Assert.Null(request.Skip);
            Assert.Null(request.Top);
        }
    }
}
