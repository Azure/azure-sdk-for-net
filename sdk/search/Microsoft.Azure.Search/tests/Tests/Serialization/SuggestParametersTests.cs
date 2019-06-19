// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Common;
    using Models;
    using Xunit;

    public sealed class SuggestParametersTests
    {
        [Fact]
        public void CanConvertToPostRequestPayload()
        {
            SuggestParameters parameters = CreateTestParameters();

            SuggestRequest request = parameters.ToRequest("find me", "mySuggester");

            Assert.Equal(parameters.Filter, request.Filter);
            Assert.Equal(parameters.HighlightPostTag, request.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, request.HighlightPreTag);
            Assert.Equal(parameters.MinimumCoverage, request.MinimumCoverage);
            Assert.Equal(parameters.OrderBy.ToCommaSeparatedString(), request.OrderBy);
            Assert.Equal("find me", request.SearchText);
            Assert.Equal(parameters.SearchFields.ToCommaSeparatedString(), request.SearchFields);
            Assert.Equal(parameters.Select.ToCommaSeparatedString(), request.Select);
            Assert.Equal("mySuggester", request.SuggesterName);
            Assert.Equal(parameters.Top, request.Top);
            Assert.Equal(parameters.UseFuzzyMatching, request.UseFuzzyMatching);
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
            Assert.Equal("find me", request.SearchText);
            Assert.Null(request.SearchFields);
            Assert.Equal("*", request.Select);  // Nothing selected for Suggest means select everything.
            Assert.Equal("mySuggester", request.SuggesterName);
            Assert.Null(request.Top);
            Assert.True(request.UseFuzzyMatching.HasValue);
            Assert.False(request.UseFuzzyMatching.Value);  // Fuzzy is non-nullable in the client-side contract.
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void EnsureSelectConvertsNullOrEmptyToSelectStar(bool isNull)
        {
            string[] select = isNull ? null : new string[0];

            SuggestParameters parameters = CreateTestParameters(select);

            Assert.Same(select, parameters.Select);

            SuggestParameters newParameters = parameters.EnsureSelect();

            Assert.Collection(newParameters.Select, s => Assert.Equal("*", s));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void EnsureSelectLeavesOtherPropertiesUnchanged(bool isNull)
        {
            string[] select = isNull ? null : new string[0];

            SuggestParameters parameters = CreateTestParameters(select);
            SuggestParameters newParameters = parameters.EnsureSelect();

            Assert.Equal(parameters.Filter, newParameters.Filter);
            Assert.Equal(parameters.HighlightPostTag, newParameters.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, newParameters.HighlightPreTag);
            Assert.Equal(parameters.MinimumCoverage, newParameters.MinimumCoverage);
            Assert.Equal(parameters.OrderBy, newParameters.OrderBy);
            Assert.Equal(parameters.SearchFields, newParameters.SearchFields);
            Assert.Equal(parameters.Top, newParameters.Top);
            Assert.Equal(parameters.UseFuzzyMatching, newParameters.UseFuzzyMatching);
        }

        [Fact]
        public void EnsureSelectReturnsSelfWhenSelectIsPopulated()
        {
            SuggestParameters parameters = CreateTestParameters();
            SuggestParameters newParameters = parameters.EnsureSelect();

            Assert.Same(parameters, newParameters);
        }

        private static SuggestParameters CreateTestParameters() => CreateTestParameters(new[] { "e", "f", "g" });

        private static SuggestParameters CreateTestParameters(string[] select) =>
            new SuggestParameters()
            {
                Filter = "x eq y",
                HighlightPostTag = "</em>",
                HighlightPreTag = "<em>",
                MinimumCoverage = 33.3,
                OrderBy = new[] { "a", "b desc" },
                SearchFields = new[] { "a", "b", "c" },
                Select = select,
                Top = 5,
                UseFuzzyMatching = true
            };
    }
}
