// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    // MAINTENANCE NOTE: Test methods (those marked with [Fact]) need to be in the derived classes in order for
    // the mock recording/playback to work properly.
    public class AutocompleteTests : QueryTests
    {
        [Fact]
        public void TestAutocompleteGetStaticallyTypedDocuments()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "very police", "very polite", "very pool", "very popular" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();

                var autocompleteParameters = new AutocompleteParametersPayload() { Fuzzy = false };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "very po", "sg", autocompleteParametersPayload: autocompleteParameters);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });
        }
        
        [Fact]
        public void TestAutocompletePostStaticallyTypedDocuments()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "very police", "very polite", "very pool", "very popular" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();

                var autocompleteRequest = new AutocompleteRequest() { Fuzzy = false, AutocompleteMode = AutocompleteMode.OneTerm, SuggesterName = "sg", Search = "very po" };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });
        }

        [Fact]
        public void TestAutocompleteGetThrowsWhenRequestIsMalformed()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClient();

                var autocompleteRequest = new AutocompleteRequest() { Fuzzy = false, AutocompleteMode = AutocompleteMode.OneTerm, Search = "very po" };
                SearchAssert.ThrowsCloudException(
                    () => client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "very po", null),
                    HttpStatusCode.BadRequest,
                    "Cannot find fields enabled for suggestions. Please provide a value for 'suggesterName' in the query.\r\nParameter name: suggestions");
            });           
        }

        [Fact]
        public void TestAutocompletePostThrowsWhenRequestIsMalformed()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClient();

                var autocompleteRequest = new AutocompleteRequest() { Fuzzy = false, AutocompleteMode = AutocompleteMode.OneTerm, Search = "very po" };
                SearchAssert.ThrowsCloudException(
                    () => client.Documents.AutocompletePost(autocompleteRequest),
                    HttpStatusCode.BadRequest,
                    "The request is invalid. Details: parameters : One or more parameters of the operation 'autocomplete' are missing from the request payload. The missing parameters are: suggesterName.");
            });            
        }

        [Fact]
        public void TestAutcompleteGetThrowsWhenGivenBadSuggesterName()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClient();
                SearchAssert.ThrowsCloudException(
                    () => client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "very po", "Invalid suggester"),
                    HttpStatusCode.BadRequest,
                    "The specified suggester name 'Invalid suggester' does not exist in this index definition.\r\nParameter name: name");
            });            
        }

        [Fact]
        public void TestAutcompletePostThrowsWhenGivenBadSuggesterName()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClient();
                var autocompleteRequest = new AutocompleteRequest() { Fuzzy = false, AutocompleteMode = AutocompleteMode.OneTerm, Search = "very po", SuggesterName = "Invalid suggester" };
                SearchAssert.ThrowsCloudException(
                    () => client.Documents.AutocompletePost(autocompleteRequest),
                    HttpStatusCode.BadRequest,
                    "The specified suggester name 'Invalid suggester' does not exist in this index definition.\r\nParameter name: name");
            });            
        }
        
        public void TestAutocompleteGetFuzzyIsOffByDefault()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "pi", "sg");

                Assert.NotNull(result.Value);
                Assert.Equal(0, result.Value.Count);
            });            
        }

        [Fact]
        public void TestAutocompletePostFuzzyIsOffByDefault()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.OneTerm, Search = "pi", SuggesterName = "sg" };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result.Value);
                Assert.Equal(0, result.Value.Count);
            });           
        }

        [Fact]
        public void TestAutocompleteGetOneTerm()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "police", "polite", "pool", "popular" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "po", "sg");

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompleteGetTwoTerms()
        {
            var expectedText = new List<String>() { "police station", "polite staff", "pool a", "popular hotel" };
            var expectedQueryPlusText = new List<String>() { "police station", "polite staff", "pool a", "popular hotel" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.TwoTerms, "po", "sg");

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });                     
        }

        [Fact]
        public void TestAutocompleteGetOneTermWithContext()
        {
            var expectedText = new List<String>() { "very police", "very polite", "very popular" };
            var expectedQueryPlusText = new List<String>() { "looking for very police", "looking for very polite", "looking for very popular" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTermWithContext, "looking for very po", "sg");

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });          
        }

        [Fact]
        public void TestAutocompletePostOneTerm()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "police", "polite", "pool", "popular" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.OneTerm, Search = "po", SuggesterName = "sg" };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompletePostTwoTerms()
        {
            var expectedText = new List<String>() { "police station", "polite staff", "pool a", "popular hotel" };
            var expectedQueryPlusText = new List<String>() { "police station", "polite staff", "pool a", "popular hotel" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.TwoTerms, Search = "po", SuggesterName = "sg" };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });            
        }

        [Fact]
        public void TestAutocompletePostOneTermWithContext()
        {
            var expectedText = new List<String>() { "very police", "very polite", "very popular" };
            var expectedQueryPlusText = new List<String>() { "looking for very police", "looking for very polite", "looking for very popular" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.OneTermWithContext, Search = "looking for very po", SuggesterName = "sg" };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });          
        }

        [Fact]
        public void TestAutocompleteGetOneTermWithFuzzy()
        {
            var expectedText = new List<String>() { "model", "modern", "morel", "motel" };
            var expectedQueryPlusText = new List<String>() { "model", "modern", "morel", "motel" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload() { Fuzzy = true };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "mod", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompleteGetTwoTermsWithFuzzy()
        {
            var expectedText = new List<String>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };
            var expectedQueryPlusText = new List<String>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload() { Fuzzy = true };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.TwoTerms, "mod", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompleteGetOneTermWithContextWithFuzzy()
        {
            var expectedText = new List<String>() { "very polite", "very police" };
            var expectedQueryPlusText = new List<String>() { "very polite", "very police" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload() { Fuzzy = true };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTermWithContext, "very polit", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompletePostOneTermWithFuzzy()
        {
            var expectedText = new List<String>() { "model", "modern", "morel", "motel" };
            var expectedQueryPlusText = new List<String>() { "model", "modern", "morel", "motel" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.OneTerm, Search = "mod", SuggesterName = "sg", Fuzzy = true };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });            
        }

        [Fact]
        public void TestAutocompletePostTwoTermsWithFuzzy()
        {
            var expectedText = new List<String>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };
            var expectedQueryPlusText = new List<String>() { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.TwoTerms, Search = "mod", SuggesterName = "sg", Fuzzy = true };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompletePostOneTermWithContextWithFuzzy()
        {
            var expectedText = new List<String>() { "very polite", "very police" };
            var expectedQueryPlusText = new List<String>() { "looking for very polite", "looking for very police" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest() { AutocompleteMode = AutocompleteMode.OneTermWithContext, Search = "looking for very polit", SuggesterName = "sg", Fuzzy = true };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });          
        }

        [Fact]
        public void TestAutocompleteGetCanUseHitHighlighting()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "<b>police</b>", "<b>polite</b>", "<b>pool</b>", "<b>popular</b>" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload()
                {
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>",
                };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "po", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });           
        }

        [Fact]
        public void TestAutocompletePostCanUseHitHighlighting()
        {
            var expectedText = new List<String>() { "police", "polite", "pool", "popular" };
            var expectedQueryPlusText = new List<String>() { "<b>police</b>", "<b>polite</b>", "<b>pool</b>", "<b>popular</b>" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest()
                {
                    AutocompleteMode = AutocompleteMode.OneTerm,
                    Search = "po",
                    SuggesterName = "sg",
                    HighlightPreTag = "<b>",
                    HighlightPostTag = "</b>"
                };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });
        }

        [Fact]
        public void TestAutocompleteGetTopTrimsResults()
        {
            var expectedText = new List<String>() { "police", "polite" };
            var expectedQueryPlusText = new List<String>() { "police", "polite" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload()
                {
                    Top = 2
                };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "po", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });
        }

        [Fact]
        public void TestAutocompletePostTopTrimsResults()
        {
            var expectedText = new List<String>() { "police", "polite" };
            var expectedQueryPlusText = new List<String>() { "police", "polite" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest()
                {
                    AutocompleteMode = AutocompleteMode.OneTerm,
                    Search = "po",
                    SuggesterName = "sg",
                    Top = 2
                };

                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });
        }

        [Fact]
        public void TestAutocompleteGetWithSelectedFields()
        {
            var expectedText = new List<String>() { "modern"};
            var expectedQueryPlusText = new List<String>() { "modern" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload()
                {
                    SearchFields = "hotelName"
                };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "mod", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);
            });
            
        }

        [Fact]
        public void TestAutocompletePostWithSelectedFields()
        {
            var expectedText = new List<String>() { "modern" };
            var expectedQueryPlusText = new List<String>() { "modern" };

            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest()
                {
                    AutocompleteMode = AutocompleteMode.OneTerm,
                    Search = "mod",
                    SuggesterName = "sg",
                    SearchFields = "hotelName"
                };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                ValidateResults(result.Value, expectedText, expectedQueryPlusText);

            });
        }

        [Fact]
        public void TestAutocompleteGetExcludesFieldsNotInSuggester()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteParameters = new AutocompleteParametersPayload()
                {
                    SearchFields = "hotelName"
                };
                AutocompleteResult result = client.Documents.AutocompleteGet(AutocompleteMode.OneTerm, "luxu", "sg", autocompleteParametersPayload: autocompleteParameters);

                Assert.NotNull(result);
                Assert.NotNull(result.Value);
                Assert.Equal(0, result.Value.Count);
            });
        }

        [Fact]
        public void TestAutocompletePostExcludesFieldsNotInSuggester()
        {
            Run(() =>
            {
                SearchIndexClient client = GetClientForQuery();
                var autocompleteRequest = new AutocompleteRequest()
                {
                    AutocompleteMode = AutocompleteMode.OneTerm,
                    Search = "luxu",
                    SuggesterName = "sg",
                    SearchFields = "hotelName"
                };
                AutocompleteResult result = client.Documents.AutocompletePost(autocompleteRequest);

                Assert.NotNull(result);
                Assert.NotNull(result.Value);
                Assert.Equal(0, result.Value.Count);
            });           
        }

        private void ValidateResults(IList<AutocompleteItem> autocompletedItems, List<String> expectedText, List<String> expectedQueryPlusText)
        {
            Assert.Equal(expectedText.Count, autocompletedItems.Count);
            Assert.True(autocompletedItems.Select(c => c.Text).ToList().SequenceEqual(expectedText));
            Assert.True(autocompletedItems.Select(c => c.QueryPlusText).ToList().SequenceEqual(expectedQueryPlusText));
        }
    }
}
