// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Newtonsoft.Json;
    using Xunit;

    public sealed class SearchContinuationTokenConverterTests
    {
        private const string TokenJson =
 @"{
  ""@odata.nextLink"": ""https://tempuri.org?api-version=2015-02-28-Preview"",
  ""@search.nextPageParameters"": {
    ""count"": true,
    ""facets"": [
      ""testfacets""
    ],
    ""filter"": ""testfilter"",
    ""highlight"": ""testhighlight"",
    ""highlightPostTag"": ""</b>"",
    ""highlightPreTag"": ""<b>"",
    ""minimumCoverage"": 50.0,
    ""orderby"": ""testorderby"",
    ""queryType"": ""full"",
    ""scoringParameters"": [
      ""testscoringparameter""
    ],
    ""scoringProfile"": ""testscoringprofile"",
    ""search"": ""some words"",
    ""searchFields"": ""somefields"",
    ""searchMode"": ""all"",
    ""select"": ""*"",
    ""skip"": 100,
    ""top"": 10
  }
}";

        private const string TokenWithOnlyLinkJson =
 @"{
  ""@odata.nextLink"": ""https://tempuri.org?=&a=&=a&a=b=c&a=b&api-version=2015-02-28-Preview"",
  ""@search.nextPageParameters"": null
}";

        private SearchContinuationToken _token =
            new SearchContinuationToken(
                "https://tempuri.org?api-version=2015-02-28-Preview",
                new SearchParametersPayload()
                {
                    Count = true,
                    Facets = new[] { "testfacets" },
                    Filter = "testfilter",
                    Highlight = "testhighlight",
                    HighlightPostTag = "</b>",
                    HighlightPreTag = "<b>",
                    MinimumCoverage = 50,
                    OrderBy = "testorderby",
                    QueryType = QueryType.Full,
                    ScoringParameters = new[] { "testscoringparameter" },
                    ScoringProfile = "testscoringprofile",
                    Search = "some words",
                    SearchFields = "somefields",
                    SearchMode = SearchMode.All,
                    Select = "*",
                    Skip = 100,
                    Top = 10
                });

        private SearchContinuationToken _tokenWithOnlyLink =
            new SearchContinuationToken("https://tempuri.org?=&a=&=a&a=b=c&a=b&api-version=2015-02-28-Preview", null);

        private TokenComparer _tokenComparer = new TokenComparer();

        [Fact]
        public void CanSerializeToken()
        {
            string json = JsonConvert.SerializeObject(_token, Formatting.Indented);
            Assert.Equal(TokenJson, json);
        }

        [Fact]
        public void CanDeserializeToken()
        {
            SearchContinuationToken token = JsonConvert.DeserializeObject<SearchContinuationToken>(TokenJson);
            Assert.Equal(_token, token, _tokenComparer);
        }

        [Fact]
        public void CanSerializeTokenWithOnlyLink()
        {
            string json = JsonConvert.SerializeObject(_tokenWithOnlyLink, Formatting.Indented);
            Assert.Equal(TokenWithOnlyLinkJson, json);
        }

        [Fact]
        public void CanDeserializeTokenWithOnlyLink()
        {
            SearchContinuationToken token = 
                JsonConvert.DeserializeObject<SearchContinuationToken>(TokenWithOnlyLinkJson);
            Assert.Equal(_tokenWithOnlyLink, token, _tokenComparer);
        }

        [Fact]
        public void DeserializeTokenWithWrongVersionThrowsException()
        {
            string tokenJson = TokenJson.Replace("2015-02-28-Preview", "1999-12-31");

            JsonSerializationException e =
                Assert.Throws<JsonSerializationException>(
                    () => JsonConvert.DeserializeObject<SearchContinuationToken>(tokenJson));

            const string ExpectedMessage =
                "Cannot deserialize a continuation token for a different api-version. Token contains version " +
                "'1999-12-31'; Expected version '2015-02-28-Preview'.";

            Assert.Equal(ExpectedMessage, e.Message);
        }

        [Fact]
        public void DeserializeTokenWithMissingVersionThrowsException()
        {
            string tokenJson = TokenJson.Replace("api-version=", "not-api-version=");

            JsonSerializationException e =
                Assert.Throws<JsonSerializationException>(
                    () => JsonConvert.DeserializeObject<SearchContinuationToken>(tokenJson));

            const string ExpectedMessage = "Cannot deserialize continuation token because the api-version is missing.";
            Assert.Equal(ExpectedMessage, e.Message);
        }

        [Fact]
        public void DeserializeTokenWithMissingVersionValueThrowsException()
        {
            string tokenJson = TokenJson.Replace("2015-02-28-Preview", string.Empty);

            JsonSerializationException e =
                Assert.Throws<JsonSerializationException>(
                    () => JsonConvert.DeserializeObject<SearchContinuationToken>(tokenJson));

            const string ExpectedMessage = "Cannot deserialize continuation token because the api-version is missing.";
            Assert.Equal(ExpectedMessage, e.Message);
        }

        [Fact]
        public void DeserializeTokenWithInvalidUrlThrowsException()
        {
            string tokenJson = @"{ ""@odata.nextLink"": ""This is not a valid URL."" }";

            JsonSerializationException e =
                Assert.Throws<JsonSerializationException>(
                    () => JsonConvert.DeserializeObject<SearchContinuationToken>(tokenJson));

            const string ExpectedMessage = 
                "Cannot deserialize continuation token. Failed to parse nextLink because it is not a valid URL.";

            Assert.Equal(ExpectedMessage, e.Message);
        }

        [Fact]
        public void DeserializeTokenWithNoQueryStringThrowsException()
        {
            string tokenJson = @"{ ""@odata.nextLink"": ""https://tempuri.org"" }";

            JsonSerializationException e =
                Assert.Throws<JsonSerializationException>(
                    () => JsonConvert.DeserializeObject<SearchContinuationToken>(tokenJson));

            const string ExpectedMessage = "Cannot deserialize continuation token because the api-version is missing.";
            Assert.Equal(ExpectedMessage, e.Message);
        }

        private class TokenComparer : IEqualityComparer<SearchContinuationToken>
        {
            public bool Equals(SearchContinuationToken x, SearchContinuationToken y)
            {
                return 
                    x.NextLink == y.NextLink &&
                    NextPageParametersEquals(x.NextPageParameters, y.NextPageParameters);
            }

            public int GetHashCode(SearchContinuationToken obj)
            {
                return obj.GetHashCode();
            }

            private static bool NextPageParametersEquals(SearchParametersPayload x, SearchParametersPayload y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if ((x == null) != (y == null))
                {
                    return false;
                }

                return
                    x.Count == y.Count &&
                    ((x.Facets == null && y.Facets == null) || x.Facets.SequenceEqual(y.Facets)) &&
                    x.Filter == y.Filter &&
                    x.Highlight == y.Highlight &&
                    x.HighlightPostTag == y.HighlightPostTag &&
                    x.HighlightPreTag == y.HighlightPreTag &&
                    x.MinimumCoverage == y.MinimumCoverage &&
                    x.OrderBy == y.OrderBy &&
                    x.QueryType == y.QueryType &&
                    ((x.ScoringParameters == null && y.ScoringParameters == null) ||
                      x.ScoringParameters.SequenceEqual(y.ScoringParameters)) &&
                    x.ScoringProfile == y.ScoringProfile &&
                    x.Search == y.Search &&
                    x.SearchFields == y.SearchFields &&
                    x.SearchMode == y.SearchMode &&
                    x.Select == y.Select &&
                    x.Skip == y.Skip &&
                    x.Top == y.Top;
            }
        }
    }
}
