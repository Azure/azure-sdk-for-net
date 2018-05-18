// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Xunit;

    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public class AutocompleteTests : QueryTests
    {
        protected void TestAutocompleteStaticallyTypedDocuments()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "very police", "very polite", "very pool", "very popular" };

            SearchIndexClient client = GetClientForQuery();

            var autocompleteParameters = new AutocompleteParameters() { Fuzzy = false };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "very po", "sg", autocompleteParameters: autocompleteParameters);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteThrowsWhenRequestIsMalformed()
        {
            SearchIndexClient client = GetClientForQuery();

            var autocompleteRequest = new AutocompleteRequest() { Fuzzy = false, AutocompleteMode = AutocompleteMode.OneTerm, Search = "very po" };
            SearchAssert.ThrowsCloudException(
                () => client.Documents.Autocomplete(AutocompleteMode.OneTerm, "very po", String.Empty),
                HttpStatusCode.BadRequest,
                "Cannot find fields enabled for suggestions. Please provide a value for 'suggesterName' in the query.\r\nParameter name: suggestions");
        }

        protected void TestAutcompleteThrowsWhenGivenBadSuggesterName()
        {
            SearchIndexClient client = GetClientForQuery();
            SearchAssert.ThrowsCloudException(
                () => client.Documents.Autocomplete(AutocompleteMode.OneTerm, "very po", "Invalid suggester"),
                HttpStatusCode.BadRequest,
                "The specified suggester name 'Invalid suggester' does not exist in this index definition.\r\nParameter name: name");
        }
        
        protected void TestAutocompleteFuzzyIsOffByDefault()
        {
            SearchIndexClient client = GetClientForQuery();
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "pi", "sg");

            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestAutocompleteOneTerm()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "police", "polite", "pool", "popular" };

            SearchIndexClient client = GetClientForQuery();
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "po", "sg");

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteTwoTerms()
        {
            var expectedText = new List<String>() { "police station", "polite staff", "pool a", "popular hotel" };
            var expectedQueryPlusText = new List<String>() { "police station", "polite staff", "pool a", "popular hotel" };

            SearchIndexClient client = GetClientForQuery();
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.TwoTerms, "po", "sg");

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteOneTermWithContext()
        {
            var expectedText = new List<String>() { "very police", "very polite", "very popular" };
            var expectedQueryPlusText = new List<String>() { "looking for very police", "looking for very polite", "looking for very popular" };

            SearchIndexClient client = GetClientForQuery();
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTermWithContext, "looking for very po", "sg");

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteOneTermWithFuzzy()
        {
            var expectedText = new List<String>() { "model", "modern", "morel", "motel" };
            var expectedQueryPlusText = new List<String>() { "model", "modern", "morel", "motel" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { Fuzzy = true };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "mod", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteTwoTermsWithFuzzy()
        {
            var expectedText = new List<String>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };
            var expectedQueryPlusText = new List<String>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { Fuzzy = true };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.TwoTerms, "mod", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteOneTermWithContextWithFuzzy()
        {
            var expectedText = new List<String>() { "very polite", "very police" };
            var expectedQueryPlusText = new List<String>() { "very polite", "very police" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { Fuzzy = true };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTermWithContext, "very polit", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteCanUseHitHighlighting()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "<b>police</b>", "<b>polite</b>", "<b>pool</b>", "<b>popular</b>" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                HighlightPreTag = "<b>",
                HighlightPostTag = "</b>",
            };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "po", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteTopTrimsResults()
        {
            var expectedText = new List<String>() { "police", "polite" };
            var expectedQueryPlusText = new List<String>() { "police", "polite" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                Top = 2
            };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "po", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteWithSelectedFields()
        {
            var expectedText = new List<String>() { "modern"};
            var expectedQueryPlusText = new List<String>() { "modern" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                SearchFields = "hotelName"
            };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "mod", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteExcludesFieldsNotInSuggester()
        {
            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                SearchFields = "hotelName"
            };
            AutocompleteResult response = client.Documents.Autocomplete(AutocompleteMode.OneTerm, "luxu", "sg", autocompleteParameters: autocompleteParameters);

            Assert.NotNull(response);
            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        private void ValidateResults(IList<AutocompleteItem> autocompletedItems, List<String> expectedText, List<String> expectedQueryPlusText)
        {
            Assert.Equal(expectedText.Count, autocompletedItems.Count);
            Assert.True(autocompletedItems.Select(c => c.Text).ToList().SequenceEqual(expectedText));
            Assert.True(autocompletedItems.Select(c => c.QueryPlusText).ToList().SequenceEqual(expectedQueryPlusText));
        }

        protected override SearchIndexClient GetClient()
        {
            SearchIndexClient client = base.GetClient();
            client.UseHttpGetForQueries = true;
            return client;
        }

        protected override SearchIndexClient GetClientForQuery()
        {
            SearchIndexClient client = base.GetClientForQuery();
            client.UseHttpGetForQueries = true;
            return client;
        }
    }
}
