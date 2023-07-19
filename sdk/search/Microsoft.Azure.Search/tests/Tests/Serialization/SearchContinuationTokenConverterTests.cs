// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Models.Internal;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SearchContinuationTokenConverterTests
    {
        private readonly SearchContinuationToken _token =
            SearchContinuationToken.CreateTestToken(
                $"https://tempuri.org?api-version={ApiVersion}",
                "some words",
                new SearchParameters()
                {
                    IncludeTotalResultCount = true,
                    Facets = new[] { "testfacets" },
                    Filter = "testfilter",
                    HighlightFields = new[] { "testhighlight" },
                    HighlightPostTag = "</b>",
                    HighlightPreTag = "<b>",
                    MinimumCoverage = 50,
                    OrderBy = new[] { "testorderby" },
                    QueryType = QueryType.Full,
                    ScoringParameters = new[] { new ScoringParameter("testscoringparameter", new[] { "123" }) },
                    ScoringProfile = "testscoringprofile",
                    SearchFields = new[] { "somefields" },
                    SearchMode = SearchMode.All,
                    Select = new[] { "*" },
                    Skip = 100,
                    Top = 10
                });

        private readonly SearchContinuationToken _tokenWithOnlyLink =
            SearchContinuationToken.CreateTestToken($"https://tempuri.org?=&a=&=a&a=b=c&a=b&api-version={ApiVersion}");

        private readonly SearchContinuationTokenComparer _tokenComparer = new SearchContinuationTokenComparer();

        /// <summary>
        /// Returns the api-version from the generated code. Using this in the tests ensures that the object under test has its api-version
        /// updated when publishing new versions of the SDK.
        /// </summary>
        private static string ApiVersion =>
            new SearchServiceClient("thisservicedoesnotexist", new SearchCredentials("thisapikeydoesnotexist")).ApiVersion;

        private static string TokenJson =>
$@"{{
  ""@odata.nextLink"": ""https://tempuri.org?api-version={ApiVersion}"",
  ""@search.nextPageParameters"": {{
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
      ""testscoringparameter-'123'""
    ],
    ""scoringProfile"": ""testscoringprofile"",
    ""search"": ""some words"",
    ""searchFields"": ""somefields"",
    ""searchMode"": ""all"",
    ""select"": ""*"",
    ""skip"": 100,
    ""top"": 10
  }}
}}";

        private static string TokenWithOnlyLinkJson =>
 $@"{{
  ""@odata.nextLink"": ""https://tempuri.org?=&a=&=a&a=b=c&a=b&api-version={ApiVersion}"",
  ""@search.nextPageParameters"": null
}}";

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
            string tokenJson = TokenJson.Replace(ApiVersion, "1999-12-31");

            JsonSerializationException e =
                Assert.Throws<JsonSerializationException>(
                    () => JsonConvert.DeserializeObject<SearchContinuationToken>(tokenJson));

            string expectedMessage =
                "Cannot deserialize a continuation token for a different api-version. Token contains version " +
                $"'1999-12-31'; Expected version '{ApiVersion}'.";

            Assert.Equal(expectedMessage, e.Message);
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
            string tokenJson = TokenJson.Replace(ApiVersion, string.Empty);

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
    }
}
