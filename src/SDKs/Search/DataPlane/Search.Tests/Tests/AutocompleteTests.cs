// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Xunit;

    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public abstract class AutocompleteTests : QueryTests
    {
        protected void TestAutocompleteStaticallyTypedDocuments()
        {
            var expectedText = new List<string>() { "point", "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<string>() { "very point", "very police", "very polite", "very pool", "very popular" };

            SearchIndexClient client = GetClientForQuery();

            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTerm, UseFuzzyMatching = false };
            AutocompleteResult response = client.Documents.Autocomplete("very po", "sg", autocompleteParameters);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteThrowsWhenRequestIsMalformed()
        {
            SearchIndexClient client = GetClientForQuery();

            SearchAssert.ThrowsCloudException(
                () => client.Documents.Autocomplete("very po", string.Empty),
                HttpStatusCode.BadRequest,
                "Cannot find fields enabled for suggestions. Please provide a value for 'suggesterName' in the query.\r\nParameter name: suggestions");
        }

        protected void TestAutcompleteThrowsWhenGivenBadSuggesterName()
        {
            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTerm };

            SearchAssert.ThrowsCloudException(
                () => client.Documents.Autocomplete("very po", "Invalid suggester", autocompleteParameters),
                HttpStatusCode.BadRequest,
                "The specified suggester name 'Invalid suggester' does not exist in this index definition.\r\nParameter name: name");
        }
        
        protected void TestAutocompleteFuzzyIsOffByDefault()
        {
            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTerm };

            AutocompleteResult response = client.Documents.Autocomplete("pi", "sg", autocompleteParameters);

            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestAutocompleteOneTerm()
        {
            var expectedText = new List<string>() { "point", "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<string>() { "point", "police", "polite", "pool", "popular" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTerm };

            AutocompleteResult response = client.Documents.Autocomplete("po", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteDefaultsToOneTermMode()
        {
            var expectedText = new List<string>() { "point", "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<string>() { "point", "police", "polite", "pool", "popular" };

            SearchIndexClient client = GetClientForQuery();

            AutocompleteResult response = client.Documents.Autocomplete("po", "sg");

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteTwoTerms()
        {
            var expectedText = new List<string>() { "point motel", "police station", "polite staff", "pool a", "popular hotel" };
            var expectedQueryPlusText = new List<string>() { "point motel", "police station", "polite staff", "pool a", "popular hotel" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.TwoTerms };

            AutocompleteResult response = client.Documents.Autocomplete("po", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteOneTermWithContext()
        {
            var expectedText = new List<string>() { "very police", "very polite", "very popular" };
            var expectedQueryPlusText = new List<string>() { "looking for very police", "looking for very polite", "looking for very popular" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTermWithContext };

            AutocompleteResult response = client.Documents.Autocomplete("looking for very po", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteOneTermWithFuzzy()
        {
            var expectedText = new List<string>() { "model", "modern", "morel", "motel" };
            var expectedQueryPlusText = new List<string>() { "model", "modern", "morel", "motel" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTerm, UseFuzzyMatching = true };

            AutocompleteResult response = client.Documents.Autocomplete("mod", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteTwoTermsWithFuzzy()
        {
            var expectedText = new List<string>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };
            var expectedQueryPlusText = new List<string>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.TwoTerms, UseFuzzyMatching = true };
            AutocompleteResult response = client.Documents.Autocomplete("mod", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteOneTermWithContextWithFuzzy()
        {
            var expectedText = new List<string>() { "very polite", "very police" };
            var expectedQueryPlusText = new List<string>() { "very polite", "very police" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters() { AutocompleteMode = AutocompleteMode.OneTermWithContext, UseFuzzyMatching = true };
            AutocompleteResult response = client.Documents.Autocomplete("very polit", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteCanUseHitHighlighting()
        {
            var expectedText = new List<string>() { "pool", "popular" };
            var expectedQueryPlusText = new List<string>() { "<b>pool</b>", "<b>popular</b>" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                Filter = "hotelName eq 'EconoStay' or hotelName eq 'Fancy Stay'",
                HighlightPreTag = "<b>",
                HighlightPostTag = "</b>",
            };
            AutocompleteResult response = client.Documents.Autocomplete("po", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteTopTrimsResults()
        {
            var expectedText = new List<string>() { "point", "police" };
            var expectedQueryPlusText = new List<string>() { "point", "police" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                Top = 2
            };
            AutocompleteResult response = client.Documents.Autocomplete("po", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteWithSelectedFields()
        {
            var expectedText = new List<string>() { "modern"};
            var expectedQueryPlusText = new List<string>() { "modern" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                SearchFields = new[] { "hotelName" },
                Filter = "hotelId eq '7'"
            };
            AutocompleteResult response = client.Documents.Autocomplete("mod", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteWithMultipleSelectedFields()
        {
            var expectedText = new List<string>() { "model", "modern" };
            var expectedQueryPlusText = new List<string>() { "model", "modern" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                SearchFields = new[] { "hotelName", "description" }
            };
            AutocompleteResult response = client.Documents.Autocomplete("mod", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteExcludesFieldsNotInSuggester()
        {
            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                SearchFields = new[] { "hotelName" }
            };
            AutocompleteResult response = client.Documents.Autocomplete("luxu", "sg", autocompleteParameters);

            Assert.NotNull(response);
            Assert.NotNull(response.Results);
            Assert.Equal(0, response.Results.Count);
        }

        protected void TestAutocompleteWithFilter()
        {
            var expectedText = new List<string>() { "polite" };
            var expectedQueryPlusText = new List<string>() { "polite" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                Filter = "search.in(hotelId, '6,7')",
            };

            AutocompleteResult response = client.Documents.Autocomplete("po", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        protected void TestAutocompleteWithFilterAndFuzzy()
        {
            var expectedText = new List<string>() { "modern", "motel" };
            var expectedQueryPlusText = new List<string>() { "modern", "motel" };

            SearchIndexClient client = GetClientForQuery();
            var autocompleteParameters = new AutocompleteParameters()
            {
                AutocompleteMode = AutocompleteMode.OneTerm,
                UseFuzzyMatching = true,
                Filter = "hotelId ne '6' and (hotelName eq 'Modern Stay' or tags/any(t : t eq 'budget'))"
            };

            AutocompleteResult response = client.Documents.Autocomplete("mod", "sg", autocompleteParameters);

            Assert.NotNull(response);
            ValidateResults(response.Results, expectedText, expectedQueryPlusText);
        }

        private void ValidateResults(IList<AutocompleteItem> autocompletedItems, List<string> expectedText, List<string> expectedQueryPlusText)
        {
            Assert.Equal(expectedText, autocompletedItems.Select(c => c.Text));
            Assert.Equal(expectedQueryPlusText, autocompletedItems.Select(c => c.QueryPlusText));
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
