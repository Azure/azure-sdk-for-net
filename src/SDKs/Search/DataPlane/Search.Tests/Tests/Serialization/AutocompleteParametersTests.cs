// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Common;
    using Models;
    using Xunit;

    public sealed class AutocompleteParametersTests
    {
        [Fact]
        public void CanConvertToPostRequestPayload()
        {
            var parameters =
                new AutocompleteParameters()
                {
                    AutocompleteMode = AutocompleteMode.OneTermWithContext,
                    Filter = "field eq 'text'",
                    HighlightPostTag = "</em>",
                    HighlightPreTag = "<em>",
                    MinimumCoverage = 33.3,
                    SearchFields = new[] { "a", "b", "c" },
                    Top = 5,
                    UseFuzzyMatching = true
                };

            AutocompleteRequest request = parameters.ToRequest("find me", "sg");

            Assert.Equal(parameters.AutocompleteMode, request.AutocompleteMode);
            Assert.Equal(parameters.Filter, request.Filter);
            Assert.Equal(parameters.HighlightPostTag, request.HighlightPostTag);
            Assert.Equal(parameters.HighlightPreTag, request.HighlightPreTag);
            Assert.Equal(parameters.MinimumCoverage, request.MinimumCoverage);
            Assert.Equal("find me", request.SearchText);
            Assert.Equal("sg", request.SuggesterName);
            Assert.Equal(parameters.SearchFields.ToCommaSeparatedString(), request.SearchFields);
            Assert.Equal(parameters.Top, request.Top);
            Assert.Equal(parameters.UseFuzzyMatching, request.UseFuzzyMatching);
        }

        [Fact]
        public void MissingParametersAreMissingInTheRequest()
        {
            var parameters = new AutocompleteParameters();

            // Search text and suggester name can never be null.
            AutocompleteRequest request = parameters.ToRequest("welco", "sg");

            Assert.True(request.AutocompleteMode.HasValue);
            Assert.Equal(AutocompleteMode.OneTerm, request.AutocompleteMode.Value);  // AutocompleteMode is non-nullable in the client contract.
            Assert.Null(request.Filter);
            Assert.Null(request.HighlightPostTag);
            Assert.Null(request.HighlightPreTag);
            Assert.Null(request.MinimumCoverage);
            Assert.Equal("welco", request.SearchText);
            Assert.Equal("sg", request.SuggesterName);
            Assert.Null(request.SearchFields);
            Assert.Null(request.Top);
            Assert.False(request.UseFuzzyMatching.HasValue);
        }
    }
}
