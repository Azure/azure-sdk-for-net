// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class AutocompleteTests : SearchTestBase
    {
        public AutocompleteTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private static void VerifyCompletions(
            AutocompleteResults completions,
            IEnumerable<string> expectedText,
            IEnumerable<string> expectedQueryPlusText)
        {
            Assert.NotNull(completions);
            Assert.NotNull(completions.Results);
            Assert.NotNull(expectedText);
            Assert.NotNull(expectedQueryPlusText);

            // TODO: #16824 - investigate autocompletions across SKUs
            CollectionAssert.IsSubsetOf(completions.Results.Select(c => c.Text), expectedText);
            CollectionAssert.IsSubsetOf(completions.Results.Select(c => c.QueryPlusText), expectedQueryPlusText);
        }

        [Test]
        public async Task StaticallyTypedDocuments()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "very po",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        UseFuzzyMatching = false
                    }),
                new[] { "point", "police", "polite", "pool", "popular" },
                new[] { "very point", "very police", "very polite", "very pool", "very popular" });
        }

        [Test]
        public async Task ThrowsWhenNoSuggesterName()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await resources.GetQueryClient().AutocompleteAsync(
                    "very po",
                    suggesterName: string.Empty));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith(
                "Cannot find fields enabled for suggestions. Please provide a value for 'suggesterName' in the query.",
                ex.Message);
        }

        [Test]
        public async Task ThrowsWhenBadSuggesterName()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            string invalidName = "Invalid suggester";
            RequestFailedException ex = await CatchAsync<RequestFailedException>(
                async () => await resources.GetQueryClient().AutocompleteAsync(
                    "very po",
                    invalidName,
                    new AutocompleteOptions { Mode = AutocompleteMode.OneTerm }));
            Assert.AreEqual(400, ex.Status);
            StringAssert.StartsWith(
                $"The specified suggester name '{invalidName}' does not exist in this index definition.",
                ex.Message);
        }

        [Test]
        public async Task FuzzyIsOffByDefault()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "pi",
                    "sg",
                    new AutocompleteOptions { Mode = AutocompleteMode.OneTerm }),
                Enumerable.Empty<string>(),
                Enumerable.Empty<string>());
        }

        [Test]
        public async Task OneTerm()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "po",
                    "sg",
                    new AutocompleteOptions { Mode = AutocompleteMode.OneTerm }),
                new[] { "point", "police", "polite", "pool", "popular" },
                new[] { "point", "police", "polite", "pool", "popular" });
        }

        [Test]
        public async Task OneTermOnByDefault()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync("po", "sg"),
                new[] { "point", "police", "polite", "pool", "popular" },
                new[] { "point", "police", "polite", "pool", "popular" });
        }

        [Test]
        public async Task TwoTerms()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "po",
                    "sg",
                    new AutocompleteOptions { Mode = AutocompleteMode.TwoTerms }),
                new[] { "point motel", "police station", "polite staff", "pool a", "popular hotel" },
                new[] { "point motel", "police station", "polite staff", "pool a", "popular hotel" });
        }

        [Test]
        public async Task OneTermWithContext()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "looking for very po",
                    "sg",
                    new AutocompleteOptions { Mode = AutocompleteMode.OneTermWithContext }),
                new[] { "very police", "very polite", "very popular" },
                new[] { "looking for very police", "looking for very polite", "looking for very popular" });
        }

        [Test]
        public async Task OneTermWithFuzzy()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "mod",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        UseFuzzyMatching = true
                    }),
                new[] { "model", "modern", "morel", "motel" },
                new[] { "model", "modern", "morel", "motel" });
        }

        [Test]
        public async Task TwoTermsWithFuzzy()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "mod",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.TwoTerms,
                        UseFuzzyMatching = true
                    }),
                new[] { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" },
                new[] { "model suites", "modern architecture", "modern stay", "morel coverings", "motel" });
        }

        [Test]
        public async Task OneTermWithContextWithFuzzy()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "very polit",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTermWithContext,
                        UseFuzzyMatching = true
                    }),
                new[] { "very polite", "very police" },
                new[] { "very polite", "very police" });
        }

        [Test]
        public async Task HitHighlighting()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "po",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        Filter = "hotelName eq 'EconoStay' or hotelName eq 'Fancy Stay'",
                        HighlightPreTag = "<b>",
                        HighlightPostTag = "</b>",
                    }),
                new[] { "pool", "popular" },
                new[] { "<b>pool</b>", "<b>popular</b>" });
        }

        [Test]
        public async Task SizeTrimsResults()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "po",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        Size = 2
                    }),
                new[] { "point", "police" },
                new[] { "point", "police" });
        }

        [Test]
        public async Task SelectedFields()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "mod",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        SearchFields = new[] { "hotelName" },
                        Filter = "hotelId eq '7'"
                    }),
                new[] { "modern" },
                new[] { "modern" });
        }

        [Test]
        public async Task MultipleSelectedFields()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "mod",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        SearchFields = new[] { "hotelName", "description" }
                    }),
                new[] { "model", "modern" },
                new[] { "model", "modern" });
        }

        [Test]
        public async Task ExcludesFieldsNotInSuggester()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "luxu",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        SearchFields = new[] { "hotelName" }
                    }),
                Enumerable.Empty<string>(),
                Enumerable.Empty<string>());
        }

        [Test]
        public async Task Filter()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "po",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        Filter = "search.in(hotelId, '6,7')"
                    }),
                new[] { "polite" },
                new[] { "polite" });
        }

        [Test]
        public async Task FilterAndFuzzy()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            VerifyCompletions(
                await resources.GetQueryClient().AutocompleteAsync(
                    "mod",
                    "sg",
                    new AutocompleteOptions
                    {
                        Mode = AutocompleteMode.OneTerm,
                        UseFuzzyMatching = true,
                        Filter = "hotelId ne '6' and (hotelName eq 'Modern Stay' or tags/any(t : t eq 'budget'))"
                    }),
                new[] { "modern", "motel" },
                new[] { "modern", "motel" });
        }
    }
}
