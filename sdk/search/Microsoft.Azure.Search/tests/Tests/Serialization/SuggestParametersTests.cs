// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Models;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SuggestParametersTests
    {
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
